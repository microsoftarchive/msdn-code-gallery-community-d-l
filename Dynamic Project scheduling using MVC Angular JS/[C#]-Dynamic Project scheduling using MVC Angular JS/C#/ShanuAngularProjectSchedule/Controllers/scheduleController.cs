using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShanuAngularProjectSchedule.Controllers
{
    public class scheduleController : ApiController
    {
        // to Search Student Details and display the result
        [HttpGet]
        public DataTable projectScheduleSelect(string projectID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["shanuConnectionString"].ConnectionString;
            DataTable dt = new DataTable();

            SqlConnection objSqlConn = new SqlConnection(connStr);

            objSqlConn.Open();
            SqlCommand command = new SqlCommand("usp_ProjectSchedule_Select", objSqlConn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@projectId", SqlDbType.VarChar).Value = projectID;
            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);

            return dt;
        }
    }
}
