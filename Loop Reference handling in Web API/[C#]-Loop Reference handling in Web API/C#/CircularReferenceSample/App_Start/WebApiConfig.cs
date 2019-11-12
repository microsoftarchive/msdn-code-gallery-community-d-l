using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CircularReferenceSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Fix 1
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling 
            //    = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Fix 2
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            //    = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
            //    = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
