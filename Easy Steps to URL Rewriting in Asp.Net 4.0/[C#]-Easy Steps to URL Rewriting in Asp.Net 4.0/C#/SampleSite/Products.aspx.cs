using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdventureWorksModel;
public partial class Products : System.Web.UI.Page
{
    AdventureWorksEntities awe = new AdventureWorksEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        int catid = Convert.ToInt32(HttpContext.Current.Items["catid"]);

        var product = awe.Products.Where(item => item.ProductSubcategoryID == catid);

        GridView1.DataSource = product;
        GridView1.DataBind();
    }

    void Bind()
    {
        
    }
}