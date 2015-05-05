using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class Cucumber : FruitVegetable
    {
        public Cucumber() { }

        public Cucumber(double weight, double index, string lifespan)
            : base(weight, index, lifespan)
        {
            
        }

        public override string ToString()
        {
            return "Cucumber has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
