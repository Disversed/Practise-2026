using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCollections_2.CustomOrderedDictionary
{
    internal class OrderedDictionaryWrap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<KeyValuePair<TKey, TValue>> list;
        private Dictionary<TKey, TValue> dict;
        public int Count { get { return list.Count; } }
        public int Capacity { get { return list.Capacity; } }

        public TValue this[TKey key]
        {
            get { return dict[key]; }
            set
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;

                    int index = list.FindIndex(pair => dict.Comparer.Equals(pair.Key, key));
                    list[index] = new KeyValuePair<TKey, TValue>(key, value);
                }
                else
                {
                    Add(key, value);
                }
            }
        }
        public TValue this[int index]
        {
            get { return list[index].Value; }
            set
            {
                KeyValuePair<TKey, TValue> oldPair = list[index];
                dict[oldPair.Key] = value;
                list[index] = new KeyValuePair<TKey, TValue>(oldPair.Key, value);
            }
        }

        public OrderedDictionaryWrap() : this(0, null) { }
        public OrderedDictionaryWrap(int capacity) : this(capacity, null) { }
        public OrderedDictionaryWrap(IEqualityComparer<TKey> comparer) : this(0, comparer) { }
        public OrderedDictionaryWrap(int capacity, IEqualityComparer<TKey> comparer)
        {
            list = new List<KeyValuePair<TKey, TValue>>(capacity);
            dict = new Dictionary<TKey, TValue>(capacity, comparer);
        }

        public void Add(TKey key, TValue value)
        {
            dict.Add(key, value);
            list.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public void Insert(int index, TKey key, TValue value)
        {
            if (index < 0 || index > Count) throw new Exception("Index out of range");

            dict.Add(key, value);
            list.Insert(index, new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            if (!dict.Remove(key)) return false;

            int index = list.FindIndex(pair => dict.Comparer.Equals(pair.Key, key));
            list.RemoveAt(index);
            return true;
        }

        public bool Contains(TKey key)
        {
            return dict.ContainsKey(key);
        }

        public void Clear()
        {
            list.Clear();
            dict.Clear();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
