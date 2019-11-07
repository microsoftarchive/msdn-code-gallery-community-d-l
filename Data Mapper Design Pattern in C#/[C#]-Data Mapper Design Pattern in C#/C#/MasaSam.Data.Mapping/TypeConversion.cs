using System;

namespace MasaSam.Data.Mapping
{
    /// <summary>
    /// Supported conversions between types.
    /// </summary>
    public enum TypeConversion : int
    {
        /// <summary>
        /// Conversion not determined.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Direct assignment.
        /// </summary>
        Direct = 1,

        /// <summary>
        /// Enum conversion.
        /// </summary>
        Enum = 2,

        /// <summary>
        /// Conversion using <see cref="IConvertable"/> interface.
        /// </summary>
        Convertable = 3,

        /// <summary>
        /// Conversion using <see cref="System.ComponentModel.TypeConverter"/>
        /// </summary>
        Converter = 4,

        /// <summary>
        /// String conversion aka parsing.
        /// </summary>
        String = 5,

        /// <summary>
        /// No conversion between types.
        /// </summary>
        None = 6
    }
}
