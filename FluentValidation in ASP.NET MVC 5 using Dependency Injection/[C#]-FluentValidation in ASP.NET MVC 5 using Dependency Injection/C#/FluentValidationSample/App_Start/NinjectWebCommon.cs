[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FluentValidationSample.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FluentValidationSample.App_Start.NinjectWebCommon), "Stop")]

namespace FluentValidationSample.App_Start
{
    using System;
    using System.Web;
    using System.Web.ModelBinding;
    using FluentValidation.Mvc;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Validation;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                ValidationConfiguration(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }

        private static void ValidationConfiguration(IKernel kernel)
        {
            ValidatorFactory validatorFactory = new ValidatorFactory(kernel);
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = validatorFactory);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }
    }
}
