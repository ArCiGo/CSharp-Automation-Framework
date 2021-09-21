using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjectModel.Models;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Data;

namespace Tests.Tests
{
    [AllureNUnit]
    [TestFixture]
    [Category("UI Automation Practice Sample Tests")]
    public class AutomationPracticeTests : BaseTest
    {
        // Attributes
        private readonly string baseURL = "http://automationpractice.com/index.php";
        private AutomationPracticeHomePage apHomePage;
        private AutomationPracticeAuthenticationPage apAuthenticationPage;
        private AutomationPracticeCreateAccountPage apCreateAccountPage;
        private AutomationPracticeMyAccountPage apMyAccountPage;

        // Properties
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        // Tests
        [Test(Description = "It creates a new user in the store")]
        [Order(1)]
        [AllureTag("create", "valid")]
        [AllureSuite("Automation Practice Tests")]
        public void CreateNewUserWithValidData()
        {
            // Storage of email address and password to use them in the following tests
            EmailAddress = Mocks.personalData[0].Email;
            Password = Mocks.personalData[0].Password;

            apHomePage = new AutomationPracticeHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillCreateAccount(EmailAddress);
            apAuthenticationPage.ClickOnCreateAccountButton();

            apCreateAccountPage = new AutomationPracticeCreateAccountPage(Driver);
            Assert.IsTrue(apCreateAccountPage.IsLoaded());
            apCreateAccountPage.FillRegisterForm(Mocks.personalData);
            apCreateAccountPage.ClickOnRegisterButton();

            apMyAccountPage = new AutomationPracticeMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
        }

        [Test(Description =("It logins successfully in the store with a valid user"))]
        [Order(2)]
        [AllureTag("login", "valid")]
        [AllureSuite("Automation Practice Tests")]
        public void LoginWithAValidUser()
        {
            apHomePage = new AutomationPracticeHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            apMyAccountPage = new AutomationPracticeMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
        }

        [Test(Description = ("It throws an error when the user attempts to login with an invalid user"))]
        [Order(3)]
        [AllureTag("login", "invalid")]
        [AllureSuite("Automation Practice Tests")]
        public void LoginWithAnInvalidUser()
        {
            apHomePage = new AutomationPracticeHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(Mocks.invalidPersonalData[0].Email, Mocks.invalidPersonalData[0].Password);
            apAuthenticationPage.ClickOnSignInButton();
            Assert.AreEqual(apAuthenticationPage.IsErrorBannerDisplayed(), "Authentication failed.");
        }

        [Test(Description = ("It logouts successfully"))]
        [Order(4)]
        [AllureTag("logout", "valid")]
        [AllureSuite("Automation Practice Tests")]
        public void LogoutWithAValidUser()
        {
            apHomePage = new AutomationPracticeHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            apMyAccountPage = new AutomationPracticeMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
            apHomePage.ClickOnSignOutButton();
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
        }

        [Test(Description = ("It adds multiple items to the shopping cart"))]
        [Order(5)]
        [AllureTag("cart")]
        [AllureSuite("Automation Practice Tests")]
        public void AddingMultipleItemsToCart()
        {
            apHomePage = new AutomationPracticeHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            apMyAccountPage = new AutomationPracticeMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
            apHomePage.ClickOnImageButton();

            List<string> clothes = new List<string> { "Faded Short Sleeve T-shirts", "Printed Dress" };


        }
    }
}
