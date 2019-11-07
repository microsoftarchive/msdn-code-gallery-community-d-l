// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace AzureMobile.Samples.FieldEngineer.Service.Test
{
    [TestClass]
    public class EquipmentControllerTest
    {
        static HttpClient client;
        internal const string tableAddress = "/tables/equipment";

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestMethod]
        public async Task GetEquipment_ReturnsData()
        {
            var resp = await client.GetAsync(Common.LocalhostAddress + tableAddress);
            resp.EnsureSuccessStatusCode();
            Assert.IsNotNull(resp.Content);
            var contentJson = await resp.Content.ReadAsStringAsync();
            var items = JArray.Parse(contentJson);
            Assert.AreNotEqual(0, items.Count);
            resp.Dispose();

            var firstId = (string)items[0]["id"];
            resp = await client.GetAsync(Common.LocalhostAddress + tableAddress + "/" + firstId);
            resp.EnsureSuccessStatusCode();
            Assert.IsNotNull(resp.Content);
            contentJson = await resp.Content.ReadAsStringAsync();
            var item = JObject.Parse(contentJson);
            Assert.AreNotEqual(0, item.Properties().Count());
            resp.Dispose();
        }

        [TestMethod]
        public async Task GetSpecification_CanExpandSpecifications()
        {
            var resp = await client.GetAsync(Common.LocalhostAddress + tableAddress + "?$expand=equipmentSpecifications");
            resp.EnsureSuccessStatusCode();
            Assert.IsNotNull(resp.Content);
            var contentJson = await resp.Content.ReadAsStringAsync();
            var items = JArray.Parse(contentJson);
            Assert.AreNotEqual(0, items.Count);
            foreach (var item in items)
            {
                var specifications = item["equipmentSpecifications"];
                Assert.IsNotNull(specifications);
                Assert.IsInstanceOfType(specifications, typeof(JArray));
                Assert.AreNotEqual(0, ((JArray)specifications).Count);
            }
            resp.Dispose();

            var firstId = (string)items[0]["id"];
            resp = await client.GetAsync(Common.LocalhostAddress + tableAddress + "/" + firstId + "?$expand=equipmentSpecifications");
            resp.EnsureSuccessStatusCode();
            Assert.IsNotNull(resp.Content);
            contentJson = await resp.Content.ReadAsStringAsync();
            var singleItem = JObject.Parse(contentJson);
            Assert.AreNotEqual(0, singleItem.Properties().Count());
            var singleItemSpecifications = singleItem["equipmentSpecifications"];
            Assert.IsNotNull(singleItemSpecifications);
            Assert.IsInstanceOfType(singleItemSpecifications, typeof(JArray));
            Assert.AreNotEqual(0, ((JArray)singleItemSpecifications).Count);
            resp.Dispose();
        }
    }
}
