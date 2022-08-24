using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Home;
using System;
using System.Collections.Generic;

namespace PageObjectModel.Pages
{
    public class APHomePage : BasePage
    {
        // Attributes
        private readonly HomeHeaderComponent homeHeaderComponent;
        private readonly HomeBodyComponent homeBodyComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public APHomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            homeHeaderComponent = new HomeHeaderComponent(driver);
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions
        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            // logger.Info("URL: " + url + "openned");
        }

        public bool IsLoaded()
        {
            return homeHeaderComponent.IsLoaded();
        }

        public APAuthenticationPage ClickOnSignInButton()
        {
            return homeHeaderComponent.ClickOnSignInButton();
        }

        public APAuthenticationPage ClickOnSignOutButton()
        {
            return homeHeaderComponent.ClickOnSignOutButton();
        }

        public APHomePage ClickOnImageButton()
        {
            return homeHeaderComponent.ClickOnImageButton();
        }

        public APShoppingCartSummaryPage ClickOnCartLinkButton()
        {
            return homeHeaderComponent.ClickOnCartLinkButton();
        }

        public void AddItemsToCart(List<string> clothes)
        {
            homeBodyComponent.AddItemsToCart(clothes);
        }
    }
}
