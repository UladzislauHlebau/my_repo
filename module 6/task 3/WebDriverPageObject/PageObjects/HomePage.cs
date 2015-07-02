using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverPageObject
{
    public class HomePage
    {

        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//span[(text()='Написать письмо')]")]
        public IWebElement createEmailButton;

        [FindsBy(How = How.XPath, Using = "//textarea[@class='js-input compose__labels__input']")]
        public IWebElement addressField;

        [FindsBy(How = How.XPath, Using = "//input[@class='compose__header__field']")]
        public IWebElement subjectField;

        [FindsBy(How = How.CssSelector, Using = "iframe[title='{#aria.rich_text_area}']")]
        public IWebElement elementItemFrame;

        [FindsBy(How = How.CssSelector, Using = "body#tinymce")]
        public IWebElement emailTextField;

        [FindsBy(How = How.XPath, Using = "//span[(text()='Сохранить')]")]
        public IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()='Черновики')]")]
        public IWebElement draftsCategory;

        [FindsBy(How = How.XPath, Using = "//div[(text()='merrymaker12@gmail.com')]")]
        public IWebElement draftEmail;

        [FindsBy(How = How.XPath, Using = "//div[(text()='WebDriver Test')]")]
        public IWebElement draftEmailSubject;

        [FindsBy(How = How.XPath, Using = "//span[@class='b-toolbar__btn__text']")]
        public IWebElement sendButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()='Отправленные')]")]
        public IWebElement sentCategory;

        public IWebElement ElementItemFrame
        {
            get
            {
                IWrapsElement wrapper = this.elementItemFrame as IWrapsElement;
                if (wrapper != null)
                {
                    return wrapper.WrappedElement;
                }

                // You could return null, or throw an exception.
                return null;
            }
        }
               
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void EmptyEmailOpening()
        {
            createEmailButton.Click();
        }

        public void NewEmailCreation(string address, string subject, string message)
        {
            addressField.SendKeys(address);
            subjectField.SendKeys(subject);
            driver.SwitchTo().Frame(ElementItemFrame);
            emailTextField.SendKeys(message);
        }

        public void EmailSaveToDrafts()
        {
            driver.SwitchTo().DefaultContent();
            saveButton.Click();
        }

        public bool DraftVerification()
        {
            draftsCategory.Click();
            return draftEmail.Displayed;
        }

        public bool SentEmailVerification()
        {
            sentCategory.Click();
            return draftEmail.Displayed;
        }

        public string EmailSubjectAndTextVerification()
        {
            return draftEmailSubject.Text;
        }

        public void EmailSending()
        {
            draftEmail.Click();
            sendButton.Click();
        }


        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
