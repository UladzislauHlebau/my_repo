using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladCreation.Vegetables
{
    [Serializable]
    public class TuberVegetable : Vegetable
    {
        public string IngatheringType { get; set; }

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
