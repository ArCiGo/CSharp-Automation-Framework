using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class GoogleHomePage : BasePage
    {
        // Attributes

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;
        private HomeBodyComponent homeBodyComponent;

        // Elements

        public IWebElement GoogleLogoImg => Driver.FindElement(By.XPath("//img[@alt='Google']"));

        // Constructor

        public GoogleHomePage(IWebDriver driver) : base(driver) 
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            logger.Info("URL: " + url + "openned");
        }

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

        public GoogleResultsPage FillSearchForm(string search)
        {
            homeBodyComponent.FillSearchForm(search);

            return new GoogleResultsPage(Driver);
        }
    }
}
