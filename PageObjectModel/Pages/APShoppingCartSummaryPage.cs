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
        private readonly ShoppingCartSummaryBodyComponent shoppingCartSummaryBodyComponent;

        // Constructor
        public APShoppingCartSummaryPage(IWebDriver driver) : base(driver)
        {
            shoppingCartSummaryBodyComponent = new ShoppingCartSummaryBodyComponent(Driver);
        }

        // Actions
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
