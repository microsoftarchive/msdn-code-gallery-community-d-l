//
// Copyright (C) Microsoft Corporation.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Diagnostics;

namespace MyFixIt.Logging
{
    public class Logger : ILogger
    {
        //
        // Warning - trace information within the application 

        public void Information(string message)
        {
            Trace.TraceInformation(message);
        }

        public void Information(string fmt, params object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception, string fmt, params object[] vars)
        {
            var msg = String.Format(fmt, vars);
            Trace.TraceInformation(string.Format(fmt, vars) + ";Exception Details={0}", ExceptionUtils.FormatException(exception, includeContext:true));
        }

        //
        // Warning - trace warnings within the application 

        public void Warning(string message)
        {
            Trace.TraceWarning(message);
        }

        public void Warning(string fmt, params object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            var msg = String.Format(fmt, vars);
            Trace.TraceWarning(string.Format(fmt, vars) + ";Exception Details={0}", ExceptionUtils.FormatException(exception, includeContext:true));
        }

        //
        // Error - trace fatal errors within the application 

        public void Error(string message)
        {
            Trace.TraceError(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            var msg = String.Format(fmt, vars);
            Trace.TraceError(string.Format(fmt, vars) + ";Exception Details={0}", ExceptionUtils.FormatException(exception, includeContext:true));
        }

        //
        // TraceAPI - trace inter-service calls (including latency)

        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            TraceApi(componentName, method, timespan, "");
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            string message = String.Concat("component:", componentName, ";method:", method, ";timespan:", timespan.ToString(), ";properties:", properties);
            Trace.TraceInformation(message);
        }
    }
}