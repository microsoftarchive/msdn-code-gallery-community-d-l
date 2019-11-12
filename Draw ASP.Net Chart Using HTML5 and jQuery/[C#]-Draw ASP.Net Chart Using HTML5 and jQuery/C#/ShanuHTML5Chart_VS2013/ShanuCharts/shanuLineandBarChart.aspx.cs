using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Services;
using System.Data;
using System.Web.Services;
using System.IO;


/// <summary>
/// Author      : Shanu
/// Create date : 2015-03-02
/// Description : SHANU WEB  Chart USING HTML 5 CANVAS
/// Latest      : Ver1.0
/// Modifier    : SHANU
/// Modify date : 2015-03-02
/// </summary>


namespace ShanuHTML5Chart_VS2013.ShanuCharts
{
     [ScriptService]
    public partial class shanuLineandBarChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDropDownList();
        }

        [WebMethod()]
        [ScriptMethod]
        public static string SaveImage(string imageData)
        {

            Random rnd = new Random();
            String Filename = HttpContext.Current.Server.MapPath("Shanuimg" + rnd.Next(12, 2000).ToString() + ".png");
            string Pic_Path = Filename;//HttpContext.Current.Server.MapPath("ShanuHTML5DRAWimg.png");
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
            return "Image Saved in your Application folder ->" + Pic_Path;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindDropDownList();
        }

        private void BindDropDownList()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Rows.Clear();
            dt.Columns.Add("Names");
            dt.Columns.Add("Frequency");
            dt.Columns["Frequency"].DataType = Type.GetType("System.Int32");


            Random random = new Random();

            for (int i = 1; i <= Convert.ToInt32(txtChartCount.Text.Trim()); i++)
            {
                DataRow row = dt.NewRow();
                Int32 value = random.Next(100, 600);
                row["Names"] = "Line-" + i.ToString() + " - (" + value + ") ";
                row["Frequency"] = value;


                dt.Rows.Add(row);


                //hidFirstVal.
            }
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Names";
            DropDownList1.DataValueField = "Frequency";
            DropDownList1.DataBind();

            // Get the Minimum value of Dropdown List and save it in hidden field to be used to draw  the bar Chart
            int minValue = DropDownList1.Items.Cast<ListItem>().Select(item =>
             int.Parse(item.Value)).Min();
            hidListMin.Value = minValue.ToString();

            // Get the Maximum value of Dropdown List and save it in hidden field to be used to draw  the bar Chart
            int maxValue = DropDownList1.Items.Cast<ListItem>().Select(item =>
                int.Parse(item.Value)).Max();

            hidListMax.Value = maxValue.ToString();


        }
    }
 }