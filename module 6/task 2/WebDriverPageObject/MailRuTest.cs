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

        IWebDriver driver;
        [TestFixtureSetUp]
        public void toRunDriver()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
        }

        [TestFixtureTearDown]
        public void toCloseDriver()
        {
            driver.Close();
        }

        [TearDown]
        public void toCloseDriverAfterTest()
        {
            driver.Close();
        }

        [Test]
        public void oneCanLoginMailRu()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = loginPage.loginToEmail();
            string title = homePage.getPageTitle();
            Assert.IsNotNull(title, "Title doesn't exist.");
    
        }

        [Test]
        public void oneCanCreateEmailAndSaveIt()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            
        }

        [Test]
        public void draftEmailVerification()
        {
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

        [Test]
        public void oneCanSendEmail()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            homePage.draftsCategory.Click();
            homePage.sendEmail();
        }

        [Test]
        public void sentEmailVerificationInDrafts()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            homePage.draftsCategory.Click();
            homePage.sendEmail();
            Assert.Throws<NoSuchElementException>(() => homePage.draftVerification());
        }

        [Test]
        public void sentEmailVerificationInSent()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.openPage();
            HomePage homePage = new HomePage(driver);
            homePage = loginPage.loginToEmail();
            homePage.newEmailCreation();
            homePage.draftsCategory.Click();
            homePage.sendEmail();
            bool isSent = homePage.sentEmailVerification();
            Assert.IsTrue(isSent);
        }

    }
}
