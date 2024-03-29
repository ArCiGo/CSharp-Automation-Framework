﻿using Bogus;
using PageObjectModel.Models;
using System.Collections.Generic;

namespace Tests.Data
{
    public class Mocks
    {
        private static readonly Faker dataFaker = new Faker("en_US");

        public static PersonModel personalData = new PersonModel()
        {
            Title = Title.Mr,
            FirstName = dataFaker.Name.FirstName(),
            LastName= dataFaker.Name.LastName(),
            Email = dataFaker.Internet.Email(),
            Password = dataFaker.Internet.Password(),
            Day = "25",
            Month = "July",
            Year = "1992",
            FirstNameAddress = dataFaker.Name.FirstName(),
            LastNameAddress = dataFaker.Name.LastName(),
            Company = dataFaker.Company.CompanyName(),
            Address = dataFaker.Address.FullAddress(),
            AddressLine2 = dataFaker.Address.SecondaryAddress(),
            City = dataFaker.Address.City(),
            State = dataFaker.Address.State(),
            ZipCode = "11111",
            Country = dataFaker.Address.Country(),
            AdditionalInformation = dataFaker.Lorem.Sentence(),
            HomePhone = dataFaker.Phone.PhoneNumberFormat(),
            MobilePhone = dataFaker.Phone.PhoneNumberFormat(),
            AddressAlias = dataFaker.Hacker.Adjective()
        };

        public static PersonModel invalidPersonalData = new PersonModel()
        {
            Email = dataFaker.Internet.Email(),
            Password = dataFaker.Internet.Password()
        };

        public static List<string> clothes = new List<string>
        {
            "Faded Short Sleeve T-shirts", "Printed Chiffon Dress"
        };
    }
}