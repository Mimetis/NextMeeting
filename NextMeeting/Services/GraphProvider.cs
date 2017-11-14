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
        private IAuthenticationProvider2 authenticationProvider;
        private GraphServiceClient graphClient;

        public GraphProvider(IAuthenticationProvider2 authenticationProvider)
        {
            this.authenticationProvider = authenticationProvider;
        }

        public GraphServiceClient GetAuthenticatedGraphClient()
        {
            if (graphClient != null)
                return graphClient;

            graphClient = new GraphServiceClient("https://graph.microsoft.com/beta", authenticationProvider);
            return graphClient;
        }

        public void SignOut()
        {
            authenticationProvider.Logout();
            this.graphClient = null;
        }

    }
}
