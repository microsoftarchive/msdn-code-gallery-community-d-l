using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImportExcel_SqlServer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string FilePath="";
             FilePath = Server.MapPath("~/App_Data/" +  FileUpload1.PostedFile.FileName);
            if (FileUpload1.HasFile)
            {
                ImportDataFromExcel(FilePath);
            }
        }

        public void ImportDataFromExcel(string excelFilePath)
        {
            //declare variables - edit these based on your particular situation
            string ssqltable = "Table1";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different
            string myexceldataquery = "select student,rollno,course from [Sheet1$]";
            try
            {
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelFilePath +
                ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                string ssqlconnectionstring = "Data Source=SAYYED;Initial Catalog=SyncDB;Integrated Security=True";
                //execute a query to erase any previous data from our destination table
                string sclearsql = "delete from " + ssqltable;
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = ssqltable;
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                Label1.Text = "File imported into sql server.";
            }
            catch (Exception ex)
            {
                //handle exception
            }
        }
    }
}