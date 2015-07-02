using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject.Utilities
{
    public class Decorator : IWebDriver
    {
        protected IWebDriver driver;

        public Decorator(IWebDriver driver)
        {
            this.driver = driver;
        }

        private void WriteToTextFile(string logs)
        {
            string fileName = "Loging.txt";

            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(DateTime.Now + "\t");
                    writer.WriteLine(logs);
                    writer.Close();
                }
            }
        }

        public void Close()
        {
            driver.Close();
            WriteToTextFile("Closing driver...");
        }

        public string CurrentWindowHandle
        {
            get { return driver.CurrentWindowHandle; }
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return driver.Navigate();
        }

        public string PageSource
        {
            get { return driver.PageSource; }
        }

        public void Quit()
        {
            driver.Quit();
            WriteToTextFile("Quitting driver...");
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public string Title
        {
            get { return driver.Title; }
        }

        public string Url
        {
            get
            {
                WriteToTextFile("URL " + driver.Url);
                return driver.Url;
            }
            set
            {
                driver.Url.ToString();
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<string> WindowHandles
        {
            get { return driver.WindowHandles; }
        }

        public IWebElement FindElement(By by)
        {
            WriteToTextFile("Searching for element with the following locator: " + by);
            return driver.FindElement(by);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            WriteToTextFile("Searching for elements with the following locator: " + by);
            return driver.FindElements(by);
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
