namespace _02.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value) 
        {
            if (this.valuesByFirstKey.ContainsKey(key1))
            {
                this.valuesByFirstKey[key1].Add(value);
            }
            else
            {
                this.valuesByFirstKey[key1] = new List<T>() { value };
            }

            if (this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey[key2].Add(value);
            }
            else
            {
                this.valuesBySecondKey[key2] = new List<T>() { value };
            }

            var tuple = new Tuple<K1, K2>(key1, key2);
            if (this.valuesByBothKeys.ContainsKey(tuple))
            {
                this.valuesByBothKeys[tuple].Add(value);
            }
            else
            {
                this.valuesByBothKeys[tuple] = new List<T>() { value };
            }
        }

        public IEnumerable<T> Find(K1 key1, K2 key2) 
        {
            var bothKeys = new Tuple<K1, K2>(key1, key2);
            if (this.valuesByBothKeys.ContainsKey(bothKeys))
            {
                return this.valuesByBothKeys[new Tuple<K1, K2>(key1, key2)];
            }
            else
            {
                return Enumerable.Empty<T>();
            }
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            if (this.valuesByFirstKey.ContainsKey(key1))
            {
                return this.valuesByFirstKey[key1];
            }
            else
            {
                return Enumerable.Empty<T>();
            }
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            if (this.valuesBySecondKey.ContainsKey(key2))
            {
                return this.valuesBySecondKey[key2];
            }
            else
            {
                return Enumerable.Empty<T>();
            }
        }

        public bool Remove(K1 key1, K2 key2)
        {
            if (this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesByFirstKey.Remove(key1);
                this.valuesBySecondKey.Remove(key2);
                this.valuesByBothKeys.Remove(new Tuple<K1, K2>(key1, key2));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
