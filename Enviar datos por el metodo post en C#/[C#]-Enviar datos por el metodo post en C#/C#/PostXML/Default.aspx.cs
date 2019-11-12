using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace PostXML
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void PostXML(string fileName, string uri)
        {
           // Creamos un request usando una url que resibira el post. 
            WebRequest request = WebRequest.Create(uri);
            // Seteamos la propiedad Method del request a POST.
            request.Method = "POST";
            // Creamos lo que se va a enviar por el metodo POST y lo convertimos a byte array.
            string postData = this.GetTextFromXMLFile(fileName);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Seteamos el ContentType del WebRequest a xml.
            request.ContentType = "text/xml";
            // Seteamos el ContentLength del WebRequest.
            request.ContentLength = byteArray.Length;
            // Obtenemos el request stream.
            Stream dataStream = request.GetRequestStream();
            // escribimos la data en el request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Cerramos el Stream object.
            dataStream.Close();
           
        }

        private string GetTextFromXMLFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        protected void boton1_Click(object sender, EventArgs e)
        {
            PostXML(Server.MapPath("~/test.xml"), "http://localhost:5261/recive.aspx");
        }

        protected void boton2_Click(object sender, EventArgs e)
        {
           Response.Redirect("~/recive.aspx");
        }
    }
}