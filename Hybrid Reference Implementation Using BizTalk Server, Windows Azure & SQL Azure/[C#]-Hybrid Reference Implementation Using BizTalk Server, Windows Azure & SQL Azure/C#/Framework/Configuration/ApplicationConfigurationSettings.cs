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
    using System.IO;
    using System.Xml;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Provides a generic configuration section for storing application settings represented by a name/value pair.
    /// </summary>
    [Serializable]
    public class ApplicationConfigurationSettings : SerializableConfigurationSection
    {
        #region Private members
        private readonly object syncRoot = new object();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationConfigurationSettings"/> object with default settings.
        /// </summary>
        public ApplicationConfigurationSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationConfigurationSettings"/> object using the specified default settings.
        /// </summary>
        /// <param name="baseSettings">The custom default settings.</param>
        public ApplicationConfigurationSettings(ApplicationConfigurationSettings baseSettings) : base()
        {
            DeserializeSection(baseSettings);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Return the collection of name/value pairs containing the application settings.
        /// </summary>
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(KeyValueConfigurationElement))]
        public KeyValueConfigurationCollection Settings
        {
            get
            {
                return (KeyValueConfigurationCollection)base[String.Empty];
            }
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a setting value from the application configuration settings by its key name.
        /// </summary>
        /// <param name="key">The value containing the setting's key name.</param>
        /// <returns>The setting's value or a null reference if the specified key was not found.</returns>
        public string GetSetting(string key)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            KeyValueConfigurationElement value = Settings[GetNormalizedKey(key)];
            return value != null ? value.Value : null;
        }

        /// <summary>
        /// Returns a setting value from the application configuration settings by its key name casting the return value to the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the configuration setting.</typeparam>
        /// <param name="key">The value containing the setting's key name.</param>
        /// <returns>The setting's value or a default value for <typeparamref name="T"/> if the specified key was not found.</returns>
        public T GetSetting<T>(string key)
        {
            return GetSetting<T>(key, default(T));
        }

        /// <summary>
        /// Returns a setting value from the application configuration settings by its key name casting the return value to the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the configuration setting.</typeparam>
        /// <param name="key">The value containing the setting's key name.</param>
        /// <param name="defaultValue">The default value to be used when configuration setting's value is null or the setting was not found.</param>
        /// <returns>The setting's value or the specified default value if the specified key was not found.</returns>
        public T GetSetting<T>(string key, T defaultValue)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            KeyValueConfigurationElement value = Settings[GetNormalizedKey(key)];
            return value != null ? FrameworkUtility.ConvertTo<T>(value.Value) : defaultValue;
        }

        /// <summary>
        /// Updates the specified setting with a new value.
        /// </summary>
        /// <param name="key">The value containing the setting's key name.</param>
        /// <param name="value">The new value to be assigned to the specified key.</param>
        public void ChangeSetting(string key, string value)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            string plainKey = GetNormalizedKey(key);
            KeyValueConfigurationElement element = Settings[plainKey];

            if (null == element)
            {
                lock (this.syncRoot)
                {
                    if (null == (element = Settings[plainKey]))
                    {
                        Settings.Add(plainKey, value);
                        return;
                    }
                }
            }

            element.Value = value;
        }
        #endregion

        #region Private methods
        private void DeserializeSection(ApplicationConfigurationSettings source)
        {
            using (MemoryStream memoryBuffer = new MemoryStream())
            {
                XmlWriterSettings writerRettings = new XmlWriterSettings();

                writerRettings.CloseOutput = false;
                writerRettings.CheckCharacters = false;
                writerRettings.ConformanceLevel = ConformanceLevel.Fragment;
                writerRettings.NamespaceHandling = NamespaceHandling.OmitDuplicates;

                using (XmlWriter writer = XmlWriter.Create(memoryBuffer, writerRettings))
                {
                    source.WriteXml(writer);
                    writer.Flush();
                }

                memoryBuffer.Seek(0, SeekOrigin.Begin);

                XmlDocument configXml = FrameworkUtility.CreateXmlDocument(memoryBuffer);
                XmlReaderSettings readerSettings = new XmlReaderSettings();

                readerSettings.CloseInput = false;
                readerSettings.IgnoreWhitespace = true;
                readerSettings.IgnoreComments = true;
                readerSettings.ValidationType = ValidationType.None;
                readerSettings.IgnoreProcessingInstructions = true;

                using (XmlReader reader = XmlReader.Create(new StringReader(configXml.OuterXml), readerSettings))
                {
                    this.ReadXml(reader);
                }
                this.PostDeserialize();
            }
        }

        private string GetNormalizedKey(string rawKey)
        {
            if (!String.IsNullOrEmpty(rawKey))
            {
                return rawKey.Replace(" ", String.Empty).ToLowerInvariant();
            }
            else
            {
                return rawKey;
            }
        }
        #endregion
    }
}