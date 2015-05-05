using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class SweetPepper : FruitVegetable
    {
        public SweetPepper() { }

        public SweetPepper(double weight, double index, string lifespan)
            : base(weight, index, lifespan)
        {
            
        }

        public override string ToString()
        {
            return "Sweet Pepper has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
