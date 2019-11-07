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
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.Globalization;

    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Defines an interface that must be implemented by all components which enable other components to extend themselves.
    /// </summary>
    public interface IExtensibleCloudServiceComponent : IExtensibleObject<IExtensibleCloudServiceComponent>
    {
    }

    /// <summary>
    /// Defines an interface that must be implemented by all components which extend the functionality of a host component.
    /// </summary>
    public interface ICloudServiceComponentExtension : IExtension<IExtensibleCloudServiceComponent>
    {
    }

    /// <summary>
    /// Provides extension methods for components that participate in the extension composition model.
    /// </summary>
    public static class CloudRoleExtensionMethods
    {
        /// <summary>
        /// Verifies whether or not the specified extension type exists in the extension collection. If not found, the extension will be
        /// automatically instantiated and added into the underlying collection.
        /// </summary>
        /// <typeparam name="T">The type of the extension. Must implement <see cref="System.ServiceModel.IExtension&lt;T&gt;"/> as prescribed by the extension model.</typeparam>
        /// <param name="instance">The instance of the object implementing the <see cref="IExtensibleCloudServiceComponent"/> interface.</param>
        public static void EnsureExists<T>(this IExtensibleCloudServiceComponent instance) where T : ICloudServiceComponentExtension, new()
        {
            if (null == instance.Extensions.Find<T>())
            {
                lock (instance)
                {
                    if (null == instance.Extensions.Find<T>())
                    {
                        instance.Extensions.Add(new T());
                    }
                }
            }
        }

        /// <summary>
        /// Verifies whether or not the specified extension type exists in the extension collection. If not found, an instance of the <see cref="CloudApplicationException"/>
        /// will be thrown.
        /// </summary>
        /// <typeparam name="T">The type of the extension. Must implement <see cref="System.ServiceModel.IExtension&lt;T&gt;"/> as prescribed by the extension model.</typeparam>
        /// <param name="collection">The instance of the object implementing the <see cref="System.ServiceModel.IExtensionCollection&lt;T&gt;"/> interface.</param>
        public static void Demand<T>(this IExtensionCollection<IExtensibleCloudServiceComponent> collection) where T : ICloudServiceComponentExtension
        {
            if (null == collection || null == collection.Find<T>())
            {
                throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.ExtensionObjectNotFound, typeof(T).Name));
            }
        }
    }
}
