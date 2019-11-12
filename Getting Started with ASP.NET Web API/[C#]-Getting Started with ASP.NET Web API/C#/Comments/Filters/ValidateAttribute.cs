using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Comments.Filters
{
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    actionContext.ModelState);
            }
        }
    }
}