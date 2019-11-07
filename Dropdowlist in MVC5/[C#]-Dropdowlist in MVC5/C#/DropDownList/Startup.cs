using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropDownList.Startup))]
namespace DropDownList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
