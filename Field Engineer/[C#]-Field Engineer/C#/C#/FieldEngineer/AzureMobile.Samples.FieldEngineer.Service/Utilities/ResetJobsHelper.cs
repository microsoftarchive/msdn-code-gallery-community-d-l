// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureMobile.Samples.FieldEngineer.Service.Models;

namespace AzureMobile.Samples.FieldEngineer.Service.Utilities
{
    public class ResetJobsHelper
    {
        MobileServiceContext context = new MobileServiceContext();
        public void ResetJobsForAgent(string agentId)
        {
            var allJobs = context.Jobs.OrderBy(j => (j.JobNumber));
            var jobsForAgent = allJobs.Where(j => (j.AgentId.Equals(agentId)));
            int split = jobsForAgent.Count() / 2;
            int jobsIndex = 0;
            foreach (Job job in jobsForAgent)
            {
                if (jobsIndex < split)
                {
                    job.Status = "Completed";
                }
                if (jobsIndex == split)
                {
                    job.Status = "On Site";
                }
                if (jobsIndex > split)
                {
                    job.Status = "Not Started";
                }
                jobsIndex++;
            }
            context.SaveChanges();
        }

        public void ResetJobHistoriesForAgent(string agentName)
        {
            agentName = agentName.ToLower();
            var jobHistoriesToDelete = context.JobHistories.Where(jh => jh.ActionBy.ToLower() == agentName);
            if (jobHistoriesToDelete != null && jobHistoriesToDelete.Count() > 1)
            {
                foreach (JobHistory jobHistory in jobHistoriesToDelete)
                {
                    context.JobHistories.Remove(jobHistory);
                }
                context.SaveChanges();
            }
        }
    }
}