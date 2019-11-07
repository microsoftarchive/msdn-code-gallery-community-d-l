
using System;
using DependencyInjectionServices.DIServices;
using Microsoft.Practices.Unity;
using DPServices = DependencyInjectionServices.DIServices.DependencyInjectionServices; //because the name of the project is the same of the Class.

namespace DependencyInjectionConsoleApp
{
    class Program
    {
        //Now we will try to display the message as simple as possible
        private static IDependencyInjectionServices _dependencyInjectionServices;

        static void Main(string[] args)
        {
            //var unityContainer = new UnityContainer();
            //unityContainer.RegisterType<IDependencyInjectionServices, DPServices>();
            //var instance = unityContainer.Resolve<>(); //if we use the class in another project in a Controller for example or in any class we should apply the resolve
            //==> We use the container in this way directly inside the main class or we will use the UnityConfig (better solution).
            //new Method 
            UnityConfig.RegisterComponents();
            _dependencyInjectionServices = UnityConfig.CurrentContainer.Resolve<IDependencyInjectionServices>();


            _dependencyInjectionServices.DisplayMessage("Hello ! This is a test for Dependency injection!");
        }
    }
}
