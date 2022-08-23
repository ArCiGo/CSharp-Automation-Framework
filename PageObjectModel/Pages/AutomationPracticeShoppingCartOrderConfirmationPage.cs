﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartOrderConfirmation;
using System;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeShoppingCartOrderConfirmationPage : BasePage
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly ShoppingCartOrderConfirmationBodyComponent shoppingCartOrderConfirmationBodyComponent;

        // Elements

        // Constructor
        public AutomationPracticeShoppingCartOrderConfirmationPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartOrderConfirmationBodyComponent = new ShoppingCartOrderConfirmationBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartOrderConfirmationBodyComponent.IsLoaded();
        }

        public string GetOrderConfirmationText()
        {
            return shoppingCartOrderConfirmationBodyComponent.GetOrderConfirmationText();
        }
    }
}
