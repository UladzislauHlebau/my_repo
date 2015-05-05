using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class Cabbage : FruitVegetable
    {
        public Cabbage() { }

        public Cabbage(double weight, double index, string lifespan)
            : base(weight, index, lifespan)
        {
            
        }

        public override string ToString()
        {
            return "Cabbage has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
