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

            People oleg = new People(4681, 876434, "Oleg", "Olegov");
            People ivan = new People(2005, 468137, "Ivan", "Ivanov");
            People sergey = new People(6575, 687845, "Sergey", "Sergeev");
            Cat barsik = new Cat("Barsik", 3);
            Cat simon = new Cat("Simon", 7);

            MyCollection<Cat, Pasport, People> col = new MyCollection<Cat, Pasport, People>();
            col.Add(barsik, oleg.Pasport, oleg);
            col.Add(simon, ivan.Pasport, ivan);
            col.Add(simon, sergey.Pasport, sergey);

            foreach (People p in col.GetValues(new Cat("Simon", 7)))
            {
                Console.WriteLine($"{p.Pasport.series} {p.Pasport.number} {p.Name} {p.Surname} \n");
            }
            Dictionary<Cat, People> dic = new Dictionary<Cat, People>();
            dic.Add(simon, ivan);
            dic.Add(simon, sergey);
            Console.ReadKey();

        }
    }
}
