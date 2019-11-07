using System;
using System.Json;
using System.Net.Http;
using TwitterSample.OAuth;

namespace TwitterSample
{
    /// <summary>
    /// Sample illustrating how to write a simple twitter client using HttpClient. The sample uses a 
    /// HttpMessageHandler to insert the appropriate OAuth authentication information into the outgoing
    /// HttpRequestMessage. The result from twitter is read using JsonValue.
    /// </summary>
    class Program
    {
        static string _address = "http://api.twitter.com/1/statuses/user_timeline.json?include_entities=true&include_rts=true&screen_name=scottgu&count=5";

        static void Main(string[] args)
        {
            // Create client and insert an OAuth message handler in the message path that 
            // inserts an OAuth authentication header in the request
            HttpClient client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            // Send asynchronous request to twitter
            client.GetAsync(_address).ContinueWith(
                (requestTask) =>
                {
                    // Get HTTP response from completed task.
                    HttpResponseMessage response = requestTask.Result;

                    // Check that response was successful or throw exception
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously as JsonValue and write out tweet texts
                    response.Content.ReadAsAsync<JsonArray>().ContinueWith(
                        (readTask) =>
                        {
                            JsonArray statuses = readTask.Result;
                            Console.WriteLine("\nLast 5 statuses from ScottGu's twitter account:\n");
                            foreach (var status in statuses)
                            {
                                Console.WriteLine(status["text"] + "\n");
                            }
                        });
                });

            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
    }
}
