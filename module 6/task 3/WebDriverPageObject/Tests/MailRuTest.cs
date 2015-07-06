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
        private static string login = System.Configuration.ConfigurationSettings.AppSettings["login1"];
        private static string password = System.Configuration.ConfigurationSettings.AppSettings["pass1"];
        private static string ADDRESS = "merrymaker12@gmail.com";
        private static string SUBJECT = "WebDriver Test";
        private static string MESSAGE = "Hey, this is WebDriver Test!";
        public static LoginPage loginPage;
        public static HomePage homePage;


        [BeforeFeature]
        public static void InitInstance()
        {
            Driver.GetDriver();
        }

        //[AfterFeature]
        //public static void QuitInstance()
        //{
        //    Driver.QuitBrowser();
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
        public void ClickSaveButton()
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

        [AfterFeature]
        public static void CloseInstance()
        {
            Driver.CloseBrowser();
        }

#endregion
    }
}
