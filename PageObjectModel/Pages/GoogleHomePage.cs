using OpenQA.Selenium;
using PageObjectModel.Components.Home;

namespace PageObjectModel.Pages
{
    public class GoogleHomePage : BasePage
    {
        // Attributes
        private readonly HomeBodyComponent homeBodyComponent;

        // Constructor
        public GoogleHomePage(IWebDriver driver) : base(driver) 
        {
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public GoogleResultsPage FillSearchForm(string search)
        {
            return homeBodyComponent.FillSearchForm(search);
        }
    }
}
