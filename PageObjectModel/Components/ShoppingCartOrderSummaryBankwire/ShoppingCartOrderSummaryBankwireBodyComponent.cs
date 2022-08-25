using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;

namespace PageObjectModel.Components.ShoppingCartOrderSummaryBankwire
{
    public class ShoppingCartOrderSummaryBankwireBodyComponent : AutomationPracticeComponent
    {
        // Attributes

        // Elements
        public IWebElement SubtitleText => Driver.FindElement(By.ClassName("page-subheading"));
        public IWebElement ConfirmOrderButton => Driver.FindElement(By.XPath("//button[contains(@class, 'button btn')]"));

        // Constructor
        public ShoppingCartOrderSummaryBankwireBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions
        public APShoppingCartOrderSummaryBankwirePage ClickOnConfirmOrderButton()
        {
            ConfirmOrderButton.Click();

            return new APShoppingCartOrderSummaryBankwirePage(Driver);
        }
    }
}
