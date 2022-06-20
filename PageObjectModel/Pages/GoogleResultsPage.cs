using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Results;
using System;

namespace PageObjectModel.Pages
{
    public class GoogleResultsPage : BasePage
    {
        // Attributes

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private WebDriverWait wait;
        private ResultsBodyComponent resultsBodyComponent;

        // Elements

        public IWebElement GoogleLogoImg => Driver.FindElement(By.XPath("//img[@alt='Google']"));

        // Constructor

        public GoogleResultsPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            resultsBodyComponent = new ResultsBodyComponent(driver);
        }

        // Actions

        /*
         * This is a generic validation
         */
        public bool IsLoaded()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@alt='Google']"))).Displayed;
        }

        public bool ResultsLabelIsLoaded()
        {
            return resultsBodyComponent.ResultsLabelIsLoaded();
        }
    }
}
