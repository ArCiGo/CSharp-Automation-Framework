using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    class AutomationPracticeHomePage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly HomeHeaderComponent homeHeaderComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public AutomationPracticeHomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            homeHeaderComponent = new HomeHeaderComponent(driver);
        }

        // Actions
        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            logger.Info("URL: " + url + "openned");
        }

        public Boolean IsLoaded()
        {
            return homeHeaderComponent.IsLoaded();
        }

        public AutomationPracticeAuthenticationPage ClickOnSignInButton()
        {
            return homeHeaderComponent.ClickOnSignInButton();
        }
    }
}
