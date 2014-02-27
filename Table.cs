using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP
{
    public abstract class Table<K, V> : IDictionary<K, V>
    {
        protected IDictionary<K, V> _table;

        public Table()
        {
            _table = new Dictionary<K, V>();
        }

        public Table(IDictionary<K, V> table)
        {
            _table = new Dictionary<K, V>(table);
        }

        public virtual void Add(K key, V value)
        {
            _table.Add(key, value);
        }

        public virtual bool ContainsKey(K key)
        {
            return _table.ContainsKey(key);
        }

        public virtual ICollection<K> Keys
        {
            get { return _table.Keys; }
        }

        public virtual bool Remove(K key)
        {
            return _table.Remove(key);
        }

        public virtual bool TryGetValue(K key, out V value)
        {
            return _table.TryGetValue(key, out value);
        }

        public virtual ICollection<V> Values
        {
            get { return _table.Values; }
        }

        public virtual V this[K key]
        {
            get
            {
                return _table[key];
            }
            set
            {
                _table[key] = value;
            }
        }

        public virtual void Add(KeyValuePair<K, V> item)
        {
            _table.Add(item.Key, item.Value);
        }

        public virtual void Clear()
        {
            _table.Clear();
        }

        public virtual bool Contains(KeyValuePair<K, V> item)
        {
            return _table.Contains(item);
        }

        public virtual void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            _table.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return _table.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public virtual bool Remove(KeyValuePair<K, V> item)
        {
            return _table.Remove(item.Key);
        }

        public virtual IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return _table.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _table.GetEnumerator() as System.Collections.IEnumerator;
        }
    }
}
