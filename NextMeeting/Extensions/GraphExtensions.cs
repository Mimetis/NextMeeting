using Microsoft.Graph;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using System.Diagnostics;
using NextMeeting.Common;
using NextMeeting.Models;

namespace NextMeeting.Graph
{
    /// <summary>
    /// Extensions when Microsoft.Graph wrapper is not enough
    /// </summary>
    public static class GraphExtensions
    {


        //public async static System.Threading.Tasks.Task<BitmapImage> GetThumbnail(
        //  this IDriveFetcher itemFetcher, string driveId, string itemId)
        //{
        //HttpClient client = new HttpClient();
        //var token = await AuthenticationHelper.GetTokenHelperAsync();
        //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //var urlString = String.Format("{0}drives/{1}/items/{2}/thumbnails/"
        //    , AuthenticationHelper.GraphEndpointId, driveId, itemId);


        //Uri usersEndpoint = new Uri(urlString);

        //HttpResponseMessage response = await client.GetAsync(usersEndpoint);

        //if (response.IsSuccessStatusCode)
        //{

        //    string responseContent = await response.Content.ReadAsStringAsync();

        //    var jResult = JObject.Parse(responseContent);

        //    foreach (JObject thumbDetails in jResult["value"])
        //    {
        //        Debug.WriteLine(thumbDetails);

        //        var thumbItem = thumbDetails.ToObject<ThumbnailSet>();

        //        if (thumbItem == null || thumbItem.Small == null)
        //            continue;

        //        var smallUrl = thumbItem.Small.Url;
        //        var capablities = await AuthenticationHelper.GetCapabilities();

        //        var capability = capablities.Where(
        //            c => smallUrl.Contains(c.Value.ServiceResourceId)).FirstOrDefault();

        //        if (capability.Value == null)
        //            continue;

        //        Debug.WriteLine(capability.Value);

        //        string thumbUri = String.Format("{0}/drive/{1}/items/{2}/thumbnails/{3}/{4}/content",
        //            capability.Value.ServiceEndpointUri.AbsoluteUri, driveId, itemId, thumbItem.Id, "small");


        //        HttpClient clientThumb = new HttpClient();
        //        var thumbResourceToken = await AuthenticationHelper.GetAccessTokenForResource(capability.Value.ServiceResourceId);
        //        clientThumb.DefaultRequestHeaders.Add("Authorization", "Bearer " + thumbResourceToken);

        //        HttpResponseMessage responseThumb = await clientThumb.GetAsync(new Uri(thumbUri));

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseContentThumb = await response.Content.ReadAsStringAsync();

        //            Debug.WriteLine(responseContentThumb);
        //        }

        //        //items.Add(item);
        //    }
        //}

        //    return null;
        //}



        public async static Task<Tuple<BitmapImage, Uri>> GetPhoto(
            this IProfilePhotoFetcher photoFetcher, string identifier)
        {

            var fileName = identifier + ".png";

            var tuple = await ImageHelper.GetImageFromCache(fileName);

            if (tuple != null)
                return tuple;

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

                        return new Tuple<BitmapImage, Uri>(bitmapImage, imgUri);
                    }
                }
            }
            return null;
        }

        public async static System.Threading.Tasks.Task<List<IUser>> GetUsersLike(
        this IUserCollection userFetcher, string id)
        {
            List<IUser> items = new List<IUser>();

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the current user's events
                // Uri usersEndpoint = new Uri(AuthenticationHelper.ResourceEndpointId + "users/" + id + "/WorkingWith");
                Uri usersEndpoint = new Uri(AuthenticationHelper.GraphEndpointId
                                    + "users?$select=id,displayName,mail,givenName,userPrincipalName&$filter=startswith(displayName, '" + id + "')");

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        foreach (JObject calendarEvent in jResult["value"])
                        {
                            var item = calendarEvent.ToObject<User>();
                            items.Add(item);
                        }

                    }
                }
            }

            return items;
        }

        public async static System.Threading.Tasks.Task<List<DriveItem>> GetLastDriveItems(
        this IUserFetcher userFetcher, string id)
        {
            List<DriveItem> items = new List<DriveItem>();

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the current user's events
                Uri endpoint = new Uri(AuthenticationHelper.GraphEndpointId + "drives/" + id + "/root/microsoft.graph.search(q='')");

                using (HttpResponseMessage response = await client.GetAsync(endpoint))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        foreach (JObject jobject in jResult["value"])
                        {
                            try
                            {
                                if (jobject["file"] != null)
                                {
                                    var item = jobject.ToObject<DriveItem>();
                                    items.Add(item);
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                                throw;
                            }
                        }

                    }
                }
            }

            return items;
        }

        public async static System.Threading.Tasks.Task<List<TrendingAroundItem>> GetUserTrendingAround(
            this IUserFetcher userFetcher, string id)
        {
            List<TrendingAroundItem> items = new List<TrendingAroundItem>();

            using (HttpClient client = new HttpClient())
            {

                var token = await AuthenticationHelper.GetTokenHelperAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the current user's events
                Uri usersEndpoint = new Uri(AuthenticationHelper.GraphEndpointId + "users/" + id + "/TrendingAround");

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {


                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        foreach (JObject calendarEvent in jResult["value"])
                        {
                            var driveItem = calendarEvent.ToObject<TrendingAroundItem>();

                            // hack to get odata.id
                            var odataId = calendarEvent["@odata.id"];
                            driveItem.Odata_id = odataId.ToString();

                            items.Add(driveItem);
                        }

                    }
                }
            }

            return items;
        }


        public async static System.Threading.Tasks.Task<IUser> GetUserById(
          this IUserCollection collection, string id)
        {
            try
            {
                User item = null;

                using (HttpClient client = new HttpClient())
                {
                    var token = await AuthenticationHelper.GetTokenHelperAsync();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    // Endpoint for the current user's events
                    Uri usersEndpoint = new Uri(AuthenticationHelper.GraphEndpointId + "users/" + id);

                    using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();

                            var jResult = JObject.Parse(responseContent);

                            item = jResult.ToObject<User>();
                        }
                    }
                }

                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        public async static System.Threading.Tasks.Task<IEvent> GetEventById(
                this IEventCollection collection, string id)
        {
            try
            {
                Event item = null;

                using (HttpClient client = new HttpClient())
                {
                    var token = await AuthenticationHelper.GetTokenHelperAsync();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    // Endpoint for the current user's events
                    Uri usersEndpoint = new Uri(AuthenticationHelper.GraphEndpointId + "me/events/" + id);

                    using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();

                            var jResult = JObject.Parse(responseContent);

                            item = jResult.ToObject<Event>();
                        }
                    }
                }

                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }


        /// <summary>
        /// Can't pass query paremeters, so do it with the old fashion way :)
        /// </summary>
        public async static System.Threading.Tasks.Task<List<Event>> GetNextEvents(
            this IEventCollection eventCollection, int top = 10)
        {
            var events = new List<Event>();

            var start = DateTime.UtcNow.ToString("o");
            var end = DateTime.UtcNow.AddMonths(1).ToString("o");

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string query = String.Format("?startDateTime={0}&endDateTime={1}&$top={2}", start, end, top);
                // Endpoint for the current user's events
                Uri usersEndpoint = new Uri(AuthenticationHelper.GraphEndpointId + "me/calendarView" + query);

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        foreach (JObject calendarEvent in jResult["value"])
                        {
                            events.Add(calendarEvent.ToObject<Event>());
                        }

                    }
                }
            }

            return events;
        }
    }
}
