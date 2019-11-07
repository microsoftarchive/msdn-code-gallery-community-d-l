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
namespace Contoso.Cloud.Integration.Framework.Discovery
{
    #region Using statements
    using System;
    #endregion

    /// <summary>
    /// Provides a base class from which any custom discovery conditions must be derived.
    /// </summary>
    public abstract class DiscoveryCondition
    {
        /// <summary>
        /// Evaluates the given input against specific criteria and returns a flag indicating whether or not the criteria has been met.
        /// </summary>
        /// <param name="input">The input to be evaluated against specific criteria.</param>
        /// <returns>The flag indicating whether or not the criteria has been met.</returns>
        public abstract bool Evaluate(object input);
    }

    /// <summary>
    /// Extends the base implementation of the <see cref="DiscoveryCondition"/> class with support for strongly-typed input.
    /// </summary>
    /// <typeparam name="T">The type of the input which this instance of <see cref="DiscoveryCondition"/> will be handling.</typeparam>
    public abstract class DiscoveryCondition<T> : DiscoveryCondition
    {
        /// <summary>
        /// Occurs when the base class is performing criteria evaluation against the specified input.
        /// </summary>
        protected EvaluateDelegate conditionEvaluate;

        /// <summary>
        /// Defines an event delegate for the event raised by this object when it is performing criteria evaluation against the specified input.
        /// </summary>
        /// <param name="input">The input to be evaluated against specific criteria.</param>
        /// <returns>The flag indicating whether or not the criteria has been met.</returns>
        protected delegate bool EvaluateDelegate(T input);

        /// <summary>
        /// Evaluates the given input against specific criteria and returns a flag indicating whether or not the criteria has been met.
        /// </summary>
        /// <param name="input">The input to be evaluated against specific criteria.</param>
        /// <returns>The flag indicating whether or not the criteria has been met.</returns>
        public override bool Evaluate(object input)
        {
            return input != null && input.GetType() == typeof(T) && conditionEvaluate((T)input);
        }
    }
}
