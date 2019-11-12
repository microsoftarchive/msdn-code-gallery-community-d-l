// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureMobile.Samples.FieldEngineer.Service.Models
{
    [Table("JobHistory")]
    public class JobHistory : EntityData
    {
        public string ActionBy { get; set; }

        public string Comments { get; set; }

        public string JobId { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public virtual Job Job { get; set; }
    }
}
