// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Toolkit.Uwp.Helpers;
using NextMeeting.Helpers;
using NextMeeting.Services;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NextMeeting.Navigation
{
    public class NavigationService : INavigationService
    {
        private bool _isNavigating;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        /// <param name="frameAdapter"></param>
        /// <param name="iocResolver"></param>
        public NavigationService(IFrameAdapter frame, IComponentContext iocResolver, IGraphProvider graphProvider)
        {
            Frame = frame;
            GraphProvider = graphProvider;
            Frame.Navigated += Frame_Navigated;
        }

        public event EventHandler<bool> IsNavigatingChanged;

        public event EventHandler Navigated;

        public bool CanGoBack => Frame.CanGoBack;

        private IFrameAdapter Frame { get; }
        public IGraphProvider GraphProvider { get; }

        public bool IsNavigating
        {
            get => _isNavigating;

            set
            {
                if (value != _isNavigating)
                {
                    _isNavigating = value;
                    IsNavigatingChanged?.Invoke(this, _isNavigating);

                    // Check that navigation just finished
                    if (!_isNavigating)
                    {
                        // Navigation finished
                        Navigated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Navigate in the back direction
        /// </summary>
        /// <returns>A task that can be awaited</returns>
        public async Task GoBackAsync()
        {
            if (Frame.CanGoBack)
            {
                IsNavigating = true;

                Page navigatedPage = await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    Frame.GoBack();
                    return Frame.Content as Page;
                });
            }
        }

        /// <summary>
        /// The Navigated event. This event is raised BEFORE <see cref="Page.OnNavigatedTo(NavigationEventArgs)"/>
        /// </summary>
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var sourcePageType = e.SourcePageType;

            Page page = e.Content as Page;

            if (page == null)
                return;

           
            // Get the the ViewModel type associated with the view
            var vmType = ContainerHelper.Current.GetViewModelType(sourcePageType);

            if (vmType.PageType != null)
            {
                // Get the viewmodel instance
                var vm = ContainerHelper.Current.Container.Resolve(vmType.PageType);

                // Call the refresh method
                if (vm != null)
                    vmType.Refresh(page, vm, e.Parameter);
            }

            IsNavigating = false;

        }

        /// <summary>
        /// Navigate to a page without parameter
        /// </summary>
        public Task NavigateToPage<TPage>()
        {
            return NavigateToPage<TPage>(null);
        }

        /// <summary>
        /// Navigate to a page with a parameter
        /// </summary>
        public async Task NavigateToPage<TPage>(object parameter)
        {
            // Early out if already in the middle of a Navigation
            if (_isNavigating)
                return;

            _isNavigating = true;

            await DispatcherHelper.ExecuteOnUIThreadAsync(() => Frame.Navigate(typeof(TPage), parameter));

        }

        public void Disconnect()
        {
            this.GraphProvider.SignOut();
        }
    }
}
