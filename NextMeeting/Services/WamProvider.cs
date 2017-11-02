using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.UI.ApplicationSettings;

namespace NextMeeting.Services
{
    public class WamProvider
    {
        private TaskCompletionSource<Boolean> tcs;

        public async Task<bool> LoginAsync()
        {
            if (tcs != null && tcs.Task != null && tcs.Task.Status == TaskStatus.Running)
                return false;

            tcs = new TaskCompletionSource<Boolean>();
            AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested += BuildPaneAsync;

            AccountsSettingsPane.Show();

            //Await the completion from any event handler
            await tcs.Task;

            AccountsSettingsPane.GetForCurrentView().AccountCommandsRequested -= BuildPaneAsync;

            return tcs.Task.Result;

        }

        private async void BuildPaneAsync(AccountsSettingsPane s, AccountsSettingsPaneCommandsRequestedEventArgs e)
        {
            var deferral = e.GetDeferral();

            var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync(
                "https://login.microsoft.com", "organizations");

            var command = new WebAccountProviderCommand(msaProvider, GetMsaTokenAsync);

            e.WebAccountProviderCommands.Add(command);

            deferral.Complete();
        }

        private async void GetMsaTokenAsync(WebAccountProviderCommand command)
        {
            try
            {

                WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "User.Read", "b70aac0e-0084-4145-a852-d8d126ae3e95");
                request.Properties.Add("resource", "https://graph.microsoft.com");

                WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
        }
    }
}
