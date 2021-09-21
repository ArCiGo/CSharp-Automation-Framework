using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.ShoppingCartSummary
{
    public class ShoppingCartSummaryBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.Id("cart_title"));
        public IList<IWebElement> ProductNameLabel => Driver.FindElements(By.ClassName("product-name"));
        public IWebElement CheckoutButton => Driver.FindElement(By.XPath("//a[contains(@title, 'Proceed to checkout')][@rel='nofollow']"));

        // Constructor
        public ShoppingCartSummaryBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public bool IsLoaded()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[@class='page-heading'][contains(text(), 'Shopping')]"))).Displayed;
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

        public bool IsOnShoppingCart(List<string> clothes)
        {
            for(int i = 0; i < clothes.Count; i++)
            {
                for(int j = 0; j < ProductNameLabel.Count; j++)
                {
                    if (clothes[i].Equals(ProductNameLabel[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public AutomationPracticeShoppingCartAddressesPage ClickOnCheckoutButton()
        {
            CheckoutButton.Click();

            return new AutomationPracticeShoppingCartAddressesPage(Driver);
        }
    }
}
