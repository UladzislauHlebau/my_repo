using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables.Tuber
{
    [Serializable]
    public class Potato : TuberVegetable
    {

        public Potato() { }

        public Potato(double weight, double index, string ingatheringType)
            : base(weight, index, ingatheringType)
        {
            Console.WriteLine("Please enter ingathering type for potato:");
            ingatheringType = Console.ReadLine();
           
        }

        public override string ToString()
        {
            return "Potato has the following weight:" + Weight + ", calorific index:" + Index + " and ingathering type:" + IngatheringType;
        }
    }
}
