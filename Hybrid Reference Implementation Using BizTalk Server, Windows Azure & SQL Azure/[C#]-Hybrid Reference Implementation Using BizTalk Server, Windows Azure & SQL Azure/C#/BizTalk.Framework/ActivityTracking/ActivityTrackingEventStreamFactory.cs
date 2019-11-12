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
namespace Contoso.Cloud.Integration.BizTalk.Core.ActivityTracking
{
    #region Using references
    using System;

    using Microsoft.BizTalk.Bam.EventObservation;
    using Microsoft.BizTalk.Component.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    #endregion

    /// <summary>
    /// Provides a set of factory methods responsible for instantiating custom event tracking streams for different usage scenarios.
    /// </summary>
    public static class ActivityTrackingEventStreamFactory
    {
        #region Private members
        private const int DefaultFlushThreshold = 1;
        #endregion

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given messaging event stream taken from the specified pipeline context.
        /// </summary>
        /// <param name="pContext">A reference to <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object that contains a references to the messaging event stream.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(IPipelineContext pContext)
        {
            Guard.ArgumentNotNull(pContext, "pContext");

            return new ActivityTrackingEventStream(pContext.GetEventStream());
        }

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given BAM Primary Import database represented by the specified connection string.
        /// Uses the default flush threshold when performing event tracking.
        /// </summary>
        /// <param name="dbConnection">The BAM Primary Import database connection string.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(string dbConnection)
        {
            return CreateEventStream(dbConnection, false);
        }

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given BAM Primary Import database represented by the specified connection string.
        /// Uses a custom flush threshold when performing event tracking. This can be one of the following values: 
        /// Greater than one - Flush each time this number of events occurs.
        /// One (1) - Flush immediately for every event.
        /// Less than or equal to zero  - Never flush automatically. You need to call the Flush method explicitly to flush the events.
        /// </summary>
        /// <param name="dbConnection">The BAM Primary Import database connection string.</param>
        /// <param name="flushThreshold">The value that determines under what conditions the buffered data will be sent to the tracking database.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(string dbConnection, int flushThreshold)
        {
            return CreateEventStream(dbConnection, false, flushThreshold);
        }

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given BAM Primary Import database represented by the specified connection string.
        /// Uses the default flush threshold when performing event tracking.
        /// </summary>
        /// <param name="dbConnection">The BAM Primary Import database connection string.</param>
        /// <param name="enableRetry">A flag indicating whether or not failed tracking attempts will be automatically retried.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(string dbConnection, bool enableRetry)
        {
            return CreateEventStream(dbConnection, false, false);
        }

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given BAM Primary Import database represented by the specified connection string.
        /// Uses a custom flush threshold when performing event tracking. This can be one of the following values: 
        /// Greater than one - Flush each time this number of events occurs.
        /// One (1) - Flush immediately for every event.
        /// Less than or equal to zero  - Never flush automatically. You need to call the Flush method explicitly to flush the events.  
        /// </summary>
        /// <param name="dbConnection">The BAM Primary Import database connection string.</param>
        /// <param name="enableRetry">A flag indicating whether or not failed tracking attempts will be automatically retried.</param>
        /// <param name="flushThreshold">The value that determines under what conditions the buffered data will be sent to the tracking database.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(string dbConnection, bool enableRetry, int flushThreshold)
        {
            return CreateEventStream(dbConnection, enableRetry, false, flushThreshold);
        }

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given BAM Primary Import database represented by the specified connection string.
        /// Uses the default flush threshold when performing event tracking.
        /// </summary>
        /// <param name="dbConnection">The BAM Primary Import database connection string.</param>
        /// <param name="enableRetry">A flag indicating whether or not failed tracking attempts will be automatically retried.</param>
        /// <param name="direct">A flag indicating whether or not event data will be sent directly to the Primary Import database.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(string dbConnection, bool enableRetry, bool direct)
        {
            return CreateEventStream(dbConnection, enableRetry, direct, DefaultFlushThreshold);
        }

        /// <summary>
        /// Returns an instance of the <see cref="IActivityTrackingEventStream"/> object instantiated for a given BAM Primary Import database represented by the specified connection string.
        /// Uses a custom flush threshold when performing event tracking. This can be one of the following values: 
        /// Greater than one - Flush each time this number of events occurs.
        /// One (1) - Flush immediately for every event.
        /// Less than or equal to zero  - Never flush automatically. You need to call the Flush method explicitly to flush the events.  
        /// </summary>
        /// <param name="dbConnection">The BAM Primary Import database connection string.</param>
        /// <param name="enableRetry">A flag indicating whether or not failed tracking attempts will be automatically retried.</param>
        /// <param name="direct">A flag indicating whether or not event data will be sent directly to the Primary Import database.</param>
        /// <param name="flushThreshold">The value that determines under what conditions the buffered data will be sent to the tracking database.</param>
        /// <returns>The <see cref="IActivityTrackingEventStream"/> object instance.</returns>
        public static IActivityTrackingEventStream CreateEventStream(string dbConnection, bool enableRetry, bool direct, int flushThreshold)
        {
            Guard.ArgumentNotNullOrEmptyString(dbConnection, "dbConnection");

            EventStream eventStream = null;

            if (direct)
            {
                // Enables the BAM event data to be sent directly to the Primary Import database using the specified connection string. 
                eventStream = new DirectEventStream(dbConnection, flushThreshold);
            }
            else
            {
                // Enables the BAM event data to be buffered in memory before writing out to the Primary Import database. 
                eventStream = new BufferedEventStream(dbConnection, flushThreshold);
            }

            return new ActivityTrackingEventStream(eventStream);
        }
    }
}
