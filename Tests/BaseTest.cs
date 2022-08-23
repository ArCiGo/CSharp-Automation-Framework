using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Tests.AutomationResources;

namespace Tests
{
    public class BaseTest
    {
        // Attributes

        // Properties
        protected IWebDriver Driver { get; set; }
        
        public WebDriverWait Wait { get; set; }

        [OneTimeSetUp]
        public void CleanupResultDirectory()
        {
            
        }

        [SetUp]
        public void Setup()
        {
            // logger

            var factory = new WebDriverFactory();
            Driver = factory.GetDriver(BrowserType.Chrome);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            // logger

            try
            {
                StopBrowser();
            }
            catch (Exception ex)
            {
                // more loggers
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Close();
            Driver.Quit();
            Driver = null;

            // logger
        }
    }
}