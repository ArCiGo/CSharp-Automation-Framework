using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartShipping;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartShippingPage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartShippingBodyComponent shoppingCartShippingBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartShippingPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartShippingBodyComponent = new ShoppingCartShippingBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartShippingBodyComponent.IsLoaded();
        }

        public void CheckTermsOfServiceCheckbox()
        {
            shoppingCartShippingBodyComponent.CheckTermsOfServiceCheckbox();
        }

        public APShoppingCartPaymentMethodPage ClickOnCheckoutButton()
        {
            return shoppingCartShippingBodyComponent.ClickOnCheckoutButton();
        }
    }
}
