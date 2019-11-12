// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------
// This file reused (with modifications) from: https://github.com/Azure/mobile-services-samples/blob/master/TodoOffline/WindowsUniversal/TodoOffline/TodoOffline.Shared/SyncHandler.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataModels;
using Capptain.Agent;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using Windows.UI.Popups;

namespace AzureMobile.Samples.FieldEngineer.Utilities
{
    public class SyncHandler : IMobileServiceSyncHandler
    {
        MobileServiceClient client;
        const string LOCAL_VERSION = "Use local version";
        const string SERVER_VERSION = "Use server version";

        public SyncHandler(MobileServiceClient client)
        {
            this.client = client;
        }

        public virtual Task OnPushCompleteAsync(MobileServicePushCompletionResult result)
        {
            return Task.FromResult(0);
        }

        public virtual async Task<JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
        {
            MobileServiceInvalidOperationException error;
            error = null;
            do
            {
                try
                {
                    JObject result = await operation.ExecuteAsync();
                    return result;
                }
                catch (MobileServicePreconditionFailedException ex)
                {
                    CapptainAgent.Instance.SendError("MobileServicePreconditionFailedException.Error", new Dictionary<object, object>() { { "errorMessage", ex.Message } });
                    error = ex;
                }
                catch (Exception ex)
                {
                    CapptainAgent.Instance.SendError("Exception in SyncHandler", new Dictionary<object, object>() { { "errorMessage", ex.Message } });
                    throw;
                }

                if (error != null)
                {
                    var localItem = operation.Item.ToObject<Job>();
                    var serverValue = await operation.Table.LookupAsync(localItem.Id) as JObject;
                    var serverItem = serverValue.ToObject<Job>();

                    if (localItem.Equals(serverItem))
                    {
                        // items are same so we can ignore the conflict
                        return serverValue;
                    }

                    IUICommand command = await ShowConflictDialog(localItem, serverValue);
                    if (command.Label == LOCAL_VERSION)
                    {
                        CapptainAgent.Instance.SendEvent("Conflict resolved. Overwriting server Job: " + localItem.Id +
                                                         " with Job from localstore");
                        // Overwrite the server version and try the operation again by continuing the loop
                        operation.Item[MobileServiceSystemColumns.Version] = serverValue[MobileServiceSystemColumns.Version];
                    }
                    else if (command.Label == SERVER_VERSION)
                    {
                        CapptainAgent.Instance.SendEvent("Conflict resolved. Overwriting local Job: " + localItem.Id +
                                                         " with latest Job from Server");
                        return (JObject)serverValue;
                    }
                    else
                    {
                        operation.AbortPush();
                    }
                }
            } while (error != null);
            return null;
        }

        private async Task<IUICommand> ShowConflictDialog(Job localItem, JObject serverValue)
        {
            var dialog = new MessageDialog(
                "How do you want to resolve this conflict?\n\n",
                title: "Conflict between local and server versions");

            dialog.Commands.Add(new UICommand(LOCAL_VERSION));
            dialog.Commands.Add(new UICommand(SERVER_VERSION));

            return await dialog.ShowAsync();
        }
    }
}
