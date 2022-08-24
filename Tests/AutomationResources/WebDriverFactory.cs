using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Tests.AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver GetDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    // logger
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    // logger
                    return GetFirefoxDriver();
                default:
                    ArgumentException ex = new ArgumentException("No such browser exists!");
                    // more loggers
                    throw ex;
            }
        }

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
