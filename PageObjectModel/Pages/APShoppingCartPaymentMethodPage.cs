using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartPaymentMethod;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartPaymentMethodPage : BasePage
    {
        // Attributes
        private readonly ShoppingCartPaymentMethodBodyComponent shoppingCartPaymentBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartPaymentMethodPage(IWebDriver driver) : base(driver)
        {
            shoppingCartPaymentBodyComponent = new ShoppingCartPaymentMethodBodyComponent(Driver);
        }

        // Actions
        public APShoppingCartOrderConfirmationPage ClickOnBankwireButton()
        {
            return shoppingCartPaymentBodyComponent.ClickOnBankwireButton();
        }
    }
}
