using System;
using System.Json;
using System.Net.Http;

namespace WorldBankSample
{
    /// <summary>
    /// Sample download list of countries from the World Bank Data sources at http://data.worldbank.org/
    /// </summary>
    class Program
    {
        static string _address = "http://api.worldbank.org/countries?format=json";

        static void Main(string[] args)
        {
            // Create an HttpClient instance
            HttpClient client = new HttpClient();

            // Send a request asynchronously continue when complete
            client.GetAsync(_address).ContinueWith(
                (requestTask) =>
                {
                    // Get HTTP response from completed task.
                    HttpResponseMessage response = requestTask.Result;

                    // Check that response was successful or throw exception
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously as JsonValue and write out top facts for each country
                    response.Content.ReadAsAsync<JsonArray>().ContinueWith(
                        (readTask) =>
                        {
                            Console.WriteLine("First 50 countries listed by The World Bank...");
                            foreach (var country in readTask.Result[1])
                            {
                                Console.WriteLine("   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
                                    country.Value["name"],
                                    country.Value["iso2Code"],
                                    country.Value["capitalCity"],
                                    country.Value["latitude"],
                                    country.Value["longitude"]);
                            }
                        });
                });

            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
    }
}
