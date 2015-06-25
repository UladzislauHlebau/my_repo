using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject.Utilities
{
    public class FirefoxDriverCreator : WebDriverCreator
    {
        public override IWebDriver FactoryMethod()
        {
            FirefoxBinary binary = new FirefoxBinary("c:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile profile = new FirefoxProfile();
            IWebDriver driver = new FirefoxDriver(binary, profile);
            return driver;
        }
    }
}
