using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class PdfConverterSecurityController : Controller
    {
        // GET: PdfConverterSecurity
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from the webpage
            string url = collection["TxtUrl"];

            string userPassword = collection["TxtUserPassword"];
            string ownerPassword = collection["TxtOwnerPassword"];

            bool canAssembleDocument = collection["ChkCanAssembleDocument"] == "on";
            bool canCopyContent = collection["ChkCanCopyContent"] == "on";
            bool canEditAnnotations = collection["ChkCanEditAnnotations"] == "on";
            bool canEditContent = collection["ChkCanEditContent"] == "on";
            bool canFillFormFields = collection["ChkCanFillFormFields"] == "on";
            bool canPrint = collection["ChkCanPrint"] == "on";

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set document passwords
            if (!string.IsNullOrEmpty(userPassword))
            {
                converter.Options.SecurityOptions.UserPassword = userPassword;
            }
            if (!string.IsNullOrEmpty(ownerPassword))
            {
                converter.Options.SecurityOptions.OwnerPassword = ownerPassword;
            }

            //set document permissions
            converter.Options.SecurityOptions.CanAssembleDocument = canAssembleDocument;
            converter.Options.SecurityOptions.CanCopyContent = canCopyContent;
            converter.Options.SecurityOptions.CanEditAnnotations = canEditAnnotations;
            converter.Options.SecurityOptions.CanEditContent = canEditContent;
            converter.Options.SecurityOptions.CanFillFormFields = canFillFormFields;
            converter.Options.SecurityOptions.CanPrint = canPrint;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
        }
    }
}