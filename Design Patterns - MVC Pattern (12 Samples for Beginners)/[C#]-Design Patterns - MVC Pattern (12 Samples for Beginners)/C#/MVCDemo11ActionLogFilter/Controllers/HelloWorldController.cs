using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDemo11ActionLogFilter
{
    //[MVCDemo11ActionLogFilter.Filters.ActionLogFilter]
    [MVCDemo11ActionLogFilter.Filters.TraceActionFilter]   // trace all action methods in this controller
    public class HelloWorldController : Controller
    {
        public ActionResult SayHello()
        {
            return View();            
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
            else
            {
                base.Initialize(requestContext);
            }
        }
    }
}