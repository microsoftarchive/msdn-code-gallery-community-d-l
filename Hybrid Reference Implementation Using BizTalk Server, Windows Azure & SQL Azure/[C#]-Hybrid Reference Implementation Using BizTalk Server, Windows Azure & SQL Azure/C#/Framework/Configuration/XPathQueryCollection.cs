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

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Implements a collection of the <see cref="XPathQueryInfo"/> configuration elements holding XPath Library entries.
    /// </summary>
    public class XPathQueryCollection : NamedElementCollection<XPathQueryInfo>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="XPathQueryCollection"/> object with default settings.
        /// </summary>
        public XPathQueryCollection()
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new item into the XPath query collection. 
        /// </summary>
        /// <param name="name">The name of the XPath expression that can be further referenced from macros.</param>
        /// <param name="xPathExpr">The text of the XPath expression.</param>
        public void Add(string name, string xPathExpr)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");
            Guard.ArgumentNotNullOrEmptyString(xPathExpr, "xPathExpr");

            this.Add(new XPathQueryInfo(name, xPathExpr));
        }
        #endregion
    }
}
