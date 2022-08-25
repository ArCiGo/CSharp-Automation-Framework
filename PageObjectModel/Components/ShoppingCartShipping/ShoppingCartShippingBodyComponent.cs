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
        public ShoppingCartShippingBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions
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
