using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AzureMobile.Samples.FieldEngineer.Manager.Startup))]

namespace AzureMobile.Samples.FieldEngineer.Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
