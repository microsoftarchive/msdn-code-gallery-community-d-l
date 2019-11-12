using System.Web;
using System.Web.Mvc;

namespace Dynamic_Tabs_In_ANgular_JS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}