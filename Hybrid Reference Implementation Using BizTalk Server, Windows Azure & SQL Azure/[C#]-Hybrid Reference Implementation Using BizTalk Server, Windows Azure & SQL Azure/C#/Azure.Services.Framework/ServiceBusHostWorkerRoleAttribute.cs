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
    #endregion

    /// <summary>
    /// Provides a declarative mechanism for enabling auto-hosting of the Windows Azure Service Bus service contracts in a worker role.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class ServiceBusHostWorkerRoleAttribute : Attribute
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ServiceHostWorkerRoleAttribute class with the type of service.
        /// </summary>
        /// <param name="serviceType">The type of hosted service.</param>
        public ServiceBusHostWorkerRoleAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }

        /// <summary>
        /// Initializes a new instance of the ServiceHostWorkerRoleAttribute class with the type of service and name of a service bus endpoint.
        /// </summary>
        /// <param name="serviceType">The type of hosted service.</param>
        /// <param name="serviceBusEndpoint">The name of the Service Bus endpoint definition in the application configuration.</param>
        public ServiceBusHostWorkerRoleAttribute(Type serviceType, string serviceBusEndpoint)
        {
            ServiceType = serviceType;
            ServiceBusEndpoint = serviceBusEndpoint;
        } 
        #endregion

        #region Public properties
        /// <summary>
        /// The type of hosted service.
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// The name of the Service Bus endpoint definition in the application configuration.
        /// </summary>
        public string ServiceBusEndpoint { get; set; }

        /// <summary>
        /// Indicates whether the service host is to be started automatically when the hosting worker role is starting.
        /// </summary>
        public bool AutoStart { get; set; } 
        #endregion
    }
}
