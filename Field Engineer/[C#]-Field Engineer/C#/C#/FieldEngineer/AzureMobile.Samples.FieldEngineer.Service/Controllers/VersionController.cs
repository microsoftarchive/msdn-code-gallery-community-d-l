// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace AzureMobile.Samples.FieldEngineer.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class VersionController : ApiController
    {
        public ApiServices Services { get; set; }

        public string Get()
        {
            string version = typeof(VersionController).Assembly.GetName().Version.ToString();
            this.Services.Log.Info(string.Format("Service version: {0}", version));
            return version;
        }
    }
}
