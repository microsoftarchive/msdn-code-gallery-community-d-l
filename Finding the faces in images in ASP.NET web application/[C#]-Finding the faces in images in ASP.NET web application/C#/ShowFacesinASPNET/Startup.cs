using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowFacesinASPNET.Startup))]
namespace ShowFacesinASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
