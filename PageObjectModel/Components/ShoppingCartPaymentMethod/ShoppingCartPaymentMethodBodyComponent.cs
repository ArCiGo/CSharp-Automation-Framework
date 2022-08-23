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
        public ShoppingCartPaymentMethodBodyComponent(IWebDriver driver) : base(driver) 
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

        public AutomationPracticeShoppingCartOrderConfirmationPage ClickOnBankwireButton()
        {
            BankwireButton.Click();

            return new AutomationPracticeShoppingCartOrderConfirmationPage(Driver);
        }
    }
}
