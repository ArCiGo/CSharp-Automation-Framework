using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartOrderSummaryBankwire;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartOrderSummaryBankwirePage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartOrderSummaryBankwireBodyComponent shoppingCartBankwireBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartOrderSummaryBankwirePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartBankwireBodyComponent = new ShoppingCartOrderSummaryBankwireBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartBankwireBodyComponent.IsLoaded();
        }

        public APShoppingCartOrderSummaryBankwirePage ClickOnConfirmOrderButton()
        {
            return shoppingCartBankwireBodyComponent.ClickOnConfirmOrderButton();
        }
    }
}
