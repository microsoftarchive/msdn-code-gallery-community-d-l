//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Scalable Transform worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform
{
    #region Using references
    using System;
    using System.IO;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Provides an implementation of the Scalable Transform service that supports the <see cref="IScalableTransformationServiceContract"/> contract.
    /// This implementation adopts a forwarding technique that relays all calls to the underlying service operations to their respective event handlers.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ScalableTransformService : IScalableTransformationServiceContract
    {
        #region Public properties
        /// <summary>
        /// Occurs when the PrepareTransform service operation is invoked.
        /// </summary>
        public Func<Stream, XslTransformState> OnPrepareTransform { get; set; }

        /// <summary>
        /// Occurs when the ApplyTransform service operation is invoked.
        /// </summary>
        public Func<string, XslTransformState, XslTransformState> OnApplyTransform { get; set; }

        /// <summary>
        /// Occurs when the CompleteTransform service operation is invoked.
        /// </summary>
        public Func<XslTransformState, Stream> OnCompleteTransform { get; set; } 
        #endregion

        #region IScalableTransformationServiceContract implementation
        /// <summary>
        /// Prepares the specified source document for transformation.
        /// </summary>
        /// <param name="data">The stream of data containing the source document that needs to be transformed.</param>
        /// <returns>An instance of the object used by the Scalable Transformation Service to track state transitions when performing transformations.</returns>
        public XslTransformState PrepareTransform(Stream data)
        {
            Guard.ArgumentNotNull(data, "data");
            var callToken = TraceManager.ServiceComponent.TraceIn();

            try
            {
                if (OnPrepareTransform != null)
                {
                    return OnPrepareTransform(data);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            finally
            {
                TraceManager.ServiceComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Applies the specified transformation map name against the source document described by the given transformation state object.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation map.</param>
        /// <param name="state">An instance of the state object carrying the information related to the source document that will be transformed.</param>
        /// <returns>An instance of the object used by the Scalable Transformation Service to track state transitions when performing transformations.</returns>
        public XslTransformState ApplyTransform(string transformName, XslTransformState state)
        {
            Guard.ArgumentNotNull(state, "state");

            var callToken = TraceManager.ServiceComponent.TraceIn(state.StorageAccount, state.ContainerName, state.InputDocumentRef);

            try
            {
                if (OnApplyTransform != null)
                {
                    return OnApplyTransform(transformName, state);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            finally
            {
                TraceManager.ServiceComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Retrieves the transformed version of the source document described by the given transformation state object.
        /// </summary>
        /// <param name="state">An instance of the state object carrying the information related to the source document that will be transformed.</param>
        /// <returns>The stream of data containing the results from transformation.</returns>
        public Stream CompleteTransform(XslTransformState state)
        {
            Guard.ArgumentNotNull(state, "state");

            var callToken = TraceManager.ServiceComponent.TraceIn(state.StorageAccount, state.ContainerName, state.InputDocumentRef);

            try
            {
                if (OnCompleteTransform != null)
                {
                    return OnCompleteTransform(state);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            finally
            {
                TraceManager.ServiceComponent.TraceOut(callToken);
            }
        }
        #endregion
    }
}
