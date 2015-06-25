using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject.Utilities
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        //public static string driverPath = "d:\\chromedriver_win32";
        //public static string driverExecutable = "chromedriver.exe";
       
        public override IWebDriver FactoryMethod()
        {
            ChromeOptions options = new ChromeOptions();
            //some options can be assigned here
            IWebDriver driver = new ChromeDriver(options);
            return driver;
        }
    }
}
