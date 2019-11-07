// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Collections.Generic;

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    /// <summary>
    /// This class is used to group the jobs based on their status. Each group has a title which is the job status
    /// and a list of jobs.
    /// </summary>
    public class JobGroup
    {
        /// <summary>
        /// Represents the title of each group (On Site, Completed, Not Started).
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents a list of jobs in each group.
        /// </summary>
        public List<Job> Jobs { get; set; }
    }
}
