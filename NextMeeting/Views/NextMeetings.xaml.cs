using Microsoft.OData.Client;
using NextMeeting.Common;
using NextMeeting.Graph;
using NextMeeting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
using System.Diagnostics;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NextMeeting.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NextMeetings : BasePage, IRefreshPage
    {
        private CacheManager<EventViewModel> cacheEventDays;
        private ObservableCollection<EventDayViewModel> eventDays = new ObservableCollection<EventDayViewModel>();
        public override string Title
        {
            get
            {
                return "next meetings";
            }
        }
        public NextMeetings()
        {
            this.InitializeComponent();
            EventViewModelCS.Source = this.Events;

            // Get cache manager
            cacheEventDays = CacheManager<EventViewModel>.Get("EventDays");

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        public ObservableCollection<EventDayViewModel> Events
        {
            get
            {
                return eventDays;
            }
            set
            {
                eventDays = value;

                RaisePropertyChanged(nameof(Events));
            }
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            using (this.TokenSource = new CancellationTokenSource())
            {
                try
                {
                    this.IsRefreshButtonEnabled = false;
                    await Refresh(this.TokenSource.Token, false);

                    await TaskHelper.Current.RegisterTileBackgroundTask();
                }
                catch (OperationCanceledException ex)
                {
                    Debug.WriteLine("Operation canceled " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    this.IsRefreshButtonEnabled = true;
                }

            }

        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
        public async Task Refresh()
        {
            using (this.TokenSource = new CancellationTokenSource())
            {
                try
                {
                    this.IsRefreshButtonEnabled = false;
                    await Refresh(this.TokenSource.Token, true);
                }
                catch (OperationCanceledException ex)
                {
                    Debug.WriteLine("Operation canceled " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    this.IsRefreshButtonEnabled = true;
                }

            }
        }
        public async Task Refresh(CancellationToken token, bool forceRefresh = false)
        {
            //this.Events.Clear();

            EventsProgressBarr.Visibility = Visibility.Visible;
            EventsProgressBarr.IsIndeterminate = true;

            this.SetTitle("refreshing next meetings ...");

            var needEvents = this.Events.Count == 0;

            if (needEvents)
            {
                StackPanelLoader.Visibility = Visibility.Visible;
                StackPanelLoader.Opacity = 1.0d;

                ProgressRingLoader.Visibility = Visibility.Visible;
                EventViewList.Visibility = Visibility.Collapsed;

                ProgressRingLoader.IsActive = true;

            }

            var calenderViewQuery = this.Graph.Me.CalendarView;
            var dsq = (DataServiceQuery<Microsoft.Graph.Event>)calenderViewQuery.Query;

            // Dont start with UtcNow to not go on yesterday
            var start = DateTime.UtcNow.Date.ToString("o");
            var end = DateTime.UtcNow.Date.AddDays(7).ToString("o");

            dsq = dsq.AddQueryOption("startDateTime", start);
            dsq = dsq.AddQueryOption("endDateTime", end);

            List<Microsoft.Graph.IEvent> allEvents = null;

            if (forceRefresh)
                this.cacheEventDays.Clear();

            try
            {
                var events = await this.Graph.Context.ExecuteAsync<Microsoft.Graph.Event, Microsoft.Graph.IEvent>(dsq);
                allEvents = events.CurrentPage.ToList();

                while (events.MorePagesAvailable)
                {
                    events = await events.GetNextPageAsync();
                    allEvents.AddRange(events.CurrentPage.ToList());
                }

                if (allEvents != null)
                {
                    // some events could start yesterday and finish today
                    allEvents = allEvents.Where(ev => DateTime.Parse(ev.Start.DateTime).ToLocalTime() > DateTime.Now.ToLocalTime()).ToList();

                    var allEventsOrdered = allEvents.OrderBy(ev => DateTime.Parse(ev.Start.DateTime)).OrderBy(ev => ev.IsAllDay).ToList();
                    foreach (var ev in allEventsOrdered)
                    {
                        var evm = cacheEventDays.Values.FirstOrDefault(cEvent => cEvent.Id == ev.Id);
                        if (evm == null)
                        {
                            evm = new EventViewModel(ev);
                            cacheEventDays.Values.Add(evm);
                        }

                        evm.Index = allEventsOrdered.IndexOf(ev);

                    }
                    // check if some events are deleted
                    foreach (var cEvent in cacheEventDays.Values.Select(c => c).ToList())
                    {
                        var ev = allEvents.FirstOrDefault(e => e.Id == cEvent.Id);
                        if (ev == null)
                            cacheEventDays.Values.Remove(cEvent);
                    }
                    foreach (var dayEvents in this.Events)
                    {
                        foreach (var cEvent in dayEvents.Events.Select(c => c).ToList())
                        {
                            var ev = allEvents.FirstOrDefault(e => e.Id == cEvent.Id);
                            if (ev == null)
                                dayEvents.Events.Remove(cEvent);
                        }
                    }


                    // get the dates for each group
                    var allDates = cacheEventDays.Values.Select(ced => ced.StartingDate.Date).Distinct().OrderBy(d => d.Date).ToList();

                    foreach (var aDate in allDates)
                    {
                        List<EventViewModel> lstEventViewModel;
                        if (allDates.IndexOf(aDate) == 0)
                            lstEventViewModel = cacheEventDays.Values.Where(ev => ev.StartingDate.Date == aDate).OrderBy(ev => ev.StartingDate).OrderBy(ev => ev.IsAllDay).ToList();
                        else
                            lstEventViewModel = cacheEventDays.Values.Where(ev => ev.StartingDate.Date == aDate).OrderBy(ev => ev.StartingDate).ToList();

                        // get or create the group
                        var edvm = this.Events.FirstOrDefault(ev => ev.DateTime != null && ev.DateTime.Date == aDate);
                        if (edvm == null)
                        {
                            edvm = new EventDayViewModel(aDate, allDates.IndexOf(aDate));

                            var lastIndexOf = this.Events.IndexOf(this.Events.FirstOrDefault(e => e.DateTime.Date >= edvm.DateTime.Date));

                            if (lastIndexOf <= 0 || this.Events.Count == 0)
                                this.Events.Add(edvm);
                            else
                                this.Events.Insert(lastIndexOf, edvm);
                        }

                        foreach (var item in lstEventViewModel)
                        {
                            // if event not exist || i want to force refresh
                            if (!edvm.Events.Any(e => e.Id == item.Id))
                            {
                                var lastIndexOf = edvm.Events.IndexOf(edvm.Events.FirstOrDefault(e => e.StartingDate >= item.StartingDate));

                                if (lastIndexOf <= 0 || this.Events.Count == 0)
                                    edvm.Events.Add(item);
                                else
                                    edvm.Events.Insert(lastIndexOf, item);

                            }
                            else if (edvm.Events.Any(e => e.Id == item.Id) && forceRefresh)
                            {
                                var ev = edvm.Events.First(e => e.Id == item.Id);
                                ev.FillItem(item.InternalEvent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (needEvents)
            {
                var sb = GetStoryboard();

                sb.Completed += async (s, o) =>
                {

                    ProgressRingLoader.IsActive = false;
                    ProgressRingLoader.Visibility = Visibility.Collapsed;
                    StackPanelLoader.Visibility = Visibility.Collapsed;
                    EventViewList.Visibility = Visibility.Visible;

                    AppShell.Current.SetTitle("next meetings");

                    await UpdateUsers(forceRefresh, token);

                };

                sb.Begin();
            }
            else
            {
                await UpdateUsers(forceRefresh, token);
            }
           
            EventsProgressBarr.Visibility = Visibility.Collapsed;
            EventsProgressBarr.IsIndeterminate = false;


        }
        private async Task UpdateUsers(bool forceRefresh, CancellationToken token)
        {
            try
            {
                // Updating all organizers
                List<string> usersMail = new List<string>();

                foreach (var ev in this.Events)
                    usersMail.AddRange(ev.Events.Select(evm => evm.organizerEmail).ToList());

                var distinctUsers = usersMail.Distinct().ToList();
                await UserViewModel.UpdateUsersFromSharepointAsync(distinctUsers, token);

                // For each events, Update Organizer user, Top Attendees, First Trendings and First files items 
                foreach (var ev in this.Events)
                    foreach (var evm in ev.Events)
                        if (evm.Index == 0)
                            evm.UpdateFirstMeetingItemAsync(forceRefresh, token);
                        else
                            evm.UpdateOrganizerUser();


            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }
        private void EventViewList_ItemClick(object sender, ItemClickEventArgs e)
        {
            EventViewModel eventClicked = e.ClickedItem as EventViewModel;
            AppShell.Current.Navigate(typeof(MeetingDetails), eventClicked);
        }

        public Storyboard GetStoryboard()
        {
            DoubleAnimation animationOpacity = new DoubleAnimation();
            animationOpacity.To = 0.0d;
            animationOpacity.From = 1.0d;
            Storyboard.SetTarget(animationOpacity, StackPanelLoader);
            Storyboard.SetTargetProperty(animationOpacity, "Opacity");

            DoubleAnimation animationOpacity2 = new DoubleAnimation();
            animationOpacity2.To = 1.0d;
            animationOpacity2.From = 0.0d;
            Storyboard.SetTarget(animationOpacity2, EventViewList);
            Storyboard.SetTargetProperty(animationOpacity2, "Opacity");

            Storyboard sb = new Storyboard();
            sb.Children.Add(animationOpacity);
            sb.Children.Add(animationOpacity2);

            sb.Duration = animationOpacity.Duration = animationOpacity2.Duration = TimeSpan.FromMilliseconds(150);

            return sb;
        }

    }

    public class MeetingTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstMeetingTemplate { get; set; }
        public DataTemplate MeetingTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            EventViewModel eventDvm = (EventViewModel)item;
            return eventDvm.Index == 0 ? FirstMeetingTemplate : MeetingTemplate;
        }


    }


}
