using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NextMeeting.Models
{
    public class ProfileViewModel : INotifyPropertyChanged
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


        private UserViewModel user = null;
        private bool isLoadingTrendings = true;
        private bool isLoadingLastFiles = true;
        private bool isLoadingSharedItems = true;
        private bool hasNoTrends = false;
        private bool hasNoFiles = false;
        private bool hasNoSharedItems = false;
        private Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private CacheManager<SPItemDoc> cacheTrendings;
        private CacheManager<SPItemDoc> cacheDriveItems;
        private CacheManager<SPItemDoc> cacheSharedItems;
        private ObservableCollection<DriveItemViewModel> driveItems;
        private ObservableCollection<DriveItemViewModel> trendings;
        private ObservableCollection<DriveItemViewModel> sharedItems;

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
        public ObservableCollection<UserViewModel> TeamWork { get; set; }
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

        public ProfileViewModel(UserViewModel user)
        {
            this.user = user;
            // get trendings from cache manager
            this.cacheTrendings = CacheManager<SPItemDoc>.Get(user.Email);
            // get files from cache manager
            this.cacheDriveItems = CacheManager<SPItemDoc>.Get(user.Email);
            // get files from cache manager
            this.cacheSharedItems = CacheManager<SPItemDoc>.Get(user.Email);

            this.DriveItems = new ObservableCollection<DriveItemViewModel>();
            this.Trendings = new ObservableCollection<DriveItemViewModel>();
            this.SharedItems = new ObservableCollection<DriveItemViewModel>();
            this.TeamWork = new ObservableCollection<UserViewModel>();
        }

        public async Task Refresh(CancellationToken token, bool forceRefresh = false)
        {
            this.IsLoadingLastFiles = true;
            this.IsLoadingTrendings = true;
            this.IsLoadingSharedItems = true;

      
            // Load files, trendings, work team
            var filesTask = this.LoadFilesAsync(forceRefresh, token);
            var trendsTask = this.LoadTrendingsAsync(forceRefresh, token);
            var teamTask = this.LoadWorkTeamAsync(forceRefresh, token);
            var sharedItemsTask = this.LoadSharedItemsAsync(forceRefresh, token);

            await Task.WhenAll(new[] { filesTask, trendsTask, teamTask, sharedItemsTask });

            await this.UpdateUsers(token);
        }
        private async Task UpdateUsers(CancellationToken token)
        {
            var usersMail = new List<string>();

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

        private async Task LoadWorkTeamAsync(bool forceRefresh, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            this.TeamWork.Clear();

            var teamWork = await SharePointSearchHelper.SPGetWorkingWithUsers(this.user.DocId);

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

            if (forceRefresh)
                this.cacheDriveItems.Clear();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingLastFiles = false;
                return;
            }

            if (this.cacheDriveItems.Values.Count == 0)
            {
                var internalDrivesItems = await SharePointSearchHelper.SPGetLastModifiedByOrViewByUser(this.user.DocId);

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

            if (forceRefresh)
                this.cacheTrendings.Clear();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingTrendings = false;
                return;
            }

            if (this.cacheTrendings.Values.Count == 0)
            {
                var internalTrendingsItems = await SharePointSearchHelper.SPGetTrendingsAroundByUser(this.user.DocId);

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

            if (forceRefresh)
                this.cacheSharedItems.Clear();

            if (token.IsCancellationRequested)
            {
                this.IsLoadingSharedItems = false;
                return;
            }

            if (this.cacheSharedItems.Values.Count == 0)
            {
                var internalItems = await SharePointSearchHelper.SPGetSharedFilesBeetweenUserAndMe(this.user.DocId);

                foreach (var item in internalItems)
                {
                    if (!this.cacheSharedItems.Values.Any(t => t.DocId == item.DocId))
                        this.cacheSharedItems.Values.Add(item);
                }
            }

            this.HasNoSharedItems = this.cacheSharedItems.Values.Count == 0;

            var orderedItems = this.cacheSharedItems.Values.OrderByDescending(t => t.LastModifiedTime).ToList();

            foreach (var item in orderedItems)
                this.SharedItems.Add(new DriveItemViewModel(item));

            this.IsLoadingSharedItems = false;

        }

    }
}
