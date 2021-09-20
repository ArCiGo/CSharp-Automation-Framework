using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.Home
{
    public class HomeHeaderComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;

        // Elements        
        public IWebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));
        public IWebElement SignOutButton => Driver.FindElement(By.ClassName("logout"));

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
                logger.Error(ex.Source);
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
                logger.Error(ex.Message);

                return false;
            }
        }

        public AutomationPracticeAuthenticationPage ClickOnSignInButton()
        {
            SignInButton.Click();

            return new AutomationPracticeAuthenticationPage(Driver);
        }

        public AutomationPracticeAuthenticationPage ClickOnSignOutButton()
        {
            SignOutButton.Click();

            return new AutomationPracticeAuthenticationPage(Driver);
        }
    }
}
