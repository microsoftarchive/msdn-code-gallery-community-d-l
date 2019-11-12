using System;
using System.Text;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class ViewHttpPostDataController : Controller
    {
        // GET: ViewHttpPostData
        public ActionResult Index()
        {
            StringBuilder output = new StringBuilder();
            output.Append("<br/>Request method: " +
                Request.HttpMethod + "<br/>");

            // Load POST form fields collection.
            NameValueCollection form = Request.Form;

            // Put the names of all keys into a string array.
            String[] keys = form.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                output.Append("Name: " + keys[i] + "<br/>");

                // Get all values under this key.
                String[] values = form.GetValues(keys[i]);
                for (int j = 0; j < values.Length; j++)
                {
                    output.Append("Value: " + values[j] + "<br/>");
                }
                output.Append("<br/>");
            }

            ViewData.Add("PostDataValue", output.ToString());

            return View();
        }
    }
}