// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------
// This file reused from: https://github.com/AzureADSamples/WebApp-GraphAPI-DotNet/blob/master/WebAppGraphAPI/App_Start/RouteConfig.cs

using System.Web.Mvc;
using System.Web.Routing;

namespace AzureMobile.Samples.FieldEngineer.Manager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
