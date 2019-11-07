using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using Client.Tests;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            string operationDone = String.Empty;

            do
            {
                Console.WriteLine("0 - Commit transaction");
                Console.WriteLine("1 - Client does not commit transaction (all operations are rolled back)");
                Console.WriteLine("2 - Raise exception from other AppDomain (all operations are rolled back)");
                Console.WriteLine("3 - Raise exception locally (all operations are rolled back)");
                Console.WriteLine(Environment.NewLine + "Press ESC to terminate..." + Environment.NewLine);

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D0:
                        ServerAndClientCommitted.Execute();
                        operationDone = "Commit performed";
                        break;

                    case ConsoleKey.D1:
                        ClientDoesNotCommitTransaction.Execute();
                        operationDone = "No commit executed";
                        break;

                    case ConsoleKey.D2:
                        try { ServerThrowException.Execute(); }
                        catch { operationDone = "Remote exception"; }
                        break;

                    case ConsoleKey.D3:
                        try { ClientThrowException.Execute(); }
                        catch { operationDone = "Local exception"; }
                        break;

                    case ConsoleKey.Escape:
                        return;
                }

                PrintResultsAfterOperations(operationDone);
            }
            while (key != ConsoleKey.Escape);
        }

        private static void PrintResultsAfterOperations(string operationDone)
        {
            var originalColor = Console.ForegroundColor;
            Console.WriteLine(new String('*', 60));
            Console.ForegroundColor = operationDone.StartsWith("Commit") ? ConsoleColor.DarkGreen : ConsoleColor.Red;
            Console.WriteLine("Results: " + operationDone);
            Console.ForegroundColor = originalColor;
            Console.WriteLine(new String('*', 60));

            int index = 1;
            Console.WriteLine(Environment.NewLine + "LOCAL DB Content");
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringClient"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT [Name], [CreatedOn] FROM [dbo].[Table_A]", connection))
                {
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read()) Console.WriteLine("{0}) Name = {1} - CreatedOn = {2}", index++, dataReader.GetString(0), dataReader.GetDateTime(1));
                }
            }

            index = 1;
            Console.WriteLine(Environment.NewLine + "REMOTE DB Content");
            using (var httpClient = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, ConfigurationManager.AppSettings["urlGet"]))
                {
                    var httpResponseMessage = httpClient.SendAsync(requestMessage).Result;
                    httpResponseMessage.EnsureSuccessStatusCode();
                    var dataTable = httpResponseMessage.Content.ReadAsAsync<DataTable>().Result;

                    IDataReader dataReader = dataTable.CreateDataReader();
                    while (dataReader.Read()) Console.WriteLine("{0}) Id = {1} - CreatedOn = {2}", index++, dataReader.GetString(0), dataReader.GetDateTime(1));
                }
            }

            Console.WriteLine();
        }
    }
}
