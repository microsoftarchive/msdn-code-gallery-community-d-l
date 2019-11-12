//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Data
{
    #region Using references
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides factory methods for instantiating SQL commands.
    /// </summary>
    public static class SqlCommandFactory
    {
        #region Public members
        /// <summary>
        /// Returns the default timeout which will be applied to all SQL commands constructed by this factory class.
        /// </summary>
        public const int DefaultCommandTimeoutSeconds = 60;
        #endregion

        #region Generic SQL commands
        /// <summary>
        /// Creates a generic command of type Stored Procedure and assigns the default command timeout.
        /// </summary>
        /// <param name="connection">The database connection object to be associated with the new command.</param>
        /// <returns>A new SQL command initialized with the respective command type and initial settings.</returns>
        public static IDbCommand CreateCommand(IDbConnection connection)
        {
            Guard.ArgumentNotNull(connection, "connection");

            IDbCommand command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = DefaultCommandTimeoutSeconds;

            return command;
        }

        /// <summary>
        /// Creates a generic command of type Stored Procedure and assigns the specified command text and default command timeout.
        /// </summary>
        /// <param name="connection">The database connection object to be associated with the new command.</param>
        /// <param name="commandText">The text of the command to run against the data source.</param>
        /// <returns>A new SQL command initialized with the respective command type and initial settings.</returns>
        public static IDbCommand CreateCommand(IDbConnection connection, string commandText)
        {
            Guard.ArgumentNotNullOrEmptyString(commandText, "commandText");

            IDbCommand command = CreateCommand(connection);
            command.CommandText = commandText;

            return command;
        }
        #endregion

        #region SqlStream commands
        /// <summary>
        /// Creates a SQL command responsible for retrieving the data from a varchar(max) field.
        /// </summary>
        /// <param name="connection">The database connection object to be associated with the new command.</param>
        /// <param name="schemaName">The name of the database schema holding the source table.</param>
        /// <param name="tableName">The name of the database table holding the varchar(max) field containing the data.</param>
        /// <param name="dataColumn">The name of the database column holding the data.</param>
        /// <param name="keyColumn">The name of the database field which represents a lookup key for the source row containing the data.</param>
        /// <param name="keyType">The type of the lookup key.</param>
        /// <param name="keyValue">The value of the lookup key.</param>
        /// <returns>A new SQL command initialized with the respective settings and parameters.</returns>
        public static IDbCommand CreateSqlStreamReadCommand(IDbConnection connection, string schemaName, string tableName, string dataColumn, string keyColumn, SqlDbType keyType, object keyValue)
        {
            Guard.ArgumentNotNull(connection, "connection");
            Guard.ArgumentNotNullOrEmptyString(schemaName, "schemaName");
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            Guard.ArgumentNotNullOrEmptyString(dataColumn, "dataColumn");
            Guard.ArgumentNotNullOrEmptyString(keyColumn, "keyColumn");
            Guard.ArgumentNotNull(keyValue, "keyValue");

            IDbCommand readCommand = CreateCommand(connection);

            readCommand.CommandText = String.Format(SqlCommandResources.SqlStreamReadCommand, dataColumn, schemaName, tableName, keyColumn);
            readCommand.CommandType = CommandType.Text;

            readCommand.Parameters.Add(SqlParameterUtility.CreateParameter("key", keyType, keyValue));
            readCommand.Parameters.Add(SqlParameterUtility.CreateParameter("offset", SqlDbType.BigInt));
            readCommand.Parameters.Add(SqlParameterUtility.CreateParameter("length", SqlDbType.BigInt));

            return readCommand;
        }

        /// <summary>
        /// Creates a SQL command responsible for updating the data held in a varchar(max) field.
        /// </summary>
        /// <param name="connection">The database connection object to be associated with the new command.</param>
        /// <param name="schemaName">The name of the database schema holding the source table.</param>
        /// <param name="tableName">The name of the database table holding the varchar(max) field containing the data.</param>
        /// <param name="dataColumn">The name of the database column holding the data.</param>
        /// <param name="keyColumn">The name of the database field which represents a lookup key for the source row containing the data.</param>
        /// <param name="keyType">The type of the lookup key.</param>
        /// <param name="keyValue">The value of the lookup key.</param>
        /// <returns>A new SQL command initialized with the respective settings and parameters.</returns>
        public static IDbCommand CreateSqlStreamWriteCommand(IDbConnection connection, string schemaName, string tableName, string dataColumn, string keyColumn, SqlDbType keyType, object keyValue)
        {
            Guard.ArgumentNotNull(connection, "connection");
            Guard.ArgumentNotNullOrEmptyString(schemaName, "schemaName");
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            Guard.ArgumentNotNullOrEmptyString(dataColumn, "dataColumn");
            Guard.ArgumentNotNullOrEmptyString(keyColumn, "keyColumn");
            Guard.ArgumentNotNull(keyValue, "keyValue");

            IDbCommand writeCommand = CreateCommand(connection);

            writeCommand.CommandText = String.Format(SqlCommandResources.SqlStreamWriteCommand, schemaName, tableName, dataColumn, keyColumn);
            writeCommand.CommandType = CommandType.Text;

            writeCommand.Parameters.Add(SqlParameterUtility.CreateParameter("key", keyType, keyValue));
            writeCommand.Parameters.Add(SqlParameterUtility.CreateParameter("offset", SqlDbType.BigInt));
            writeCommand.Parameters.Add(SqlParameterUtility.CreateParameter("length", SqlDbType.BigInt));
            writeCommand.Parameters.Add(SqlParameterUtility.CreateParameter("buffer", SqlDbType.VarBinary));

            return writeCommand;
        }

        /// <summary>
        /// Creates a SQL command responsible for returning the size of the data held in a varchar(max) field.
        /// </summary>
        /// <param name="connection">The database connection object to be associated with the new command.</param>
        /// <param name="schemaName">The name of the database schema holding the source table.</param>
        /// <param name="tableName">The name of the database table holding the varchar(max) field containing the data.</param>
        /// <param name="dataColumn">The name of the database column holding the data.</param>
        /// <param name="keyColumn">The name of the database field which represents a lookup key for the source row containing the data.</param>
        /// <param name="keyType">The type of the lookup key.</param>
        /// <param name="keyValue">The value of the lookup key.</param>
        /// <returns>A new SQL command initialized with the respective settings and parameters.</returns>
        public static IDbCommand CreateSqlStreamGetSizeCommand(IDbConnection connection, string schemaName, string tableName, string dataColumn, string keyColumn, SqlDbType keyType, object keyValue)
        {
            Guard.ArgumentNotNull(connection, "connection");
            Guard.ArgumentNotNullOrEmptyString(schemaName, "schemaName");
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            Guard.ArgumentNotNullOrEmptyString(dataColumn, "dataColumn");
            Guard.ArgumentNotNullOrEmptyString(keyColumn, "keyColumn");
            Guard.ArgumentNotNull(keyValue, "keyValue");

            IDbCommand getLengthCommand = CreateCommand(connection);

            getLengthCommand.CommandText = String.Format(SqlCommandResources.SqlStreamGetLengthCommand, dataColumn, schemaName, tableName, keyColumn);
            getLengthCommand.CommandType = CommandType.Text;

            getLengthCommand.Parameters.Add(SqlParameterUtility.CreateOutputParameter("length", SqlDbType.BigInt));
            getLengthCommand.Parameters.Add(SqlParameterUtility.CreateParameter("key", keyType, keyValue));

            return getLengthCommand;
        }
        #endregion

        #region Other system commands
        /// <summary>
        /// Creates a SQL command that is intended to return the connection's context ID which is useful for tracing purposes.
        /// </summary>
        /// <param name="connection">The database connection object to be associated with the new command.</param>
        /// <returns>A new SQL command initialized with the respective command type, text and initial settings.</returns>
        public static IDbCommand CreateGetContextInfoCommand(IDbConnection connection)
        {
            Guard.ArgumentNotNull(connection, "connection");

            IDbCommand command = CreateCommand(connection);

            command.CommandType = CommandType.Text;
            command.CommandText = SqlCommandResources.QueryGetContextInfo;

            return command;
        } 
        #endregion
    }
}
