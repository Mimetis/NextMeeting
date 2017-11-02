using Autofac;
using NextMeeting.Helpers;
using NextMeeting.Navigation;
using NextMeeting.Views;
using NextMeeting.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graph;
using NextMeeting.Services;

namespace NextMeeting
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {


 
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            MainPage mainPage = Window.Current.Content as MainPage;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (mainPage == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                mainPage = new MainPage();

                // Using a frame adapter to be able to inject it through DI
                FrameAdapter adapter = new FrameAdapter(mainPage.AppFrame);

                // Register the FrameAdapter object
                ContainerHelper.Current.Builder.RegisterInstance(adapter).As<IFrameAdapter>();

                // Register graph service
                ContainerHelper.Current.Builder.RegisterType<GraphProvider>().As<IGraphProvider>();

                // Register user service
                ContainerHelper.Current.Builder.RegisterType<UserProvider>().As<IUserProvider>();

                // Register a Navigation Service single instance
                ContainerHelper.Current.Builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

                // Register a view model and then associated with its own view
                ContainerHelper.Current.RegisterTypeWithViewModel<EventsViewModel, Events>();
                ContainerHelper.Current.RegisterTypeWithViewModel<SearchesViewModel, Search>();
                ContainerHelper.Current.RegisterTypeWithViewModel<EventDetailsViewModel, EventDetails>();
                ContainerHelper.Current.RegisterTypeWithViewModel<ProfileDetailsViewModel, ProfileDetails>();

                // Create the container 
                ContainerHelper.Current.Build();

                // Don't want to register Main page, but we need the Navigation service
                mainPage.InitializeNavigationService(ContainerHelper.Current.Container.Resolve<INavigationService>());


                adapter.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = mainPage;

                // Ensure the current window is active
                Window.Current.Activate();

                SetupTitlebar();
            }

            if (e.PrelaunchActivated == false)
            {
                if (mainPage.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                }
            }
        }

        public static ElementTheme TrueTheme()
        {
            var frameworkElement = Window.Current.Content as FrameworkElement;
            return frameworkElement.ActualTheme;
        }

        /// <summary>
        /// Setting a personal title bar
        /// </summary>
        private static void SetupTitlebar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = Colors.Transparent;
                    if (TrueTheme() == ElementTheme.Dark)
                    {
                        titleBar.ButtonForegroundColor = Colors.White;
                        titleBar.ForegroundColor = Colors.White;
                    }
                    else
                    {
                        titleBar.ButtonForegroundColor = Colors.Black;
                        titleBar.ForegroundColor = Colors.Black;
                    }

                    titleBar.BackgroundColor = Colors.Black;

                    titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                    titleBar.ButtonInactiveForegroundColor = Colors.LightGray;

                    CoreApplicationViewTitleBar coreTitleBar = TitleBarHelper.Instance.TitleBar;

                    coreTitleBar.ExtendViewIntoTitleBar = true;
                }
            }
        }


        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
