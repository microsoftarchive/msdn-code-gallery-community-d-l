using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using MasaSam.Data.Common;

namespace MasaSam.Data.SqlClient
{
    /// <summary>
    /// <see cref="CommandSettings"/> for SQL server command.
    /// </summary>
    public sealed class SqlCommandSettings : CommandSettings
    {
        #region Ctor

        /// <summary>
        /// Initializes new instance.
        /// </summary>
        /// <param name="commandText">Command text.</param>
        /// <param name="commandType">Command type.</param>
        public SqlCommandSettings(string commandText, CommandType commandType)
            : base(commandText, commandType)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Add parameter for the command.
        /// </summary>
        /// <param name="parameter">Parameter to add.</param>
        public void AddParameter(SqlParameter parameter)
        {
            AddParameterInternal(parameter);
        }

        /// <summary>
        /// Add multiple parameters for the command.
        /// </summary>
        /// <param name="parameters">Parameters to add.</param>
        public void AddParameters(IEnumerable<SqlParameter> parameters)
        {
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    AddParameter(parameter);
                }
            }
        }

        #endregion
    }
}
