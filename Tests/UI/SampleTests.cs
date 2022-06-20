using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel.Pages;

namespace Tests.UI
{
    [AllureNUnit]
    [TestFixture]
    [Category("UI Sample Tests")]
    public class SampleTests : BaseTest
    {
        private readonly string baseURL = "https://www.google.com/";
        private readonly string search = "Tampico";

        [Test(Description = "This is a sample test")]
        [AllureTag("Sample")]
        [AllureSuite("UI Sample Tests")]
        public void Test1()
        {
            Driver.Navigate().GoToUrl(baseURL);

            Driver.FindElement(By.XPath("//form[@action='/search']/descendant::input[@name='q']")).SendKeys(search + Keys.Enter);
            var resultsText = Driver.FindElement(By.XPath("//div[@id='result-stats']"));
            
            Assert.IsTrue(resultsText.Displayed);
        }

        [Test(Description = "This is a sample test using POM and components")]
        [AllureTag("Sample")]
        [AllureSuite("UI Sample Tests")]
        public void Test2()
        {
            GoogleHomePage googleHomePage = new GoogleHomePage(Driver);
            googleHomePage.GoTo(baseURL);
            
            Assert.IsTrue(googleHomePage.IsLoaded());

            googleHomePage.FillSearchForm(search);

            GoogleResultsPage googleResultsPage = new GoogleResultsPage(Driver);
            Assert.IsTrue(googleResultsPage.IsLoaded());
            Assert.IsTrue(googleResultsPage.ResultsLabelIsLoaded());
        }

        [Test(Description = "This sample test should fail for the screenshot")]
        [AllureTag("Sample")]
        [AllureSuite("UI Sample Tests")]
        public void Test3()
        {
            Driver.Navigate().GoToUrl(baseURL);

            Driver.FindElement(By.Id("sample"));
        }
    }
}
