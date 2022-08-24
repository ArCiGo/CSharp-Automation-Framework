using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Pages;
using Serilog;
using System;
using Tests.AutomationResources;
using Tests.Utilities;

namespace Tests
{
    public class BaseTest : ExtentReportsHelpers
    {
        // Attributes
        protected string baseURL;

        // Properties
        protected IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        protected APHomePage apHomePage;
        protected APAuthenticationPage apAuthenticationPage;
        protected APCreateAccountPage apCreateAccountPage;
        protected APMyAccountPage apMyAccountPage;
        protected APShoppingCartSummaryPage apShoppingCartSummaryPage;
        protected APShoppingCartAddressesPage apShoppingCartAddressPage;
        protected APShoppingCartShippingPage apShoppingCartShippingPage;
        protected APShoppingCartPaymentMethodPage apShoppingCartPaymentMethodPage;
        protected APShoppingCartOrderSummaryBankwirePage apShoppingCartOrderSummaryBWP;
        protected APShoppingCartOrderConfirmationPage apShoppingCartOrderConfirmationPage;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("Tests"));
            var projectPath = new Uri(actualPath).LocalPath;
            var reportPath = projectPath + "/UIReports/" + DateTime.Now.ToString("s") + "/UITestReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(projectPath + "/UIlogs-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        [SetUp]
        public void Setup()
        {
            Log.Information("SetUp has started");

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var factory = new WebDriverFactory();
            Driver = factory.GetDriver(BrowserType.Chrome);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.Manage().Window.Maximize();

            InitSetup();
        }

        public void InitSetup()
        {
            apHomePage = new APHomePage(Driver);
            apAuthenticationPage = new APAuthenticationPage(Driver);
            apCreateAccountPage = new APCreateAccountPage(Driver);
            apMyAccountPage = new APMyAccountPage(Driver);
            apShoppingCartSummaryPage = new APShoppingCartSummaryPage(Driver);
            apShoppingCartAddressPage = new APShoppingCartAddressesPage(Driver);
            apShoppingCartShippingPage = new APShoppingCartShippingPage(Driver);
            apShoppingCartPaymentMethodPage = new APShoppingCartPaymentMethodPage(Driver);
            apShoppingCartOrderSummaryBWP = new APShoppingCartOrderSummaryBankwirePage(Driver);
            apShoppingCartOrderConfirmationPage = new APShoppingCartOrderConfirmationPage(Driver);

            baseURL = "http://automationpractice.com/index.php";
        }

        [TearDown]
        public void CleanUp()
        {
            Log.Information("CleanUp has started");

            try
            {
                var outcome = TestContext.CurrentContext.Result.Outcome;
                var message = TestContext.CurrentContext.Result.Message;
                RecordTestOutcomeToExtent(test, outcome, message);

                StopBrowser();
                extent.Flush();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Source);
                Log.Error(ex.StackTrace);
                Log.Error(ex.InnerException.ToString());
                Log.Error(ex.Message);
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Close();
            Driver.Quit();
            Driver = null;

            Log.Information("Browser stopped successfully");
        }

        public override void RecordTestOutcomeToExtent(ExtentTest test, ResultState outcome, string message)
        {
            MediaEntityModelProvider mediaEntity;
            string fileName = "Screenshot_" + DateTime.Now.ToString("dd’-‘MM’-‘yyyy’T’HH’:’mm’:’ss") + test + ".png";

            if (outcome == ResultState.Success)
            {
                test.Pass("Test passed");
                mediaEntity = CaptureScreenShot(Driver, fileName);
                test.Pass("ExtentReport 4 Capture: Test Passed (click on button)", mediaEntity);
            }
            else if (outcome == ResultState.Failure)
            {
                test.Fail(message);
                Log.Error("Fail: " + message);
                mediaEntity = CaptureScreenShot(Driver, fileName);
                test.Fail("ExtentReport 4 Capture: Test Failed (click on button)", mediaEntity);
            }
            else if (outcome == ResultState.Error)
            {
                test.Error(message);
                Log.Error("Error: " + message);
                mediaEntity = CaptureScreenShot(Driver, fileName);
                test.Fail("ExtentReport 4 Capture: There was an error executing the test (click on button)", mediaEntity);
            }
            else if (outcome == ResultState.Inconclusive)
            {
                test.Skip(message);
            }
            else
            {
                test.Warning(message);
            }
        }

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}