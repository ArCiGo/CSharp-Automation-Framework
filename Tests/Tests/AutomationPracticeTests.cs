using NUnit.Framework;
using PageObjectModel.Pages;
using System.Collections.Generic;
using Tests.Data;

namespace Tests.Tests
{
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
        private AutomationPracticeShoppingCartSummaryPage apShoppingCartSummaryPage;
        private AutomationPracticeShoppingCartAddressesPage apShoppingCartAddressPage;
        private AutomationPracticeShoppingCartShippingPage apShoppingCartShippingPage;
        private AutomationPracticeShoppingCartPaymentMethodPage apShoppingCartPaymentMethodPage;
        private AutomationPracticeShoppingCartOrderSummaryBankwirePage apShoppingCartOrderSummaryBWP;
        private AutomationPracticeShoppingCartOrderConfirmationPage apShoppingCartOrderConfirmationPage;

        // Properties
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        // Tests
        [Test(Description = "It creates a new user in the store")]
        [Order(1)]
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
        public void AddingMultipleItemsToCart()
        {
            List<string> clothes = new List<string> { "Faded Short Sleeve T-shirts", "Printed Chiffon Dress" };

            apHomePage = new AutomationPracticeHomePage(Driver);
            apHomePage.GoTo(baseURL);
            Assert.IsTrue(apHomePage.IsLoaded());
            apHomePage.AddItemsToCart(clothes);
            apHomePage.ClickOnCartLinkButton();

            apShoppingCartSummaryPage = new AutomationPracticeShoppingCartSummaryPage(Driver);
            Assert.True(apShoppingCartSummaryPage.IsLoaded());
            Assert.IsTrue(apShoppingCartSummaryPage.IsOnShoppingCart(clothes));
            apShoppingCartSummaryPage.ClickOnCheckoutButton();

            apAuthenticationPage = new AutomationPracticeAuthenticationPage(Driver);
            Assert.True(apAuthenticationPage.IsLoaded());
            apAuthenticationPage.FillSignInForm("eduardo.gonzalez@wolterskluwer.com", "Pa$$w0rd!");
            apAuthenticationPage.ClickOnSignInButton();

            apShoppingCartAddressPage = new AutomationPracticeShoppingCartAddressesPage(Driver);
            Assert.True(apShoppingCartAddressPage.IsLoaded());
            apShoppingCartAddressPage.ClickOnCheckOutButton();

            apShoppingCartShippingPage = new AutomationPracticeShoppingCartShippingPage(Driver);
            Assert.True(apShoppingCartShippingPage.IsLoaded());
            apShoppingCartShippingPage.CheckTermsOfServiceCheckbox();
            apShoppingCartShippingPage.ClickOnCheckoutButton();

            apShoppingCartPaymentMethodPage = new AutomationPracticeShoppingCartPaymentMethodPage(Driver);
            Assert.True(apShoppingCartPaymentMethodPage.IsLoaded());
            apShoppingCartPaymentMethodPage.ClickOnBankwireButton();

            apShoppingCartOrderSummaryBWP = new AutomationPracticeShoppingCartOrderSummaryBankwirePage(Driver);
            Assert.True(apShoppingCartOrderSummaryBWP.IsLoaded());
            apShoppingCartOrderSummaryBWP.ClickOnConfirmOrderButton();

            apShoppingCartOrderConfirmationPage = new AutomationPracticeShoppingCartOrderConfirmationPage(Driver);
            Assert.True(apShoppingCartOrderConfirmationPage.IsLoaded());
            Assert.AreEqual("Your order on My Store is complete.", apShoppingCartOrderConfirmationPage.GetOrderConfirmationText());
        }
    }
}
