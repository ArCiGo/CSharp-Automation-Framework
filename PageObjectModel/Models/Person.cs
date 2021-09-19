using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel.Models
{
    public class Person
    {
        public Title Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string FirstNameAddress { get; set; }

        public string LastNameAddress { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public string Country { get; set; }

        public string AdditionalInformation { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string AddressAlias { get; set; }
    }
}
