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
    using System.Globalization;

    using Microsoft.RuleEngine;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a custom tracking interceptor which enables reporting the significant events during rules execution via the ETW trace log.
    /// </summary>
    public sealed class TracingRuleTrackingInterceptor : IRuleSetTrackingInterceptor, IDisposable
    {
        #region Private members
        // Preload all string resource for better performance.
        private static string traceHeaderTrace = TraceLogMessages.Header;
        private static string ruleEngineInstanceTrace = TraceLogMessages.RuleEngineInstance;
        private static string rulesetNameTrace = TraceLogMessages.RulesetName;
        private static string ruleFiredTrace = TraceLogMessages.RuleFired;
        private static string ruleNameTrace = TraceLogMessages.RuleName;
        private static string conflictResolutionCriteriaTrace = TraceLogMessages.ConflictResolutionCriteria;
        private static string workingMemoryUpdateTrace = TraceLogMessages.WorkingMemoryUpdate;
        private static string operationTypeTrace = TraceLogMessages.OperationType;
        private static string assertOperationTrace = TraceLogMessages.AssertOperation;
        private static string retractOperationTrace = TraceLogMessages.RetractOperation;
        private static string updateOperationTrace = TraceLogMessages.UpdateOperation;
        private static string assertUnrecognizedOperationTrace = TraceLogMessages.AssertUnrecognizedOperation;
        private static string retractUnrecognizedOperationTrace = TraceLogMessages.RetractUnrecognizedOperation;
        private static string updateUnrecognizedOperationTrace = TraceLogMessages.UpdateUnrecognizedOperation;
        private static string retractNotPresentOperationTrace = TraceLogMessages.RetractNotPresentOperation;
        private static string updateNotPresentOperationTrace = TraceLogMessages.UpdateNotPresentOperation;
        private static string unrecognizedOperationTrace = TraceLogMessages.UnrecognizedOperation;
        private static string objectTypeTrace = TraceLogMessages.ObjectType;
        private static string objectInstanceTrace = TraceLogMessages.ObjectInstance;
        private static string conditionEvaluationTrace = TraceLogMessages.ConditionEvaluation;
        private static string testExpressionTrace = TraceLogMessages.TestExpression;
        private static string leftOperandValueTrace = TraceLogMessages.LeftOperandValue;
        private static string rightOperandValueTrace = TraceLogMessages.RightOperandValue;
        private static string testResultTrace = TraceLogMessages.TestResult;
        private static string agendaUpdateTrace = TraceLogMessages.AgendaUpdate;
        private static string addOperationTrace = TraceLogMessages.AddOperation;
        private static string removeOperationTrace = TraceLogMessages.RemoveOperation;

        private const string TraceTemplateOneParam = "RULE TRACE: {0} null";
        private const string TraceTemplateTwoParam = "RULE TRACE: {0} {1}";
        private const string TraceTemplateThreeParam = "RULE TRACE: {0} {1} {2}";
        private const string TraceTemplateObjTypeEval = "RULE TRACE: {0} {1} {2} ({3})";
        private const string TraceTemplateValueTypeEval = "RULE TRACE: {0} {1} ({2})";

        private TrackingConfiguration trackingConfig;
        private string ruleSetName;
        private string ruleEngineGuid;
        #endregion

        #region IRuleSetTrackingInterceptor members
        /// <summary>
        /// Sets the rule set tracking GUID and tracking configuration.
        /// </summary>
        /// <param name="trackingConfig">The tracking configuration.</param>
        public void SetTrackingConfig(TrackingConfiguration trackingConfig)
        {
            this.trackingConfig = trackingConfig;
        }

        /// <summary>
        /// Tracks updates to the rule engine agenda.
        /// </summary>
        /// <param name="isAddition">True if a rule is added; otherwise, false.</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="conflictResolutionCriteria">The priority of rule, used to resolve rule firing order conflicts on the agenda.</param>
        public void TrackAgendaUpdate(bool isAddition, string ruleName, object conflictResolutionCriteria)
        {
            PrintHeader(agendaUpdateTrace);

            if (isAddition)
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, addOperationTrace);
            }
            else
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, removeOperationTrace);
            }

            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, ruleNameTrace, ruleName);
            
            if (conflictResolutionCriteria == null)
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateOneParam, conflictResolutionCriteriaTrace);
            }
            else
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, conflictResolutionCriteriaTrace, conflictResolutionCriteria);
            }
        }

        /// <summary>
        /// Tracks the evaluation of rule conditions.
        /// </summary>
        /// <param name="testExpression">Test expression string.</param>
        /// <param name="leftClassType">Left hand argument object type.</param>
        /// <param name="leftClassInstanceId">Left hand argument object instance ID.</param>
        /// <param name="leftValue">Left hand argument value.</param>
        /// <param name="rightClassType">Right hand argument object type.</param>
        /// <param name="rightClassInstanceId">Right hand argument object instance ID.</param>
        /// <param name="rightValue">Right hand argument value.</param>
        /// <param name="result">Condition result.</param>
        public void TrackConditionEvaluation(string testExpression, string leftClassType, int leftClassInstanceId, object leftValue, string rightClassType, int rightClassInstanceId, object rightValue, bool result)
        {
            PrintHeader(conditionEvaluationTrace);

            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, testExpressionTrace, testExpression);

            if (leftValue == null)
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateOneParam, leftOperandValueTrace);
            }
            else
            {
                Type leftValueType = leftValue.GetType();

                if (leftValueType.IsClass && (Type.GetTypeCode(leftValueType) != TypeCode.String))
                {
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateObjTypeEval, leftOperandValueTrace, objectInstanceTrace, leftValue.GetHashCode().ToString(CultureInfo.CurrentCulture), leftValueType.FullName);
                }
                else
                {
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateValueTypeEval, leftOperandValueTrace, leftValue, leftValueType.FullName);
                }
            }

            if (rightValue == null)
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateOneParam, rightOperandValueTrace);
            }
            else
            {
                Type rightValueType = rightValue.GetType();

                if (rightValueType.IsClass && (Type.GetTypeCode(rightValueType) != TypeCode.String))
                {
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateObjTypeEval, rightOperandValueTrace, objectInstanceTrace, rightValue.GetHashCode().ToString(CultureInfo.CurrentCulture), rightValueType.FullName);
                }
                else
                {
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateValueTypeEval, rightOperandValueTrace, rightValue, rightValueType.FullName);
                }
            }

            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, testResultTrace, result);
        }

        /// <summary>
        /// Tracks changes to working memory.
        /// </summary>
        /// <param name="activityType">Describes if the activity is to assert, retract, or update.</param>
        /// <param name="classType">Type of facts.</param>
        /// <param name="classInstanceId">Unique fact identifier.</param>
        public void TrackFactActivity(FactActivityType activityType, string classType, int classInstanceId)
        {
            PrintHeader(workingMemoryUpdateTrace);

            switch (activityType)
            {
                case FactActivityType.Assert:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, assertOperationTrace);
                    break;

                case FactActivityType.Retract:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, retractOperationTrace);
                    break;

                case FactActivityType.Update:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, updateOperationTrace);
                    break;

                case FactActivityType.AssertUnrecognized:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, assertUnrecognizedOperationTrace);
                    break;

                case FactActivityType.RetractUnrecognized:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, retractUnrecognizedOperationTrace);
                    break;

                case FactActivityType.UpdateUnrecognized:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, updateUnrecognizedOperationTrace);
                    break;

                case FactActivityType.RetractNotPresent:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, retractNotPresentOperationTrace);
                    break;

                case FactActivityType.UpdateNotPresent:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, updateNotPresentOperationTrace);
                    break;

                default:
                    TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, operationTypeTrace, unrecognizedOperationTrace);
                    break;
            }

            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, objectTypeTrace, classType);
            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, objectInstanceTrace, classInstanceId.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Tracks the firing of a rule.
        /// </summary>
        /// <param name="ruleName">The name of the rule.</param>
        /// <param name="conflictResolutionCriteria">The priority of rule, used to resolve rule firing order conflicts on the agenda.</param>
        public void TrackRuleFiring(string ruleName, object conflictResolutionCriteria)
        {
            PrintHeader(ruleFiredTrace);

            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, ruleNameTrace, ruleName);

            if (conflictResolutionCriteria == null)
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateOneParam, conflictResolutionCriteriaTrace);
            }
            else
            {
                TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, conflictResolutionCriteriaTrace, conflictResolutionCriteria);
            }

        }

        /// <summary>
        /// Tracks the association of a rule set with a rule engine instance.
        /// </summary>
        /// <param name="ruleSetInfo">Rule set information.</param>
        /// <param name="ruleEngineGuid">Rule engine instance identifier.</param>
        public void TrackRuleSetEngineAssociation(RuleSetInfo ruleSetInfo, Guid ruleEngineGuid)
        {
            this.ruleSetName = ruleSetInfo.Name;
            this.ruleEngineGuid = ruleEngineGuid.ToString();

            TraceManager.RulesComponent.TraceInfo(TraceTemplateThreeParam, traceHeaderTrace, this.ruleSetName, DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }
        #endregion

        #region IDisposable members
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // We don't really need to dispose anything in this implementation.
        }
        #endregion

        #region Private members
        private void PrintHeader(string hdr)
        {
            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, hdr, DateTime.Now.ToString(CultureInfo.CurrentCulture));
            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, ruleEngineInstanceTrace, this.ruleEngineGuid);
            TraceManager.RulesComponent.TraceInfo(TraceTemplateTwoParam, rulesetNameTrace, this.ruleSetName);
        }
        #endregion
    }
}
