using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables
{
    public class TuberVegetable : Vegetable
    {
         protected string IngatheringType { get; set; }

        public TuberVegetable() { }

        public TuberVegetable(double weight, double index, string ingatheringType)
        {
            Weight = weight;
            Index = index;
            IngatheringType = ingatheringType;
        }

        public double CalorificValue()
        {
            return Weight * (Index / 80);
        }
    }
}
