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
    using System.Net.Sockets;
    using System.IdentityModel.Tokens;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides the transient error detection logic that can recognize transient faults when dealing with Windows Azure Service Bus.
    /// </summary>
    public class ServiceBusTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
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
                return false;
            }
            else if (ex is CommunicationException)
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
            else if (ex is SecurityTokenException)
            {
                return true;
            }
            else if (ex is ServerTooBusyException)
            {
                return true;
            }
            else if (ex is ServerErrorException)
            {
                return true;
            }
            else if (ex is InvalidOperationException)
            {
                return true;
            }
            else if (ex is EndpointNotFoundException)
            {
                // This exception may occur when a listener and a consumer are being
                // initialized out of sync (e.g. consumer is reaching to a listener that
                // is still in the process of setting up the Service Host).
                return true;
            }
            else if (ex is SocketException)
            {
                SocketException socketFault = ex as SocketException;

                return socketFault.SocketErrorCode == SocketError.TimedOut;
            }
            else if (ex is ProtocolException)
            {
                // Attempt to handle a condition upon which a client channel fails with the following exception:
                // "This channel can no longer be used to send messages as the output session was auto-closed due to a server-initiated shutdown. 
                // Either disable auto-close by setting the DispatchRuntime.AutomaticInputSessionShutdown to false, or consider modifying the shutdown protocol with the remote server."
                return true;
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
