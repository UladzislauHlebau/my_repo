using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Module_3__task_2
{
    public class Program
    {
        static Salad salad;

        private static void MenuCreate()
        {
            Console.WriteLine("Please select operation and click Enter: ");
            Console.WriteLine("Enter 1 to write to binary file.");
            Console.WriteLine("Enter 2 to write to text file file.");
            Console.WriteLine("Enter 3 to read from text file.");
            Console.WriteLine("Enter 4 to write to binary file using serialization.");
        }

        //public static void SaladCreation()
        //{
        //    int MenuValue = Console.Read();
        
        //    switch (MenuValue)
        //    {
        //        case '1':
        //            BinaryTextWriter bt = new BinaryTextWriter();
        //            bt.WriteToBinaryFile();
        //            break;
        //        case '2':
        //            //TextWriter wt = new TextWriter();
        //            WriteToTextFile();
        //            break;
        //        case '3':
        //            TextReader tr = new TextReader();
        //            tr.ReadTextFromFile();
        //            break;
        //        case '4':
        //            BinaryTextWriterUsingSerialization btw = new BinaryTextWriterUsingSerialization();
        //            btw.WriteToBinaryFileUsingSerialization();
        //            break;
        //     default:
        //            Console.WriteLine("Such an operation doesn't exist, please retry.");
        //            break;
        //    }
        //}
        
        public static void Main()
        {
            Console.WriteLine("Let's cook vegetable salad and calculate its calorific value.");

            salad.Create();

            //Console.WriteLine("\nPlease enter tomato's weight:");

            //double tomatoWeight = double.Parse(Console.ReadLine());
        
            //var tomato = new Tomato(tomatoWeight, 15, Lifespan);

            //Console.WriteLine("\nPlease enter potato's weight:");

            //double potatoWeight = double.Parse(Console.ReadLine());

            //var potato = new Potato(potatoWeight, 60, IngatheringType);

            //Console.WriteLine("\nPlease enter cucumber's weight:");

            //double cucumberWeight = double.Parse(Console.ReadLine());

            //var cucumber = new Cucumber(cucumberWeight, 15, Lifespan);

            //Console.WriteLine("\nPlease enter sweet pepper's weight:");

            //double sweetpepperWeight = double.Parse(Console.ReadLine());

            //var sweetpepper = new SweetPepper(sweetpepperWeight, 19, Lifespan);

            //Console.WriteLine("\nPlease enter cabbage's weight:");

            //double cabbageWeight = double.Parse(Console.ReadLine());

            //var cabbage = new Cabbage(cabbageWeight, 23, Lifespan);

            //var salad = new Salad();
            //salad.Add(tomato);
            //salad.Add(potato);
            //salad.Add(cucumber);
            //salad.Add(sweetpepper);
            //salad.Add(cabbage);

           

            Console.WriteLine(salad);

            //salad.Sort();
            //Console.WriteLine("\nHere is the list of vegetables in our salad sorted by calorific value:");
            //foreach (var vegetable in salad.Vegetables)
            //{
            //    Console.WriteLine(vegetable);
            //}

            
            

            //Console.WriteLine("\nPlease enter 'exit' and press 'Enter' button to quit.");
            //string exit = Console.ReadLine();

            //if (exit == "exit")
            //{
            //    Environment.Exit(0);
            //}
            //else
            //{
            //Console.WriteLine("\nPlease enter 'exit' and press 'Enter' to quit.");
            //}

            MenuCreate();
            SaladCreation();

           Console.ReadLine();

        }
        public static void WriteToTextFile()
        {
            FileStream fs = null;
            try
            {
                // Open file for writing by its full path
                using (fs = new FileStream("C:/TextFileToWriteTo.txt", FileMode.Append, FileAccess.Write))
                // Create StreamWriter object
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    // Write your string to file
                    //salad = new Salad();
                    //salad.Add(new Tomato());
                    //salad.Add(new Cucumber());
                    //salad.Add(new Cabbage());
                    //salad.Add(new SweetPepper());
                    //salad.Add(new Potato());
                    sw.WriteLine(salad);
                    Console.WriteLine("Written to text file.");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File error.");
            }
            finally
            {
                fs.Dispose();
            }
        }
    }
}
