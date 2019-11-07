// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace AzureMobile.Samples.AAD.Graph
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeAadGroupAttribute : AuthorizationFilterAttribute
    {
        public const string LocalUserObjectId = "localUser";
        public const string LocalUserName = "Local user";
        public const string TestUserGroupHeaderName = "x-fe-test-aad-group";

        private bool isInitialized;
        private bool isHosted;
        private IAadHelperProvider aadHelperProvider;

        public AuthorizeAadGroupAttribute(AadGroups group)
        {
            this.Group = group;
        }

        public AadGroups Group { get; private set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            // Check whether we are running in a mode where local host access is allowed through without authentication.
            if (!this.isInitialized)
            {
                HttpConfiguration config = actionContext.ControllerContext.Configuration;
                this.isHosted = config.GetIsHosted();
                this.aadHelperProvider = config.DependencyResolver.GetService<IAadHelperProvider>();
                this.isInitialized = true;
            }

            ApiController controller = actionContext.ControllerContext.Controller as ApiController;

            if (!this.isHosted && actionContext.RequestContext.IsLocal)
            {
                var localUser = new ServiceUser();
                var providerIdentitiesProperty = typeof(ServiceUser).GetProperty("ProviderIdentities", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var providerIdentities = (Collection<ProviderCredentials>)providerIdentitiesProperty.GetValue(localUser);
                providerIdentities.Add(new AzureActiveDirectoryCredentials { ObjectId = LocalUserObjectId });
                localUser.AddIdentity(new ClaimsIdentity());
                if (controller != null)
                {
                    controller.User = localUser;
                }

                // Test validation of group membership
                IEnumerable<string> testGroupValues;
                if (actionContext.Request.Headers.TryGetValues(TestUserGroupHeaderName, out testGroupValues))
                {
                    var testGroup = testGroupValues.FirstOrDefault();
                    if (testGroup != null)
                    {
                        if (this.Group.ToString().Equals(testGroup, StringComparison.OrdinalIgnoreCase))
                        {
                            // Ok, continue
                        }
                        else
                        {
                            // Wrong group
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "User is not logged in or not a member of the required group");
                        }
                    }
                }

                return;
            }

            if (this.aadHelperProvider == null)
            {
                Trace.TraceError("Could not resolve depdendency for 'IAadHelperProvider' in AuthorizeAadGroupAttribute");
            }

            bool isAuthorized = false;
            if (controller != null && this.aadHelperProvider != null)
            {
                string groupId = this.aadHelperProvider.GetGroupId(this.Group);
                if (!string.IsNullOrEmpty(groupId))
                {
                    ServiceUser serviceUser = controller.User as ServiceUser;
                    if (serviceUser != null && serviceUser.Level == AuthorizationLevel.User)
                    {
                        var idents = serviceUser.GetIdentitiesAsync().Result;
                        var clientAadCredentials = idents.OfType<AzureActiveDirectoryCredentials>().FirstOrDefault();
                        if (clientAadCredentials != null)
                        {
                            string accessToken = this.aadHelperProvider.GetAccessToken();
                            CallContext currentCallContext = new CallContext(accessToken, Guid.NewGuid());
                            GraphConnection graphConnection = new GraphConnection(currentCallContext);
                            bool isMember = graphConnection.IsMemberOf(groupId, clientAadCredentials.ObjectId);
                            if (isMember)
                            {
                                isAuthorized = true;
                            }
                        }
                    }
                }
            }

            if (!isAuthorized)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "User is not logged in or not a member of the required group");
            }
        }
    }
}
