using MasaSam.Data.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace MasaSam.Data
{
    /// <summary>
    /// Class that contains extension methods for the <see cref="DbDataReader"/> class.
    /// </summary>
    public static class DbDataReaderExtensions
    {
        #region Public Methods

        /// <summary>
        /// Gets single instance from single record in data reader. Expects that reader only has one record to read.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="reader">The source <see cref="DbDataReader"/> instance.</param>
        /// <param name="mappings">The mappings between properties and columns.</param>
        /// <returns>A single <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public static T GetSingleRecord<T>(this DbDataReader reader, IEnumerable<PropertyColumnMapping> mappings) where T : class, new()
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (mappings == null)
                throw new ArgumentNullException("mappings");

            return GetInstance<T>(reader, mappings, false);
        }

        /// <summary>
        /// Gets single instance from single record in data reader. Expects that reader only has one record to read.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="reader">The source <see cref="DbDataReader"/> instance.</param>
        /// <param name="ctorMappings">The mappings between constructor arguments and columns.</param>
        /// <param name="propMappings">The mappings between properties and columns.</param>
        /// <returns>A single <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public static T GetSingleRecord<T>(this DbDataReader reader, ColumnConstructorParameterMappingCollection<T> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings = null) where T : class
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (ctorMappings == null)
                throw new ArgumentNullException("ctorMappings");

            return GetInstance<T>(reader, ctorMappings, propMappings, false);
        }

        /// <summary>
        /// Gets first instance from data reader.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="reader">The source <see cref="DbDataReader"/> instance.</param>
        /// <param name="mappings">The mappings between properties and columns.</param>
        /// <returns>A first <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public static T GetFirstRecord<T>(this DbDataReader reader, IEnumerable<PropertyColumnMapping> mappings) where T : class, new()
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (mappings == null)
                throw new ArgumentNullException("mappings");

            return GetInstance<T>(reader, mappings, true);
        }

        /// <summary>
        /// Gets first instance from data reader.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="reader">The source <see cref="DbDataReader"/> instance.</param>
        /// <param name="ctorMappings">The mappings between constructor arguments and columns.</param>
        /// <param name="propMappings">The mappings between properties and columns.</param>
        /// <returns>A first <typeparamref name="T"/> instance or default <typeparamref name="T"/>.</returns>
        public static T GetFirstRecord<T>(this DbDataReader reader, ColumnConstructorParameterMappingCollection<T> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings = null) where T : class
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (ctorMappings == null)
                throw new ArgumentNullException("ctorMappings");

            return GetInstance<T>(reader, ctorMappings, propMappings, true);
        }

        /// <summary>
        /// Gets all instances from data reader.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="reader">The source <see cref="DbDataReader"/> instance.</param>
        /// <param name="mappings">The mappings between properties and columns.</param>
        /// <returns>A enumerable of <typeparamref name="T"/> instances.</returns>
        public static IEnumerable<T> GetRecords<T>(this DbDataReader reader, IEnumerable<PropertyColumnMapping> mappings) where T : class, new()
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (mappings == null)
                throw new ArgumentNullException("mappings");

            var result = new List<T>();

            if (reader.HasRows)
            {
                var lookupTable = GetColumnIndexLookupTable(reader, mappings.Select(x => x.ColumnName));

                while (reader.Read())
                {
                    var instance = new T();

                    ReadData(instance, reader, mappings, lookupTable);

                    result.Add(instance);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets all instances from data reader.
        /// </summary>
        /// <typeparam name="T">Type of an object read.</typeparam>
        /// <param name="reader">The source <see cref="DbDataReader"/> instance.</param>
        /// <param name="ctorMappings">The mappings between constructor arguments and columns.</param>
        /// <param name="propMappings">The mappings between properties and columns.</param>
        /// <returns>A enumerable of <typeparamref name="T"/> instances.</returns>
        public static IEnumerable<T> GetRecords<T>(this DbDataReader reader, ColumnConstructorParameterMappingCollection<T> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings) where T : class
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (ctorMappings == null)
                throw new ArgumentNullException("ctorMappings");

            var result = new List<T>();

            if (reader.HasRows)
            {
                var activator = ActivatorFactory.GetActivator<T>(ctorMappings.Constructor);

                Dictionary<string, int> propertyColumnLookupTable = null;

                //// if contains property mappings, get lookup table
                if (propMappings != null)
                {
                    propertyColumnLookupTable = GetColumnIndexLookupTable(reader, propMappings.Select(x => x.ColumnName));
                }

                /// mappings between ctor params and columns
                var ctorColumnLookupTable = GetColumnIndexLookupTable(reader, ctorMappings.Select(x => x.ColumnName));

                while (reader.Read())
                {
                    object[] arguments = null;

                    //// get constructor arguments
                    if (ctorMappings.HasParameters)
                    {
                        arguments = GetConstructorParameters(reader, ctorColumnLookupTable, ctorMappings);
                    }

                    var instance = activator.Invoke(arguments);

                    //// if contains property mappings, read values
                    if (propMappings != null)
                    {
                        ReadData(instance, reader, propMappings, propertyColumnLookupTable);
                    }

                    result.Add(instance);
                }
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets one instance of <typeparamref name="T"/> from data reader.
        /// </summary>
        /// <typeparam name="T">Type of an instance.</typeparam>
        /// <param name="reader">Source data reader.</param>
        /// <param name="mappings">Property column mappings.</param>
        /// <param name="breakAfterFirst">true to break after the first read record; false to not. if false throws exception if more than one record.</param>
        /// <returns>A single instance read from reader or null.</returns>
        private static T GetInstance<T>(DbDataReader reader, IEnumerable<PropertyColumnMapping> mappings, bool breakAfterFirst) where T : class, new()
        {
            T instance = null;

            if (reader.HasRows)
            {
                instance = new T();

                var lookupTable = GetColumnIndexLookupTable(reader, mappings.Select(x => x.ColumnName));

                bool first = true;

                while (reader.Read())
                {
                    if (!first)
                        throw new InvalidOperationException("Reader contains more than expected 1 record.");

                    ReadData(instance, reader, mappings, lookupTable);

                    if (breakAfterFirst)
                    {
                        break;
                    }

                    first = false;
                }
            }

            return instance;
        }

        /// <summary>
        /// Gets one instance of <typeparamref name="T"/> from data reader.
        /// </summary>
        /// <typeparam name="T">Type of an instance.</typeparam>
        /// <param name="reader">Source data reader.</param>
        /// <param name="ctorParamMappings">Column constructor parameter mappings.</param>
        /// <param name="propMappings">Property column mappings.</param>
        /// <param name="breakAfterFirst">true to break after the first read record; false to not. if false throws exception if more than one record.</param>
        /// <returns>A single instance read from reader or null.</returns>
        private static T GetInstance<T>(DbDataReader reader, ColumnConstructorParameterMappingCollection<T> ctorParamMappings, IEnumerable<PropertyColumnMapping> propMappings, bool breakAfterFirst) where T : class
        {
            T instance = null;

            if (reader.HasRows)
            {
                //// create activator to create instance with constructor
                var activator = ActivatorFactory.GetActivator<T>(ctorParamMappings.Constructor);

                Dictionary<string, int> propertyColumnLookupTable = null;

                //// if contains property mappings, get lookup table
                if (propMappings != null)
                {
                    propertyColumnLookupTable = GetColumnIndexLookupTable(reader, propMappings.Select(x => x.ColumnName));
                }

                /// mappings between ctor params and columns
                var ctorColumnLookupTable = GetColumnIndexLookupTable(reader, ctorParamMappings.Select(x => x.ColumnName));

                bool first = true;

                while (reader.Read())
                {
                    if (!first)
                        throw new InvalidOperationException("Reader contains more than expected 1 record.");

                    object[] arguments = null;

                    //// get constructor arguments
                    if (ctorParamMappings.HasParameters)
                    {
                        arguments = GetConstructorParameters(reader, ctorColumnLookupTable, ctorParamMappings);
                    }

                    //// create instance
                    instance = activator.Invoke(arguments);

                    //// if contains property mappings, read values
                    if (propMappings != null)
                    {
                        ReadData(instance, reader, propMappings, propertyColumnLookupTable);
                    }

                    if (breakAfterFirst)
                    {
                        break;
                    }

                    first = false;
                }
            }

            return instance;
        }

        /// <summary>
        /// Gets the object array of constructor arguments.
        /// </summary>
        /// <typeparam name="T">Type of an instance.</typeparam>
        /// <param name="reader">Source data reader.</param>
        /// <param name="lookupTable">Column name column ordinal lookup table.</param>
        /// <param name="ctorMappings">Column constructor parameter mappings.</param>
        /// <returns>Object array of constructor parameters.</returns>
        private static object[] GetConstructorParameters<T>(DbDataReader reader, Dictionary<string, int> lookupTable, ColumnConstructorParameterMappingCollection<T> ctorMappings) where T : class
        {
            object[] args = new object[ctorMappings.Count];

            foreach (var mapping in ctorMappings)
            {
                int ordinal = lookupTable[mapping.ColumnName];

                //// read value
                object value = GetValue(reader, mapping.CanBeNull, ordinal, mapping.ColumnName);

                //// if mappings does not accept nulls, but null was read
                //// throw exception
                if (!mapping.CanBeNull && value == null)
                    throw new NullReferenceException(String.Format("Constructor parameter does not accept null references, but null was read from column {0}.", mapping.ColumnName));

                //// if value is not null, perform value check
                if (value != null)
                {
                    value = CheckValue(value, mapping.ConstructorParameterType);
                }

                //// store to arguments array
                args[mapping.ConstructorParameterIndex] = value;
            }

            return args;
        }

        /// <summary>
        /// Creates the column name -> column ordinal lookup table.
        /// </summary>
        /// <param name="reader">Source data readers.</param>
        /// <param name="columnNames">Column names.</param>
        /// <returns>A lookup table between column names and column ordinals.</returns>
        private static Dictionary<string, int> GetColumnIndexLookupTable(DbDataReader reader, IEnumerable<string> columnNames)
        {
            var lookupTable = new Dictionary<string, int>();

            foreach (string columnName in columnNames)
            {
                try
                {
                    int ordinal = reader.GetOrdinal(columnName);
                    lookupTable.Add(columnName, ordinal);
                }
                catch (IndexOutOfRangeException exception)
                {
                    throw new IndexOutOfRangeException(String.Format("Result set does not contain column {0}.", columnName), exception);
                }
            }

            return lookupTable;
        }

        /// <summary>
        /// Reads value from the reader.
        /// </summary>
        /// <param name="reader">Source data reader.</param>
        /// <param name="canBeNull">true if null is acceptable.</param>
        /// <param name="ordinal">Column ordinal.</param>
        /// <param name="columnName">Column name.</param>
        /// <returns>A read value.</returns>
        private static object GetValue(DbDataReader reader, bool canBeNull, int ordinal, string columnName)
        {
            object value = null;

            if (canBeNull)
            {
                if (!reader.IsDBNull(ordinal))
                {
                    value = reader.GetValue(ordinal);
                }
            }
            else
            {
                if (reader.IsDBNull(ordinal))
                {
                    throw new NullReferenceException(String.Format("Column {0} contains NULL data, but the value can not be null reference.", columnName));
                }

                value = reader.GetValue(ordinal);
            }

            return value;
        }

        /// <summary>
        /// Check the input value and converts it to instance of conversion type.
        /// </summary>
        /// <param name="value">Source value.</param>
        /// <param name="conversionType">Converted value type.</param>
        /// <returns>A converted value or null.</returns>
        private static object CheckValue(object value, Type conversionType)
        {
            object obj = value;

            Type columnType = obj.GetType();

            if (!conversionType.IsEnum)
            {
                if (columnType != conversionType)
                {
                    if (CanChangeType(obj, conversionType))
                    {
                        try
                        {
                            obj = Convert.ChangeType(obj, conversionType);
                        }
                        catch (FormatException exception)
                        {
                            throw new InvalidCastException(String.Format("Value format is invalid for type of {0}.", conversionType.FullName), exception);
                        }
                        catch (OverflowException exception)
                        {
                            throw new InvalidCastException(String.Format("Value overflows the size of type of {0}.", conversionType.FullName), exception);
                        }
                    }
                    else
                    {
                        throw new InvalidCastException(String.Format("Can not convert from {0} to {1}.", columnType.FullName, conversionType.FullName));
                    }
                }
            }
            else
            {
                //// enum conversion
                try
                {
                    object enumValue = Enum.ToObject(conversionType, obj);

                    return enumValue;
                }
                catch (Exception exception)
                {
                    throw new InvalidCastException(String.Format("Can not convert from {0} to {1}.", columnType.FullName, conversionType.FullName), exception);
                }
            }

            return obj;
        }

        /// <summary>
        /// Check if <see cref="IConvertible"/> can be used in type conversion.
        /// </summary>
        /// <param name="value">Source value.</param>
        /// <param name="conversionType">Type to convert to.</param>
        /// <returns>true if conversion with <see cref="IConvertible"/> is possible; false otherwise.</returns>
        private static bool CanChangeType(object value, Type conversionType)
        {
            if (conversionType == null || value == null)
            {
                return false;
            }

            IConvertible convertible = value as IConvertible;

            if (convertible != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Reads data to instance.
        /// </summary>
        /// <typeparam name="T">Type of an instance.</typeparam>
        /// <param name="instance">Instance to read data to.</param>
        /// <param name="reader">Reader to read.</param>
        /// <param name="mappings">Mappings between columns and properties.</param>
        /// <param name="lookupTable">Column ordinal lookup table.</param>
        private static void ReadData<T>(T instance, DbDataReader reader, IEnumerable<PropertyColumnMapping> mappings, Dictionary<string, int> lookupTable)
        {
            foreach (var mapping in mappings)
            {
                int ordinal = lookupTable[mapping.ColumnName];

                object value = GetValue(reader, mapping.CanBeNull, ordinal, mapping.ColumnName);

                if (value != null)
                {
                    value = CheckValue(value, mapping.PropertyType);

                    SetPropertyValue(instance, mapping.PropertyName, value);
                }
            }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <typeparam name="T">Type of an instance.</typeparam>
        /// <param name="instance">Instance to set value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">Value to set.</param>
        private static void SetPropertyValue<T>(T instance, string propertyName, object value)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);

            if (property != null)
            {
                MethodInfo setMethod = property.GetSetMethod();

                if (setMethod != null)
                {
                    setMethod.Invoke(instance, new object[] { value });
                }
            }
        }

        #endregion
    }
}
