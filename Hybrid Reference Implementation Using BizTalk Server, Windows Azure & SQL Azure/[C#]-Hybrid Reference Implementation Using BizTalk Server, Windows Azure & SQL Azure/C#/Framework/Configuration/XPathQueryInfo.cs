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
    using System.Xml;
    using System.Xml.XPath;
    using System.Text.RegularExpressions;
    using System.Globalization;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Represents the basic details about an XPath query.
    /// </summary>
    public class XPathQueryInfo : NamedConfigurationElement
    {
        #region Private members
        private const string XPathQueryProperty = "xPath";
        
        /// <summary>
        /// Indicates that the XPath query has been parsed.
        /// </summary>
        private bool parsed;

        /// <summary>
        /// A lock object.
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// A string containing parsed XPath expression with all macros substituted and namespaces expanded.
        /// </summary>
        private string parsedQueryText;

        /// <summary>
        /// A compiled instance of a regular expression used for parsing XPath queries and replacing macros with actual content of XPath expressions.
        /// </summary>
        private static Regex macroSearchExpr = new Regex(Resources.XPathQueryMacroRegEx, RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// A compiled instance of a regular expression used for expanding XPath expressions with explicit namespace references.
        /// </summary>
        private static Regex nsExpansionExpr = new Regex(Resources.XPathQueryParsingRegEx, RegexOptions.Singleline | RegexOptions.Compiled);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="XPathQueryInfo"/> object with default settings.
        /// </summary>
        public XPathQueryInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="XPathQueryInfo"/> object with specified name and XPath expression.
        /// </summary>
        /// <param name="name">The name of the XPath expression that can be further referenced from macros.</param>
        /// <param name="xPathExpr">The text of the XPath expression.</param>
        public XPathQueryInfo(string name, string xPathExpr) : base(name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");
            Guard.ArgumentNotNullOrEmptyString(xPathExpr, "xPathExpr");

            XPath = xPathExpr;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the XPath expression.
        /// </summary>
        [ConfigurationProperty(XPathQueryProperty, IsRequired = true)]
        public string XPath
        {
            get 
            { 
                return (string)base[XPathQueryProperty]; 
            }
            set 
            { 
                base[XPathQueryProperty] = value; 
                this.parsed = false;
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Parses the current XPath query in order to expand the prefixed elements with their fully qualified references.
        /// </summary>
        internal string ParseQuery(XPathQueryLibrary xPathLib)
        {
            if (null == this.parsedQueryText || !this.parsed)
            {
                lock (lockObject)
                {
                    if (null == this.parsedQueryText || !this.parsed)
                    {
                        string currentXPath = (string)base[XPathQueryProperty];

                        // Check whether or not the XPath Query Library object has any namespace definitions
                        if (xPathLib.Namespaces.Count > 0)
                        {
                            // Retrieve the list of namespaces along with their defined prefixes
                            XmlNamespaceManager namespaceManager = xPathLib.Namespaces.NamespaceManager;

                            // Represents the method that is called each time a regular expression match is found during a Replace method operation.
                            MatchEvaluator evaluator = new MatchEvaluator(match =>
                            {
                                string resolvedNamespace = namespaceManager.LookupNamespace(match.Groups[Resources.NamespaceGroupName].Value);

                                if (resolvedNamespace != null)
                                {
                                    // If the XML namespace was found, return a localized version of the XPath query (e.g. *[local-name()='NodeName' and namespace-uri()='FoundNamespace'])
                                    return String.Format(CultureInfo.InvariantCulture, Resources.XPathQueryTargetElementRef, match.Groups[Resources.NodeNameGroupName].Value, resolvedNamespace);
                                }
                                else
                                {
                                    // If the target XML namespace is not found, simply return the original fully qualified node name.
                                    return match.Groups[Resources.FullyQualifiedNodeNameGroupName].Value;
                                }
                            });

                            // Replace the XPath query with its parsed version.
                            currentXPath = nsExpansionExpr.Replace(currentXPath, evaluator);
                        }

                        // Perform macro substitution only if at least 1 macro has been found.
                        if (currentXPath != null && currentXPath.Contains("{$"))
                        {
                            // Represents the method that is called each time a regular expression match is found during a Replace method operation.
                            MatchEvaluator evaluator = new MatchEvaluator(match =>
                            {
                                XPathQueryInfo refQueryInfo = xPathLib.Queries.Get(match.Groups[1].Value);

                                // Check if we found the referenced XPathQueryInfo, also make sure we don't end up with a circular reference.
                                if (refQueryInfo != null && String.Compare(refQueryInfo.Name, this.Name, false, CultureInfo.InvariantCulture) != 0)
                                {
                                    return refQueryInfo.ParseQuery(xPathLib);
                                }
                                else
                                {
                                    return null;
                                }
                            });

                            // Update the XPath query with its parsed version.
                            currentXPath = macroSearchExpr.Replace(currentXPath, evaluator);
                        }

                        this.parsedQueryText = currentXPath;
                        this.parsed = true;
                    }
                }
            }

            return this.parsedQueryText;
        }
        #endregion
    }
}