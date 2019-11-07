// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Notifications;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace AzureMobile.Samples.FieldEngineer.Service.Utilities
{
    public class PushRegistrationHandler : INotificationHandler
    {
        public async Task Register(ApiServices services, HttpRequestContext context, NotificationRegistration registration)
        {
            //Register Tag: UserId to push to users
            ServiceUser user = (ServiceUser)context.Principal;
            AzureActiveDirectoryCredentials creds = (await user.GetIdentitiesAsync()).OfType<AzureActiveDirectoryCredentials>().FirstOrDefault();
            registration.Tags.Add(creds.ObjectId);
            services.Log.Info("Registered tag for userId: " + creds.ObjectId);
        }

        public Task Unregister(ApiServices services, HttpRequestContext context, string deviceId)
        {
            //TODO UnRegister
            return Task.FromResult(true);
        }
    }
}
