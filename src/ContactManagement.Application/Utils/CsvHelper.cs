using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;

namespace ContactManagement.Application.Utils;

/// <summary>
/// Helper class for reading CSV files and converting them to a list of objects of type T.
/// The ReadCsvAsync method takes an IFormFile representing the CSV file, reads its contents, and uses the CsvHelper library to parse the CSV data into a list of objects of type T. The CsvConfiguration is set to ignore header validation and missing fields to allow for more flexible CSV formats.
/// </summary>
public static class CsvHelper
{
    /// <summary>
    /// Reads a CSV file and converts it to a list of objects of type T.
    /// </summary> 
    /// <typeparam name="T">The type of objects to convert the CSV data into. Must be a class with a parameterless constructor.</typeparam>
    /// <param name="csvFile">The IFormFile representing the CSV file to read.</param>
    /// <returns>A list of objects of type T containing the data from the CSV file.</returns>
    public static List<T> ReadCsv<T>(IFormFile csvFile)
    {
        var result = new List<T>();

        using (var stream = new StreamReader(csvFile.OpenReadStream()))
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };
            using (var csv = new CsvReader(stream, config))
            {
                result = [.. csv.GetRecords<T>()];
            }
        }
        return result;
    }
}
