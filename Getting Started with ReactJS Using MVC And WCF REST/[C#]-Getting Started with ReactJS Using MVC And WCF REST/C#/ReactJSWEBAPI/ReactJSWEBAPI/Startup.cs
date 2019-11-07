using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReactJSWEBAPI.Startup))]
namespace ReactJSWEBAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
