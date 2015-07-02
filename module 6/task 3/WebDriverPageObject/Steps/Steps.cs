using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.GetDriver();
        }

        public void CloseBrowser()
        {
            Driver.CloseBrowser();
        }

        public void QuitBrowser()
        {
            Driver.QuitBrowser();
        }

        public void LoginMailRu(string login, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.OpenPage();
            loginPage.LoginToEmail(login, password);
        }

        public string VerifyThatLoginIsSuccessful()
        {
            HomePage homePage = new HomePage(driver);
            return homePage.GetPageTitle();
        }

        //public void CreateNewEmail()
        //{
        //    HomePage homePage = new HomePage(driver);
        //    homePage.NewEmailCreation();
        //}

        public void SaveNewEmailToDrafts()
        {
            HomePage homePage = new HomePage(driver);
            homePage.EmailSaveToDrafts();
        }

        public bool VerifyEmailInDrafts()
        {
            HomePage homePage = new HomePage(driver);
            return homePage.DraftVerification();
        }

        public string VerifyContentsOfEmail()
        {
            HomePage homePage = new HomePage(driver);
            return homePage.EmailSubjectAndTextVerification();
        }

        public void SendEmail()
        {
            HomePage homePage = new HomePage(driver);
            homePage.EmailSending();
        }

        public bool VerifyEmailInSent()
        {
            HomePage homePage = new HomePage(driver);
            return homePage.SentEmailVerification();
        }
    }
}
