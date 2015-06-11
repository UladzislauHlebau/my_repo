using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject
{
    public abstract class Page
    {
        private IWebDriver driver;

        public IWebDriver GetDriver
        {           
            get
            {
                return driver;
            }
        }

        public Boolean IsElementPresent(By locator)
        {
            return driver.FindElements(locator).Count() > 0;
        }


    }
}
