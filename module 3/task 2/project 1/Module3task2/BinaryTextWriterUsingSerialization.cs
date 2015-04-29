using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2
{
    class BinaryTextWriterUsingSerialization
    {
        static Salad salad;
        public void WriteToBinaryFileUsingSerialization()
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
                    formatter.Serialize(fs, salad);
                    Console.WriteLine("Object has been serialized.");
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
    }
}
