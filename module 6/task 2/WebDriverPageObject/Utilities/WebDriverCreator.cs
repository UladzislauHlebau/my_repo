using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject.Utilities
{
    public abstract class WebDriverCreator
    {
        public abstract IWebDriver FactoryMethod();
    }
}
