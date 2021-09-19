using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components
{
    public class AutomationPracticeComponent
    {
        protected IWebDriver Driver { get; set; }

        public AutomationPracticeComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
