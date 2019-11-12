using System;
using System.Collections.Generic;
using System.Linq;

namespace MasaSam.Data.Mapping
{
    /// <summary>
    /// Class to determine type conversion.
    /// </summary>
    internal static class ConversionResolver
    {
        /// <summary>
        /// Resolves type conversion between source and destination type.
        /// </summary>
        /// <returns>A possible conversion to try from source to destination type.</returns>
        public static TypeConversion Resolve(object sourceValue, Type sourceType, Type destinationType)
        {
            //// if types match or destination is assignable from source, direct assign is possible
            if (sourceType.Equals(destinationType) || destinationType.IsAssignableFrom(sourceType))
            {
                return TypeConversion.Direct;
            }

            //// if destination type is enum and source type is enum underlying type or string,
            //// enum conversion is possible
            if (destinationType.IsEnum && (EnumUtility.IsEnumType(sourceType) || sourceType.Equals(typeof(string))))
            {
                return TypeConversion.Enum;
            }

            //// if destination type has TypeConverter, then use that
            if (TypeConverterCache.HasConverter(destinationType))
            {
                return TypeConversion.Converter;

            }

            //// if source is IConvertible, use System.Convert.ChangeType
            if (CanChangeType(sourceValue, destinationType))
            {
                return TypeConversion.Convertable;
            }

            //// check if detination type has parsing methods
            if (ReflectionUtility.SupportsParsing(destinationType))
            {
                //// try string parsing conversion
                return TypeConversion.String;
            }

            return TypeConversion.None;
        }

        /// <summary>
        /// Resolves type conversion between map item source and destination type.
        /// </summary>
        /// <returns>A possible conversion to try from source to destination type.</returns>
        public static TypeConversion Resolve(MapItem item, object sourceValue)
        {
            Type sourceType = item.Source.Type;
            Type destinationType = item.Destination.Type;

            return Resolve(sourceValue, sourceType, destinationType);
        }

        /// <summary>
        /// Checks if using <see cref="IConvertible"/> interface might be possible.
        /// </summary>
        /// <returns><c>true</c> if using <see cref="IConvertible"/> might be possible; <c>false</c> otherwise.</returns>
        private static bool CanChangeType(object value, Type conversionType)
        {
            if (conversionType == null)
            {
                return false;
            }

            if (value == null)
            {
                return false;
            }

            IConvertible convertible = value as IConvertible;

            if (convertible == null)
            {
                return false;
            }

            return true;
        }
    }
}
