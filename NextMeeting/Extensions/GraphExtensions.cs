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
using System.Net.Http.Headers;

namespace NextMeeting.Graph
{
    /// <summary>
    /// Extensions when Microsoft.Graph wrapper is not enough
    /// </summary>
    public static class GraphExtensions
    {
        private const string SearchBase = "search/query?";

        private const string SelectPropertiesDocs = "SelectProperties='Author,AuthorOwsUser,ContentClass,ContentTypeId,DefaultEncodingURL,DocId,DocumentPreviewMetadata,Edges,EditorOwsUser,FileExtension,FileType,HitHighlightedProperties,HitHighlightedSummary,LastModifiedTime,ListID,ListItemID,MediaDuration,OriginalPath,Path,PictureThumbnailURL,PrivacyIndicator,Rank,SPWebUrl,SecondaryFileExtension,ServerRedirectedPreviewURL,ServerRedirectedURL,SitePath,SiteTitle,Title,ViewCountLifetime,siteID,uniqueID,webID";
        private const string SelectPropertiesUser = "SelectProperties='UserName,DocId'";

        private const string QueryTemplate = "QueryTemplate='((NOT HideFromDelve:True) AND (FileExtension:doc OR FileExtension:docx OR FileExtension:ppt OR FileExtension:pptx OR FileExtension:xls OR FileExtension:xlsx OR FileExtension:pdf OR ContentTypeId:0x010100F3754F12A9B6490D9622A01FE9D8F012* OR contentclass:ExternalLink))";

        private const string QueryText = "Querytext='*'";

        private const string RankinModelId = "RankingModelId='0c77ded8-c3ef-466d-929d-905670ea1d72'";

        private const string RowLimit = "RowLimit=36";

        private const string StartRow = "StartRow=0";

        private const string ClientType = "ClientType='PulseWeb'";

        private const string BypassResultTypes = "BypassResultTypes=true";

        private const string EnableQueryRules = "EnableQueryRules=false";

        private const string ProcessBestBets = "ProcessBestBets=false";

        private const string ProcessPersonalFavorites = "ProcessPersonalFavorites=false";

        private const string SortList = "SortList='LastModifiedTime:descending'";

        private const string SourceId = "SourceId='b09a7990-05ea-4af9-81ef-edfab16c4e31'";

        public static string GetWorkTeamByUserUri(string userId = "ME")
        {
            StringBuilder uriBuilder = new StringBuilder();
            uriBuilder.Append(SearchBase);
            uriBuilder.AppendFormat("?{0}", QueryText);
            uriBuilder.AppendFormat("&{0}", SourceId);
            uriBuilder.AppendFormat("&{0}", SelectPropertiesUser);
            uriBuilder.AppendFormat("&{0}", RowLimit);
            uriBuilder.AppendFormat(@"&Properties='GraphQuery:ACTOR({0}\,action\:1015)'", userId);

            return Uri.EscapeDataString(uriBuilder.ToString());
        }

        public static string GetManagerByUserUri(string userId = "ME")
        {
            StringBuilder uriBuilder = new StringBuilder();
            uriBuilder.Append(SearchBase);
            uriBuilder.AppendFormat("?{0}", QueryText);
            uriBuilder.AppendFormat("&{0}", SourceId);
            uriBuilder.AppendFormat("&{0}", SelectPropertiesUser);
            uriBuilder.AppendFormat(@"&Properties='GraphQuery:ACTOR({0}\,action\:1013)'", userId);

            return Uri.EscapeDataString(uriBuilder.ToString());
        }

        public static string GetLastModifiedByUserUri(string userId = "ME")
        {
            StringBuilder uriBuilder = new StringBuilder();
            uriBuilder.Append(SearchBase);
            uriBuilder.AppendFormat("?{0}", QueryTemplate);
            uriBuilder.AppendFormat("&{0}", SelectPropertiesDocs);
            uriBuilder.AppendFormat("&{0}", RankinModelId);
            uriBuilder.AppendFormat("&{0}", SortList);
            uriBuilder.AppendFormat("&{0}", RowLimit);
            uriBuilder.AppendFormat("&{0}", StartRow);
            uriBuilder.AppendFormat("&{0}", ClientType);
            uriBuilder.AppendFormat("&{0}", BypassResultTypes);
            uriBuilder.AppendFormat("&{0}", EnableQueryRules);
            uriBuilder.AppendFormat("&{0}", ProcessBestBets);
            uriBuilder.AppendFormat("&{0}", ProcessPersonalFavorites);
            uriBuilder.AppendFormat(@"&Properties='GraphQuery:ACTOR({0}\,action\:1003)'", userId);

            return Uri.EscapeDataString(uriBuilder.ToString());

        }

        public static string GetLastViewByUserUri(string userId = "ME")
        {
            StringBuilder uriBuilder = new StringBuilder();
            uriBuilder.Append(SearchBase);
            uriBuilder.AppendFormat("?{0}", QueryTemplate);
            uriBuilder.AppendFormat("&{0}", SelectPropertiesDocs);
            uriBuilder.AppendFormat("&{0}", RankinModelId);
            uriBuilder.AppendFormat("&{0}", SortList);
            uriBuilder.AppendFormat("&{0}", RowLimit);
            uriBuilder.AppendFormat("&{0}", StartRow);
            uriBuilder.AppendFormat("&{0}", ClientType);
            uriBuilder.AppendFormat("&{0}", BypassResultTypes);
            uriBuilder.AppendFormat("&{0}", EnableQueryRules);
            uriBuilder.AppendFormat("&{0}", ProcessBestBets);
            uriBuilder.AppendFormat("&{0}", ProcessPersonalFavorites);
            uriBuilder.AppendFormat(@"&Properties='GraphQuery:ACTOR({0}\,action\:1001)'", userId);

            return Uri.EscapeDataString(uriBuilder.ToString());

        }

       
        public async static Task<List<SearchItemUser>> SearchUsersAsync(string search)
        {

            var lst = new List<SearchItemUser>();
            var capabilities = await AuthenticationHelper.GetCapabilities();

            var sharepointCapability = capabilities.FirstOrDefault(c => c.Key == "RootSite");

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync(null, sharepointCapability.Value.ServiceResourceId);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var uri = String.Format("{0}/{1}", sharepointCapability.Value.ServiceEndpointUri.AbsoluteUri, search);
                Uri usersEndpoint = new Uri(uri);

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        if (jResult["PrimaryQueryResult"] == null || jResult["PrimaryQueryResult"]["RelevantResults"] == null
                            || jResult["PrimaryQueryResult"]["RelevantResults"]["Table"] == null
                            || jResult["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"] == null
                            )
                            return null;

                        var cellsObject = jResult["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"] as JArray;

                        foreach (var cellObject in cellsObject)
                        {
                            var cells = cellObject["Cells"];
                            var searchItem = new SearchItemUser();
                            lst.Add(searchItem);
                            foreach (var val in cells)
                            {
                                var searchValue = val.ToObject<SearchValue>();
                                switch (searchValue.Key)
                                {
                                    case "UserName":
                                        searchItem.UserName = searchValue.Value;
                                        break;
                                    case "DocId":
                                        searchItem.DocId = searchValue.Value;
                                        break;
                                }

                            }
                        }
                    }
                }
            }
            return lst;

        }

        public async static Task<List<SearchItemDocs>> GetSearchDocs(string search)
        {

            var lst = new List<SearchItemDocs>();
            var capabilities = await AuthenticationHelper.GetCapabilities();

            var sharepointCapability = capabilities.FirstOrDefault(c => c.Key == "RootSite");

            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync(null, sharepointCapability.Value.ServiceResourceId);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var uri = String.Format("{0}/{1}", sharepointCapability.Value.ServiceEndpointUri.AbsoluteUri, search);
                Uri usersEndpoint = new Uri(uri);

                using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        if (jResult["PrimaryQueryResult"] == null || jResult["PrimaryQueryResult"]["RelevantResults"] == null
                            || jResult["PrimaryQueryResult"]["RelevantResults"]["Table"] == null
                            || jResult["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"] == null
                            )
                            return null;

                        var cellsObject = jResult["PrimaryQueryResult"]["RelevantResults"]["Table"]["Rows"] as JArray;

                        foreach (var cellObject in cellsObject)
                        {
                            var cells = cellObject["Cells"];
                            var searchItem = new SearchItemDocs();
                            lst.Add(searchItem);
                            foreach (var val in cells)
                            {
                                var searchValue = val.ToObject<SearchValue>();
                                switch (searchValue.Key)
                                {
                                    case "Rank":
                                        searchItem.Rank = searchValue.Value;
                                        break;
                                    case "DocId":
                                        searchItem.DocId = searchValue.Value;
                                        break;
                                    case "Title":
                                        searchItem.Title = searchValue.Value;
                                        break;
                                    case "Author":
                                        searchItem.Author = searchValue.Value;
                                        break;
                                    case "AuthorOwsUser":
                                        searchItem.AuthorOwsUser = searchValue.Value;
                                        break;
                                    case "ContentClass":
                                        searchItem.ContentClass = searchValue.Value;
                                        break;
                                    case "ContentTypeId":
                                        searchItem.ContentTypeId = searchValue.Value;
                                        break;
                                    case "DefaultEncodingURL":
                                        searchItem.DefaultEncodingURL = searchValue.Value;
                                        break;
                                    case "DocumentPreviewMetadata":
                                        searchItem.DocumentPreviewMetadata = searchValue.Value;
                                        break;
                                    case "Edges":
                                        searchItem.Edges = searchValue.Value;
                                        break;
                                    case "EditorOwsUser":
                                        searchItem.EditorOwsUser = searchValue.Value;
                                        break;
                                    case "FileExtension":
                                        searchItem.FileExtension = searchValue.Value;
                                        break;
                                    case "FileType":
                                        searchItem.FileType = searchValue.Value;
                                        break;
                                    case "HitHighlightedProperties":
                                        searchItem.HitHighlightedProperties = searchValue.Value;
                                        break;
                                    case "HitHighlightedSummary":
                                        searchItem.HitHighlightedSummary = searchValue.Value;
                                        break;
                                    case "LastModifiedTime":
                                        searchItem.LastModifiedTime = searchValue.Value;
                                        break;
                                    case "Path":
                                        searchItem.Path = searchValue.Value;
                                        break;
                                    case "SPWebUrl":
                                        searchItem.SPWebUrl = searchValue.Value;
                                        break;
                                    case "ServerRedirectedPreviewURL":
                                        searchItem.ServerRedirectedPreviewURL = searchValue.Value;
                                        break;
                                    case "SitePath":
                                        searchItem.SitePath = searchValue.Value;
                                        break;
                                    case "SiteTitle":
                                        searchItem.SiteTitle = searchValue.Value;
                                        break;
                                }

                            }
                        }
                    }
                }
            }
            return lst;

        }

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
