using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class MailRuTest
    {
        [Test]
        public void oneCanLoginMailRu()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginToEmail loginToEmail = new LoginToEmail(driver);
            loginToEmail.canLoginEmail();
            string title = loginToEmail.getPageTitle();
            Assert.IsNotNull(title, "Title doesn't exist.");
            driver.Close();
        }

        [Test]
        public void oneCanCreateEmailAndSaveIt()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginToEmail loginToEmail = new LoginToEmail(driver);
            loginToEmail.canLoginEmail();
            loginToEmail.canCreateEmail();
            //this is a check to see if a draft has correct address
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='merrymaker12@gmail.com')]"))));

            //this is a check to see if a draft has correct subject
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='WebDriver Test')]"))));

            //this is a check to see if a draft has correct email body
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//span[(text()='Hey, this is WebDriver Test! С уважением, Vl Gl vld.gl@mail.ru')]"))));
            driver.Close();
        }

        [Test]
        public void oneCanSendEmail()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginToEmail loginToEmail = new LoginToEmail(driver);
            loginToEmail.canLoginEmail();
            loginToEmail.canCreateEmail();
            loginToEmail.canSendEmail();

            Assert.Throws<NoSuchElementException>(() => loginToEmail.findSentEmailInDrafts());
  
            driver.Close();
        }

        //[Test]
        //public void



    }
}
