﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartOrderSummaryBankwire;
using System;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeShoppingCartOrderSummaryBankwirePage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartOrderSummaryBankwireBodyComponent shoppingCartBankwireBodyComponent;

        // Elements

        // Constructor
        public AutomationPracticeShoppingCartOrderSummaryBankwirePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartBankwireBodyComponent = new ShoppingCartOrderSummaryBankwireBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartBankwireBodyComponent.IsLoaded();
        }

        public AutomationPracticeShoppingCartOrderSummaryBankwirePage ClickOnConfirmOrderButton()
        {
            return shoppingCartBankwireBodyComponent.ClickOnConfirmOrderButton();
        }
    }
}
