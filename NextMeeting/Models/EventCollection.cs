using Microsoft.Graph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Models
{
    public class EventCollection : ICollection<Event>
    {
        Collection<Event> collection = new Collection<Event>();

        /// <summary>
        /// Gets a ev by its index in the collection
        /// </summary>
        public Event this[int index]
        {
            get
            {
                return collection[index];
            }
        }

        /// <summary>
        /// Gets a ev identified by its mail or evprincipalname property
        /// </summary>
        public Event this[string identifier]
        {
            get
            {
                if (string.IsNullOrEmpty(identifier))
                    throw new ArgumentNullException("id");

                var ev = this.collection.FirstOrDefault(u => u.Id.Equals(identifier, StringComparison.CurrentCultureIgnoreCase));

                return ev;
            }
        }

        /// <summary>
        /// Gets a ev index in the collection
        /// </summary>
        public int IndexOf(Event ev)
        {
            return collection.IndexOf(ev);
        }

        /// <summary>
        /// Gets a ev index in the collection
        /// </summary>
        public int IndexOf(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException(identifier);

            int count = Count;
            Event ev = this[identifier];

            if (ev == null)
                return -1;

            for (int j = 0; j < count; j++)
                if (ev == collection[j])
                    return j;

            return -1;
        }

        internal void AddRange(IList<Event> events)
        {
            foreach (var ev in events)
            {
                if (!this.Contains(ev))
                    this.Add(ev);
                else
                    this.Merge(ev);
            }
        }


        /// <summary>
        /// Add all events in the collections. If Already exists, merge it, if not add it
        /// </summary>
        /// <param name="events"></param>
        public void MergeAll(IList<Event> events)
        {
            foreach (var ev in events)
            {
                if (!this.Contains(ev))
                    this.Add(ev);
                else
                    this.Merge(ev);
            }

            // Delete events not in the events parameter.
            // Maybe user has deleted an event, so we must synchronize it
            var array = this.ToArray();
            foreach (var arrayEvent in array)
            {
                if (!events.Any(ev => ev.Id.Equals(arrayEvent.Id, StringComparison.CurrentCultureIgnoreCase)))
                    this.Remove(arrayEvent);
            }
        }

        public void Merge(Event newEvent)
        {
            var oldEvent = this[newEvent.Id];

            if (oldEvent == null)
                return;

            // get the correct index
            var index = this.IndexOf(oldEvent);

            // replace with new one
            this.collection[index] = newEvent;
        }

        /// <summary>
        /// Gets evs's collection count
        /// </summary>
        public int Count => this.collection.Count;

        /// <summary>
        /// Gets if collection is readonly (false by design)
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a ev to the collection if not already exists
        /// </summary>
        public void Add(Event item)
        {
            if (!Contains(item))
                collection.Add(item);
        }

        /// <summary>
        /// Clear the evs's collection
        /// </summary>
        public void Clear()
        {
            this.collection.Clear();
        }

        /// <summary>
        /// Check if a ev is already in the collection
        /// </summary>
        public bool Contains(Event item)
        {
            return this.collection.Any(u => u.Id.Equals(item.Id, StringComparison.CurrentCultureIgnoreCase));
        }
        /// <summary>
        /// Check if a ev is already in the collection, with its Mail or EventPrincipalName
        /// </summary>
        public bool Contains(string identifier)
        {
            return this.collection.Any(u => u.Id.Equals(identifier, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Copy collection to an other collection
        /// </summary>
        public void CopyTo(Event[] array, int arrayIndex)
        {
            for (int i = 0; i < collection.Count; ++i)
                array[arrayIndex + i] = collection[i];
        }

        /// <summary>
        /// Remove a ev from the collection
        /// </summary>
        public bool Remove(Event item)
        {
            if (this.Contains(item))
            {
                this.collection.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove a ev from the collection
        /// </summary>
        public bool RemoveRange(Event[] items)
        {
            foreach (var item in items)
            {
                if (this.Contains(item))
                {
                    this.collection.Remove(item);
                }
            }
            return true;
        }

        /// <summary>
        /// Remove a ev from the collection, based on its index.
        /// </summary>
        public void RemoveAt(int index)
        {
            var u = this[index];
            if (u != null)
                Remove(u);
        }

        /// <summary>
        /// Remove a ev from the collection, based on its identifier.
        /// </summary>
        public void Remove(string identifier)
        {
            var u = this[identifier];
            if (u != null)
                Remove(u);
        }
        public IEnumerator<Event> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
