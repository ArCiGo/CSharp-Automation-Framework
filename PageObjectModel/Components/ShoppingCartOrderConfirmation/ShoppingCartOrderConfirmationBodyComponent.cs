using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectModel.Components.ShoppingCartOrderConfirmation
{
    public class ShoppingCartOrderConfirmationBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.ClassName("page-heading"));
        public IWebElement OrderCompletedText => Driver.FindElement(By.ClassName("cheque-indent"));

        // Constructor
        public ShoppingCartOrderConfirmationBodyComponent(IWebDriver driver) : base(driver)
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
                // Here goes the logger

                return false;
            }
        }

        public string GetOrderConfirmationText()
        {
            return OrderCompletedText.Text;
        }
    }
}
