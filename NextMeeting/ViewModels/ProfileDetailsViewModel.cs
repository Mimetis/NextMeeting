using Microsoft.Graph;
using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json.Linq;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace NextMeeting.ViewModels
{
    public class ProfileDetailsViewModel : INotifyPropertyChanged, IViewModelNavigable
    {
        private INavigationService navigationService;
        private IUserProvider userProvider;
        private GraphServiceClient graphServiceClient;
        private UserModel userModel;
        private bool isLoadingTeam;
        private bool isLoadingUserItems;
        private bool hasNoUserItems;

        public UserModel User
        {
            get
            {
                return userModel;
            }
            private set
            {
                if (value != userModel)
                {
                    userModel = value;
                    RaisePropertyChanged(nameof(EventModel));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ProfileDetailsViewModel(INavigationService navigationService, IGraphProvider graphProvider, IUserProvider userProvider)
        {
            this.navigationService = navigationService;
            this.userProvider = userProvider;
            this.graphServiceClient = graphProvider.GetAuthenticatedGraphClient();
        }

        public ObservableCollection<UserModel> Team { get; set; } = new ObservableCollection<UserModel>();

        public ObservableCollection<ResourceModel> UserItems { get; set; } = new ObservableCollection<ResourceModel>();


        public bool IsLoadingTeam
        {
            get
            {
                return isLoadingTeam;
            }
            private set
            {
                if (value != isLoadingTeam)
                {
                    isLoadingTeam = value;
                    RaisePropertyChanged(nameof(IsLoadingTeam));
                }
            }
        }
        public bool IsLoadingUserItems
        {
            get
            {
                return isLoadingUserItems;
            }
            private set
            {
                if (value != isLoadingUserItems)
                {
                    isLoadingUserItems = value;
                    RaisePropertyChanged(nameof(IsLoadingUserItems));
                }
            }
        }
        public bool HasNoUserItems
        {
            get
            {
                return hasNoUserItems;
            }
            private set
            {
                if (value != hasNoUserItems)
                {
                    hasNoUserItems = value;
                    RaisePropertyChanged(nameof(HasNoUserItems));
                }
            }
        }


        public async Task Navigated(NavigationEventArgs e, CancellationToken cancellationToken)
        {
            if (e.Parameter == null)
                return;

            this.User = e.Parameter as UserModel;

            await this.LoadTeamAsync();

            await this.LoadTeamPhotosAsync();

            await this.LoadUserItemsAsync();
        }

        public async Task Navigating(NavigatingCancelEventArgs e)
        {
            await Task.CompletedTask;
        }



        private async Task LoadUserItemsAsync()
        {
            this.IsLoadingUserItems = true;

            try
            {
                var lstSharedItems = await this.graphServiceClient.GetInsights(this.User.UserPrincipalName);

                this.HasNoUserItems = lstSharedItems == null || lstSharedItems.Count == 0;

                foreach (var sharedItems in lstSharedItems)
                    this.UserItems.Add(sharedItems);

            }
            catch (Exception ex)
            {
                this.HasNoUserItems = true;
                Debug.Write(ex.Message);

            }

            this.IsLoadingUserItems = false;
        }

        /// <summary>
        /// Todo : Make a parrallel call with a Task.WhenAll() method
        /// </summary>
        /// <returns></returns>
        private async Task LoadTeamPhotosAsync()
        {
            if (this.Team.Count <= 0)
                return;

            var po = new ParallelOptions();
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            po.TaskScheduler = uiScheduler;

            Parallel.ForEach(this.Team, po, async (userModel) =>
            {
                var (PhotoBitmap, PhotoUri) = await this.graphServiceClient.GetUserPhoto(userModel.Email);

                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    userModel.Photo = PhotoBitmap;
                    userModel.PhotoUri = PhotoUri;
                    userModel.IsLoadedPhoto = true;

                });
            });

            await Task.CompletedTask;

            //Task<(BitmapImage PhotoBitmap, Uri PhotoUri)>[] photosTasks = new Task<(BitmapImage, Uri)>[this.Team.Count];

            //for (int i = 0; i < this.Team.Count; i++)
            //{
            //    var userModel = this.Team[i];
            //    var photoTask = this.graphServiceClient.GetUserPhoto(userModel.Email);

            //    photosTasks[i] = photoTask;
            //}

            //await Task.WhenAll(photosTasks);


            //for (int i = 0; i < this.Team.Count; i++)
            //{
            //    var userModel = this.Team[i];
            //    var t = photosTasks[i];

            //    if (!t.IsCompletedSuccessfully)
            //        continue;
            //    var b = t.Result;

            //    userModel.Photo = b.PhotoBitmap;
            //    userModel.PhotoUri = b.PhotoUri;
            //    userModel.IsLoadedPhoto = true;

            //}




        }

        /// <summary>
        /// User item click event
        /// </summary>
        internal async void UserItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as ResourceModel;

            if (e == null)
                return;

            if (!String.IsNullOrEmpty(item.ContainerWebUrl))
                await Windows.System.Launcher.LaunchUriAsync(new Uri(item.ContainerWebUrl));

        }

        internal void ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as UserModel;

            if (item == null)
                return;

            navigationService.NavigateToPage<ProfileDetails>(item);
        }

        public async Task LoadTeamAsync()
        {
            try
            {
                this.IsLoadingTeam = true;
                this.Team.Clear();

                var peopleRequest = this.graphServiceClient.Users[this.User.UserPrincipalName].People.Request();

                // Does not work
                //var team = await peopleRequest.GetAsync();

                // Workaround : Works directly with the HttpRequestMessage, well formatted by graph sdk !
                var message = peopleRequest.GetHttpRequestMessage();
                await this.graphServiceClient.AuthenticationProvider.AuthenticateRequestAsync(message);
                var response = await graphServiceClient.HttpProvider.SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return;

                var jsonString = await response.Content.ReadAsStringAsync();

                var tokens = JObject.Parse(jsonString).SelectTokens("$..value");

                if (tokens == null)
                    return;


                foreach (var jToken in tokens.Children())
                {
                    UserModel userModel = new UserModel();

                    if (jToken["emailAddresses"] != null && jToken["emailAddresses"] is JArray arrayAddress)
                    {
                        var email = arrayAddress[0]["address"];

                        if (email != null)
                            userModel.Email = email.ToString();
                    }
                    userModel.Department = jToken["department"].Value<string>();
                    userModel.DisplayName = jToken["displayName"].Value<string>();
                    userModel.Id = jToken["id"].Value<string>();
                    userModel.JobTitle = jToken["title"].Value<string>();
                    userModel.UserPrincipalName = jToken["userPrincipalName"].Value<string>();

                    this.Team.Add(userModel);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            this.IsLoadingTeam = false;
        }


    }
}
