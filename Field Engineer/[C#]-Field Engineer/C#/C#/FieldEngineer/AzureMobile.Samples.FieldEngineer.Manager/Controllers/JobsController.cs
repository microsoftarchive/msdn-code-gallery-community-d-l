// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.Manager.Models;
using AzureMobile.Samples.FieldEngineer.Manager.Utils;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureMobile.Samples.FieldEngineer.Manager.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private IEnumerable<Equipment> Equipments;
        private IEnumerable<Customer> Customers;
        private List<User> Agents;
        private MobileServiceClient FieldEngineerClient;

        // GET: Jobs/Create
        public async Task<ActionResult> Create()
        {
            await SetViewBagProperties();
            return View();
        }

        private async Task SetViewBagProperties()
        {
            if (Equipments == null || Customers == null || Agents == null || FieldEngineerClient == null)
            {
                await InitializeData();
            }
            ViewBag.Equipments = new MultiSelectList(Equipments, "Id", "Name");
            ViewBag.Customers = new SelectList(Customers, "Id", "FullName");
            ViewBag.Agents = new SelectList(Agents, "ObjectId", "DisplayName");
            ViewBag.EtaTimes = new SelectList(GetEtaTimes());
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create(JobsViewModel jobViewModel)
        {
            Random random = new Random();
            Job newJob = new Job()
            {
                JobNumber = random.Next(1, 200).ToString(),
                AgentId = jobViewModel.AgentId,
                EtaTime = jobViewModel.EtaTime,
                Equipments = await GetEquipments(jobViewModel.EquipmentsIds),
                Title = jobViewModel.Title,
                CustomerId = jobViewModel.CustomerId
            };
            var jobTable = FieldEngineerClient.GetTable<Job>();
            string message = "";
            try
            {
                await jobTable.InsertAsync(newJob);
                message = "Successfully created new job";
            }
            catch (Exception ex)
            {
                message = string.Format("Failed to create job. Error: {0}.Please retry", ex.Message);
            }

            return RedirectToAction("PostResult", new { postResult = message });
        }

        public ActionResult PostResult(string postResult)
        {
            ViewBag.ResultMessage = postResult;
            return View();
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete()
        {
            await SetViewBagProperties();
            return View();
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(JobsViewModel jobViewModel)
        {
            await SetViewBagProperties();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("agentId", jobViewModel.AgentId);
            string message="";
            try
            {
                await FieldEngineerClient.InvokeApiAsync("ResetStatus", HttpMethod.Post, parameters);
                message = "Reset jobs succeeded";
            }
            catch(Exception ex)
            {
                message = string.Format("Reset jobs. Error: {0}.Please retry", ex.Message);
            }

            return RedirectToAction("PostResult", new { postResult = message });
        }

        private List<string> GetEtaTimes()
        {
            List<string> etaList = new List<string>();
            etaList.Add("08:30 AM - 09:30 AM");
            etaList.Add("09:30 AM - 10:30 AM");
            etaList.Add("11:30 AM - 12:30 PM");
            etaList.Add("12:30 PM - 01:30 PM");
            etaList.Add("01:30 PM - 02:30 PM");
            etaList.Add("02:30 PM - 03:30 PM");
            etaList.Add("03:30 PM - 04:30 PM");
            return etaList;
        }

        private async Task<List<Equipment>> GetEquipments(List<string> equipmentIds)
        {
            if (Equipments == null || Customers == null)
            {
                await InitializeData();
            }
            if (equipmentIds == null)
            {
                return null;
            }
            List<Equipment> equipments = new List<Equipment>();
            foreach (var equipmentId in equipmentIds)
            {
                var equipment = Equipments.Where(eq => eq.Id == equipmentId).FirstOrDefault();
                if (equipment != null)
                {
                    equipments.Add(equipment);
                }
            }
            return equipments;
        }

        private async Task InitializeData()
        {
            string mobileServiceUrl = ConfigurationManager.AppSettings["MobileServiceUrl"];
            FieldEngineerClient = new MobileServiceClient(mobileServiceUrl);
            string accessToken = AadHelper.GetAccessToken();
            JObject payload = new JObject();
            payload["access_token"] = accessToken;

            var mobileServiceUser = await FieldEngineerClient.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, payload);
            var eqTable = FieldEngineerClient.GetTable<Equipment>();
            var customerTable = FieldEngineerClient.GetTable<Customer>();

            this.Equipments = await eqTable.ReadAsync();
            this.Customers = await customerTable.ReadAsync();
            this.Agents = new List<User>();

            var agents = await FieldEngineerClient.InvokeApiAsync("getFieldAgents", HttpMethod.Get, null);
            foreach (JToken agentToken in agents)
            {
                var agent = JsonConvert.DeserializeObject<User>(agentToken.ToString());
                this.Agents.Add(agent);
            }
        }
    }
}
