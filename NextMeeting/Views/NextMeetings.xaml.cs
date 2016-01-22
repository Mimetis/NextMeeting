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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NextMeeting.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NextMeetings : BasePage, IRefreshPage
    {
        private CacheManager<EventDayViewModel> cacheEventDays;
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
            cacheEventDays = CacheManager<EventDayViewModel>.Get("EventDays");

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
            this.Events.Clear();
            // Came back on page. no need to refresh from graph
            if (this.cacheEventDays.Values.Count > 0 && !forceRefresh)
            {
                this.SetTitle(this.Title);

                foreach (var t in this.cacheEventDays.Values)
                    this.Events.Add(t);

                return;
            }

            this.SetTitle("loading next meetings ...");

            StackPanelLoader.Visibility = Visibility.Visible;
            StackPanelLoader.Opacity = 1.0d;

            ProgressRingLoader.Visibility = Visibility.Visible;
            EventViewList.Visibility = Visibility.Collapsed;

            ProgressRingLoader.IsActive = true;

            var calenderViewQuery = this.Graph.Me.CalendarView;
            var dsq = (DataServiceQuery<Microsoft.Graph.Event>)calenderViewQuery.Query;

            var start = DateTime.UtcNow.ToString("o");
            var end = DateTime.UtcNow.AddDays(7).ToString("o");

            dsq = dsq.AddQueryOption("startDateTime", start);
            dsq = dsq.AddQueryOption("endDateTime", end);

            List<Microsoft.Graph.IEvent> allEvents = null;

            if (forceRefresh)
                cacheEventDays.Clear();


            try
            {
                var events = await this.Graph.Context.ExecuteAsync<Microsoft.Graph.Event, Microsoft.Graph.IEvent>(dsq);
                allEvents = events.CurrentPage.ToList();

                while (events.MorePagesAvailable)
                {
                    events = await events.GetNextPageAsync();
                    allEvents.AddRange(events.CurrentPage.ToList());
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (allEvents != null)
            {
                var gEvents = allEvents.GroupBy(ev => DateTime.Parse(ev.Start.DateTime).Date).ToList();
                var gEventsOrdered = gEvents.OrderBy(g => g.Key).ToList();

                for (int i = 0; i <= gEventsOrdered.Count - 1; i++)
                {
                    var evg = gEventsOrdered[i];
                    var key = evg.Key;
                    var lst = evg.ToList().OrderBy(ev => ev.Start.DateTime).ToList();

                    if (!cacheEventDays.Values.Any(temp => temp.DateTime == evg.Key.ToLocalTime()))
                        cacheEventDays.Values.Add(new EventDayViewModel(evg.Key, i, lst));

                    this.Events.Add(cacheEventDays.Values.First(temp => temp.DateTime == evg.Key.ToLocalTime()));

                }
            }


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

            sb.Completed += (s, o) =>
            {

                ProgressRingLoader.IsActive = false;
                ProgressRingLoader.Visibility = Visibility.Collapsed;
                StackPanelLoader.Visibility = Visibility.Collapsed;
                AppShell.Current.SetTitle("next meetings");

            };

            EventViewList.Visibility = Visibility.Visible;
            sb.Begin();

        }
        private void EventViewList_ItemClick(object sender, ItemClickEventArgs e)
        {
            EventViewModel eventClicked = e.ClickedItem as EventViewModel;
            AppShell.Current.Navigate(typeof(MeetingDetails), eventClicked);
        }

    }

    public class MeetingTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstMeetingTemplate { get; set; }
        public DataTemplate MeetingTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            EventViewModel eventDvm = (EventViewModel)item;

            // Dont need to wait 
            if (eventDvm.ReferenceIndex == "0_0")
                eventDvm.UpdateFirstMeetingItemAsync(false, CancellationToken.None);
            else
                eventDvm.UpdateMeetingItemAsync(CancellationToken.None);

            return eventDvm.ReferenceIndex == "0_0" ? FirstMeetingTemplate : MeetingTemplate;
        }


    }


}
