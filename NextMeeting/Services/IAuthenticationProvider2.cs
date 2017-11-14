using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace NextMeeting.Services
{
    public interface IAuthenticationProvider2 : IAuthenticationProvider
    {
        PublicClientApplication PublicClientApplication { get; }
        void Logout();
        Task<bool> TryAuthenticateSilentlyAsync();
        
        Task<AuthenticationResult> AuthenticateAsync();
    }
}