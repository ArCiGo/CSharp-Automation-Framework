using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Tests.UI.AutomationResources
{
    public class WebDriverFactory
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public IWebDriver GetDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    logger.Info("*** Chrome driver created ***");
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    logger.Info("*** Firefox driver created ***");
                    return GetFirefoxDriver();
                default:
                    ArgumentException ex = new ArgumentException("No such browser exists!");
                    logger.Error(ex.Source);
                    logger.Error(ex.StackTrace);
                    logger.Error(ex.InnerException);
                    logger.Error(ex.Message);
                    throw ex;
            }
        }

        /*
         * Review if this works on Mac.
         * If this works as expected on Mac, the OperatingSystem class will not be necessary.
         */
        private IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");

            return new ChromeDriver(options);
        }

        private IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions profile = new FirefoxOptions();
            profile.SetPreference("dom.webnotifications.enabled", false);

            return new FirefoxDriver(profile);
        }
    }
}
