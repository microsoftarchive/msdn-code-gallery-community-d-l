using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

using MasaSam.Data.Common;

namespace MasaSam.Data.SqlClient
{
    /// <summary>
    /// <see cref="DbExecutor"/> for the SQL server.
    /// </summary>
    public sealed class SqlExecutor : DbExecutor
    {
        #region Ctor

        /// <summary>
        /// Initializes new instance.
        /// </summary>
        /// <param name="connectionString">Connection string to SQL server database.</param>
        public SqlExecutor(string connectionString)
            : base(connectionString)
        { }

        #endregion

        #region Overrides

        /// <summary>
        /// Creates <see cref="SqlConnection"/> instance.
        /// </summary>
        protected override DbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Creates <see cref="SqlCommand"/> instance.
        /// </summary>
        protected override DbCommand GetCommand(CommandSettings settings, DbConnection connection)
        {
            SqlConnection sqlConnection = connection as SqlConnection;

            if (connection == null)
                throw new InvalidOperationException("Connection instance mismatch.");

            SqlCommand command = new SqlCommand(settings.CommandText, sqlConnection);
            command.CommandType = settings.CommandType;

            if (settings.HasParameters)
            {
                foreach (var parameter in settings.Parameters.OfType<SqlParameter>())
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        #endregion
    }
}
