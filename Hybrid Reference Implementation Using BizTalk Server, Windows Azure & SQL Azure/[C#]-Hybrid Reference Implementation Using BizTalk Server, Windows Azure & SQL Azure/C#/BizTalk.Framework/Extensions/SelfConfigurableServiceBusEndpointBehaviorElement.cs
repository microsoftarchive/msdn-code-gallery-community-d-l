//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.Extensions
{
    #region Using statements
    using System;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Channels;
    using System.Configuration;
    #endregion

    /// <summary>
    /// Implements an extension element for a custom WCF endpoint behavior.
    /// </summary>
    public class SelfConfigurableServiceBusEndpointBehaviorElement : BehaviorExtensionElement
    {
        #region Private members
        /// <summary>
        /// Defines the name of the configuration property as appears in the configuration file or BizTalk Admin console.
        /// </summary>
        private const string ServiceBusEndpointNameProperty = "serviceBusEndpointName";
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the value of the mandatory property containing the name of the Windows Azure Service Bus endpoint
        /// definition in the application configuration.
        /// </summary>
        [ConfigurationProperty(ServiceBusEndpointNameProperty, IsRequired = true)]
        public string ServiceBusEndpointName
        {
            get { return (string)(base[ServiceBusEndpointNameProperty]); }
            set { base[ServiceBusEndpointNameProperty] = value; }
        }
        #endregion

        #region BehaviorExtensionElement implementation
        /// <summary>
        /// Returns the underlying type of a custom behavior.
        /// </summary>
        public override Type BehaviorType
        {
            get { return typeof(SelfConfigurableServiceBusEndpointBehavior); }
        }

        /// <summary>
        /// Creates a behavior extension based on the current configuration settings.
        /// </summary>
        /// <returns>The instance of a custom behavior extension.</returns>
        protected override object CreateBehavior()
        {
            return new SelfConfigurableServiceBusEndpointBehavior(this.ServiceBusEndpointName);
        }
        #endregion
    }
}
