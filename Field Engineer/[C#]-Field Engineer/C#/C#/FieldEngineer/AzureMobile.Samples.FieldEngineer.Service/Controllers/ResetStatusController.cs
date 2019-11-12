// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Web.Http;
using AzureMobile.Samples.AAD.Graph;
using AzureMobile.Samples.FieldEngineer.Service.Models;
using AzureMobile.Samples.FieldEngineer.Service.Utilities;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AzureMobile.Samples.FieldEngineer.Service.Controllers
{
    public class ResetStatusController : ApiController
    {
        private readonly IAadHelperProvider aadHelperProvider;
        private MobileServiceContext context = new MobileServiceContext();

        public ApiServices Services { get; set; }

        public ResetStatusController(IAadHelperProvider aadHelperProvider)
        {
            this.aadHelperProvider = aadHelperProvider;
        }

        public void Post(string agentId)
        {
            Services.Log.Info("Resetting jobs for Agent: " + agentId);
            string accessToken = this.aadHelperProvider.GetAccessToken();
            string FieldAgentGroupId = this.Services.Settings["FieldAgentGroupId"].ToString();
            string tenant = this.Services.Settings["AadTenantDomain"].ToString();
            string clientId = this.Services.Settings["MS_AadClientID"].ToString();
            string appKey = this.Services.Settings["AadServiceAppKey"].ToString();
            string agentName = this.aadHelperProvider.GetUserDisplayName(agentId, accessToken);
            ResetJobsHelper resetJobsHelper = new ResetJobsHelper();

            try
            {
                resetJobsHelper.ResetJobHistoriesForAgent(agentName);
                resetJobsHelper.ResetJobsForAgent(agentId);
            }
            catch (Exception ex)
            {
                Services.Log.Error(string.Format("Resetting jobs for Agent: {0} failed. Exception: {1}", agentId, ex.Message));
                throw;
            }
        }
    }
}
