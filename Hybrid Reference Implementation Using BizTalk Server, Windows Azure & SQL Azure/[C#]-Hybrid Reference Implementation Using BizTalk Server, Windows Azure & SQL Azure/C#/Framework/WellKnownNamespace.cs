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
namespace Contoso.Cloud.Integration.Framework
{
    #region Using statements
    using System;
    #endregion

    /// <summary>
    /// Provides the well-known namespaces used by WCF service and data contracts.
    /// </summary>
    public struct WellKnownNamespace
    {
        /// <summary>
        /// Provides the well-known namespaces used by WCF data contracts.
        /// </summary>
        public struct DataContracts
        {
            /// <summary>
            /// Returns the standard name of the General namespace.
            /// </summary>
            public const string General = "Contoso.Cloud.Integration.DataContracts";

            /// <summary>
            /// Returns the standard name of the Infrastructure namespace.
            /// </summary>
            public const string Infrastructure = "Contoso.Cloud.Integration.Infrastructure";
        }

        /// <summary>
        /// Provides the well-known namespaces used by WCF service contracts.
        /// </summary>
        public struct ServiceContracts
        {
            /// <summary>
            /// Returns the standard name of the General namespace.
            /// </summary>
            public const string General = "Contoso.Cloud.Integration.ServiceContracts";
        }
    }
}