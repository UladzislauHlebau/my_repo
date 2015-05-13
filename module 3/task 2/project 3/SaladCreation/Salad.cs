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

        public void Sort()
        {
            SaladCollection.Sort(new CalorificComparer());
        }

        //public void TotalCalorificValue
        //{
        //    return CalorificValue(_vegetables);
        //}

        public void Add(Vegetable v)
        {
            if(SaladCollection.Contains(v))
                throw new Exception();
            SaladCollection.Add(v);
        }

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
