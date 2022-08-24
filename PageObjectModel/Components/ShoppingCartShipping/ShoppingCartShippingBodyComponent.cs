using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.ShoppingCartShipping
{
    public class ShoppingCartShippingBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.ClassName("page-heading"));
        public IWebElement TermsOfServiceCheckbox => Driver.FindElement(By.Id("cgv"));
        public IWebElement CheckoutButton => Driver.FindElement(By.Name("processCarrier"));

        // Constructor
        public ShoppingCartShippingBodyComponent(IWebDriver driver) : base(driver)
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

        public void CheckTermsOfServiceCheckbox()
        {
            TermsOfServiceCheckbox.Click();
        }

        public APShoppingCartPaymentMethodPage ClickOnCheckoutButton()
        {
            CheckoutButton.Click();

            return new APShoppingCartPaymentMethodPage(Driver);
        }
    }
}
