// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;
using Microsoft.Azure.ActiveDirectory.GraphClient.ErrorHandling;

namespace AzureMobile.Samples.AAD.Graph
{
    public class AadHelperProvider : IAadHelperProvider
    {
        private const string AadInstance = "https://login.windows.net/{0}";
        private const string GraphResourceId = "https://graph.windows.net";

        private IServiceSettingsProvider settingsProvider;
        private HttpConfiguration configuration;
        private Dictionary<AadGroups, string> groupIds;

        public AadHelperProvider(IServiceSettingsProvider settingsProvider, HttpConfiguration config)
        {
            this.settingsProvider = settingsProvider;
            this.configuration = config;
        }

        public string GetAccessToken()
        {
            ServiceSettingsDictionary settings = this.settingsProvider.GetServiceSettings();
            if (!this.configuration.GetIsHosted())
            {
                // Running in localhost, return null
                return null;
            }

            string tenant = ReadSetting(settings, "AadTenantDomain");
            string clientId = ReadSetting(settings, "MS_AadClientID");
            string appKey = ReadSetting(settings, "AadServiceAppKey");

            ClientCredential clientCred = new ClientCredential(clientId, appKey);
            string authority = string.Format(CultureInfo.InvariantCulture, AadInstance, tenant);
            AuthenticationContext authContext = new AuthenticationContext(authority);

            AuthenticationResult result = null;
            try
            {
                result = authContext.AcquireToken(GraphResourceId, clientCred);
            }
            catch (ActiveDirectoryAuthenticationException ex)
            {
                // If there is an issue acquiring the token, log the issue
                // and clear the cache, which will get a fresh token. If
                // the second call throws, let it bubble out.

                Trace.TraceError("Problem acquiring token: {0}", ex.ToString());
                authContext.TokenCacheStore.Clear();
                result = authContext.AcquireToken(GraphResourceId, clientCred);
            }

            return result.AccessToken;
        }

        public string GetManagerEmail(string objectId, string accessToken)
        {
            if (objectId == AuthorizeAadGroupAttribute.LocalUserObjectId)
            {
                // When running locally
                return null;
            }

            CallContext currentCallContext = new CallContext(accessToken, Guid.NewGuid());
            GraphConnection graphConnection = new GraphConnection(currentCallContext);
            var user = graphConnection.Get<User>(objectId);
            var userManagerLink = graphConnection.GetLinks(user, "manager", null).Results.FirstOrDefault();
            string result = null;
            if (userManagerLink != null)
            {
                User manager = graphConnection.Get<User>(userManagerLink.ObjectId);
                result = manager.OtherMails.FirstOrDefault();
            }

            return result;
        }

        public string GetUserDisplayName(string objectId, string accessToken)
        {
            if (objectId == AuthorizeAadGroupAttribute.LocalUserObjectId)
            {
                // When running locally
                return AuthorizeAadGroupAttribute.LocalUserName;
            }

            CallContext currentCallContext = new CallContext(accessToken, Guid.NewGuid());
            GraphConnection graphConnection = new GraphConnection(currentCallContext);
            try
            {
                var user = graphConnection.Get<User>(objectId);
                return user.DisplayName;
            }
            catch(ObjectNotFoundException ex)
            {
                Trace.TraceError("Error finding User.{0}", ex.ToString());
            }
            return string.Empty;
        }

        public string GetGroupId(AadGroups group)
        {
            if (this.groupIds == null)
            {
                ServiceSettingsDictionary settings = this.settingsProvider.GetServiceSettings();
                this.groupIds = new Dictionary<AadGroups, string>();

                string storeAssociateId = ReadSetting(settings, "AadSalesAssociateGroupObjectId");
                this.groupIds.Add(AadGroups.StoreAssociate, storeAssociateId);
                string fieldMangerGroupId = ReadSetting(settings, "AadFieldManagerGroupObjectId");
                this.groupIds.Add(AadGroups.FieldManager, fieldMangerGroupId);
                string fieldAgentGroupId = ReadSetting(settings, "AadFieldAgentGroupObjectId");
                this.groupIds.Add(AadGroups.FieldAgent, fieldAgentGroupId);
            }

            string groupId;
            return this.groupIds.TryGetValue(group, out groupId) ? groupId : null;
        }

        public List<String> GetUserIdsInGroup(string accessToken, string groupId)
        {
            CallContext currentCallContext = new CallContext(accessToken, Guid.NewGuid());
            GraphConnection graphConnection = new GraphConnection(currentCallContext);
            var fieldAgentsGroup = graphConnection.Get<Group>(groupId);
            var fieldAgentMembers = graphConnection.GetLinks(fieldAgentsGroup, "members", null);
            var fieldAgents = fieldAgentMembers.Results.OfType<User>();
            List<String> agentIds = new List<string>();
            foreach (User user in fieldAgents)
            {
                agentIds.Add(user.ObjectId);
            }
            return agentIds;
        }

        public IEnumerable<User> GetUsersInGroup(string accessToken, string groupId)
        {
            CallContext currentCallContext = new CallContext(accessToken, Guid.NewGuid());
            GraphConnection graphConnection = new GraphConnection(currentCallContext);
            var fieldAgentsGroup = graphConnection.Get<Group>(groupId);
            var fieldAgentMembers = graphConnection.GetLinks(fieldAgentsGroup, "members", null);
            return fieldAgentMembers.Results.OfType<User>();
        }

        private static string ReadSetting(ServiceSettingsDictionary settings, string settingName)
        {
            string settingValue;
            return settings.TryGetValue(settingName, out settingValue) ? settingValue : null;
        }
    }
}