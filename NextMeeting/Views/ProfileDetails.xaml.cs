using NextMeeting.Common;
using NextMeeting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NextMeeting.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfileDetails : BasePage, IRefreshPage
    {
        public ProfileDetails()
        {
            this.InitializeComponent();
        }

        private ProfileViewModel profile;
        public ProfileViewModel Profile
        {
            get
            {
                return profile;
            }

            set
            {
                profile = value;
                RaisePropertyChanged(nameof(Profile));
            }
        }
        public UserViewModel User { get; set; }

        public override string Title
        {
            get
            {
                return "profile details";
            }
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.User = e.Parameter as UserViewModel;
            this.Profile = new ProfileViewModel(this.User);

            try
            {
                //if (!this.User.IsLoadedFromGraph)
                //    await this.User.UpdateUserAsync(CancellationToken.None);

                await Refresh();
            }
            catch (OperationCanceledException ex)
            {
                Debug.WriteLine("Operation canceled " + ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
        public async Task Refresh()
        {
            using (this.TokenSource = new CancellationTokenSource())
            {
                try
                {
                    this.IsRefreshButtonEnabled = false;
                    await this.Profile.Refresh(TokenSource.Token, true);
                }
                catch (OperationCanceledException ex)
                {
                    Debug.WriteLine("Operation canceled " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    this.IsRefreshButtonEnabled = true;
                }
            }

        }
      
        private void DriveItem_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            var item = e.ClickedItem as DriveItemViewModel;

            if (e == null)
                return;

            item.OpenItem.Execute(null);
        }

    }
}
