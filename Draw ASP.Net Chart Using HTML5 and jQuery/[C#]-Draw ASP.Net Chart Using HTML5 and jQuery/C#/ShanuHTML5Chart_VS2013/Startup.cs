using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShanuHTML5Chart_VS2013.Startup))]
namespace ShanuHTML5Chart_VS2013
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
