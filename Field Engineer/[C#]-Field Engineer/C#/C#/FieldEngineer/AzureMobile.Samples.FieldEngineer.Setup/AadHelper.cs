// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureMobile.Samples.FieldEngineer.Setup
{
    public class AadHelper
    {
        private const string AadInstance = "https://login.windows.net/{0}";
        private const string GraphResourceId = "https://graph.windows.net";

        public string GetAccessToken()
        {
            string tenant = ConfigurationManager.AppSettings["AadTenantDomain"].ToString();
            string clientId = ConfigurationManager.AppSettings["MS_AadClientID"].ToString();
            string appKey = ConfigurationManager.AppSettings["AadServiceAppKey"].ToString();

            ClientCredential clientCred = new ClientCredential(clientId, appKey);
            string authority = string.Format(CultureInfo.InvariantCulture, AadInstance, tenant);
            AuthenticationContext authContext = new AuthenticationContext(authority);

            AuthenticationResult result = authContext.AcquireToken(GraphResourceId, clientCred);
            return result.AccessToken;
        }

        public void UpdateUsersManager(string accessToken, string agentsGroupId, string managersGroupId)
        {
            CallContext currentCallContext = new CallContext(accessToken, Guid.NewGuid());
            GraphConnection graphConnection = new GraphConnection(currentCallContext);
            var fieldAgentsGroup = graphConnection.Get<Group>(agentsGroupId);
            var managersGroup = graphConnection.Get<Group>(managersGroupId);
            var fieldAgentMembers = graphConnection.GetLinks(fieldAgentsGroup, "members", null);
            var managersMemebers = graphConnection.GetLinks(managersGroup, "members", null);

            var fieldAgents = fieldAgentMembers.Results.OfType<User>();
            var manager = managersMemebers.Results.OfType<User>().FirstOrDefault();

            if (manager == null)
            {
                Console.WriteLine("Error: Atleast one manager needed");
                return;
            }

            foreach (User user in fieldAgents)
            {
                graphConnection.AddLink(user, manager, "manager", true);
            }
        }

        public List<String> GetUsersInGroup(string accessToken, string groupId)
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
    }
}
