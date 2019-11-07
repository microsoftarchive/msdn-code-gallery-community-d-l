// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Mobile.Service;

namespace AzureMobile.Samples.FieldEngineer.Service.DataObjects
{
    public class CustomerDTO : EntityData
    {
        public string AdditionalContactNumber { get; set; }
        public string County { get; set; }
        public string FullName { get; set; }
        public string HouseNumberOrName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Postcode { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
    }
}
