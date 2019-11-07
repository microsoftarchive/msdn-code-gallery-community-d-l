// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureMobile.Samples.FieldEngineer.Service.Models
{
    [Table("Job")]
    public class Job
    {
        public Job()
        {
            this.JobHistories = new HashSet<JobHistory>();
            this.Equipments = new HashSet<Equipment>();
        }

        public string Id { get; set; }

        public string AgentId { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public string EtaTime { get; set; }

        public string JobNumber { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public string Status { get; set; }

        public string Title { get; set; }

        public string CustomerId { get; set; }

        #region system properties
        public DateTimeOffset? CreatedAt { get; set; }

        public bool Deleted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
        #endregion

        public Customer Customer { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
    }
}
