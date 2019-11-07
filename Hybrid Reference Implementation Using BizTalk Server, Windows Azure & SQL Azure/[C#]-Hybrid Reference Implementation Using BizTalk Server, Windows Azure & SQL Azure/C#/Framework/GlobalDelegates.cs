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
    /// Defines a callback delegate which will be invoked whenever a retry condition is encountered.
    /// </summary>
    /// <param name="currentRetryCount">The current retry attempt count.</param>
    /// <param name="lastException">The exception which caused the retry conditions to occur.</param>
    /// <param name="delay">The delay indicating how long the current thread will be suspended for before the next iteration will be invoked.</param>
    public delegate void RetryCallbackDelegate(int currentRetryCount, Exception lastException, TimeSpan delay);

    /// <summary>
    /// Defines a callback delegate which will be invoked whenever an operation is completed with a specific result.
    /// </summary>
    /// <typeparam name="T">The type of operation result.</typeparam>
    /// <param name="result">The result of the operation.</param>
    public delegate void OperationCompletedDelegate<T>(T result);
}
