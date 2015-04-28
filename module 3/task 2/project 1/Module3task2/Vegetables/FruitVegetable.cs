using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables
{
   public class FruitVegetable : Vegetable
    {
        protected string Lifespan { get; set; }

        public FruitVegetable() { }

        public FruitVegetable(double weight, double index, string lifespan)
        {
            Weight = weight;
            Index = index;
            Lifespan = lifespan;
        }

        public double CalorificValue()
        {
            return Weight * (Index / 90);
        }
    }
}
