﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables
{
    public class Potato : Vegetable
    {
        public Potato(double weight, double index)
            :base(weight, index)
        {
        }

        public override string ToString()
        {
            return "Potato";
        }
    }
}
