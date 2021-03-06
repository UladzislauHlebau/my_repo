﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables
{
    [Serializable]
    public class Salad
    {
        //private List<Vegetable> _vegetables = new List<Vegetable>();
        //public List<Vegetable> Vegetables
        //{
        //    get
        //    {
        //        return _vegetables;
        //    }
        //}


        //public void Add(Vegetable vegetable)
        //{
        //    _vegetables.Add(vegetable);
        //}

        public List<Salad> SaladCollection = new List<Salad>();

        public void Create()
        {
            Salad cabbage = new Cabbage(400, 15, "hey");
            SaladCollection.Add(cabbage);

            Salad cucumber = new Cucumber(400, 15, "hey");
            SaladCollection.Add(cucumber);

            Salad sweetpepper = new SweetPepper(400, 15, "hey");
            SaladCollection.Add(sweetpepper);

            Salad tomato = new Tomato(400, 15, "hey");
            SaladCollection.Add(tomato);

            Salad potato = new Potato(400, 15, "hey");
            SaladCollection.Add(potato);
        }

        //public void Sort()
        //{
        //    SaladCollection.Sort(new CalorificComparer());
        //}

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

    //public class CalorificComparer : IComparer<Salad>
    //{
    //    public int Compare(Salad x, Salad y)
    //    {
    //        return x.CalorificValue().CompareTo(y.CalorificValue());
    //    }
    //}
}
