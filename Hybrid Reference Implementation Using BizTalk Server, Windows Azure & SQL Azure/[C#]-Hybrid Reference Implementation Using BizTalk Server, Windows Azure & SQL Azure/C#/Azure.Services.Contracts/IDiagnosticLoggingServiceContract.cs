//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains service and data contract definitions.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Contracts
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.Diagnostics;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the Real-Time Diagnostic Logging service.
    /// </summary>
    [ServiceContract(Name = "IDiagnosticLoggingService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IDiagnosticLoggingServiceContract
    {
        /// <summary>
        /// Submits the specified trace events to the Real-Time Diagnostic Logging service for processing.
        /// </summary>
        /// <param name="traceEvents">The list of trace events to be submitted to the Real-Time Diagnostic Logging service.</param>
        [OperationContract(IsOneWay = true, Name = "TraceEvent")]
        void TraceEvent([MessageParameter(Name = WellKnownContractMember.MessageParameters.TraceEvents)] TraceEventRecord[] traceEvents);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the Real-Time Diagnostic Logging service.
    /// </summary>
    public interface IDiagnosticLoggingServiceChannel : IDiagnosticLoggingServiceContract, IClientChannel { }
}
