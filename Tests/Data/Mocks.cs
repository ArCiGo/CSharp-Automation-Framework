using Bogus;
using PageObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Data
{
    public class Mocks
    {
        private static readonly Faker aux = new Faker("en_US");

        public static List<PersonModel> personalData = new List<PersonModel>()
        {
            new PersonModel()
            {
                Title = Title.Mr,
                FirstName = aux.Name.FirstName(),
                LastName= aux.Name.LastName(),
                Email = aux.Internet.Email(),
                Password = aux.Internet.Password(),
                Day = "25",
                Month = "July",
                Year = "1992",
                FirstNameAddress = aux.Name.FirstName(),
                LastNameAddress = aux.Name.LastName(),
                Company = aux.Company.CompanyName(),
                Address = aux.Address.FullAddress(),
                AddressLine2 = aux.Address.SecondaryAddress(),
                City = aux.Address.City(),
                State = aux.Address.State(),
                ZipCode = "11111",
                Country = aux.Address.Country(),
                AdditionalInformation = aux.Lorem.Paragraph(),
                HomePhone = aux.Phone.PhoneNumberFormat(),
                MobilePhone = aux.Phone.PhoneNumberFormat(),
                AddressAlias = aux.Hacker.Adjective()            }
        };
    }
}
