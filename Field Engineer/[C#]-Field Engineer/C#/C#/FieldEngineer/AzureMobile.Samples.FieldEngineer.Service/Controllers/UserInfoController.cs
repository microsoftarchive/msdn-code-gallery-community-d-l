// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AzureMobile.Samples.AAD.Graph;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using System.Collections.Generic;

namespace AzureMobile.Samples.FieldEngineer.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class UserInfoController : ApiController
    {
        private readonly IAadHelperProvider aadHelperProvider;

        public UserInfoController(IAadHelperProvider aadHelperProvider)
        {
            this.aadHelperProvider = aadHelperProvider;
        }

        public ApiServices Services { get; set; }

        [Route("api/getFieldAgentDisplayName")]
        [AuthorizeAadGroup(AadGroups.FieldAgent)]
        public async Task<string> GetFieldAgentDisplayName()
        {
            this.Services.Log.Info("In Get FieldAgentDisplayName");
            string accessToken = this.aadHelperProvider.GetAccessToken();
            ServiceUser mobileServiceUser = (ServiceUser)this.User;
            AzureActiveDirectoryCredentials aadCreds = (await mobileServiceUser.GetIdentitiesAsync()).OfType<AzureActiveDirectoryCredentials>().First();
            return this.aadHelperProvider.GetUserDisplayName(aadCreds.ObjectId, accessToken);
        }

        [Route("api/getFieldAgents")]
        [AuthorizeAadGroup(AadGroups.FieldManager)]
        public IEnumerable<User> GetFieldAgents()
        {
            this.Services.Log.Info("In Get FieldAgents");
            string accessToken = this.aadHelperProvider.GetAccessToken();
            string fieldAgentGroupId = this.aadHelperProvider.GetGroupId(AadGroups.FieldAgent);
            return this.aadHelperProvider.GetUsersInGroup(accessToken, fieldAgentGroupId);
        }
    }
}
