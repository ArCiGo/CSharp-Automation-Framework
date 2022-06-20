using OpenQA.Selenium;

namespace PageObjectModel.Components
{
    public class GoogleComponent
    {
        protected IWebDriver Driver { get; set; }

        public GoogleComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
