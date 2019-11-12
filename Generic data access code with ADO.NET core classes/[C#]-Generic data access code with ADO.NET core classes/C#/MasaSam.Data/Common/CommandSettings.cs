using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace MasaSam.Data.Common
{
    /// <summary>
    /// Class that defines property values for the <see cref="DbCommand"/> class.
    /// </summary>
    public abstract class CommandSettings
    {
        #region Fields

        private readonly Dictionary<string, DbParameter> parameters;
        private readonly string commandText;
        private readonly CommandType commandType;

        #endregion

        #region Ctor

        protected CommandSettings(string commandText, CommandType commandType)
        {
            this.commandText = commandText;
            this.commandType = commandType;
            this.parameters = new Dictionary<string, DbParameter>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command text.
        /// </summary>
        public string CommandText
        {
            get { return commandText; }
        }

        /// <summary>
        /// Gets the command type.
        /// </summary>
        public CommandType CommandType
        {
            get { return commandType; }
        }

        /// <summary>
        /// Gets whether or not contains parameters.
        /// </summary>
        public bool HasParameters
        {
            get { return parameters.Count > 0; }
        }

        /// <summary>
        /// Gets parameters.
        /// </summary>
        public IEnumerable<DbParameter> Parameters
        {
            get { return parameters.Values; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Removes the parameter.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to remove.</param>
        /// <returns><c>true</c> if removed; <c>false</c> otherwise.</returns>
        public bool RemoveParameter(string parameterName)
        {
            return parameters.Remove(parameterName);
        }

        /// <summary>
        /// Checks if contains parameter.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to check.</param>
        /// <returns><c>true</c> if contains parameter with provided name; <c>false</c> otherwise.</returns>
        public bool ContainsParameter(string parameterName)
        {
            return parameters.ContainsKey(parameterName);
        }

        protected void AddParameterInternal(DbParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            if (ContainsParameter(parameter.ParameterName))
                throw new ArgumentException("Contains parameter with same name.", "parameter");

            parameters.Add(parameter.ParameterName, parameter);
        }

        #endregion
    }
}
