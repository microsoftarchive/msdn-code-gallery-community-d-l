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
    using System.Resources;
    using System.Diagnostics;

    using InternalResources = Contoso.Cloud.Integration.BizTalk.Core.Properties.PipelineComponentResources;
    #endregion

    internal class ResourceManagerWrapper : ResourceManager
    {
        private ResourceManager masterResourceManager;

        public ResourceManagerWrapper(ResourceManager master)
            : base(typeof(InternalResources))
        {
            this.masterResourceManager = master;
        }

        public override string BaseName
        {
            get
            {
                return this.masterResourceManager.BaseName;
            }
        }

        public override object GetObject(string name, System.Globalization.CultureInfo culture)
        {
            return this.masterResourceManager.GetObject(name, culture);
        }

        public override string GetString(string name, System.Globalization.CultureInfo culture)
        {
            if (!String.IsNullOrEmpty(name))
            {
                if (String.Compare(name, GlobalComponentPropertyName.EnableDetailedExceptionsProp, false) == 0)
                {
                    return InternalResources.PropEnableDetailedExceptions;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnableDetailedExceptionsDesc, false) == 0)
                {
                    return InternalResources.DescEnableDetailedExceptions;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnablePerformanceCountersProp, false) == 0)
                {
                    return InternalResources.PropEnablePerformanceCounters;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnablePerformanceCountersDesc, false) == 0)
                {
                    return InternalResources.DescEnablePerformanceCounters;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnableInstrumentationProp, false) == 0)
                {
                    return InternalResources.PropEnableInstrumentation;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnableInstrumentationDesc, false) == 0)
                {
                    return InternalResources.DescEnableInstrumentation;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnableActivityTrackingProp, false) == 0)
                {
                    return InternalResources.PropEnableActivityTracking;
                }

                if (String.Compare(name, GlobalComponentPropertyName.EnableActivityTrackingDesc, false) == 0)
                {
                    return InternalResources.DescEnableActivityTracking;
                }

                if (String.Compare(name, GlobalComponentPropertyName.SharedPipelineComponentPropsCategory, false) == 0)
                {
                    return InternalResources.SharedPipelineComponentPropsCategory;
                }
            }
            return this.masterResourceManager.GetString(name, culture);
        }
    }
}
