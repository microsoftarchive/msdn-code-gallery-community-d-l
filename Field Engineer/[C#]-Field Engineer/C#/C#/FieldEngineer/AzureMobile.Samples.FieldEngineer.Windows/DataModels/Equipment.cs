// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using Newtonsoft.Json;

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    public class Equipment
    {
        public string Id { get; set; }
        public string EquipmentNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbImage { get; set; }
        public string FullImage { get; set; }
        [JsonIgnore]
        public EquipmentSpecification[] EquipmentSpecifications { get; set; }
    }
}
