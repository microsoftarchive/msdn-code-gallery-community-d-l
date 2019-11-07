using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCUnityIOCDemo.Startup))]

namespace MVCUnityIOCDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}