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
namespace Contoso.Cloud.Integration.Framework.Instrumentation
{
    #region Using statements
    using System;
    using System.Data;
    using System.Text;
    #endregion

    #region ITraceEventProvider extension methods
    /// <summary>
    /// Provides extension methods which supplement the tracing provider with additional enhancements.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Writes detailed information about the specified database command including command statement, its parameters and their values.
        /// </summary>
        /// <param name="traceProvider">The type which is targeted by this extension method.</param>
        /// <param name="command">The database command which will be traced.</param>
        public static void TraceCommand(this ITraceEventProvider traceProvider, IDbCommand command)
        {
            if (command != null)
            {
                traceProvider.TraceDetails(() =>
                {
                    StringBuilder traceTextBuilder = new StringBuilder();
                    traceTextBuilder.AppendFormat("EXEC {0}", command.CommandText);

                    if (command.Parameters != null)
                    {
                        foreach (var parameter in command.Parameters)
                        {
                            IDbDataParameter dataParam = parameter as IDbDataParameter;
                            bool firstPass = true;

                            if (dataParam != null)
                            {
                                if (!firstPass)
                                {
                                    traceTextBuilder.Append(", ");
                                }
                                else
                                {
                                    traceTextBuilder.Append(" ");
                                }

                                traceTextBuilder.AppendFormat("{0}='{1}'{2}", dataParam.ParameterName, dataParam.Value != null ? dataParam.Value : "NULL", dataParam.Direction == ParameterDirection.Input ? String.Empty : " OUT");
                                firstPass = false;
                            }
                        }
                    }

                    return traceTextBuilder.ToString();
                });
            }
        }
    }
    #endregion
}