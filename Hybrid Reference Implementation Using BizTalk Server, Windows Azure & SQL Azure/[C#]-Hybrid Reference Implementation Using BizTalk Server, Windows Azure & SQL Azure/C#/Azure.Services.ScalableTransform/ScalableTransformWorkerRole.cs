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
    using System.Linq;
    using System.ServiceModel;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Discovery;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    #endregion

    /// <summary>
    /// Implements a worker role dedicated to hosting of the Scalable Transform service.
    /// </summary>
    [ServiceBusHostWorkerRole(typeof(ScalableTransformService), ServiceBusEndpoint = "ScalableTransformService", AutoStart = false)]
    public class ScalableTransformWorkerRole : ReliableWorkerRoleBase
    {
        /// <summary>
        /// Extends the Run phase that is called by Windows Azure runtime after the role instance has been initialized.
        /// </summary>
        protected override void OnRoleRun()
        {
            Extensions.Demand<IServiceBusHostWorkerRoleExtension>();
            Extensions.Demand<IScalableTransformServiceExtension>();

            IServiceBusHostWorkerRoleExtension serviceHostExtension = Extensions.Find<IServiceBusHostWorkerRoleExtension>();
            IScalableTransformServiceExtension transformServiceImpl = Extensions.Find<IScalableTransformServiceExtension>();

            ScalableTransformService transformService = serviceHostExtension.FindServiceHost<ScalableTransformService>();

            if (transformService != null)
            {
                transformService.OnPrepareTransform = transformServiceImpl.PrepareTransform;
                transformService.OnApplyTransform = transformServiceImpl.ApplyTransform;
                transformService.OnCompleteTransform = transformServiceImpl.CompleteTransform;
            }

            serviceHostExtension.StartAll();
        }

        /// <summary>
        /// Extends the OnStart phase that is called by Windows Azure runtime to initialize the role instance.
        /// </summary>
        /// <returns>True if initialization succeeds, otherwise false.</returns>
        protected override bool OnRoleStart()
        {
            this.EnsureExists<ScalableTransformConfigurationExtension>();
            this.EnsureExists<CloudStorageProviderExtension>();
            this.EnsureExists<XslTransformMetadataProviderExtension>();
            this.EnsureExists<XslTransformInProcCacheExtension>();
            this.EnsureExists<XslTransformProviderExtension>();
            this.EnsureExists<EndpointConfigurationDiscoveryExtension>();

            IEndpointConfigurationDiscoveryExtension discoveryExtension = Extensions.Find<IEndpointConfigurationDiscoveryExtension>();
            IRoleConfigurationSettingsExtension roleConfigExtension = Extensions.Find<IRoleConfigurationSettingsExtension>();
            IScalableTransformConfigurationExtension serviceConfigExtension = Extensions.Find<IScalableTransformConfigurationExtension>();

            StorageAccountConfigurationSettings storageSettings = roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);
            XslTransformCloudBlobCacheExtension cloudBlobCache = new XslTransformCloudBlobCacheExtension(storageSettings.Accounts.Get(serviceConfigExtension.Settings.CacheStorageAccount));
            CloudStorageLoadBalancingExtension storageLoadBalancer = new CloudStorageLoadBalancingExtension(from name in serviceConfigExtension.Settings.StorageAccounts.AllKeys select storageSettings.Accounts.Get(name));

            // Configure the cache TTL for the blob caching extension.
            cloudBlobCache.CacheTimeToLive = serviceConfigExtension.Settings.BlobCacheTimeToLive;

            // Configure the cache TTL for the in-proc caching extension.
            XslTransformInProcCacheExtension memoryCache = Extensions.Find<XslTransformInProcCacheExtension>();
            memoryCache.CacheTimeToLive = serviceConfigExtension.Settings.MemoryCacheTimeToLive;

            Extensions.Add(cloudBlobCache);
            Extensions.Add(storageLoadBalancer);

            // Done with configuring all infrastructure extensions, now proceed with registering the service extension that implements the core methods.
            this.EnsureExists<ScalableTransformServiceExtension>();

            var contractTypeMatchCondition = ServiceEndpointDiscoveryCondition.ContractTypeExactMatch(typeof(IScalableTransformationServiceContract));
            var bindingTypeMatchCondition = ServiceEndpointDiscoveryCondition.BindingTypeExactMatch(typeof(NetTcpRelayBinding));

            discoveryExtension.RegisterDiscoveryAction(new[] { contractTypeMatchCondition, bindingTypeMatchCondition }, (endpoint) =>
            {
                NetTcpRelayBinding relayBinding = endpoint.Binding as NetTcpRelayBinding;

                if (relayBinding != null)
                {
                    relayBinding.TransferMode = TransferMode.Streamed;
                }
            });

            return true;
        }

        /// <summary>
        /// Extends the OnStop phase that is called by Windows Azure runtime when the role instance is to be stopped.
        /// </summary>
        protected override void OnRoleStop()
        {
        }
    }
}
