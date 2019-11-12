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

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the configuration service hosted on-premises.
    /// </summary>
    [ServiceContract(Name = "IOnPremiseConfigurationService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IOnPremiseConfigurationServiceContract
    {
        /// <summary>
        /// Retrieves the specified configuration section for a given application running on a specific machine.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section.</param>
        /// <param name="applicationName">The name of the application requesting the configuration section.</param>
        /// <param name="machineName">The machine name where the requesting application is running.</param>
        /// <returns>An instance of the configuration section serialized into an XML fragment so that it can be sent through the wire.</returns>
        [XmlSerializerFormat]
        [OperationContract(Name = WellKnownContractMember.MethodNames.GetConfigurationSection)]
        XmlElement GetConfigurationSection(
            [MessageParameter(Name = WellKnownContractMember.MessageParameters.SectionName)] string sectionName,
            [MessageParameter(Name = WellKnownContractMember.MessageParameters.ApplicationName)] string applicationName, 
            [MessageParameter(Name = WellKnownContractMember.MessageParameters.MachineName)] string machineName);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the on-premises configuration service.
    /// </summary>
    public interface IOnPremiseConfigurationServiceChannel : IOnPremiseConfigurationServiceContract, IClientChannel { }
}
