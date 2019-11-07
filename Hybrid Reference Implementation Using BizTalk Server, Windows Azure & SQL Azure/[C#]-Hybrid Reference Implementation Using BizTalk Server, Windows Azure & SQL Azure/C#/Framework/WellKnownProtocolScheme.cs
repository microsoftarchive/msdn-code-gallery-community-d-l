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
    /// Provides the well-known protocol schemes used by application when constructing endpoint addresses.
    /// </summary>
    public struct WellKnownProtocolScheme
    {
        /// <summary>
        /// Returns the standard name of the protocol scheme reserved for Service Bus endpoint addresses.
        /// </summary>
        public const string ServiceBus = "sb";

        /// <summary>
        /// Returns the standard name of the protocol scheme reserved for HTTP-based endpoint addresses.
        /// </summary>
        public const string Http = "https";

        /// <summary>
        /// Returns the standard name of the protocol scheme reserved for HTTPS endpoint addresses.
        /// </summary>
        public const string SecureHttp = "https";
    }
}
