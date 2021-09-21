using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartAddresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeShoppingCartAddressesPage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;
        private readonly ShoppingCartAddressesBodyComponent shoppingCartAddressBodyComponent;

        // Elements

        // Constructor
        public AutomationPracticeShoppingCartAddressesPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartAddressBodyComponent = new ShoppingCartAddressesBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartAddressBodyComponent.IsLoaded();
        }

        public AutomationPracticeShoppingCartShippingPage ClickOnCheckOutButton()
        {
            return shoppingCartAddressBodyComponent.ClickOnCheckOutButton();
        }
    }
}
