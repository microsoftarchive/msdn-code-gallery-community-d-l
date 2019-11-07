using System;

namespace MasaSam.Data
{
    /// <summary>
    /// Class that maps object property to database column.
    /// </summary>
    public sealed class PropertyColumnMapping
    {
        #region Ctor

        public PropertyColumnMapping(string propertyName, Type propertyType)
            : this(propertyName, propertyName, propertyType)
        { }

        public PropertyColumnMapping(string propertyName, string columnName, Type propertyType)
            : this(propertyName, columnName, propertyType, false)
        { }

        public PropertyColumnMapping(string propertyName, string columnName, Type propertyType, bool canBeNull)
        {
            this.ColumnName = columnName;
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.CanBeNull = canBeNull;
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Gets the property type.
        /// </summary>
        public Type PropertyType { get; private set; }

        /// <summary>
        /// Gets whether or not property value can be null.
        /// </summary>
        public bool CanBeNull { get; private set; }

        #endregion
    }
}
