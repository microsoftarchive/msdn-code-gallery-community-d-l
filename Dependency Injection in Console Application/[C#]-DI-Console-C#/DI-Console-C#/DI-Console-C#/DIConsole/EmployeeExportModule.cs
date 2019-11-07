using DI.Repo;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsole
{
  public class EmployeeExportModule:NinjectModule
    {
        public override void Load()
        {
            Bind(Type.GetType("DI.Data.DIConsoleEntities, DI.Data")).ToSelf().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InSingletonScope();
        }
    }
}
