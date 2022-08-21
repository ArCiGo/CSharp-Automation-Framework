using OpenQA.Selenium;
using PageObjectModel.Components.Results;

namespace PageObjectModel.Pages
{
    public class GoogleResultsPage : BasePage
    {
        // Attributes
        private readonly ResultsBodyComponent resultsBodyComponent;

        // Constructor

        public GoogleResultsPage(IWebDriver driver) : base(driver)
        {
            resultsBodyComponent = new ResultsBodyComponent(driver);
        }

        // Actions

        public bool ResultsLabelIsLoaded()
        {
            return resultsBodyComponent.ResultsLabelIsLoaded();
        }
    }
}
