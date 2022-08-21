using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel.Pages;
using Serilog;

namespace Tests.UI
{
    [TestFixture]
    [Category("UI Sample Tests")]
    public class SampleTests : BaseTest
    {
        [Test(Description = "This is a sample test"), Category("UI")]
        [Order(1)]
        public void Test1()
        {
            Log.Information("Enter to Test 1");

            Driver.Navigate().GoToUrl(baseURL);

            Driver.FindElement(By.XPath("//form[@action='/search']/descendant::input[@name='q']")).SendKeys(itemToSearch + Keys.Enter);
            var resultsText = Driver.FindElement(By.XPath("//div[@id='result-stats']"));
            
            Assert.IsTrue(resultsText.Displayed);
        }

        [Test(Description = "This is a sample test using POM and components")]
        [Order(2)]
        public void Test2()
        {
            Log.Information("Enter to Test 2");

            googleHomePage.GoTo(baseURL);
            googleHomePage.FillSearchForm(itemToSearch);

            Assert.IsTrue(googleResultsPage.ResultsLabelIsLoaded());
        }

        [Test(Description = "This sample test should fail for the screenshot")]
        [Order(3)]
        public void Test3()
        {
            Log.Information("Enter to Test 3");

            Driver.Navigate().GoToUrl(baseURL);

            Driver.FindElement(By.Id("sample"));
        }
    }
}
