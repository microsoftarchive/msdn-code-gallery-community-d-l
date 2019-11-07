using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShanuMVCWebAPIAngular.Startup))]
namespace ShanuMVCWebAPIAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
