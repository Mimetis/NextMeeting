using NextMeeting.Helpers;
using NextMeeting.Navigation;
using NextMeeting.Services;
using NextMeeting.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NextMeeting.ViewModels
{
    public class LogoutViewModel : INotifyPropertyChanged, IViewModelNavigable
    {
        private readonly IGraphProvider graphProvider;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public LogoutViewModel(IGraphProvider graphProvider)
        {
            this.graphProvider = graphProvider;
        }
        public async Task Navigated(NavigationEventArgs e, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Logout.
        /// Since we are not navigating to a page included in MainPage, 
        /// breaking the Window.Current.Content and start another one
        /// </summary>
        public void Logout(object sender, RoutedEventArgs e)
        {
            this.graphProvider.SignOut();

            ContainerHelper.Current.Container.Dispose();
            ContainerHelper.Current.Container = null;

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
            }

            rootFrame.Navigate(typeof(Login), null);

        }

        public Task Navigating(NavigatingCancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
