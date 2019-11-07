// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.Service.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace AzureMobile.Samples.FieldEngineer.Service.Test
{
    [TestClass]
    public class ApiTests
    {
        static HttpClient client;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Validate that the site is running locally
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var resp = client.GetAsync(Common.LocalhostAddress).Result)
            {
                resp.EnsureSuccessStatusCode();
                Assert.IsNotNull(resp.Content);
                Assert.AreEqual("text/html", resp.Content.Headers.ContentType.MediaType);
            }
        }

        [TestMethod]
        public async Task GetFieldAgentDisplayName_ReturnsLocalUser()
        {
            using (var resp = await client.GetAsync(Common.LocalhostAddress + "/api/getFieldAgentDisplayName"))
            {
                resp.EnsureSuccessStatusCode();
                Assert.IsNotNull(resp.Content);
                var contentJson = await resp.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<string>(contentJson);
                Assert.AreEqual(Common.LocalUserName, content);
            }
        }

        [TestMethod]
        public async Task GetVersion_ReturnsFieldEngineerServiceAssemblyVersion()
        {
            using (var resp = await client.GetAsync(Common.LocalhostAddress + "/api/version"))
            {
                resp.EnsureSuccessStatusCode();
                Assert.IsNotNull(resp.Content);
                var contentJson = await resp.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<string>(contentJson);
                var expected = typeof(JobController).Assembly.GetName().Version.ToString();
                Assert.AreEqual(expected, content);
            }
        }
    }
}
