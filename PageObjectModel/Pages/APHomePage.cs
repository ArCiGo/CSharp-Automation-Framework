using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Home;
using Serilog;
using System;
using System.Collections.Generic;

namespace PageObjectModel.Pages
{
    public class APHomePage : BasePage
    {
        // Attributes
        private readonly HomeHeaderComponent homeHeaderComponent;
        private readonly HomeBodyComponent homeBodyComponent;

        // Elements

        // Constructor
        public APHomePage(IWebDriver driver) : base(driver)
        {
            homeHeaderComponent = new HomeHeaderComponent(driver);
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return homeHeaderComponent.IsLoaded();
        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Log.Information("URL: " + url + "openned");
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
