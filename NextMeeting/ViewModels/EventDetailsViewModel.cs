using Microsoft.Graph;
using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json.Linq;
using NextMeeting.Helpers;
using NextMeeting.Models;
using NextMeeting.Navigation;
using NextMeeting.Services;
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

namespace NextMeeting.ViewModels
{
    public class EventDetailsViewModel : INotifyPropertyChanged, IRefresh
    {
        private INavigationService navigationService;
        private IUserProvider userProvider;
        private GraphServiceClient graphServiceClient;
        private EventModel eventModel;
        private bool isLoadingTeam;
        private bool isLoadingUserItems;
        private bool hasNoUserItems;

        public EventModel EventModel
        {
            get
            {
                return eventModel;
            }
            private set
            {
                if (value != eventModel)
                {
                    eventModel = value;
                    RaisePropertyChanged(nameof(EventModel));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public EventDetailsViewModel(INavigationService navigationService, IGraphProvider graphProvider, IUserProvider userProvider)
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

        public async Task RefreshAsync(object parameter)
        {
            if (parameter == null)
                return;

            this.EventModel = parameter as EventModel;

            await this.LoadTeamAsync();

            await this.LoadTeamPhotosAsync();

            await this.LoadUserItemsAsync();
        }


        private async Task LoadUserItemsAsync()
        {
            var organizer = this.EventModel.Organizer;

            this.IsLoadingUserItems = true;

            try
            {
                var lstSharedItems = await this.graphServiceClient.GetInsights(organizer.UserPrincipalName);

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

        public async Task LoadTeamAsync()
        {
            try
            {
                this.IsLoadingTeam = true;
                this.Team.Clear();

                var peopleRequest = this.graphServiceClient.Users[this.EventModel.Organizer.UserPrincipalName].People.Request();

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
