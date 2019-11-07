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
    /// Provides a set of factory methods responsible for instantiating and pre-initializing the <see cref="System.Data.SqlClient.SqlParameter"/> instances.
    /// </summary>
    public static class SqlParameterUtility
    {
        #region Private members
        private const char SqlParameterPrefix = '@';
        private const int DefaultVarCharSize = 255;
        #endregion

        /// <summary>
        /// Creates a new input SQL parameter using the specified parameter name and its data type.
        /// </summary>
        /// <param name="parameterName">The name of the SQL parameter.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <returns>A new SQL parameter initialized with the specified name and data type.</returns>
        public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType)
        {
            Guard.ArgumentNotNullOrEmptyString(parameterName, "parameterName");

            return new SqlParameter(String.Concat(SqlParameterPrefix, parameterName), dbType);
        }

        /// <summary>
        /// Creates a new input SQL parameter using the specified parameter name, its data type and initial value.
        /// </summary>
        /// <param name="parameterName">The name of the SQL parameter.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="value">The initial value that is assigned to the parameter upon initialization.</param>
        /// <returns>A new SQL parameter initialized with the specified name, data type and initial value.</returns>
        public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, object value)
        {
            Guard.ArgumentNotNullOrEmptyString(parameterName, "parameterName");

            SqlParameter sqlParam = new SqlParameter(String.Concat(SqlParameterPrefix, parameterName), dbType) { Value = value };

            switch(dbType)
            {
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                    sqlParam.Size = DefaultVarCharSize;
                    break;
            }

            return sqlParam;
        }

        /// <summary>
        /// Creates a new output SQL parameter using the specified parameter name and its data type.
        /// </summary>
        /// <param name="parameterName">The name of the SQL parameter.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <returns>A new SQL parameter initialized with the specified name and data type.</returns>
        public static SqlParameter CreateOutputParameter(string parameterName, SqlDbType dbType)
        {
            Guard.ArgumentNotNullOrEmptyString(parameterName, "parameterName");

            return new SqlParameter(String.Concat(parameterName), dbType) { Direction = ParameterDirection.Output };
        }

        /// <summary>
        /// Creates a new output SQL parameter using the specified parameter name, its data type and data size.
        /// </summary>
        /// <param name="parameterName">The name of the SQL parameter.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <returns>A new SQL parameter initialized with the specified name, data type and data size.</returns>
        public static SqlParameter CreateOutputParameter(string parameterName, SqlDbType dbType, int size)
        {
            SqlParameter sqlParam = CreateOutputParameter(parameterName, dbType);
            sqlParam.Size = size;

            return sqlParam;
        }

        /// <summary>
        /// Returns the value of the parameter in the specified SQL command.
        /// </summary>
        /// <typeparam name="T">The target type into which the parameter's value will be converted.</typeparam>
        /// <param name="command">The SQL command providing the collection of parameters.</param>
        /// <param name="parameterName">The name of the SQL parameter.</param>
        /// <returns>The value of the specified parameter, or the default value of type <typeparamref name="T"/> if no such parameter was found.</returns>
        public static T GetParameterValueAs<T>(IDbCommand command, string parameterName)
        {
            Guard.ArgumentNotNull(command, "command");
            Guard.ArgumentNotNullOrEmptyString(parameterName, "parameterName");

            IDataParameter param = command.Parameters[parameterName] as IDataParameter;

            if (param != null && param.Value != null && param.Value != DBNull.Value)
            {
                return (T)Convert.ChangeType(param.Value, typeof(T));
            }
            else
            {
                return default(T);
            }
        }
    }
}
