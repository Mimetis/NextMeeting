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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private bool isLoadingTrendings = true;
        private bool isLoadingLastFiles = true;
        private bool hasNoTrends = false;
        private bool hasNoFiles = false;
        private CacheManager<TrendingViewModel> cacheTrendings;
        private CacheManager<DriveItemViewModel> cacheDriveItems;
        private ObservableCollection<DriveItemViewModel> driveItems;
        private ObservableCollection<TrendingViewModel> trendings;
        private List<Microsoft.Graph.DriveItem> internalDrivesItems;
        private List<TrendingAroundItem> internalTrendings;
        private Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private UserViewModel user;

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

        public ProfileViewModel(UserViewModel user)
        {
            this.user = user;

            // get trendings from cache manager
            this.cacheTrendings = CacheManager<TrendingViewModel>.Get(user.Email);

            // get files from cache manager
            this.cacheDriveItems = CacheManager<DriveItemViewModel>.Get(user.Email);

            this.DriveItems = new ObservableCollection<DriveItemViewModel>();
            this.Trendings = new ObservableCollection<TrendingViewModel>();
        }
        public async Task Refresh(CancellationToken token, bool forceRefresh = false)
        {
            if (token.IsCancellationRequested)
                return;

            this.IsLoadingLastFiles = true;
            this.IsLoadingTrendings = true;

            // Load trendings and files
            await this.LoadTrendingAndFilesAsync(forceRefresh, token);

            await this.UpdateTrendingsAsync(forceRefresh, token);
   
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

            if (internalDrivesItems == null || internalDrivesItems.Count == 0 || forceRefresh)
                internalDrivesItems = await graph.Me.GetLastDriveItems(this.user.Id);

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

            if (internalTrendings == null || internalTrendings.Count == 0 || forceRefresh)
                internalTrendings = await graph.Me.GetUserTrendingAround(this.user.Id);

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
            }
            this.IsLoadingTrendings = false;

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
