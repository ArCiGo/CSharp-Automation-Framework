using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Authentication;
using System;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeAuthenticationPage : BasePage
    {
        // Attributes
        private readonly AuthenticationBodyComponent authenticationBodyComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public AutomationPracticeAuthenticationPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            authenticationBodyComponent = new AuthenticationBodyComponent(driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return authenticationBodyComponent.IsLoaded();
        }

        public void FillCreateAccount(string email)
        {
            authenticationBodyComponent.FillCreateAccountForm(email);
        }

        public AutomationPracticeCreateAccountPage ClickOnCreateAccountButton()
        {
            return authenticationBodyComponent.ClickOnCreateAccountButton();
        }

        public void FillSignInForm(string email, string password)
        {
            authenticationBodyComponent.FillSignInForm(email, password);
        }

        public AutomationPracticeMyAccountPage ClickOnSignInButton()
        {
            return authenticationBodyComponent.ClickOnSignInButton();
        }

        public string IsErrorBannerDisplayed()
        {
            return authenticationBodyComponent.IsErrorBannerDisplayed();
        }
    }
}
