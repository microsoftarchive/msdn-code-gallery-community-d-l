using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using System.Transactions;

namespace Client.Tests
{
    public static class ServerAndClientCommitted
    {
        public static void Execute()
        {
            var id = new Random().Next(0, 1000).ToString(CultureInfo.InvariantCulture);

            using (var scope = new TransactionScope())
            {
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
                
                // Commit client and server operation
                scope.Complete();
            }
        }
    }
}