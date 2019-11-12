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
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Collections.Generic;

    using Microsoft.BizTalk.XPath;
    using Microsoft.BizTalk.Streaming;

    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Core.ActivityTracking;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for performing generic operations with BAM tracking activities.
    /// </summary>
    public abstract class TrackingActivityTaskBase : MessagingRuntimeExtenderTaskBase
    {
        #region Private members
        private const string ContinuationTokenInternalDataItemName = "__ContinuationToken";
        private ActivityBase activity;
        private readonly IDictionary<string, string> milestoneToXPathMap = new Dictionary<string, string>();
        private readonly IDictionary<string, Type> lateBoundActivityValueMap = new Dictionary<string, Type>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackingActivityTaskBase"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public TrackingActivityTaskBase(IMessagingRuntimeExtension owner) : base(owner)
        {
        }
        #endregion

        #region Protected members
        /// <summary>
        /// Returns the instance of the BAM activity managed by this task.
        /// </summary>
        protected virtual ActivityBase CurrentActivity
        {
            get { return this.activity; }
        }
        #endregion

        #region IMessagingRuntimeExtenderTask implementation
        /// <summary>
        /// Returns a flag indicating whether or not this task is enabled for execution.
        /// </summary>
        public override bool CanRun
        {
            get { return base.CanRun && this.activity != null; }
        }

        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public override void Run(RuntimeTaskExecutionContext context)
        {
            if (this.lateBoundActivityValueMap.Count > 0)
            {
                foreach (var dateTimeMilestone in this.lateBoundActivityValueMap.Where((item) => { return item.Value == typeof(DateTime); }))
                {
                    SetActivityData(dateTimeMilestone.Key, DateTime.UtcNow);
                }
            }

            if (this.milestoneToXPathMap.Count > 0)
            {
                Stream messageDataStream = BizTalkUtility.EnsureSeekableStream(context.Message, context.PipelineContext);

                if (messageDataStream != null)
                {
                    byte[] buffer = new byte[BizTalkUtility.VirtualStreamBufferSize];
                    string[] milestones = new string[this.milestoneToXPathMap.Count];
                    int arrIndex = 0, matchFound = 0;

                    XPathCollection xc = new XPathCollection();
                    XPathQueryLibrary xPathLib = ApplicationConfiguration.Current.XPathQueries;

                    foreach (var listItem in this.milestoneToXPathMap)
                    {
                        milestones[arrIndex++] = listItem.Key;
                        xc.Add(xPathLib.GetXPathQuery(listItem.Value));
                    }

                    try
                    {
                        XPathMutatorStream mutator = new XPathMutatorStream(messageDataStream, xc,
                            delegate(int matchIdx, XPathExpression expr, string origValue, ref string finalValue)
                            {
                                if (matchIdx >= 0 && matchIdx < milestones.Length)
                                {
                                    SetActivityData(milestones[matchIdx], origValue);
                                    matchFound++;
                                }
                            });

                        while (mutator.Read(buffer, 0, buffer.Length) > 0 && matchFound < milestones.Length) ;

                        // Check we had performed continuation token value resolution via XPath.
                        object continuationToken = null;

                        if (CurrentActivity.ActivityData.TryGetValue(ContinuationTokenInternalDataItemName, out continuationToken))
                        {
                            CurrentActivity.ContinuationToken = (string)continuationToken;
                            CurrentActivity.ActivityData.Remove(ContinuationTokenInternalDataItemName);
                        }
                    }
                    finally
                    {
                        if (messageDataStream.CanSeek)
                        {
                            messageDataStream.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Creates a new BAM tracking activity with the specified name and ID.
        /// </summary>
        /// <param name="activityName">The name of the BAM activity.</param>
        /// <param name="activityId">The ID of the BAM activity.</param>
        public void SetActivityInfo(string activityName, object activityId)
        {
            SetActivityInfo(activityName, Convert.ToString(activityId));
        }

        /// <summary>
        /// Creates a new BAM tracking activity with the specified name and ID.
        /// </summary>
        /// <param name="activityName">The name of the BAM activity.</param>
        /// <param name="activityId">The ID of the BAM activity.</param>
        public void SetActivityInfo(string activityName, string activityId)
        {
            var callToken = TraceManager.CustomComponent.TraceIn(activityName, activityId);

            this.activity = new GenericNamedActivity(activityName, activityId);

            Enable();

            TraceManager.CustomComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Updates the specified BAM activity milestone with the specified value.
        /// </summary>
        /// <param name="milestoneName">The name of the BAM activity milestone.</param>
        /// <param name="data">The data to be assigned to the milestone.</param>
        public void SetActivityData(string milestoneName, object data)
        {
            var callToken = TraceManager.CustomComponent.TraceIn(milestoneName, data);

            if (CurrentActivity != null)
            {
                CurrentActivity.ActivityData.Add(milestoneName, data);
            }

            TraceManager.CustomComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Updates the specified BAM activity milestone with a value taken from the input message using the specified XPath expression.
        /// </summary>
        /// <param name="milestoneName">The name of the BAM activity milestone.</param>
        /// <param name="xPathItemRef">The XPath expression to be applied against the input message.</param>
        public void SetActivityDataXPath(string milestoneName, string xPathItemRef)
        {
            var callToken = TraceManager.CustomComponent.TraceIn(milestoneName, xPathItemRef);

            this.milestoneToXPathMap.Add(milestoneName, xPathItemRef);

            TraceManager.CustomComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Updates the specified BAM activity milestone with a date/time value.
        /// </summary>
        /// <param name="milestoneName">The name of the BAM activity milestone.</param>
        /// <param name="value">The date/time value to be assigned to the milestone.</param>
        public void UpdateDateTimeMilestone(string milestoneName, DateTime value)
        {
            SetActivityData(milestoneName, value);
        }

        /// <summary>
        /// Updates the specified BAM activity milestone with a current date/time value.
        /// </summary>
        /// <param name="milestoneName">The name of the BAM activity milestone.</param>
        public void UpdateDateTimeMilestone(string milestoneName)
        {
            this.lateBoundActivityValueMap.Add(milestoneName, typeof(DateTime));
        }

        /// <summary>
        /// Enables continuation for the current BAM tracking activity using the specified continuation token.
        /// </summary>
        /// <param name="continuationToken">The continuation token under which further activity updates will be originated.</param>
        public void EnableContinuation(string continuationToken)
        {
            var callToken = TraceManager.CustomComponent.TraceIn(continuationToken);

            if (CurrentActivity != null)
            {
                CurrentActivity.ContinuationToken = continuationToken;
            }

            TraceManager.CustomComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Enables continuation for the current BAM tracking activity using a continuation token value taken from the input message using the specified XPath expression.
        /// </summary>
        /// <param name="xPathItemRef">The XPath expression to be applied against the input message.</param>
        public void EnableContinuationWithXPath(string xPathItemRef)
        {
            SetActivityDataXPath(ContinuationTokenInternalDataItemName, xPathItemRef);
        }
        #endregion
    }
}