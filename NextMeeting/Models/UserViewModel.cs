
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
using Windows.UI.Xaml.Media.Imaging;

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
        private string docId;
        private string email;
        private string workEmail;
        private string name;
        private string userPrincipalName;
        private string department;
        private string jobTitle;
        private string path;
        private ImageSource pictureUrl;
        private static Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private static List<UserViewModel> users = new List<UserViewModel>();
        private bool isLoadedFromGraph = false;
        private bool isLoadedFromSharePoint = false;
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

        public string DocId
        {
            get
            {
                return docId;
            }

            set
            {
                docId = value;
                RaisePropertyChanged(nameof(DocId));
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
                RaisePropertyChanged(nameof(Department));
            }
        }
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }

            set
            {
                jobTitle = value;
                RaisePropertyChanged(nameof(JobTitle));
            }
        }
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
                RaisePropertyChanged(nameof(Path));
            }
        }
        public ImageSource SPPictureUrl
        {
            get
            {
                return pictureUrl;
            }

            set
            {
                pictureUrl = value;
                RaisePropertyChanged(nameof(SPPictureUrl));
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
        public string WorkEmail
        {
            get
            {
                return workEmail;
            }
            set
            {
                this.workEmail = value;

                RaisePropertyChanged(nameof(WorkEmail));
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
                userPrincipalName = value.Trim();
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
        public bool IsLoadedFromSharePoint
        {
            get
            {
                return isLoadedFromSharePoint;
            }
            set
            {
                isLoadedFromSharePoint = value;

                RaisePropertyChanged(nameof(IsLoadedFromSharePoint));
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
            empty.IsLoadedFromSharePoint = true;
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
        private UserViewModel()
        {
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        }

        internal static async Task UpdateUsersFromSharepointAsync(List<string> userMails, CancellationToken token)
        {
            var lstUsers = new List<String>();

            foreach (var email in userMails)
            {
                var userViewModel = FindUser(email);
                if (userViewModel != null && userViewModel.IsLoadedFromSharePoint)
                    continue;

                lstUsers.Add(email);
            }

            var mod = lstUsers.Count % 30;
            var cpt = (lstUsers.Count / 30) + (mod > 0 ? 1 : 0);

            for (int i = 0; i < cpt; i++)
            {
                var index = i * 30;
                int len = 30;

                if (mod > 0 && i == cpt - 1)
                    len = mod;

                var arrayUsers = lstUsers.Skip(index).Take(len).ToArray();
                var spUsers = await SharePointSearchHelper.SPGetUsers(arrayUsers);

                foreach (var u in spUsers)
                {
                    // mb we have a user indexed with a bad address (ie : WorkEmail indexed)
                    if (u.UserName.ToLower() != u.WorkEmail.ToLower())
                    {
                        var userIndexedByWorkEmail = users.FirstOrDefault(us => us.Email == u.WorkEmail);

                        if (userIndexedByWorkEmail != null)
                        {
                            userIndexedByWorkEmail.Email = u.UserName;
                            userIndexedByWorkEmail.WorkEmail = u.WorkEmail;
                            userIndexedByWorkEmail.UserPrincipalName = u.UserName;
                        }
                    }
                    UserViewModel.MergeFromSharepoint(GetUser(u.UserName), u);

                }

            }
        }
        internal static async Task UpdateUsersFromGraphAsync(List<UserViewModel> users, CancellationToken token)
        {
            var usersNotUpdated = new List<UserViewModel>();
            var groups = new List<IReadOnlyQueryableSet<Microsoft.Graph.IUser>>();

            // Check if the user already exists
            foreach (var uvm in users)
            {
                if (!uvm.IsLoadedFromGraph)
                    usersNotUpdated.Add(uvm);
            }

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

            foreach (var usersTask in groups)
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
                    UserViewModel uvm = usersNotUpdated.First(u => u.UserPrincipalName == user.Mail);

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

                }

            };

            // for users not found
            foreach (var uvm in users)
            {
                if (!uvm.IsLoadedFromGraph)
                    uvm.IsLoadedFromGraph = true;
            }
        }

        internal static UserViewModel FindUser(string mail)
        {
            return users.FirstOrDefault(u => u.Email == mail || u.UserPrincipalName == mail || u.WorkEmail == mail);
        }

        internal static UserViewModel GetUser(string userPrincipalName)
        {
            userPrincipalName = userPrincipalName.Trim();
            try
            {
                if (string.IsNullOrEmpty(userPrincipalName))
                    return UserViewModel.Empty;

                UserViewModel user = users.FirstOrDefault(u => u.Email == userPrincipalName || u.UserPrincipalName == userPrincipalName);

                //// try to find by the work email
                //if (user == null)
                //    user = users.FirstOrDefault(u => u.WorkEmail == userPrincipalName && !string.IsNullOrEmpty(u.UserPrincipalName));


                if (user != null)
                    return user;

                user = new UserViewModel()
                {
                    Email = userPrincipalName,
                    UserPrincipalName = userPrincipalName,
                    IsLoadedFromGraph = false,
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
      

        internal static UserViewModel MergeFromSharepoint(UserViewModel userViewModel, SPItemUser u)
        {
            userViewModel.DocId = u.DocId;
            userViewModel.Department = u.Department;
            userViewModel.JobTitle = u.JobTitle;
            userViewModel.Path = u.Path;
            userViewModel.WorkEmail = u.WorkEmail;
            if (!String.IsNullOrEmpty(u.PictureUrl))
                userViewModel.SPPictureUrl = new BitmapImage(new Uri(u.PictureUrl));
            else
                userViewModel.SPPictureUrl = ImageHelper.UnknownPersonImage;

            userViewModel.Name = u.PreferredName;
            userViewModel.FirstName = u.FirstName;

            if (string.IsNullOrEmpty(userViewModel.UserPrincipalName))
                userViewModel.UserPrincipalName = u.UserName.Trim() ;

            userViewModel.IsLoadedFromSharePoint = true;

            return userViewModel;
        }

        public async Task UpdatePhotoAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;


            if (IsLoadedPhoto)
                return;

            if (String.IsNullOrEmpty(this.UserPrincipalName))
                return;

            var graph = AuthenticationHelper.GetGraphService();

            var tuple = await graph.Me.Photo.GetPhoto(this.UserPrincipalName);

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
