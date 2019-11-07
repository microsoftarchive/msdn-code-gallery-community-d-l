using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MvcApplication5.Controllers
{
    public class HomeController : Controller
    {
       
        DataTable dt = new DataTable();
        MailMessage mail = new MailMessage();
        string PathFile = @"C:/VS2010.pdf";

        private void SendEmail(string EmailAddress, string txtSubject, string txtMessage)
        {


            mail.To.Add(EmailAddress);
            mail.From = new MailAddress("zbarrerar@gmail.com");
            mail.Subject = txtSubject;
            mail.Body = txtMessage;


           mail.IsBodyHtml = true;
          
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("zbarrerar@gmail.com", "yagami123");
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
        public static DataTable DBCorreos()
        {
            DataTable dt = new DataTable();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString());//cadena conexion

            string consulta = "SELECT * FROM Correos"; //consulta a la tabla paises
            SqlCommand comando = new SqlCommand(consulta, conexion);

            SqlDataAdapter adap = new SqlDataAdapter(comando);

            adap.Fill(dt);
            return dt;
        }


        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home/
      

        public ActionResult Upload(string button, string txtTo, string txtSubject,
              string txtMessage, HttpPostedFileBase fichero)

            
             {
            Attachment data = new Attachment(PathFile, MediaTypeNames.Application.Pdf);

                    // Add the file attachment to this e-mail message.
            mail.Attachments.Add(data);
            if (button.Equals( "Enviar Correo"))
            {

                try
                {

                    string[] to = txtTo.Split(';');

                    foreach (string emailAdd in to)
                    {

                        if (!string.IsNullOrEmpty(emailAdd))
                            SendEmail(emailAdd, txtSubject, txtMessage);
                    }

                    txtTo = dt.ToString();
                    txtSubject = "";
                    txtMessage = "";

                   return Content("Message sent.");

                }
                catch
                {
                    return Content("Message failed.");
                }

            }
            return View();

        }
    }
}

