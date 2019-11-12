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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Configuration
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Configuration;
    using System.Reflection;
    using System.Collections.Generic;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Implements a configuration source that uses the Service Bus to communicate with a remote configuration source hosted on premises.
    /// </summary>
    [ConfigurationElementType(typeof(OnPremiseConfigurationSourceElement))]
    public sealed class OnPremiseConfigurationSource : IConfigurationSource
    {
        #region Private members
        private const int ServiceBusRequestRetryCount = 10;
        private const int ServiceBusRequestRetryIntervalSec = 1;

        private readonly ServiceBusEndpointInfo sbEndpointInfo;
        private readonly RetryPolicy retryPolicy;

        /// <summary>
        /// A dictionary object containing cached instances of the configuration sections.
        /// </summary>
        private readonly IDictionary<string, ConfigurationSection> configSectionCache;

        /// <summary>
        /// A lock object for the configuration section cache.
        /// </summary>
        private readonly object configSectionCacheLock = new object();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a configuration source that will connect to the on-premises configuration source using the specified Service Bus endpoint.
        /// </summary>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        public OnPremiseConfigurationSource(ServiceBusEndpointInfo sbEndpointInfo)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            this.sbEndpointInfo = sbEndpointInfo;
            this.retryPolicy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(ServiceBusRequestRetryCount, TimeSpan.FromSeconds(ServiceBusRequestRetryIntervalSec));
            this.configSectionCache = new Dictionary<string, ConfigurationSection>(16);
        }
        #endregion

        #region IConfigurationSource implementation
        /// <summary>
        /// Adds a ConfigurationSection to the configuration source and saves the configuration source.
        /// </summary>
        /// <param name="sectionName">The name by which the configurationSection should be added.</param>
        /// <param name="configurationSection">The configuration section to add.</param>
        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Adds a handler to be called when changes to the section named sectionName are detected. 
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler for the change event to add.</param>
        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieves the specified configuration section. 
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <returns>An instance of the specified configuration section, or null reference if a section by that name is not found.</returns>
        public ConfigurationSection GetSection(string sectionName)
        {
            var callToken = TraceManager.DebugComponent.TraceIn(sectionName);

            try
            {
                ConfigurationSection configSection = null;

                if (!this.configSectionCache.TryGetValue(sectionName, out configSection))
                {
                    lock (this.configSectionCacheLock)
                    {
                        if (!this.configSectionCache.TryGetValue(sectionName, out configSection))
                        {
                            configSection = RetrieveSection(sectionName);
                            this.configSectionCache.Add(sectionName, configSection);
                        }
                    }
                }

                return configSection;
            }
            finally
            {
                TraceManager.DebugComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Removes a configuration section from the configuration source. 
        /// </summary>
        /// <param name="sectionName">The name of the section to remove.</param>
        public void Remove(string sectionName)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Removes a handler to be called when changes to section are detected. 
        /// </summary>
        /// <param name="sectionName">The name of the watched section.</param>
        /// <param name="handler">The handler for the change event to remove.</param>
        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Event raised when any section in this configuration source changes.
        /// </summary>
        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;
        #endregion

        #region Private members
        private ConfigurationSection RetrieveSection(string sectionName)
        {
            var callToken = TraceManager.DebugComponent.TraceIn(sectionName);

            try
            {
                using (ReliableServiceBusClient<IOnPremiseConfigurationServiceChannel> configServiceClient = new ReliableServiceBusClient<IOnPremiseConfigurationServiceChannel>(this.sbEndpointInfo, this.retryPolicy))
                {
                    var startScopeInvokeService = TraceManager.DebugComponent.TraceStartScope(Resources.ScopeOnPremiseConfigurationSourceInvokeService, callToken);

                    try
                    {
                        // Invoke the WCF service in a reliable fashion and retrieve the specified configuration section.
                        XmlElement configSectionXml = configServiceClient.RetryPolicy.ExecuteAction<XmlElement>(() =>
                        {
                            return configServiceClient.Client.GetConfigurationSection(sectionName, CloudEnvironment.CurrentRoleName, CloudEnvironment.CurrentRoleMachineName);
                        });

                        if (configSectionXml != null)
                        {
                            // Instantiate a configuration object that correspond to the specified section.
                            ConfigurationSection configSection = ConfigurationSectionFactory.GetSection(sectionName);

                            // Gotcha: configuration section deserializer requires a well-formed XML document including processing instruction.
                            XmlDocument configXml = FrameworkUtility.CreateXmlDocument();
                            configXml.AppendChild(configXml.ImportNode(configSectionXml, true));

                            // Configure XML reader settings to disable validation and ignore certain XML entities.
                            XmlReaderSettings settings = new XmlReaderSettings
                            {
                                CloseInput = true,
                                IgnoreWhitespace = true,
                                IgnoreComments = true,
                                ValidationType = ValidationType.None,
                                IgnoreProcessingInstructions = true
                            };

                            // Create a reader to consume the XML data.
                            using (XmlReader reader = XmlReader.Create(new StringReader(configXml.OuterXml), settings))
                            {
                                // Attempt to cast the configuration section object into SerializableConfigurationSection for further check.
                                SerializableConfigurationSection serializableSection = configSection as SerializableConfigurationSection;

                                // Check if the the configuration section natively supports serialization/de-serialization.
                                if (serializableSection != null)
                                {
                                    // Yes, it's supported. Invoke the ReadXml method to consume XML and turn it into object model.
                                    serializableSection.ReadXml(reader);
                                }
                                else
                                {
                                    // No, it's unsupported. Need to do something different, starting with positioning the XML reader to the first available node.
                                    reader.Read();

                                    // Invoke the DeserializeSection method via reflection. This is the only way as the method is internal.
                                    MethodInfo info = configSection.GetType().GetMethod(WellKnownContractMember.MethodNames.DeserializeSection, BindingFlags.NonPublic | BindingFlags.Instance);
                                    info.Invoke(configSection, new object[] { reader });
                                }

                                reader.Close();
                            }

                            if (SourceChanged != null)
                            {
                                SourceChanged(this, new ConfigurationSourceChangedEventArgs(this, new string[] { sectionName }));
                            }

                            return configSection;
                        }
                        else
                        {
                            // The specified section is not supported by the remote configuration source. We should not throw an exception and rely on the caller to handle an empty section.
                            return null;
                        }
                    }
                    finally
                    {
                        TraceManager.DebugComponent.TraceEndScope(Resources.ScopeOnPremiseConfigurationSourceInvokeService, startScopeInvokeService, callToken);
                    }
                }
            }
            catch (Exception ex)
            {
                TraceManager.DebugComponent.TraceError(ex, callToken);
                throw;
            }
            finally
            {
                TraceManager.DebugComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.configSectionCache.Clear();
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~OnPremiseConfigurationSource()
        {
            this.Dispose(false);
        }
        #endregion
    }
}
