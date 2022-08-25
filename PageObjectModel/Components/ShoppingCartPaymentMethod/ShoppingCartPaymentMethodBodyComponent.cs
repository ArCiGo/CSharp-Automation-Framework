using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.ShoppingCartPaymentMethod
{
    public class ShoppingCartPaymentMethodBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabe => Driver.FindElement(By.ClassName("page-heading"));
        public IWebElement BankwireButton => Driver.FindElement(By.XPath("//a[contains(@class, 'bankwire')]"));

        // Constructor
        public ShoppingCartPaymentMethodBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions
        public APShoppingCartOrderConfirmationPage ClickOnBankwireButton()
        {
            BankwireButton.Click();

            return new APShoppingCartOrderConfirmationPage(Driver);
        }
    }
}
