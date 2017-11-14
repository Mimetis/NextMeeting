using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Services
{
    public class AuthenticationProvider : IAuthenticationProvider2
    {
        private string[] scopes = new string[] {
            "Files.Read.All",
            "People.Read",
            "Mail.Read",
            "User.Read",
            "User.ReadBasic.All",
            "Calendars.Read",
            "Sites.Read.All"
        };

        private PublicClientApplication pca = new PublicClientApplication(
                        "b70aac0e-0084-4145-a852-d8d126ae3e95",
                        "https://login.microsoftonline.com/common");


        public PublicClientApplication PublicClientApplication => pca;

        public AuthenticationProvider()
        {
        }
        public async Task<AuthenticationResult> AuthenticateAsync()
        {

            try
            {
                return await pca.AcquireTokenSilentAsync(scopes, pca.Users.FirstOrDefault());
            }
            catch (MsalException msalException)
            {
                //if (msalException.ErrorCode == "failed_to_acquire_token_silently" || msalException.ErrorCode == "user_null")
                return await pca.AcquireTokenAsync(scopes);
            }
        }
        public async Task<Boolean> TryAuthenticateSilentlyAsync()
        {
            try
            {
                var token = await pca.AcquireTokenSilentAsync(scopes, pca.Users.FirstOrDefault());

                return !string.IsNullOrEmpty(token.AccessToken);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Logout()
        {
            if (PublicClientApplication.Users == null)
                return;

            foreach (var user in PublicClientApplication.Users)
                PublicClientApplication.Remove(user);
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var ar = await AuthenticateAsync();

            if (ar == null)
                throw new Exception("Can't authenticate user");

            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", ar.AccessToken);

        }
    }

}
