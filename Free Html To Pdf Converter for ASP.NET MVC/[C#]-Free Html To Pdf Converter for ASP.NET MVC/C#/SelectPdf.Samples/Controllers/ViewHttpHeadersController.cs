using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class ViewHttpHeadersController : Controller
    {
        // GET: ViewHttpHeaders
        public ActionResult Index()
        {
            string headers = string.Empty;
            foreach (string name in Request.Headers)
            {
                string value = Request.Headers[name];
                headers += "<br/>" + name + ": " + value;
            }

            ViewData.Add("HeadersValue", headers);
            
            return View();
        }
    }
}