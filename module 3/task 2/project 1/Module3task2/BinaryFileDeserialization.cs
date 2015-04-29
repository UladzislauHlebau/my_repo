using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Module3task2
{
    class BinaryFileDeserialization
    {
        public void DeserializeFromBinaryFile()
        {
            string BinaryFile3 = "BinaryFile3.dat";
            FileStream fs = new FileStream(BinaryFile3, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                //park.Cars = (List<Car>)formatter.Deserialize(fs);
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
    }
}
