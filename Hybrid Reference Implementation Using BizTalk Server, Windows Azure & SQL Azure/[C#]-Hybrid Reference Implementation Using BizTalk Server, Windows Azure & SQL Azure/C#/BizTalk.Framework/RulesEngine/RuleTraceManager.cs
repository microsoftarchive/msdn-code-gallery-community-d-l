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

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Implements a static class which is intended to be used on the Action pane inside the Business Rule Composer. 
    /// Its main purpose is to expose a set of tracing methods with a fixed parameter list. Internally, the RuleTraceManager 
    /// is simply relaying all calls to TraceManager.RulesComponent. A requirement for a separate class has arisen from the fact 
    /// that the Business Rules Engine doesn’t support the invocation of methods with a variable number of parameters.
    /// </summary>
    public static class RuleTraceManager
    {
        #region TraceInfo methods
        /// <summary>
        /// Writes an information message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        public static void TraceInfo(string message)
        {
            TraceManager.RulesComponent.TraceInfo(message);
        }

        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        public static void TraceInfo(string format, object p1)
        {
            TraceManager.RulesComponent.TraceInfo(format, p1);
        }

        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        public static void TraceInfo(string format, object p1, object p2)
        {
            TraceManager.RulesComponent.TraceInfo(format, p1, p2);
        }

        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        public static void TraceInfo(string format, object p1, object p2, object p3)
        {
            TraceManager.RulesComponent.TraceInfo(format, p1, p2, p3);
        }

        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        public static void TraceInfo(string format, object p1, object p2, object p3, object p4)
        {
            TraceManager.RulesComponent.TraceInfo(format, p1, p2, p3, p4);
        }

        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        /// <param name="p5">A data item to be used when formatting the output message.</param>
        public static void TraceInfo(string format, object p1, object p2, object p3, object p4, object p5)
        {
            TraceManager.RulesComponent.TraceInfo(format, p1, p2, p3, p4, p5);
        }

        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        /// <param name="p5">A data item to be used when formatting the output message.</param>
        /// <param name="p6">A data item to be used when formatting the output message.</param>
        public static void TraceInfo(string format, object p1, object p2, object p3, object p4, object p5, object p6)
        {
            TraceManager.RulesComponent.TraceInfo(format, p1, p2, p3, p4, p5, p6);
        } 
        #endregion

        #region TraceIn methods
        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        public static void TraceIn(string message)
        {
            TraceManager.RulesComponent.TraceIn(message);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        public static void TraceIn(object p1)
        {
            TraceManager.RulesComponent.TraceIn(p1);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        public static void TraceIn(object p1, object p2)
        {
            TraceManager.RulesComponent.TraceIn(p1, p2);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        public static void TraceIn(object p1, object p2, object p3)
        {
            TraceManager.RulesComponent.TraceIn(p1, p2, p3);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        public static void TraceIn(object p1, object p2, object p3, object p4)
        {
            TraceManager.RulesComponent.TraceIn(p1, p2, p3, p4);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        /// <param name="p5">A data item to be used when formatting the output message.</param>
        public static void TraceIn(object p1, object p2, object p3, object p4, object p5)
        {
            TraceManager.RulesComponent.TraceIn(p1, p2, p3, p4, p5);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        /// <param name="p5">A data item to be used when formatting the output message.</param>
        /// <param name="p6">A data item to be used when formatting the output message.</param>
        public static void TraceIn(object p1, object p2, object p3, object p4, object p5, object p6)
        {
            TraceManager.RulesComponent.TraceIn(p1, p2, p3, p4, p5, p6);
        }
        
        #endregion

        #region TraceError methods
        /// <summary>
        /// Writes an error message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the error message to be traced.</param>
        public static void TraceError(string message)
        {
            TraceManager.RulesComponent.TraceError(message);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        public static void TraceError(string format, object p1)
        {
            TraceManager.RulesComponent.TraceError(format, p1);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        public static void TraceError(string format, object p1, object p2)
        {
            TraceManager.RulesComponent.TraceError(format, p1, p2);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        public static void TraceError(string format, object p1, object p2, object p3)
        {
            TraceManager.RulesComponent.TraceError(format, p1, p2, p3);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        public static void TraceError(string format, object p1, object p2, object p3, object p4)
        {
            TraceManager.RulesComponent.TraceError(format, p1, p2, p3, p4);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        /// <param name="p5">A data item to be used when formatting the output message.</param>
        public static void TraceError(string format, object p1, object p2, object p3, object p4, object p5)
        {
            TraceManager.RulesComponent.TraceError(format, p1, p2, p3, p4, p5);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="p1">A data item to be used when formatting the output message.</param>
        /// <param name="p2">A data item to be used when formatting the output message.</param>
        /// <param name="p3">A data item to be used when formatting the output message.</param>
        /// <param name="p4">A data item to be used when formatting the output message.</param>
        /// <param name="p5">A data item to be used when formatting the output message.</param>
        /// <param name="p6">A data item to be used when formatting the output message.</param>
        public static void TraceError(string format, object p1, object p2, object p3, object p4, object p5, object p6)
        {
            TraceManager.RulesComponent.TraceError(format, p1, p2, p3, p4, p5, p6);
        } 
        #endregion
    }
}
