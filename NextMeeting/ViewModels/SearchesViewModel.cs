using Microsoft.Graph;
using Microsoft.Toolkit.Uwp.Helpers;
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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NextMeeting.ViewModels
{
    public class SearchesViewModel : INotifyPropertyChanged, IViewModelNavigable
    {
        private INavigationService navigationService;
        private GraphServiceClient graphServiceClient;
        private CancellationTokenSource cancellationTokenSource;
        private bool isLoading = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();

        public async Task Navigated(NavigationEventArgs e, CancellationToken cancellationToken)
        {
            this.Users.Clear();
            await Task.CompletedTask;
        }

        public async Task Navigating(NavigatingCancelEventArgs e)
        {
            await Task.CompletedTask;
        }


        /// <summary>
        /// you can use IsLoading for any loading purpose
        /// </summary>
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
  

        public SearchesViewModel(INavigationService navigationService, IGraphProvider graphProvider)
        {
            this.navigationService = navigationService;
            this.graphServiceClient = graphProvider.GetAuthenticatedGraphClient();
        }


        private async Task Search(string val, CancellationToken cancellationToken)
        {

            try
            {
                this.IsLoading = true;

                this.Users.Clear();
                List<User> users = new List<User>();
                var filterRequest = this.graphServiceClient
                                            .Users
                                            .Request()
                                            .Top(10) // pageSize, not overall count !
                                            .Filter("startswith(displayName, '" + val + "')");

                var allUsers = await filterRequest.GetAsync();

                // just need one page to begin to show !
                this.IsLoading = false;

                while (allUsers!= null)
                {
                    // If we launch a new search request, just stop current users requests 
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    foreach (var u in allUsers.CurrentPage)
                    {
                        await DispatcherHelper.ExecuteOnUIThreadAsync(() => this.Users.Add(new UserModel(u)));
                    }

                    // break after 100 users retrieved
                    if (this.Users.Count > 100)
                        break;

                    allUsers = allUsers.NextPageRequest != null ? await allUsers.NextPageRequest.GetAsync() : null;
                    
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



        }

        /// <summary>
        /// Todo : Make a parrallel call with a Task.WhenAll() method
        /// </summary>
        /// <returns></returns>
        private async Task LoadUsersPhotosAsync(CancellationToken cancellationToken)
        {
            if (this.Users.Count <= 0)
                return;

            var po = new ParallelOptions();
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            po.TaskScheduler = uiScheduler;
            po.CancellationToken = cancellationToken;
            po.MaxDegreeOfParallelism = 4;

            Parallel.ForEach(this.Users, po, async (userModel, pls) =>
            {
                var (PhotoBitmap, PhotoUri) = await this.graphServiceClient.GetUserPhoto(userModel.Email);

                // maybe we already click on an item, so we cancel the loop and exit silently
                if (po.CancellationToken.IsCancellationRequested)
                {
                    pls.Stop();
                    return;
                }

                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    userModel.Photo = PhotoBitmap;
                    userModel.PhotoUri = PhotoUri;
                    userModel.IsLoadedPhoto = true;
                });
            });

            await Task.CompletedTask;
        }

        internal async void QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.QueryText))
            {

                try
                {
                    if (this.cancellationTokenSource != null && !this.cancellationTokenSource.IsCancellationRequested)
                        this.cancellationTokenSource.Cancel();

                    // set a new cancellation token source for current search
                    this.cancellationTokenSource = new CancellationTokenSource();

                    this.Users.Clear();
                    await Search(sender.Text.Trim(), this.cancellationTokenSource.Token);
                    
                    await LoadUsersPhotosAsync(this.cancellationTokenSource.Token);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    this.IsLoading = false;
                }
            }
        }
        internal void ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as UserModel;

            if (item == null)
                return;

            if (this.cancellationTokenSource != null)
                this.cancellationTokenSource.Cancel();

            navigationService.NavigateToPage<ProfileDetails>(item);
        }



    }
}
