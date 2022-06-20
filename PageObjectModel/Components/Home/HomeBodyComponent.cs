using OpenQA.Selenium;
using PageObjectModel.Pages;

namespace PageObjectModel.Components.Home
{
    public class HomeBodyComponent : GoogleComponent
    {
        // Attributes

        // Elements

        public IWebElement InputSearchField => Driver.FindElement(By.XPath("//form[@action='/search']/descendant::input[@name='q']"));

        // Constructor

        public HomeBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions

        public GoogleResultsPage FillSearchForm(string search)
        {
            InputSearchField.Clear();
            InputSearchField.SendKeys(search + Keys.Enter);

            return new GoogleResultsPage(Driver);
        }
    }
}
