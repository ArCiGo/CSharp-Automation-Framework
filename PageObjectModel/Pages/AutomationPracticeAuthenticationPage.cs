﻿using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeAuthenticationPage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly AuthenticationBodyComponent authenticationBodyComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public AutomationPracticeAuthenticationPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            authenticationBodyComponent = new AuthenticationBodyComponent(driver);
        }

        // Actions
        public Boolean IsLoaded()
        {
            return authenticationBodyComponent.IsLoaded();
        }

        public void FillCreateAccount(string email)
        {
            authenticationBodyComponent.FillCreateAccountForm(email);
        }

        public AutomationPracticeCreateAccountPage ClickOnCreateAccountButton()
        {
            return authenticationBodyComponent.ClickOnCreateAccountButton();
        }

        public void FillSignInForm(string email, string password)
        {
            authenticationBodyComponent.FillSignInForm(email, password);
        }

        public AutomationPracticeMyAccountPage ClickOnSignInButton()
        {
            return authenticationBodyComponent.ClickOnSignInButton();
        }
    }
}