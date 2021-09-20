using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
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
        public IWebElement EmailAddressCreateInput => Driver.FindElement(By.Id("email_create"));
        public IWebElement CreateAccountButton => Driver.FindElement(By.Id("SubmitCreate"));
        public IWebElement EmailAddressAlreadyInput => Driver.FindElement(By.XPath("//h3[contains(text(), 'Already')]/following-sibling::div/div[@class='form-group']/input[@id='email']"));
        public IWebElement PasswordAlreadyInput => Driver.FindElement(By.XPath("//h3[contains(text(), 'Already')]/following-sibling::div/div[@class='form-group'][2]/span/input[@id='passwd']"));
        public IWebElement SignInButton => Driver.FindElement(By.Id("SubmitLogin"));

        // Constructor
        public AuthenticationBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public bool IsLoaded()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[@class='page-heading'][contains(text(), 'Authen')]"))).Displayed;
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

        public void FillCreateAccountForm(string email)
        {
            EmailAddressCreateInput.Clear();
            EmailAddressCreateInput.SendKeys(email);
        }

        public AutomationPracticeCreateAccountPage ClickOnCreateAccountButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SubmitCreate"))).Click(); ;

            return new AutomationPracticeCreateAccountPage(Driver);
        }

        public void FillSignInForm(string email, string password)
        {
            EmailAddressAlreadyInput.Clear();
            EmailAddressAlreadyInput.SendKeys(email);

            PasswordAlreadyInput.Clear();
            PasswordAlreadyInput.SendKeys(password);
        }

        public AutomationPracticeMyAccountPage ClickOnSignInButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SubmitLogin"))).Click();

            return new AutomationPracticeMyAccountPage(Driver);
        }
    }
}
