using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class Potato : TuberVegetable
    {

        public Potato() { }

        public Potato(double weight, double index, string ingatheringType)
            : base(weight, index, ingatheringType)
        {
            
        }

        public override string ToString()
        {
            return "Potato has the following weight:" + Weight + ", calorific index:" + Index + " and ingathering type:" + IngatheringType;
        }
    }
}
