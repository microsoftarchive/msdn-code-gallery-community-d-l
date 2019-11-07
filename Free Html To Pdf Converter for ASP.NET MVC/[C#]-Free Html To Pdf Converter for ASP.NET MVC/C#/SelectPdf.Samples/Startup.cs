using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelectPdf.Samples.Startup))]
namespace SelectPdf.Samples
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
