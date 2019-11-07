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
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Extensions
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;
    using System.Xml.Linq;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    #region IXslTransformMetadataProviderExtension interface
    /// <summary>
    /// Defines a contract that needs to be implemented by an extension responsible for providing the XSLT transformation metadata.
    /// </summary>
    public interface IXslTransformMetadataProviderExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns the XSLT transformation metadata for the specified transform object name.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation object.</param>
        /// <returns>A set of metadata for the XSLT-based transformation object.</returns>
        XslTransformMetadata GetXslTransformMetadata(string transformName);
    }
    #endregion

    /// <summary>
    /// Provides XSLT transformation metadata directly from the metadata source bypassing any interim caching layers.
    /// </summary>
    public class XslTransformMetadataProviderExtension : IXslTransformMetadataProviderExtension
    {
        #region Private members
        private IRoleConfigurationSettingsExtension roleConfigExtension;
        #endregion

        #region XslTransformMetadataProviderExtension implementation
        /// <summary>
        /// Returns the XSLT transformation metadata for the specified transform object name.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation object.</param>
        /// <returns>A set of metadata for the XSLT-based transformation object.</returns>
        public XslTransformMetadata GetXslTransformMetadata(string transformName)
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(transformName);

            try
            {
                using (ReliableServiceBusClient<IOnPremiseTransformationServiceChannel> transformServiceClient = new ReliableServiceBusClient<IOnPremiseTransformationServiceChannel>(this.roleConfigExtension.OnPremiseRelayTwoWayEndpoint, this.roleConfigExtension.CommunicationRetryPolicy))
                {
                    return transformServiceClient.RetryPolicy.ExecuteAction<XslTransformMetadata>(() =>
                    {
                        return transformServiceClient.Client.GetXslTransformMetadata(transformName);
                    });
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();
            this.roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion
    }
}
