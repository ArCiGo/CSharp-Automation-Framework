using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartShipping;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartShippingPage : BasePage
    {
        // Attributes
        private readonly ShoppingCartShippingBodyComponent shoppingCartShippingBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartShippingPage(IWebDriver driver) : base(driver)
        {
            shoppingCartShippingBodyComponent = new ShoppingCartShippingBodyComponent(Driver);
        }

        // Actions
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
