using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd
{
    public class DataOperations : SqlConnectionProperties
    {
        /// <summary>
        /// Method inserts records based on pPlayerList into a SQL-Server table.
        /// The focus is for the most part on setting up the parameters for the
        /// inserting of records.
        /// </summary>
        /// <param name="pPlayerList"></param>
        /// <returns></returns>
        public bool InsertRecordsFromTextFileImport(List<Player> pPlayerList)
        {
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    /*
                     * Construct an INSERT statement with a SELECT which provides the new primary
                     * key on a successful insert.
                     * 
                     * INSERT/SELECT was generated via part of a code sample I wrote
                     * https://code.msdn.microsoft.com/Working-with-SQL-Server-986fff9e
                     * 
                     * where you select a database from a ComboBox, select a table from a ListBox
                     * then select columns from a CheckedListBox which in turn create a INSERT/SELECT
                     * statement.
                     */
                    cmd.CommandText = "INSERT INTO Players " + 
                                      "(Name,Team,Position,Height,[Weight],Age) " + 
                                      "VALUES (@Name,@Team,@Position,@Height,@Weight,@Age); " + 
                                      "SELECT CAST(scope_identity() AS int);";

                    /*
                     * Setup parameters (one only inserting one row we would use cmd.Parameters.AddWithValue
                     * yet in a for-each we can't unless we clear the parameter collection and set the values
                     * on each iteration while doing the parameters as shown below is better.
                     * 
                     * Usually what I see on forums is a new to data operations developer will not only 
                     * re-create parameters in a for-each but also they will be opening/closing a connection,
                     * creating a new command, re-open a connection, run the query, not check for errors
                     * or get the new id which with not many records might be acceptable to them yet when dealing
                     * with many rows or many rows and many columns this most likely will slow things down and
                     * make it harder to maintain the code.
                     */
                    cmd.Parameters.Add(new SqlParameter() {ParameterName = "@Name", DbType = DbType.String });
                    cmd.Parameters.Add(new SqlParameter() {ParameterName = "@Team", DbType = DbType.String });
                    cmd.Parameters.Add(new SqlParameter() {ParameterName = "@Position",DbType = DbType.String});
                    cmd.Parameters.Add(new SqlParameter() {ParameterName = "@Height", DbType = DbType.Int32 });
                    cmd.Parameters.Add(new SqlParameter() {ParameterName = "@Weight", DbType = DbType.Int32 });
                    cmd.Parameters.Add(new SqlParameter() {ParameterName = "@Age", DbType = DbType.Decimal });

                    try
                    {

                        cn.Open();

                        foreach (Player player in pPlayerList)
                        {
                            /*
                             * Since we setup parameters once above we simply index to the proper
                             * parameter and set it's value
                             */
                            cmd.Parameters["@Name"].Value = player.Name;
                            cmd.Parameters["@Team"].Value = player.Team;
                            cmd.Parameters["@Position"].Value = player.Position;
                            cmd.Parameters["@Height"].Value = player.Height;
                            cmd.Parameters["@Weight"].Value = player.Weight;
                            cmd.Parameters["@Age"].Value = player.Age;

                            /*
                             * As we have an insert and select the ExecuteScalar returns
                             * the result of the select part of our CommandText. We get
                             * back the identity/primary key for the newly added record
                             * from ExecuteScalar cast from object to int.
                             */
                            player.id = Convert.ToInt32(cmd.ExecuteScalar());

                        }
                        
                    }
                    catch (Exception ex)
                    {
                        mHasException = true;
                        mLastException = ex;
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
