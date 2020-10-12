using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Cat : IEquatable<Cat>
    {
        public string Name { get;  private set; }
        public int Age { get; private set; }
        public Cat (string name, int age)
        {
            Name = name;
            Age = age;
        }

        public bool Equals(Cat other)
        {
            if (this.Name == other.Name || this.Age == other.Age)
            {
                return true;
            }
            return false;
        }
    }
}
