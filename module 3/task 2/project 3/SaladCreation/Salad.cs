using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaladCreation.Vegetables;

namespace SaladCreation
{
    [Serializable]
    public class Salad
    {
        public List<Vegetable> SaladCollection = new List<Vegetable>();

        public void Create()
        {
            Vegetable cabbage = new Cabbage(100, 24, "1 year");
            SaladCollection.Add(cabbage);

            Vegetable cucumber = new Cucumber(50, 15, "1 year");
            SaladCollection.Add(cucumber);

            Vegetable sweetpepper = new SweetPepper(100, 50, "1 year");
            SaladCollection.Add(sweetpepper);

            Vegetable tomato = new Tomato(150, 25, "1 year");
            SaladCollection.Add(tomato);

            Vegetable potato = new Potato(200, 45, "Greenhouse type");
            SaladCollection.Add(potato);
        }

        public void Sort()
        {
            SaladCollection.Sort(new CalorificComparer());
        }

        //public void TotalCalorificValue
        //{
        //    return CalorificValue(_vegetables);
        //}



        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Salad contains: \n");
            for (int i = 0; i < SaladCollection.Count; i++)
            {
                result.Append(SaladCollection[i]);

                if (i != SaladCollection.Count - 1)
                {
                    result.Append(";\n");
                }
                else
                {
                    result.Append(".");
                }
            }
            return result.ToString();
        }
    }

    public class CalorificComparer : IComparer<Vegetable>
    {
        public int Compare(Vegetable x, Vegetable y)
        {
            return x.CalorificValue().CompareTo(y.CalorificValue());
        }
    }
}
