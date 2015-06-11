using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WebDriverPageObject
{
        [TestFixture(typeof(FirefoxDriver))]
        [TestFixture(typeof(ChromeDriver))]


        class RemoteDriverTests<TWebDriver> where TWebDriver : IWebDriver, new()
        {
            private string Node = "http://10.10.10.10/wd/hub";

            IWebDriver driver;

            [SetUp]
            public void RunDriver()
            {
                if (typeof(TWebDriver) == typeof(ChromeDriver))
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    Console.Write("Tests are being run in: " + capabilities.BrowserName + "with version: " + capabilities.Version);
                    driver = new RemoteWebDriver(new Uri(Node), capabilities);
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Manage().Window.Maximize();
                }
                else
                {
                    DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                    Console.Write("Tests are being run in: " + capabilities.BrowserName + "with version: " + capabilities.Version);
                    driver = new RemoteWebDriver(new Uri(Node), capabilities);
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Manage().Window.Maximize();
                }
            }

            [TestFixtureTearDown]
            public void toCloseDriver()
            {
                driver.Close();
            }

            //[TearDown]
            //public void toCloseDriverAfterTest()
            //{
            //    driver.Close();
            //}

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
