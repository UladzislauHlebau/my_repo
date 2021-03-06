﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2
{
    [Serializable]
    public abstract class Vegetable
    {
        protected double Weight;
        protected double Index;

        public Vegetable() { }

        public Vegetable(double weight, double index)
        {
            Weight = weight;
            Index = index;
        }

        public double CalorificValue()
        {
            return Weight * (Index / 100);
        }
    }
}
