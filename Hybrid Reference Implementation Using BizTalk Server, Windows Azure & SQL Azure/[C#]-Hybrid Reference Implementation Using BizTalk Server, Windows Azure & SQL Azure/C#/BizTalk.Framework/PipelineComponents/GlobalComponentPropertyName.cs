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
namespace Contoso.Cloud.Integration.BizTalk.Core.PipelineComponents
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    internal struct GlobalComponentPropertyName
    {
        public const string SharedPipelineComponentPropsCategory = "SharedPipelineComponentPropsCategory";

        public const string EnableDetailedExceptionsProp = "PropEnableDetailedExceptions";
        public const string EnableDetailedExceptionsDesc = "DescEnableDetailedExceptions";

        public const string EnablePerformanceCountersProp = "PropEnablePerformanceCounters";
        public const string EnablePerformanceCountersDesc = "DescEnablePerformanceCounters";

        public const string EnableInstrumentationProp = "PropEnableInstrumentation";
        public const string EnableInstrumentationDesc = "DescEnableInstrumentation";

        public const string EnableActivityTrackingProp = "PropEnableActivityTracking";
        public const string EnableActivityTrackingDesc = "DescEnableActivityTracking";
    }
}
