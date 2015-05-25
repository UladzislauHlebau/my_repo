using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver
{
   public class LoginToEmail
    {
        private IWebDriver driver;

        public LoginToEmail(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void canLoginEmail()
        {
            driver.Navigate().GoToUrl("https://mail.ru/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement element = driver.FindElement(By.CssSelector("input#mailbox__login"));
            element.SendKeys("vld.gl");
            IWebElement element1 = driver.FindElement(By.CssSelector("select#mailbox__login__domain"));
            element1.Click();
            IWebElement element2 = driver.FindElement(By.XPath("//select[@id='mailbox__login__domain']/option[@value='mail.ru']"));
            element2.Click();
            IWebElement element3 = driver.FindElement(By.CssSelector("input#mailbox__password"));
            element3.SendKeys("WebDriver");
            IWebElement element4 = driver.FindElement(By.CssSelector("input#mailbox__auth__button"));
            element4.Click();

        }

        public void canCreateEmail()
        {
            IWebElement element5 = driver.FindElement(By.XPath("//span[(text()='Написать письмо')]"));
            element5.Click();

            IWebElement element6 = driver.FindElement(By.XPath("//textarea[@class='js-input compose__labels__input']"));
            element6.SendKeys("merrymaker12@gmail.com");

            IWebElement element7 = driver.FindElement(By.XPath("//input[@class='compose__header__field']"));
            element7.SendKeys("WebDriver Test");

            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[title='{#aria.rich_text_area}']")));

            IWebElement element8 = driver.FindElement(By.CssSelector("body#tinymce"));
            element8.SendKeys("Hey, this is WebDriver Test!");

            driver.SwitchTo().DefaultContent();

            IWebElement element9 = driver.FindElement(By.XPath("//span[(text()='Сохранить')]"));
            element9.Click();

            IWebElement element10 = driver.FindElement(By.XPath("//span[(text()='Черновики')]"));
            element10.Click();
        }

        public void canSendEmail()
        {
            IWebElement element11 = driver.FindElement(By.XPath("//div[(text()='merrymaker12@gmail.com')]"));
            element11.Click();

            IWebElement element12 = driver.FindElement(By.XPath("//span[@class='b-toolbar__btn__text']"));
            element12.Click();

            IWebElement element13 = driver.FindElement(By.XPath("//span[(text()='Черновики')]"));
            element13.Click();

        }

        public void findSentEmailInDrafts()
        {
            IWebElement element13 = driver.FindElement(By.XPath("//div[(text()='merrymaker12@gmail.com')]"));
        }

        public string getPageTitle()
        {
            return this.driver.Title;
        }
    }
}
