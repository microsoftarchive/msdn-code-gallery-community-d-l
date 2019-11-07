using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_In_MVC_Using_Web_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
