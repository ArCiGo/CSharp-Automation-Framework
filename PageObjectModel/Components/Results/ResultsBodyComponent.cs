using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectModel.Components.Results
{
    public class ResultsBodyComponent : GoogleComponent
    {
        // Attributes

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;

        // Elements

        public IWebElement ResultsLabel => Driver.FindElement(By.XPath("//div[@id='result-stats']"));

        // Constructor

        public ResultsBodyComponent(IWebDriver driver) : base(driver) 
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions

        public bool ResultsLabelIsLoaded()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='result-stats']"))).Displayed;
        }
    }
}
