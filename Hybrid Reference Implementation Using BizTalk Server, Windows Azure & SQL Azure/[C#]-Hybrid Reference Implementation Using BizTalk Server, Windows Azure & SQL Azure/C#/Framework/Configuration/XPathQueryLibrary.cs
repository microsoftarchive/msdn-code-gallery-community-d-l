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
    using System.Xml.XPath;
    using System.Configuration;
    using System.Globalization;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Wrapper class for strongly-typed collection of well-known XPath queries and XML namespaces.
    /// </summary>
    [Serializable]
    public class XPathQueryLibrary : SerializableConfigurationSection
    {
        #region Private members
        private const string QueryCollectionProperty = "Queries";
        private const string NamespaceCollectionProperty = "Namespaces";
        #endregion

        #region Public members
        /// <summary>
        /// Configuration section name as defined in the application configuration file.
        /// </summary>
        public const string SectionName = "XPathQueryLibrary"; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="XPathQueryLibrary"/> class that contains empty values for all XPath queries.
        /// </summary>
        public XPathQueryLibrary()
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the collection of XPath queries.
        /// </summary>
        [ConfigurationProperty(QueryCollectionProperty)]
        public XPathQueryCollection Queries
        {
            get { return base[QueryCollectionProperty] as XPathQueryCollection; }
        }

        /// <summary>
        /// Returns the collection of XML namespaces.
        /// </summary>
        [ConfigurationProperty(NamespaceCollectionProperty)]
        public NamespaceCollection Namespaces
        {
            get { return base[NamespaceCollectionProperty] as NamespaceCollection; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a parsed version of the XPath query by its name. The parsed query does not contain any macros, all macros will be expanded to their respective sequences.
        /// </summary>
        /// <param name="name">The unique name under which the XPath query is registered in the XPath library.</param>
        /// <returns>The parsed version of the XPath query.</returns>
        public string GetXPathQuery(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            XPathQueryInfo queryInfo = this.Queries.Get(name);

            if (null == queryInfo || String.IsNullOrEmpty(queryInfo.XPath))
            {
                throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.XPathQueryNotDefined, name));
            }

            return queryInfo.ParseQuery(this);
        }
        #endregion
    }

}
