// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Mobile.Service;

namespace AzureMobile.Samples.FieldEngineer.Service.DataObjects
{
    public class EquipmentDTO : EntityData
    {
        public string Description { get; set; }
        public string EquipmentNumber { get; set; }
        public string FullImage { get; set; }
        public string Name { get; set; }
        public string ThumbImage { get; set; }
    }
}
