using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Results;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Boolean IsLoaded()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@alt='Google']")));

                return GoogleLogoImg.Displayed;
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

        public Boolean ResultsLabelIsLoaded()
        {
            return resultsBodyComponent.ResultsLabelIsLoaded();
        }
    }
}
