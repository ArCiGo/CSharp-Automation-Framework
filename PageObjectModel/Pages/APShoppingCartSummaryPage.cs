using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartSummary;
using System;
using System.Collections.Generic;

namespace PageObjectModel.Pages
{
    public class APShoppingCartSummaryPage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartSummaryBodyComponent shoppingCartSummaryBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartSummaryPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartSummaryBodyComponent = new ShoppingCartSummaryBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartSummaryBodyComponent.IsLoaded();
        }

        public bool IsOnShoppingCart(List<string> clothes)
        {
            return shoppingCartSummaryBodyComponent.IsOnShoppingCart(clothes);
        }

        public APShoppingCartAddressesPage ClickOnCheckoutButton()
        {
            return shoppingCartSummaryBodyComponent.ClickOnCheckoutButton();
        }
    }
}
