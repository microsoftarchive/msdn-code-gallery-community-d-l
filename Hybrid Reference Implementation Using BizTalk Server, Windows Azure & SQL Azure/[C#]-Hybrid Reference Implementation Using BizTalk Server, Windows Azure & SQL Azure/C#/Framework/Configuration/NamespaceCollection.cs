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
    using System.Xml;
    using System.Threading;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Represents a strongly-typed collection of the <see cref="NamespaceInfo"/> objects.
    /// </summary>
    public class NamespaceCollection : NamedElementCollection<NamespaceInfo>
    {
        #region Private members
        /// <summary>
        /// A lock object.
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// A collection of namespaces and their prefixes.
        /// </summary>
        private XmlNamespaceManager namespaceManager;
        #endregion

        #region Public properties
        /// <summary>
        /// Returns an instance of the <see cref="System.Xml.XmlNamespaceManager"/> class populated with the namespace URIs and their prefixes.
        /// </summary>
        public XmlNamespaceManager NamespaceManager
        {
            get
            {
                if (null == this.namespaceManager)
                {
                    lock (this.lockObject)
                    {
                        if (null == this.namespaceManager)
                        {
                            XmlNamespaceManager nsManager = new XmlNamespaceManager(new NameTable());

                            this.ForEach(namespaceInfo =>
                            {
                                try
                                {
                                    nsManager.AddNamespace(namespaceInfo.Prefix, namespaceInfo.Name);
                                }
                                catch (ArgumentException ex)
                                {
                                    throw new ArgumentException(ExceptionMessages.DuplicatePrefixFoundInNamespaceCollection, namespaceInfo.Name, ex);
                                }
                            });

                            Interlocked.Exchange<XmlNamespaceManager>(ref this.namespaceManager, nsManager);
                        }
                    }
                }

                return this.namespaceManager;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new item into the XML namespace collection. 
        /// </summary>
        /// <param name="name">The XML namespace.</param>
        /// <param name="prefix">The prefix of the XML namespace.</param>
        public void Add(string name, string prefix)
        {
            this.Add(new NamespaceInfo(name, prefix));
        }
        #endregion
    }

}
