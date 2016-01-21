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

            var capabilities = await AuthenticationHelper.GetCapabilities();

            var sharepointCapability = capabilities.FirstOrDefault(c => c.Key == "RootSite");

            // your manager
            // search/query?Querytext='*'&amp;Properties='GraphQuery:ACTOR(ME\,action\:1013)'

            // first ten items that you recently modified or viewed
            // search/query?Querytext='*'&amp;Properties='GraphQuery:ACTOR(ME\,OR(action\:1001\,action\:1003))'

            var search = @"search/query?QueryTemplate=%27((NOT%20HideFromDelve%3ATrue)%20AND%20(FileExtension%3Adoc%20OR%20FileExtension%3Adocx%20OR%20FileExtension%3Appt%20OR%20FileExtension%3Apptx%20OR%20FileExtension%3Axls%20OR%20FileExtension%3Axlsx%20OR%20FileExtension%3Apdf%20OR%20ContentTypeId%3A0x010100F3754F12A9B6490D9622A01FE9D8F012*%20OR%20contentclass%3AExternalLink))%27&Properties=%27TitleBasedSummaries%3Atrue,IncludeExternalContent%3Atrue,GraphQuery%3Aand(actor(me%5C%2Caction%5C%3A1021)%5C%2Cactor(me%5C%2Cor(action%5C%3A1021%5C%2Caction%5C%3A1036%5C%2Caction%5C%3A1037%5C%2Caction%5C%3A1039%5C%2Caction%5C%3A1052%5C%2Caction%5C%3A1048))),GraphRankingModel%3Aaction%5C%3A1021%5C%2Cweight%5C%3A1%5C%2CedgeFunc%5C%3Aweight%5C%2CmergeFunc%5C%3Amax%27&SelectProperties=%27Author,AuthorOwsUser,ContentClass,ContentTypeId,DefaultEncodingURL,DocId,DocumentPreviewMetadata,Edges,EditorOwsUser,FileExtension,FileType,HitHighlightedProperties,HitHighlightedSummary,LastModifiedTime,LikeCountLifetime,ListID,ListItemID,MediaDuration,OriginalPath,Path,PictureThumbnailURL,PrivacyIndicator,Rank,SPWebUrl,SecondaryFileExtension,ServerRedirectedPreviewURL,ServerRedirectedURL,SitePath,SiteTitle,Title,ViewCountLifetime,siteID,uniqueID,webID%27&RankingModelId=%270c77ded8-c3ef-466d-929d-905670ea1d72%27&RowLimit=36&ClientType=%27PulseWeb%27&BypassResultTypes=true&EnableQueryRules=false&ProcessBestBets=false&ProcessPersonalFavorites=false";

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync(null, sharepointCapability.Value.ServiceResourceId);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var uri = String.Format("{0}/{1}", sharepointCapability.Value.ServiceEndpointUri.AbsoluteUri, search);
                Uri usersEndpoint = new Uri(uri);

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var r = await response.Content.ReadAsStringAsync();
                    }
                }
            }

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
