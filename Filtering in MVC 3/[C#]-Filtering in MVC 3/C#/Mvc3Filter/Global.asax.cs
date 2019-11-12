using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mvc3Filter.Filters;

namespace Mvc3Filter {

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequestLogFilter());

            // Remove comment to make TraceActionFilterAttribute global
            //  filters.Add(new TraceActionFilterAttribute());

            var provider = new RequestTimingFilterProvider();
            provider.Add(c => c.HttpContext.IsDebuggingEnabled ? new RequestTimingFilter() : null);
            FilterProviders.Providers.Add(provider);
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}