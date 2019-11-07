using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Example_cs.Classes
{
    public class DataOperations
    {
        /// <summary>
        /// The connection is pointing to my SQL-Server instance, depending on your SQL-Server install you may need to change
        /// Data Source=KARENS-PC to Data Source=SQLEXPRESS 
        /// Here is a web page to assist with setting the connection up
        /// 
        /// https://www.connectionstrings.com/sql-server/
        /// 
        /// </summary>
        private string ConnectionString = "Data Source=KARENS-PC;Initial Catalog=ExampleDataGridViewComboBox_1;Integrated Security=True";

        public DataTable PersonsTable = new DataTable();
        public DataTable ColorTable = new DataTable();
        public DataTable InformationTable = new DataTable();

        public Dictionary<int, string> ColorDictionary = new Dictionary<int, string>();

        public ErrorInformation Exception = new ErrorInformation();
        /// <summary>
        /// Gets data for DataGridView
        /// </summary>
        public void GetData()
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception ex)
                    {
                        Exception.HasError = true;
                        Exception.Message = ex.Message;
                    }


                    cmd.CommandText = "SELECT ColorId,ColorText FROM Colors";
                    ColorTable.Load(cmd.ExecuteReader());
                    try
                    {

                        foreach (DataRow row in ColorTable.Rows)
                        {
                            ColorDictionary.Add(row.Field<int>("ColorId"), row.Field<string>("ColorText"));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    cmd.CommandText = "SELECT Id,[Text] FROM Information";
                    InformationTable.Load(cmd.ExecuteReader());
                    cmd.CommandText = "SELECT Id,ColorId ,FirstName FROM Person";
                    PersonsTable.Load(cmd.ExecuteReader());
                    Console.WriteLine();
                }
            }
        }
        /// <summary>
        /// Update a row in the Person table
        /// </summary>
        /// <param name="PersonId">Primary key for a specific record</param>
        /// <param name="ColorId">Key to the color to update</param>
        /// <returns></returns>
        public bool UpdatePerson(int PersonId, int ColorId)
        {
            int Result = 0;
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "UPDATE Person SET ColorId = @ColorId WHERE Id = @PersonId";
                    cmd.Parameters.AddWithValue("@ColorId", ColorId);
                    cmd.Parameters.AddWithValue("@PersonId", PersonId);

                    try
                    {
                        cn.Open();
                    }
                    catch (Exception ex)
                    {
                        Exception.HasError = true;
                        Exception.Message = ex.Message;
                    }

                    try
                    {
                        Result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return Result == 1;

        }
    }
    /// <summary>
    /// Provides a container for DataOperations error information
    /// </summary>
    public class ErrorInformation
    {
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
