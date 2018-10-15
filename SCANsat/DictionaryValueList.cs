using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCANsat
{
    // 
    // DictionaryValueList class taken from KSP_1.4.5 Assembly-CSharp.dll
    // 

    [Serializable]
    public class DictionaryValueList<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dict;
        private List<TValue> list;
        private List<TKey> listKeys;

        public DictionaryValueList()
        {
            this.dict = new Dictionary<TKey, TValue>();
            this.list = new List<TValue>();
            this.listKeys = new List<TKey>();
        }

        public DictionaryValueList(global.DictionaryValueList<TKey, TValue> old)
        {
            this.list = new List<TValue>((IEnumerable<TValue>)old.list);
            this.listKeys = new List<TKey>((IEnumerable<TKey>)old.listKeys);
            this.dict = new Dictionary<TKey, TValue>((IDictionary<TKey, TValue>)old.dict);
        }

        public void Clear()
        {
            this.list.Clear();
            this.listKeys.Clear();
            this.dict.Clear();
        }

        public bool Add(TKey key, TValue val)
        {
            bool flag = false;
            TValue obj;
            if (this.dict.TryGetValue(key, out obj))
            {
                this.list.Remove(obj);
                this.listKeys.Remove(key);
                this.dict.Remove(key);
                flag = true;
            }
            this.list.Add(val);
            this.listKeys.Add(key);
            this.dict.Add(key, val);
            return flag;
        }

        public bool Remove(TKey key)
        {
            TValue obj;
            if (!this.dict.TryGetValue(key, out obj))
                return false;
            this.list.Remove(obj);
            this.listKeys.Remove(key);
            this.dict.Remove(key);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue val)
        {
            return this.dict.TryGetValue(key, out val);
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.dict[key];
            }
            set
            {
                TValue obj;
                if (this.dict.TryGetValue(key, out obj))
                {
                    this.list.Remove(obj);
                    this.listKeys.Remove(key);
                    this.dict.Remove(key);
                }
                this.dict.Add(key, value);
                this.list.Add(value);
                this.listKeys.Add(key);
            }
        }

        public TValue At(int index)
        {
            return this.list[index];
        }

        public TKey KeyAt(int index)
        {
            return this.listKeys[index];
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public bool Contains(TKey key)
        {
            return this.dict.ContainsKey(key);
        }

        public bool ContainsKey(TKey key)
        {
            return this.dict.ContainsKey(key);
        }

        public int IndexOf(TValue val)
        {
            return this.list.IndexOf(val);
        }

        public Dictionary<TKey, TValue>.Enumerator GetDictEnumerator()
        {
            return this.dict.GetEnumerator();
        }

        public List<TValue>.Enumerator GetListEnumerator()
        {
            return this.list.GetEnumerator();
        }

        public Dictionary<TKey, TValue>.KeyCollection Keys
        {
            get
            {
                return this.dict.Keys;
            }
        }

        public Dictionary<TKey, TValue>.ValueCollection Values
        {
            get
            {
                return this.dict.Values;
            }
        }

        internal List<TValue> ValuesList
        {
            get
            {
                return this.list;
            }
        }

        internal List<TKey> KeysList
        {
            get
            {
                return this.listKeys;
            }
        }
    }

}
