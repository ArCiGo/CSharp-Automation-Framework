using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartAddresses;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartAddressesPage : BasePage
    {
        // Attributes
        private readonly ShoppingCartAddressesBodyComponent shoppingCartAddressBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartAddressesPage(IWebDriver driver) : base(driver)
        {
            shoppingCartAddressBodyComponent = new ShoppingCartAddressesBodyComponent(Driver);
        }

        // Actions
        public APShoppingCartShippingPage ClickOnCheckOutButton()
        {
            return shoppingCartAddressBodyComponent.ClickOnCheckOutButton();
        }
    }
}
