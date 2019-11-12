using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CRUD_Operations_In_MVC_Using_Web_API.Startup))]

namespace CRUD_Operations_In_MVC_Using_Web_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
