using NextMeeting.Common;
using NextMeeting.Graph;
using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Media.Imaging;

namespace NextMeeting.Tasks
{


    public sealed class EventTileModel
    {
        public string OrganizerName { get; set; }
        public string OrganizerMail { get; set; }
        public string OrganizerImageAbsoluteUri { get; set; }
        public string TimeDelta { get; set; }
        public string Subject { get; set; }
        public IList<DriveItemTileModel> Items { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public string BodyPreview { get; set; }
        public bool IsAllDay { get; set; }

        public EventTileModel()
        {
            Items = new List<DriveItemTileModel>();
        }

    }

    public sealed class DriveItemTileModel
    {
        public string Title { get; set; }
        public string IconAbsoluteUri { get; set; }

    }
    public sealed class TileHelper
    {

        private static Uri unknownPersonUri = new Uri("ms-appx:///Assets/UnknownPerson.jpg");
        private static Uri docxUrl = new Uri("ms-appx:///Assets/Icon-docx.png");
        private static Uri xlsxUri = new Uri("ms-appx:///Assets/Icon-xlsx.png");
        private static Uri pptxUri = new Uri("ms-appx:///Assets/Icon-pptx.png");
        private static Uri oneUri = new Uri("ms-appx:///Assets/Icon-one.png");
        private static Uri pdfUri = new Uri("ms-appx:///Assets/Icon-pdf.png");
        private static Uri zipUri = new Uri("ms-appx:///Assets/Icon-zip.png");
        private static Uri xmlUri = new Uri("ms-appx:///Assets/Icon-xml.png");
        private static Uri txtUri = new Uri("ms-appx:///Assets/Icon-txt.png");
        private static Uri fileUri = new Uri("ms-appx:///Assets/Icon-file.png");
        private static Uri unknownPersonImageUri = new Uri("ms-appx:///Assets/UnknownPerson.jpg");

        private static TileHelper current;

        public static TileHelper Current
        {
            get
            {
                if (current == null)
                    current = new TileHelper();

                return current;
            }
        }

        internal async Task<Uri> GetPhotoUri(string identifier)
        {

            var fileName = identifier + ".png";

            var folder = ApplicationData.Current.LocalFolder;

            var file = await folder.TryGetItemAsync(fileName) as StorageFile;

            if (file != null)
                return new Uri("ms-appdata:///local/" + fileName);

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var urlString = String.Format("{0}users/{1}/photo/$value", AuthenticationHelper.GraphEndpointId, identifier);
                Uri usersEndpoint = new Uri(urlString);

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var photoByte = await response.Content.ReadAsByteArrayAsync();

                        var bitmapImage = await ImageHelper.SaveImageToCacheAndGetImage(photoByte, fileName);
                        var imgUri = new Uri("ms-appdata:///local/" + fileName);

                        return imgUri;
                    }
                }
            }
            return null;
        }
        public Uri GetImageExtensionsUri(string extension)
        {
            var ext = extension.StartsWith(".") ? extension : "." + extension;

            switch (ext.ToLowerInvariant())
            {
                case ".doc":
                case ".docx":
                    return docxUrl;
                case ".xls":
                case ".xlsx":
                    return xlsxUri;
                case ".ppt":
                case ".pptx":
                    return pptxUri;
                case ".one":
                    return oneUri;
                case ".pdf":
                    return pdfUri;
                case ".zip":
                    return zipUri;
                case ".xml":
                    return xmlUri;
                case ".txt":
                    return txtUri;
                default:
                    return fileUri;

            }

        }


        public void SendEventTileNotification(EventTileModel etm)
        {
            var content = new TileBindingContentAdaptive();
            TileGroup firstGroup = new TileGroup();

            TileSubgroup sgroup = new TileSubgroup();
            sgroup.Weight = 22;
            TileImage imgOrganizer = new TileImage();
            var uriImageOrganizer = etm.OrganizerImageAbsoluteUri;

            if (string.IsNullOrEmpty(uriImageOrganizer))
                uriImageOrganizer = unknownPersonImageUri.AbsoluteUri;

            imgOrganizer.Source = new TileImageSource(uriImageOrganizer);
            sgroup.Children.Add(imgOrganizer);
            firstGroup.Children.Add(sgroup);

            sgroup = new TileSubgroup();
            TileText organizerName = new TileText();
            organizerName.Text = etm.OrganizerName;
            sgroup.Children.Add(organizerName);
            TileText timeEvent = new TileText();
            timeEvent.Text = etm.TimeDelta;
            timeEvent.Style = TileTextStyle.CaptionSubtle;
            sgroup.Children.Add(timeEvent);
            TileText eventBdy = new TileText();
            eventBdy.Text = etm.Subject;
            sgroup.Children.Add(eventBdy);
            firstGroup.Children.Add(sgroup);

            content.Children.Add(firstGroup);

            foreach (var driveItem in etm.Items.Take(2))
            {

                TileGroup secondGroup = new TileGroup();
                sgroup = new TileSubgroup();
                TileImage imgExt = new TileImage();
                imgExt.Source = new TileImageSource(driveItem.IconAbsoluteUri);
                sgroup.Children.Add(imgExt);
                sgroup.Weight = 5;
                secondGroup.Children.Add(sgroup);
                sgroup = new TileSubgroup();
                TileText tt = new TileText();
                tt.Text = driveItem.Title;
                sgroup.Children.Add(tt);
                secondGroup.Children.Add(sgroup);
                content.Children.Add(secondGroup);

            }
            TileContent tileContent = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileWide = new TileBinding()
                    {
                        Content = content
                    },
                    TileMedium = new TileBinding()
                    {
                        Content = content
                    },
                }
            };
            try
            {
                var tileContentxml = tileContent.ToString();
                TileNotification notification = new TileNotification(tileContent.GetXml());
                TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
