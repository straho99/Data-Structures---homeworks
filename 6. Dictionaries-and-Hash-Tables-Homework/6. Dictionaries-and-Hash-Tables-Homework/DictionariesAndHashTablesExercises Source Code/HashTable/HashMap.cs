namespace Hash_Table
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private HashTable<TKey, TValue> elements;
        private const int initialCapacity = 16;

        public HashMap(int capacity = initialCapacity)
        {
            this.elements = new HashTable<TKey, TValue>(capacity);
        }

        public void Add(TKey key, TValue value)
        {
            this.elements.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return this.elements.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return this.elements.Keys.ToList(); }
        }

        public bool Remove(TKey key)
        {
            return this.elements.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.elements.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return this.elements.Values.ToList(); }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.elements[key];
            }
            set
            {
                this.elements[key] = value;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this.elements.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return this.elements.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Array.Copy(this.elements.Values.ToArray(), 0, array, arrayIndex, this.elements.Count);
        }

        public int Count
        {
            get
            {
                return this.elements.Count();
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.elements.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return new KeyValuePair<TKey, TValue>(element.Key, element.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
