using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace MasaSam.Data.Mapping
{
    #region ValueConverter

    /// <summary>
    /// Class that performs value conversion between source and destination type.
    /// </summary>
    internal static class ValueConverter
    {
        /// <summary>
        /// Convert provided source object to destination object based
        /// of an provided <see cref="MapItem"/>.
        /// </summary>
        /// <param name="mapItem">A <see cref="MapItem"/> that defines the mapping.</param>
        /// <param name="source">A source member value.</param>
        /// <returns>A destination member value or <c>null</c>.</returns>
        public static object Convert(MapItem mapItem, object source)
        {
            if (mapItem == null)
                throw new ArgumentNullException("mapItem");

            Type sourceType = mapItem.Source.Type;
            Type destinationType = mapItem.Destination.Type;

            return Convert(source, sourceType, destinationType);

            //try
            //{
            //    mapItem.SetConversion(source);

            //    object destination = null;

            //    Type sourceType = mapItem.Source.Type;
            //    Type destinationType = mapItem.Destination.Type;

            //    if (source != null)
            //    {
            //        switch (mapItem.Conversion)
            //        {
            //            case ItemConversion.Direct:
            //                destination = source;
            //                break;
            //            case ItemConversion.Enum:
            //                destination = FromEnum(sourceType, destinationType, source);
            //                break;
            //            case ItemConversion.Convertable:
            //                destination = FromConvertable(sourceType, destinationType, source);
            //                break;
            //            case ItemConversion.Converter:
            //                destination = FromConverter(sourceType, destinationType, source);
            //                break;
            //            case ItemConversion.String:
            //                destination = FromString(sourceType, destinationType, source);
            //                break;
            //        }
            //    }

            //    return destination;
            //}
            //catch (Exception exception)
            //{
            //    throw new ValueConverterException(exception.Message, exception);
            //}
        }

        /// <summary>
        /// Convert provided source object to destination object.
        /// </summary>
        /// <param name="source">The source object instance.</param>
        /// <param name="sourceType">The source object type.</param>
        /// <param name="destinationType">The destination object type.</param>
        /// <returns>A destination object type value.</returns>
        public static object Convert(object source, Type sourceType, Type destinationType)
        {
            object destination = null;

            try
            {
                if (source != null)
                {
                    TypeConversion conversion = ConversionResolver.Resolve(source, sourceType, destinationType);

                    switch (conversion)
                    {
                        case TypeConversion.Direct:
                            destination = source;
                            break;
                        case TypeConversion.Enum:
                            destination = FromEnum(sourceType, destinationType, source);
                            break;
                        case TypeConversion.Convertable:
                            destination = FromConvertable(sourceType, destinationType, source);
                            break;
                        case TypeConversion.Converter:
                            destination = FromConverter(sourceType, destinationType, source);
                            break;
                        case TypeConversion.String:
                            destination = FromString(sourceType, destinationType, source);
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new ValueConverterException(exception.Message, exception);
            }

            return destination;
        }

        /// <summary>
        /// Convert source type value to destination value using <see cref="Enum.Parse"/>
        /// or <see cref="Enum.ToObject"/> depending on the <paramref name="sourceType"/>.
        /// </summary>
        /// <param name="sourceType">A type of an source member.</param>
        /// <param name="destinationType">A type of an destination member.</param>
        /// <param name="source">A source instance.</param>
        /// <returns>A enum value converted with <see cref="Enum.Parse"/> or <see cref="Enum.ToObject"/>.</returns>
        private static object FromEnum(Type sourceType, Type destinationType, object source)
        {
            if (sourceType.Equals(typeof(string)))
            {
                return Enum.Parse(destinationType, source.ToString(), true);
            }

            return Enum.ToObject(destinationType, source);
        }

        /// <summary>
        /// Convert source type value to destination type value using <see cref="IConvertable"/> interface.
        /// </summary>
        /// <param name="sourceType">A type of an source member.</param>
        /// <param name="destinationType">A type of an destination member.</param>
        /// <param name="source">A source instance.</param>
        /// <returns>A value converted with <see cref="IConvertable"/>.</returns>
        private static object FromConvertable(Type sourceType, Type destinationType, object source)
        {
            object destination = null;

            destination = System.Convert.ChangeType(source, destinationType);

            return destination;
        }

        /// <summary>
        /// Convert source type value to destination type value using parsing methods if destination
        /// type has one.
        /// </summary>
        /// <param name="sourceType">A type of an source member.</param>
        /// <param name="destinationType">A type of an destination member.</param>
        /// <param name="source">A source instance.</param>
        /// <returns>A value converted from parse method or <c>null</c>.</returns>
        private static object FromString(Type sourceType, Type destinationType, object source)
        {
            object destination = null;

            string str = source.ToString();

            MethodInfo parsingMethod = ReflectionUtility.GetTryParseMethod(destinationType);

            if (parsingMethod != null)
            {
                destination = parsingMethod.Invoke(null, new object[] { str });
            }
            else if ((parsingMethod = ReflectionUtility.GetParseMethod(destinationType)) != null)
            {
                object[] parameters = new object[] { str, null };

                bool result = (bool)parsingMethod.Invoke(null, parameters);

                if (result)
                {
                    destination = parameters[1];
                }
            }

            return destination;
        }

        /// <summary>
        /// Convert source type value to destination type value using <see cref="TypeConverter"/>
        /// applied to destination type.
        /// </summary>
        /// <param name="sourceType">A type of an source member.</param>
        /// <param name="destinationType">A type of an destination member.</param>
        /// <param name="source">A source instance.</param>
        /// <returns>A value converted with type converter or <c>null</c>.</returns>
        private static object FromConverter(Type sourceType, Type destinationType, object source)
        {
            TypeConverter converter = TypeConverterCache.GetConverter(destinationType);

            object destination = null;

            if (converter != null)
            {
                if (converter.CanConvertFrom(sourceType))
                {
                    destination = converter.ConvertFrom(source);
                }
                else if (converter.CanConvertFrom(typeof(string)))
                {
                    string str = source.ToString();

                    destination = converter.ConvertFromString(str);
                }
            }

            return destination;
        }
    }

    #endregion

    #region ValueConverterException

    internal class ValueConverterException : Exception
    {
        #region Ctor

        public ValueConverterException()
            : this("Value conversion error.")
        { }

        public ValueConverterException(string message)
            : this(message, null)
        { }

        public ValueConverterException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected ValueConverterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }

    #endregion
}
