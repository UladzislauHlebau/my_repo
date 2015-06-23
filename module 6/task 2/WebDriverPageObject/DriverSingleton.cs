using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject
{
    class DriverSingleton
    {
        private static IWebDriver driver;

        private DriverSingleton()
        {
            
        }

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

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver;
            driver = new FirefoxDriver();
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Close();
            driver = null;
        }

        public static void QuitBrowser()
        {
            driver.Quit();
            driver = null;
        }

        public Boolean isElementPresent(By locator)
        {
            return driver.FindElements(locator).Count() > 0;
        }


    }
}
