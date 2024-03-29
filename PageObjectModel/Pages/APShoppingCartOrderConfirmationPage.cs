﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartOrderConfirmation;
using System;

namespace PageObjectModel.Pages
{
    public class APShoppingCartOrderConfirmationPage : BasePage
    {
        // Attributes
        private readonly ShoppingCartOrderConfirmationBodyComponent shoppingCartOrderConfirmationBodyComponent;

        // Elements

        // Constructor
        public APShoppingCartOrderConfirmationPage(IWebDriver driver) : base(driver)
        {
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
