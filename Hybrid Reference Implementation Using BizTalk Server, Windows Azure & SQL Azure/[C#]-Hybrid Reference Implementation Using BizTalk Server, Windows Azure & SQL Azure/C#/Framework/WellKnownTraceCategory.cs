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
namespace Contoso.Cloud.Integration.Framework
{
    #region Using statements
    using System;
    using System.Diagnostics;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Provides the standard names of well-known trace message categories for reusability purposes.
    /// </summary>
    public struct WellKnownTraceCategory
    {
        #region Public members
        /// <summary>
        /// Returns the standard name of the TraceInfo trace event category.
        /// </summary>
        public const string TraceInfo = "TraceInfo";

        /// <summary>
        /// Returns the standard name of the TraceDetails trace event category.
        /// </summary>
        public const string TraceDetails = "TraceDetails";

        /// <summary>
        /// Returns the standard name of the TraceWarning trace event category.
        /// </summary>
        public const string TraceWarning = "TraceWarning";

        /// <summary>
        /// Returns the standard name of the TraceError trace event category.
        /// </summary>
        public const string TraceError = "TraceError";

        /// <summary>
        /// Returns the standard name of the TraceIn trace event category.
        /// </summary>
        public const string TraceIn = "TraceIn";

        /// <summary>
        /// Returns the standard name of the TraceOut trace event category.
        /// </summary>
        public const string TraceOut = "TraceOut";

        /// <summary>
        /// Returns the standard name of the TraceStartScope trace event category.
        /// </summary>
        public const string TraceStartScope = "TraceStartScope";

        /// <summary>
        /// Returns the standard name of the TraceEndScope trace event category.
        /// </summary>
        public const string TraceEndScope = "TraceEndScope"; 
        #endregion

        #region Public members
        /// <summary>
        /// Returns the name of the trace event category which corresponds to the type of the specified trace event.
        /// </summary>
        /// <param name="eventRecord">The trace event providing the data.</param>
        /// <returns>The name of the trace event category if event type has been recognized, otherwise the name of the default trace event category.</returns>
        public static string CreateFrom(TraceEventRecord eventRecord)
        {
            Guard.ArgumentNotNull(eventRecord, "eventRecord");

            switch (eventRecord.EventType)
            {
                case TraceEventType.Information:
                    return TraceInfo;
                case TraceEventType.Verbose:
                    return TraceDetails;
                case TraceEventType.Warning:
                    return TraceWarning;
                case TraceEventType.Error:
                case TraceEventType.Critical:
                    return TraceError;
                case TraceEventType.Start:
                    return TraceStartScope;
                case TraceEventType.Stop:
                    return TraceEndScope;
                default:
                    return TraceInfo;
            }
        } 
        #endregion
    }
}
