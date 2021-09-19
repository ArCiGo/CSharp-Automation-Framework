using CsvHelper;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Linq;
using System.Net;
using Tests.Client;
using Tests.Models;
using Tests.Utilities;

namespace Tests.Tests
{
    /*
     * These tests read data from different resources: JSON (from a fake API) and CSV
     */
    [TestFixture]
    class SampleDataTests
    {
        private PokeAPIClient pokeAPIClient = new PokeAPIClient();
        private JsonDeserializer deserializer = new JsonDeserializer();

        [Test(Description = "Gets the data of the Pokemon requested based on its ID")]
        [Category("JSON Sample Test")]
        public void GetPokemon()
        {
            IRestResponse getPokemonResponse = pokeAPIClient.GetPokemon(1);
            PokeAPIPokemonModel values = deserializer.Deserialize<PokeAPIPokemonModel>(getPokemonResponse);

            Assert.AreEqual(HttpStatusCode.OK, getPokemonResponse.StatusCode);
            Assert.AreEqual("overgrow", values.Abilities[0]["ability"]["name"]);
            Assert.IsFalse(values.Abilities[0]["is_hidden"]);

            // Once the data is retrieved, it can be stored into variables and pass it into methods (or tests)
        }

        [Test(Description = "Gets the data stored in a CSV file")]
        [Category("CSV Sample Test")]
        public void GetCSV()
        {
            DateTime date = new DateTime(2021, 06, 01);
            string filePath = @"your/awesome/path/YourAwesomeFile.csv";
            CsvReader csvReader = Utils.CSVReaderFile(filePath);

            var records = csvReader.GetRecords<MockarooFakeModel>().ToList();

            Assert.AreEqual("Bethena", records[2].FirstName);
            Assert.AreEqual(date, records[4].Date);

            // Once the data is retrieved, it can be stored into variables and pass it into methods (or tests)
        }
    }
}
