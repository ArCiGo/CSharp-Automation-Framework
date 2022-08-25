using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;

namespace PageObjectModel.Components.ShoppingCartSummary
{
    public class ShoppingCartSummaryBodyComponent : AutomationPracticeComponent
    {
        // Attributes

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.Id("cart_title"));
        public IList<IWebElement> ProductNameLabel => Driver.FindElements(By.CssSelector("td p.product-name a"));
        public IWebElement CheckoutButton => Driver.FindElement(By.CssSelector("p[class='cart_navigation clearfix'] a[title^='Proceed']"));

        // Constructor
        public ShoppingCartSummaryBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions
        public bool IsOnShoppingCart(List<string> clothes)
        {
            for(int i = 0; i < clothes.Count; i++)
            {
                for(int j = 0; j < ProductNameLabel.Count; j++)
                {
                    if (clothes[i].Equals(ProductNameLabel[j].Text))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public APShoppingCartAddressesPage ClickOnCheckoutButton()
        {
            CheckoutButton.Click();

            return new APShoppingCartAddressesPage(Driver);
        }
    }
}
