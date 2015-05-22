using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverPageObject
{
    [TestFixture]
    public class MailRuTest
    {
        

        //[TearDown]
        //public void logoutFromMailRu()
        //{

        //}

        [Test]
        public void oneCanLoginMailRu()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = loginPage.loginToEmail();
            string title = homePage.getPageTitle();
            Assert.IsNotNull(title, "Title doesn't exist.");
        }

        [Test]
        public void oneCanCreateEmailAndSaveIt()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            
        }

        [Test]
        public void draftEmailVerification()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            bool isDraftDisplayed = homePage.draftVerification();
            Assert.IsTrue(isDraftDisplayed);

        }

        [Test]
        public void draftEmailSubjectAndTextVerification()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            homePage.draftsCategory.Click();
            string returnedSubjectAndText = homePage.emailSubjectAndTextVerification();
            string neededSubjectAndText = "WebDriver TestHey, this is WebDriver Test! С уважением, Vl Gl vld.gl@mail.ru";
            Assert.AreEqual(returnedSubjectAndText, neededSubjectAndText);

        }
    }
}
