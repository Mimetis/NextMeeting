using Microsoft.Graph;
using NextMeeting.Common;
using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using NextMeeting.Extensions;

namespace NextMeeting.Models
{
    public class TrendingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string id;
        private DateTime? createdDateTime;
        private DateTime? lastModifiedDateTime;
        private string name;
        private string friendlyName;
        private string friendlyExtensionName;
        private Brush fileExtensionIconColor;
        private BitmapImage fileExtensionIcon;
        private string fileExtension;
        private string webUrl;
        private string cTag;
        private UserViewModel createdByUser;
        private UserViewModel lastModifiedByUser;
        private RelayCommand openItem;
        private string odata_id;
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
        public String CreatedDateTimeFriendly
        {
            get
            {
                if (CreatedDateTime.HasValue)
                    return "created " + CreatedDateTime.Value.ToRelativeString();

                return null;
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
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                RaisePropertyChanged("Name");
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
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                RaisePropertyChanged("Id");
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
        public string CTag
        {
            get
            {
                return cTag;
            }

            set
            {
                cTag = value;
                RaisePropertyChanged("CTag");
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
        public string Odata_id
        {
            get
            {
                return odata_id;
            }

            set
            {
                odata_id = value;
                RaisePropertyChanged(nameof(Odata_id));
            }
        }

        public TrendingViewModel(TrendingAroundItem item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.CreatedDateTime = item.DateTimeCreated;
            this.LastModifiedDateTime = item.DateTimeLastModified;
            this.Odata_id = item.Odata_id;
            this.webUrl = item.WebUrl;
            this.CreatedByUser = UserViewModel.Empty;
            this.LastModifiedByUser = UserViewModel.Empty;

        }
        public void Update(IDriveItem item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.CreatedDateTime = item.CreatedDateTime.HasValue ? item.CreatedDateTime.Value.DateTime : (DateTime?)null;
            this.LastModifiedDateTime = item.LastModifiedDateTime.HasValue ? item.LastModifiedDateTime.Value.DateTime : (DateTime?)null;
            this.WebUrl = item.WebUrl;
            
            //var createdByid = item.CreatedBy?.User?.Id;
            //this.CreatedByUser = createdByid != null ? UserViewModel.GetUser(createdByid, null) : UserViewModel.Empty;

            //var lastModifiedById = item.LastModifiedBy?.User?.Id;
            //this.LastModifiedByUser = lastModifiedById != null ? UserViewModel.GetUser(lastModifiedById, null) : UserViewModel.Empty;

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
