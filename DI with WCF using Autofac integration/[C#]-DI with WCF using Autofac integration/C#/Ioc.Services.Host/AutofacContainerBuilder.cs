using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;
using Ioc.Services.Impl;
using Ioc.Services.Domain;

namespace Ioc.Services.Host
{
/// <summary>
/// Class to build Autofac IOC container.
/// </summary>
public static class AutofacContainerBuilder
{
    /// <summary>
    /// Configures and builds Autofac IOC container.
    /// </summary>
    /// <returns></returns>
    public static IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();

        // register types
        builder.RegisterType<EuropeanCarProvider>().As<ICarProvider>();
        builder.RegisterType<CarProviderService>().As<ICarProviderService>();

        // build container
        return builder.Build();
    }
}
}