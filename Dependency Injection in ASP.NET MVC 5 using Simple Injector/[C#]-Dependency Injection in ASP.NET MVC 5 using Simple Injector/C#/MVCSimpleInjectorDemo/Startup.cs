using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSimpleInjectorDemo.Startup))]
namespace MVCSimpleInjectorDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
