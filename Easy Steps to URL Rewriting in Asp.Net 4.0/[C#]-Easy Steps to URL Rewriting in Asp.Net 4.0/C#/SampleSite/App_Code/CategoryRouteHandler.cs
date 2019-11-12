using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
using AdventureWorksModel;

/// <summary>
/// Summary description for CategoryRouteHandler
/// </summary>
public class CategoryRouteHandler : IRouteHandler
{
	public CategoryRouteHandler()	{	}

    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        AdventureWorksEntities awe = new AdventureWorksEntities();
        string cat=requestContext.RouteData.Values["category"] as string;
        int catid = awe.ProductCategories.Where(x => x.Name == cat).FirstOrDefault().ProductCategoryID;

        HttpContext.Current.Items["catid"] = catid;
        return BuildManager.CreateInstanceFromVirtualPath("~/Products.aspx", typeof(Page)) as Page;
    }
}