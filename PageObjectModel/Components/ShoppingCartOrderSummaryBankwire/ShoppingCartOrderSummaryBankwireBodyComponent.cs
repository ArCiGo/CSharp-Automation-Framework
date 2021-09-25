using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.ShoppingCartOrderSummaryBankwire
{
    public class ShoppingCartOrderSummaryBankwireBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
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
                logger.Error(ex.Source);
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
                logger.Error(ex.Message);

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
