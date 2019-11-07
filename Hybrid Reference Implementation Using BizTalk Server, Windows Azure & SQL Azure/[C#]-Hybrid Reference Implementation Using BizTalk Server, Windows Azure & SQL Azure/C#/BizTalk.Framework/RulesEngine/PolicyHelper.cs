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
namespace Contoso.Cloud.Integration.BizTalk.Core.RulesEngine
{
    #region Using references
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.RuleEngine;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Provides a set of helper methods facilitating the interactions with the Business Rules engine.
    /// </summary>
    public static class PolicyHelper
    {
        /// <summary>
        /// Verifies if the specified Business Rules policy is deployed regardless of its version.
        /// </summary>
        /// <param name="policyName">The name of the Business Rules policy to be verified.</param>
        /// <returns>True if the specified policy is deployed, otherwise False. Returns False in the event of any exceptions occurring when checking for deployed policies.</returns>
        public static bool IsDeployed(string policyName)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");

            var callToken = TraceManager.RulesComponent.TraceIn(policyName);
            bool deployed = false;
            
            try
            {
                using (Policy policy = new Policy(policyName))
                {
                    deployed = true;
                }
            }
            catch (Exception ex)
            {
                TraceManager.RulesComponent.TraceError(ex);
                deployed = false;
            }

            TraceManager.RulesComponent.TraceOut(callToken, deployed);
            return deployed;
        }

        /// <summary>
        /// Verifies if the specified Business Rules policy is deployed and its version number matches the specified version.
        /// </summary>
        /// <param name="policyName">The name of the Business Rules policy to be verified.</param>
        /// <param name="version">The version number to be verified.</param>
        /// <returns>True if the specified policy is deployed, otherwise False. Returns False in the event of any exceptions occurring when checking for deployed policies.</returns>
        public static bool IsDeployed(string policyName, Version version)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");
            Guard.ArgumentNotNull(version, "version");

            var callToken = TraceManager.RulesComponent.TraceIn(policyName, version);
            bool deployed = false;

            try
            {
                using (Policy policy = new Policy(policyName, version.Major, version.Minor))
                {
                    deployed = true;
                }
            }
            catch (Exception ex)
            {
                TraceManager.RulesComponent.TraceError(ex);
                deployed = false;
            }

            TraceManager.RulesComponent.TraceOut(callToken, deployed);
            return deployed;
        }

        /// <summary>
        /// Returns the actual version number of the deployed Business Rules policy.
        /// </summary>
        /// <param name="policyName">The name of the Business Rules policy.</param>
        /// <returns>The version number that corresponds to the deployed Business Rules policy.</returns>
        public static Version GetVersion(string policyName)
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");
            
            var callToken = TraceManager.RulesComponent.TraceIn(policyName);
            Version version = null;

            try
            {
                using (Policy policy = new Policy(policyName))
                {
                    version = new Version(policy.MajorRevision, policy.MinorRevision);
                }
            }
            catch (Exception ex)
            {
                TraceManager.RulesComponent.TraceError(ex);
                version = new Version(0, 0);
            }

            TraceManager.RulesComponent.TraceOut(callToken, version);
            return version;
        }

        /// <summary>
        /// Invokes a Business Rules policy specified in the supplied <see cref="PolicyExecutionInfo"/> object using the collection of specified facts.
        /// </summary>
        /// <param name="policyExecInfo">The <see cref="PolicyExecutionInfo"/> object containing policy name, version number and parameters to be used when invoking the policy.</param>
        /// <param name="facts">The collection of facts to be used when invoking the policy.</param>
        /// <returns>The <see cref="PolicyExecutionResult"/> object containing the results of policy execution.</returns>
        public static PolicyExecutionResult Execute(PolicyExecutionInfo policyExecInfo, IEnumerable facts)
        {
            Guard.ArgumentNotNull(facts, "facts");
            return Execute(policyExecInfo, facts.Cast<object>().ToArray<object>());
        }

        /// <summary>
        /// Invokes a Business Rules policy specified in the supplied <see cref="PolicyExecutionInfo"/> object using the list of zero or more facts.
        /// </summary>
        /// <param name="policyExecInfo">The <see cref="PolicyExecutionInfo"/> object containing policy name, version number and parameters to be used when invoking the policy.</param>
        /// <param name="facts">The list of facts to be used when invoking the policy.</param>
        /// <returns>The <see cref="PolicyExecutionResult"/> object containing the results of policy execution.</returns>
        public static PolicyExecutionResult Execute(PolicyExecutionInfo policyExecInfo, params object[] facts)
        {
            Guard.ArgumentNotNull(policyExecInfo, "policyExecInfo");
            Guard.ArgumentNotNullOrEmptyString(policyExecInfo.PolicyName, "policyExecInfo.PolicyName");

            var callToken = TraceManager.RulesComponent.TraceIn(policyExecInfo.PolicyName, policyExecInfo.PolicyVersion);

            Version policyVersion = policyExecInfo.PolicyVersion;
            PolicyExecutionResult execResult = new PolicyExecutionResult(policyExecInfo.PolicyName, false);

            PolicyFetchErrorHandler errorHandler = delegate(Exception ex)
            {
                TraceManager.RulesComponent.TraceError(ex);
                execResult.Errors.Add(ex); 
            };

            try
            {
                using (Policy policy = policyVersion != null ? new Policy(policyExecInfo.PolicyName, policyVersion.Major, policyVersion.Minor, errorHandler) : new Policy(policyExecInfo.PolicyName, errorHandler))
                {
                    List<object> agendaFacts = new List<object>(facts);
                    agendaFacts.Add(policyExecInfo);

                    using (TracingRuleTrackingInterceptor trackingInterceptor = new TracingRuleTrackingInterceptor())
                    {
                        // Write the Start event to measure how long it takes to execute the BRE policy.
                        var scopeStarted = TraceManager.RulesComponent.TraceStartScope(String.Format("{0} (\"{1}\", {2}.{3})", InstrumentedScopes.ExecutePolicy, policy.PolicyName, policy.MajorRevision, policy.MinorRevision));

                        policy.Execute(agendaFacts.ToArray(), trackingInterceptor);

                        // Once finished, write the End event along with calculated duration.
                        TraceManager.RulesComponent.TraceEndScope(String.Format("{0} (\"{1}\", {2}.{3})", InstrumentedScopes.ExecutePolicy, policy.PolicyName, policy.MajorRevision, policy.MinorRevision), scopeStarted);
                    }

                    execResult = new PolicyExecutionResult(policyExecInfo.PolicyName, policy.MajorRevision, policy.MinorRevision);
                }
            }
            catch (Exception ex)
            {
                TraceManager.RulesComponent.TraceError(ex);
                execResult.Errors.Add(ex);
            }

            TraceManager.RulesComponent.TraceOut(callToken, execResult.PolicyName, execResult.PolicyVersion, execResult.Success);
            return execResult;
        }
    }
}
