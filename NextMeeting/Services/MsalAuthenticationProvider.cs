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
    public class MsalAuthenticationProvider : IAuthenticationProvider
    {
        private readonly PublicClientApplication pca;
        private readonly string[] scopes;

        public MsalAuthenticationProvider(PublicClientApplication pca, string[] scopes)
        {
            this.pca = pca;
            this.scopes = scopes;
        }
        private async Task<AuthenticationResult> AuthenticateAsync()
        {

            try
            {
                return await pca.AcquireTokenSilentAsync(scopes, pca.Users.FirstOrDefault());
            }
            catch (MsalException msalException)
            {

                if (msalException.ErrorCode == "failed_to_acquire_token_silently" || msalException.ErrorCode == "user_null")
                    return await pca.AcquireTokenAsync(scopes);
            }

            return null;

        }
        public async Task<Boolean> TryAuthenticateSilentlyAsync()
        {
            try
            {
                await pca.AcquireTokenSilentAsync(scopes, pca.Users.FirstOrDefault());
                return true;
            }
            catch (Exception exception)
            {
            }
            return false;

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
