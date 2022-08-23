using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.ShoppingCartOrderSummaryBankwire
{
    public class ShoppingCartOrderSummaryBankwireBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement SubtitleText => Driver.FindElement(By.ClassName("page-subheading"));
        public IWebElement ConfirmOrderButton => Driver.FindElement(By.XPath("//button[contains(@class, 'button btn')]"));

        // Constructor
        public ShoppingCartOrderSummaryBankwireBodyComponent(IWebDriver driver) : base(driver)
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

        public AutomationPracticeShoppingCartOrderSummaryBankwirePage ClickOnConfirmOrderButton()
        {
            ConfirmOrderButton.Click();

            return new AutomationPracticeShoppingCartOrderSummaryBankwirePage(Driver);
        }
    }
}
