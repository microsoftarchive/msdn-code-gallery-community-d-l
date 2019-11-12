//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Represents a definition of an XML namespace that will be used for building fully qualified XPath expressions.
    /// </summary>
    public class NamespaceInfo : NamedConfigurationElement
    {
        #region Private members
        private const string PrefixProperty = "prefix";
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="NamespaceInfo"/> object.
        /// </summary>
        public NamespaceInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="NamespaceInfo"/> object with specified name and prefix.
        /// </summary>
        /// <param name="name">The XML namespace.</param>
        /// <param name="prefix">The prefix of the XML namespace.</param>
        public NamespaceInfo(string name, string prefix) : base(name)
        {
            Prefix = prefix;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the prefix of the XML namespace.
        /// </summary>
        [ConfigurationProperty(PrefixProperty, IsRequired = true)]
        public string Prefix
        {
            get { return (string)base[PrefixProperty]; }
            set { base[PrefixProperty] = value; }
        }
        #endregion
    }
}
