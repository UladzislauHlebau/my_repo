using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3__task_2.Vegetables.Fruit;
using Module_3__task_2.Vegetables.Tuber;

namespace Module_3__task_2
{
    public class Program
    {
        private static string Lifespan;
        private static string IngatheringType;
        public static void Main()
        {
            
            Console.WriteLine("Let's cook vegetable salad and calculate its calorific value.");
            Console.WriteLine("\nPlease enter tomato's weight:");

            double tomatoWeight = double.Parse(Console.ReadLine());
            
            var tomato = new Tomato(tomatoWeight, 15, Lifespan);

            Console.WriteLine("\nPlease enter potato's weight:");

            double potatoWeight = double.Parse(Console.ReadLine());

            var potato = new Potato(potatoWeight, 60, IngatheringType);

            Console.WriteLine("\nPlease enter cucumber's weight:");

            double cucumberWeight = double.Parse(Console.ReadLine());

            var cucumber = new Cucumber(cucumberWeight, 15, Lifespan);

            Console.WriteLine("\nPlease enter sweet pepper's weight:");

            double sweetpepperWeight = double.Parse(Console.ReadLine());

            var sweetpepper = new SweetPepper(sweetpepperWeight, 19, Lifespan);

            Console.WriteLine("\nPlease enter cabbage's weight:");

            double cabbageWeight = double.Parse(Console.ReadLine());

            var cabbage = new Cabbage(cabbageWeight, 23, Lifespan);

            var salad = new Salad();
            salad.Add(tomato);
            salad.Add(potato);
            salad.Add(cucumber);
            salad.Add(sweetpepper);
            salad.Add(cabbage);

            //totalCalorificValue = CalorificValue;

            Console.WriteLine(salad);
            //foreach(var vegetable in salad.Vegetables)
            //{
            //    Console.WriteLine(vegetable);
            //}

            salad.Sort();
            Console.WriteLine("\nHere is the list of vegetables in our salad sorted by calorific value:");
            foreach (var vegetable in salad.Vegetables)
            {
                Console.WriteLine(vegetable);
            }
            Console.WriteLine("\nPlease enter 'exit' and press 'Enter' button to quit.");
            string exit = Console.ReadLine();

            if (exit == "exit")
            {
                Environment.Exit(0);
            }
            else
            {
            Console.WriteLine("\nPlease enter 'exit' and press 'Enter' to quit.");
            }
            Console.ReadLine();

        }
    }
}
