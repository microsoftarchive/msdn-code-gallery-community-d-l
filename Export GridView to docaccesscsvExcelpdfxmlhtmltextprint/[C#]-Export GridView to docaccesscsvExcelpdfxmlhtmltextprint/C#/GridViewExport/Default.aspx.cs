using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Windows.Forms;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace GridViewExport
{
    public partial class _Default : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridDetails(GridView1);
            }
        }
        
        protected DataTable BindGridDetails(GridView GridView1)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Student_ID", typeof(Int32));
            dt.Columns.Add("Student_Name", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("City", typeof(string));
            DataRow dtrow = dt.NewRow();
            dtrow["Student_ID"] = 1;
            dtrow["Student_Name"] = "Musakkhir";
            dtrow["Education"] = "MCA";
            dtrow["City"] = "Pune";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();
            dtrow["Student_ID"] = 2;
            dtrow["Student_Name"] = "Azhar";
            dtrow["Education"] = "M.E";
            dtrow["City"] = "Mumbai";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();
            dtrow["Student_ID"] = 3;
            dtrow["Student_Name"] = "Pervaiz";
            dtrow["Education"] = "M.Tech";
            dtrow["City"] = "Pune";
            dt.Rows.Add(dtrow);
            dtrow = dt.NewRow();
            dtrow["Student_ID"] = 4;
            dtrow["Student_Name"] = "Mustaheer";
            dtrow["Education"] = "M.S.";
            dtrow["City"] = "Pune";
            dt.Rows.Add(dtrow);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            return dt;
        }

        protected void btnExcelExport_Click(object sender, EventArgs e)
        {
            HtmlForm form = new HtmlForm();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "Student.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            BindGridDetails(GridView1);
            form.Attributes["runat"] = "server";
            form.Controls.Add(GridView1);
            this.Controls.Add(form);
            form.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@;}</style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }


        protected void btnWord_Click(object sender, EventArgs e)
        {
            HtmlForm form = new HtmlForm();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "Student.doc"));
            Response.ContentType = "application/ms-msword";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            BindGridDetails(GridView1);
            form.Attributes["runat"] = "server";
            form.Controls.Add(GridView1);
            this.Controls.Add(form);
            form.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@;}</style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnAccess_Click(object sender, EventArgs e)
        {
            //String accessConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/test.accdb;";
            //String sqlConnectionString = ConfigurationManager.ConnectionStrings["College"].ConnectionString;

            ////Make adapters for each table we want to export
            //SqlDataAdapter adapter1 = new SqlDataAdapter();
            ////  SqlDataAdapter adapter2 = new SqlDataAdapter();
            //DataTable dtFillGrid = (DataTable)ViewState["FillGrid"];
            ////Fills the data set with data from the SQL database
            //// DataSet dataSet = new DataSet();
            //adapter1.Fill(dtFillGrid);
            ////  adapter2.Fill(dataSet, "Table2");

            ////Create an empty Access file that we will fill with data from the data set
            //ADOX.Catalog catalog = new ADOX.Catalog();
            //catalog.Create(accessConnectionString);

            ////Create an Access connection and a command that we'll use
            //OleDbConnection accessConnection = new OleDbConnection(accessConnectionString);
            //OleDbCommand command = new OleDbCommand();
            //command.Connection = accessConnection;
            //command.CommandType = CommandType.Text;
            //accessConnection.Open();

            ////This loop creates the structure of the database
            //foreach (DataTable table in dtFillGrid.Rows)
            //{
            //    String columnsCommandText = "(";
            //    foreach (DataColumn column in table.Columns)
            //    {
            //        String columnName = column.ColumnName;
            //        String dataTypeName = column.DataType.Name;
            //        String sqlDataTypeName = getSqlDataTypeName(dataTypeName); 
            //        columnsCommandText += "[" + columnName + "] " + sqlDataTypeName + ",";
            //    }
            //    columnsCommandText = columnsCommandText.Remove(columnsCommandText.Length - 1);
            //    columnsCommandText += ")";

            //    command.CommandText = "CREATE TABLE " + table.TableName + columnsCommandText;

            //    command.ExecuteNonQuery();
            //}

            ////This loop fills the database with all information
            //foreach (DataTable table in dtFillGrid.Rows)
            //{
            //    foreach (DataRow row in table.Rows)
            //    {
            //        String commandText = "INSERT INTO " + table.TableName + " VALUES (";
            //        foreach (var item in row.ItemArray)
            //        {
            //            commandText += "'" + item.ToString() + "',";
            //        }
            //        commandText = commandText.Remove(commandText.Length - 1);
            //        commandText += ")";

            //        command.CommandText = commandText;
            //        command.ExecuteNonQuery();
            //    }
            //}

            //accessConnection.Close();
            HtmlForm form = new HtmlForm();
            GridView1.AllowPaging = false;
            BindGridDetails(GridView1);
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.accdb"));
            Response.Charset = "";
            Response.ContentType = "application/ms-access";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            form.Attributes["runat"] = "server";
            form.Controls.Add(GridView1);
            this.Controls.Add(form);
            Form.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnExportCSV_Click(object sender, EventArgs e)
        {
            BindGridDetails(GridView1);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition","attachment;filename=Student.csv");
                Response.Charset = "";
                Response.ContentType = "application/text";
                GridView1.AllowPaging = false;
                GridView1.DataBind();
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < GridView1.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(GridView1.Columns[k].HeaderText + ',');
                }
                //append new line
                sb.Append("\r\n");
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < GridView1.Columns.Count; k++)
                    {
                        //add separator
                        sb.Append(GridView1.Rows[i].Cells[k].Text + ',');
                    }
                    //append new line
                    sb.Append("\r\n");
                }
                Response.Output.Write(sb.ToString());
                Response.Flush();
                Response.End();
        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Student.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            HtmlForm frm = new HtmlForm();
            GridView1.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(GridView1);
            frm.RenderControl(hw);
            GridView1.DataBind();
            StringReader sr = new StringReader(sw.ToString());
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        
        protected void btnXML_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(new ThreadStart(XMLExport));
            staThread.ApartmentState = ApartmentState.STA;
            staThread.Start();
        }

        public void XMLExport()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Xml files (*.xml)|*.xml";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;
            saveDialog.InitialDirectory = "c:\\";
            saveDialog.FileName = "Student";
            saveDialog.Title = "XML Export";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                BindGridDetails(GridView1);
                DataSet ds = new DataSet();
               DataTable dt = (DataTable)GridView1.DataSource;
                ds.Tables.Add(dt);
               // ds.WriteXml(File.OpenWrite(saveDialog.FileName));
            } 
        }

        protected void btnHTML_Click(object sender, EventArgs e)
        {
            HtmlForm form = new HtmlForm();
            GridView1.AllowPaging = false;
            BindGridDetails(GridView1);
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Student.html"));
            Response.Charset = "";
            Response.ContentType = "text/html";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            form.Attributes["runat"] = "server";
            form.Controls.Add(GridView1);
            this.Controls.Add(form);
            Form.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnText_Click(object sender, EventArgs e)
        {
            BindGridDetails(GridView1);
            GridView1.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Student.txt"));
            Response.ContentType = "application/text";
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                str.Append(GridView1.Columns[i].HeaderText + ' ');
            }
            str.Append("\r\n");
            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                for (int k = 0; k < GridView1.Columns.Count; k++)
                {
                    str.Append(GridView1.Rows[j].Cells[k].Text + ' ');
                }
                str.Append("\r\n");
            }
            Response.Write(str.ToString());
            Response.End();
        }

        protected void btnExportImage_Click(object sender, EventArgs e)
        { 
           // Bitmap bm = new Bitmap(GridView1.Width.Value, GridView1.Height.Value);
            //GridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.GridView1.Width, this.GridView1.Height));
            //e.Graphics.DrawImage(bm, 0, 0);
            ConvertDG2BMP(GridView1, "c:/myscreen.bmp");
        }

        public static void ConvertDG2BMP(GridView gdview, string sFilePath)
        {
            Bitmap bitmap = new Bitmap
         (Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            
            Graphics graphics = Graphics.FromImage(bitmap as System.Drawing.Image);
            graphics.CopyFromScreen(25, 25, 25, 25, bitmap.Size);
            bitmap.Save("c:/myscreenshot.bmp", ImageFormat.Bmp);
        }
    }
}
