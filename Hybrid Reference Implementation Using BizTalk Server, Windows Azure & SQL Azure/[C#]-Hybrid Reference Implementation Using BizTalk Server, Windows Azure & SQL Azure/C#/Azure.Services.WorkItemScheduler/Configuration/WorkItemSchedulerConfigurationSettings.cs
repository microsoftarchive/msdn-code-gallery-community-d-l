//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The WorkItemScheduler worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Configuration
{
    #region Using references
    using System;

    using Contoso.Cloud.Integration.Framework.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration section which provides access to the configuration settings used by the Work Item Scheduler service.
    /// </summary>
    [Serializable]
    public class WorkItemSchedulerConfigurationSettings : ApplicationConfigurationSettings
    {
        #region Private members
        /// <summary>
        /// The names of application-specific configuration properties.
        /// </summary>
        private const string HandlingPolicyNameProperty = "Handling Policy Name";
        private const string XmlBatchSizeProperty = "XML Batch Size";
        private const string CloudStorageAccountProperty = "Cloud Storage Account";
        private const string DestinationQueueProperty = "Destination Queue";
        #endregion

        #region Public members
        /// <summary>
        /// The name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "WorkItemSchedulerConfiguration";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemSchedulerConfigurationSettings"/> object with default settings.
        /// </summary>
        public WorkItemSchedulerConfigurationSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemSchedulerConfigurationSettings"/> object using the specified default settings.
        /// </summary>
        /// <param name="baseSettings">The custom default settings.</param>
        public WorkItemSchedulerConfigurationSettings(ApplicationConfigurationSettings baseSettings) : base(baseSettings)
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the business rules policy being used for performing work item scheduling.
        /// </summary>
        public string HandlingPolicyName
        {
            get { return GetSetting(HandlingPolicyNameProperty); }
            set { ChangeSetting(HandlingPolicyNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the Windows Azure storage account which hosts the working queues.
        /// </summary>
        public string CloudStorageAccount
        {
            get { return GetSetting(CloudStorageAccountProperty); }
            set { ChangeSetting(CloudStorageAccountProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the Windows Azure queue to which scheduled work items will be enqueued.
        /// </summary>
        public string DestinationQueue
        {
            get { return GetSetting(DestinationQueueProperty); }
            set { ChangeSetting(DestinationQueueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the working batch size defining the number of products that will be included into a single work item.
        /// </summary>
        public int XmlBatchSize
        {
            get { return GetSetting<int>(XmlBatchSizeProperty); }
            set { ChangeSetting(XmlBatchSizeProperty, Convert.ToString(value)); }
        } 
        #endregion
    }
}
