using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JsonWithAspNetMVCExample.Startup))]
namespace JsonWithAspNetMVCExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
