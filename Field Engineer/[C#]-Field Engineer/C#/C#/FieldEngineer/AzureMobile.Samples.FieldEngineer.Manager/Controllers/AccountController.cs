// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------
// This file reused (with modifications) from: https://github.com/AzureADSamples/WebApp-GraphAPI-DotNet/blob/master/WebAppGraphAPI/Controllers/AccountController.cs

using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AzureMobile.Samples.FieldEngineer.Manager.Utils;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace AzureMobile.Samples.FieldEngineer.Manager.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
        public void SignOut()
        {
            // Remove all cache entries for this user and send an OpenID Connect sign-out request.
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            AuthenticationContext authContext = new AuthenticationContext(Startup.Authority,
                new NaiveSessionCache(userObjectID));
            authContext.TokenCache.Clear();
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}