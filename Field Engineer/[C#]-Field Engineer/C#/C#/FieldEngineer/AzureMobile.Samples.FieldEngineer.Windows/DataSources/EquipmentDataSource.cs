// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Storage;

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    /// <summary> 
    /// This class acts as a facade for fetching data. It contains all the methods used to fetch data from
    /// the xml files, filter them as required and return the data to the xaml pages.
    /// </summary>
    public class EquipmentDataSource
    {
        private IList<Equipment> equipments;

        public EquipmentDataSource(string urlPrefix)
        {
            this.URLPrefix = urlPrefix;
        }

        private string URLPrefix { get; set; }

        public async Task<IList<Equipment>> GetAllAsync()
        {
            if (this.equipments == null)
            {
                var localTable = AzureDataServices.MobileServiceClient.GetSyncTable<Equipment>();

                if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online)
                {
                    await localTable.PullAsync();
                }

                this.equipments = await localTable.ToListAsync();

                foreach (var equipment in this.equipments)
                {
                    if (equipment.FullImage != null)
                    {
                        equipment.FullImage = this.URLPrefix + equipment.FullImage;
                    }

                    if (equipment.ThumbImage != null)
                    {
                        equipment.ThumbImage = this.URLPrefix + equipment.ThumbImage;
                    }
                }
            }

            return this.equipments;
        }

        /// <summary>
        /// This method returns the complete details about a Equipment using the Equipment ID.
        /// </summary>
        /// <param name="equipmentId">The Equipment id.</param>
        /// <returns>Equipment object</returns>
        public async Task<Equipment> GetDetailsAsync(string equipmentId)
        {
            var allEquipments = await this.GetAllAsync();
            var matches = allEquipments.Where((item) => item.Id.Equals(equipmentId));
            if (matches != null && matches.Count() == 1)
            {
                return matches.First();
            }

            return null;
        }
    }
}
