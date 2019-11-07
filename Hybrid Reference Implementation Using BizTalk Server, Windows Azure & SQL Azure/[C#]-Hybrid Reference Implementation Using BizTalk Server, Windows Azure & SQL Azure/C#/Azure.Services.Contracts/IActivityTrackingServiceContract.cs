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

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the Business Activity Monitoring (BAM) service.
    /// </summary>
    [ServiceContract(Name = "IActivityTrackingService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IActivityTrackingServiceContract
    {
        /// <summary>
        /// Tells the Business Activity Monitoring service to invoke the BeginActivity operation. 
        /// This creates a new activity record so that data can tracked using the UpdateActivity method. 
        /// </summary>
        /// <param name="activity">The instance of the tracking activity.</param>
        [OperationContract(IsOneWay = true, Name = WellKnownContractMember.MethodNames.BeginActivity)]
        void BeginActivity([MessageParameter(Name = WellKnownContractMember.MessageParameters.Activity)] ActivityBase activity);

        /// <summary>
        /// Tells the Business Activity Monitoring service to invoke the UpdateActivity operation. This updates the activity record.
        /// </summary>
        /// <param name="activity">The instance of the tracking activity.</param>
        [OperationContract(IsOneWay = true, Name = WellKnownContractMember.MethodNames.UpdateActivity)]
        void UpdateActivity([MessageParameter(Name = WellKnownContractMember.MessageParameters.Activity)] ActivityBase activity);

        /// <summary>
        /// Tells the Business Activity Monitoring service to invoke the EndActivity operation. 
        /// This indicates that there are no more events expected for the given activity instance. 
        /// </summary>
        /// <param name="activity">The instance of the tracking activity.</param>
        [OperationContract(IsOneWay = true, Name = WellKnownContractMember.MethodNames.CompleteActivity)]
        void CompleteActivity([MessageParameter(Name = WellKnownContractMember.MessageParameters.Activity)] ActivityBase activity);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the Business Activity Monitoring (BAM) service.
    /// </summary>
    public interface IActivityTrackingServiceChannel : IActivityTrackingServiceContract, IClientChannel { }
}
