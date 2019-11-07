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

    using Microsoft.Practices.EnterpriseLibrary.Data;
    #endregion

    /// <summary>
    /// Provides a set of extension methods adding retry capabilities into the base implementation of a database provided by Enterprise Library.
    /// </summary>
    public static class EntLibDatabaseExtensions
    {
        /// <summary>
        /// Executes the specified command and returns the results in a new <see cref="System.Data.DataSet"/>.
        /// </summary>
        /// <param name="db">The database object which is required as per extension method declaration.</param>
        /// <param name="command">The <see cref="System.Data.Common.DbCommand"/> object that contains the query to execute.</param>
        /// <param name="retryPolicy">The retry policy defining whether to retry a command if it fails to complete due to a transient condition.</param>
        /// <returns>A <see cref="System.Data.DataSet"/> with the results of the command.</returns>        
        public static DataSet ExecuteDataSet(this Database db, DbCommand command, RetryPolicy retryPolicy)
        {
            return (retryPolicy != null ? retryPolicy : RetryPolicy.NoRetry).ExecuteAction<DataSet>(() =>
            {
                return db.ExecuteDataSet(command);
            });
        }

        /// <summary>
        /// Executes the specified command and returns the number of rows affected.
        /// </summary>
        /// <param name="db">The database object which is required as per extension method declaration.</param>
        /// <param name="command">The <see cref="System.Data.Common.DbCommand"/> object that contains the query to execute.</param>
        /// <param name="retryPolicy">The retry policy defining whether to retry a command if it fails to complete due to a transient condition.</param>
        /// <returns>The number of rows affected by the command.</returns>
        public static int ExecuteNonQuery(this Database db, DbCommand command, RetryPolicy retryPolicy)
        {
            return (retryPolicy != null ? retryPolicy : RetryPolicy.NoRetry).ExecuteAction<int>(() =>
            {
                return db.ExecuteNonQuery(command);
            });
        }

        /// <summary>
        /// Executes the specified command and returns an <see cref="System.Data.IDataReader"/> object through which the result can be read.
        /// It is the responsibility of the caller to close the reader when finished.
        /// </summary>
        /// <param name="db">The database object which is required as per extension method declaration.</param>
        /// <param name="command">The <see cref="System.Data.Common.DbCommand"/> object that contains the query to execute.</param>
        /// <param name="retryPolicy">The retry policy defining whether to retry a command if it fails to complete due to a transient condition.</param>
        /// <returns>An <see cref="System.Data.IDataReader"/> object enabling to fetch the results.</returns>
        public static IDataReader ExecuteReader(this Database db, DbCommand command, RetryPolicy retryPolicy)
        {
            return (retryPolicy != null ? retryPolicy : RetryPolicy.NoRetry).ExecuteAction<IDataReader>(() =>
            {
                return db.ExecuteReader(command);
            });
        }

        /// <summary>
        /// Executes the specified command and returns the first column of the first row in the result set returned by the query. 
        /// Extra columns or rows are ignored.
        /// </summary>
        /// <param name="db">The database object which is required as per extension method declaration.</param>
        /// <param name="command">The <see cref="System.Data.Common.DbCommand"/> object that contains the query to execute.</param>
        /// <param name="retryPolicy">The retry policy defining whether to retry a command if it fails to complete due to a transient condition.</param>
        /// <returns>The value of the first column of the top row in the result set.</returns>
        public static object ExecuteScalar(this Database db, DbCommand command, RetryPolicy retryPolicy)
        {
            return (retryPolicy != null ? retryPolicy : RetryPolicy.NoRetry).ExecuteAction<object>(() =>
            {
                return db.ExecuteScalar(command);
            });
        }
    }
}
