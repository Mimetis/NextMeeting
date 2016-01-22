using NextMeeting.Common;
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
        private int groupIndex;
        private Microsoft.Graph.IEvent internalEvent;
        private bool isLoadingTrendings = true;
        private bool isLoading = true;
        private bool isLoadingLastFiles = true;
        private bool hasNoTrends = false;
        private bool hasNoFiles = false;
        private Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private CacheManager<TrendingViewModel> cacheTrendings;
        private CacheManager<DriveItemViewModel> cacheDriveItems;
        private UserViewModel organizer;
        private ObservableCollection<DriveItemViewModel> driveItems;
        private ObservableCollection<DriveItemViewModel> topDriveItems;
        private ObservableCollection<TrendingViewModel> trendings;
        private ObservableCollection<TrendingViewModel> topTrendings;
        private TaskScheduler uiScheduler;
        private List<Microsoft.Graph.DriveItem> internalDrivesItems;
        private List<TrendingAroundItem> internalTrendings;
        

        public Microsoft.Graph.ItemBody Body { get; set; }
        public String Id { get; set; }
        public string BodyPreview { get; set; }
        public String Location { get; set; }
        public ObservableCollection<TrendingViewModel> Trendings
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
        public ObservableCollection<TrendingViewModel> TopTrendings
        {
            get
            {
                return topTrendings;
            }
            set
            {
                topTrendings = value;

                RaisePropertyChanged(nameof(TopTrendings));
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
        public ObservableCollection<DriveItemViewModel> TopDriveItems
        {
            get
            {
                return topDriveItems;
            }
            set
            {
                topDriveItems = value;

                RaisePropertyChanged(nameof(TopDriveItems));
            }
        }
        public ObservableCollection<AttendeeViewModel> Attendees { get; set; }
        public ObservableCollection<SearchItemUser> TeamWork { get; set; }
        
        public ObservableCollection<AttendeeViewModel> TopAttendees
        {
            get
            {
                return new ObservableCollection<AttendeeViewModel>(this.Attendees.Take(TOP_ATTENDEES_NUMBERS).ToList());
            }
        }
        public String ReferenceIndex
        {
            get
            {
                return this.groupIndex + "_" + this.index;
            }
        }
        public String Subject { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public String TimeDelta
        {
            get
            {
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

        public EventViewModel(Microsoft.Graph.IEvent ev, int index, int groupIndex)
        {
            this.IsLoading = true;
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            this.index = index;
            this.groupIndex = groupIndex;
           
            this.Organizer = UserViewModel.GetUser(null, ev.Organizer.EmailAddress.Address, ev.Organizer.EmailAddress.Name);

            // get trendings from cache manager
            this.cacheTrendings = CacheManager<TrendingViewModel>.Get(ev.Organizer.EmailAddress.Address);

            // get files from cache manager
            this.cacheDriveItems = CacheManager<DriveItemViewModel>.Get(ev.Organizer.EmailAddress.Address);

            this.FillItem(ev);

            this.IsLoading = false;

        }

        public async Task Refresh(CancellationToken token, bool forceRefresh = false)
        {
            this.IsLoading = true;
            this.IsLoadingLastFiles = true;
            this.IsLoadingTrendings = true;

            if (forceRefresh)
            {
                var ievent = await graph.Me.Events.GetEventById(this.Id);
                this.FillItem(ievent);
            }
            this.IsLoading = false;

            // Load trendings and files
            var t1 = this.LoadTrendingAndFilesAsync(forceRefresh, token)
                .ContinueWith(async tmp => await this.UpdateTrendingsAsync(forceRefresh, token), token, TaskContinuationOptions.OnlyOnRanToCompletion, uiScheduler);

            var t2 = this.UpdateAttendeesAsync(token);

            var t3 = this.UpdateWorkTeamAsync(token);

            await Task.WhenAll(new[] { t1, t2, t3 });

        }

        private void FillItem(Microsoft.Graph.IEvent ev)
        {
            this.Id = ev.Id;
            this.DriveItems = new ObservableCollection<DriveItemViewModel>();
            this.Trendings = new ObservableCollection<TrendingViewModel>();
            this.TopDriveItems = new ObservableCollection<DriveItemViewModel>();
            this.TopTrendings = new ObservableCollection<TrendingViewModel>();
            this.InternalEvent = ev;
            this.Subject = ev.Subject;
            this.StartingDate = DateTime.Parse(ev.Start.DateTime).ToLocalTime();
            this.EndingDate = DateTime.Parse(ev.End.DateTime).ToLocalTime();
            this.Attendees = new ObservableCollection<AttendeeViewModel>();
            this.TeamWork = new ObservableCollection<SearchItemUser>();
            this.Location = ev.Location.DisplayName;
            this.BodyPreview = ev.BodyPreview;
            this.Body = ev.Body;
            // Adding Attendees
            foreach (var a in ev.Attendees.ToList())
                this.Attendees.Add(new AttendeeViewModel(a));

        }

        // What to update for all other templates in NextMeetings view
        public async Task UpdateMeetingItemAsync(CancellationToken token)
        {

            // Update organizer
            await this.Organizer.UpdateUserAsync(token);

            // Update Photo
            await this.Organizer.UpdatePhotoAsync(token);

        }

        private async Task InternalUpdateFirstMeeting(bool forceRefresh, CancellationToken token)
        {
            await this.Organizer.UpdateUserAsync(token);
            await this.Organizer.UpdatePhotoAsync(token);
            await this.LoadTrendingAndFilesAsync(forceRefresh, token);
            await this.UpdateTopTrendingsAsync(forceRefresh, token);

        }
        // What to update for first template in NextMeetings view
        public async Task UpdateFirstMeetingItemAsync(bool forceRefresh, CancellationToken token)
        {
            //var o1 = Task.Factory.StartNew(async () =>
            //{
            //    await this.Organizer.UpdateUserAsync(token);
            //    await this.Organizer.UpdatePhotoAsync(token);
            //    await this.LoadTrendingAndFilesAsync(forceRefresh, token);
            //    await this.UpdateTopTrendingsAsync(forceRefresh, token);

            //}, token, TaskCreationOptions.None, uiScheduler);

            Task o1 = InternalUpdateFirstMeeting(forceRefresh, token);

            
            //// Update organizer then Photo
            //var o1 = this.Organizer.UpdateUser()
            //    .ContinueWith(async (tmp) => await this.Organizer.UpdatePhoto(), uiScheduler)
            //    .ContinueWith(async (tmp) => await this.LoadTrendingAndFiles(CancellationToken.None), uiScheduler)
            //    .ContinueWith(async (tmp) => await this.UpdateTopTrendings(CancellationToken.None), uiScheduler);

            // Update attendees
            var a1 = this.UpdateTopAttendeesAsync(token);

            try
            {
                // await first steps
                await Task.WhenAll(new[] { o1, a1 });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            // Send tile to start screen tile
            TileHelper.Current.SendEventTileNotification(this);
        }
        private async Task InternalUpdateAttendeesAsync(CancellationToken token, IEnumerable<AttendeeViewModel> attendees)
        {
            if (token.IsCancellationRequested)
                return;

            var users = attendees.Select(a => a.User).ToList();

            if (users == null || users.Count <= 0)
                return;

            // batch update
            await UserViewModel.UpdateUsersAsync(users, token);

        }
        private async Task UpdateWorkTeamAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;
            this.TeamWork.Clear();

            var uri = GraphExtensions.GetManagerByUserUri("ME");

            var uri2 = "search/query?Querytext=%27*%27&Properties=%27GraphQuery:ACTOR(ME\\,action\\:1015)%27&SourceId=%27b09a7990-05ea-4af9-81ef-edfab16c4e31%27&SelectProperties=%27UserName,DocId%27&RowLimit=36";

            var users =await GraphExtensions.SearchUsersAsync(uri2);

            foreach(var u in users)
            {
                this.TeamWork.Add(u);
            }

        }

        public async Task UpdateTopAttendeesAsync(CancellationToken token)
        {
            await InternalUpdateAttendeesAsync(token, this.TopAttendees);
        }
        public async Task UpdateAttendeesAsync(CancellationToken token)
        {
            await InternalUpdateAttendeesAsync(token, this.Attendees);
        }



        public async Task LoadTrendingAndFilesAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            // Load files and trendings
            var files = this.LoadFilesAsync(forceRefresh, token);
            var trends = this.LoadTrendingsAsync(forceRefresh, token);

            await Task.WhenAll(new[] { files, trends });

        }
        private async Task LoadFilesAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.IsLoadingLastFiles = true;
            this.HasNoFiles = false;

            this.DriveItems.Clear();
            this.TopDriveItems.Clear();

            if (internalDrivesItems == null || internalDrivesItems.Count == 0 || forceRefresh)
                internalDrivesItems = await graph.Me.GetLastDriveItems(this.Organizer.Id);

            this.HasNoFiles = internalDrivesItems == null || internalDrivesItems.Count == 0;

            var orderLastFiles = internalDrivesItems.OrderByDescending(t => t.LastModifiedDateTime).ToList();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingLastFiles = false;
                return;
            }

            foreach (var item in orderLastFiles)
            {
                if (!this.cacheDriveItems.Values.Any(t => t.Id == item.Id))
                    this.cacheDriveItems.Values.Add(new DriveItemViewModel(item));

                var itemFromCache = this.cacheDriveItems.Values.First(dvm => dvm.Id == item.Id);

                this.DriveItems.Add(itemFromCache);

                if (orderLastFiles.IndexOf(item) < TOP_ITEMS_NUMBERS)
                    this.TopDriveItems.Add(itemFromCache);
            }
            this.IsLoadingLastFiles = false;

        }
        private async Task LoadTrendingsAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.IsLoadingTrendings = true;
            this.HasNoTrends = false;

            Debug.WriteLine("Clear Trendings and TopTrendings");

            this.Trendings.Clear();
            this.TopTrendings.Clear();

            if (internalTrendings == null || internalTrendings.Count == 0 || forceRefresh)
                internalTrendings = await graph.Me.GetUserTrendingAround(this.Organizer.Id);

            this.HasNoTrends = internalTrendings == null || internalTrendings.Count == 0;

            var orderedTrendings = internalTrendings.OrderByDescending(t => t.DateTimeLastModified).ToList();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingTrendings = false;
                return;
            }

            foreach (var item in orderedTrendings)
            {
                if (!this.cacheTrendings.Values.Any(t => t.Id == item.Id))
                    this.cacheTrendings.Values.Add(new TrendingViewModel(item));

                var itemFromCache = this.cacheTrendings.Values.First(dvm => dvm.Id == item.Id);
                Debug.WriteLine("Add item to Trendings");
                this.Trendings.Add(itemFromCache);

                if (orderedTrendings.IndexOf(item) < TOP_ITEMS_NUMBERS)
                {
                    Debug.WriteLine("Add item to TopTrendings");
                    this.TopTrendings.Add(itemFromCache);
                }
            }
            this.IsLoadingTrendings = false;

        }
        public async Task UpdateTopTrendingsAsync(bool forceRefresh, CancellationToken token)
        {
            Debug.WriteLine("UpdateTopTrendingsAsync");
            await InternalUpdateTrendingsAsync(this.TopTrendings, forceRefresh, token);
        }
        public async Task UpdateTrendingsAsync(bool forceRefresh, CancellationToken token)
        {
            Debug.WriteLine("UpdateTrendingsAsync");
            await InternalUpdateTrendingsAsync(this.Trendings, forceRefresh, token);
        }
        private async Task InternalUpdateTrendingsAsync(IEnumerable<TrendingViewModel> trendings, bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            // Clone list to avoid collection modified behavior
            var trendingsClone = trendings.Select(t => t).ToList();

            foreach (var trend in trendingsClone)
            {

                if (token.IsCancellationRequested)
                    return;

                // Already loaded
                if (trend.Odata_id == null && !forceRefresh)
                    continue;

                // Already updated
                if (trend.CreatedByUser != UserViewModel.Empty && !forceRefresh)
                    continue;

                var dsq = graph.Context.CreateQuery<Microsoft.Graph.DriveItem>(trend.Odata_id);
                try
                {
                    var items = await graph.Context.ExecuteAsync<Microsoft.Graph.DriveItem, Microsoft.Graph.IDriveItem>(dsq);

                    if (token.IsCancellationRequested)
                        return;


                    if (items.CurrentPage.Count > 0)
                    {
                        var item = items.CurrentPage[0];

                        var itemb = this.Trendings.FirstOrDefault(i => i.Id == item.Id);

                        if (itemb != null)
                        {
                            itemb.Update(item);

                            var user = UserViewModel.GetUser(item.CreatedBy.User.Id, null, null);
                            await user.UpdateUserAsync(token);
                            //await user.UpdatePhotoAsync(token);

                            if (token.IsCancellationRequested)
                                return;

                            var user2 = UserViewModel.GetUser(item.LastModifiedBy.User.Id, null, null);
                            await user2.UpdateUserAsync(token);
                            //await user2.UpdatePhotoAsync(token);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                if (token.IsCancellationRequested)
                    return;

            }
        }


    }
}
