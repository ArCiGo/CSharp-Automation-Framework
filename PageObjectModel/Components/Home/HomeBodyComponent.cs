using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PageObjectModel.Components.Home
{
    public class HomeBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;
        private readonly HomeHeaderComponent homeHeaderComponent;

        // Elements
        //public IList<IWebElement> ClothesText => Driver.FindElements(By.XPath("//a[@class='product-name']"));
        public IList<IWebElement> ClotheImages => Driver.FindElements(By.XPath("//ul[@id='homefeatured']/li/descendant::img[@class='replace-2x img-responsive']"));
        public IList<IWebElement> CartButtons => Driver.FindElements(By.XPath("//ul[@id='homefeatured']/li/descendant::div[@class='button-container']/a[@title='Add to cart']"));
        public IWebElement ContinueShoppingButton => Driver.FindElement(By.XPath("//div[@class='button-container']/span"));

        // Constructor
        public HomeBodyComponent(IWebDriver driver) : base(driver) 
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            homeHeaderComponent = new HomeHeaderComponent(Driver);
        }

        // Actions
        public void AddItemsToCart(List<string> clothes)
        {
            for (int i = 0; i < clothes.Count; i ++)
            {
                for (int j = 0; j < ClotheImages.Count; j++)
                {
                    Actions action = new Actions(Driver);
                    action.MoveToElement(ClotheImages[j]).Build().Perform();

                    if (CartButtons[j].Displayed && (clothes[i].Equals(ClotheImages[j].GetAttribute("alt"))))
                    {
                        CartButtons[j].Click();
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("layer_cart")));
                        ContinueShoppingButton.Click();
                        homeHeaderComponent.IsLoaded();
                    }
                }
            }
        }
    }
}
