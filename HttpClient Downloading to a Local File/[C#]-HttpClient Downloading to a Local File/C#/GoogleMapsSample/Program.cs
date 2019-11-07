using System;
using System.Diagnostics;
using System.Net.Http;

namespace GoogleMapsSample
{
    /// <summary>
    ///  Downloads a Redmond map from Google Map, saves it as a file and opens the default viewer.
    /// </summary>
    class Program
    {
        static string _address = "http://maps.googleapis.com/maps/api/staticmap?center=Redmond,WA&zoom=14&size=400x400&sensor=false";

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            // Send asynchronous request
            client.GetAsync(_address).ContinueWith(
                (requestTask) =>
                {
                    // Get HTTP response from completed task.
                    HttpResponseMessage response = requestTask.Result;

                    // Check that response was successful or throw exception
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously and save to file
                    response.Content.ReadAsFileAsync("output.png", true).ContinueWith(
                        (readTask) =>
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "output.png";
                            process.Start();
                        });
                });

            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
    }
}
