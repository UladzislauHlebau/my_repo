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
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

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
            Console.WriteLine("Enter 7 to deserialize from XML file.");
            Console.WriteLine("Enter 8 to write to JSON using serialization.");
            Console.WriteLine("Enter 9 to show First/Last name of all the employees.");
            Console.WriteLine("Enter 0 to select rows from DB.");
            Console.WriteLine("Enter q to delete rows from DB.");
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
                case '7':
                    DeserializeFromXMLFile();
                    break;
                case '8':
                    WriteToJSONUsingSerialization();
                    break;
                case '9':
                    ConnectToDB();
                    break;
                case '0':
                    SelectFromDB();
                    break;
                case 'q':
                    DeleteRows("9");
                    break;
                case 'w':
                    StoredProcedureForProducts("Sosiski", DateTime.Now);
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

        public class SaladXML
        {

            [XmlElement("Name")]
            public string SaladName { get; set; }

            [XmlElement("CalorificValue")]
            public double Value { get; set; }

            [XmlElement("TimeToCook")]
            public DateTime Time { get; set; }
        } 


        private static void WriteToXmlLFileUsingSerialization()
        {
            TextWriter textWriter = null;

            try
            {
                SaladXML saladXML = new SaladXML();

                saladXML.SaladName = "Oliv'e";
                saladXML.Value = 600;
                saladXML.Time = DateTime.Parse("00:20:00");

                XmlSerializer serializer = new XmlSerializer(typeof(SaladXML));
    
                {
                    textWriter = new StreamWriter(@"C:\Salad.xml");
                    serializer.Serialize(textWriter, saladXML);
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
                textWriter.Close();
            }

        }

        public static void DeserializeFromXMLFile()
        {
            TextReader textReader = null;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(SaladXML));
                textReader = new StreamReader(@"C:\Salad.xml");
                SaladXML saladXML;
                saladXML = (SaladXML)deserializer.Deserialize(textReader);
                Console.WriteLine("Object has been successfully deserialized from XML file.");
                Console.ReadLine();
            }
            catch (XmlException)
            {
                Console.WriteLine("Failed to deserialize.");
            }
            finally
            {
                textReader.Close();
            }

        }

        public class SaladJSON
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int CalorificValue { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double Price { get; set; }

            public override string ToString()
            {
                return string.Format(
                "Id={0}, Name={1}, CalorificValue={2}, Price={3}", Id, Name, CalorificValue, Price);
            }

        }

        private static void WriteToJSONUsingSerialization()
        {
            SaladJSON saladJSON = new SaladJSON();
            saladJSON.Id = 01;
            saladJSON.Name = "Oliv'e";
            saladJSON.CalorificValue = 600;
            saladJSON.Price = 120.5;

            //Serialize an object to Json
            string actualJson = JsonConvert.SerializeObject(saladJSON);

            //Display serialized to json saladJSON
            Console.WriteLine(actualJson);
            Console.ReadLine();

        }

        //private static void DeserializeFromJSON
        //{
        //    string exampleJson = "{\"Id\":2013,\"FirstName\":\"Bill\",\"SecondName\":\"Marvel\",\"Payment\": 1500}";
        //    //Deserialize json string to SaladJSON class
        //    SaladJSON actualCustomer = JsonConvert.DeserializeObject<SaladJSON>(exampleJson);
        //    //Display deserialized Customer
        //    Console.WriteLine(actualCustomer);

        //}

        public static void ConnectToDB()
        {
            string cnStr = ConfigurationManager.AppSettings["cnStr"];
            // Get connection object
            using (var cn = new SqlConnection())
            {
                Console.WriteLine("Connection object --> " + cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();
                // create command object
                DbCommand cmd = new SqlCommand();
                Console.WriteLine("Command object --> " + cmd.GetType().Name);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Employees ORDER BY EmployeeID";
                //show all the employees' First and Last names
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var fn = reader["FirstName"];
                        var ln = reader["LastName"];
                        Console.WriteLine(fn + ", " + ln);
                    }
                }
                Console.ReadLine();
             }
        }

        public static void SelectFromDB()
        {
            string cnStr = ConfigurationManager.AppSettings["cnStr"];
            // Get connection object
            using (var cn = new SqlConnection())
            {
                Console.WriteLine("Connection object --> " + cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();
                DbCommand cmd = new SqlCommand();
                Console.WriteLine("Command object --> " + cmd.GetType().Name);
                cmd.Connection = cn;

                //read using DataTable
                var employees = new DataTable();
                cmd.CommandText = "Select * From Employees ORDER BY EmployeeID";
                using (var dr = cmd.ExecuteReader())
                {
                    employees.Load(dr);
                }

                foreach (DataRow row in employees.Rows)
                {
                    Console.WriteLine(
                            "-> Employee ID: {0}, Last Name: {1}, First Name: {2}, Title: {3}, City: {4}\n",
                            row["EmployeeID"],
                            row["LastName"],
                            row["FirstName"],
                            row["Title"],
                            row["City"]);
                }
                Console.ReadLine();
            }

          }

        public static int DeleteRows(string id)
        {
                string cnStr = ConfigurationManager.AppSettings["cnStr"];
                // Get connection object
                var cn = new SqlConnection();
            
                Console.WriteLine("Connection object --> " + cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();

                int numberOfAffectedRows = 0;
                string sql = string.Format("Delete FROM [Employees] where EmployeeID = '{0}'", id);
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    try
                    {
                        numberOfAffectedRows = cmd.ExecuteNonQuery();
                        
                    }
                    catch (SqlException ex)
                    {
                        var error = new Exception("Couldn't delete the employee.", ex);
                        throw error;
                    }
                }
                return numberOfAffectedRows;
        }

        private static DataTable StoredProcedureForProducts (string productName, DateTime dateAdded)
        {
            string cnStr = ConfigurationManager.AppSettings["cnStr"];
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                var newProducts = new DataTable();
                using (SqlCommand cmd = new SqlCommand("New Products", cn))
                {


                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = new SqlParameter("@ProductName", SqlDbType.NChar);
                    SqlParameter parameter1 = new SqlParameter("@DateAdded", SqlDbType.DateTime);

                    parameter.Value = productName;
                    parameter1.Value = dateAdded;
                    cmd.Parameters.Add(parameter);
                    cmd.Parameters.Add(parameter1);

                    using (var dr = cmd.ExecuteReader())
                    {
                        newProducts.Load(dr);
                    }

                    return newProducts;
                }
            }
        }
    }
} 

