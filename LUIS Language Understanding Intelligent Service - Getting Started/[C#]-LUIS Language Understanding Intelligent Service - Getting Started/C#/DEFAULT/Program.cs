using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using System.Web;
using static System.Console;

namespace DEFAULT
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string contextId = "";
                WriteLine();
                Write("Hi, my name is DEFAULT, please be aware that I am a Bot, how can I help you?  ");
                string question = ReadLine();
                LUISResponse luisResponse = new LUISResponse();

                Task.Run(async () =>
                {
                    WriteLine();
                    luisResponse = await askLUIS(question, contextId);
                    WriteLine(JsonConvert.SerializeObject(luisResponse));
                    WriteLine();
                }).Wait();
                while (luisResponse?.dialog?.prompt?.Length > 0)
                {
                    Write(luisResponse.dialog.prompt + "  ");
                    contextId = luisResponse.dialog.contextId;
                    question = question + " " + ReadLine();
                    Task.Run(async () =>
                    {
                        WriteLine();
                        luisResponse = await askLUIS(question, contextId);
                        WriteLine(JsonConvert.SerializeObject(luisResponse));
                        WriteLine();
                    }).Wait();
                }
                //Check status
                ReadLine();
            }
            catch (Exception ex)
            {
                WriteLine("An exception happened: " + ex.Message + " with an inner exception of: " + ex.InnerException);
                ReadLine();
            }
        }

        static async Task<LUISResponse> askLUIS(string question, string contextId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.projectoxford.ai");
                #region LIVE
                //string id = "ADD YOUR LUID ID";
                //string subscriptionKey = "ADD THE SUBSCRIPTION KEY";
                //HttpResponseMessage response =
                //await client.GetAsync($"/luis/v1/application?id={id}&subscription-key={subscriptionKey}&q={question}");
                //if (!response.IsSuccessStatusCode)
                //{
                //    //return $"LUIS did not respond as expected on " + DateTime.Now.ToString();
                //}
                #endregion
                #region PREVIEW
                string id = "ADD YOUR LUID ID";
                string subscriptionKey = "ADD THE SUBSCRIPTION KEY";
                string requestUri = "";

                if (contextId == "")
                {
                    requestUri = $"/luis/v1/application/preview?id={id}&subscription-key={subscriptionKey}&q={question}";
                }
                else
                {
                    requestUri = $"/luis/v1/application/preview?id={id}&subscription-key={subscriptionKey}&q={question}&contextId={contextId}";
                }

                //WriteLine(question);
                //WriteLine();
                //WriteLine(contextId);

                HttpResponseMessage response = await client.GetAsync(requestUri);
                #endregion
                //var js = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()).ToString();
                //var jsonString = JsonConvert.DeserializeObject<LUISResponse>(await response.Content.ReadAsStringAsync());
                //var js = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()).ToString();
                //return $"The response from LUIS was {response.StatusCode.ToString()}";
                //return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()).ToString();
                return JsonConvert.DeserializeObject<LUISResponse>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
