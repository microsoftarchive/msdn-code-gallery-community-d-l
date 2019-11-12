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
    using System.Net.Sockets;
    using System.ServiceModel;

    using Microsoft.ServiceBus;
    using Microsoft.ApplicationServer.Caching;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides the transient error detection logic that can recognize transient faults when dealing with Windows Azure Caching Service.
    /// </summary>
    public class CacheTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Checks whether or not the specified exception belongs to a category of transient failures that can be compensated by a retry.
        /// </summary>
        /// <param name="ex">The exception object to be verified.</param>
        /// <returns>A Boolean result indicating whether or not the specified exception belongs to the category of transient errors.</returns>
        public bool IsTransient(Exception ex)
        {
            if (ex is ServerTooBusyException)
            {
                return true;
            }
            else if (ex is SocketException)
            {
                SocketException socketFault = ex as SocketException;

                return socketFault.SocketErrorCode == SocketError.TimedOut;
            }
            else if (ex is DataCacheException)
            {
                var cacheException = ex as DataCacheException;

                return (cacheException.ErrorCode == DataCacheErrorCode.ServiceAccessError) ||
                       (cacheException.ErrorCode == DataCacheErrorCode.RetryLater) ||
                       (cacheException.ErrorCode == DataCacheErrorCode.ConnectionTerminated) ||
                       (cacheException.ErrorCode == DataCacheErrorCode.Timeout) ||
                       (cacheException.SubStatus == DataCacheErrorSubStatus.CacheServerUnavailable) ||
                       (cacheException.SubStatus == DataCacheErrorSubStatus.ServiceMemoryShortage) ||
                       (cacheException.SubStatus == DataCacheErrorSubStatus.Throttled) ||
                       (cacheException.SubStatus == DataCacheErrorSubStatus.QuotaExceeded);
            }

            // Some transient exceptions may be wrapped into an outer exception, hence we should also inspect any inner exceptions.
            if (ex != null && ex.InnerException != null)
            {
                return IsTransient(ex.InnerException);
            }

            return false;
        }
    }
}
