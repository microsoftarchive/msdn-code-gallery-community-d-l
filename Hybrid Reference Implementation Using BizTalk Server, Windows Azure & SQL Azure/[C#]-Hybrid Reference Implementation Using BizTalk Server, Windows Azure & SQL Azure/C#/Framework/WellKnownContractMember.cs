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
    #endregion

    /// <summary>
    /// Provides the well-known string values used by service and data contract artifacts.
    /// </summary>
    public struct WellKnownContractMember
    {
        /// <summary>
        /// Returns the standard suffix used in the XML element names representing a response message from a service method.
        /// </summary>
        public const string ResponseMethodSuffix = "Response";

        /// <summary>
        /// Returns the standard suffix used in the XML element names representing a message with the result from a service method.
        /// </summary>
        public const string ResultMethodSuffix = "Result";

        /// <summary>
        /// Provides a reusable set of method parameter names.
        /// </summary>
        public struct MessageParameters
        {
            /// <summary>
            /// Returns the standard name of the TraceEvents parameter.
            /// </summary>
            public const string TraceEvents = "TraceEvents";

            /// <summary>
            /// Returns the standard name of the SectionName parameter.
            /// </summary>
            public const string SectionName = "SectionName";

            /// <summary>
            /// Returns the standard name of the ApplicationName parameter.
            /// </summary>
            public const string ApplicationName = "ApplicationName";

            /// <summary>
            /// Returns the standard name of the MachineName parameter.
            /// </summary>
            public const string MachineName = "MachineName";

            /// <summary>
            /// Returns the standard name of the PolicyName parameter.
            /// </summary>
            public const string PolicyName = "PolicyName";

            /// <summary>
            /// Returns the standard name of the InputParameters parameter.
            /// </summary>
            public const string InputParameters = "InputParameters";

            /// <summary>
            /// Returns the standard name of the TransformName parameter.
            /// </summary>
            public const string TransformName = "TransformName";

            /// <summary>
            /// Returns the standard name of the Activity parameter.
            /// </summary>
            public const string Activity = "Activity";

            /// <summary>
            /// Returns the standard name of the Request parameter.
            /// </summary>
            public const string Request = "Request";
        }

        /// <summary>
        /// Provides a reusable set of method names.
        /// </summary>
        public struct MethodNames
        {
            /// <summary>
            /// Returns the standard name of the GetConfigurationSection method.
            /// </summary>
            public const string GetConfigurationSection = "GetConfigurationSection";

            /// <summary>
            /// Returns the standard name of the SerializeSection method.
            /// </summary>
            public const string SerializeSection = "SerializeSection";

            /// <summary>
            /// Returns the standard name of the DeserializeSection method.
            /// </summary>
            public const string DeserializeSection = "DeserializeSection";

            /// <summary>
            /// Returns the standard name of the ExecutePolicy method.
            /// </summary>
            public const string ExecutePolicy = "ExecutePolicy";

            /// <summary>
            /// Returns the standard name of the GetXslTransformMetadata method.
            /// </summary>
            public const string GetXslTransformMetadata = "GetXslTransformMetadata";

            /// <summary>
            /// Returns the standard name of the BeginActivity method.
            /// </summary>
            public const string BeginActivity = "BeginActivity";

            /// <summary>
            /// Returns the standard name of the UpdateActivity method.
            /// </summary>
            public const string UpdateActivity = "UpdateActivity";

            /// <summary>
            /// Returns the standard name of the CompleteActivity method.
            /// </summary>
            public const string CompleteActivity = "CompleteActivity";
        }
    }
}