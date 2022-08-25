using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Components.MyAccount;
using System;

namespace PageObjectModel.Pages
{
    public class APMyAccountPage : BasePage
    {
        // Attributes
        private readonly MyAccountBodyComponent myAccountBodyComponent;

        // Elements

        // Constructor
        public APMyAccountPage(IWebDriver driver) : base(driver)
        {
            myAccountBodyComponent = new MyAccountBodyComponent(driver);
        }

        // Actions
        public bool IsLoaded()
        {
            return myAccountBodyComponent.IsLoaded();
        }
    }
}
