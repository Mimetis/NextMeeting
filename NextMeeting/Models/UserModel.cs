using Microsoft.Graph;
using NextMeeting.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NextMeeting.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private ImageSource photo;
        private Uri photoUri;
        private string id;
        private string email;
        private string userPrincipalName;
        private string department;
        private string jobTitle;
        private bool isLoadedPhoto = false;
        private string givenName;

        public ImageSource Photo
        {
            get
            {
                //if (!IsLoadedPhoto)
                //    this.UpdatePhotoAsync();

                if (photo == null)
                    return ImageHelper.UnknownPersonImage;

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
                if (photoUri == null)
                    return ImageHelper.UnknownPersonImageUri;

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

        public string DisplayName
        {
            get
            {
                return this.givenName;
            }
            set
            {
                this.givenName = value;

                RaisePropertyChanged(nameof(DisplayName));

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
                this.userPrincipalName = value;

                RaisePropertyChanged(nameof(UserPrincipalName));
            }
        }
        public bool IsLoadedPhoto
        {
            get
            {
                return isLoadedPhoto;
            }
            set
            {
                isLoadedPhoto = value;

                RaisePropertyChanged(nameof(IsLoadedPhoto));
            }
        }
        public UserModel(string email)
        {
            this.Email = email;
            this.UserPrincipalName = email;
            // add Email as Display Name, until the real DisplayName is loaded.
            // This trick enable email as Organizer Name, if we don't find him in the organization.
            this.DisplayName = email;
        }

        public UserModel(User user)
        {
            FillUser(user);
        }

        public UserModel(EmailAddress emailAddress)
        {
            this.DisplayName = emailAddress?.Name;
            this.Email = emailAddress?.Address;
            this.UserPrincipalName = emailAddress?.Address;
        }

        public UserModel(Person person)
        {
            this.FillPerson(person);
        }

        public UserModel()
        {
        }

        internal void FillPerson(Person person)
        {
            this.Department = person.Department;
            this.DisplayName = person.DisplayName;
            this.Id = person.Id;
            this.JobTitle = person.JobTitle;

            if (person.ScoredEmailAddresses != null && person.ScoredEmailAddresses.Count() > 0)
            {
                var emailAddress = person.ScoredEmailAddresses.ToList()[0];
                this.Email = emailAddress?.Address;
            }

            this.UserPrincipalName = person.UserPrincipalName;

            if (!string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.UserPrincipalName))
                return;

            if (string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.UserPrincipalName))
                this.Email = this.UserPrincipalName;

            if (!string.IsNullOrEmpty(this.Email) && string.IsNullOrEmpty(this.UserPrincipalName))
                this.UserPrincipalName = this.Email;


        }


        internal void FillUser(User user)
        {
            this.Department = user.Department;
            this.DisplayName = user.DisplayName;
            this.Id = user.Id;
            this.JobTitle = user.JobTitle;
            this.Email = user.Mail;
            this.UserPrincipalName = user.UserPrincipalName;

            if (!string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.UserPrincipalName))
                return;

            if (string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.UserPrincipalName))
                this.Email = this.UserPrincipalName;

            if (!string.IsNullOrEmpty(this.Email) && string.IsNullOrEmpty(this.UserPrincipalName))
                this.UserPrincipalName = this.Email;


        }

        /// <summary>
        /// Update the User viewmodel photo. First of all, try to get from cache, then make an async Graph call
        /// </summary>
        //public async Task UpdatePhotoAsync()
        //{

        //    if (IsLoadedPhoto)
        //        return;

        //    var userPhoto = await this.graphService.GetUserPhoto(this.email);

        //    //if (userPhoto != null)
        //    {
        //        this.Photo = userPhoto.Item1;
        //        this.PhotoUri = userPhoto.Item2;

        //    }

        //    IsLoadedPhoto = true;
        //}

    }

}
