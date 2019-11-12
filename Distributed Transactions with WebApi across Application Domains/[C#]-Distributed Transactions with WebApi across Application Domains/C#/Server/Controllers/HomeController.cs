using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Filters;

namespace WebApplication.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var dataTable = new DataTable("Table1");
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [CreatedOn] FROM [Table_1] ORDER BY [CreatedOn] DESC";
                    dataTable.Load(command.ExecuteReader());
                }
            }

            return this.Request.CreateResponse<DataTable>(HttpStatusCode.OK, dataTable);
        }

        [HttpPost]
        [EnlistToDistributedTransactionActionFilter]
        public HttpResponseMessage Post(string id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("INSERT INTO [Table_1] ([Id], [CreatedOn]) VALUES ('{0}', GETDATE())", id);
                    command.ExecuteNonQuery();
                }
            }

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = id }));
            return response;
        }
    }
}