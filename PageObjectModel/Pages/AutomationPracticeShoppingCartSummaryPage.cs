using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.ShoppingCartSummary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeShoppingCartSummaryPage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;
        private readonly ShoppingCartSummaryBodyComponent shoppingCartSummaryBodyComponent;

        // Elements

        // Constructor
        public AutomationPracticeShoppingCartSummaryPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            shoppingCartSummaryBodyComponent = new ShoppingCartSummaryBodyComponent(Driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return shoppingCartSummaryBodyComponent.IsLoaded();
        }

        public bool IsOnShoppingCart(List<string> clothes)
        {
            return shoppingCartSummaryBodyComponent.IsOnShoppingCart(clothes);
        }

        public AutomationPracticeShoppingCartAddressesPage ClickOnCheckoutButton()
        {
            return shoppingCartSummaryBodyComponent.ClickOnCheckoutButton();
        }
    }
}
