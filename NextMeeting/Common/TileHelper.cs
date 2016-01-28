using NextMeeting.Models;
using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Media.Imaging;

namespace NextMeeting.Common
{
    public class TileHelper
    {
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


        public void SendEventTileNotification(EventViewModel evm)
        {
            var content = new TileBindingContentAdaptive();
            TileGroup firstGroup = new TileGroup();
            
            TileSubgroup sgroup = new TileSubgroup();
            sgroup.Weight = 22;
            TileImage imgOrganizer = new TileImage();
            var uriImageOrganizer = evm.Organizer.PhotoUri.AbsoluteUri;
            //uriImageOrganizer = ImageHelper.UnknownPersonImageUri.AbsoluteUri ;
            imgOrganizer.Source = new TileImageSource(uriImageOrganizer);
            sgroup.Children.Add(imgOrganizer);
            firstGroup.Children.Add(sgroup);

            sgroup = new TileSubgroup();
            TileText organizerName = new TileText();
            organizerName.Text = evm.Organizer.Name;
            sgroup.Children.Add(organizerName);
            TileText timeEvent = new TileText();
            timeEvent.Text = evm.TimeDelta;
            timeEvent.Style = TileTextStyle.CaptionSubtle;
            sgroup.Children.Add(timeEvent);
            TileText eventBdy = new TileText();
            eventBdy.Text = evm.Subject;
            sgroup.Children.Add(eventBdy);
            firstGroup.Children.Add(sgroup);

            content.Children.Add(firstGroup);

            //if (evm.TopDriveItems.Count > 0)
            //{
            //    var driveItem = evm.TopDriveItems[0];

            //    TileGroup secondGroup = new TileGroup();
            //    sgroup = new TileSubgroup();
            //    TileImage imgExt = new TileImage();
            //    imgExt.Source = new TileImageSource(driveItem.FileExtensionIcon.UriSource.AbsoluteUri);
            //    sgroup.Children.Add(imgExt);
            //    sgroup.Weight = 5;
            //    secondGroup.Children.Add(sgroup);
            //    sgroup = new TileSubgroup();
            //    TileText tt = new TileText();
            //    tt.Text = driveItem.Name;
            //    sgroup.Children.Add(tt);
            //    secondGroup.Children.Add(sgroup);
            //    content.Children.Add(secondGroup);

            //}

            //if (evm.TopTrendings.Count > 0)
            //{
            //    var trend = evm.TopTrendings[0];

            //    TileGroup thirdGroup = new TileGroup();
            //    sgroup = new TileSubgroup();
            //    TileImage imgExt = new TileImage();
            //    imgExt.Source = new TileImageSource(trend.FileExtensionIcon.UriSource.AbsoluteUri);
            //    sgroup.Children.Add(imgExt);
            //    sgroup.Weight = 5;
            //    thirdGroup.Children.Add(sgroup);
            //    sgroup = new TileSubgroup();
            //    TileText tt = new TileText();
            //    tt.Text = trend.Name;
            //    sgroup.Children.Add(tt);
            //    thirdGroup.Children.Add(sgroup);
            //    content.Children.Add(thirdGroup);

            //}


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
        public string GenerateOneTile()
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                                {
                                    new TileText()
                                    {
                                        Text = "Jennifer Parker",
                                        Style = TileTextStyle.Subtitle
                                    },

                                    new TileText()
                                    {
                                        Text = "Photos from our trip",
                                        Style = TileTextStyle.CaptionSubtle
                                    },

                                    new TileText()
                                    {
                                        Text = "Check out these awesome photos I took while in New Zealand!",
                                        Style = TileTextStyle.CaptionSubtle
                                    }
                                }
                        }
                    },


                }
            };

            return content.ToString();
        }
    }
}
