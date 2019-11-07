using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shanuAngularMVCPivotGrid.Startup))]
namespace shanuAngularMVCPivotGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
