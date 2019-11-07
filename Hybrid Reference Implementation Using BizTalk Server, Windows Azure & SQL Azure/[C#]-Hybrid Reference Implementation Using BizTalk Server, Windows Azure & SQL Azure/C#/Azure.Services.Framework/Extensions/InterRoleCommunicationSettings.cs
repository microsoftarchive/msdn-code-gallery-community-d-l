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
    #endregion

    /// <summary>
    /// Defines runtime settings for the <see cref="InterRoleCommunicationExtension"/> component.
    /// </summary>
    public class InterRoleCommunicationSettings
    {
        /// <summary>
        /// The server wait time before the event receive operation times out.
        /// </summary>
        public TimeSpan EventWaitTimeout { get; set; }

        /// <summary>
        /// The time-to-live (TTL) value for inter-role communication events.
        /// </summary>
        public TimeSpan EventTimeToLive { get; set; }

        /// <summary>
        /// A flag indicating whether the sender receives a copy of the inter-role communication event.
        /// </summary>
        public bool EnableCarbonCopy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterRoleCommunicationSettings"/> object using default settings.
        /// </summary>
        public InterRoleCommunicationSettings()
        {
            EventWaitTimeout = TimeSpan.FromSeconds(30);
            EventTimeToLive = TimeSpan.FromMinutes(10);
            EnableCarbonCopy = false;
        }

        /// <summary>
        /// Returns default runtime settings for the <see cref="InterRoleCommunicationExtension"/> component.
        /// </summary>
        public static InterRoleCommunicationSettings Default
        {
            get { return new InterRoleCommunicationSettings(); }
        }
    }
}
