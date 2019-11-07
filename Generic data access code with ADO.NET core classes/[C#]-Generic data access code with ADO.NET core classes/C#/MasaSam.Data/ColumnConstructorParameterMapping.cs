using System;
using System.Reflection;

namespace MasaSam.Data
{
    /// <summary>
    /// Class that maps database column to constructor argument.
    /// </summary>
    public sealed class ColumnConstructorParameterMapping
    {
        #region Ctor

        internal ColumnConstructorParameterMapping(string columnName, ParameterInfo parameter, ConstructorInfo ctor, bool canBeNull = false)
        {
            this.ColumnName = columnName;
            this.ParameterInfo = parameter;
            this.Constructor = ctor;
            this.CanBeNull = canBeNull;
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Gets the index of the parameter in ctor parameters.
        /// </summary>
        public int ConstructorParameterIndex
        {
            get { return ParameterInfo.Position; }
        }

        /// <summary>
        /// Gets the type of the parameter.
        /// </summary>
        public Type ConstructorParameterType
        {
            get { return ParameterInfo.ParameterType; }
        }

        /// <summary>
        /// Gets whether or not null can be passed.
        /// </summary>
        public bool CanBeNull { get; private set; }

        /// <summary>
        /// Gets the parameter info.
        /// </summary>
        public ParameterInfo ParameterInfo { get; private set; }

        /// <summary>
        /// Gets the constructor info.
        /// </summary>
        internal ConstructorInfo Constructor { get; private set; }

        #endregion
    }
}
