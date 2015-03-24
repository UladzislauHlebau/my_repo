using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] initialarray = new string [10];
            Console.WriteLine("Please enter 10 strings:");

            for (int i = 0; initialarray.Length > i; i++)
            {
                initialarray [i] = Console.ReadLine();
            }
            Console.WriteLine("\nArray with 10 strings:");

            foreach (string val in initialarray)
            {
                Console.WriteLine("{0}", val);  
            }

            string [] reversedStringArray = new string [initialarray.Length];
            Console.WriteLine("\nReversed list:");

            for (int i = 0; i < initialarray.Length; i++)
            {
                reversedStringArray [i] = initialarray [initialarray.Length - i - 1];
                Console.WriteLine(reversedStringArray [i]);                 
            }
            Console.ReadKey();
        }
    }
}