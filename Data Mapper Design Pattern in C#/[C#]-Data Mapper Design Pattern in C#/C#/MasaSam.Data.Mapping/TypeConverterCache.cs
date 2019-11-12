using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MasaSam.Data.Mapping
{
    /// <summary>
    /// Class to keep cache of type converter instance per type.
    /// </summary>
    public static class TypeConverterCache
    {
        #region Fields

        private static readonly Dictionary<string, TypeConverter> cache = new Dictionary<string, TypeConverter>();
        private static readonly object mutex = new object();

        #endregion

        #region Methods

        /// <summary>
        /// Gets <see cref="TypeConverter"/> for the provided type.
        /// </summary>
        /// <param name="type">A type to get converter.</param>
        /// <returns>A <see cref="TypeConverter"/> of the type or <c>null</c>, if type has no converter.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="type"/> is <c>null</c>.</exception>
        public static TypeConverter GetConverter(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            string key = type.FullName;

            TypeConverter converter;

            if (!cache.TryGetValue(key, out converter))
            {
                lock (mutex)
                {
                    if (!cache.TryGetValue(key, out converter))
                    {
                        TypeConverterAttribute attribute;

                        if (HasConverter(type, out attribute))
                        {
                            converter = GetConverter(attribute);

                            if (converter != null)
                            {
                                cache.Add(key, converter);
                            }
                        }
                    }
                }
            }

            return converter;
        }

        /// <summary>
        /// Checks if provided type has type converter.
        /// </summary>
        /// <param name="type">A type to check.</param>
        /// <returns><c>true</c> if type has type converter; <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="type"/> is <c>null</c>.</exception>
        public static bool HasConverter(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            lock (mutex)
            {
                if (cache.ContainsKey(type.FullName))
                {
                    return true;
                }

                TypeConverterAttribute attribute;

                bool result = HasConverter(type, out attribute);

                //// if has converter attribute, get converter
                //// and cache it
                if (result)
                {
                    TypeConverter converter = GetConverter(attribute);

                    if (converter != null)
                    {
                        cache.Add(type.FullName, converter);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Checks if <see cref="TypeConverterAttribute"/> is applied to provided type.
        /// </summary>
        /// <param name="type">A type to check.</param>
        /// <param name="attribute">A found first <see cref="TypeConverterAttribute"/> applied to type, if <c>true</c> is returned.</param>
        /// <returns><c>true</c> if <see cref="TypeConverterAttribute"/> is applied to type; <c>false</c> otherwise.</returns>
        private static bool HasConverter(Type type, out TypeConverterAttribute attribute)
        {
            var attributes = type.GetCustomAttributes(typeof(TypeConverterAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                attribute = (TypeConverterAttribute)attributes.First();

                return true;
            }

            attribute = null;

            return false;
        }

        /// <summary>
        /// Creates instance of <see cref="TypeConverter"/> from provided <see cref="TypeConverterAttribute"/> class.
        /// </summary>
        /// <param name="attribute">A <see cref="TypeConverterAttribute"/> to create <see cref="TypeConverter"/> from.</param>
        /// <returns>A <see cref="TypeConverter"/> instance created from <paramref name="attribute"/> or <c>null</c>, if can not create instance.</returns>
        private static TypeConverter GetConverter(TypeConverterAttribute attribute)
        {
            string typeName = attribute.ConverterTypeName;

            Type type = Type.GetType(typeName);

            if (type != null)
            {
                TypeConverter converter = Activator.CreateInstance(type) as TypeConverter;

                return converter;
            }

            return null;
        }

        #endregion
    }
}
