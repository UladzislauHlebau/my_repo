using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject
{
    public class LoginPage : Page
    {
        private string URL = "https://mail.ru/";
        private string LOGIN = "vld.gl";
        private string PASSWORD = "WebDriver";


        [FindsBy(How = How.CssSelector, Using = "input#mailbox__login")]
        public IWebElement loginField;

        [FindsBy(How = How.CssSelector, Using = "input#mailbox__password")]
        public IWebElement passwordField;

        [FindsBy(How = How.CssSelector, Using = "input#mailbox__auth__button")]
        public IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void openPage()
        {
            this.driver.Navigate().GoToUrl(URL);
        }

        public HomePage loginToEmail()
        {
            loginField.SendKeys(LOGIN);
            passwordField.SendKeys(PASSWORD);
            loginButton.Click();
            return new HomePage(this.driver);
        }

    }
}
