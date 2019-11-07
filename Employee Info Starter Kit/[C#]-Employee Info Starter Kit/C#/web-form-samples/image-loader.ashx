<%@ WebHandler Language="C#" Class="image_loader" %>

using System;
using System.Web;
using System.IO;

public class image_loader : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Buffer = true;
        context.Response.ContentType = "image/gif";
        byte[] byteArray = null;
        
        if (context.Request["ImageBinary"] != string.Empty)
            byteArray = new Eisk.BusinessLogicLayer.EmployeeBLL().GetEmployeeByEmployeeId(Int32.Parse(context.Request["ImageBinary"], System.Globalization.CultureInfo.CurrentCulture.NumberFormat)).Photo;
        
        if (byteArray != null)
            context.Response.BinaryWrite(byteArray);
        else
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(context.Server.MapPath("~/App_Resources/images/noimage.gif"));
            MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.BinaryWrite(ms.ToArray());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}