using Microsoft.Graph;
using Newtonsoft.Json.Linq;
using NextMeeting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace NextMeeting.Helpers
{
    public static class GraphExtensions
    {

        public async static Task<List<ResourceModel>> GetInsightsUsed(this IGraphServiceClient graphService, string identifier)
        {
            string reqString = $"https://graph.microsoft.com/beta/users/{identifier}/insights/used";

            return await GetInsights(graphService, identifier, reqString);
        }

        public async static Task<List<ResourceModel>> GetInsightsTrendingAround(this IGraphServiceClient graphService, string identifier)
        {
            string reqString = $"https://graph.microsoft.com/beta/users/{identifier}/insights/trending";

            return await GetInsights(graphService, identifier, reqString);
        }

        public async static Task<List<ResourceModel>> GetInsightsShared(this IGraphServiceClient graphService, string identifier)
        {
            string reqString = $"https://graph.microsoft.com/beta/users/{identifier}/insights/shared";

            return await GetInsights(graphService, identifier, reqString);
        }


        /// <summary>
        /// Get all insights from a user (trending, shared, used)
        /// </summary>
        public async static Task<List<ResourceModel>> GetInsights(this IGraphServiceClient graphService, string identifier)
        {
            try
            {

                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post,
                    "https://graph.microsoft.com/beta/$batch");
                JArray requests = new JArray();

                var jo = new JObject(
                    new JProperty("url", $"/users/{identifier}/insights/shared"),
                    new JProperty("method", "GET"),
                    new JProperty("id", "0"));

                requests.Add(jo);

                jo = new JObject(
                    new JProperty("url", $"/users/{identifier}/insights/used"),
                    new JProperty("method", "GET"),
                    new JProperty("id", "1"));

                requests.Add(jo);

                jo = new JObject(
                    new JProperty("url", $"/users/{identifier}/insights/trending"),
                    new JProperty("method", "GET"),
                    new JProperty("id", "2"));

                requests.Add(jo);

                JObject batchObject = new JObject(new JProperty("requests", requests));

                var batchString = batchObject.ToString();

                message.Content = new StringContent(batchString);
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await graphService.AuthenticationProvider.AuthenticateRequestAsync(message);
                var response = await graphService.HttpProvider.SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;

                var jsonString = await response.Content.ReadAsStringAsync();

                var tokens = JObject.Parse(jsonString).SelectTokens("$...body...value..resourceVisualization");

                List<ResourceModel> items = new List<ResourceModel>();

                foreach (var jtoken in tokens)
                {
                    ResourceModel item = jtoken.ToObject<ResourceModel>();
                    item.SetFileExtensions();
                    items.Add(item);
                }

                return items.Distinct(new ResourceModelComparer()).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        private async static Task<List<ResourceModel>> GetInsights(IGraphServiceClient graphService, string identifier, string reqString)
        {
            try
            {

                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, reqString);

                await graphService.AuthenticationProvider.AuthenticateRequestAsync(message);
                var response = await graphService.HttpProvider.SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;

                var jsonString = await response.Content.ReadAsStringAsync();

                List<ResourceModel> resources = new List<ResourceModel>();

                var tokens = JObject.Parse(jsonString).SelectTokens("$..value..resourceVisualization");

                if (tokens == null)
                    return null;

                List<ResourceModel> lstResources = new List<ResourceModel>();

                foreach (var jtoken in tokens)
                {
                    var resourceModel = jtoken.ToObject<ResourceModel>();
                    resourceModel.SetFileExtensions();
                    lstResources.Add(resourceModel);
                }

                return lstResources;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return null;
        }
        /// <summary>
        /// Get user photo : BitmapImage and Uri.
        /// </summary>
        public async static Task<(BitmapImage PhotoBitmap, Uri PhotoUri)> GetUserPhoto(
                this IGraphServiceClient graphService, string identifier)
        {

            var fileName = identifier + ".png";

            var img = await ImageHelper.GetImageFromCache(fileName);

            if (img.Image != null && img.uri != null)
                return img;
            try
            {

                using (Stream photo = await graphService.Users[identifier].Photo.Content.Request().GetAsync())
                {

                    if (photo != null)
                    {
                        // Get byte[] for display.
                        using (BinaryReader reader = new BinaryReader(photo))
                        {
                            byte[] photoByte = reader.ReadBytes((int)photo.Length);
                            var bitmapImage = await ImageHelper.SaveImageToCacheAndGetImage(photoByte, fileName);
                            var imgUri = new Uri("ms-appdata:///local/" + fileName);

                            return (bitmapImage, imgUri);
                        }
                    }
                }
            }
            catch (ServiceException ex)
            {
                if (ex.Error.Code == "itemNotFound" || ex.Error.Code == "ErrorItemNotFound" || ex.Error.Code == "ResourceNotFound")
                    return (null, null);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return (null, null);
        }



    }
}
