// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureMobile.Samples.FieldEngineer.Service.Models
{
    [Table("Customer")]
    public class Customer :EntityData
    {
        public Customer()
        {
            this.Jobs = new HashSet<Job>();
        }

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
        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; }
    }
}
