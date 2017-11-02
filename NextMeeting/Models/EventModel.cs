using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Models
{
    public class EventModel : INotifyPropertyChanged
    {
        const int TOP_ATTENDEES_NUMBERS = 10;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private int index;
        private string bodyPreview;
        private UserModel organizer;
        private ObservableCollection<UserModel> attendees;
        private ObservableCollection<ResourceModel> sharedItems;
        private ObservableCollection<ResourceModel> topSharedItems;
        private bool isLoadingSharedItems = true;
        private bool hasNoSharedItems = false;

        public EventModel(Event graphEvent)
        {
            this.Event = graphEvent;
            this.Organizer = new UserModel(this.Event.Organizer.EmailAddress);
            this.Attendees = new ObservableCollection<UserModel>(graphEvent.Attendees.Select(a => new UserModel(a.EmailAddress)));
            this.topSharedItems = new ObservableCollection<ResourceModel>();
            this.sharedItems = new ObservableCollection<ResourceModel>();
        }

        /// <summary>
        /// Index of the event. Useful for the 1st one to change the DataTemplate
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
                RaisePropertyChanged(nameof(Index));
            }
        }


        public bool IsLoadingSharedItems
        {
            get
            {
                return isLoadingSharedItems;
            }

            set
            {
                isLoadingSharedItems = value;
                RaisePropertyChanged(nameof(IsLoadingSharedItems));
            }
        }

        public bool HasNoSharedItems
        {
            get
            {
                return hasNoSharedItems;
            }

            set
            {
                hasNoSharedItems = value;
                RaisePropertyChanged(nameof(HasNoSharedItems));
            }
        }
        public ObservableCollection<ResourceModel> SharedItems
        {
            get
            {
                return sharedItems;
            }

            set
            {
                sharedItems = value;
                RaisePropertyChanged(nameof(SharedItems));
                RaisePropertyChanged(nameof(TopSharedItems));
            }
        }
        public ObservableCollection<ResourceModel> TopSharedItems
        {
            get
            {
                return topSharedItems;
            }
            set
            {
                topSharedItems = value;
                RaisePropertyChanged(nameof(TopSharedItems));
            }
        }

        /// <summary>
        /// Subject
        /// </summary>
        public String Subject => this.Event.Subject;

        /// <summary>
        /// Starting date
        /// </summary>
        public DateTime StartingDate => DateTime.Parse(this.Event.Start.DateTime).ToLocalTime();

        /// <summary>
        /// Ending date
        /// </summary>
        public DateTime EndingDate => DateTime.Parse(this.Event.End.DateTime).ToLocalTime();

        /// <summary>
        /// Gets the Is All Day property
        /// </summary>
        public Boolean IsAllDay => this.Event.IsAllDay.HasValue ? this.Event.IsAllDay.Value : false;

        /// <summary>
        /// Gets the Delta time for the current event
        /// </summary>
        public String TimeDelta
        {
            get
            {
                if (this.IsAllDay)
                    return "All day event";

                return this.StartingHourDate + "-" + this.EndingHourDate;
            }
        }

        /// <summary>
        /// Gets the Starting hour date in string format
        /// </summary>
        public String StartingHourDate
        {
            get
            {
                var hour = this.StartingDate.Hour < 10 ? "0" + this.StartingDate.Hour.ToString() : this.StartingDate.Hour.ToString();
                var min = this.StartingDate.Minute < 10 ? "0" + this.StartingDate.Minute.ToString() : this.StartingDate.Minute.ToString();
                return string.Format("{0}:{1}", hour, min);
            }
        }

        /// <summary>
        /// Gets the Ending hour date in string format
        /// </summary>
        public String EndingHourDate
        {
            get
            {
                var hour = this.EndingDate.Hour < 10 ? "0" + this.EndingDate.Hour.ToString() : this.EndingDate.Hour.ToString();
                var min = this.EndingDate.Minute < 10 ? "0" + this.EndingDate.Minute.ToString() : this.EndingDate.Minute.ToString();
                return string.Format("{0}:{1}", hour, min);
            }
        }

        /// <summary>
        /// Gets the location event
        /// </summary>
        public String Location => this.Event.Location.DisplayName;

        /// <summary>
        /// Gets if the location is not defined
        /// </summary>
        public Boolean IsLocationUndefined => String.IsNullOrWhiteSpace(this.Location);

        /// <summary>
        /// Gets or Sets the current calendar event
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// Gets the event body
        /// </summary>
        public ItemBody Body => this.Event.Body;

        /// <summary>
        /// Gets the event id
        /// </summary>
        public String Id => this.Event.Id;

        /// <summary>
        /// Gets or Sets the body Proview
        /// </summary>
        public string BodyPreview
        {
            get
            {
                return bodyPreview;
            }

            set
            {
                bodyPreview = value;
                RaisePropertyChanged(nameof(BodyPreview));
            }
        }

        /// <summary>
        /// Gets if the body is not defined
        /// </summary>
        public Boolean IsBodyEmpty => String.IsNullOrWhiteSpace(this.BodyPreview);

        /// <summary>
        /// Get or Sets the attendees associated with the current event
        /// </summary>
        public ObservableCollection<UserModel> Attendees
        {
            get
            {
                return attendees;
            }

            set
            {
                attendees = value;
                RaisePropertyChanged(nameof(Attendees));
                RaisePropertyChanged(nameof(TopAttendees));
            }
        }

        /// <summary>
        /// Gets the TOP 10 attendees
        /// </summary>
        public ObservableCollection<UserModel> TopAttendees
        {
            get
            {

                return new ObservableCollection<UserModel>(this.Attendees.Take(TOP_ATTENDEES_NUMBERS).ToList());
            }
        }

        public UserModel Organizer
        {
            get
            {
                return organizer;
            }

            set
            {
                organizer = value;
                RaisePropertyChanged(nameof(Organizer));
            }
        }
    }
}
