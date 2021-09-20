using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjectModel.Models;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Tests
{
    [AllureNUnit]
    [TestFixture]
    [Category("Automation Practice Sample Tests")]
    public class AutomationPracticeTests : BaseTest
    {
        private readonly string baseURL = "http://automationpractice.com/index.php";

        [Test(Description = "It creates a new user in the store")]
        [AllureTag()]
        [AllureSuite("Automation Practice Tests")]
        public void CreateNewUser_Test()
        {
            List<Person> personalData = new List<Person>()
            {
                new Person()
                {
                    Title = Title.Mr,
                    FirstName = "Armando",
                    LastName= "Cifuentes",
                    Email = "armando.cifuentes@arcigo.mx",
                    Password = "password",
                    Day = "25",
                    Month = "July",
                    Year = "1992",
                    FirstNameAddress = "Eduardo",
                    LastNameAddress = "Videgaray",
                    Company = "ArCiGo Company",
                    Address = "777 Brockton Avenue, Abington MA 2351",
                    AddressLine2 = "30 Memorial Drive, Avon MA 2322",
                    City = "Avon",
                    State = "Massachusetts",
                    ZipCode = 11111,
                    Country = "United States",
                    AdditionalInformation = "Some amazing additional information",
                    HomePhone = "+521(123)456-78-90",
                    MobilePhone = "+521(098)765-43-21",
                    AddressAlias = "Some amazing alias"
                }
            };

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
            automationPracticeCreateAccountPage.FillRegisterForm(personalData);
            automationPracticeCreateAccountPage.ClickOnRegisterButton();

            AutomationPracticeMyAccountPage automationPracticeMyAccountPage = new AutomationPracticeMyAccountPage(Driver);
            Assert.IsTrue(automationPracticeMyAccountPage.IsLoaded());
        }
    }
}
