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
            EmailAddress = Mocks.personalData[0].Email;
            Password = Mocks.personalData[0].Password;

            apHomePage = new APHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new APAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillCreateAccount(EmailAddress);
            apAuthenticationPage.ClickOnCreateAccountButton();

            apCreateAccountPage = new APCreateAccountPage(Driver);
            Assert.IsTrue(apCreateAccountPage.IsLoaded());
            apCreateAccountPage.FillRegisterForm(Mocks.personalData);
            apCreateAccountPage.ClickOnRegisterButton();

            apMyAccountPage = new APMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
        }

        [Test(Description ="It logins successfully in the store with a valid user"), Category("UI")]
        [Order(2)]
        public void LoginWithAValidUser()
        {
            apHomePage = new APHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new APAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            apMyAccountPage = new APMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
        }

        [Test(Description = "It throws an error when the user attempts to login with an invalid user"), Category("UI")]
        [Order(3)]
        public void LoginWithAnInvalidUser()
        {
            apHomePage = new APHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new APAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(Mocks.invalidPersonalData[0].Email, Mocks.invalidPersonalData[0].Password);
            apAuthenticationPage.ClickOnSignInButton();
            Assert.AreEqual(apAuthenticationPage.IsErrorBannerDisplayed(), "Authentication failed.");
        }

        [Test(Description = "It logouts successfully"), Category("UI")]
        [Order(4)]
        public void LogoutWithAValidUser()
        {
            apHomePage = new APHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.ClickOnSignInButton();

            apAuthenticationPage = new APAuthenticationPage(Driver);
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm(EmailAddress, Password);
            apAuthenticationPage.ClickOnSignInButton();

            apMyAccountPage = new APMyAccountPage(Driver);
            Assert.IsTrue(apMyAccountPage.IsLoaded());
            apHomePage.ClickOnSignOutButton();
            Assert.IsTrue(apAuthenticationPage.IsLoaded());
        }

        [Test(Description = "It adds multiple items to the shopping cart"), Category("UI")]
        [Order(5)]
        public void AddingMultipleItemsToCart()
        {
            List<string> clothes = new List<string> { "Faded Short Sleeve T-shirts", "Printed Chiffon Dress" };

            apHomePage = new APHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.AddItemsToCart(clothes);
            apHomePage.ClickOnCartLinkButton();

            apShoppingCartSummaryPage = new APShoppingCartSummaryPage(Driver);
            Assert.True(apShoppingCartSummaryPage.IsLoaded());
            Assert.IsTrue(apShoppingCartSummaryPage.IsOnShoppingCart(clothes));
            apShoppingCartSummaryPage.ClickOnCheckoutButton();

            apAuthenticationPage = new APAuthenticationPage(Driver);
            Assert.True(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm("eduardo.gonzalez@wolterskluwer.com", "Pa$$w0rd!");
            apAuthenticationPage.ClickOnSignInButton();

            apShoppingCartAddressPage = new APShoppingCartAddressesPage(Driver);
            Assert.True(apShoppingCartAddressPage.IsLoaded());
            apShoppingCartAddressPage.ClickOnCheckOutButton();

            apShoppingCartShippingPage = new APShoppingCartShippingPage(Driver);
            Assert.True(apShoppingCartShippingPage.IsLoaded());
            apShoppingCartShippingPage.CheckTermsOfServiceCheckbox();
            apShoppingCartShippingPage.ClickOnCheckoutButton();

            apShoppingCartPaymentMethodPage = new APShoppingCartPaymentMethodPage(Driver);
            Assert.True(apShoppingCartPaymentMethodPage.IsLoaded());
            apShoppingCartPaymentMethodPage.ClickOnBankwireButton();

            apShoppingCartOrderSummaryBWP = new APShoppingCartOrderSummaryBankwirePage(Driver);
            Assert.True(apShoppingCartOrderSummaryBWP.IsLoaded());
            apShoppingCartOrderSummaryBWP.ClickOnConfirmOrderButton();

            apShoppingCartOrderConfirmationPage = new APShoppingCartOrderConfirmationPage(Driver);
            Assert.True(apShoppingCartOrderConfirmationPage.IsLoaded());
            Assert.AreEqual("Your order on My Store is complete.", apShoppingCartOrderConfirmationPage.GetOrderConfirmationText());
        }
    }
}
