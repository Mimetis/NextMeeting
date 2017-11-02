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
    public class UserCollection : ICollection<User>
    {
        Collection<User> collection = new Collection<User>();

        public UserCollection()
        {
            var i = 1;
        }
        /// <summary>
        /// Gets a user by its index in the collection
        /// </summary>
        public User this[int index]
        {
            get
            {
                return collection[index];
            }
        }

        /// <summary>
        /// Gets a user identified by its mail or userprincipalname property
        /// </summary>
        public User this[string identifier]
        {
            get
            {
                if (string.IsNullOrEmpty(identifier))
                    throw new ArgumentNullException("id");

                var user = this.collection.FirstOrDefault(u => u.Mail.Equals(identifier, StringComparison.CurrentCultureIgnoreCase) || u.UserPrincipalName.Equals(identifier, StringComparison.CurrentCultureIgnoreCase));

                return user;
            }
        }

        /// <summary>
        /// Gets a user index in the collection
        /// </summary>
        public int IndexOf(User user)
        {
            return collection.IndexOf(user);
        }

        /// <summary>
        /// Gets a user index in the collection
        /// </summary>
        public int IndexOf(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException(identifier);

            int count = Count;
            User user = this[identifier];

            if (user == null)
                return -1;

            for (int j = 0; j < count; j++)
                if (user == collection[j])
                    return j;

            return -1;
        }
        /// <summary>
        /// Gets users's collection count
        /// </summary>
        public int Count => this.collection.Count;

        /// <summary>
        /// Gets if collection is readonly (false by design)
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a user to the collection if not already exists
        /// </summary>
        public void Add(User item)
        {
            if (!Contains(item))
                collection.Add(item);
        }



        /// <summary>
        /// Add all events in the collections. If Already exists, merge it, if not add it
        /// </summary>
        public void MergeAll(IList<User> users)
        {
            foreach (var user in users)
            {
                if (!this.Contains(user))
                    this.Add(user);
                else
                    this.Merge(user);
            }

            // Delete events not in the events parameter.
            // Maybe user has deleted an event, so we must synchronize it
            var array = this.ToArray();
            foreach (var arrayUser in array)
            {
                if (!users.Any(ev => ev.Id.Equals(arrayUser.Id, StringComparison.CurrentCultureIgnoreCase)))
                    this.Remove(arrayUser);
            }
        }

        public void Merge(User newUser)
        {
            var oldUser = this[newUser.Id];

            if (oldUser == null)
                return;

            // get the correct index
            var index = this.IndexOf(oldUser);

            // replace with new one
            this.collection[index] = newUser;
        }

        /// <summary>
        /// Clear the users's collection
        /// </summary>
        public void Clear()
        {
            this.collection.Clear();
        }

        /// <summary>
        /// Check if a user is already in the collection
        /// </summary>
        public bool Contains(User item)
        {
            return this.collection.Any(u => u.Mail.Equals(item.Mail, StringComparison.CurrentCultureIgnoreCase) || u.UserPrincipalName.Equals(item.UserPrincipalName, StringComparison.CurrentCultureIgnoreCase));
        }
        /// <summary>
        /// Check if a user is already in the collection, with its Mail or UserPrincipalName
        /// </summary>
        public bool Contains(string identifier)
        {
            return this.collection.Any(u => u.Mail.Equals(identifier, StringComparison.CurrentCultureIgnoreCase) || u.UserPrincipalName.Equals(identifier, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Copy collection to an other collection
        /// </summary>
        public void CopyTo(User[] array, int arrayIndex)
        {
            for (int i = 0; i < collection.Count; ++i)
                array[arrayIndex + i] = collection[i];
        }

        /// <summary>
        /// Remove a user from the collection
        /// </summary>
        public bool Remove(User item)
        {
            if (this.Contains(item))
            {
                this.collection.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove a user from the collection, based on its index.
        /// </summary>
        public void RemoveAt(int index)
        {
            var u = this[index];
            if (u != null)
                Remove(u);
        }

        /// <summary>
        /// Remove a user from the collection, based on its identifier.
        /// </summary>
        public void Remove(string identifier)
        {
            var u = this[identifier];
            if (u != null)
                Remove(u);
        }
        public IEnumerator<User> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
