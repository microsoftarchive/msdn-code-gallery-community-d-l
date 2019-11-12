using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Services;
using System.Text;
using System.IO;

public partial class Grid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Fill_List(49);
           
        }
    }

    private void Fill_List(int Rows)
    {
        string Imagespath = HttpContext.Current.Server.MapPath("~/Images/");
        string SitePath = HttpContext.Current.Server.MapPath("~");
        var Files = (from file in Directory.GetFiles(Imagespath) select new { image = file.Replace(SitePath, "~") }).Take(Rows);
        ImageGrid.DataSource = Files.ToList();
        ImageGrid.DataBind();
    }
    [WebMethod]
    public static string LoadImages(int Skip, int Take)
    {
        System.Threading.Thread.Sleep(2000);
        StringBuilder GetImages = new StringBuilder();
        string Imagespath = HttpContext.Current.Server.MapPath("~/Images/");
        string SitePath = HttpContext.Current.Server.MapPath("~");
        var Files = (from file in Directory.GetFiles(Imagespath) select new { image = file.Replace(SitePath, "") }).Skip(Skip).Take(Take);
        foreach (var file in Files)
        {
            var imageSrc = file.image.Replace("\\","/").Substring(1); //Remove First '/' from image path
            GetImages.AppendFormat("<a>");
            GetImages.AppendFormat("<li>");
            GetImages.AppendFormat(string.Format("<img src='{0}'/>", imageSrc));
            GetImages.AppendFormat("</li>");
            GetImages.AppendFormat("</a>");


        }
        return GetImages.ToString();
    }
}