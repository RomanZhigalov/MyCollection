using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    struct CompositeKey<Tkey_1, Tkey_2>
    {
        public Tkey_1 Key_1 { get; private set; }
        public Tkey_2 Key_2 { get; private set; }

        public CompositeKey(Tkey_1 key_1, Tkey_2 key_2)
        {
            if (key_1 == null)
            {
                throw new ArgumentNullException(nameof(key_1));
            }
            if (key_2 == null)
            {
                throw new ArgumentNullException(nameof(key_2));
            }
            Key_1 = key_1;
            Key_2 = key_2;
        }
    }
    class MyCollection<Tkey_1, Tkey_2, Tvalue> 
        where Tkey_1 : IComparable<Tkey_1>, IEquatable<Tkey_1> 
        where Tkey_2 : IComparable<Tkey_2>, IEquatable<Tkey_2>
        where Tvalue : IEquatable<Tvalue>
    {
        private int count;
        private List<Tkey_1> keys_1;
        private List<Tkey_2> keys_2;
        private Dictionary<CompositeKey<Tkey_1, Tkey_2>, Tvalue> values;
        public int Count { get { return count; } }
        public List<Tkey_1> Keys_1 { get { return keys_1; } }
        public List<Tkey_2> Keys_2 { get { return keys_2; } }
        public Tvalue this[Tkey_1 key_1, Tkey_2 key_2]
        {
            get
            {
                CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
                if (!values.Keys.Contains(key))
                {
                    throw new ArgumentException();
                }
                return values[key];
            }
            set
            {
                CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
                if (!values.Keys.Contains(key))
                {
                    throw new ArgumentException();
                }
                values[key] = value;
            }
        }
        public List<Tvalue> Values
        { 
            get
            {
                List<Tvalue> tvalues = new List<Tvalue>();
                foreach(Tvalue val in values.Values)
                {
                    tvalues.Add(val);
                }
                return tvalues;
            }
        }
        public MyCollection()
        {
            count = 0;
            keys_1 = new List<Tkey_1>();
            keys_2 = new List<Tkey_2>();
            values = new Dictionary<CompositeKey<Tkey_1, Tkey_2>, Tvalue>();
        }
        public void Add(Tkey_1 key_1, Tkey_2 key_2, Tvalue value)
        {
            CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
            if (values.Keys.Contains(key))
            {
                throw new ArgumentException(nameof(key));
            }
            keys_1.Add(key_1);
            keys_2.Add(key_2);
            values.Add(key, value);
            count++;
        }
        public bool Remove(Tkey_1 key_1, Tkey_2 key_2)
        {
            CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
            if (!values.Keys.Contains(key))
            {
                return false;
            }
            keys_1.Remove(key_1);
            keys_2.Remove(key_2);
            values.Remove(key);
            count--;
            return true;
        }
        public List<Tvalue> GetValues(Tkey_1 key_1)
        {
            if (!keys_1.Contains(key_1))
            {
                throw new ArgumentException(nameof(key_1));
            }
            List<Tvalue> tvalues = new List<Tvalue>();
            foreach(CompositeKey<Tkey_1, Tkey_2> key in values.Keys)
            {
                if (key.Key_1.CompareTo(key_1) == 0)
                {
                    tvalues.Add(values[new CompositeKey<Tkey_1, Tkey_2>(key.Key_1, key.Key_2)]);
                }
            }
            return tvalues;
        }
        public List<Tvalue> GetValues(Tkey_2 key_2)
        {
            if (!keys_2.Contains(key_2))
            {
                throw new ArgumentException(nameof(key_2));
            }
            List<Tvalue> tvalues = new List<Tvalue>();
            foreach (CompositeKey<Tkey_1, Tkey_2> key in values.Keys)
            {
                if (key.Key_2.CompareTo(key_2) == 0)
                {
                    tvalues.Add(values[new CompositeKey<Tkey_1, Tkey_2>(key.Key_1, key.Key_2)]);
                }
            }
            return tvalues;
        }
        public bool ContainsValue(Tvalue tvalue)
        {
            if (values.Values.Contains(tvalue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ContainsKey(Tkey_1 key_1, Tkey_2 key_2)
        {

            if (values.Keys.Contains(new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ContainsKey(Tkey_1 key_1)
        {
            if (keys_1.Contains(key_1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ContainsKey(Tkey_2 key_2)
        {
            if (keys_2.Contains(key_2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
