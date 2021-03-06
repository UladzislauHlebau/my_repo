﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2.Vegetables
{
    [Serializable]
    public class Cabbage : FruitVegetable
    {
        public Cabbage() { }

        //public Cabbage(double weight, double index, string lifespan)
        //    : base(weight, index, lifespan)
        //{
        //    Console.WriteLine("Please enter lifespan for cabbage:");
        //    lifespan = Console.ReadLine();
        //}

        public Cabbage(double weight, double index, string lifespan)
        {
            this.Weight = weight;
            this.Index = index;
            this.Lifespan = lifespan;
        }

        public override string ToString()
        {
            return "Cucumber has the following weight:" + Weight + ", calorific index:" + Index + " and lifespan:" + Lifespan;
        }
    }
}
