using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Tests.AutomationResources;

namespace Tests
{
    [AllureNUnit]
    [AllureParentSuite("Tests")]
    public class BaseTest
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Properties
        protected IWebDriver Driver { get; set; }
        
        public WebDriverWait Wait { get; set; }

        [OneTimeSetUp]
        public void CleanupResultDirectory()
        {
            AllureExtensions.WrapSetUpTearDownParams(() => 
            { 
                AllureLifecycle.Instance.CleanupResultDirectory(); 
            },
            "Cleanup Allure Results Directory");
        }

        [SetUp]
        public void Setup()
        {
            logger.Info("*** Test started ***");

            var factory = new WebDriverFactory();
            Driver = factory.GetDriver(BrowserType.Chrome);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            logger.Info(GetType().FullName + " started a CleanUp() method");
            
            TakeScreenshot();

            try
            {
                StopBrowser();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Source);
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
                logger.Error(ex.Message);
            }
        }

        private void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
                var path = filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
                AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Close();
            Driver.Quit();
            Driver = null;

            logger.Info("Browser stopped successfully!");
        }
    }
}