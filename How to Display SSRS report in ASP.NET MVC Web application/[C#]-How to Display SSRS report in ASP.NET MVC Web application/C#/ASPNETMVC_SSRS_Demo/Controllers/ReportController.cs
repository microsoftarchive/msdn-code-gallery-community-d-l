using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVC_SSRS_Demo.Models;

namespace ASPNETMVC_SSRS_Demo.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult ReportTemplate(string ReportName, string ReportDescription, int Width, int Height)
        {
            var rptInfo = new ReportInfo
            {
                ReportName = ReportName,
                ReportDescription = ReportDescription,
                ReportURL = String.Format("../../Reports/ReportTemplate.aspx?ReportName={0}&Height={1}", ReportName, Height),
                Width = Width,
                Height = Height
            };

            return View(rptInfo);
        }


    }
}
