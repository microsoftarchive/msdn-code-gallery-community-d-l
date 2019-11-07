using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;

namespace MvcApplication5.Models
{
    public class Class1
    {

       public string EmailAdress { get; set; }
        public string button { get; set; }
        public string txtTo { get; set; }
        string txtSubject { get; set; }
        string txtMessage { get; set; }
        string descripcion { get; set; }
        public HttpPostedFileBase fichero { get; set; }
        public ContentType Failed { get; set; }
        public ContentType Send { get; set; }
        public Attachment data { get; set; }
    }
}