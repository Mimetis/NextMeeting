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

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public EventDayViewModel(DateTime dateTime, int index, List<IEvent> events)
        {
            this.Index = index;
            this.Events = new ObservableCollection<EventViewModel>();
            this.DateTime = dateTime.ToLocalTime();

            for (int i = 0; i <= events.Count - 1; i++)
            {
                var ev = events[i];
                var evm = new EventViewModel(ev, i, index);

                this.Events.Add(evm);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
