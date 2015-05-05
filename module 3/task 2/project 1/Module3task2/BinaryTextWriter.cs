using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2
{
    class BinaryTextWriter
    {
        private Salad salad;
        public void WriteToBinaryFile()
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
                    // Write your string to binary file
                    //salad = new Salad();
                    //salad.Add(new Tomato());
                    //salad.Add(new Cucumber());
                    //salad.Add(new Cabbage());
                    //salad.Add(new SweetPepper());
                    //salad.Add(new Potato());

                    bw.Write(salad.ToString());
                    Console.WriteLine("Objects were successfully added to a binary file.\n");
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
    }
}
