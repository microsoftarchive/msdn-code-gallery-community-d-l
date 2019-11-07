//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Helper class that exposes all strongly-typed configuration sections and also provides an ability to save the
    /// configuration changes for custom sections.
    /// </summary>
    public sealed class ApplicationConfiguration
    {
        #region Private members
        /// <summary>
        /// A pre-initialized instance of the current configuration.
        /// </summary>
        private static volatile ApplicationConfiguration currentConfiguration;

        /// <summary>
        /// A lock object.
        /// </summary>
        private static readonly object initLock = new object();

        /// <summary>
        /// A flag indicating that the current configuration has been successfully loaded.
        /// </summary>
        private static bool configLoaded;

        /// <summary>
        /// A reference to the default configuration source configured in Enterprise Library.
        /// </summary>
        private readonly IConfigurationSource defaultConfigSource;

        /// <summary>
        /// A cached reference to the DatabaseConfigurationSettings configuration section.
        /// </summary>
        private DatabaseConfigurationSettings databaseConfig;

        /// <summary>
        /// Flags indicating that the corresponding configuration section must be reloaded.
        /// </summary>
        private bool reloadDatabaseConfig;

        /// <summary>
        /// Lock objects for each individual configuration section.
        /// </summary>
        private readonly object lockDatabaseConfig = new object();

        /// <summary>
        /// A dictionary object containing cached instances of the configuration sections.
        /// </summary>
        private readonly IDictionary<string, ConfigurationSection> configSectionCache;

        /// <summary>
        /// A lock object for the configuration section cache.
        /// </summary>
        private readonly object configSectionCacheLock = new object();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ApplicationConfiguration class using default configuration source.
        /// </summary>
        private ApplicationConfiguration() : this(ConfigurationSourceFactory.Create())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationConfiguration class using the specified configuration source.
        /// </summary>
        /// <param name="configSource">The configuration source.</param>
        private ApplicationConfiguration(IConfigurationSource configSource)
        {
            // Create an instance of the configuration source based on the application config file's (e.g. app.config) definition.
            this.defaultConfigSource = configSource;
            this.configSectionCache = new Dictionary<string, ConfigurationSection>(16);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns a flag indicating that the current configuration has been successfully loaded.
        /// </summary>
        public static bool IsLoaded
        {
            get { return configLoaded; }
        }

        /// <summary>
        /// Returns the object that actually implements the underlying source for getting configuration information.
        /// </summary>
        public IConfigurationSource Source
        {
            get { return this.defaultConfigSource; }
        }

        /// <summary>
        /// Returns an instance of the ApplicationConfiguration class by enforcing a singleton design pattern with a lazy initialization.
        /// </summary>
        public static ApplicationConfiguration Current
        {
            get
            {
                if (null == currentConfiguration)
                {
                    lock (initLock)
                    {
                        // If we were the second process attempting to initialize the currentConfiguration member, when we enter
                        // this critical section let's check once again if the member was not already initialized by the another
                        // process. As the lock will ensure a serialized execution, we need to make sure that we don't attempt
                        // to re-initialize the ready-to-go instance.
                        if (null == currentConfiguration)
                        {
                            currentConfiguration = new ApplicationConfiguration();
                            configLoaded = true;
                        }
                    }
                }

                return currentConfiguration;
            }
        }

        /// <summary>
        /// Returns the Database Configuration section.
        /// </summary>
        public DatabaseConfigurationSettings Databases
        {
            get
            {
                if (null == this.databaseConfig || this.reloadDatabaseConfig)
                {
                    // Lock the section to ensure that no other threads will attempt to initialize or reload it.
                    lock (this.lockDatabaseConfig)
                    {
                        if (null == this.databaseConfig || this.reloadDatabaseConfig)
                        {
                            this.databaseConfig = new DatabaseConfigurationSettings(this.Source);
                            this.reloadDatabaseConfig = false;
                        }
                    }
                }

                return this.databaseConfig;
            }
        }

        /// <summary>
        /// Returns the <see cref="XPathQueryLibrary"/> configuration section. 
        /// </summary>
        public XPathQueryLibrary XPathQueries
        {
            get { return GetConfigurationSection<XPathQueryLibrary>(XPathQueryLibrary.SectionName); }
        }

        /// <summary>
        /// Returns the <see cref="ServiceBusConfigurationSettings"/> configuration section. 
        /// </summary>
        public ServiceBusConfigurationSettings ServiceBusSettings
        {
            get { return GetConfigurationSection<ServiceBusConfigurationSettings>(ServiceBusConfigurationSettings.SectionName); }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a configuration section defined by the given type <typeparamref name="T"/> and name that corresponds to the type's fully qualified name.
        /// </summary>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        /// <returns>An instance of the type <typeparamref name="T"/> containing the configuration section or a null reference if configuration section was not found.</returns>
        public T GetConfigurationSection<T>() where T : ConfigurationSection
        {
            return GetConfigurationSection<T>(typeof(T).FullName);
        }

        /// <summary>
        /// Returns a configuration section defined by the given type <typeparamref name="T"/> and specified section name.
        /// </summary>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        /// <param name="sectionName">The name of the configuration section.</param>
        /// <returns>An instance of the type <typeparamref name="T"/> containing the configuration section or a null reference if configuration section was not found.</returns>
        public T GetConfigurationSection<T>(string sectionName) where T: ConfigurationSection
        {
            ConfigurationSection configSection = null;

            if (!this.configSectionCache.TryGetValue(sectionName, out configSection))
            {
                lock (this.configSectionCacheLock)
                {
                    if (!this.configSectionCache.TryGetValue(sectionName, out configSection))
                    {
                        configSection = Source.GetSection(sectionName);
                        this.configSectionCache.Add(sectionName, configSection);
                    }
                }
            }

            return configSection as T;
        }

        /// <summary>
        /// Signals the configuration manager to unload all currently loaded configuration sections by removing them from in-memory cache.
        /// </summary>
        public void Unload()
        {
            this.reloadDatabaseConfig = true;

            lock (this.configSectionCacheLock)
            {
                this.configSectionCache.Clear();
            }
        }
        #endregion
    }
}
