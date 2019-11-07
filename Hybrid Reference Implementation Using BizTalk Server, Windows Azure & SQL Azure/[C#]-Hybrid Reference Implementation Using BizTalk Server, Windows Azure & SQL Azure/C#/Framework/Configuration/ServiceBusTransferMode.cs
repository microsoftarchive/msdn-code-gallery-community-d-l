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
    using System.ComponentModel;
    #endregion

    /// <summary>
    /// Provides message transfer modes supported by Windows Azure Service Bus.
    /// </summary>
    [DefaultValue(ServiceBusTransferMode.Buffered)]
    public enum ServiceBusTransferMode
    {
        /// <summary>
        /// The request and response messages are both buffered. 
        /// </summary>
        Buffered,

        /// <summary>
        /// The request and response messages are both streamed. 
        /// </summary>
        Streamed,

        /// <summary>
        /// The request message is streamed and the response message is buffered. 
        /// </summary>
        StreamedRequest,

        /// <summary>
        /// The request message is buffered and the response message is streamed. 
        /// </summary>
        StreamedResponse
    }
}
