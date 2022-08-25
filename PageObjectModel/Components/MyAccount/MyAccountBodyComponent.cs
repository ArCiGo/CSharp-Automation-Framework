using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectModel.Components.MyAccount
{
    public class MyAccountBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public MyAccountBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public bool IsLoaded()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[@class='page-heading'][contains(text(), 'My acc')]"))).Displayed;
        }
    }
}
