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
    [Category("Automation Practice Sample Tests")]
    public class AutomationPracticeTests : BaseTest
    {
        // Attributes
        private readonly string baseURL = "http://automationpractice.com/index.php";
        
        // Properties
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        [Test(Description = "It creates a new user in the store")]
        [AllureTag()]
        [AllureSuite("Automation Practice Tests")]
        public void CreateNewUser_Test()
        {
            AutomationPracticeHomePage automationPracticeHomePage = new AutomationPracticeHomePage(Driver);
            automationPracticeHomePage.GoTo(baseURL);
            Assert.IsTrue(automationPracticeHomePage.IsLoaded());
            automationPracticeHomePage.ClickOnSignInButton();

            AutomationPracticeAuthenticationPage automationPracticeAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.IsTrue(automationPracticeAuthenticationPage.IsLoaded());
            automationPracticeAuthenticationPage.FillCreateAccount("samuel@test.com");
            automationPracticeAuthenticationPage.ClickOnCreateAccountButton();

            AutomationPracticeCreateAccountPage automationPracticeCreateAccountPage = new AutomationPracticeCreateAccountPage(Driver);
            Assert.IsTrue(automationPracticeCreateAccountPage.IsLoaded());
            automationPracticeCreateAccountPage.FillRegisterForm(Mocks.personalData);
            automationPracticeCreateAccountPage.ClickOnRegisterButton();

            AutomationPracticeMyAccountPage automationPracticeMyAccountPage = new AutomationPracticeMyAccountPage(Driver);
            Assert.IsTrue(automationPracticeMyAccountPage.IsLoaded());

            // Assigning the values to these properties to use them in following tests
            EmailAddress = Mocks.personalData[0].Email;
            Password = Mocks.personalData[0].Password;
        }
    }
}
