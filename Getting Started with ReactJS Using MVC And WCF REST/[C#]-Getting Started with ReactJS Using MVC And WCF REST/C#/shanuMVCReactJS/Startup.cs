using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shanuMVCReactJS.Startup))]
namespace shanuMVCReactJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
