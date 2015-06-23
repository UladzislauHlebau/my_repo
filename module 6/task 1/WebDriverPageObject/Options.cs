using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace WebDriverPageObject
{
    class Options
    {
          [Option('l', "login", Required = true, HelpText = "Login to acceess emailbox.")]
          public string Login { get; set; }

          [Option('p', "password", Required = true, HelpText = "Password to acceess emailbox.")]
          public string Password { get; set; }

          [Option('u', "url", Required = true, HelpText = "Here is a URL.")]
          public string Url { get; set; }

          [HelpOption]
          public string GetUsage()
          {
            // this without using CommandLine.Text
            var usage = new StringBuilder();
            usage.AppendLine("Tests are running..");
            usage.AppendLine("Issues will be reported.");
            return usage.ToString();
          }
     }

    //public class Runner
    //{
    //    static void Main(string[] args)
    //    {
    //        Options options = new Options();
    //        if (CommandLine.Parser.Default.ParseArguments(args, options))
    //        {
    //            // Values are available here
    //            var login = options.Login;
    //            var password = options.Password;
    //            var url = options.Url;
    //            Console.WriteLine("Url: {0}, Login: {1}, Password: {2}", url, login, password);
    //        }
    //    }
    //}
}
