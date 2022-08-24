using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartAddresses;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartAddressesPage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartAddressesBodyComponent shoppingCartAddressBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartAddressesPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartAddressBodyComponent = new ShoppingCartAddressesBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartAddressBodyComponent.IsLoaded();
        }

        public APShoppingCartShippingPage ClickOnCheckOutButton()
        {
            return shoppingCartAddressBodyComponent.ClickOnCheckOutButton();
        }
    }
}
