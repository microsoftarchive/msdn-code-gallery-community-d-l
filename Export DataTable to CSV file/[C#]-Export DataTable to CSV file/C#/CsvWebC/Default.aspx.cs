using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CsvWebC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            String strDownloadFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

            // Your Function for Retrieving Data
            DataTable dtA = RetrieveData();

            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment; filename=" + strDownloadFileName); // myData - file name (also can be bring from DB)

            //MyData - your data ...
            Byte[] myData = csvBytesWriter(ref dtA);

            Response.BinaryWrite(myData);  // Binary data - see myData -  
            Response.End();
        }

        protected DataTable RetrieveData()
        {
            DataTable dt = new DataTable();
            // Here you LOGIC for Retrieving Data Table...

            //Below just for test purpose ...
            dt.TableName = "TEST";
            dt.Columns.Add("TestA");
            dt.Columns.Add("TestB");
            dt.Columns.Add("TestC");
            dt.Columns.Add("TestD,E");

            DataRow dr = dt.NewRow();
            dr["TestA"] = @"A' ";
            dr["TestB"] = @"B"" ";
            dr["TestC"] = @"C<> ";
            dr["TestD,E"] = @",C, ";

            dt.Rows.Add(dr);
            return dt;
        }

        public byte[] csvBytesWriter(ref DataTable dTable)
        {

            //--------Columns Name---------------------------------------------------------------------------

            StringBuilder sb = new StringBuilder();
            int intClmn = dTable.Columns.Count;

            int i = 0;
            for (i = 0; i <= intClmn - 1; i += 1)
            {
                sb.Append(@"""" + dTable.Columns[i].ColumnName.ToString() + @"""");
                if (i == intClmn - 1)
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(",");
                }
            }
            sb.Append(Environment.NewLine);

            //--------Data By  Columns---------------------------------------------------------------------------


            foreach (DataRow row in dTable.Rows)
            {
                int ir = 0;
                for (ir = 0; ir <= intClmn - 1; ir += 1)
                {
                    sb.Append(@"""" + row[ir].ToString().Replace(@"""", @"""""") + @"""");
                    if (ir == intClmn - 1)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append(",");
                    }

                }
                sb.Append(Environment.NewLine);
            }

            return System.Text.Encoding.UTF8.GetBytes(sb.ToString());

        }



    }
}