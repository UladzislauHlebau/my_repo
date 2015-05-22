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
        protected IWebDriver driver;

        public Page()
        {
            
        }


        public IWebDriver getDriver()
        {
            return this.driver;
        }

        public Boolean isElementPresent(By locator)
        {
            return driver.FindElements(locator).Count() > 0;
        }


    }
}
