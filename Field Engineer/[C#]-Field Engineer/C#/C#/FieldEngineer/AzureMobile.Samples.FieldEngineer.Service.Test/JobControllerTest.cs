// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AzureMobile.Samples.AAD.Graph;
using AzureMobile.Samples.FieldEngineer.Service.DataObjects;
using AzureMobile.Samples.FieldEngineer.Service.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace AzureMobile.Samples.FieldEngineer.Service.Test
{
    [TestClass]
    public class JobControllerTest
    {
        static HttpClient client;
        const string tableAddress = "/tables/job";
        static readonly string testJobId = "test-job-id";
        static string existingCustomerId;
        static string[] existingEquipmentIds;
        static string existingJobId;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var req = new HttpRequestMessage(
                HttpMethod.Get,
                Common.LocalhostAddress + tableAddress + "?$top=1&$select=customerId,id&$filter=id%20ne%20'" + testJobId + "'");
            var resp = client.SendAsync(req).Result;
            resp.EnsureSuccessStatusCode();
            var respBody = resp.Content.ReadAsStringAsync().Result;
            var arr = JArray.Parse(respBody);
            Assert.AreEqual(1, arr.Count);
            var item = arr[0];
            existingCustomerId = (string)item["customerId"];
            existingJobId = (string)item["id"];
            resp.Dispose();

            req = new HttpRequestMessage(HttpMethod.Get, Common.LocalhostAddress + EquipmentControllerTest.tableAddress + "?$select=id");
            resp = client.SendAsync(req).Result;
            resp.EnsureSuccessStatusCode();
            respBody = resp.Content.ReadAsStringAsync().Result;
            arr = JArray.Parse(respBody);
            Assert.AreNotEqual(0, arr.Count);
            existingEquipmentIds = arr.Select(e => (string)e["id"]).ToArray();
            resp.Dispose();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Delete test job, if it exists; ignore result if it doesn't
            var resp = client.DeleteAsync(Common.LocalhostAddress + tableAddress + "/" + testJobId).Result;
            Console.WriteLine(resp);
        }

        [TestMethod]
        public async Task PostJob_InvalidCustomer_CausesError()
        {
            var req = new HttpRequestMessage(HttpMethod.Post, Common.LocalhostAddress + tableAddress);
            var job = CreateJob();
            job.CustomerId = "does-not-exist";
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(job, serializerSettings);
            req.Content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");

            using (var resp = await client.SendAsync(req))
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, resp.StatusCode);
            }
        }

        [TestMethod]
        public async Task PostJob_InvalidEquipment_CausesError()
        {
            var req = new HttpRequestMessage(HttpMethod.Post, Common.LocalhostAddress + tableAddress);
            var job = CreateJob();
            job.Equipments[0].Id = "does-not-exist";
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(job, serializerSettings);
            req.Content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");

            using (var resp = await client.SendAsync(req))
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, resp.StatusCode);
            }
        }

        [TestMethod]
        public async Task PostJob_NotAManager_CausesError()
        {
            var req = new HttpRequestMessage(HttpMethod.Post, Common.LocalhostAddress + tableAddress);
            var job = CreateJob();
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(job, serializerSettings);
            req.Content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");
            req.Headers.Add(AuthorizeAadGroupAttribute.TestUserGroupHeaderName, Common.FieldAgentAadGroup);

            using (var resp = await client.SendAsync(req))
            {
                Assert.AreEqual(HttpStatusCode.Forbidden, resp.StatusCode);
            }
        }

        [TestMethod]
        public async Task DeleteJob_NotAManager_CausesError()
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, Common.LocalhostAddress + tableAddress + "/" + testJobId);
            req.Headers.Add(AuthorizeAadGroupAttribute.TestUserGroupHeaderName, Common.FieldAgentAadGroup);

            using (var resp = await client.SendAsync(req))
            {
                Assert.AreEqual(HttpStatusCode.Forbidden, resp.StatusCode);
            }
        }

        [TestMethod]
        public async Task GetJob_CanExpandHistory()
        {
            var req = new HttpRequestMessage(HttpMethod.Get, Common.LocalhostAddress + tableAddress + "/" + existingJobId + "?$expand=jobHistories");
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
                var body = await resp.Content.ReadAsStringAsync();
                var obj = JObject.Parse(body);
                var history = obj["jobHistories"];
                Assert.IsNotNull(history);
                Assert.AreEqual(JTokenType.Array, history.Type);
            }
        }

        [TestMethod]
        public async Task GetJob_CanExpandEquipments()
        {
            var req = new HttpRequestMessage(HttpMethod.Get, Common.LocalhostAddress + tableAddress + "/" + existingJobId + "?$expand=equipments");
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
                var body = await resp.Content.ReadAsStringAsync();
                var obj = JObject.Parse(body);
                var history = obj["equipments"];
                Assert.IsNotNull(history);
                Assert.AreEqual(JTokenType.Array, history.Type);
            }
        }

        [TestMethod]
        public async Task CreateUpdateDeleteJob()
        {
            // Create a new job
            await PostJob_AddsNewJob();

            // Retrieve the job
            await GetJob_ReturnsAddedJob();

            // Update and validate update
            await UpdateJob_ReturnsUpdatedJob();

            // Delete the job
            await DeleteJob_RemovesFromDatabase();
        }

        [TestMethod]
        public async Task PatchJob_OnlyUpdatesChangedProperties()
        {
            await PostJob_AddsNewJob();
            var job = CreateJob();
            var req = new HttpRequestMessage(new HttpMethod("PATCH"), Common.LocalhostAddress + tableAddress + "/" + testJobId);
            var newJob = new JobDTO();
            newJob.Id = testJobId;
            newJob.Title = "modified title";
            job.Title = newJob.Title;
            string reqBody = JsonConvert.SerializeObject(newJob, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });
            req.Content = new StringContent(reqBody, Encoding.UTF8, "application/json");
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
            }

            using (var resp = await client.GetAsync(Common.LocalhostAddress + tableAddress + "/" + testJobId))
            {
                resp.EnsureSuccessStatusCode();
                var respBody = await resp.Content.ReadAsStringAsync();
                var updatedJob = JsonConvert.DeserializeObject<JobDTO>(respBody);
                Assert.AreEqual(job.Title, updatedJob.Title);
                Assert.AreEqual(job.Id, updatedJob.Id);
                Assert.AreEqual(job.AgentId, updatedJob.AgentId);
                Assert.AreEqual(job.EtaTime, updatedJob.EtaTime);
                Assert.AreEqual(job.JobNumber, updatedJob.JobNumber);
            }
        }

        private async Task DeleteJob_RemovesFromDatabase()
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, Common.LocalhostAddress + tableAddress + "/" + testJobId);
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
            }

            req = new HttpRequestMessage(HttpMethod.Get, Common.LocalhostAddress + tableAddress + "/" + testJobId);
            using (var resp = await client.SendAsync(req))
            {
                Assert.AreEqual(HttpStatusCode.NotFound, resp.StatusCode);
            }
        }

        private async Task UpdateJob_ReturnsUpdatedJob()
        {
            var req = new HttpRequestMessage(new HttpMethod("PATCH"), Common.LocalhostAddress + tableAddress + "/" + testJobId);
            var obj = new JObject();
            obj.Add("title", "Test job updated");
            obj.Add("id", testJobId);
            req.Content = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
            }

            req = new HttpRequestMessage(HttpMethod.Get, Common.LocalhostAddress + tableAddress + "/" + testJobId);
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
                var respBody = await resp.Content.ReadAsStringAsync();
                obj = JObject.Parse(respBody);
                Assert.AreEqual("Test job updated", (string)obj["title"]);
            }
        }

        private async Task GetJob_ReturnsAddedJob()
        {
            var req = new HttpRequestMessage(HttpMethod.Get, Common.LocalhostAddress + tableAddress + "/" + testJobId);
            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
                var respBody = await resp.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(respBody);
                var job = CreateJob();
                Assert.AreEqual(job.Id, (string)obj["id"]);
                Assert.AreEqual(job.EtaTime, (string)obj["etaTime"]);
                Assert.AreEqual(job.CustomerId, (string)obj["customerId"]);
                Assert.AreEqual(job.Title, (string)obj["title"]);
                Assert.IsNotNull(obj["status"]);
                Assert.AreNotEqual(Constants.CompletedStatus, (string)obj["status"]);
            }
        }

        private async Task PostJob_AddsNewJob()
        {
            var req = new HttpRequestMessage(HttpMethod.Post, Common.LocalhostAddress + tableAddress);
            var job = CreateJob();
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(job, serializerSettings);
            req.Content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");

            using (var resp = await client.SendAsync(req))
            {
                resp.EnsureSuccessStatusCode();
                Assert.IsNotNull(resp.Content);
                var contentJson = await resp.Content.ReadAsStringAsync();
                var inserted = JObject.Parse(contentJson);
                Assert.IsNotNull(inserted["status"]);
            }
        }

        private static JobDTO CreateJob()
        {
            var job = new JobDTO();
            job.AgentId = Common.LocalUserObjectId;
            job.Id = testJobId;
            job.EtaTime = "11:00 AM - 12:00 PM";
            job.JobNumber = "1001";
            job.Title = "Test job";
            job.CustomerId = existingCustomerId;

            job.Equipments = new List<EquipmentDTO>();
            for (var i = 0; i < 2; i++)
            {
                job.Equipments.Add(new EquipmentDTO
                {
                    Id = existingEquipmentIds[i % existingEquipmentIds.Length]
                });
            }

            job.JobHistories = new List<JobHistoryDTO>();
            job.JobHistories.Add(new JobHistoryDTO
            {
                ActionBy = Common.LocalUserName,
                Comments = "comments on the history",
                JobId = job.Id,
                TimeStamp = DateTimeOffset.UtcNow
            });

            return job;
        }
    }
}
