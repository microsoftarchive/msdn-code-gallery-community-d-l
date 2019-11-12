using System;
using System.IO;
using System.Net.Mail;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class ConvertAndEmailController : Controller
    {
        // GET: ConvertAndEmail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fields)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            try
            {
                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertUrl(fields["TxtUrl"]);

                // create memory stream to save PDF
                MemoryStream pdfStream = new MemoryStream();

                // save pdf document into a MemoryStream
                doc.Save(pdfStream);

                // reset stream position
                pdfStream.Position = 0;

                // create email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress("support@selectpdf.com");
                message.To.Add(new MailAddress(fields["TxtEmail"]));
                message.Subject = "SelectPdf Sample - Convert and Email as Attachment";
                message.Body = "This email should have attached the PDF document " +
                    "resulted from the conversion of the following url to pdf: " +
                    fields["TxtUrl"];
                message.Attachments.Add(new Attachment(pdfStream, "Document.pdf"));

                // send email
                new SmtpClient().Send(message);

                // close pdf document
                doc.Close();

                ViewData["Message"] = "Email sent";
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "An error occurred: " + ex.Message;
            }

            return View();
        }
    }
}