//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.Configuration
{
    #region Using references
    using System;
    using System.ComponentModel;
    using System.Globalization;
    #endregion

    /// <summary>
    /// Represents a configuration converter that converts a Version type to and from its string representation.
    /// </summary>
    public class VersionTypeConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="sourceType">A <see cref="Type"/> that represents the type you want to convert from. </param>
        /// <returns><see langword="true"/> if this converter can perform the conversion; otherwise, <see langword="falase"/>. </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return typeof(string) == sourceType;
        }

        /// <summary>
        /// Converts the given value to the type of this converter.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="culture">A <see cref="CultureInfo"/> object.</param>
        /// <param name="value">An <see cref="Object"/> that represents the converted value. </param>
        /// <returns>An <see cref="Object"/> that represents the converted value. </returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return !String.IsNullOrEmpty((string)value) ? Version.Parse((string)value) : null;
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="destinationType">A <see cref="Type"/> that represents the type you want to convert to..</param>
        /// <returns><b>true</b> if the converter can convert to the specified type, <b>false</b> otherwise.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return typeof(Version) == destinationType;
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the arguments. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="culture">A <see cref="CultureInfo"/> object.</param>
        /// <param name="value">The <see cref="Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="Type"/> to convert the value parameter to.</param>
        /// <returns>The converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return value != null ? value.ToString() : null;
        }
    }
}
