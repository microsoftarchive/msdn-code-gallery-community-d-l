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
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Configuration
{
    #region Using references
    using System;

    using Contoso.Cloud.Integration.Framework.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration section which provides access to the configuration settings used by the Work Item Processor service.
    /// </summary>
    [Serializable]
    public class WorkItemProcessorConfigurationSettings : ApplicationConfigurationSettings
    {
        #region Private members
        private const int DefaultDequeueBatchSize = 20;
        private const double DefaultMinimumIdleIntervalMs = 1000;
        private const double DefaultMaximumIdleIntervalMs = 1000 * 60;

        /// <summary>
        /// The names of application-specific configuration properties.
        /// </summary>
        private const string CloudStorageAccountProperty = "Cloud Storage Account";
        private const string WorkItemQueueProperty = "Work Item Queue";
        private const string OutputQueueProperty = "Output Item Queue";
        private const string WorkItemQueueVisibilityTimeoutProperty = "Work Item Queue Visibility Timeout";
        private const string OutputQueueVisibilityTimeoutProperty = "Output Queue Visibility Timeout";
        private const string TargetDatabaseProperty = "Target Database";
        private const string HandlingPolicyNameProperty = "Handling Policy Name";
        private const string DequeueBatchSizeProperty = "Dequeue Batch Size";
        private const string MinimumIdleIntervalProperty = "Minimum Idle Interval";
        private const string MaximumIdleIntervalProperty = "Maximum Idle Interval";
        #endregion

        #region Public members
        /// <summary>
        /// The name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "WorkItemProcessorConfiguration";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemProcessorConfigurationSettings"/> object with default settings.
        /// </summary>
        public WorkItemProcessorConfigurationSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemProcessorConfigurationSettings"/> object using the specified default settings.
        /// </summary>
        /// <param name="baseSettings">The custom default settings.</param>
        public WorkItemProcessorConfigurationSettings(ApplicationConfigurationSettings baseSettings)
            : base(baseSettings)
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the Windows Azure storage account which hosts the working queues.
        /// </summary>
        public string CloudStorageAccount
        {
            get { return GetSetting(CloudStorageAccountProperty); }
            set { ChangeSetting(CloudStorageAccountProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the Windows Azure queue from which work items awaiting processing will be dequeued.
        /// </summary>
        public string WorkItemQueue
        {
            get { return GetSetting(WorkItemQueueProperty); }
            set { ChangeSetting(WorkItemQueueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the Windows Azure queue to which processing results will be enqueued.
        /// </summary>
        public string OutputQueue
        {
            get { return GetSetting(OutputQueueProperty); }
            set { ChangeSetting(OutputQueueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the queue item visibility timeout for the input queue.
        /// </summary>
        public TimeSpan WorkItemQueueVisibilityTimeout
        {
            get { return GetSetting<TimeSpan>(WorkItemQueueVisibilityTimeoutProperty); }
            set { ChangeSetting(WorkItemQueueVisibilityTimeoutProperty, Convert.ToString(value)); }
        }

        /// <summary>
        /// Gets or sets the queue item visibility timeout for the output queue.
        /// </summary>
        public TimeSpan OutputQueueVisibilityTimeout
        {
            get { return GetSetting<TimeSpan>(OutputQueueVisibilityTimeoutProperty); }
            set { ChangeSetting(OutputQueueVisibilityTimeoutProperty, Convert.ToString(value)); }
        }

        /// <summary>
        /// Gets or sets the name of the connection string definition for the Inventory database.
        /// </summary>
        public string InventoryDatabase
        {
            get { return GetSetting(TargetDatabaseProperty); }
            set { ChangeSetting(TargetDatabaseProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the business rules policy being used for performing work item processing.
        /// </summary>
        public string HandlingPolicyName
        {
            get { return GetSetting(HandlingPolicyNameProperty); }
            set { ChangeSetting(HandlingPolicyNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the queue item batch size when communicating with Windows Azure queue storage service.
        /// </summary>
        public int DequeueBatchSize
        {
            get { return GetSetting<int>(DequeueBatchSizeProperty, DefaultDequeueBatchSize); }
            set { ChangeSetting(DequeueBatchSizeProperty, Convert.ToString(value)); }
        }

        /// <summary>
        /// Gets or sets the time interval defining the minimum delay when polling an empty queue.
        /// </summary>
        public TimeSpan MinimumIdleInterval
        {
            get { return GetSetting<TimeSpan>(MinimumIdleIntervalProperty, TimeSpan.FromMilliseconds(DefaultMinimumIdleIntervalMs)); }
            set { ChangeSetting(MinimumIdleIntervalProperty, Convert.ToString(value)); }
        }

        /// <summary>
        /// Gets or sets the time interval defining the maximum delay when polling an empty queue.
        /// </summary>
        public TimeSpan MaximumIdleInterval
        {
            get { return GetSetting<TimeSpan>(MaximumIdleIntervalProperty, TimeSpan.FromMilliseconds(DefaultMaximumIdleIntervalMs)); }
            set { ChangeSetting(MaximumIdleIntervalProperty, Convert.ToString(value)); }
        }
        #endregion
    }
}
