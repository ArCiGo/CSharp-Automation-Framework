using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartPaymentMethod;
using System;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeShoppingCartPaymentMethodPage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartPaymentMethodBodyComponent shoppingCartPaymentBodyComponent;

        // Elements

        // Constructor
        public AutomationPracticeShoppingCartPaymentMethodPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartPaymentBodyComponent = new ShoppingCartPaymentMethodBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartPaymentBodyComponent.IsLoaded();
        }

        public AutomationPracticeShoppingCartOrderConfirmationPage ClickOnBankwireButton()
        {
            return shoppingCartPaymentBodyComponent.ClickOnBankwireButton();
        }
    }
}
