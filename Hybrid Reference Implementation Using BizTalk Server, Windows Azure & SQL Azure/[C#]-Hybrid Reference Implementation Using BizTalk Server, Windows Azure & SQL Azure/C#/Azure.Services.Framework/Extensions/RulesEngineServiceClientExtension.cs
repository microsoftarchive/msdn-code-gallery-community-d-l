//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Extensions
{
    #region Using references
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    #region IRulesEngineServiceClientExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for executing Business Rules Engine (BRE) policies.
    /// </summary>
    public interface IRulesEngineServiceClientExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Executes the specified BRE policy using zero or more facts.
        /// </summary>
        /// <typeparam name="T">The type of the result expected from the BRE policy.</typeparam>
        /// <param name="policyName">The name of the BRE policy that needs to be invoked.</param>
        /// <param name="facts">Zero or more facts that will be submitted to the policy for evaluation.</param>
        /// <returns>The instance of an object carrying the result of policy execution, or null reference if the policy was not fired successfully.</returns>
        T ExecutePolicy<T>(string policyName, params object[] facts) where T : class, new();
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for executing Business Rules Engine policies.
    /// </summary>
    public class RulesEngineServiceClientExtension : IRulesEngineServiceClientExtension
    {
        #region Private members
        private IRoleConfigurationSettingsExtension roleConfigExtension;
        #endregion

        #region IRulesEngineServiceClientExtension implementation
        /// <summary>
        /// Executes the specified BRE policy using zero or more facts.
        /// </summary>
        /// <typeparam name="T">The type of the result expected from the BRE policy.</typeparam>
        /// <param name="policyName">The name of the BRE policy that needs to be invoked.</param>
        /// <param name="facts">Zero or more facts that will be submitted to the policy for evaluation.</param>
        /// <returns>The instance of an object carrying the result of policy execution, or null reference if the policy was not fired successfully.</returns>
        public T ExecutePolicy<T>(string policyName, params object[] facts) where T : class, new()
        {
            Guard.ArgumentNotNullOrEmptyString(policyName, "policyName");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(policyName);

            try
            {
                RulesEngineRequest request = new RulesEngineRequest(policyName);
                request.AddFacts(new T());

                if (facts != null)
                {
                    request.AddFacts(facts);
                }

                using(var rulesEngineClient = new ReliableServiceBusClient<IOnPremiseRulesEngineServiceChannel>(roleConfigExtension.OnPremiseRelayTwoWayEndpoint, roleConfigExtension.CommunicationRetryPolicy))
                {
                    RulesEngineResponse response = rulesEngineClient.RetryPolicy.ExecuteAction<RulesEngineResponse>(() =>
                    {
                        return rulesEngineClient.Client.ExecutePolicy(request);
                    });

                    if (response.Success)
                    {
                        return (from fact in response.Facts where fact.GetType() == typeof(T) select fact).FirstOrDefault() as T;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
            catch (Exception ex)
            {
                // Report on any exceptions and return the default value of T, do not re-throw the exception to the caller.
                TraceManager.WorkerRoleComponent.TraceError(ex);
                return default(T);
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();

            this.roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion
    }
}
