using CsvHelper;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Linq;
using System.Net;
using Tests.APIAndData;
using Tests.APIAndData.Models;
using Tests.Utilities;

namespace Tests.APIAndData
{
    /*
     * These tests read data from different resources: JSON (from a fake API) and CSV
     */
    [TestFixture]
    public class SampleTests : BaseAPITest
    {
        private JsonDeserializer deserializer = new JsonDeserializer();

        // JSON Sample Test
        [Test(Description = "Gets the data of the Pokemon requested based on its ID"), Category("API")]
        public void GetPokemon()
        {
            IRestResponse getPokemonResponse = pokeAPIClient.GetPokemon(1);
            PokeAPIPokemonModel values = deserializer.Deserialize<PokeAPIPokemonModel>(getPokemonResponse);

            Assert.AreEqual(HttpStatusCode.OK, getPokemonResponse.StatusCode);
            Assert.AreEqual("overgrow", values.Abilities[0]["ability"]["name"]);
            Assert.IsFalse(values.Abilities[0]["is_hidden"]);

            // Once the data is retrieved, it can be stored into variables and pass it into methods (or tests)
        }

        // CSV Sample Test
        [Test(Description = "Gets the data stored in a CSV file"), Category("CSV")]
        public void GetCSV()
        {
            DateTime date = new DateTime(2021, 07, 10);
            string filePath = @"your/Awesome/Path/Data_1.csv";
            CsvReader csvReader = Utils.CSVReaderFile(filePath);

            var records = csvReader.GetRecords<MockarooFakeModel>().ToList();

            Assert.AreEqual("Gayle", records[2].FirstName);
            Assert.AreEqual(date, records[999].Date);

            // Once the data is retrieved, it can be stored into variables and pass it into methods (or tests)
        }
    }
}
