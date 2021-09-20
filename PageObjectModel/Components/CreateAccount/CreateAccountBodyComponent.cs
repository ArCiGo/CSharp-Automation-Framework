using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Models;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Components.CreateAccount
{
    public class CreateAccountBodyComponent : AutomationPracticeComponent
    {
        // Attributes
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement TitleLabel => Driver.FindElement(By.ClassName("page-heading"));
        public IWebElement MrRadioButton => Driver.FindElement(By.Id("id_gender1"));
        public IWebElement MrsRadioButton => Driver.FindElement(By.Id("id_gender2"));
        public IWebElement FirstNameInput => Driver.FindElement(By.Id("customer_firstname"));
        public IWebElement LastNameInput => Driver.FindElement(By.Id("customer_lastname"));
        public IWebElement EmailInput => Driver.FindElement(By.Id("email"));
        public IWebElement PasswordInput => Driver.FindElement(By.Id("passwd"));
        
        public IWebElement DaySelect => Driver.FindElement(By.Id("days"));
        public SelectElement DaySelectElement;
        public IList<IWebElement> DayOptions;
        
        public IWebElement MonthSelect => Driver.FindElement(By.Id("months"));
        public SelectElement MonthSelectElement;
        public IList<IWebElement> MonthOptions;

        public IWebElement YearSelect => Driver.FindElement(By.Id("years"));
        public SelectElement YearSelectElement;
        public IList<IWebElement> YearOptions;

        public IWebElement AddressFirstNameInput => Driver.FindElement(By.Id("firstname"));
        public IWebElement AddressLastNameInput => Driver.FindElement(By.Id("lastname"));
        public IWebElement CompanyInput => Driver.FindElement(By.Id("company"));
        public IWebElement AddressInput => Driver.FindElement(By.Id("address1"));
        public IWebElement AddressLine2Input => Driver.FindElement(By.Id("address2"));
        public IWebElement CityInput => Driver.FindElement(By.Id("city"));
        
        public IWebElement StateSelect => Driver.FindElement(By.Id("id_state"));
        public SelectElement StateSelectElement;
        public IList<IWebElement> StateOptions;

        public IWebElement ZipCodeInput => Driver.FindElement(By.Id("postcode"));
        
        public IWebElement CountrySelect => Driver.FindElement(By.Id("id_country"));
        public SelectElement CountrySelectElement;
        public IList<IWebElement> CountryOptions;

        public IWebElement AdditionalInformationTextarea => Driver.FindElement(By.Id("other"));
        public IWebElement HomePhone => Driver.FindElement(By.Id("phone"));
        public IWebElement MobilePhone => Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement Alias => Driver.FindElement(By.Id("alias"));
        public IWebElement RegiterButton => Driver.FindElement(By.Id("submitAccount"));

        // Constructor
        public CreateAccountBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public bool IsLoaded()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[@class='page-heading'][contains(text(), 'Create')]"))).Displayed;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Source);
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
                logger.Error(ex.Message);

                return false;
            }
        }

        public bool TitleRadioButtonsIsLoaded()
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("id_gender1"))).Displayed;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Source);
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
                logger.Error(ex.Message);

                return false;
            }
        }

        public void FillRegisterForm(List<Person> personalData)
        {
            SelectTitle(personalData[0].Title);

            FirstNameInput.Clear();
            FirstNameInput.SendKeys(personalData[0].FirstName);

            LastNameInput.Clear();
            LastNameInput.SendKeys(personalData[0].LastName);

            EmailInput.Clear();
            EmailInput.SendKeys(personalData[0].Email);

            PasswordInput.Clear();
            PasswordInput.SendKeys(personalData[0].Password);

            SetDay(personalData[0].Day);

            SetMonth(personalData[0].Month);

            SetYear(personalData[0].Year);

            AddressFirstNameInput.Clear();
            AddressFirstNameInput.SendKeys(personalData[0].FirstNameAddress);

            AddressLastNameInput.Clear();
            AddressLastNameInput.SendKeys(personalData[0].LastNameAddress);

            CompanyInput.Clear();
            CompanyInput.SendKeys(personalData[0].Company);

            AddressInput.Clear();
            AddressInput.SendKeys(personalData[0].Address);

            AddressLine2Input.Clear();
            AddressLine2Input.SendKeys(personalData[0].AddressLine2);

            CityInput.Clear();
            CityInput.SendKeys(personalData[0].City);

            SetState(personalData[0].State);

            ZipCodeInput.Clear();
            ZipCodeInput.SendKeys(personalData[0].ZipCode.ToString());

            SetCountry(personalData[0].Country);

            AdditionalInformationTextarea.Clear();
            AdditionalInformationTextarea.SendKeys(personalData[0].AdditionalInformation);

            HomePhone.Clear();
            HomePhone.SendKeys(personalData[0].HomePhone);

            MobilePhone.Clear();
            MobilePhone.SendKeys(personalData[0].MobilePhone);

            Alias.Clear();
            Alias.SendKeys(personalData[0].AddressAlias);
        }

        private void SelectTitle(Title title)
        {
            TitleRadioButtonsIsLoaded();

            switch (title)
            {
                case Title.Mr:
                    MrRadioButton.Click();
                    break;
                case Title.Mrs:
                    MrsRadioButton.Click();
                    break;
                default:
                    ArgumentException ex = new ArgumentException("No such option exists!");
                    logger.Error(ex.Source);
                    logger.Error(ex.StackTrace);
                    logger.Error(ex.InnerException);
                    logger.Error(ex.Message);

                    throw ex;
            }
        }

        private void SetDay(string day)
        {
            DaySelectElement = new SelectElement(DaySelect);
            DayOptions = DaySelectElement.Options;

            foreach (IWebElement item in DayOptions)
            {
                if (item.GetAttribute("value").Contains(day))
                {
                    DaySelectElement.SelectByValue(day);
                }
            }
        }

        private void SetMonth(string month)
        {
            MonthSelectElement = new SelectElement(MonthSelect);
            MonthOptions = MonthSelectElement.Options;

            foreach (IWebElement item in MonthOptions)
            {
                if (item.Text.Trim().Contains(month))
                {
                    MonthSelectElement.SelectByText(month, true);
                }
            }
        }

        private void SetYear(string year)
        {
            YearSelectElement = new SelectElement(YearSelect);
            YearOptions = YearSelectElement.Options;

            foreach (IWebElement item in YearOptions)
            {
                if (item.GetAttribute("value").Contains(year))
                {
                    YearSelectElement.SelectByValue(year);
                }
            }
        }

        private void SetState(string state)
        {
            StateSelectElement = new SelectElement(StateSelect);
            StateOptions = StateSelectElement.Options;

            foreach (IWebElement item in StateOptions)
            {
                if (item.Text.Contains(state))
                {
                    StateSelectElement.SelectByText(state);
                }
            }
        }

        private void SetCountry(string country) 
        {
            CountrySelectElement = new SelectElement(CountrySelect);
            CountryOptions = CountrySelectElement.Options;

            foreach (IWebElement item in CountryOptions)
            {
                if (item.Text.Contains(country))
                {
                    CountrySelectElement.SelectByText(country);
                }
            }
        }

        public AutomationPracticeMyAccountPage ClickRegisterButton()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submitAccount"))).Click();

            return new AutomationPracticeMyAccountPage(Driver);
        }
    }
}
