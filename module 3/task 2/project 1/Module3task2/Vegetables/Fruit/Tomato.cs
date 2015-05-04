using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables.Fruit
{
    [Serializable]
    public class Tomato : FruitVegetable
    {
        public Tomato() { }

        public Tomato(double weight, double index, string lifespan)
            : base(weight, index, lifespan)
        {
            Console.WriteLine("Please enter lifespan for tomato:");
            lifespan = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Tomato has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
