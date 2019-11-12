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
namespace Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks
{
    #region Using references
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Provides factory methods for instantiating messaging runtime extension tasks.
    /// </summary>
    public static class RuntimeTaskFactory
    {
        /// <summary>
        /// Returns all available messaging runtime extension tasks.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        /// <returns>The messaging runtime extension tasks discovered by this factory component.</returns>
        public static IList<IMessagingRuntimeExtenderTask> GetRegisteredTasks(IMessagingRuntimeExtension owner)
        {
            IList<IMessagingRuntimeExtenderTask> runtimeTasks = new List<IMessagingRuntimeExtenderTask>(16);

            runtimeTasks.Add(new ExecuteRulesEnginePolicyTask(owner));
            runtimeTasks.Add(new ExternalComponentInvokeTask(owner));
            runtimeTasks.Add(new CreateResponseTask(owner));
            runtimeTasks.Add(new BeginTrackingActivityTask(owner));
            runtimeTasks.Add(new UpdateTrackingActivityTask(owner));
            runtimeTasks.Add(new CompleteTrackingActivityTask(owner));
            runtimeTasks.Add(new PromoteContextPropertyTask(owner));
            runtimeTasks.Add(new BlockMessageTask(owner));

            return runtimeTasks;
        }
    }
}
