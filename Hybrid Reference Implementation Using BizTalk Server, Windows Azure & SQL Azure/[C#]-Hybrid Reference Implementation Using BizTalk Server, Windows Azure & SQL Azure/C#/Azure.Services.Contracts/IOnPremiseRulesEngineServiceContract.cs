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
    using System.Xml;
    using System.ServiceModel;
    using System.Configuration;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the Rules Engine service hosted on-premises.
    /// </summary>
    [ServiceContract(Name = "IOnPremiseRulesEngineService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IOnPremiseRulesEngineServiceContract
    {
        /// <summary>
        /// Invokes a Rules Engine policy specified in the request message and returns the results of the policy execution.
        /// </summary>
        /// <param name="request">The request message containing policy name, version number and a list of policy facts.</param>
        /// <returns>The response from the Rules Engine service with the results of the policy execution.</returns>
        [OperationContract(Name = WellKnownContractMember.MethodNames.ExecutePolicy)]
        RulesEngineResponse ExecutePolicy([MessageParameter(Name = WellKnownContractMember.MessageParameters.Request)] RulesEngineRequest request);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the on-premises Rules Engine service.
    /// </summary>
    public interface IOnPremiseRulesEngineServiceChannel : IOnPremiseRulesEngineServiceContract, IClientChannel { }
}
