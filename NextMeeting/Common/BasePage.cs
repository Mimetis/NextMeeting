using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NextMeeting.Common
{
    public abstract partial class BasePage : Page, INotifyPropertyChanged
    {
        private static object lockObject = new object();
        public event PropertyChangedEventHandler PropertyChanged;

        private Microsoft.Graph.GraphService graph = AuthenticationHelper.GetGraphService();
        private CancellationTokenSource tokenSource;
        private TaskScheduler uiScheduler;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private bool isLoading = false;

        /// <summary>
        /// you can use IsLoading for any loading purpose
        /// </summary>
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                isLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
            }
        }

        public BasePage()
        {
        }

        public abstract String Title { get; }
       
        public Microsoft.Graph.GraphService Graph
        {
            get
            {
                return this.graph;
            }
        }
        public CancellationTokenSource TokenSource
        {
            get
            {
                return this.tokenSource;
            }
            set
            {
                this.tokenSource = value;
            }
        }
        public TaskScheduler UiScheduler
        {
            get
            {
                return this.uiScheduler;
            }
            set
            {
                this.uiScheduler = value;
            }
        }

        public void SetTitle(string newTitle)
        {
            AppShell.Current.SetTitle(newTitle);
        }

        public bool IsRefreshButtonEnabled
        {
            get
            {
                return AppShell.Current.RefreshButton.IsEnabled;
            }
            set
            {
                AppShell.Current.RefreshButton.IsEnabled = value;
            }
        }

        public void Navigate(Type pageType, object args = null)
        {
            AppShell.Current.Navigate(pageType, args);
        }
        public bool IsPageEnabled
        {
            get
            {
                return AppShell.Current.Splitter.IsPaneOpen;
            }
            set
            {
                AppShell.Current.Splitter.IsPaneOpen = value;
                AppShell.Current.Splitter.IsEnabled = value;
                AppShell.Current.ShellFrame.IsEnabled = value;

            }
        }

        public void CancelTokenSource()
        {
            if (tokenSource != null)
            {
                lock (lockObject)
                {
                    if (tokenSource != null)
                    {
                        try
                        {
                            tokenSource.Cancel();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AppShell.Current.SetTitle(Title);

            this.uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CancelTokenSource();

            base.OnNavigatedFrom(e);
        }
    }
}
