using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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
