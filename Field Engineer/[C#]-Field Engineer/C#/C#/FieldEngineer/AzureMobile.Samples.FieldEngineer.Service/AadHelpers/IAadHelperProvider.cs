// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using Microsoft.Azure.ActiveDirectory.GraphClient;
using System.Collections.Generic;
namespace AzureMobile.Samples.AAD.Graph
{
    public interface IAadHelperProvider
    {
        string GetAccessToken();

        string GetGroupId(AadGroups group);

        string GetManagerEmail(string objectId, string accessToken);

        string GetUserDisplayName(string objectId, string accessToken);

        List<string> GetUserIdsInGroup(string accessToken, string FieldAgentGroupId);

        IEnumerable<User> GetUsersInGroup(string accessToken, string FieldAgentGroupId);
    }
}
