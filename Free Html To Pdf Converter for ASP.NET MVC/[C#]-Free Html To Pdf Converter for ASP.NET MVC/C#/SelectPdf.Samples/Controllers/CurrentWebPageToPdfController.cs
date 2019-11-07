using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;

namespace SelectPdf.Samples.Controllers
{
    public class CurrentWebPageToPdfController : Controller
    {
        // GET: /CurrentWebPageToPdf/
        public ActionResult Index()
        {
            ViewData.Add("SampleText", "sample text");
            ViewData.Add("DropDownList1", "Value3");

            List<SelectListItem> DropDownList1 = new List<SelectListItem>();
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value1",
                Value = "Value1",
                Selected = ViewData["DropDownList1"] != null && 
                    ViewData["DropDownList1"].ToString() == "Value1"
            });
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value2",
                Value = "Value2",
                Selected = ViewData["DropDownList1"] != null && 
                    ViewData["DropDownList1"].ToString() == "Value2"
            });
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value3",
                Value = "Value3",
                Selected = ViewData["DropDownList1"] != null && 
                    ViewData["DropDownList1"].ToString() == "Value3"
            });
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value4",
                Value = "Value4",
                Selected = ViewData["DropDownList1"] != null && 
                    ViewData["DropDownList1"].ToString() == "Value4"
            });

            ViewData.Add("DropDownList1Items", DropDownList1);

            ViewData.Add("SampleCheckbox", "true");

            ViewData.Add("SampleText2", "1000");
            ViewData.Add("SampleText3", "800");

            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // set data for the view
            ViewDataDictionary MyViewData = GetViewData(collection);

            // render view to get html
            StringWriter html = new StringWriter();

            ViewEngineResult viewEngineResult = 
                ViewEngines.Engines.FindView(ControllerContext, "Index", null);
            ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewEngineResult.View,
                    MyViewData,
                    new TempDataDictionary(),
                    html
                    );
            viewEngineResult.View.Render(viewContext, html);

            string htmlString = html.ToString();

            // get base url
            string baseUrl = this.ControllerContext.HttpContext.Request.Url.
                AbsoluteUri.Substring(
                0, this.ControllerContext.HttpContext.Request.Url.
                AbsoluteUri.Length - "CurrentWebPageToPdf/Convert".Length);

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting a html string
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
        }

        private ViewDataDictionary GetViewData(FormCollection collection)
        {
            ViewDataDictionary MyViewData = new ViewDataDictionary();

            MyViewData.Add("SampleText", collection["TxtSampleText"]);
            MyViewData.Add("DropDownList1", collection["DropDownList1"]);

            List<SelectListItem> DropDownList1 = new List<SelectListItem>();
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value1",
                Value = "Value1",
                Selected = MyViewData["DropDownList1"] != null && 
                    MyViewData["DropDownList1"].ToString() == "Value1"
            });
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value2",
                Value = "Value2",
                Selected = MyViewData["DropDownList1"] != null && 
                    MyViewData["DropDownList1"].ToString() == "Value2"
            });
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value3",
                Value = "Value3",
                Selected = MyViewData["DropDownList1"] != null && 
                    MyViewData["DropDownList1"].ToString() == "Value3"
            });
            DropDownList1.Add(new SelectListItem
            {
                Text = "Value4",
                Value = "Value4",
                Selected = MyViewData["DropDownList1"] != null && 
                    MyViewData["DropDownList1"].ToString() == "Value4"
            });

            MyViewData.Add("DropDownList1Items", DropDownList1);

            MyViewData.Add("SampleCheckbox", collection["ChkSampleCheckbox"]);

            MyViewData.Add("SampleText2", collection["TxtSampleText2"]);
            MyViewData.Add("SampleText3", collection["TxtSampleText3"]);

            return MyViewData;
        }
    }
}
