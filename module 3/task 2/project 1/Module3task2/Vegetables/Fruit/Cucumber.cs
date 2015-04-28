using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables.Fruit
{
    public class Cucumber : FruitVegetable
    {
        public Cucumber() { }

        public Cucumber(double weight, double index, string Lifespan)
            : base(weight, index, Lifespan)
        {
            Console.WriteLine("Please enter lifespan for cucumber:");
            string lifespan = Console.ReadLine();
            lifespan = Lifespan;
        }

        public override string ToString()
        {
            return "Cucumber has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
