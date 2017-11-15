﻿using Microsoft.Toolkit.Uwp.Helpers;
using NextMeeting.Helpers;
using NextMeeting.Navigation;
using NextMeeting.Views;
using NextMeeting.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NextMeeting.Services;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NextMeeting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // Navigation service
        private INavigationService _navigationService;
        private bool firstTime = true;

        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += MainPage_Loaded;

            // Tracking back arrow click event
            var nav = SystemNavigationManager.GetForCurrentView();
            nav.BackRequested += Nav_BackRequested;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // first time we load, go to meeting
            if (firstTime)
            {
                _navigationService.NavigateToPage<Events>();
                firstTime = false;
            }
        }

        /// <summary>
        /// Get the Frame inside the Main page
        /// </summary>
        public Frame AppFrame
        {
            get
            {
                return appNavFrame;
            }
        }


        public void InitializeNavigationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            // Set the correct icon
            switch (e.SourcePageType)
            {
                case Type c when e.SourcePageType == typeof(Events):
                    ((NavigationViewItem)navview.MenuItems[0]).IsSelected = true;
                    break;
                case Type c when e.SourcePageType == typeof(Search):
                    ((NavigationViewItem)navview.MenuItems[1]).IsSelected = true;
                    break;
                case Type c when e.SourcePageType == typeof(Logout):
                    ((NavigationViewItem)navview.MenuItems[2]).IsSelected = true;
                    break;
            }

            DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                 var nav = SystemNavigationManager.GetForCurrentView();

                 nav.AppViewBackButtonVisibility = _navigationService.CanGoBack ?
                     AppViewBackButtonVisibility.Visible :
                     AppViewBackButtonVisibility.Collapsed;
             });
        }

        private void Nav_BackRequested(object sender, BackRequestedEventArgs e)
        {
            var ignored = _navigationService.GoBackAsync();
            e.Handled = true;
        }

        public TitleBarHelper TitleHelper
        {
            get
            {
                return TitleBarHelper.Instance;
            }
        }

   
        private async void Navview_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // _navigationService.NavigateToSettingsAsync();
                return;
            }

            switch (args.InvokedItem as string)
            {
                case "Meetings":
                    await _navigationService.NavigateToPage<Events>();
                    break;
                case "Search":
                    await _navigationService.NavigateToPage<Search>();
                    break;
                case "Disconnect":
                    await _navigationService.NavigateToPage<Logout>();
                    break;
            }

        }
    }
}
