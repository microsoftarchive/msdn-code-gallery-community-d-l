// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using Newtonsoft.Json;

namespace AzureMobile.Samples.FieldEngineer.Service.Models
{
    [Table("Equipment")]
    public class Equipment : EntityData
    {
        public Equipment()
        {
            this.Jobs = new HashSet<Job>();
        }

        public string Description { get; set; }

        public string EquipmentNumber { get; set; }

        public string FullImage { get; set; }

        public string Name { get; set; }

        public string ThumbImage { get; set; }

        [JsonIgnore]
        public ICollection<EquipmentSpecification> EquipmentSpecifications { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
