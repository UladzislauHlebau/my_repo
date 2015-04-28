using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3__task_2.Vegetables;

namespace Module_3__task_2
{
    public class Salad
    {
        private List<Vegetable> _vegetables = new List<Vegetable>();
        public List<Vegetable> Vegetables
        {
            get
            {
                return _vegetables;
            }
        }

        //public List<Vegetable> Vegetable()
        //{
        //    return _vegetables;
        //}

        public void Add(Vegetable vegetable)
        {
            _vegetables.Add(vegetable);
        }

        public void Sort()
        {
            _vegetables.Sort(new CalorificComparer());
        }

        //public void TotalCalorificValue
        //{
        //    return CalorificValue(_vegetables);
        //}

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Salad contains: \n");
            for (int i = 0; i < _vegetables.Count; i++)
            {
                result.Append(_vegetables[i]);

                if (i != _vegetables.Count - 1)
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
