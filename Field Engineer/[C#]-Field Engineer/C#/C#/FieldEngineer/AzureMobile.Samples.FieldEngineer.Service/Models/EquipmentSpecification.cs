// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace AzureMobile.Samples.FieldEngineer.Service.Models
{
    [Table("EquipmentSpecification")]
    public class EquipmentSpecification : EntityData
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
