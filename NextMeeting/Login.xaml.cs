using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Autofac;
using Microsoft.Toolkit.Uwp.UI.Animations;
using NextMeeting.Helpers;
using NextMeeting.Navigation;
using NextMeeting.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NextMeeting.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();

            BgImg.Blur(value: 15, duration: 500, delay: 0).Start();
        }


        MainPage mainPage;

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;

            try
            {
                PgBar.Visibility = Visibility.Visible;

                if (mainPage == null)
                {
                    mainPage = new MainPage();

                    // Register all types
                    ContainerHelper.Current.RegisterTypes(mainPage.AppFrame);
                }

                // get the auth provider
                var authProvider = ContainerHelper.Current.Container.Resolve<IAuthenticationProvider2>();

                // try authenticate
                var token = await authProvider.AuthenticateAsync();

                if (String.IsNullOrEmpty(token.AccessToken))
                    throw new Exception("Can't get a correct access token from identity provider.");

                var navigationService = ContainerHelper.Current.Container.Resolve<INavigationService>();

                // Don't want to register Main page, but we need the Navigation service
                mainPage.InitializeNavigationService(navigationService);

                // Place the frame in the current Window
                Window.Current.Content = mainPage;

                App.SetupTitlebar();

            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
            }
            finally
            {
                PgBar.Visibility = Visibility.Collapsed;
            }

            (sender as Button).IsEnabled = true;

        }
    }
}
