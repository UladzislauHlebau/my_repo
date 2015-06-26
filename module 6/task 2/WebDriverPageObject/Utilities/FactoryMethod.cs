using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject.Utilities
{
    public interface IFactoryMethod
    {
      void DriverInstance();
    }

    public class FirefoxDriverInstance : IFactoryMethod
    {
        public void DriverInstance()
        {
            FirefoxBinary binary = new FirefoxBinary("c:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            FirefoxProfile profile = new FirefoxProfile();
            IWebDriver driver = new FirefoxDriver(binary, profile);
        }
    }

    public class ChromeDriverInstance : IFactoryMethod
    {
        public void DriverInstance()
        {
            ChromeOptions options = new ChromeOptions();
            //some options can be assigned here
            IWebDriver driver = new ChromeDriver(options);
        }
    }

    public abstract class DriverCreator
    {
        public abstract IFactoryMethod FactoryMethod();
    }

    public class FirefoxDriverCreator : DriverCreator
    {
        public override IFactoryMethod FactoryMethod()
        {
            return new FirefoxDriverInstance();
        }
    }

    public class ChromeDriverCreator : DriverCreator
    {
        public override IFactoryMethod FactoryMethod()
        {
            return new ChromeDriverInstance();
        }
    }
}
