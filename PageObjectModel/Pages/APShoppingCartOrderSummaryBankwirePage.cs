using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartOrderSummaryBankwire;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartOrderSummaryBankwirePage : BasePage
    {
        // Attributes
        private readonly ShoppingCartOrderSummaryBankwireBodyComponent shoppingCartBankwireBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartOrderSummaryBankwirePage(IWebDriver driver) : base(driver)
        {
            shoppingCartBankwireBodyComponent = new ShoppingCartOrderSummaryBankwireBodyComponent(Driver);
        }

        // Actions
        public APShoppingCartOrderSummaryBankwirePage ClickOnConfirmOrderButton()
        {
            return shoppingCartBankwireBodyComponent.ClickOnConfirmOrderButton();
        }
    }
}
