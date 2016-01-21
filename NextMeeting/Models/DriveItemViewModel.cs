using Microsoft.Graph;
using NextMeeting.Common;
using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using NextMeeting.Extensions;
using Windows.UI.Xaml.Media;
using System.IO;

namespace NextMeeting.Models
{
    public class DriveItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private string name;
        private DateTime? createdDateTime;
        private DateTime? lastModifiedDateTime;
        private string id;
        private UserViewModel createdByUser;
        private UserViewModel lastModifiedByUser;
        private Brush fileExtensionIconColor;
        private BitmapImage fileExtensionIcon;
        private string friendlyExtensionName;
        private string fileExtension;
        private string friendlyName;
        private RelayCommand openItem;
        private string webUrl;

        public UserViewModel CreatedByUser
        {
            get
            {
                return createdByUser;
            }

            set
            {
                createdByUser = value;
                RaisePropertyChanged(nameof(CreatedByUser));
            }
        }
        public UserViewModel LastModifiedByUser
        {
            get
            {
                return lastModifiedByUser;
            }

            set
            {
                lastModifiedByUser = value;
                RaisePropertyChanged(nameof(LastModifiedByUser));
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
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public DateTime? CreatedDateTime
        {
            get
            {
                return createdDateTime;
            }

            set
            {
                createdDateTime = value;
                RaisePropertyChanged(nameof(CreatedDateTime));
                RaisePropertyChanged(nameof(CreatedDateTimeFriendly));
            }
        }
        public String CreatedDateTimeFriendly
        {
            get
            {
                if (CreatedDateTime.HasValue)
                    return "created " + CreatedDateTime.Value.ToRelativeString();

                return null;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }
        public String LastModifiedDateTimeFriendly
        {
            get
            {
                if (LastModifiedDateTime.HasValue)
                    return "modified " + LastModifiedDateTime.Value.ToRelativeString();

                return null;
            }
        }
        public DateTime? LastModifiedDateTime
        {
            get
            {
                return lastModifiedDateTime;
            }

            set
            {
                lastModifiedDateTime = value;
                RaisePropertyChanged(nameof(LastModifiedDateTime));
                RaisePropertyChanged(nameof(LastModifiedDateTimeFriendly));
            }
        }
        public string FileExtension
        {
            get
            {
                return fileExtension;
            }

            set
            {
                fileExtension = value;
                RaisePropertyChanged("FileExtension");
            }
        }
        public BitmapImage FileExtensionIcon
        {
            get
            {
                return fileExtensionIcon;
            }

            set
            {
                fileExtensionIcon = value;
                RaisePropertyChanged("FileExtensionIcon");
            }
        }
        public Brush FileExtensionIconColor
        {
            get
            {
                return fileExtensionIconColor;
            }

            set
            {
                fileExtensionIconColor = value;
                RaisePropertyChanged(nameof(FileExtensionIconColor));
            }
        }
        public string FriendlyExtensionName
        {
            get
            {
                return friendlyExtensionName;
            }

            set
            {
                friendlyExtensionName = value;
                RaisePropertyChanged(nameof(FriendlyExtensionName));
            }
        }
        public string FriendlyName
        {
            get
            {
                return friendlyName;
            }

            set
            {
                friendlyName = value;
                RaisePropertyChanged("FriendlyName");
            }
        }
        public string WebUrl
        {
            get
            {
                return webUrl;
            }

            set
            {
                webUrl = value;
                RaisePropertyChanged("WebUrl");
            }
        }

        public DriveItemViewModel(IDriveItem item)
        {

            this.Name = item.Name;
            this.Id = item.Id;
            this.CreatedDateTime = item.CreatedDateTime?.DateTime;
            this.LastModifiedDateTime = item.LastModifiedDateTime?.DateTime;
            this.CreatedByUser = item.CreatedBy?.User?.DisplayName != null ? UserViewModel.GetUser(null, null, item.CreatedBy?.User?.DisplayName) : UserViewModel.Empty;
            this.LastModifiedByUser = item.LastModifiedBy?.User?.DisplayName != null ? UserViewModel.GetUser(null, null, item.LastModifiedBy?.User?.DisplayName) : UserViewModel.Empty;
            this.WebUrl = item.WebUrl;

            FileInfo fi = new FileInfo(this.Name);


            this.FileExtension = fi.Extension;
            this.FileExtensionIcon = ImageHelper.GetImageExtensions(fi.Extension);
            this.FileExtensionIconColor = new SolidColorBrush(ImageHelper.GetFileExtensionColor(fi.Extension));

            this.FriendlyName = this.Name.Replace(this.FileExtension, "");

            this.FriendlyExtensionName = ImageHelper.GetDocumentType(fi.Extension);

            if (this.CreatedDateTime.HasValue)
                this.CreatedDateTime = this.CreatedDateTime.Value.ToLocalTime();

            if (this.LastModifiedDateTime.HasValue)
                this.LastModifiedDateTime = this.LastModifiedDateTime.Value.ToLocalTime();

        }

        public RelayCommand OpenItem
        {
            get
            {
                if (openItem == null)
                {
                    openItem = new RelayCommand(async () =>
                    {
                        if (!String.IsNullOrEmpty(this.WebUrl))
                         await Windows.System.Launcher.LaunchUriAsync(new Uri(this.WebUrl));
                    });
                }
                return openItem;
            }
        }
    }
}
