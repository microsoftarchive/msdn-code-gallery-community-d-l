using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using DataAccess.Repositories;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using DataAccess.Services;
using TestAPI.Resolver;

namespace TestAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
          
            container.RegisterType<IBlogRepository, BlogRepository>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IBlogService, BlogService>();
            config.DependencyResolver = new UnityResolver(container);


            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
