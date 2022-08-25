using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.Authentication
{
    public class AuthenticationBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.XPath("//h1[@class='page-heading']"));
        public IWebElement EmailAddressCreateInput => Driver.FindElement(By.Id("email_create"));
        public IWebElement CreateAccountButton => Driver.FindElement(By.Id("SubmitCreate"));
        public IWebElement EmailAddressAlreadyInput => Driver.FindElement(By.XPath("//h3[contains(text(), 'Already')]/following-sibling::div/div[@class='form-group']/input[@id='email']"));
        public IWebElement PasswordAlreadyInput => Driver.FindElement(By.XPath("//h3[contains(text(), 'Already')]/following-sibling::div/div[@class='form-group'][2]/span/input[@id='passwd']"));
        public IWebElement SignInButton => Driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement ErrorBanner => Driver.FindElement(By.XPath("//h1/following-sibling::div[@class='alert alert-danger']/descendant::li"));

        // Constructor
        public AuthenticationBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public void FillCreateAccountForm(string email)
        {
            EmailAddressCreateInput.Clear();
            EmailAddressCreateInput.SendKeys(email);
        }

        public APCreateAccountPage ClickOnCreateAccountButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SubmitCreate"))).Click(); ;

            return new APCreateAccountPage(Driver);
        }

        public void FillSignInForm(string email, string password)
        {
            EmailAddressAlreadyInput.Clear();
            EmailAddressAlreadyInput.SendKeys(email);

            PasswordAlreadyInput.Clear();
            PasswordAlreadyInput.SendKeys(password);
        }

        public APMyAccountPage ClickOnSignInButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SubmitLogin"))).Click();

            return new APMyAccountPage(Driver);
        }

        public string IsErrorBannerDisplayed()
        {
            if(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1/following-sibling::div[@class='alert alert-danger']/descendant::li"))).Displayed)
            {
                return ErrorBanner.Text;
            }

            return null;
        }
    }
}
