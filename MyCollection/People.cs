using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    struct Pasport : IEquatable<Pasport>
    {
        internal int series;
        internal int number;
        public Pasport(int series, int number)
        {
            this.series = series;
            this.number = number;
        }
        public bool Equals(Pasport other)
        {
            if (this.number == other.number || this.series == other.series)
            {
                return true;
            }
            return false;
        }
    }
    class People : IEquatable<People>
    {
        private Pasport pasport;
        public Pasport Pasport { get { return pasport; } }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public People (int pasportSeries, int pasportNumber, string name, string surname)
        {
            this.pasport.series = pasportSeries;
            this.pasport.number = pasportNumber;
            Name = name;
            Surname = surname;
        }
        public bool Equals(People other)
        {
            if (this.Pasport.Equals(other.pasport) ||
                this.Name == other.Name ||
                this.Surname == other.Surname)
            {
                return true;
            }
            return false;
        }
    }
}
