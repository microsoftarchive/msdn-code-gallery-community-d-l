using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using System.Transactions;

namespace Client.Tests
{
    public static class ServerThrowException
    {
        public static void Execute()
        {
            using (var scope = new TransactionScope())
            {
                var id = new Random().Next(0, 1000).ToString(CultureInfo.InvariantCulture);

                // cross app domain call
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, String.Format(ConfigurationManager.AppSettings["urlPost"], id)))
                    {
                        // forward transaction token
                        request.AddTransactionPropagationToken();
                        var response = client.SendAsync(request).Result;
                        response.EnsureSuccessStatusCode();
                    }

                    // Here we are sending the same Id. Because this field is a unique primary key, the DB throw an exception
                    // Using the HttpResponseMessage.EnsureSuccessStatusCode() we check if the HTTP response status code is 200.
                    // If is not, the EnsureSuccessStatusCode() method thor an exception, forcing the execution to get out from the using 
                    // scope without invoking the Complete() method ending up with a server and client rollback. 
                    using (var request = new HttpRequestMessage(HttpMethod.Post, String.Format(ConfigurationManager.AppSettings["urlPost"], id)))
                    {
                        // forward transaction token
                        request.AddTransactionPropagationToken();
                        var response = client.SendAsync(request).Result;
                        response.EnsureSuccessStatusCode();
                    }
                }

                // insert data in local database
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringClient"].ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(String.Format("INSERT INTO [Table_A] ([Name], [CreatedOn]) VALUES ('{0}', GETDATE())", id), connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                scope.Complete();
            }
        }
    }
}