using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.CreateAccount;
using PageObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Pages
{
    public class AutomationPracticeCreateAccountPage : BasePage
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly CreateAccountBodyComponent createAccountBodyComponent;
        private readonly WebDriverWait wait;

        // Elements

        // Constructor
        public AutomationPracticeCreateAccountPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            createAccountBodyComponent = new CreateAccountBodyComponent(driver);
        }

        // Actions
        public void FillRegisterForm(List<Person> personalData)
        {
            createAccountBodyComponent.FillRegisterForm(personalData);
        }

        public AutomationPracticeMyAccountPage ClickOnRegisterButton()
        {
            return createAccountBodyComponent.ClickRegisterButton();
        }
    }
}
