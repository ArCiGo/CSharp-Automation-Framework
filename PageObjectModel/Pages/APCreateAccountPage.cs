using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.CreateAccount;
using PageObjectModel.Models;
using System;
using System.Collections.Generic;

namespace PageObjectModel.Pages
{
    public class APCreateAccountPage : BasePage
    {
        // Attributes
        private readonly CreateAccountBodyComponent createAccountBodyComponent;

        // Elements

        // Constructor
        public APCreateAccountPage(IWebDriver driver) : base(driver)
        {
            createAccountBodyComponent = new CreateAccountBodyComponent(driver);
        }

        // Actions
        public void FillRegisterForm(PersonModel personalData)
        {
            createAccountBodyComponent.FillRegisterForm(personalData);
        }

        public APMyAccountPage ClickOnRegisterButton()
        {
            return createAccountBodyComponent.ClickRegisterButton();
        }
    }
}
