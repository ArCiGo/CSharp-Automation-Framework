using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.ShoppingCartAddresses
{
    public class ShoppingCartAddressesBodyComponent : AutomationPracticeComponent
    {
        // Attributes

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.ClassName("page-heading"));
        public IWebElement CheckoutButton => Driver.FindElement(By.Name("processAddress"));

        // Constructor
        public ShoppingCartAddressesBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions
        public APShoppingCartShippingPage ClickOnCheckOutButton()
        {
            CheckoutButton.Click();

            return new APShoppingCartShippingPage(Driver);
        }
    }
}
