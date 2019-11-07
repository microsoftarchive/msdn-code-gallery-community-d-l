//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    #endregion

    #region ICloudQueueLocationResolverExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for dynamically resolving the location of a given queue at runtime.
    /// </summary>
    public interface ICloudQueueLocationResolverExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Resolves the exact location of a given queue by its name.
        /// </summary>
        /// <param name="queueName">The name of the Windows Azure queue.</param>
        /// <returns>The location of the queue in the Windows Azure storage infrastructure.</returns>
        CloudQueueLocation GetQueueLocation(string queueName);
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for for dynamically resolving the location of a given queue at runtime.
    /// </summary>
    public class CloudQueueLocationResolverExtension : ICloudQueueLocationResolverExtension
    {
        #region ICloudQueueLocationResolverExtension implementation
        /// <summary>
        /// Resolves the exact location of a given queue by its name.
        /// </summary>
        /// <param name="queueName">The name of the Windows Azure queue.</param>
        /// <returns>The location of the queue in the Windows Azure storage infrastructure.</returns>
        public CloudQueueLocation GetQueueLocation(string queueName)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
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
