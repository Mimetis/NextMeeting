using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Models
{
    public class CacheManager<T> : INotifyPropertyChanged
    {
        public static Dictionary<string, Dictionary<Type, CacheManager<T>>> AllModels
        {
            get; private set;
        }
        private string id;
        private ObservableCollection<T> values;

        static CacheManager()
        {
            AllModels = new Dictionary<string, Dictionary<Type, CacheManager<T>>>();

        }

        private CacheManager()
        {
        }
        public CacheManager(string id)
        {
            this.id = id;
            this.Values = new ObservableCollection<T>();
        }

        // Get the FileViewModel from a defined userid
        public static CacheManager<T> Get(string id)
        {
            CacheManager<T> cache;

            if (!AllModels.ContainsKey(id))
            {
                AllModels.Add(id, new Dictionary<Type, CacheManager<T>>());
                cache = new CacheManager<T>(id);
                AllModels[id].Add(typeof(T), cache);

                return cache;
            }

            var userModels = AllModels[id];

            if (!userModels.ContainsKey(typeof(T)))
                userModels.Add(typeof(T), new CacheManager<T>(id));

            cache = userModels[typeof(T)];

            return cache;
        }

    

        public ObservableCollection<T> Values
        {
            get
            {
                return values;
            }
            set
            {
                if (value != values)
                    values = value;

                RaisePropertyChanged("Values");
            }
        }

        public void Clear()
        {
            this.Values.Clear();
        }

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
