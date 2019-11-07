using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeleteMultipleWebgrid.Startup))]
namespace DeleteMultipleWebgrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
