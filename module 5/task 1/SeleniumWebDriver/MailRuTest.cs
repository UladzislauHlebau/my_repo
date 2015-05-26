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
        IWebDriver driver;
        [TestFixtureSetUp]
        public void toRunDriver()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TestFixtureTearDown]
        public void toCloseDriver()
        {
            driver.Close();
        }
       

        [Test]
        public void oneCanLoginMailRu()
        {
            
            LoginToEmail loginToEmail = new LoginToEmail(driver);
            loginToEmail.canLoginEmail();
            string title = loginToEmail.getPageTitle();
            Assert.IsNotNull(title, "Title doesn't exist.");
            driver.Close();
        }

        [Test]
        public void oneCanCreateEmailAndSaveIt()
        {
            
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
            
            LoginToEmail loginToEmail = new LoginToEmail(driver);
            loginToEmail.canLoginEmail();
            loginToEmail.canCreateEmail();
            loginToEmail.canSendEmail();

            Assert.Throws<NoSuchElementException>(() => loginToEmail.findSentEmailInDrafts());
  
            driver.Close();
        }

        [Test]
        public void sentEmailVerification()
        {
            
            LoginToEmail loginToEmail = new LoginToEmail(driver);
            loginToEmail.canLoginEmail();
            loginToEmail.canCreateEmail();
            loginToEmail.canSendEmail();
            loginToEmail.findSentEmailInSent();

            //this is a check to see if a draft is in 'Sent' folder
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.XPath("//div[(text()='merrymaker12@gmail.com')]"))));

            driver.Close();
        }
    }
}
