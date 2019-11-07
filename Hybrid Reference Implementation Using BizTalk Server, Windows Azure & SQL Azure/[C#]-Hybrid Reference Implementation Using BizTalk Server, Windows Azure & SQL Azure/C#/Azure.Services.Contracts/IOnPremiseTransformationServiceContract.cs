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
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the XSLT Transformation service hosted on-premises.
    /// </summary>
    [ServiceContract(Name = "IOnPremiseTransformationService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IOnPremiseTransformationServiceContract
    {
        /// <summary>
        /// Retrieves the XSLT transformation object metadata for the specified transformation map name.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation map.</param>
        /// <returns>A set of metadata for the XSLT-based transformation object or a null reference if the specified map has not been found.</returns>
        [OperationContract(Name = WellKnownContractMember.MethodNames.GetXslTransformMetadata)]
        XslTransformMetadata GetXslTransformMetadata([MessageParameter(Name = WellKnownContractMember.MessageParameters.TransformName)] string transformName);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the on-premises XSLT Transformation service.
    /// </summary>
    public interface IOnPremiseTransformationServiceChannel : IOnPremiseTransformationServiceContract, IClientChannel { }
}
