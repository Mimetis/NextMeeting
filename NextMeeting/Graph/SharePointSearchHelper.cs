using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NextMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Graph
{
    public class SharePointSearchHelper
    {
        private const string SearchBase = "search/query";

        private const string SelectPropertiesDocs = "'Author,AuthorOwsUser,ContentClass,ContentTypeId,DefaultEncodingURL,DocId,DocumentPreviewMetadata,Edges,EditorOwsUser,FileExtension,FileType,HitHighlightedProperties,HitHighlightedSummary,LastModifiedTime,ListID,ListItemID,MediaDuration,OriginalPath,Path,PictureThumbnailURL,PrivacyIndicator,Rank,SPWebUrl,SecondaryFileExtension,ServerRedirectedPreviewURL,ServerRedirectedURL,SitePath,SiteTitle,Title,ViewCountLifetime,siteID,uniqueID,webID";
        private const string SelectPropertiesUser = "'UserName,DocId,Department,JobTitle,Path,PictureUrl,PreferredName,WorkEmail,SipAddress'";

        private const string QueryTemplate = "QueryTemplate='((NOT HideFromDelve:True) AND (FileExtension:doc OR FileExtension:one OR FileExtension:docx OR FileExtension:ppt OR FileExtension:pptx OR FileExtension:xls OR FileExtension:xlsx OR FileExtension:pdf OR ContentTypeId:0x010100F3754F12A9B6490D9622A01FE9D8F012* OR contentclass:ExternalLink))";

        private const string QueryTextAll = "*";

        private const string RankinModelId = "0c77ded8-c3ef-466d-929d-905670ea1d72";

        private const string RowLimit = "36";

        private const string StartRow = "0";

        private const string ClientType = "PulseWeb";

        private const string BypassResultTypes = "true";

        private const string EnableQueryRules = "false";

        private const string ProcessBestBets = "false";

        private const string ProcessPersonalFavorites = "false";

        private const string SortList = "LastModifiedTime:descending";

        private const string SourceId = "b09a7990-05ea-4af9-81ef-edfab16c4e31";

        private const string RefinementFilters = "UserName:{0}";

        private const string TrimDuplicates = "false";
        public async static Task<List<SPItemDoc>> SPGetSharedFilesBeetweenUserAndMe(string userId = "ME")
        {
            SearchQuery sp = new SearchQuery();
            sp.request = new Request();
            sp.request.Querytext = "*";
            sp.request.RowLimit = "30";
            sp.request.RowsPerPage = "30";
            sp.request.RankingModelId = "0c77ded8-c3ef-466d-929d-905670ea1d72";
            sp.request.TrimDuplicates = false;
            sp.request.SelectProperties = new RequestArray();
            sp.request.SelectProperties.Results.AddRange(new[] { "Author", "Rank", "AuthorOWSUSER", "ContentClass", "ContentSource", "Created", "CreatedBy", "CreatedById", "CreatedOWSDATE", "DefaultEncodingURL", "DetectedLanguage", "DisplayAuthor", "DocId", "DocumentPreviewMetadata", "Edges", "EditorOWSUSER", "FileType", "Filename", "HostingPartition", "IsContainer", "IsDocument", "IsExternalContent", "LastModifiedTime", "LinkingUrl", "ModifiedBy", "ModifiedById", "ModifiedOWSDATE", "ParentId", "ParentLink", "Path", "PrivacyIndicator", "SiteID", "SitePath", "SiteTitle", "Size", "Title", "UniqueID", "ViewableByAnonymousUsers", "ViewableByExternalUsers", "WebApplicationId", "WebId", "language" });
            sp.request.Properties = new PropertiesArray();
            sp.request.QueryTemplate = "((NOT HideFromDelve:True) AND (FileExtension:doc OR FileExtension:one OR FileExtension:docx OR FileExtension:ppt OR FileExtension:pptx OR FileExtension:xls OR FileExtension:xlsx OR FileExtension:pdf OR ContentTypeId:0x010100F3754F12A9B6490D9622A01FE9D8F012* OR contentclass:ExternalLink))";
            sp.request.SortList = new SortArray();
            sp.request.SortList.Results.Add(new SortItem() { Direction = "1", Property = "LastModifiedTime" });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphQuery",
                Value = new PropertiesItemValue { StrVal = String.Format("AND(ACTOR(ME, OR(action:1001,action:1003)), ACTOR({0}, OR(action:1001,action:1003)))", userId) }
            });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphRankingModel",
                Value = new PropertiesItemValue
                {
                    StrVal = "{\"features\":[{\"function\":\"EdgeWeight\"}]}"
                }
            });

            return await SPSendPostQuery<SPItemDoc>(sp);

        }
        public async static Task<List<SPItemDoc>> SPGetTrendingsAroundByUser(string userId = "ME")
        {
            SearchQuery sp = new SearchQuery();
            sp.request = new Request();
            sp.request.Querytext = "*";
            sp.request.RowLimit = "30";
            sp.request.RowsPerPage = "30";
            sp.request.RankingModelId = "0c77ded8-c3ef-466d-929d-905670ea1d72";
            sp.request.TrimDuplicates = false;
            sp.request.SelectProperties = new RequestArray();
            sp.request.SelectProperties.Results.AddRange(new[] { "Author", "Rank", "AuthorOWSUSER", "ContentClass", "ContentSource", "Created", "CreatedBy", "CreatedById", "CreatedOWSDATE", "DefaultEncodingURL", "DetectedLanguage", "DisplayAuthor", "DocId", "DocumentPreviewMetadata", "Edges", "EditorOWSUSER", "FileType", "Filename", "HostingPartition", "IsContainer", "IsDocument", "IsExternalContent", "LastModifiedTime", "LinkingUrl", "ModifiedBy", "ModifiedById", "ModifiedOWSDATE", "ParentId", "ParentLink", "Path", "PrivacyIndicator", "SiteID", "SitePath", "SiteTitle", "Size", "Title", "UniqueID", "ViewableByAnonymousUsers", "ViewableByExternalUsers", "WebApplicationId", "WebId", "language" });
            sp.request.Properties = new PropertiesArray();
            sp.request.QueryTemplate = "((NOT HideFromDelve:True) AND (FileExtension:doc OR FileExtension:one OR FileExtension:docx OR FileExtension:ppt OR FileExtension:pptx OR FileExtension:xls OR FileExtension:xlsx OR FileExtension:pdf OR ContentTypeId:0x010100F3754F12A9B6490D9622A01FE9D8F012* OR contentclass:ExternalLink))";
            sp.request.SortList = new SortArray();
            sp.request.SortList.Results.Add(new SortItem() { Direction = "1", Property = "LastModifiedTime" });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphQuery",
                Value = new PropertiesItemValue { StrVal = String.Format("ACTOR({0}, action:1020)", userId) }
            });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphRankingModel",
                Value = new PropertiesItemValue
                {
                    StrVal = "{\"features\":[{\"function\":\"EdgeWeight\"}]}"
                }
            });

            return await SPSendPostQuery<SPItemDoc>(sp);

        }
        public async static Task<List<SPItemDoc>> SPGetLastModifiedByOrViewByUser(string userId = "ME")
        {
            SearchQuery sp = new SearchQuery();
            sp.request = new Request();
            sp.request.Querytext = "*";
            sp.request.RowLimit = "30";
            sp.request.RowsPerPage = "30";
            sp.request.RankingModelId = "0c77ded8-c3ef-466d-929d-905670ea1d72";
            sp.request.TrimDuplicates = false;
            sp.request.SelectProperties = new RequestArray();
            sp.request.SelectProperties.Results.AddRange(new[] { "Author", "Rank", "AuthorOWSUSER", "ContentClass", "ContentSource", "Created", "CreatedBy", "CreatedById", "CreatedOWSDATE", "DefaultEncodingURL", "DetectedLanguage", "DisplayAuthor", "DocId", "DocumentPreviewMetadata", "Edges", "EditorOWSUSER", "FileType", "Filename", "HostingPartition", "IsContainer", "IsDocument", "IsExternalContent", "LastModifiedTime", "LinkingUrl", "ModifiedBy", "ModifiedById", "ModifiedOWSDATE", "ParentId", "ParentLink", "Path", "PrivacyIndicator", "SiteID", "SitePath", "SiteTitle", "Size", "Title", "UniqueID", "ViewableByAnonymousUsers", "ViewableByExternalUsers", "WebApplicationId", "WebId", "language" });
            sp.request.Properties = new PropertiesArray();
            sp.request.QueryTemplate = "((NOT HideFromDelve:True) AND (FileExtension:doc OR FileExtension:one OR FileExtension:docx OR FileExtension:ppt OR FileExtension:pptx OR FileExtension:xls OR FileExtension:xlsx OR FileExtension:pdf OR ContentTypeId:0x010100F3754F12A9B6490D9622A01FE9D8F012* OR contentclass:ExternalLink))";
            sp.request.SortList = new SortArray();
            sp.request.SortList.Results.Add(new SortItem() { Direction = "1", Property = "LastModifiedTime" });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphQuery",
                Value = new PropertiesItemValue { StrVal = String.Format("ACTOR({0}, action:1003)", userId) }
            });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphRankingModel",
                Value = new PropertiesItemValue
                {
                    StrVal = "{\"features\":[{\"function\":\"EdgeWeight\"}]}"
                }
            });

            return await SPSendPostQuery<SPItemDoc>(sp);

        }
        public static async Task<List<SPItemUser>> SPGetWorkingWithUsers(string userId = "ME")
        {
            SearchQuery sp = new SearchQuery();
            sp.request = new Request();
            sp.request.Querytext = "*";
            sp.request.RowLimit = "30";
            sp.request.RankingModelId = "0c77ded8-c3ef-466d-929d-905670ea1d72";
            sp.request.TrimDuplicates = false;
            sp.request.SelectProperties = new RequestArray();
            sp.request.SelectProperties.Results.AddRange(new[] { "UserName", "FirstName", "LastName", "DocId", "Department", "JobTitle", "Path", "PictureUrl", "PreferredName", "WorkEmail", "SipAddress" });
            sp.request.SourceId = "b09a7990-05ea-4af9-81ef-edfab16c4e31";
            sp.request.Properties = new PropertiesArray();
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphQuery",
                Value = new PropertiesItemValue { StrVal = String.Format("ACTOR({0},action:1033)", userId) }
            });
            sp.request.Properties.Results.Add(new PropertiesItem
            {
                Name = "GraphRankingModel",
                Value = new PropertiesItemValue
                {
                    StrVal = "{\"features\":[{\"function\":\"EdgeWeight\"}]}"
                }
            });

            return await SPSendPostQuery<SPItemUser>(sp);
        }

        public async static Task<List<SPItemUser>> SPGetUsers(string[] userNames)
        {
            SearchQuery sp = new SearchQuery();
            sp.request = new Request();

            string usersString = String.Empty;
            foreach (var u in userNames)
                usersString += u + " OR ";
            usersString = usersString.Substring(0, usersString.Length - 4);

            sp.request.Querytext = usersString;
            sp.request.RowLimit = "30";
            sp.request.TrimDuplicates = false;
            sp.request.SelectProperties = new RequestArray();
            sp.request.SelectProperties.Results.AddRange(new[] { "UserName", "FirstName", "LastName", "DocId", "Department", "JobTitle", "Path", "PictureUrl", "PreferredName", "WorkEmail", "SipAddress" });
            sp.request.SourceId = "b09a7990-05ea-4af9-81ef-edfab16c4e31";
            sp.request.RefinementFilters = new RequestArray();

            return await SPSendPostQuery<SPItemUser>(sp);
        }

        private async static Task<List<T>> SPSendPostQuery<T>(SearchQuery query)
        {

            var capabilities = await AuthenticationHelper.GetCapabilities();
            var sharepointCapability = capabilities.FirstOrDefault(c => c.Key == "RootSite");
            var requestString = JsonConvert.SerializeObject(query,
                                Formatting.Indented,
                                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


            using (HttpClient client = new HttpClient())
            {
                var token = await AuthenticationHelper.GetTokenHelperAsync(null, sharepointCapability.Value.ServiceResourceId);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                client.DefaultRequestHeaders.Add("X-HTTP-Method", "POST");

                var uri = String.Format("{0}/search/postquery", sharepointCapability.Value.ServiceEndpointUri.AbsoluteUri);
                Uri usersEndpoint = new Uri(uri);

                HttpContent content = new StringContent(requestString);
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");

                using (HttpResponseMessage response = await client.PostAsync(usersEndpoint, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jResult = JObject.Parse(responseContent);

                        var rows = jResult.SelectTokens("$..Rows.results").FirstOrDefault();

                        if (rows == null)
                            return new List<T>();
                        else if (typeof(T) == typeof(SPItemUser))
                            return SPGetUsersFromRows(rows) as List<T>;
                        else if (typeof(T) == typeof(SPItemDoc))
                            return SPGetDocsFromRows(rows) as List<T>;
                    }
                }
            }
            return new List<T>();
        }

        private static List<SPItemUser> SPGetUsersFromRows(IEnumerable<JToken> cellsObject)
        {
            List<SPItemUser> users = new List<SPItemUser>();

            foreach (var cells in cellsObject)
            {
                var item = new SPItemUser();
                users.Add(item);
                var values = cells.SelectTokens("$..Cells.results");

                foreach (var val in values.FirstOrDefault())
                {
                    var searchValue = val.ToObject<SPKeyValue>();
                    switch (searchValue.Key)
                    {
                        case "UserName":
                            item.UserName = searchValue.Value;
                            break;
                        case "FirstName":
                            item.FirstName = searchValue.Value;
                            break;
                        case "LastName":
                            item.LastName = searchValue.Value;
                            break;
                        case "DocId":
                            item.DocId = searchValue.Value;
                            break;
                        case "Department":
                            item.Department = searchValue.Value;
                            break;
                        case "JobTitle":
                            item.JobTitle = searchValue.Value;
                            break;
                        case "Path":
                            item.Path = searchValue.Value;
                            break;
                        case "PictureUrl":
                            item.PictureUrl = searchValue.Value;
                            break;
                        case "PreferredName":
                            item.PreferredName = searchValue.Value;
                            break;
                        case "SipAddress":
                            item.SipAddress = searchValue.Value;
                            break;
                        case "WorkEmail":
                            item.WorkEmail = searchValue.Value;
                            break;
                    }
                }

            }

            return users;
        }

        private static List<SPItemDoc> SPGetDocsFromRows(IEnumerable<JToken> cellsObject)
        {

            List<SPItemDoc> docs = new List<SPItemDoc>();

            foreach (var cells in cellsObject)
            {
                var item = new SPItemDoc();
                docs.Add(item);
                var values = cells.SelectTokens("$..Cells.results");

                foreach (var val in values.FirstOrDefault())
                {
                    var searchValue = val.ToObject<SPKeyValue>();
                    switch (searchValue.Key)
                    {
                        case "Author":
                            item.Author = searchValue.Value;
                            break;
                        case "AuthorOWSUSER":
                            item.AuthorOWSUSER = searchValue.Value;
                            break;
                        case "ContentClass":
                            item.ContentClass = searchValue.Value;
                            break;
                        case "ContentSource":
                            item.ContentSource = searchValue.Value;
                            break;
                        case "Created":
                            DateTime dt = DateTime.Now;
                            if (DateTime.TryParse(searchValue.Value, out dt))
                                item.Created = dt;
                            break;
                        case "CreatedBy":
                            item.CreatedBy = searchValue.Value;
                            break;
                        case "CreatedById":
                            item.CreatedById = searchValue.Value;
                            break;
                        case "CreatedOWSDATE":
                            DateTime dtCreatedOWSDATE = DateTime.Now;
                            if (DateTime.TryParse(searchValue.Value, out dtCreatedOWSDATE))
                                item.CreatedOWSDATE = dtCreatedOWSDATE;
                            break;
                        case "DefaultEncodingURL":
                            item.DefaultEncodingURL = searchValue.Value;
                            break;
                        case "DetectedLanguage":
                            item.DetectedLanguage = searchValue.Value;
                            break;
                        case "DisplayAuthor":
                            item.DisplayAuthor = searchValue.Value;
                            break;
                        case "DocId":
                            item.DocId = searchValue.Value;
                            break;
                        case "EditorOWSUSER":
                            item.EditorOWSUSER = searchValue.Value;
                            break;
                        case "FileType":
                            item.FileType = searchValue.Value;
                            break;
                        case "Filename":
                            item.Filename = searchValue.Value;
                            break;
                        case "HostingPartition":
                            item.HostingPartition = searchValue.Value;
                            break;
                        case "IsContainer":
                            bool tmpIsContainer = true;
                            if (bool.TryParse(searchValue.Value, out tmpIsContainer))
                            item.IsContainer = tmpIsContainer;
                            break;
                        case "IsDocument":
                            bool tmpIsDocument = true;
                            if (bool.TryParse(searchValue.Value, out tmpIsDocument))
                                item.IsDocument = tmpIsDocument;
                            break;
                        case "IsExternalContent":
                            bool tmpIsExternalContent = true;
                            if (bool.TryParse(searchValue.Value, out tmpIsExternalContent))
                                item.IsExternalContent = tmpIsExternalContent;
                            break;
                        case "LastModifiedTime":
                            DateTime dtLastModifiedTime = DateTime.Now;
                            if (DateTime.TryParse(searchValue.Value, out dtLastModifiedTime))
                                item.LastModifiedTime = dtLastModifiedTime;
                            break;
                        case "LinkingUrl":
                            item.LinkingUrl = searchValue.Value;
                            break;
                        case "ModifiedBy":
                            item.ModifiedBy = searchValue.Value;
                            break;
                        case "ModifiedById":
                            item.ModifiedById = searchValue.Value;
                            break;
                        case "ModifiedOWSDATE":
                            DateTime dtModifiedOWSDATE = DateTime.Now;
                            if (DateTime.TryParse(searchValue.Value, out dtModifiedOWSDATE))
                                item.ModifiedOWSDATE = dtModifiedOWSDATE;
                            break;
                        case "ParentId":
                            item.ParentId = searchValue.Value;
                            break;
                        case "ParentLink":
                            item.ParentLink = searchValue.Value;
                            break;
                        case "Path":
                            item.Path = searchValue.Value;
                            break;
                        case "PrivacyIndicator":
                            item.PrivacyIndicator = searchValue.Value;
                            break;
                        case "SiteID":
                            item.SiteID = searchValue.Value;
                            break;
                        case "SitePath":
                            item.SitePath = searchValue.Value;
                            break;
                        case "SiteTitle":
                            item.SiteTitle = searchValue.Value;
                            break;
                        case "Size":
                            item.Size = searchValue.Value;
                            break;
                        case "Title":
                            item.Title = searchValue.Value;
                            break;
                        case "UniqueID":
                            item.UniqueID = searchValue.Value;
                            break;
                        case "ViewableByAnonymousUsers":
                            bool tmpViewableByAnonymousUsers = true;
                            if (bool.TryParse(searchValue.Value, out tmpViewableByAnonymousUsers))
                                item.ViewableByAnonymousUsers = tmpViewableByAnonymousUsers;
                            break;
                        case "ViewableByExternalUsers":
                            bool tmpViewableByExternalUsers = true;
                            if (bool.TryParse(searchValue.Value, out tmpViewableByExternalUsers))
                                item.ViewableByExternalUsers = tmpViewableByExternalUsers;
                            break;
                        case "WebApplicationId":
                            item.WebApplicationId = searchValue.Value;
                            break;
                        case "WebId":
                            item.WebId = searchValue.Value;
                            break;
                        case "Language":
                            item.Language = searchValue.Value;
                            break;

                        case "Rank":
                            item.Rank = searchValue.Value;
                            break;
                        case "DocumentPreviewMetadata":
                            item.DocumentPreviewMetadata = searchValue.Value;
                            break;
                        case "Edges":
                            item.Edges = searchValue.Value;
                            break;
                        case "EditorOwsUser":
                            item.EditorOwsUser = searchValue.Value;
                            break;
                        case "FileExtension":
                            item.FileExtension = searchValue.Value;
                            break;
                    }

                }
            }

            return docs;
        }

    }
}
