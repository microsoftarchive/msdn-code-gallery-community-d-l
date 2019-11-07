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
    /// Represents a response message when communicating with an on-premises Rules Engine.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class RulesEngineResponse : RulesEngineDataExchangeMessage
    {
        #region Public properties
        /// <summary>
        /// Gets a flag indicating whether or not the policy invocation has been successful.
        /// </summary>
        [DataMember]
        public bool Success { get; private set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a response message using the specified policy name and its version.
        /// </summary>
        /// <param name="policyName">The Rules Engine policy name.</param>
        /// <param name="policyVersion">The Rules Engine policy version.</param>
        public RulesEngineResponse(string policyName, Version policyVersion) : this(policyName, policyVersion, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of a response message using the specified policy name, its version and success flag.
        /// </summary>
        /// <param name="policyName">The Rules Engine policy name.</param>
        /// <param name="policyVersion">The Rules Engine policy version.</param>
        /// <param name="success">The Boolean flag indicating whether or not the policy invocation has been successful.</param>
        public RulesEngineResponse(string policyName, Version policyVersion, bool success)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");

            PolicyName = policyName;
            PolicyVersion = policyVersion;
            Success = success;
        } 
        #endregion
    }
}
