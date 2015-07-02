using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using WebDriverPageObject.Utilities;
using TechTalk.SpecFlow;

namespace WebDriverPageObject
{
    [Binding]
    public class MailRuTest
    {
        private string login = System.Configuration.ConfigurationSettings.AppSettings["login1"];
        private string password = System.Configuration.ConfigurationSettings.AppSettings["pass1"];
        private string ADDRESS = "merrymaker12@gmail.com";
        private string SUBJECT = "WebDriver Test";
        private string MESSAGE = "Hey, this is WebDriver Test!";
        IWebDriver driver;
        Steps.Steps steps = new Steps.Steps();
        LoginPage loginPage;
        HomePage homePage;
        

        //[SetUp]
        //public void InitInstance()
        //{
        //    steps.InitBrowser();
        //}

        //[TearDown]
        //public void CloseInstance()
        //{
        //    steps.CloseBrowser();
        //}

        //[TestFixtureTearDown]
        //public void QuitInstance()
        //{
        //    steps.QuitBrowser();
        //}

        //[BeforeFeature]
        //public void InitInstance()
        //{
        //    steps.InitBrowser();
        //}
#region
        [Given(@"mail.ru is opened")]
        public void MailRuIsOpened()
        {
            loginPage.OpenPage();
        }

        [When(@"I enter email address, password and click login button")]
        public void WhenIEnterEmailPasswordAndClickLogin()
        {
            loginPage.LoginToEmail(login, password);
        }

        [Then(@"The emailbox title is displayed")]
        public void ThenEmailboxTitleIsDisplayed()
        {
            string title = homePage.GetPageTitle();
            Assert.IsNotNull(title, "Title doesn't exist.");
        }
#endregion
#region
        [Given(@"Empty Email is opened")]
        public void EmptyEmailIsOpened()
        {
            homePage.EmptyEmailOpening();
        }

        [When(@"I fill in <address> and <subject> and <message>")]
        public void WhenIFillInAddressSubjectMessage(string address, string subject, string message)
        {
            homePage.NewEmailCreation(ADDRESS, SUBJECT, MESSAGE);
        }

        [When(@"I click Save button")]
        public void IClickSaveButton()
        {
            homePage.EmailSaveToDrafts();
        }

        [Then(@"The Email exists in Drafts category")]
        public void ThenEmailExistsInDrafts()
        {
            string returnedSubjectAndText = homePage.EmailSubjectAndTextVerification();
            string neededSubjectAndText = "WebDriver TestHey, this is WebDriver Test! С уважением, Vl Gl vld.gl@mail.ru";
            Assert.AreEqual(returnedSubjectAndText, neededSubjectAndText);
        }
#endregion
    }
}
