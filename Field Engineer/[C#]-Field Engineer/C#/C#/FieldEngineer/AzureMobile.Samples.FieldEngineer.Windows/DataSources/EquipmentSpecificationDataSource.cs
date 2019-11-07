// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Storage;

namespace AzureMobile.Samples.FieldEngineer.DataSources
{
    public sealed class EquipmentSpecificationDataSource
    {
        private IList<EquipmentSpecification> equipmentSpecification;

        public async Task<IList<EquipmentSpecification>> GetAllAsync()
        {
            if (this.equipmentSpecification == null)
            {
                var localTable = AzureDataServices.MobileServiceClient.GetSyncTable<EquipmentSpecification>();

                if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online)
                {
                    await localTable.PullAsync();
                }

                this.equipmentSpecification = await localTable.ToListAsync();
            }

            return this.equipmentSpecification;
        }

        /// <summary>
        /// This method returns the complete list of Equipment Specification
        /// </summary>
        /// <returns>List of Equipment Specifications</returns>
        public async Task<List<EquipmentSpecification>> GetAllEquipmentSpecification()
        {
            var allEquipmentSpecification = await this.GetAllAsync();
            return allEquipmentSpecification.ToList();
        }

        /// <summary>
        /// This method returns details about a specific equipment
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        public async Task<EquipmentSpecification[]> GetDetailsAsync(string equipmentId)
        {
            var allEquipmentSpecifications = await this.GetAllAsync();
            var matches = allEquipmentSpecifications.Where((item) => item.EquipmentId.Equals(equipmentId));
            if (matches != null)
            {
                return matches.ToArray();
            }

            return null;
        }
    }
}
