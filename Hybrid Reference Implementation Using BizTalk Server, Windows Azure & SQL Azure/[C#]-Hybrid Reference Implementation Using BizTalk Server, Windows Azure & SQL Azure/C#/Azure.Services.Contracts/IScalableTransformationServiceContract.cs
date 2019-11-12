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
    using System.IO;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the Scalable Transformation service.
    /// </summary>
    [ServiceContract(Name = "IScalableTransformationService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IScalableTransformationServiceContract
    {
        /// <summary>
        /// Prepares the specified source document for transformation.
        /// </summary>
        /// <param name="data">The stream of data containing the source document that needs to be transformed.</param>
        /// <returns>An instance of the object used by the Scalable Transformation Service to track state transitions when performing transformations.</returns>
        [OperationContract]
        XslTransformState PrepareTransform(Stream data);

        /// <summary>
        /// Applies the specified transformation map name against the source document described by the given transformation state object.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation map.</param>
        /// <param name="state">An instance of the state object carrying the information related to the source document that will be transformed.</param>
        /// <returns>An instance of the object used by the Scalable Transformation Service to track state transitions when performing transformations.</returns>
        [OperationContract]
        XslTransformState ApplyTransform(string transformName, XslTransformState state);

        /// <summary>
        /// Retrieves the transformed version of the source document described by the given transformation state object.
        /// </summary>
        /// <param name="state">An instance of the state object carrying the information related to the source document that will be transformed.</param>
        /// <returns>The stream of data containing the results from transformation.</returns>
        [OperationContract]
        Stream CompleteTransform(XslTransformState state);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the Scalable Transformation service.
    /// </summary>
    public interface IScalableTransformationServiceChannel : IScalableTransformationServiceContract, IClientChannel { }
}
