using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NextMeeting.Models
{
    public class EventDayViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EventViewModel> Events { get; private set; }
        private DateTime dateTime;
        private int index;
        public DateTime DateTime
        {
            get
            {
                return dateTime;

            }
            set
            {
                dateTime = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
            }
        }

       

        public EventDayViewModel(DateTime dateTime, int index)
        {
            this.Events = new ObservableCollection<EventViewModel>();
            this.DateTime = dateTime.ToLocalTime();

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
