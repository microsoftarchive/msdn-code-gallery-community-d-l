// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AzureMobile.Samples.FieldEngineer.Service.DataObjects
{
    public class JobDTO : EntityData
    {
        public string CustomerId { get; set; }

        public string AgentId { get; set; }
        
        public string EtaTime { get; set; }
        
        public string JobNumber { get; set; }
        
        public string Status { get; set; }
        
        public string Title { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public virtual CustomerDTO Customer { get; set; }
        public virtual List<JobHistoryDTO> JobHistories { get; set; }
        public virtual List<EquipmentDTO> Equipments { get; set; }
    }
}
