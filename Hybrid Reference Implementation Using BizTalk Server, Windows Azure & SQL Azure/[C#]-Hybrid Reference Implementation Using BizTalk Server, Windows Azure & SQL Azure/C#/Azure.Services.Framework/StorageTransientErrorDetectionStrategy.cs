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
    using System.Linq;
    using System.Data.Services.Client;
    using System.Text.RegularExpressions;

    using Microsoft.WindowsAzure.StorageClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Provides the transient error detection logic that can recognize transient faults when dealing with Windows Azure storage services.
    /// </summary>
    public class StorageTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Checks whether or not the specified exception belongs to a category of transient failures that can be compensated by a retry.
        /// </summary>
        /// <param name="ex">The exception object to be verified.</param>
        /// <returns>A Boolean result indicating whether or not the specified exception belongs to the category of transient errors.</returns>
        public bool IsTransient(Exception ex)
        {
            var webException = ex as WebException;

            if (webException != null && (webException.Status == WebExceptionStatus.ProtocolError || webException.Status == WebExceptionStatus.ConnectionClosed))
            {
                return true;
            }

            var dataServiceException = ex as DataServiceRequestException;

            if (dataServiceException != null)
            {
                if (IsErrorStringMatch(GetErrorCode(dataServiceException), StorageErrorCodeStrings.InternalError, StorageErrorCodeStrings.ServerBusy, StorageErrorCodeStrings.OperationTimedOut, TableErrorCodeStrings.TableServerOutOfMemory))
                {
                    return true;
                }
            }

            var serverException = ex as StorageServerException;

            if (serverException != null)
            {
                if (IsErrorCodeMatch(serverException, StorageErrorCode.ServiceInternalError, StorageErrorCode.ServiceTimeout))
                {
                    return true;
                }

                if (IsErrorStringMatch(serverException, StorageErrorCodeStrings.InternalError, StorageErrorCodeStrings.ServerBusy, StorageErrorCodeStrings.OperationTimedOut))
                {
                    return true;
                }
            }

            var storageException = ex as StorageClientException;

            if (storageException != null)
            {
                if (IsErrorStringMatch(storageException, StorageErrorCodeStrings.InternalError, StorageErrorCodeStrings.ServerBusy, TableErrorCodeStrings.TableServerOutOfMemory))
                {
                    return true;
                }
            }

            if (ex is TimeoutException)
            {
                return true;
            }

            return false;
        }

        #region Private members
        private static string GetErrorCode(DataServiceRequestException ex)
        {
            if (ex != null && ex.InnerException != null)
            {
                var regEx = new Regex(Resources.GetErrorCodeRegEx, RegexOptions.IgnoreCase);
                var match = regEx.Match(ex.InnerException.Message);

                return match.Groups[1].Value;
            }
            else
            {
                return null;
            }
        }

        private static bool IsErrorCodeMatch(StorageException ex, params StorageErrorCode[] codes)
        {
            return ex != null && codes.Contains(ex.ErrorCode);
        }

        private static bool IsErrorStringMatch(StorageException ex, params string[] errorStrings)
        {
            return ex != null && ex.ExtendedErrorInformation != null && errorStrings.Contains(ex.ExtendedErrorInformation.ErrorCode);
        }

        private static bool IsErrorStringMatch(string exceptionErrorString, params string[] errorStrings)
        {
            return errorStrings.Contains(exceptionErrorString);
        }
        #endregion
    }
}
