using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.MyAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeMyAccountPage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly MyAccountBodyComponent myAccountBodyComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public AutomationPracticeMyAccountPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            myAccountBodyComponent = new MyAccountBodyComponent(driver);
        }

        // Actions
        public Boolean IsLoaded()
        {
            return myAccountBodyComponent.IsLoaded();
        }
    }
}
