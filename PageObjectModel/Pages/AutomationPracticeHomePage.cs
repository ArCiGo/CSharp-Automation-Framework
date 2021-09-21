using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeHomePage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly HomeHeaderComponent homeHeaderComponent;
        private readonly HomeBodyComponent homeBodyComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public AutomationPracticeHomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            homeHeaderComponent = new HomeHeaderComponent(driver);
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions
        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            logger.Info("URL: " + url + "openned");
        }

        public bool IsLoaded()
        {
            return homeHeaderComponent.IsLoaded();
        }

        public AutomationPracticeAuthenticationPage ClickOnSignInButton()
        {
            return homeHeaderComponent.ClickOnSignInButton();
        }

        public AutomationPracticeAuthenticationPage ClickOnSignOutButton()
        {
            return homeHeaderComponent.ClickOnSignOutButton();
        }

        public AutomationPracticeHomePage ClickOnImageButton()
        {
            return homeHeaderComponent.ClickOnImageButton();
        }

        public AutomationPracticeShoppingCartSummaryPage ClickOnCartLinkButton()
        {
            return homeHeaderComponent.ClickOnCartLinkButton();
        }

        public void AddItemsToCart(List<string> clothes)
        {
            homeBodyComponent.AddItemsToCart(clothes);
        }
    }
}
