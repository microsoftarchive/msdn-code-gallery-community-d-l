// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AzureMobile.Samples.AAD.Graph;
using AzureMobile.Samples.FieldEngineer.Service.Models;
using AzureMobile.Samples.FieldEngineer.Service.Utilities;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AzureMobile.Samples.FieldEngineer.Service.ScheduledJobs
{
    public class FieldEngineerDBCleanup : ScheduledJob
    {
        private readonly IAadHelperProvider aadHelperProvider;
        private MobileServiceContext context = new MobileServiceContext();

        public FieldEngineerDBCleanup(IAadHelperProvider aadHelperProvider)
        {
            this.aadHelperProvider = aadHelperProvider;
        }

        public override Task ExecuteAsync()
        {
            string FieldAgentGroupId = this.Services.Settings["FieldAgentGroupId"].ToString();
            string tenant = this.Services.Settings["AadTenantDomain"].ToString();
            string clientId = this.Services.Settings["MS_AadClientID"].ToString();
            string appKey = this.Services.Settings["AadServiceAppKey"].ToString();
            string accessToken = this.aadHelperProvider.GetAccessToken();
            List<string> agentIds = this.aadHelperProvider.GetUserIdsInGroup(accessToken, FieldAgentGroupId);
            try
            {
                this.Services.Log.Info("Deleting JobHistories");
                var jobHistoriesToDelete = context.JobHistories.Where(jh => jh.ActionBy.ToLower().Contains("field"));
                if (jobHistoriesToDelete != null && jobHistoriesToDelete.Count() > 0)
                {
                    this.Services.Log.Info("JobHistories to Delete:" + jobHistoriesToDelete.Count());

                    foreach (JobHistory jobHistory in jobHistoriesToDelete)
                    {
                        context.JobHistories.Remove(jobHistory);
                    }
                    context.SaveChanges();
                    this.Services.Log.Info("Done Deleting JobHistories");
                }
                else
                {
                    this.Services.Log.Info("No JobHistories to delete");
                    return Task.FromResult(true);
                }
            }
            catch (Exception e)
            {
                this.Services.Log.Error("Deleting JobHistories" + e.Message);
            }
            try
            {
                ResetJobsHelper resetJobsHelper = new ResetJobsHelper();
                foreach (string agentId in agentIds)
                {
                    this.Services.Log.Info("Cleaning JobStatus for FieldAgent: " + agentId);
                    resetJobsHelper.ResetJobsForAgent(agentId);
                }
                this.Services.Log.Info("Done Updating JobStatus");
            }
            catch (Exception e)
            {
                this.Services.Log.Error("Error Updating JobStatus" + e.Message);
            }
            return Task.FromResult(true);
        }
    }
}