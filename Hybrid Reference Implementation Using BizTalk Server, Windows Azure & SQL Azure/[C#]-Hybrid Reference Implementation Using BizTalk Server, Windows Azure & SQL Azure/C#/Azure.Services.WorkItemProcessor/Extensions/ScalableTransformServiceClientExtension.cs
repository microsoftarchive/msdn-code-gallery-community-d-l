//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Work Item Processor worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Extensions
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.ServiceModel;
    using System.Globalization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Properties;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    #region IScalableTransformServiceClientExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for interoperating with the Scalable Transform service.
    /// </summary>
    public interface IScalableTransformServiceClientExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Applies the specified transformation map against the input document.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation map.</param>
        /// <param name="input">The input document that needs to be transformed.</param>
        /// <returns>The results from transformation.</returns>
        XDocument ApplyTransform(string transformName, XDocument input);
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for interoperating with the Scalable Transform service.
    /// </summary>
    public class ScalableTransformServiceClientExtension : IScalableTransformServiceClientExtension
    {
        #region Private members
        private IRoleConfigurationSettingsExtension roleConfigExtension;
        private RetryPolicy communicationRetryPolicy;
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
            this.communicationRetryPolicy = this.roleConfigExtension.CommunicationRetryPolicy;
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region IScalableTransformServiceClientExtension implementation
        /// <summary>
        /// Applies the specified transformation map against the input document.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation map.</param>
        /// <param name="input">The input document that needs to be transformed.</param>
        /// <returns>The results from transformation.</returns>
        public XDocument ApplyTransform(string transformName, XDocument input)
        {
            Guard.ArgumentNotNull(this.roleConfigExtension, "roleConfigExtension");
            Guard.ArgumentNotNullOrEmptyString(transformName, "transformName");
            Guard.ArgumentNotNull(input, "input");
            Guard.ArgumentNotNull(input.Root, "input.Root");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(transformName, input.Root.Name);

            try
            {
                ServiceBusEndpointInfo sbEndpointInfo = this.roleConfigExtension.GetServiceBusEndpoint(WellKnownEndpointName.ScalableTransformService);

                if (sbEndpointInfo != null)
                {
                    using (ReliableServiceBusClient<IScalableTransformationServiceChannel> transform = new ReliableServiceBusClient<IScalableTransformationServiceChannel>(sbEndpointInfo, this.roleConfigExtension.CommunicationRetryPolicy))
                    using (MemoryStream dataStream = new MemoryStream())
                    using (XmlWriter xmlWriter = XmlWriter.Create(dataStream))
                    {
                        input.WriteTo(xmlWriter);

                        xmlWriter.Flush();
                        dataStream.Seek(0, SeekOrigin.Begin);

                        XslTransformState preparedState = transform.RetryPolicy.ExecuteAction<XslTransformState>(() =>
                        {
                            return transform.Client.PrepareTransform(dataStream);
                        });

                        XslTransformState transformedState = transform.RetryPolicy.ExecuteAction<XslTransformState>(() =>
                        {
                            return transform.Client.ApplyTransform(transformName, preparedState);
                        });

                        using (Stream transformedData = transform.RetryPolicy.ExecuteAction<Stream>(() =>
                        {
                            return transform.Client.CompleteTransform(transformedState);
                        }))
                        {
                            return XDocument.Load(transformedData);
                        }
                    }
                }
                else
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.ServiceBusEndpointNotFound, WellKnownEndpointName.ScalableTransformService));
                }
            }
            catch (Exception ex)
            {
                TraceManager.WorkerRoleComponent.TraceError(ex, callToken);
                throw;
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }
        #endregion
    }
}
