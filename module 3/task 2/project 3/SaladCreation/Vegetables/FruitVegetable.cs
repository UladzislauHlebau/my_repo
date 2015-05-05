using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class FruitVegetable : Vegetable
    {
        public string Lifespan { get; set; }

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
