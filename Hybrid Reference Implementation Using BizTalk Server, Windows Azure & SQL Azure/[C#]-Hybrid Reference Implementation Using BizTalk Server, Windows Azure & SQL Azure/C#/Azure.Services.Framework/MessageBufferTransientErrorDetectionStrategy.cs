//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.Net;
    using System.ServiceModel;
    using System.IdentityModel.Tokens;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides the transient error detection logic that is specific to Windows Azure Service Bus Message Buffers.
    /// </summary>
    public class MessageBufferTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Checks whether or not the specified exception belongs to a category of transient failures that can be compensated by a retry.
        /// </summary>
        /// <param name="ex">The exception object to be verified.</param>
        /// <returns>A Boolean result indicating whether or not the specified exception belongs to the category of transient errors.</returns>
        public bool IsTransient(Exception ex)
        {
            if (ex is FaultException)
            {
                return true;
            }
            else if (ex is TimeoutException)
            {
                return true;
            }
            else if (ex is WebException)
            {
                return true;
            }

            return false;
        }
    }
}
