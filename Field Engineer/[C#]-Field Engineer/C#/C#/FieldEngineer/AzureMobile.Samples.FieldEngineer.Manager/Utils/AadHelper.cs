// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------
// This file reused (with modifications) from: https://github.com/AzureADSamples/WebApp-GraphAPI-DotNet/blob/master/WebAppGraphAPI/Controllers/UsersController.cs

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Configuration;
using System.Security.Claims;

namespace AzureMobile.Samples.FieldEngineer.Manager.Utils
{
    public class AadHelper
    {
        public static string GetAccessToken()
        {
            string loginUrl = ConfigurationManager.AppSettings["ida:AADInstance"]; ;
            string graphResourceId = ConfigurationManager.AppSettings["ida:GraphUrl"];
            string clientId = ConfigurationManager.AppSettings["ida:ClientID"];
            string serviceKey = ConfigurationManager.AppSettings["ida:AppKey"];
            string mobileServiceUrl = ConfigurationManager.AppSettings["MobileServiceUrl"];

            // Get the access token from the cache
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            AuthenticationContext authContext = new AuthenticationContext(Startup.Authority,
                new NaiveSessionCache(userObjectID));
            ClientCredential credential = new ClientCredential(clientId, serviceKey);
            string mobileServiceResourceId=mobileServiceUrl.Trim('/')+"/login/aad";
            AuthenticationResult result = authContext.AcquireTokenSilent(mobileServiceResourceId, credential,
                new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
            return result.AccessToken;
        }
    }
}