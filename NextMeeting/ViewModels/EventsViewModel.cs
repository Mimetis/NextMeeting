using Microsoft.Graph;
using NextMeeting.Helpers;
using NextMeeting.Models;
using NextMeeting.Navigation;
using NextMeeting.Services;
using NextMeeting.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NextMeeting.ViewModels
{
    public class EventsViewModel : INotifyPropertyChanged, IRefresh
    {
        private INavigationService navigationService;
        private readonly IUserProvider userProvider;
        private readonly IGraphServiceClient graphServiceClient;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private IEnumerable<IGrouping<DateTime, EventModel>> events;


        public EventsViewModel(INavigationService navigationService, IGraphProvider graphProvider, IUserProvider userProvider)
        {
            this.navigationService = navigationService;
            this.userProvider = userProvider;
            this.graphServiceClient = graphProvider.GetAuthenticatedGraphClient();

        }


        /// <summary>
        /// Gets or Sets the events grouped by day
        /// </summary>
        public IEnumerable<IGrouping<DateTime, EventModel>> Events
        {
            get
            {
                return events;
            }
            private set
            {
                if (value != events)
                {
                    events = value;
                    RaisePropertyChanged(nameof(Events));
                }
            }
        }


        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            var eventModel = e.ClickedItem as EventModel;
            this.navigationService.NavigateToPage<EventDetails>(eventModel);
        }


        /// <summary>
        /// Refresh all events 
        /// </summary>
        public async Task RefreshAsync(object parameter)
        {
            // set calendar request options
            // Dont start with UtcNow to not go on yesterday
            var start = DateTime.UtcNow.Date.ToString("o");
            var end = DateTime.UtcNow.Date.AddDays(7).ToString("o");

            IUserCalendarViewCollectionRequest calendarRequest;

            

            calendarRequest = this.graphServiceClient.Me.CalendarView.Request();
            calendarRequest.QueryOptions.Add(new QueryOption("startDateTime", start));
            calendarRequest.QueryOptions.Add(new QueryOption("endDateTime", end));

            //if (forceRefresh)
            //    this.events.Clear();

            try
            {
                var newEvents = new List<Event>();
                var userCalendarView = await calendarRequest.GetAsync();
                newEvents.AddRange(userCalendarView.CurrentPage);

                while (userCalendarView.NextPageRequest != null)
                {
                    userCalendarView = await userCalendarView.NextPageRequest.GetAsync();
                    newEvents.AddRange(userCalendarView.CurrentPage);
                }

                // some events could start yesterday and finish today
                // make a copy to be able to remove them safely
                var queryableEvents = newEvents.Where(ev => DateTime.Parse(ev.Start.DateTime).ToLocalTime() > DateTime.Now.ToLocalTime());

                queryableEvents = queryableEvents.OrderBy(ev => DateTime.Parse(ev.Start.DateTime))
                                                  .OrderBy(ev => ev.IsAllDay);

                var events = new List<EventModel>();
                var index = 0;
                foreach (var e in queryableEvents)
                {
                    var em = new EventModel(e);
                    em.Index = index;
                    events.Add(em);
                    index++;
                }

                // Making the events, grouped by date
                var gEvents = from e in events
                              group e by e.StartingDate.Date;

                this.Events = gEvents;

                await this.UpdateSharedItems();

                await this.UpdateUsers();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private async Task UpdateSharedItems()
        {

            // select all attendees
            var allEvents = this.Events.SelectMany(ev => ev);

            foreach (var firstEvent in allEvents)
            {
                //// get first event
                //var firstEvent = this.Events.SelectMany(ev => ev).FirstOrDefault(ev => ev.Index == 0);

                //if (firstEvent == null)
                //    return;

                var organizer = firstEvent.Organizer;

                firstEvent.IsLoadingSharedItems = true;

                var lstSharedItems = await this.graphServiceClient.GetInsightsUsed(organizer.UserPrincipalName);

                firstEvent.HasNoSharedItems = lstSharedItems == null || lstSharedItems.Count == 0;

                try
                {

                    foreach (var sharedItems in lstSharedItems)
                    {
                        //if (!String.IsNullOrEmpty(sharedItems.PreviewImageUrl))
                        //{
                        //    string reqString = sharedItems.PreviewImageUrl;

                        //    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, reqString);

                        //    await this.graphServiceClient.AuthenticationProvider.AuthenticateRequestAsync(message);
                        //    var response = await this.graphServiceClient.HttpProvider.SendAsync(message);

                        //    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        //        continue;

                        //    var bitmapImage = new BitmapImage();

                        //    using (var stream = await response.Content.ReadAsStreamAsync())
                        //    {
                        //        using (var mStream = stream.AsRandomAccessStream())
                        //        {
                        //            await bitmapImage.SetSourceAsync(mStream);
                        //        }
                        //    }

                        //    sharedItems.PreviewImage = bitmapImage;

                        //}

                        firstEvent.TopSharedItems.Add(sharedItems);
                    }

                    firstEvent.IsLoadingSharedItems = false;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);

                }
            }

        }

        private async Task UpdateUsers()
        {
            try
            {
                // Updating all organizers
                List<string> usersMail = new List<string>();

                // select all attendees
                var allEvents = this.Events.SelectMany(ev => ev);

                // for first meeting, get top 10 attendees
                var firstMeetingAttendees = allEvents.Where(ev => ev.Index == 0)
                                                     .SelectMany(ev => ev.Attendees.Take(10));

                // get all organizers
                var allOrganizers = allEvents.Select(ev => ev.Organizer);

                // union both
                var allUsers = firstMeetingAttendees.Union(allOrganizers);


                // select all mails, make a distinct, and check we did not already get their profile
                var mails = allUsers.Select(a => a.Email)
                                     .Union(allUsers.Select(a => a.UserPrincipalName))
                                     .Distinct()
                                     .Where(mail => !string.IsNullOrEmpty(mail))
                                     .ToList();

                var newUsers = await this.userProvider.GetUsers(mails);

                if (newUsers == null)
                    return;

                // now fill UserViewModel with good user
                foreach (var user in newUsers)
                {
                    var existingUserModel = allUsers.FirstOrDefault(u =>
                            (!String.IsNullOrEmpty(user.Mail) && !String.IsNullOrEmpty(u.Email) &&
                            u.Email.Equals(user.Mail, StringComparison.CurrentCultureIgnoreCase)) ||
                            (!String.IsNullOrEmpty(user.UserPrincipalName) && !String.IsNullOrEmpty(u.UserPrincipalName) &&
                            u.UserPrincipalName.Equals(user.UserPrincipalName, StringComparison.CurrentCultureIgnoreCase)));

                    if (existingUserModel != null)
                    {
                        existingUserModel.FillUser(user);

                        if (!existingUserModel.IsLoadedPhoto)
                        {
                            var userPhoto = await this.graphServiceClient.GetUserPhoto(existingUserModel.Email);
                            existingUserModel.Photo = userPhoto.PhotoBitmap;
                            existingUserModel.PhotoUri = userPhoto.PhotoUri;
                            existingUserModel.IsLoadedPhoto = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

    }

    public class MeetingTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstMeetingTemplate { get; set; }
        public DataTemplate MeetingTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            EventModel eventDvm = (EventModel)item;
            return FirstMeetingTemplate;
            //return eventDvm.Index == 0 ? FirstMeetingTemplate : MeetingTemplate;

        }


    }
}
