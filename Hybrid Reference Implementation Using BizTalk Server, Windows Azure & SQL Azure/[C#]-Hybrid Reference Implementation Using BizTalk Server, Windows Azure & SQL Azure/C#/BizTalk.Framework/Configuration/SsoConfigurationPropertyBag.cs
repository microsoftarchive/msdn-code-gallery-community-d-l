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
    #region Using statements
    using System;
    using System.Collections.Specialized;

    using Microsoft.BizTalk.SSOClient.Interop;
    #endregion

    /// <summary>
    /// Provides a native storage slot in which the object can persistently save its properties. 
    /// </summary>
    internal class SsoConfigurationPropertyBag : IPropertyBag
    {
        /// <summary>
        /// The properties to be stored.
        /// </summary>
        private readonly HybridDictionary properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="SsoConfigurationPropertyBag"/> class.
        /// </summary>
        internal SsoConfigurationPropertyBag()
        {
            this.properties = new HybridDictionary();
        }

        /// <summary>
        /// Asks the property bag to read the named property into a caller-initialized VARIANT.
        /// </summary>
        /// <param name="propName">The name of the property to read. This cannot be NULL.</param>
        /// <param name="ptrVar">The caller-initialized VARIANT that is to receive the property value on output.</param>
        /// <param name="errLog">Address of the caller's error log in which the property bag stores any errors that occur during reads. This can be NULL; in that case, the caller does not receive errors.</param>
        public void Read(string propName, out object ptrVar, int errLog)
        {
            ptrVar = this.properties[propName];
        }

        /// <summary>
        /// Asks the property bag to save the named property in a caller-initialized VARIANT.
        /// </summary>
        /// <param name="propName">A string containing the name of the property to write. This cannot be NULL.</param>
        /// <param name="ptrVar">Reference to the caller-initialized VARIANT that holds the property value to save.</param>
        public void Write(string propName, ref object ptrVar)
        {
            this.properties[propName] = ptrVar;
        }

        /// <summary>
        /// Checks if the specified property name exists in the bag.
        /// </summary>
        /// <param name="propName">A property name.</param>
        /// <returns>A boolean indicating that the property was found in the property bag.</returns>
        public bool Contains(string propName)
        {
            return this.properties.Contains(propName);
        }
    }
}
