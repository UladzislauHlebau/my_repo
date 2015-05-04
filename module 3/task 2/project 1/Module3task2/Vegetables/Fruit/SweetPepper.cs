using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables.Fruit
{
    [Serializable]
    public class SweetPepper : FruitVegetable
    {
        public SweetPepper() { }

        public SweetPepper(double weight, double index, string lifespan)
            : base(weight, index, lifespan)
        {
            Console.WriteLine("Please enter lifespan for sweet pepper:");
            lifespan = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Sweet Pepper has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
