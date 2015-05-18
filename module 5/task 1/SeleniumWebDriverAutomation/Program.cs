using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebDriverAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://mail.ru/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement element = driver.FindElement(By.CssSelector("input#mailbox__login"));
            element.Click();
            element.SendKeys("vld.gl");
            IWebElement element1 = driver.FindElement(By.CssSelector("select#mailbox__login__domain"));
            element1.Click();
            IWebElement element2 = driver.FindElement(By.XPath("//select[@id='mailbox__login__domain']/option[@value='mail.ru']"));
            element2.Click();
            IWebElement element3 = driver.FindElement(By.CssSelector("input#mailbox__password"));
            element3.Click();
            element3.SendKeys("WebDriver");
            IWebElement element4 = driver.FindElement(By.CssSelector("input#mailbox__auth__button"));
            element4.Click();

            //this is a check to see if login is successful
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//i[(text()='vld.gl@mail.ru')]"))));

            //this element is found by this xpath from time to time, that's why i changed it
            //IWebElement element5 = driver.FindElement(By.XPath("//span[@class='b-toolbar__btn__text b-toolbar__btn__text_pad']"));
            //element5.Click();

            IWebElement element5 = driver.FindElement(By.XPath("//span[(text()='Написать письмо')]"));
            element5.Click();

            IWebElement element6 = driver.FindElement(By.XPath("//textarea[@class='js-input compose__labels__input']"));
            element6.Click();
            element6.SendKeys("merrymaker12@gmail.com");
            IWebElement element7 = driver.FindElement(By.XPath("//input[@class='compose__header__field']"));
            element7.Click();
            element7.SendKeys("WebDriver Test");

            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[title='{#aria.rich_text_area}']")));

            IWebElement element8 = driver.FindElement(By.CssSelector("body#tinymce"));
            element8.Click();
            element8.SendKeys("Hey, this is WebDriver Test!");

            driver.SwitchTo().DefaultContent();

            IWebElement element9 = driver.FindElement(By.XPath("//span[(text()='Сохранить')]"));
            element9.Click();

            IWebElement element10 = driver.FindElement(By.XPath("//span[(text()='Черновики')]"));
            element10.Click();

            //this is a check to see if a draft has correct address
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='merrymaker12@gmail.com')]"))));

            //this is a check to see if a draft has correct subject
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='WebDriver Test')]"))));

            //this is a check to see if a draft has correct email body
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//span[(text()='Hey, this is WebDriver Test! С уважением, Vl Gl vld.gl@mail.ru')]"))));

            IWebElement element11 = driver.FindElement(By.XPath("//div[(text()='merrymaker12@gmail.com')]"));
            element11.Click();

            IWebElement element12 = driver.FindElement(By.XPath("//span[@class='b-toolbar__btn__text']"));
            element12.Click();

            IWebElement element13 = driver.FindElement(By.XPath("//span[(text()='Черновики')]"));
            element13.Click();

            IWebElement wdr = null;

            //this block checks whether email has been sent or not
            try
            {
                wdr = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='merrymaker12@gmail.com')]"))));
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                Console.WriteLine("Email has been sent.");
            }

            IWebElement element14 = driver.FindElement(By.XPath("//span[(text()='Отправленные')]"));
            element14.Click();

            //this is a check to see if a draft is in 'Sent' folder
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='merrymaker12@gmail.com')]"))));

            IWebElement element15 = driver.FindElement(By.CssSelector("a#PH_logoutLink"));
            element15.Click();

            //driver.Quit();
        }
    }
}
