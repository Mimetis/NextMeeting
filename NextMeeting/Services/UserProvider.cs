using Microsoft.Graph;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Services
{
    public class UserProvider : IUserProvider
    {
        private IGraphServiceClient graphServiceClient;

        public UserProvider(IGraphProvider graphProvider)
        {
            this.graphServiceClient = graphProvider.GetAuthenticatedGraphClient();
        }

        public async Task<List<User>> GetUsers(List<String> emails)
        {

            if (emails == null || emails.Count == 0)
                return null;

            var users = new List<User>();

            // Par requête, 5 batchs max
            // Dans chaque batch 5 duo de mails (donc 10 mails) pour avoir juste 10 'OR'

            // Calculare batchs numbers. Each batch will contains 25 mails on max
            var requestNumbers = (emails.Count / 25) + 1;

            // filter to apply
            var filterClause = "mail eq '{0}' or userPrincipalName eq '{0}'";
            try
            {
                // loop for each batch
                for (int requestIndex = 0; requestIndex < requestNumbers; requestIndex++)
                {
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, 
                        "https://graph.microsoft.com/beta/$batch");
                    JArray requests = new JArray();
                    JObject batchObject = new JObject(new JProperty("requests", requests));

                    // For this request, generate the 1 to 5 batchs

                    // check steps
                    var stepMin = Math.Min(requestIndex * 25, emails.Count);
                    var stepMax = Math.Min((requestIndex * 25) + 25, emails.Count);
                    var batchIndex = 0;
                    for (int i = stepMin; i < stepMax; i += 5)
                    {
                        // check min index
                        var batchIndexMin = i;

                        // take maximum 5 mails
                        var batchIndexMax = Math.Min((batchIndexMin + 5), emails.Count);

                        string filter = "";
                        string or = " OR ";
                        for (int j = batchIndexMin; j < batchIndexMax; j++)
                        {
                            filter += string.Format(filterClause, emails[j]);

                            if (j == batchIndexMax - 1)
                                or = "";

                            filter += or;
                        }

                        var select = "$select=mail,userPrincipalName,jobTitle,department,id,displayName";
                        filter = $"$filter={filter}";

                        var jo = new JObject(
                            new JProperty("url", $"/users?{select}&{filter}"),
                            new JProperty("method", "GET"),
                            new JProperty("id", batchIndex));

                        requests.Add(jo);
                        batchIndex++;
                    }

                    var batchString = batchObject.ToString();

                    message.Content = new StringContent(batchString);
                    message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    await this.graphServiceClient.AuthenticationProvider.AuthenticateRequestAsync(message);
                    var response = await this.graphServiceClient.HttpProvider.SendAsync(message);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        return null;

                    var jsonString = await response.Content.ReadAsStringAsync();

                    var tokens = JObject.Parse(jsonString).SelectTokens("$...body.value");


                    foreach (var jtoken in tokens)
                    {
                        foreach (var userToken in jtoken.Children())
                        {
                            User user = userToken.ToObject<User>();
                            users.Add(user);
                        }
                    }


                }


            }
            catch (Exception ex)
            {
                throw;
            }
            //JObject batchObject = new JObject(
            //    new JProperty("requests",
            //        new JArray(
            //            from p in emails
            //            select new JObject(
            //                new JProperty("url", $"/users?$filter=mail eq '{p}' or userPrincipalName eq '{p}'"),
            //                new JProperty("method", "GET"),
            //                new JProperty("id", emails.IndexOf(p))))));




            return users;
        }
    }
}
