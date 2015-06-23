using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverPageObject
{
        public abstract class Page
        {
            public Page()
            {

            }

            public Boolean isElementPresent(By locator)
            {
                return DriverSingleton.GetDriver().FindElements(locator).Count() > 0;
            }
        }
}
