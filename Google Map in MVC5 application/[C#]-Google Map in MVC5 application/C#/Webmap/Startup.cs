using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webmap.Startup))]
namespace Webmap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
