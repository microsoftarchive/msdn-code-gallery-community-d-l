using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Import_Click(object sender, EventArgs e)
    { 
        // if you have Excel 2007 uncomment this line of code
        //  string excelConnectionString =string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0",path);
      
        string ExcelContentType = "application/vnd.ms-excel";
        string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        if (FileUpload1.HasFile)
        {
            //Check the Content Type of the file
            if(FileUpload1.PostedFile.ContentType==ExcelContentType || FileUpload1.PostedFile.ContentType==Excel2010ContentType)
            {
                try
                {
                    //Save file path
                    string path = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload1.FileName);
                    //Save File as Temp then you can delete it if you want
                    FileUpload1.SaveAs(path);
                    //string path = @"C:\Users\Johnney\Desktop\ExcelData.xls";
                    //For Office Excel 2010  please take a look to the followng link  http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e
                    string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

                    // Create Connection to Excel Workbook
                    using (OleDbConnection connection =
                                 new OleDbConnection(excelConnectionString))
                    {
                        OleDbCommand command = new OleDbCommand
                                ("Select * FROM [Sheet1$]", connection);

                        connection.Open();

                        // Create DbDataReader to Data Worksheet
                        using (DbDataReader dr = command.ExecuteReader())
                        {

                            // SQL Server Connection String
                            string sqlConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=ExcelDB;Integrated Security=True";

                            // Bulk Copy to SQL Server
                            using (SqlBulkCopy bulkCopy =
                                       new SqlBulkCopy(sqlConnectionString))
                            {
                                bulkCopy.DestinationTableName = "Employee";
                                bulkCopy.WriteToServer(dr);
                                Label1.Text = "The data has been exported succefuly from Excel to SQL";
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
            }
        }
    }
}