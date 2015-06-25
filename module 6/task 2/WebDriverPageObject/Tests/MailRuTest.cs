using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverPageObject.Utilities;

namespace WebDriverPageObject
{
    [TestFixture]
    public class MailRuTest
    {
        private string login = System.Configuration.ConfigurationSettings.AppSettings["login1"];
        private string password = System.Configuration.ConfigurationSettings.AppSettings["pass1"];

        Steps.Steps steps = new Steps.Steps();
        

        [SetUp]
        public void InitInstance()
        {
            //steps.InitBrowser();
            WebDriverCreator creator = new ChromeDriverCreator();
            IWebDriver driver = creator.FactoryMethod();
        }

        [TearDown]
        public void CloseInstance()
        {
            steps.CloseBrowser();
        }

        //[TestFixtureTearDown]
        //public void QuitInstance()
        //{
        //    steps.QuitBrowser();
        //}

        [Test]
        public void OneCanLoginMailRu()
        {
            steps.LoginMailRu(login, password);
            string title = steps.VerifyThatLoginIsSuccessful();
            Assert.IsNotNull(title, "Title doesn't exist.");
        }

        [Test]
        public void OneCanCreateEmailAndSaveIt()
        {
            steps.LoginMailRu(login, password);
            steps.CreateNewEmail();
            steps.SaveNewEmailToDrafts();
            bool isDraftDisplayed = steps.VerifyEmailInDrafts();
            Assert.IsTrue(isDraftDisplayed);
        }

        [Test]
        public void DraftEmailVerification()
        {
            steps.LoginMailRu(login, password);
            steps.CreateNewEmail();
            steps.SaveNewEmailToDrafts();
            steps.VerifyEmailInDrafts();
            string returnedSubjectAndText = steps.VerifyContentsOfEmail();
            string neededSubjectAndText = "WebDriver TestHey, this is WebDriver Test! С уважением, Vl Gl vld.gl@mail.ru";
            Assert.AreEqual(returnedSubjectAndText, neededSubjectAndText);
        }

        [Test]
        public void OneCanSendEmail()
        {
            steps.LoginMailRu(login, password);
            steps.CreateNewEmail();
            steps.SaveNewEmailToDrafts();
            steps.VerifyEmailInDrafts();
            steps.SendEmail();
            Assert.Throws<NoSuchElementException>(() => steps.VerifyEmailInDrafts());
            bool isSent = steps.VerifyEmailInSent();
            Assert.IsTrue(isSent);

        }
    }
}
