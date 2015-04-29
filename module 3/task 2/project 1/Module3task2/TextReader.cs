using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3__task_2
{
    public class TextReader
    {
        public void ReadTextFromFile()
        {
            string NewFile = "FileToFeadFrom.txt";
            // Determine whether NewFile is a file
            if (File.Exists(NewFile))
            { // Obtain reader and file contents
                try
                {
                    StreamReader stream = new StreamReader(NewFile);
                    string inputString = stream.ReadToEnd();
                    Console.WriteLine(inputString);
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
    }
}
