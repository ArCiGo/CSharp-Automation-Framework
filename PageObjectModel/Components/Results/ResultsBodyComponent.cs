using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;

namespace PageObjectModel.Components.Results
{
    public class ResultsBodyComponent : GoogleComponent
    {
        // Attributes
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
            Log.Information("ResultsBodyComponent class: ResultsLabelIsLoaded() method was ran");

            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='result-stats']"))).Displayed;
        }
    }
}
