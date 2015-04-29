using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2
{
    class TextWriter
    {
        static Salad salad;
        public void WriteToTextFile()
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
                    sw.WriteLine(salad);
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
