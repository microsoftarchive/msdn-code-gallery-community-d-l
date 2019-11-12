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
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Represents an infrastructure object used by the Scalable Transformation Service to track state transitions when performing transformations.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class XslTransformState
    {
        #region Private members
        [DataMember]
        private readonly XslTransformState[] stateTracking;
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the name of the Windows Azure storage account holding the input document.
        /// </summary>
        [DataMember]
        public string StorageAccount { get; private set; }

        /// <summary>
        /// Gets the name of the Windows Azure blob storage's container holding the input document.
        /// </summary>
        [DataMember]
        public string ContainerName { get; private set; }

        /// <summary>
        /// Gets a reference of the input document in the Windows Azure blob storage.
        /// </summary>
        [DataMember]
        public string InputDocumentRef { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// The default constructor is inaccessible, the object needs to be instantiated using non-parameterless overloads.
        /// </summary>
        private XslTransformState()
        {
        }

        /// <summary>
        /// Initializes a new instance of a state object containing the initial location of the input document that will be used for performing XSLT-based transformation.
        /// </summary>
        /// <param name="storageAccount">The name of the Windows Azure storage account holding the input document.</param>
        /// <param name="containerName">The name of the Windows Azure blob storage's container holding the input document.</param>
        /// <param name="inputDocRef">The unique reference of the input document in the Windows Azure blob storage.</param>
        public XslTransformState(string storageAccount, string containerName, string inputDocRef)
        {
            this.StorageAccount = storageAccount;
            this.ContainerName = containerName;
            this.InputDocumentRef = inputDocRef;
            this.stateTracking = new XslTransformState[] { new XslTransformState() { StorageAccount = storageAccount, ContainerName = containerName, InputDocumentRef = inputDocRef } };
        }

        /// <summary>
        /// Initializes a new instance of a state object based on the initial state of the transformation and last known state that participates in state tracking.
        /// </summary>
        /// <param name="initialState">The initial state.</param>
        /// <param name="mergeState">The last known state that participates in state tracking.</param>
        public XslTransformState(XslTransformState initialState, XslTransformState mergeState)
        {
            this.StorageAccount = initialState.StorageAccount;
            this.ContainerName = initialState.ContainerName;
            this.InputDocumentRef = initialState.InputDocumentRef;

            var references = new List<XslTransformState>(mergeState.stateTracking);
            references.Add(new XslTransformState() { StorageAccount = this.StorageAccount, ContainerName = this.ContainerName, InputDocumentRef = this.InputDocumentRef });

            this.stateTracking = references.ToArray();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a collection of state objects describing the transition of a given input document throughout the transformation process.
        /// </summary>
        /// <returns>A read-only, enumerable list of state objects describing the transition of a given input document throughout the transformation process.</returns>
        public IEnumerable<XslTransformState> GetTransitions()
        {
            return Array.AsReadOnly<XslTransformState>(stateTracking);
        }
        #endregion
    }
}
