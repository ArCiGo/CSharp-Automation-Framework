using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.Home
{
    public class HomeBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;
        private readonly HomeHeaderComponent homeHeaderComponent;

        // Elements
        //public IList<IWebElement> ClothesText => Driver.FindElements(By.XPath("//a[@class='product-name']"));
        public IList<IWebElement> ClothesImage => Driver.FindElements(By.XPath("//img[@class='replace-2x img-responsive']"));
        public IWebElement ContinueShoppingButton => Driver.FindElement(By.XPath("//div[@class='button-container']/span"));

        // Constructor
        public HomeBodyComponent(IWebDriver driver) : base(driver) 
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            homeHeaderComponent = new HomeHeaderComponent(Driver);
        }

        // Actions
        public void AddItemsToCart(List<string> clothes)
        {
            for(int i = 0; i < clothes.Count; i ++)
            {
                for(int j = 0; j < ClothesImage.Count; j++)
                {
                    Actions action = new Actions(Driver);
                    action.MoveToElement(ClothesImage[j]).Build().Perform();
                    
                    Console.WriteLine("Item by index: " + ClothesImage[j].GetAttribute("alt"));

                    IWebElement cartButton = Driver.FindElement(By.XPath("//div[@class='button-container']/a[@title='Add to cart']"));

                    if (cartButton.Displayed && (clothes[i].ToString().Equals(ClothesImage[j].GetAttribute("alt"))))
                    {
                        cartButton.Click();
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("layer_cart")));
                        ContinueShoppingButton.Click();
                        homeHeaderComponent.IsLoaded();
                    }
                }
            }
        }
    }
}
