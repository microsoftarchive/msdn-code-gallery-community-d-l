// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    public class Job
    {
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public string AgentId { get; set; }
        public string JobNumber { get; set; }
        public string Id { get; set; }
        public string EtaTime { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<JobHistory> JobHistories { get; set; }
        [Version]
        public string Version { get; set; }

        public override bool Equals(object obj)
        {
            Job job = obj as Job;
            if (job == null) return false;

            if ((string.Compare(this.CustomerId, job.CustomerId, StringComparison.OrdinalIgnoreCase) != 0) ||
                (string.Compare(this.AgentId, job.AgentId, StringComparison.OrdinalIgnoreCase) != 0) ||
                (string.Compare(this.JobNumber, job.JobNumber, StringComparison.OrdinalIgnoreCase) != 0) ||
                (string.Compare(this.Id, job.Id, StringComparison.OrdinalIgnoreCase) != 0) ||
                (string.Compare(this.EtaTime, job.EtaTime, StringComparison.OrdinalIgnoreCase) != 0) ||
                (string.Compare(this.Status, job.Status, StringComparison.OrdinalIgnoreCase) != 0) ||
                (string.Compare(this.Title, job.Title, StringComparison.OrdinalIgnoreCase) != 0))
            {
                return false;
            }

            if ((this.Equipments == null) != (job.Equipments == null)) return false;

            if (this.Equipments != null)
            {
                if (this.Equipments.Count != job.Equipments.Count) return false;
                if (this.Equipments.Any(e => !job.Equipments.Any(je => je.Id == e.Id))) return false;
            }

            if ((this.Customer == null) != (job.Customer == null)) return false;

            if (this.Customer != null)
            {
                if (this.Customer.Id != job.Customer.Id) return false;
            }

            return true;
        }
    }
}
