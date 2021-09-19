using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models
{
    public class MockarooFakeModel
    {
        [Name("id")]
        public int ID { get; set; }

        [Name("first_name")]
        public string FirstName { get; set; }

        [Name("last_name")]
        public string LastName { get; set; }

        [Name("email")]
        public string Email { get; set; }

        [Name("gender")]
        public string Gender { get; set; }

        [Name("ip_address")]
        public string IPAddress { get; set; }

        [Name("date")]
        public DateTime Date { get; set; }
    }
}
