using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using System.IO;
using Windows.Graphics.Imaging;

namespace NextMeeting.Common
{
    public class ImageHelper
    {

        private static Uri unknownPersonUri = new Uri("ms-appx:///Assets/UnknownPerson.jpg");
        private static BitmapImage unknownPersonBitmapImage = new BitmapImage(unknownPersonUri);
        private static Uri docxUrl = new Uri("ms-appx:///Assets/Icon-docx.png");
        private static BitmapImage docxBitmapImage = new BitmapImage(docxUrl);
        private static Uri xlsxUri = new Uri("ms-appx:///Assets/Icon-xlsx.png");
        private static BitmapImage xlsxBitmapImage = new BitmapImage(xlsxUri);
        private static Uri pptxUri = new Uri("ms-appx:///Assets/Icon-pptx.png");
        private static BitmapImage pptxBitmapImage = new BitmapImage(pptxUri);
        private static Uri oneUri = new Uri("ms-appx:///Assets/Icon-one.png");
        private static BitmapImage oneBitmapImage = new BitmapImage(oneUri);
        private static Uri pdfUri = new Uri("ms-appx:///Assets/Icon-pdf.png");
        private static BitmapImage pdfBitmapImage = new BitmapImage(pdfUri);
        private static Uri zipUri = new Uri("ms-appx:///Assets/Icon-zip.png");
        private static BitmapImage zipBitmapImage = new BitmapImage(zipUri);
        private static Uri xmlUri = new Uri("ms-appx:///Assets/Icon-xml.png");
        private static BitmapImage xmlBitmapImage = new BitmapImage(xmlUri);
        private static Uri txtUri = new Uri("ms-appx:///Assets/Icon-txt.png");
        private static BitmapImage txtBitmapImage = new BitmapImage(txtUri);
        private static Uri fileUri = new Uri("ms-appx:///Assets/Icon-file.png");
        private static BitmapImage fileBitmapImage = new BitmapImage(fileUri);
        private static Uri unknownPersonImageUri = new Uri("ms-appx:///Assets/UnknownPerson.jpg");


        private static ImageHelper current;

        public static ImageHelper Current
        {
            get
            {
                if (current == null)
                    current = new ImageHelper();

                return current;
            }
        }

        public static Uri UnknownPersonImageUri
        {
            get
            {
                return unknownPersonImageUri;
            }
        }
        public static BitmapImage UnknownPersonImage
        {
            get
            {
                return unknownPersonBitmapImage;
            }
        }

        public static string GetDocumentType(string extension)
        {
            var ext = extension.StartsWith(".") ? extension : "." + extension;
            switch (ext.ToLowerInvariant())
            {
                case ".doc":
                case ".docx":
                    return "Word";
                case ".xls":
                case ".xlsx":
                    return "Excel";
                case ".ppt":
                case ".pptx":
                    return "PowerPoint";
                case ".one":
                    return "OneNote";
                case ".pdf":
                    return "Adobe pdf";
                case ".zip":
                    return "Compressed zip";
                case ".xml":
                    return "Text xml";
                case ".txt":
                    return "Text";
                default:
                    return "Unknow file";
            }
        }


        public static Windows.UI.Color GetFileExtensionColor(string extension)
        {
            var ext = extension.StartsWith(".") ? extension : "." + extension;
            switch (ext.ToLowerInvariant())
            {
                case ".doc":
                case ".docx":
                    return Color.FromArgb(255, 42, 86, 153);
                case ".xls":
                case ".xlsx":
                    return Color.FromArgb(255, 32, 114, 69);
                case ".ppt":
                case ".pptx":
                    return Color.FromArgb(255, 210, 70, 37);
                case ".one":
                    return Color.FromArgb(255, 115, 55, 129);
                case ".pdf":
                    return Color.FromArgb(255, 233, 76, 61);
                case ".zip":
                    return Color.FromArgb(255, 249, 233, 141);
                case ".xml":
                    return Color.FromArgb(255, 114, 138, 25);
                case ".txt":
                    return Color.FromArgb(255, 57, 57, 57);
                default:
                    return Color.FromArgb(255, 206, 224, 247);
            }
        }

        public static BitmapImage GetImageExtensions(string extension)
        {
            var ext = extension.StartsWith(".") ? extension : "." + extension;

            switch (ext.ToLowerInvariant())
            {
                case ".doc":
                case ".docx":
                    return docxBitmapImage;
                case ".xls":
                case ".xlsx":
                    return xlsxBitmapImage;
                case ".ppt":
                case ".pptx":
                    return pptxBitmapImage;
                case ".one":
                    return oneBitmapImage;
                case ".pdf":
                    return pdfBitmapImage;
                case ".zip":
                    return zipBitmapImage;
                case ".xml":
                    return xmlBitmapImage;
                case ".txt":
                    return txtBitmapImage;
                default:
                    return fileBitmapImage;

            }

        }
 
        public static async Task<BitmapImage> SaveImageToCacheAndGetImage(Byte[] imageArray, string fileName)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            var bitmapImage = new BitmapImage();
             
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(imageArray))
                {
                    using (var randomAccessStream = memoryStream.AsRandomAccessStream())
                    {
                        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(randomAccessStream);

                        uint width = 80;
                        var height = decoder.OrientedPixelHeight * width / decoder.OrientedPixelWidth;

                        using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(stream, decoder);

                            encoder.BitmapTransform.ScaledHeight = height;
                            encoder.BitmapTransform.ScaledWidth = width;

                            await encoder.FlushAsync();

                            stream.Seek(0);
                            await bitmapImage.SetSourceAsync(stream);
                        }
                    }

                }
                return bitmapImage;

            }
            catch (Exception ex)
            {

            }

            return null;

        }
        public static async Task<BitmapImage> SaveImageToCacheAndGetImage2(Byte[] imageArray, string fileName)
        {
            try
            {
                var folder = ApplicationData.Current.LocalFolder;

                var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                var bitmapImage = new BitmapImage();

                using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await stream.WriteAsync(imageArray.AsBuffer());

                    stream.Seek(0);
                    await bitmapImage.SetSourceAsync(stream);
                    stream.Dispose();
                }


                return bitmapImage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static async Task<Tuple<BitmapImage, Uri>> GetImageFromCache(string fileName)
        {
            try
            {
                var folder = ApplicationData.Current.LocalFolder;

                var file = await folder.TryGetItemAsync(fileName) as StorageFile;

                if (file == null)
                    return null;

                BitmapImage bitmapImage = new BitmapImage();
                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    await bitmapImage.SetSourceAsync(stream);
                }

                var imgUri = new Uri("ms-appdata:///local/" + fileName);

                // bitmapImage.UriSource = new Uri(file.Path);
                return new Tuple<BitmapImage, Uri>(bitmapImage, imgUri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

        }


    }
}
