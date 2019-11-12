using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShanuAngularProjectSchedule.Startup))]
namespace ShanuAngularProjectSchedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
