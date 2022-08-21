using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Serilog;
using System;

namespace Tests.UI.AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver GetDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    Log.Information("*** ChromeDriver was initialized ***");
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    Log.Information("*** GeckoDriver was initialized ***");
                    return GetFirefoxDriver();
                default:
                    ArgumentException ex = new ArgumentException("No such browser exists!");

                    Log.Error(ex.Source);
                    Log.Error(ex.StackTrace);
                    Log.Error(ex.InnerException.ToString());
                    Log.Error(ex.Message);

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
