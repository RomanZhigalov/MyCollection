using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            Person oleg = new Person(4681, 876434, "Oleg", "Olegov");
            Person ivan = new Person(2005, 468137, "Ivan", "Ivanov");
            Person sergey = new Person(6575, 687845, "Sergey", "Sergeev");
            Cat barsik = new Cat("Barsik", 3);
            Cat simon = new Cat("Simon", 7);
            Cat kitty = new Cat("Simon", 7);

            MyCollection<Cat, Pasport, Person> col = new MyCollection<Cat, Pasport, Person>();
            col.Add(barsik, oleg.Pasport, oleg);
            col.Add(simon, ivan.Pasport, ivan);
            col.Add(kitty, sergey.Pasport, sergey);

            foreach (Person p in col.GetValues(new Cat("Simon", 7)))
            {
                Console.WriteLine($"{p.Pasport.series} {p.Pasport.number} {p.Name} {p.Surname} \n");
            }
            Console.ReadKey();

        }
    }
}
