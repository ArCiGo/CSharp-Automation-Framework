using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.ShoppingCartAddresses
{
    public class ShoppingCartAddressesBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.ClassName("page-heading"));
        public IWebElement CheckoutButton => Driver.FindElement(By.Name("processAddress"));

        // Constructor
        public ShoppingCartAddressesBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public bool IsLoaded()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("page-heading"))).Displayed;
            }
            catch (Exception ex)
            {
                // here goes the logger

                return false;
            }
        }

        public AutomationPracticeShoppingCartShippingPage ClickOnCheckOutButton()
        {
            CheckoutButton.Click();

            return new AutomationPracticeShoppingCartShippingPage(Driver);
        }
    }
}
