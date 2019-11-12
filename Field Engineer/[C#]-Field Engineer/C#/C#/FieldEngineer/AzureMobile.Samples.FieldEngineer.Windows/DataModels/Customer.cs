// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    public partial class Customer
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string HouseNumberOrName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string AdditionalContactNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
