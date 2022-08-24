using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.Home
{
    public class HomeHeaderComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements        
        public IWebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));
        public IWebElement SignOutButton => Driver.FindElement(By.ClassName("logout"));
        public IWebElement LogoImg => Driver.FindElement(By.XPath("//img[@class='logo img-responsive']"));
        public IWebElement CartLinkButton => Driver.FindElement(By.XPath("//a[contains(@title, 'View my shopping')]"));

        // Constructor
        public HomeHeaderComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public bool IsLoaded()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@class='logo img-responsive']"))).Displayed;
            }
            catch (Exception ex)
            {
                // Here goes the logger

                return false;
            }
        }

        public APAuthenticationPage ClickOnSignInButton()
        {
            SignInButton.Click();

            return new APAuthenticationPage(Driver);
        }

        public APAuthenticationPage ClickOnSignOutButton()
        {
            SignOutButton.Click();

            return new APAuthenticationPage(Driver);
        }

        public APHomePage ClickOnImageButton()
        {
            LogoImg.Click();

            return new APHomePage(Driver);
        }

        public APShoppingCartSummaryPage ClickOnCartLinkButton()
        {
            CartLinkButton.Click();

            return new APShoppingCartSummaryPage(Driver);
        }
    }
}
