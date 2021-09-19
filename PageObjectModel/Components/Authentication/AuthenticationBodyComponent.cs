using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.Authentication
{
    public class AuthenticationBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.XPath("//h1[@class='page-heading']"));

        public IWebElement EmailAddressCreateTextInput => Driver.FindElement(By.Id("email_create"));

        public IWebElement CreateAccountButton => Driver.FindElement(By.Id("SubmitCreate"));

        public IWebElement EmailAddressAlreadyTextInput => Driver.FindElement(By.XPath("//h3[contains(text(), 'Already')]/following-sibling::div/div[@class='form-group']/input[@id='email']"));

        public IWebElement PasswordAlreadyTextInput => Driver.FindElement(By.XPath("//h3[contains(text(), 'Already')]/following-sibling::div/div[@class='form-group'][2]/span/input[@id='passwd']"));

        public IWebElement SignInButton => Driver.FindElement(By.Id("SubmitLogin"));

        // Constructor
        public AuthenticationBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public Boolean IsLoaded()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[@class='page-heading']")));

                return TitleLabel.Displayed;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Source);
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
                logger.Error(ex.Message);

                return false;
            }
        }

        public void CreateAccount(string email)
        {
            EmailAddressCreateTextInput.Clear();
            EmailAddressCreateTextInput.SendKeys(email);
            CreateAccountButton.Click();

            return null;
        }

        public void SignIn(string email, string password)
        {
            EmailAddressAlreadyTextInput.Clear();
            EmailAddressAlreadyTextInput.SendKeys(email);
            
            PasswordAlreadyTextInput.Clear();
            PasswordAlreadyTextInput.SendKeys(password);

            SignInButton.Click();

            return null;
        }
    }
}
