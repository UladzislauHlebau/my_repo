using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SaladCreation.Vegetables;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;

namespace SaladCreation
{
    public class Program
    {
        static Salad salad;

        public static void Main()
        {
            salad = new Salad();

            Console.WriteLine("Let's cook vegetable salad and calculate its calorific value.");

            salad.Create();

            Console.WriteLine(salad);

            MenuCreate();

            SaladCreationMenu();

            Console.ReadLine();
        }

        private static void MenuCreate()
        {
            Console.WriteLine("\nPlease select operation and click Enter: ");
            Console.WriteLine("Enter 1 to write to binary file.");
            Console.WriteLine("Enter 2 to write to text file.");
            Console.WriteLine("Enter 3 to read from text file.");
            Console.WriteLine("Enter 4 to write to binary file using serialization.");
            Console.WriteLine("Enter 5 to deserialize from binary file.");
            Console.WriteLine("Enter 6 to write to XML file using serialization.");
            Console.WriteLine("Press Enter to exit.");
        }

        public static void SaladCreationMenu()
        {

            int MenuValue = Console.Read();

            switch (MenuValue)
            {
                case '1':
                    WriteToBinaryFile();
                    break;
                case '2':
                    WriteToTextFile();
                    break;
                case '3':
                    ReadTextFromFile();
                    break;
                case '4':
                    WriteToBinaryFileUsingSerialization();
                    break;
                case '5':
                    DeserializeFromBinaryFile();
                    break;
                case '6':
                    WriteToXmlLFileUsingSerialization();
                    break;
                default:
                    Console.WriteLine("Please retry as such operation doesn't exist.");
                    break;
            }

        }

        public static void WriteToBinaryFile()
        {
            string BinaryFile = "BinaryFile.dat";
            FileStream fs = null;
            try
            {
                // New file stream creation
                using (fs = new FileStream(BinaryFile, FileMode.Append, FileAccess.Write))
                // Create StreamWriter object
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(salad.ToString());
                    Console.WriteLine("Objects were successfully added to a binary file.\n");
                    Console.ReadLine();
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error while writing to a binary file.");
            }
            finally
            {
                fs.Dispose();
            }
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
                    sw.WriteLine(salad);
                    Console.WriteLine("Objects were successfully added to a text file.\n");
                    Console.ReadLine();
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

        public static void ReadTextFromFile()
        {
            string NewFile = "FileToReadFrom.txt";
            // Determine whether NewFile is a file
            if (File.Exists(NewFile))
            { // Obtain reader and file contents
                try
                {
                    StreamReader stream = new StreamReader(NewFile);
                    string inputString = stream.ReadToEnd();
                    Console.WriteLine(inputString);
                    Console.ReadLine();
                }
                // Handle exception if StreamReader is unavailable
                catch (IOException)
                {
                    Console.WriteLine("File error.");
                }
            }
            else
            {  // Notify user that neither file nor directory exists
                Console.WriteLine(NewFile + " does not exist.");
            }

        }

        public static void WriteToBinaryFileUsingSerialization()
        {
            string BinaryFile2 = "BinaryFile2.dat";
            FileStream fs = null;
            try
            {
                // New file stream creation
                fs = new FileStream(BinaryFile2, FileMode.Append, FileAccess.Write);
                // Create BinaryFormatter object
                BinaryFormatter formatter = new BinaryFormatter();
                {
                    // Write your string to binary file
                    formatter.Serialize(fs, salad.SaladCollection);
                    Console.WriteLine("Collection has been serialized.");
                    Console.ReadLine();
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error while object serialization.");
            }
            finally
            {
                fs.Dispose();
            }
        }

        public static void DeserializeFromBinaryFile()
        {
            string BinaryFileName = "BinaryFile3.dat";
            FileStream fs = new FileStream(BinaryFileName, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                salad.SaladCollection = (List<Vegetable>)formatter.Deserialize(fs);
                Console.WriteLine("Collection has been deserialized.");
                Console.ReadLine();
            }

            catch (IOException)
            {
                Console.WriteLine("Failed to deserialize.");
            }
            finally
            {
                fs.Close();
            }

        }

        private static void WriteToXmlLFileUsingSerialization()
        {
            string FileName = "Salad.xml";
            TextWriter tw = null;

            try
            {
                tw = new StreamWriter(FileName);
                XmlSerializer serializer = new XmlSerializer(typeof(Salad), new Type[]
                { 
                    typeof(Cabbage), typeof(Cucumber), typeof(SweetPepper), typeof(Tomato), typeof(Potato) 
                });
                {
                    serializer.Serialize(tw, salad);
                    Console.WriteLine("Object has been serialized.");
                    Console.ReadLine();
                }
            }
            catch (XmlException)
            {
                Console.WriteLine("Failed to serialize to XML.");
            }

            finally
            {
                    tw.Close();
            }

        }

    }
} 

