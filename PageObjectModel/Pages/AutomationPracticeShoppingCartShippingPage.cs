﻿using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartShipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeShoppingCartShippingPage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;
        private readonly ShoppingCartShippingBodyComponent shoppingCartShippingBodyComponent;

        // Elements

        // Constructor
        public AutomationPracticeShoppingCartShippingPage(IWebDriver driver) : base(driver)
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

        public AutomationPracticeShoppingCartPaymentMethodPage ClickOnCheckoutButton()
        {
            return shoppingCartShippingBodyComponent.ClickOnCheckoutButton();
        }
    }
}