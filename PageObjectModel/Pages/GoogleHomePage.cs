using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Home;
using System;

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
        public bool IsLoaded()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@alt='Google']"))).Displayed;
        }

        public GoogleResultsPage FillSearchForm(string search)
        {
            homeBodyComponent.FillSearchForm(search);

            return new GoogleResultsPage(Driver);
        }
    }
}
