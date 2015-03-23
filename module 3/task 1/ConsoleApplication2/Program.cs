using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Calc
    {
        static void Main(string[] args)
        {


            float x = 0;
            float y = 0;
    
           while (x != null && y != null)
           {
            
            Console.WriteLine("\nPlease enter the first number (float) and press 'Enter': ");
             x = float.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease enter the second number (float) and press 'Enter': ");
             y = float.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter 1-for addition operation, 2-for substraction, 3-for multiplication, 4-for division.");
            string b = Console.ReadLine();
            int a = Convert.ToInt32(b);

            switch (a)
            {
                case 1:
                    {
                        Console.WriteLine("\nResult of addition: {0}", x + y); break;
                    }
                case 2: 
                    {
                        Console.WriteLine("\nResult of substraction: {0}", x - y); break;
                    }
                case 3: 
                    {
                        Console.WriteLine("\nResult of multiplication: {0}", x * y); break;
                    }
                case 4: 
                    {
                        Console.WriteLine("\nResult of division: {0}", x / y); break;
                    }

                default: Console.WriteLine("\nSuch an operation doesn't exist, please retry."); break;
            }
           }
            Console.ReadKey();
        }         
    }

}
 