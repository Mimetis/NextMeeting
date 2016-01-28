using Microsoft.Graph;
using NextMeeting.Common;
using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media;

namespace NextMeeting.Models
{

    public class AttendeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        private UserViewModel user;
        private string email;

        public AttendeeViewModel(Attendee attendee)
        {
            this.Email = attendee.EmailAddress.Address;

            if (attendee.Status != null)
                this.Response = attendee.Status.Response;

            this.AttendeeType = attendee.Type;

        }

        public UserViewModel User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

     
        public ResponseType Response { get; set; }

        public AttendeeType AttendeeType { get; set; }

        private RelayCommand attendeeContactCommand;

        public RelayCommand AttendeeContactCommand
        {
            get
            {
                return attendeeContactCommand ?? (attendeeContactCommand = new RelayCommand(() =>
                {
                    HandleContactClicked(this);
                }));
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        private void HandleContactClicked(AttendeeViewModel attendee)
        {
            var contact = new Windows.ApplicationModel.Contacts.Contact();

            contact.YomiGivenName = attendee.User.Name;
            contact.Name = attendee.User.Name;

            ContactEmail workEmail = new ContactEmail();
            workEmail.Address = attendee.User.Email;
            workEmail.Kind = ContactEmailKind.Work;
            contact.Emails.Add(workEmail);

            // Try to share the screen half/half with the full contact card.
            FullContactCardOptions options = new FullContactCardOptions();
            options.DesiredRemainingView = ViewSizePreference.UseHalf;

            // Show the full contact card.
            ContactManager.ShowFullContactCard(contact, options);
        }

    }
}
