using System.Web;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class ViewHttpCookiesController : Controller
    {
        // GET: ViewHttpCookies
        public ActionResult Index()
        {
            string cookies = string.Empty;
            foreach (string key in Request.Cookies)
            {
                HttpCookie cookie = Request.Cookies[key];
                cookies += "<br/>" + cookie.Name + ": " + cookie.Value;
            }

            ViewData.Add("cookiesValue", cookies);
            
            return View();
        }
    }
}