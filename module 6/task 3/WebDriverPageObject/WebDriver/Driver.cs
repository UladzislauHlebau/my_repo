using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverPageObject.Utilities;

namespace WebDriverPageObject
{
    class Driver
    {
        private static IWebDriver driver;

        private Driver() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = CreateDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Close();
        }

        public static void QuitBrowser()
        {
            driver.Quit();
        }

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver;
            driver = new FirefoxDriver();
            return driver;
        }
        
    }
}
