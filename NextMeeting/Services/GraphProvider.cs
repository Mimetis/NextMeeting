using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Services
{
    public class GraphProvider : IGraphProvider
    {
        private string[] scopes = new string[] {"Files.Read.All", "People.Read",  "Mail.Read", "User.Read", "User.ReadBasic.All", "Calendars.Read", "Sites.Read.All" };

        private PublicClientApplication pca = new PublicClientApplication("b70aac0e-0084-4145-a852-d8d126ae3e95", 
            "https://login.microsoftonline.com/common");

        private GraphServiceClient graphClient;

        public GraphServiceClient GetAuthenticatedGraphClient()
        {
            if (graphClient != null)
                return graphClient;

            graphClient = new GraphServiceClient("https://graph.microsoft.com/beta", new MsalAuthenticationProvider(pca, scopes));
            return graphClient;
        }

        public void SignOut()
        {
            foreach (var user in pca.Users)
                pca.Remove(user);

            this.graphClient = null;
        }

    }
}
