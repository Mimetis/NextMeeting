
using Microsoft.OData.ProxyExtensions;
using NextMeeting.Common;
using NextMeeting.Graph;
using NextMeeting.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NextMeeting.Models
{

    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        private ImageSource photo = ImageHelper.UnknownPersonImage;
        private Uri photoUri = ImageHelper.UnknownPersonImageUri;
        private string id;
        private string email;
        private string name;
        private string userPrincipalName;
        private static Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private static List<UserViewModel> users = new List<UserViewModel>();
        private bool isLoadedFromGraph = false;
        private bool isLoadedPhoto = false;
        private static UserViewModel empty;
        private string firstName;
        private static TaskScheduler uiScheduler;
        private RelayCommand userCommand;

        public ImageSource Photo
        {
            get
            {
                if (!IsLoadedPhoto)
                    this.UpdatePhotoAsync(CancellationToken.None);

                return photo;
            }
            set
            {

                this.photo = value;

                RaisePropertyChanged(nameof(Photo));
            }
        }

        public Uri PhotoUri
        {
            get
            {
                return photoUri;
            }

            set
            {
                photoUri = value;
                RaisePropertyChanged(nameof(PhotoUri));
            }
        }
        public String Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;

                RaisePropertyChanged(nameof(Id));
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;

                RaisePropertyChanged(nameof(FirstName));

            }
        }
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;


                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                this.email = value;

                RaisePropertyChanged(nameof(Email));
            }
        }
        public string UserPrincipalName
        {
            get
            {
                return userPrincipalName;
            }

            set
            {
                userPrincipalName = value;
                RaisePropertyChanged(nameof(UserPrincipalName));
            }
        }
        public static UserViewModel Empty
        {
            get
            {
                return empty;
            }
        }
        public bool IsLoadedFromGraph
        {
            get
            {
                return isLoadedFromGraph;
            }
            set
            {
                isLoadedFromGraph = value;

                RaisePropertyChanged(nameof(IsLoadedFromGraph));
            }

        }
        public bool IsLoadedPhoto
        {
            get
            {
                return isLoadedPhoto;
            }
            private set
            {
                isLoadedPhoto = value;

                RaisePropertyChanged(nameof(IsLoadedPhoto));
            }
        }
        static UserViewModel()
        {
            empty = new UserViewModel();
            empty.IsLoadedFromGraph = true;
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
        private UserViewModel()
        {
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        }
        internal static async Task UpdateUsersAsync(List<UserViewModel> users, CancellationToken token)
        {
            var usersNotUpdated = new List<UserViewModel>();
            var groups = new List<IReadOnlyQueryableSet<Microsoft.Graph.IUser>>();

            // Check if the user already exists
            foreach (var uvm in users)
            {
                if (!uvm.IsLoadedFromGraph)
                    usersNotUpdated.Add(uvm);
            }

            //var number = 3;
            //for (int i = 0; i < usersNotUpdated.Count; i = i + number)
            //{
            //    for (var j = number - 1; j >= 0; j--)
            //    {
            //        if (i + j < usersNotUpdated.Count)
            //        {
            //            List<IReadOnlyQueryableSet<Microsoft.Graph.IUser>> tab = new List<IReadOnlyQueryableSet<Microsoft.Graph.IUser>>() ;
            //            for (var k = 0; k <= j; k++)
            //            {
            //                var email = usersNotUpdated[i + k].Email;
            //                var usersTask = from u in graph.Users
            //                            where u.Mail == email || u.UserPrincipalName == email
            //                            select u;
            //                tab.Add(usersTask);
            //            }
            //            //groups.Add(usersTask);
            //        }
            //    }
            //}

            for (int i = 0; i < usersNotUpdated.Count; i = i + 5)
            {
                IReadOnlyQueryableSet<Microsoft.Graph.IUser> usersTask = null;
                if (i + 4 < usersNotUpdated.Count)
                {
                    var email1 = usersNotUpdated[i].Email;
                    var email2 = usersNotUpdated[i + 1].Email;
                    var email3 = usersNotUpdated[i + 2].Email;
                    var email4 = usersNotUpdated[i + 3].Email;
                    var email5 = usersNotUpdated[i + 4].Email;
                    usersTask = graph.Users.Where(u => u.Mail == email1 || u.UserPrincipalName == email1
                                                    || u.Mail == email2 || u.UserPrincipalName == email2
                                                    || u.Mail == email3 || u.UserPrincipalName == email3
                                                    || u.Mail == email4 || u.UserPrincipalName == email4
                                                    || u.Mail == email5 || u.UserPrincipalName == email5);

                }
                else if (i + 3 < usersNotUpdated.Count)
                {
                    var email1 = usersNotUpdated[i].Email;
                    var email2 = usersNotUpdated[i + 1].Email;
                    var email3 = usersNotUpdated[i + 2].Email;
                    var email4 = usersNotUpdated[i + 3].Email;
                    usersTask = graph.Users.Where(u => u.Mail == email1 || u.UserPrincipalName == email1
                                                    || u.Mail == email2 || u.UserPrincipalName == email2
                                                    || u.Mail == email3 || u.UserPrincipalName == email3
                                                    || u.Mail == email4 || u.UserPrincipalName == email4);

                }
                else if (i + 2 < usersNotUpdated.Count)
                {
                    var email1 = usersNotUpdated[i].Email;
                    var email2 = usersNotUpdated[i + 1].Email;
                    var email3 = usersNotUpdated[i + 2].Email;
                    usersTask = graph.Users.Where(u => u.Mail == email1 || u.UserPrincipalName == email1
                                                    || u.Mail == email2 || u.UserPrincipalName == email2
                                                    || u.Mail == email3 || u.UserPrincipalName == email3);

                }
                else if (i + 1 < usersNotUpdated.Count)
                {
                    var email1 = usersNotUpdated[i].Email;
                    var email2 = usersNotUpdated[i + 1].Email;
                    usersTask = graph.Users.Where(u => u.Mail == email1 || u.UserPrincipalName == email1
                                                    || u.Mail == email2 || u.UserPrincipalName == email2);

                }
                else if (i < usersNotUpdated.Count)
                {
                    var email1 = usersNotUpdated[i].Email;
                    usersTask = graph.Users.Where(u => u.Mail == email1 || u.UserPrincipalName == email1);
                }

                groups.Add(usersTask);

            }
            //var po = new ParallelOptions() { CancellationToken = token, TaskScheduler = uiScheduler };

            foreach( var usersTask in groups)
            {
                if (token.IsCancellationRequested)
                    return;

                var allusers = new List<Microsoft.Graph.IUser>();

                try
                {
                    var usersPaged = await usersTask.ExecuteAsync();

                    allusers.AddRange(usersPaged.CurrentPage.ToList());

                    while (usersPaged.MorePagesAvailable)
                    {
                        usersPaged = await usersPaged.GetNextPageAsync();
                        allusers.AddRange(usersPaged.CurrentPage.ToList());
                    }

                    if (token.IsCancellationRequested)
                        return;

                }
                catch (Exception)
                {
                    return;
                }

                foreach (var user in allusers)
                {
                    UserViewModel uvm = usersNotUpdated.First(u => u.Email == user.Mail);

                    uvm.Name = user.DisplayName;
                    uvm.UserPrincipalName = user.UserPrincipalName;
                    uvm.Email = user.Mail;
                    uvm.Id = user.Id;
                    uvm.FirstName = user.GivenName;

                    if (string.IsNullOrEmpty(uvm.FirstName))
                        uvm.FirstName = uvm.Name.Split(' ').Length > 1 ? uvm.Name.Split(' ')[0] : uvm.Name;

                    uvm.IsLoadedFromGraph = true;

                    if (token.IsCancellationRequested)
                        return;

                    //await uvm.UpdatePhotoAsync(token);


                }

            };

            // for users not found
            foreach (var uvm in users)
            {
                if (!uvm.IsLoadedFromGraph)
                    uvm.IsLoadedFromGraph = true;
            }
        }
        internal static UserViewModel GetUser(string id, string email, string name)
        {
            try
            {
                if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(name))
                    return UserViewModel.Empty;

                UserViewModel user = null;
                if (!string.IsNullOrEmpty(id))
                    user = users.FirstOrDefault(u => u.Id == id);
                else if (!string.IsNullOrEmpty(email))
                    user = users.FirstOrDefault(u => u.Email == email || u.UserPrincipalName == email);
                else if (!string.IsNullOrEmpty(name))
                    user = users.FirstOrDefault(u => u.Name == name);

                if (user != null)
                    return user;

                user = new UserViewModel()
                {
                    Id = id,
                    Email = email,
                    Name = name,
                    IsLoadedFromGraph = false,
                    FirstName = String.IsNullOrEmpty(name) ? null : name.Split(' ').Length > 1 ? name.Split(' ')[0] : name,
                };

                users.Add(user);
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }
        public async Task UpdateUserAsync(CancellationToken token)
        {
            if (IsLoadedFromGraph)
                return;

            if (token.IsCancellationRequested)
                return;

            Microsoft.Graph.IUser iuser = null;

            try
            {
                if (!String.IsNullOrEmpty(this.Id))
                    iuser = await graph.Users.GetUserById(this.Id);
                else
                    iuser = await graph.Users.Where(u => u.Mail == email || u.UserPrincipalName == email).ExecuteSingleAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (iuser != null)
            {
                this.Name = iuser.DisplayName;
                this.UserPrincipalName = iuser.UserPrincipalName;
                this.Email = iuser.Mail;
                this.Id = iuser.Id;
                this.FirstName = iuser.GivenName;
                if (string.IsNullOrEmpty(this.FirstName))
                    FirstName = Name.Split(' ').Length > 1 ? Name.Split(' ')[0] : Name;
            }


            this.IsLoadedFromGraph = true;

        }
        public async Task UpdatePhotoAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

           
            if (IsLoadedPhoto)
                return;

            if (String.IsNullOrEmpty(this.Id))
                return;

            var graph = AuthenticationHelper.GetGraphService();

            var tuple = await graph.Me.Photo.GetPhoto(this.Id);

            if (tuple != null)
            {
                this.Photo = tuple.Item1;
                this.PhotoUri = tuple.Item2;

            }

            IsLoadedPhoto = true;
        }

        public RelayCommand UserCommand
        {
            get
            {
                return userCommand ?? (userCommand = new RelayCommand(() =>
                {
                    HandleContactClicked(this);
                }));
            }
        }

       

        private void HandleContactClicked(UserViewModel uvm)
        {
            AppShell.Current.Navigate(typeof(ProfileDetails), uvm);

        }


    }

}
