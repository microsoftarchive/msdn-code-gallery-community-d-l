using Prism;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoggerUtility;
using Prism.Logging;
using MenuModules;
using Prism.Modularity;
using ExampleModules;
using Prism.Unity;
namespace PrismApp
{
    public class Bootstrapper : WinFormUnityBootstrapper
    {
        protected override System.Windows.Forms.Form CreateShell()
        {
            return ServiceLocator.Current.GetInstance<RootForm>();
        }

        protected override void InitializeShell()
        {
            // Add any custom initialization such as logger or other
            // components
            //todo...

            Logger = this.CreateLogger();
            if (Logger == null)
            {
                throw new InvalidOperationException("The ILoggerFacade is required and cannot be null.");
            }
            else
            {
                // before shell loading this is not get triggered.
                if (Logger is LoggerUtility.Logger)
                {
                    ((LoggerUtility.Logger)Logger).Initialize();
                }
            }


        }
        protected override void ConfigureModuleCatalog()
        {
            // Add required module initialization here
            // base.ConfigureModuleCatalog();
            List<Type> types = new List<Type>();
            types.Add(typeof(MenuModule));
            types.Add(typeof(NavigationModule));
            types.Add(typeof(StudentModule));
            types.Add(typeof(SubjectModule));
            foreach (var type in types)
            {
                ModuleCatalog.AddModule(new ModuleInfo()
                {
                    ModuleName = type.Name,
                    ModuleType = type.AssemblyQualifiedName,
                    InitializationMode = InitializationMode.WhenAvailable
                });
            }
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new Logger();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
