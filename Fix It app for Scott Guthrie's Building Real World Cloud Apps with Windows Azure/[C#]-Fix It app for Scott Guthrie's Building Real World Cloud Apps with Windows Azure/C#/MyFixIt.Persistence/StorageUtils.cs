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

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using System;

namespace MyFixIt.Persistence
{
    static class StorageUtils
    {
        public static CloudStorageAccount StorageAccount
        {
            get
            {
                string account = CloudConfigurationManager.GetSetting("StorageAccountName");
                // This enables the storage emulator when running locally using the Azure compute emulator.
                if (account == "{StorageAccountName}")
                {
                    return CloudStorageAccount.DevelopmentStorageAccount;
                }

                string key = CloudConfigurationManager.GetSetting("StorageAccountAccessKey");
                string connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
                return CloudStorageAccount.Parse(connectionString);
            }
        }
    }
}
