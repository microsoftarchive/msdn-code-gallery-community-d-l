using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DragandDrop
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Value") });
                dt.Rows.Add(1, 450);
                dt.Rows.Add(2, 3200);
                dt.Rows.Add(3, 1900);
                dt.Rows.Add(4, 185);
                dt.Rows.Add(5, 100);
                dt.Rows.Add(6, 120);
                dt.Rows.Add(7, 290);
                dt.Rows.Add(8, 150);
                dt.Rows.Add(9, 1900);
                dt.Rows.Add(10, 1585);
                dt.Rows.Add(11, 1060);
                dt.Rows.Add(12, 1220);
                gvSource.UseAccessibleHeader = true;
                gvSource.DataSource = dt;
                gvSource.DataBind();

                dt.Rows.Clear();
                dt.Rows.Add();
                gvDest.DataSource = dt;
                gvDest.DataBind();
            }
        }
    }
}