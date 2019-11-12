// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Web.Http;

namespace AdventureWorks.WebServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config == null || config.Routes == null) return;

            config.Routes.MapHttpRoute(
                name: "ShippingMethodApi",
                routeTemplate: "api/shippingmethod/{action}",
                defaults: new { controller = "shippingmethod", action = "defaultAction" },
                constraints: new { action = @"[^\d]+" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
