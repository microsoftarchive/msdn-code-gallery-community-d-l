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
namespace Contoso.Cloud.Integration.Azure.Services.Contracts.Data
{
    #region Using references
    using System;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Represents a request message when communicating with an on-premises Rules Engine.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class RulesEngineRequest : RulesEngineDataExchangeMessage
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of a request message using the specified policy name.
        /// </summary>
        /// <param name="policyName">The Rules Engine policy name.</param>
        public RulesEngineRequest(string policyName)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");

            PolicyName = policyName;
        }

        /// <summary>
        /// Initializes a new instance of a request message using the specified policy name and its version.
        /// </summary>
        /// <param name="policyName">The Rules Engine policy name.</param>
        /// <param name="policyVersion">The Rules Engine policy version.</param>
        public RulesEngineRequest(string policyName, Version policyVersion)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");
            Guard.ArgumentNotNull(policyVersion, "policyVersion");

            PolicyName = policyName;
            PolicyVersion = policyVersion;
        } 
        #endregion
    }
}
