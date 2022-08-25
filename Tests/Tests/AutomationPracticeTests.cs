using NUnit.Framework;
using PageObjectModel.Pages;
using System.Collections.Generic;
using Tests.Data;

namespace Tests.Tests
{
    [TestFixture]
    public class AutomationPracticeTests : BaseTest
    {
        // Attributes

        // Properties
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        // Tests
        [Test(Description = "It creates a new user in the store"), Category("UI")]
        [Order(1)]
        public void CreateNewUserWithValidData()
        {
            // Storage of email address and password to use them in the following tests
            EmailAddress = Mocks.personalData.Email;
            Password = Mocks.personalData.Password;

            apHomePage.GoTo(baseURL);
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage.FillCreateAccount(EmailAddress);
            apAuthenticationPage.ClickOnCreateAccountButton();

            apCreateAccountPage.FillRegisterForm(Mocks.personalData);
            apCreateAccountPage.ClickOnRegisterButton();

            Assert.IsTrue(apMyAccountPage.IsLoaded());
        }

        [Test(Description ="It logins successfully in the store with a valid user"), Category("UI")]
        [Order(2)]
        public void LoginWithAValidUser()
        {
            apHomePage.GoTo(baseURL);
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            Assert.IsTrue(apMyAccountPage.IsLoaded());
        }

        [Test(Description = "It throws an error when the user attempts to login with an invalid user"), Category("UI")]
        [Order(3)]
        public void LoginWithAnInvalidUser()
        {
            apHomePage.GoTo(baseURL);
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage.FillSignInForm(Mocks.invalidPersonalData.Email, Mocks.invalidPersonalData.Password);
            apAuthenticationPage.ClickOnSignInButton();

            Assert.AreEqual(apAuthenticationPage.IsErrorBannerDisplayed(), "Authentication failed.");
        }

        [Test(Description = "It logouts successfully"), Category("UI")]
        [Order(4)]
        public void LogoutWithAValidUser()
        {
            apHomePage.GoTo(baseURL);
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            Assert.IsTrue(apMyAccountPage.IsLoaded());
            apHomePage.ClickOnSignOutButton();
        }

        [Test(Description = "It adds multiple items to the shopping cart"), Category("UI")]
        [Order(5)]
        public void AddingMultipleItemsToCart()
        {
            List<string> clothes = new List<string> { "Faded Short Sleeve T-shirts", "Printed Chiffon Dress" };

            apHomePage.GoTo(baseURL);
            apHomePage.AddItemsToCart(Mocks.clothes);
            apHomePage.ClickOnCartLinkButton();

            Assert.IsTrue(apShoppingCartSummaryPage.IsOnShoppingCart(Mocks.clothes));
            apShoppingCartSummaryPage.ClickOnCheckoutButton();

            apAuthenticationPage.FillSignInForm("eduardo.gonzalez@wolterskluwer.com", "Pa$$w0rd!");
            apAuthenticationPage.ClickOnSignInButton();

            apShoppingCartAddressPage.ClickOnCheckOutButton();

            apShoppingCartShippingPage.CheckTermsOfServiceCheckbox();
            apShoppingCartShippingPage.ClickOnCheckoutButton();

            apShoppingCartPaymentMethodPage.ClickOnBankwireButton();

            apShoppingCartOrderSummaryBWP.ClickOnConfirmOrderButton();

            Assert.True(apShoppingCartOrderConfirmationPage.IsLoaded());
            Assert.AreEqual("Your order on My Store is complete.", apShoppingCartOrderConfirmationPage.GetOrderConfirmationText());
        }
    }
}
