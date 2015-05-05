using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class Tomato : FruitVegetable
    {
        public Tomato() { }

        public Tomato(double weight, double index, string lifespan)
            : base(weight, index, lifespan)
        {
            
        }

        public override string ToString()
        {
            return "Tomato has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
