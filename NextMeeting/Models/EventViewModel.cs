﻿using NextMeeting.Common;
using NextMeeting.Graph;
using NextMeeting.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Contacts;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NextMeeting.Models
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private const int TOP_ITEMS_NUMBERS = 2;
        private const int TOP_ATTENDEES_NUMBERS = 10;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int index;
        private Microsoft.Graph.IEvent internalEvent;
        private bool isLoadingTrendings = true;
        private bool isLoading = true;
        private bool isLoadingLastFiles = true;
        private bool isLoadingSharedItems = true;
        private bool hasNoTrends = false;
        private bool hasNoFiles = false;
        private bool hasNoSharedItems = false;
        private bool? isAllDay = false;
        internal string organizerEmail;
        private string organizerFriendlyName;
        private string subject;
        private string bodyPreview;
        private string location;
        private DateTime startingDate;
        private DateTime endingDate;
        private Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private CacheManager<SPItemDoc> cacheTrendings;
        private CacheManager<SPItemDoc> cacheDriveItems;
        private CacheManager<SPItemDoc> cacheSharedItems;
        private UserViewModel organizer;
        private ObservableCollection<DriveItemViewModel> driveItems;
        private ObservableCollection<DriveItemViewModel> trendings;
        private ObservableCollection<DriveItemViewModel> sharedItems;
        private ObservableCollection<DriveItemViewModel> topSharedItems;
        private TaskScheduler uiScheduler;

        public Microsoft.Graph.ItemBody Body { get; set; }
        public String Id { get; set; }
        public string BodyPreview
        {
            get
            {
                return bodyPreview;
            }

            set
            {
                bodyPreview = value;
                RaisePropertyChanged(nameof(BodyPreview));
            }
        }
        public bool IsBodyEmpty { get; set; }
        public bool IsLocationUndefined { get; set; }
        public String Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }
        public ObservableCollection<DriveItemViewModel> Trendings
        {
            get
            {
                return trendings;
            }
            set
            {
                trendings = value;

                RaisePropertyChanged(nameof(Trendings));
            }
        }
        public ObservableCollection<DriveItemViewModel> SharedItems
        {
            get
            {
                return sharedItems;
            }

            set
            {
                sharedItems = value;
                RaisePropertyChanged(nameof(SharedItems));
                RaisePropertyChanged(nameof(TopSharedItems));
            }
        }
        public ObservableCollection<DriveItemViewModel> TopSharedItems
        {
            get
            {
                return topSharedItems;
            }
            set
            {
                topSharedItems = value;
                RaisePropertyChanged(nameof(TopSharedItems));
            }
        }
        public ObservableCollection<DriveItemViewModel> DriveItems
        {
            get
            {
                return driveItems;
            }
            set
            {
                driveItems = value;

                RaisePropertyChanged(nameof(DriveItems));
            }
        }
        public ObservableCollection<AttendeeViewModel> Attendees { get; set; }
        public ObservableCollection<UserViewModel> TeamWork { get; set; }
        public ObservableCollection<AttendeeViewModel> TopAttendees
        {
            get
            {
                return new ObservableCollection<AttendeeViewModel>(this.Attendees.Take(TOP_ATTENDEES_NUMBERS).ToList());
            }
        }
        public String Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
                RaisePropertyChanged(nameof(Subject));
            }
        }
        public DateTime StartingDate
        {
            get
            {
                return startingDate;
            }

            set
            {
                startingDate = value;
                RaisePropertyChanged(nameof(StartingDate));
                RaisePropertyChanged(nameof(StartingHourDate));
                RaisePropertyChanged(nameof(TimeDelta));
            }
        }
        public DateTime EndingDate
        {
            get
            {
                return endingDate;
            }

            set
            {
                endingDate = value;
                RaisePropertyChanged(nameof(EndingDate));
                RaisePropertyChanged(nameof(EndingHourDate));
                RaisePropertyChanged(nameof(TimeDelta));
            }
        }
        public String TimeDelta
        {
            get
            {
                if (this.IsAllDay.HasValue && this.IsAllDay.Value)
                    return "All day event";

                return this.StartingHourDate + "-" + this.EndingHourDate;
            }
        }
        public String StartingHourDate
        {
            get
            {
                var hour = this.StartingDate.Hour < 10 ? "0" + this.StartingDate.Hour.ToString() : this.StartingDate.Hour.ToString();
                var min = this.StartingDate.Minute < 10 ? "0" + this.StartingDate.Minute.ToString() : this.StartingDate.Minute.ToString();
                return string.Format("{0}:{1}", hour, min);
            }
        }
        public String EndingHourDate
        {
            get
            {
                var hour = this.EndingDate.Hour < 10 ? "0" + this.EndingDate.Hour.ToString() : this.EndingDate.Hour.ToString();
                var min = this.EndingDate.Minute < 10 ? "0" + this.EndingDate.Minute.ToString() : this.EndingDate.Minute.ToString();
                return string.Format("{0}:{1}", hour, min);
            }
        }
        public bool IsLoadingTrendings
        {
            get
            {
                return isLoadingTrendings;
            }

            set
            {
                isLoadingTrendings = value;
                RaisePropertyChanged(nameof(IsLoadingTrendings));
            }
        }
        public bool IsLoadingLastFiles
        {
            get
            {
                return isLoadingLastFiles;
            }

            set
            {
                isLoadingLastFiles = value;
                RaisePropertyChanged(nameof(IsLoadingLastFiles));
            }
        }
        public bool IsLoadingSharedItems
        {
            get
            {
                return isLoadingSharedItems;
            }

            set
            {
                isLoadingSharedItems = value;
                RaisePropertyChanged(nameof(IsLoadingSharedItems));
            }
        }
        public Microsoft.Graph.IEvent InternalEvent
        {
            get
            {
                return internalEvent;
            }

            set
            {
                internalEvent = value;
                RaisePropertyChanged(nameof(InternalEvent));
            }
        }
        public UserViewModel Organizer
        {
            get
            {
                return organizer;
            }

            set
            {
                organizer = value;
                RaisePropertyChanged(nameof(Organizer));

                if (Organizer != null && Organizer.Name != this.OrganizerFriendlyName)
                    this.OrganizerFriendlyName = Organizer.Name;
            }
        }
        public bool HasNoTrends
        {
            get
            {
                return hasNoTrends;
            }

            set
            {
                hasNoTrends = value;
                RaisePropertyChanged(nameof(HasNoTrends));
            }
        }
        public bool HasNoFiles
        {
            get
            {
                return hasNoFiles;
            }

            set
            {
                hasNoFiles = value;
                RaisePropertyChanged(nameof(HasNoFiles));
            }
        }
        public bool HasNoSharedItems
        {
            get
            {
                return hasNoSharedItems;
            }

            set
            {
                hasNoSharedItems = value;
                RaisePropertyChanged(nameof(HasNoSharedItems));
            }
        }
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                isLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
            }
        }
        public string OrganizerFriendlyName
        {
            get
            {
                return organizerFriendlyName;
            }

            set
            {
                organizerFriendlyName = value;
                RaisePropertyChanged(nameof(OrganizerFriendlyName));
            }
        }
        public bool? IsAllDay
        {
            get
            {
                return isAllDay;
            }

            set
            {
                isAllDay = value;
                RaisePropertyChanged(nameof(IsAllDay));
            }
        }
        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
                RaisePropertyChanged(nameof(Index));
            }
        }
    
        public EventViewModel(Microsoft.Graph.IEvent ev)
        {
            this.IsLoading = true;
            this.uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //this.Index = index;
            //this.GroupIndex = groupIndex;
            this.Id = ev.Id;

            // get trendings from cache manager
            this.cacheTrendings = CacheManager<SPItemDoc>.Get(this.Id + "_trends");
            // get files from cache manager
            this.cacheDriveItems = CacheManager<SPItemDoc>.Get(this.Id + "_files");
            // get files from cache manager
            this.cacheSharedItems = CacheManager<SPItemDoc>.Get(this.Id + "_shared");

            this.FillItem(ev);

            this.IsLoading = false;

        }
        public void FillItem(Microsoft.Graph.IEvent ev)
        {
            this.DriveItems = new ObservableCollection<DriveItemViewModel>();
            this.Trendings = new ObservableCollection<DriveItemViewModel>();
            this.SharedItems = new ObservableCollection<DriveItemViewModel>();
            this.TopSharedItems = new ObservableCollection<DriveItemViewModel>();
            this.InternalEvent = ev;
            this.Subject = ev.Subject;
            this.StartingDate = DateTime.Parse(ev.Start.DateTime).ToLocalTime();
            this.EndingDate = DateTime.Parse(ev.End.DateTime).ToLocalTime();
            this.Attendees = new ObservableCollection<AttendeeViewModel>();
            this.TeamWork = new ObservableCollection<UserViewModel>();
            this.Location = ev.Location.DisplayName;
            this.IsLocationUndefined = String.IsNullOrWhiteSpace(ev.Location.DisplayName);
            this.BodyPreview = ev.BodyPreview;
            this.IsBodyEmpty = String.IsNullOrWhiteSpace(ev.BodyPreview);
            this.Body = ev.Body;
            this.IsAllDay = ev.IsAllDay;
            this.organizerEmail = ev.Organizer.EmailAddress.Address;
            // Temporary Organizer name.
            this.OrganizerFriendlyName = ev.Organizer.EmailAddress.Name;

            // Adding Attendees
            foreach (var a in ev.Attendees.ToList())
                this.Attendees.Add(new AttendeeViewModel(a));

        }
        public async Task Refresh(CancellationToken token, bool forceRefresh = false)
        {
            this.IsLoading = true;
            this.IsLoadingLastFiles = true;
            this.IsLoadingTrendings = true;
            this.IsLoadingSharedItems = true;

            if (forceRefresh)
            {
                var ievent = await graph.Me.Events.GetEventById(this.Id);
                this.FillItem(ievent);
            }
            this.IsLoading = false;

            //Need to find the organizer before trying to get trends and files
            this.UpdateOrganizerUser();

            // Load files, trendings, work team
            var filesTask = this.LoadFilesAsync(forceRefresh, token);
            var trendsTask = this.LoadTrendingsAsync(forceRefresh, token);
            var teamTask = this.LoadWorkTeamAsync(forceRefresh, token);
            var sharedItemsTask = this.LoadSharedItemsAsync(forceRefresh, token);

            await Task.WhenAll(new[] { filesTask, trendsTask, teamTask, sharedItemsTask });

            await this.UpdateUsers(false, token);
        }
        private async Task UpdateUsers(bool onlyTopAttendees, CancellationToken token)
        {
            var usersMail = new List<string>();

            // Add organizer
            usersMail.Add(this.organizerEmail);

            // Add attendees
            usersMail.AddRange(onlyTopAttendees ? this.TopAttendees.Select(a => a.Email) : this.Attendees.Select(a => a.Email));

            // No need to add teamworks
            // usersMail.AddRange(this.TeamWork)

            // Add Last Files viewed items
            usersMail.AddRange(this.DriveItems.Select(d => d.CreatedByUser.UserPrincipalName));
            usersMail.AddRange(this.DriveItems.Select(d => d.LastModifiedByUser.UserPrincipalName));

            // Add Trending items
            usersMail.AddRange(this.Trendings.Select(d => d.CreatedByUser.UserPrincipalName));
            usersMail.AddRange(this.Trendings.Select(d => d.LastModifiedByUser.UserPrincipalName));

            // distinct them
            var distinctUsers = usersMail.Distinct().Where(mail => !string.IsNullOrEmpty(mail)).ToList();

            // update them
            await UserViewModel.UpdateUsersFromSharepointAsync(distinctUsers, token);
        }
        public async Task UpdateFirstMeetingItemAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.UpdateOrganizerUser();

            var loadShareItemsTask = this.LoadSharedItemsAsync(forceRefresh, token);

            Func<CancellationToken, Task> updateUsersAsync = async (bToken) =>
            {
                await this.UpdateUsers(true, bToken);

                //update TopAttendees since they dont have User set
                foreach (var att in this.TopAttendees)
                    att.User = UserViewModel.FindUser(att.Email);
            };
            var updateUsersTask = updateUsersAsync(token);


            await Task.WhenAll(new[] { loadShareItemsTask, updateUsersTask });

            await TaskHelper.Current.SendNotification();
        }
        public void UpdateOrganizerUser()
        {
            var user = UserViewModel.FindUser(this.organizerEmail);

            if (user != null)
                this.Organizer = user;
        }
        private void UpdateAttendees(IEnumerable<AttendeeViewModel> attendees)
        {

            // batch update
            foreach (var attendee in attendees)
            {
                var user = UserViewModel.FindUser(attendee.Email);
                if (user != null)
                    attendee.User = user;
            }
        }
        private async Task LoadWorkTeamAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.TeamWork.Clear();

            if (this.Organizer == null || String.IsNullOrEmpty(this.Organizer.DocId))
                return;

            var teamWork = await SharePointSearchHelper.SPGetWorkingWithUsers(this.Organizer.DocId);

            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var u in teamWork)
            {
                UserViewModel uvm = UserViewModel.MergeFromSharepoint(UserViewModel.GetUser(u.UserName), u);
                this.TeamWork.Add(uvm);
            }

        }
        private async Task LoadFilesAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.IsLoadingLastFiles = true;
            this.HasNoFiles = false;

            this.DriveItems.Clear();

            if (this.Organizer == null || String.IsNullOrEmpty(this.Organizer.DocId))
            {
                this.IsLoadingLastFiles = false;
                return;
            }

            if (forceRefresh)
                this.cacheDriveItems.Clear();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingLastFiles = false;
                return;
            }

            if (this.cacheDriveItems.Values.Count == 0)
            {
                var internalDrivesItems = await SharePointSearchHelper.SPGetLastModifiedByOrViewByUser(this.Organizer.DocId);

                foreach (var item in internalDrivesItems)
                {
                    if (!this.cacheDriveItems.Values.Any(t => t.DocId == item.DocId))
                        this.cacheDriveItems.Values.Add(item);
                }
            }


            this.HasNoFiles = this.cacheDriveItems.Values.Count == 0;

            var orderLastFiles = this.cacheDriveItems.Values.OrderByDescending(t => t.LastModifiedTime).ToList();

            foreach (var item in orderLastFiles)
                this.DriveItems.Add(new DriveItemViewModel(item));
            this.IsLoadingLastFiles = false;

        }
        private async Task LoadTrendingsAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.IsLoadingTrendings = true;
            this.HasNoTrends = false;

            this.Trendings.Clear();

            if (this.Organizer == null || String.IsNullOrEmpty(this.Organizer.DocId))
            {
                this.IsLoadingTrendings = false;
                return;
            }

            if (forceRefresh)
                this.cacheTrendings.Clear();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingTrendings = false;
                return;
            }

            if (this.cacheTrendings.Values.Count == 0)
            {
                var internalTrendingsItems = await SharePointSearchHelper.SPGetTrendingsAroundByUser(this.Organizer.DocId);

                foreach (var item in internalTrendingsItems)
                {
                    if (!this.cacheTrendings.Values.Any(t => t.DocId == item.DocId))
                        this.cacheTrendings.Values.Add(item);
                }
            }


            this.HasNoTrends = this.cacheTrendings.Values.Count == 0;

            var orderedTrendings = this.cacheTrendings.Values.OrderByDescending(t => t.LastModifiedTime).ToList();

            foreach (var item in orderedTrendings)
                this.Trendings.Add(new DriveItemViewModel(item));

            this.IsLoadingTrendings = false;

        }
        private async Task LoadSharedItemsAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.IsLoadingSharedItems = true;
            this.HasNoSharedItems = false;

            this.SharedItems.Clear();
            this.TopSharedItems.Clear();

            if (this.Organizer == null || String.IsNullOrEmpty(this.Organizer.DocId))
            {
                this.IsLoadingSharedItems = false;
                return;
            }

            if (forceRefresh)
                this.cacheSharedItems.Clear();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingSharedItems = false;
                return;
            }

            if (this.cacheSharedItems.Values.Count == 0)
            {
                var internalItems = await SharePointSearchHelper.SPGetSharedFilesBeetweenUserAndMe(this.Organizer.DocId);

                foreach (var item in internalItems)
                {
                    if (!this.cacheSharedItems.Values.Any(t => t.DocId == item.DocId))
                        this.cacheSharedItems.Values.Add(item);
                }
            }


            this.HasNoSharedItems = this.cacheSharedItems.Values.Count == 0;

            var orderedItems = this.cacheSharedItems.Values.OrderByDescending(t => t.LastModifiedTime).ToList();

            foreach (var item in orderedItems)
            {
                var divm = new DriveItemViewModel(item);
                this.SharedItems.Add(divm);

                if (orderedItems.IndexOf(item) < TOP_ITEMS_NUMBERS)
                    this.TopSharedItems.Add(divm);
            }

            this.IsLoadingSharedItems = false;

        }

    }
}
