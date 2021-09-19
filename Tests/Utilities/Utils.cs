using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Tests.Utilities
{
    /*
     * Here goes your custom methods to use in your tests,
     * like random generator of numbers/strings/alphanumerics
     * etcetera
     */
    public class Utils
    {
        public static CsvReader CSVReaderFile(string filePath)
        {
            var streamReader = new StreamReader(filePath);
            var csvConfig = new CsvConfiguration(new CultureInfo("es-MX"))
            {
                // Delimiter = ";"
            };
            var csvReader = new CsvReader(streamReader, csvConfig);

            return csvReader;
        }
    }
}
