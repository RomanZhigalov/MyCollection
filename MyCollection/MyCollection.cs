using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCollection
{
    /// <summary>
    /// Composite key (Tkey_1, Tkey_2) struct
    /// </summary>
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
    /// <summary>
    /// This class contains values(Tvalue) with composite key (Tkey_1, Tkey_2)
    /// Key_1, Key_2 and Value shoud implement IEquatable, which provides a correct camparison
    /// </summary>
    class MyCollection<Tkey_1, Tkey_2, Tvalue> 
        where Tkey_1 : IEquatable<Tkey_1> 
        where Tkey_2 : IEquatable<Tkey_2>
        where Tvalue : IEquatable<Tvalue>
    {
        private int count;
        private List<Tkey_1> keys_1;
        private List<Tkey_2> keys_2;
        private Dictionary<CompositeKey<Tkey_1, Tkey_2>, Tvalue> values;

        /// <returns>
        /// Gets number of items in the collection
        /// </returns>
        public int Count { get { return count; } }

        /// <returns>
        /// Get a collection containing Keys_1 in the Collection(Tkey_1, Tkey_2, Tvalue)
        /// </returns>
        public List<Tkey_1> Keys_1 { get { return keys_1; } }

        /// <returns>
        /// Get a collection containing Keys_2 in the Collection(Tkey_1, Tkey_2, Tvalue)
        /// </returns>
        public List<Tkey_2> Keys_2 { get { return keys_2; } }

        /// <returns>
        /// The value associated with the specified key.
        /// If the specified key is not found, a get operation throws a System.Collections.Generic.KeyNotFoundException,
        /// and a set operation creates a new element with the specified key.
        /// </returns>
        public Tvalue this[Tkey_1 key_1, Tkey_2 key_2]
        {
            get
            {
                CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
                if (!values.Keys.Contains(key))
                {
                    throw new KeyNotFoundException();
                }
                return values[key];
            }
            set
            {
                CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
                if (!values.Keys.Contains(key))
                {
                    throw new KeyNotFoundException();
                }
                values[key] = value;
            }
        }

        /// <returns>
        /// Gets a collection containing the values in the Collection(Tkey_1, Tkey_2, Tvalue)
        /// </returns>
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

        /// <summary>
        ///Adds the specified composite key and value to the Collection(Tkey_1, Tkey_2, Tvalue).
        /// </summary>
        public void Add(Tkey_1 key_1, Tkey_2 key_2, Tvalue value)
        {
            CompositeKey<Tkey_1, Tkey_2> key = new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2);
            if (values.Keys.Contains(key))
            {
                throw new ArgumentException("This key is already exists");
            }
            keys_1.Add(key_1);
            keys_2.Add(key_2);
            values.Add(key, value);
            count++;
        }

        /// <summary>
        /// Removes the value with the specified key from the Collection(Tkey_1, Tkey_2, Tvalue>)
        /// </summary>
        /// <returns>
        /// true - if the element is successfully found and removed; if elemet not found - false.
        /// </returns>
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

        /// <returns>
        /// The collection associated with the one part of composite key. 
        /// If the specified key is not found, a get operation throws a System.Collections.Generic.KeyNotFoundException.
        /// </returns>
        public List<Tvalue> GetValues(Tkey_1 key_1)
        {
            if (!keys_1.Contains(key_1))
            {
                throw new KeyNotFoundException();
            }
            List<Tvalue> tvalues = new List<Tvalue>();
            foreach(CompositeKey<Tkey_1, Tkey_2> key in values.Keys)
            {
                if (key.Key_1.Equals(key_1))
                {
                    tvalues.Add(values[new CompositeKey<Tkey_1, Tkey_2>(key.Key_1, key.Key_2)]);
                }
            }
            return tvalues;
        }

        /// <returns>
        /// The collection associated with the one part of composite key.
        /// If the specified key is not found, a get operation throws a System.Collections.Generic.KeyNotFoundException.
        /// </returns>
        public List<Tvalue> GetValues(Tkey_2 key_2)
        {
            if (!keys_2.Contains(key_2))
            {
                throw new KeyNotFoundException();
            }
            List<Tvalue> tvalues = new List<Tvalue>();
            foreach (CompositeKey<Tkey_1, Tkey_2> key in values.Keys)
            {
                if (key.Key_2.Equals(key_2))
                {
                    tvalues.Add(values[new CompositeKey<Tkey_1, Tkey_2>(key.Key_1, key.Key_2)]);
                }
            }
            return tvalues;
        }

        /// <returns>
        /// true if the Collection(Tkey_1, Tkey_2, Tvalue) contains a value; otherwise, false.
        /// </returns>
        public bool ContainsValue(Tvalue tvalue)
        {
            return values.ContainsValue(tvalue);
        }

        /// <returns>
        /// true if the Collection(Tkey_1, Tkey_2, Tvalue) contains an element with
        /// the specified composite key (Tkey_1, Tkey_2); otherwise, false.
        /// </returns>
        public bool ContainsKey(Tkey_1 key_1, Tkey_2 key_2)
        {

            return values.ContainsKey(new CompositeKey<Tkey_1, Tkey_2>(key_1, key_2));
        }

        /// <returns>
        /// true if the Collection(Tkey_1, Tkey_2, Tvalue) contains an element with
        /// the part of composite key (Tkey_1); otherwise, false.
        /// </returns>
        public bool ContainsKey(Tkey_1 key_1)
        {
            return Keys_1.Contains(key_1);
        }
 
        /// <returns>
        /// true if the Collection(Tkey_1, Tkey_2, Tvalue) contains an element with
        /// the part of composite key (Tkey_2); otherwise, false.
        /// </returns>
        public bool ContainsKey(Tkey_2 key_2)
        {
            return Keys_2.Contains(key_2);
        }
    }
}
