using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recaptcha.Startup))]
namespace Recaptcha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
