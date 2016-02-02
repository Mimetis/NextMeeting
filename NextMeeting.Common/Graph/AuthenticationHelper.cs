using Microsoft.Graph;
using Microsoft.Office365.Discovery;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;
using Windows.UI.ApplicationSettings;

namespace NextMeeting.Graph
{
    public static class AuthenticationHelper
    {

        // The Client ID is used by the application to uniquely identify itself to Microsoft Azure Active Directory (AD).
        static string clientId = "9da67e3f-3cf9-4793-b924-bbecf9accccf";

        private const string AccountProviderId = "https://login.microsoft.com";
        private const string Authority = "organizations";

        // To authenticate to Microsoft Graph, the client needs to know its App ID URI.
        public const string GraphResourceId = "https://graph.microsoft.com/";
        public const string GraphEndpointId = "https://graph.microsoft.com/beta/";

        public const string DiscoveryResourceId = "https://api.office.com/discovery/";
        public const string DiscoveryEndpointId = "https://api.office.com/discovery/v2.0/me/";

        // private static WebAccountProvider aadAccountProvider = null;
        private static WebAccount userAccount = null;

        // Store account-specific settings so that the app can remember that a user has already signed in.
        public static ApplicationDataContainer settings = ApplicationData.Current.RoamingSettings;

        private static GraphService graphService;

        private static string currentToken;
        private static TaskCompletionSource<Boolean> tcs;
        private static Dictionary<string, CapabilityDiscoveryResult> capabilities;



        public static async Task<string> TryAuthenticateSilentlyAsync()
        {
            try
            {
                var redir = GetAppRedirectURI();

                var aadAccountProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
                     AccountProviderId, Authority);

                // Check if there's a record of the last account used with the app.
                var userID = settings.Values["userID"];

                WebTokenRequest webTokenRequest = new WebTokenRequest(aadAccountProvider, string.Empty, clientId);
                webTokenRequest.Properties.Add("resource", GraphResourceId);

                WebTokenRequestResult webTokenRequestResult;
                if (userID != null)
                {
                    // Get an account object for the user.
                    userAccount = await WebAuthenticationCoreManager.FindAccountAsync(
                        aadAccountProvider, (string)userID);

                    // Ensure that the saved account works for getting the token we need.
                    webTokenRequestResult =
                            await WebAuthenticationCoreManager.GetTokenSilentlyAsync(webTokenRequest, userAccount);
                }
                else
                {
                    webTokenRequestResult =
                            await WebAuthenticationCoreManager.GetTokenSilentlyAsync(webTokenRequest);
                }


                if (webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.Success
                    || webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.AccountSwitch)
                {
                    WebTokenResponse webTokenResponse = webTokenRequestResult.ResponseData[0];
                    userAccount = webTokenResponse.WebAccount;
                    currentToken = webTokenResponse.Token;

                    if (userAccount != null)
                    {
                        // Save user ID in local storage.
                        settings.Values["userID"] = userAccount.Id;
                        settings.Values["userEmail"] = userAccount.UserName;
                        settings.Values["userName"] = userAccount.Properties["DisplayName"];
                    }
                    return currentToken;

                }
                else 

                // Dont want to log during launch !!
                //if (webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.UserInteractionRequired)
                //{
                //    webTokenRequest = new WebTokenRequest(aadAccountProvider, string.Empty, clientId, WebTokenRequestPromptType.ForceAuthentication);
                //    webTokenRequest.Properties.Add("resource", GraphResourceId);

                //    //get token through prompt
                //    if (userID != null)
                //    {
                //        // Ensure that the saved account works for getting the token we need.
                //        webTokenRequestResult = await WebAuthenticationCoreManager.RequestTokenAsync(webTokenRequest, userAccount);
                //    }
                //    else
                //    {
                //        webTokenRequestResult = await WebAuthenticationCoreManager.RequestTokenAsync(webTokenRequest);
                //    }

                //    if (webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.Success)
                //    {
                //        WebTokenResponse webTokenResponse = webTokenRequestResult.ResponseData[0];
                //        userAccount = webTokenResponse.WebAccount;
                //        currentToken = webTokenResponse.Token;

                //        if (userAccount != null)
                //        {
                //            // Save user ID in local storage.
                //            settings.Values["userID"] = userAccount.Id;
                //            settings.Values["userEmail"] = userAccount.UserName;
                //            settings.Values["userName"] = userAccount.Properties["DisplayName"];
                //        }
                //        return true;
                //    }
                //    else
                //    {
                //        // The saved account could not be used for getting a token.
                //        // Make sure that the UX is ready for a new sign in.
                //        await SignOutAsync();
                //        return false;

                //    }
                //}
                {
                    // The saved account could not be used for getting a token.
                    // Make sure that the UX is ready for a new sign in.
                    await SignOutAsync();
                    return null;
                }
            }
            catch (Exception)
            {
                await SignOutAsync();
                return null;
            }


        }

        public static async Task<bool> LoginAsync()
        {
            if (tcs != null && tcs.Task != null && tcs.Task.Status == TaskStatus.Running)
                return false;

            tcs = new TaskCompletionSource<Boolean>();
            AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested += OnAccountCommandsRequested;

            AccountsSettingsPane.Show();

            //Await the completion from any event handler
            await tcs.Task;

            AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested -= OnAccountCommandsRequested;

            return tcs.Task.Result;

        }


        public static async Task<Dictionary<string, CapabilityDiscoveryResult>> GetCapabilities(WebAccountProvider webAccountProvider = null)
        {
            if (capabilities != null)
                return capabilities;

            if (webAccountProvider == null)
                webAccountProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(AccountProviderId, Authority);

            DiscoveryClient discoveryClient = new DiscoveryClient(
                    async () => await GetTokenHelperAsync(null, DiscoveryResourceId));

            // Get capabilities
            capabilities = await discoveryClient.DiscoverCapabilitiesAsync() as Dictionary<string, CapabilityDiscoveryResult>;

            return capabilities;
        }
        private static async void OnAccountCommandsRequested(AccountsSettingsPane sender, AccountsSettingsPaneCommandsRequestedEventArgs e)
        {
            // In order to make async calls within this callback, the deferral object is needed
            var deferral = e.GetDeferral();

            // The Microsoft account provider is always present in Windows 10 devices, as is the Azure AD plugin.
            // If a non-installed plugin or incorect identity is specified, FindAccountProviderAsync will return null   
            var webAccountProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
                AccountProviderId, Authority);

            var providerCommand = new WebAccountProviderCommand(webAccountProvider,
                async (c) =>
                {
                    try
                    {
                        currentToken = await GetTokenHelperAsync(c.WebAccountProvider, GraphResourceId);

                        DiscoveryClient discoveryClient = new DiscoveryClient(
                                async () => await GetTokenHelperAsync(null, DiscoveryResourceId));

                        //Get capabilities
                        capabilities = await discoveryClient.DiscoverCapabilitiesAsync() as Dictionary<string, CapabilityDiscoveryResult>;


                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        SignOutAsync();
                        tcs.TrySetResult(false);
                    }
                    var isValid = !String.IsNullOrEmpty(currentToken);

                    if (!isValid)
                        await SignOutAsync();

                    tcs.TrySetResult(isValid);
                });

            e.WebAccountProviderCommands.Add(providerCommand);

            deferral.Complete();
        }

        public static async Task<string> GetTokenHelperAsync()
        {
            if (!String.IsNullOrEmpty(currentToken))
                return currentToken;

            return await GetTokenHelperAsync(null, GraphResourceId);
        }

        // Get an access token for the given context and resourceId. An attempt is first made to 
        // acquire the token silently. If that fails, then we try to acquire the token by prompting the user.
        public static async Task<string> GetTokenHelperAsync(WebAccountProvider accountProvider, string resourceId)
        {
            string token = null;
            WebAccountProvider aadAccountProvider;

            if (accountProvider != null)
            {
                aadAccountProvider = accountProvider;
            }
            else
            {
                aadAccountProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
                    AccountProviderId, Authority);

            }

            // Check if there's a record of the last account used with the app.
            var userID = settings.Values["userID"];

            WebTokenRequest webTokenRequest = new WebTokenRequest(aadAccountProvider, string.Empty, clientId);
            webTokenRequest.Properties.Add("resource", resourceId);

            WebTokenRequestResult webTokenRequestResult;
            if (userID != null)
            {
                // Get an account object for the user.
                userAccount = await WebAuthenticationCoreManager.FindAccountAsync(aadAccountProvider, (string)userID);

                // Ensure that the saved account works for getting the token we need.
                webTokenRequestResult = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(webTokenRequest, userAccount);
            }
            else
            {
                webTokenRequestResult = await WebAuthenticationCoreManager.RequestTokenAsync(webTokenRequest);
            }

            if (webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.Success || webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.AccountSwitch)
            {
                WebTokenResponse webTokenResponse = webTokenRequestResult.ResponseData[0];
                userAccount = webTokenResponse.WebAccount;
                token = webTokenResponse.Token;

                // We succeeded in getting a valid user.
                if (userAccount != null)
                {
                    // Save user ID in local storage.
                    settings.Values["userID"] = userAccount.Id;
                    settings.Values["userEmail"] = userAccount.UserName;
                    settings.Values["userName"] = userAccount.Properties["DisplayName"];
                }

                return token;
            }
            else if (webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.UserInteractionRequired)
            {
                webTokenRequest = new WebTokenRequest(aadAccountProvider, string.Empty, clientId, WebTokenRequestPromptType.ForceAuthentication);
                webTokenRequest.Properties.Add("resource", resourceId);

                //get token through prompt
                if (userID != null)
                {
                    // Ensure that the saved account works for getting the token we need.
                    webTokenRequestResult = await WebAuthenticationCoreManager.RequestTokenAsync(webTokenRequest, userAccount);
                }
                else
                {
                    webTokenRequestResult = await WebAuthenticationCoreManager.RequestTokenAsync(webTokenRequest);
                }

                if (webTokenRequestResult.ResponseStatus == WebTokenRequestStatus.Success)
                {
                    WebTokenResponse webTokenResponse = webTokenRequestResult.ResponseData[0];
                    userAccount = webTokenResponse.WebAccount;
                    currentToken = webTokenResponse.Token;

                    if (userAccount != null)
                    {
                        // Save user ID in local storage.
                        settings.Values["userID"] = userAccount.Id;
                        settings.Values["userEmail"] = userAccount.UserName;
                        settings.Values["userName"] = userAccount.Properties["DisplayName"];
                    }
                    return token;
                }
                else
                {
                    // The saved account could not be used for getting a token.
                    // Make sure that the UX is ready for a new sign in.
                    await SignOutAsync();
                    return null;

                }
            }
            else
            {
                // The saved account could not be used for getting a token.
                // Make sure that the UX is ready for a new sign in.
                await SignOutAsync();
                return null;
            }

        }

        /// <summary>
        /// Signs the user out of the service.
        /// </summary>
        public static async System.Threading.Tasks.Task SignOutAsync()
        {
            if (settings.Values["userID"] != null)
            {
                try
                {

                    WebAccountProvider providertoDelete = await WebAuthenticationCoreManager.FindAccountProviderAsync(
                        AccountProviderId, Authority);

                    WebAccount accountToDelete = await WebAuthenticationCoreManager.FindAccountAsync(
                        providertoDelete, (string)settings.Values["userID"]);

                    if (accountToDelete != null)
                        await accountToDelete.SignOutAsync();
                }
                catch (Exception)
                {
                }
            }

            //Clear stored values from last authentication.
            currentToken = null;
            //capabilities = null;
            settings.Values["userID"] = null;
            settings.Values["userEmail"] = null;
            settings.Values["userName"] = null;

        }
        public static GraphService GetGraphService()
        {
            try
            {
                if (graphService != null)
                    return graphService;

                graphService = new GraphService(new Uri(GraphEndpointId), GetTokenHelperAsync);

                return graphService;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }


        }

        public static string GetAppRedirectURI()
        {
            // Windows 10 universal apps require redirect URI in the format below. Add a breakpoint to this line, and run the app before you register it so that
            // you can supply the correct redirect URI value.
            return string.Format("ms-appx-web://microsoft.aad.brokerplugin/{0}", WebAuthenticationBroker.GetCurrentApplicationCallbackUri().Host.ToUpper());
        }

    }
}
