using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExportHTMLAsExcel.Controllers
{
    public class ExportController : Controller
    {
        //
        // GET: /Export/

        public ActionResult ExportPage()
        {
            return View();
        }

    }
}
