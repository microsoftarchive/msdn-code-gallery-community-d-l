//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Work Item Processor worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Extensions
{
    #region Using references
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.ServiceModel;
    using System.Globalization;
    using System.Data.EntityClient;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Common;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Common.RulesEngine;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Properties;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Data;
    #endregion

    /// <summary>
    /// Implements the extension responsible for processing work items found in the output queue. 
    /// </summary>
    public class OutputQueueSubscriberExtension : IWorkItemQueueSubscriberExtension
    {
        #region Private members
        private static readonly string DefaultDtoNamespace = typeof(InventoryData_DTO).Namespace;
        private static readonly string DefaultDtoTypeFullName = typeof(InventoryData_DTO).FullName;
        private static readonly string DefaultDtoAssemblyQualifiedName = typeof(InventoryData_DTO).AssemblyQualifiedName;

        private const int MaxErrorCountForReporting = 5;

        private IWorkItemProcessorConfigurationExtension configSettingsExtension;
        private IRoleConfigurationSettingsExtension roleConfigExtension;
        private ICloudCacheProviderExtension cacheProviderExtension;
        private IRulesEngineServiceClientExtension rulesEngineExtension;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IWorkItemProcessorConfigurationExtension>();
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();
            owner.Extensions.Demand<ICloudCacheProviderExtension>();
            owner.Extensions.Demand<IRulesEngineServiceClientExtension>();

            this.configSettingsExtension = owner.Extensions.Find<IWorkItemProcessorConfigurationExtension>();
            this.roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();
            this.cacheProviderExtension = owner.Extensions.Find<ICloudCacheProviderExtension>();
            this.rulesEngineExtension = owner.Extensions.Find<IRulesEngineServiceClientExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region IObserver implementation
        /// <summary>
        /// Gets called by the provider to notify this subscriber about a new item retrieved from the queue.
        /// </summary>
        /// <param name="inventoryDoc">The queue item retrieved from the source queue.</param>
        public void OnNext(XDocument inventoryDoc)
        {
            Guard.ArgumentNotNull(inventoryDoc, "inventoryDoc");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(inventoryDoc.Root.Name);

            try
            {
                Type dtoType = ResolveDataTransferObjectType(inventoryDoc);

                if (dtoType != null)
                {
                    string destTypeName = dtoType.Name;
                    DataContractSerializer serializer = new DataContractSerializer(dtoType);
                    List<object> dtoCollection = new List<object>();
                    List<Exception> errors = new List<Exception>();

                    var items = (from x in inventoryDoc.Root.Descendants() where String.Compare(x.Name.LocalName, destTypeName, false) == 0 select x);
                    var deserializationStartScope = TraceManager.WorkerRoleComponent.TraceStartScope(TraceLogMessages.ScopeDeserializeDataTransferObjects, callToken);

                    foreach (var item in items)
                    {
                        try
                        {
                            object dtoObject = serializer.ReadObject(item.CreateReader());

                            if (dtoObject != null)
                            {
                                dtoCollection.Add(dtoObject);
                            }
                            else
                            {
                                throw new InvalidDataContractException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.UnrecognizedObject, destTypeName));
                            }
                        }
                        catch (Exception ex)
                        {
                            errors.Add(ex);
                        }
                    }

                    TraceManager.WorkerRoleComponent.TraceEndScope(TraceLogMessages.ScopeDeserializeDataTransferObjects, deserializationStartScope, callToken);

                    RetryPolicy retryPolicy = this.roleConfigExtension.DatabaseRetryPolicy;
                    string sqlConnectionStrig = this.roleConfigExtension.GetConnectionString(this.configSettingsExtension.Settings.InventoryDatabase);

                    var dataOpStartScope = TraceManager.WorkerRoleComponent.TraceStartScope(TraceLogMessages.ScopeInvokeEntityFrameworkAPI, callToken);

                    try
                    {
                        EntityConnection conn = new EntityConnection(sqlConnectionStrig);

                        using (ContosoInventoryContainer dc = new ContosoInventoryContainer(conn))
                        {
                            foreach (var dto in dtoCollection)
                            {
                                dc.InventoryData_DTO.AddObject((InventoryData_DTO)dto);
                            }

                            retryPolicy.ExecuteAction(() => { dc.SaveChanges(); });
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex);
                    }

                    TraceManager.WorkerRoleComponent.TraceEndScope(TraceLogMessages.ScopeInvokeEntityFrameworkAPI, dataOpStartScope, callToken);

                    // Should we encountered any errors, throw an exception to notify the queue listener that this message failed processing.
                    // This will prevent the message from being deleted from queue.
                    if (errors.Count > 0)
                    {
                        // Note: we are going to report on the first 5 exceptions only.
                        throw new CloudApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.StoreInventoryDataOperationFailed), errors.Take(MaxErrorCountForReporting));
                    }
                }
                else
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.InstalledUICulture, ExceptionMessages.UnableToResolveDataTransferObjectType, inventoryDoc.Root.Name, this.configSettingsExtension.Settings.HandlingPolicyName));
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Gets called by the provider to indicate that it has finished processing queue items and is about to terminate.
        /// </summary>
        public void OnCompleted()
        {
        }

        /// <summary>
        /// Gets called by the provider to indicate that data is unavailable, inaccessible, or corrupted, 
        /// or that the provider has experienced some other error condition.
        /// </summary>
        /// <param name="error">The exception that resulted in an error condition.</param>
        public void OnError(Exception error)
        {
        }
        #endregion

        #region Private members
        private Type ResolveDataTransferObjectType(XDocument document)
        {
            Guard.ArgumentNotNull(document, "document");

            // Create a Rules Engine fact representing the message type of the item being processed.
            MessageTypeFact msgTypeFact = new MessageTypeFact(document);

            // Construct a cache key that uniquely identifies a specific cache item based on the input document type.
            string cacheKeyName = String.Concat(this.GetType().FullName, "_ResolveDTOTypeName_", msgTypeFact.Value);

            string dtoTypeName = this.cacheProviderExtension.GetOrPut(cacheKeyName, () =>
            {
                // Invoke a policy to determine the name of the map to be applied to the item being processed.
                StringDictionaryFact policyExecutionResult = this.rulesEngineExtension.ExecutePolicy<StringDictionaryFact>(this.configSettingsExtension.Settings.HandlingPolicyName, msgTypeFact);

                if (policyExecutionResult != null && policyExecutionResult.Items != null && policyExecutionResult.Items.Count > 0)
                {
                    // Take a dictionary item by it's predefined name.
                    return policyExecutionResult.Items[Resources.StringDictionaryFactValueDataTransferObjectType];
                }
                else
                {
                    return null;
                }
            }) as string;

            if (!String.IsNullOrEmpty(dtoTypeName))
            {
                // Construct a cache key that uniquely identifies a specific cache item based on the input document type.
                cacheKeyName = String.Concat(this.GetType().FullName, "_ResolveDTOType_", dtoTypeName);

                return this.cacheProviderExtension.GetOrPut(cacheKeyName, () =>
                {
                    // First, assume that we have a fully-qualified type name.
                    Type dtoType = Type.GetType(dtoTypeName, false);
                    if (dtoType != null) return dtoType;

                    // Not a fully qualified type name, assume we have a type name with namespace, try to append the assembly name.
                    string fullTypeName = DefaultDtoAssemblyQualifiedName.Replace(DefaultDtoTypeFullName, dtoTypeName);
                    dtoType = Type.GetType(fullTypeName, false);
                    if (dtoType != null) return dtoType;

                    // Still not found, assume we have just a type name, append both the namespace and assembly name.
                    fullTypeName = DefaultDtoAssemblyQualifiedName.Replace(DefaultDtoTypeFullName, String.Concat(DefaultDtoNamespace, ".", dtoTypeName));
                    dtoType = Type.GetType(fullTypeName, false);

                    return dtoType;
                }) as Type;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}