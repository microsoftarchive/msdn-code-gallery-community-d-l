using Microsoft.SharePoint.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Threading.Tasks;

namespace InvokeSharePointRestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> result = getWebTitle("https://zsis376.sharepoint.com");
            result.Wait();

            Console.WriteLine(result.Result);
            Console.ReadLine();
        }

        /// <summary>
        /// Return the JSON result containing the web tiltle
        /// </summary>
        /// <param name="webUrl"></param>
        /// <returns></returns>
        private static async Task<string>getWebTitle(string webUrl)
        {
            //Creating Password
            const string PWD = "xxxx.1";
            const string USER = "bubu@zsis376.onmicrosoft.com";
            const string RESTURL = "{0}/_api/web?$select=Title";

            //Creating Credentials
            var passWord = new SecureString();
            foreach (var c in PWD) passWord.AppendChar(c);
            var credential = new SharePointOnlineCredentials(USER, passWord);

            //Creating Handler to allows the client to use credentials and cookie
            using (var handler = new HttpClientHandler() { Credentials = credential })
            {
                //Getting authentication cookies
                Uri uri = new Uri(webUrl);
                handler.CookieContainer.SetCookies(uri, credential.GetAuthenticationCookie(uri));

                //Invoking REST API
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(string.Format(RESTURL, webUrl)).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonData = await response.Content.ReadAsStringAsync();

                    return jsonData;
                }
            }
        }
    }
}
