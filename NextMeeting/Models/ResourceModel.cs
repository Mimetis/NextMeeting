using NextMeeting.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NextMeeting.Models
{
    public class ResourceModel : INotifyPropertyChanged
    {
        private BitmapImage fileExtensionIcon;
        private Brush fileExtensionIconColor;
        private BitmapImage previewImage;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public String Title { get; set; }
        public String Type { get; set; }
        public String MediaType { get; set; }
        public String PreviewImageUrl { get; set; }
        public String PreviewText { get; set; }
        public String ContainerWebUrl { get; set; }
        public String ContainerDisplayName { get; set; }
        public String ContainerType { get; set; }

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

        public BitmapImage PreviewImage
        {
            get
            {
                return previewImage;
            }

            set
            {
                previewImage = value;
                RaisePropertyChanged("PreviewImage");
            }
        }

        public ResourceModel()
        {

        }

        public void SetFileExtensions()
        {
            var extension = ImageHelper.GetFileExtensionFromDocumentType(Type);
            this.FileExtensionIcon = ImageHelper.GetImageExtensions(extension);
            this.FileExtensionIconColor = new SolidColorBrush(ImageHelper.GetFileExtensionColor(extension));

        }

        
       
    }

    public class ResourceModelComparer : IEqualityComparer<ResourceModel>
    {
        public bool Equals(ResourceModel x, ResourceModel y)
        {
            return x.Title.ToLowerInvariant().Equals(y.Title.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(ResourceModel obj)
        {
            return base.GetHashCode();
        }
    }
}
