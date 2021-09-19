﻿using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.Home
{
    public class HomeHeaderComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement AutomationPracticeLogoImg => Driver.FindElement(By.XPath("//img[@class='logo img-responsive']"));
        
        public IWebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));

        // Constructor
        public HomeHeaderComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public Boolean IsLoaded()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@class='logo img-responsive']")));

                return AutomationPracticeLogoImg.Displayed;
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

        public AutomationPracticeAuthenticationPage ClickOnSignInButton()
        {
            SignInButton.Click();

            return new AutomationPracticeAuthenticationPage(Driver);
        }
    }
}