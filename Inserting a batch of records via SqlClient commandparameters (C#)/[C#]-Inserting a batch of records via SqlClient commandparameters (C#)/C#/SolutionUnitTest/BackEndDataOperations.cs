using BackEnd;
using System;
using System.Data.SqlClient;

namespace SolutionUnitTest
{
    public class BackEndDataOperations : SqlConnectionProperties
    {
        /// <summary>
        /// Used to clear the table prior to running a unit test which
        /// checks to see if there are 1000 rows, without this method
        /// the unit test would fail
        /// </summary>
        public void TruncatePlayersTable()
        {
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "TRUNCATE TABLE dbo.Players";
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Get record count for unit test to check we did insert 1000 records
        /// </summary>
        /// <returns></returns>
        public int GetPlayerCount()
        {
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cn.Open();
                    cmd.CommandText = "SELECT COUNT(*) FROM dbo.Players";
                    var recordCount = (Int32)cmd.ExecuteScalar();
                    return recordCount;
                }
            }
        }
    }
}
