﻿using Microsoft.OData.ProxyExtensions;
using NextMeeting.Common;
using NextMeeting.Graph;
using NextMeeting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class SearchPeople : BasePage
    {
        public ObservableCollection<UserViewModel> Users { get; set; }

        
        public SearchPeople()
        {
            this.InitializeComponent();
            this.Users = new ObservableCollection<UserViewModel>();
        }
        public override string Title
        {
            get
            {
                return "search people";
            }
        }
        public async Task<List<Microsoft.Graph.IUser>> Search(string val, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var lstUsers = new List<UserViewModel>();

            var allusers = await this.Graph.Users.GetUsersLike(val);

            return allusers;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.QueryText))
            {
                this.CancelTokenSource();

                using (TokenSource = new CancellationTokenSource())
                {
                    try
                    {
                        this.IsRefreshButtonEnabled = false;
                        this.IsLoading = true;
                        Users.Clear();

                        List<Microsoft.Graph.IUser> allusers = await Search(sender.Text, TokenSource.Token);

                        // Since we want to show the Users list even if the images are not loaded
                        this.IsLoading = false;
                        this.ListViewResearch.Focus(FocusState.Programmatic);

                        foreach (var user in allusers)
                        {
                            UserViewModel uvm = UserViewModel.GetUser(user.Id, null, null);

                            uvm.Name = user.DisplayName;
                            uvm.UserPrincipalName = user.UserPrincipalName;
                            uvm.Email = user.Mail;
                            uvm.Id = user.Id;
                            uvm.FirstName = user.GivenName;

                            if (string.IsNullOrEmpty(uvm.FirstName))
                                uvm.FirstName = uvm.Name.Split(' ').Length > 1 ? uvm.Name.Split(' ')[0] : uvm.Name;

                            uvm.IsLoadedFromGraph = true;

                            Users.Add(uvm);

                        }
                        //for (int i = 0; i < Users.Count; i = i + 3)
                        //{
                        //    List<Task> tasks = new List<Task>();

                        //    UserViewModel uvm = Users[i];
                        //    tasks.Add(uvm.UpdatePhotoAsync(TokenSource.Token));

                        //    if (i + 1 < Users.Count - 1)
                        //    {
                        //        uvm = Users[i + 1];
                        //        tasks.Add(uvm.UpdatePhotoAsync(TokenSource.Token));
                        //    }
                        //    if (i + 2 < Users.Count - 1)
                        //    {
                        //        uvm = Users[i + 2];
                        //        tasks.Add(uvm.UpdatePhotoAsync(TokenSource.Token));
                        //    }
                        //    if (i + 3 < Users.Count - 1)
                        //    {
                        //        uvm = Users[i + 3];
                        //        tasks.Add(uvm.UpdatePhotoAsync(TokenSource.Token));
                        //    }

                        //    await Task.WhenAll(tasks.ToArray());

                        //}
                    }
                    catch (TaskCanceledException ex)
                    {
                        Debug.WriteLine("Task canceled " + ex.Message);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Debug.WriteLine("Operation canceled " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception " + ex.Message);
                    }
                    finally
                    {
                        this.IsRefreshButtonEnabled = true;
                        this.IsLoading = false;
                        this.ListViewResearch.Focus(FocusState.Programmatic);
                    }
                }
            }
        }
        private void UserViewModel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as UserViewModel;

            if (e == null)
                return;

            item.UserCommand.Execute(null);
        }

       
    }
}