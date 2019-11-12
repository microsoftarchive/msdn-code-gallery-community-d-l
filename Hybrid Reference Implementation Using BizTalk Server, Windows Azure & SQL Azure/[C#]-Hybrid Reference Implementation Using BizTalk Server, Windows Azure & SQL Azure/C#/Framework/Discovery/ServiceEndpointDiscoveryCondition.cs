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
    using System.ServiceModel.Description;
    #endregion

    /// <summary>
    /// Implements a discovery condition that evaluates the <see cref="System.ServiceModel.Description.ServiceEndpoint"/> instances against a set of
    /// criteria when performing service endpoint configuration discovery.
    /// </summary>
    public class ServiceEndpointDiscoveryCondition : DiscoveryCondition<ServiceEndpoint>
    {
        #region Constructor
        private ServiceEndpointDiscoveryCondition()
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a discovery condition which evaluates a service endpoint name to check if it fully matches the specified name.
        /// </summary>
        /// <param name="name">The name of the service endpoint participating in the evaluation.</param>
        /// <returns>The instance of the <see cref="DiscoveryCondition"/> object containing the evaluation condition.</returns>
        public static DiscoveryCondition EndpointNameExactMatch(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            return new ServiceEndpointDiscoveryCondition()
            {
                conditionEvaluate = (endpoint) =>
                {
                    return String.Compare(endpoint.Name, name, false) == 0;
                }
            };
        }

        /// <summary>
        /// Returns a discovery condition which evaluates a service endpoint name to check if it partially matches the specified name.
        /// </summary>
        /// <param name="name">The name of the service endpoint participating in the evaluation.</param>
        /// <returns>The instance of the <see cref="DiscoveryCondition"/> object containing the evaluation condition.</returns>
        public static DiscoveryCondition EndpointNamePartialMatch(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            return new ServiceEndpointDiscoveryCondition()
            {
                conditionEvaluate = (endpoint) =>
                {
                    return String.Compare(endpoint.Name, name, true) == 0 || endpoint.Name.StartsWith(name) || endpoint.Name.EndsWith(name);
                }
            };
        }

        /// <summary>
        /// Returns a discovery condition which evaluates a transport binding to check if it matches the specified type.
        /// </summary>
        /// <param name="bindingType">The WCF binding type participating in the evaluation.</param>
        /// <returns>The instance of the <see cref="DiscoveryCondition"/> object containing the evaluation condition.</returns>
        public static DiscoveryCondition BindingTypeExactMatch(Type bindingType)
        {
            Guard.ArgumentNotNull(bindingType, "bindingType");

            return new ServiceEndpointDiscoveryCondition()
            {
                conditionEvaluate = (endpoint) =>
                {
                    return endpoint.Binding != null && endpoint.Binding.GetType() == bindingType;
                }
            };
        }

        /// <summary>
        /// Returns a discovery condition which evaluates a service contract to check if it matches the specified type.
        /// </summary>
        /// <param name="contractType">The service contract type participating in the evaluation.</param>
        /// <returns>The instance of the <see cref="DiscoveryCondition"/> object containing the evaluation condition.</returns>
        public static DiscoveryCondition ContractTypeExactMatch(Type contractType)
        {
            Guard.ArgumentNotNull(contractType, "contractType");

            return new ServiceEndpointDiscoveryCondition()
            {
                conditionEvaluate = (endpoint) =>
                {
                    return endpoint.Contract != null && endpoint.Contract.ContractType == contractType;
                }
            };
        }
        #endregion
    }
}
