// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Capptain.Agent;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Windows.Storage;
using Windows.UI.Popups;

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    /// <summary> 
    /// This class acts as a facade for fetching data. It contains all the methods used to fetch data from
    /// the xml files, filter them as required and return the data to the xaml pages.
    /// </summary>
    public sealed class JobDataSource
    {
        private IList<Job> jobs;

        public async Task<IList<Job>> GetAllAsync(bool refresh = false)
        {
            if (this.jobs == null || refresh)
            {
                var localTable = AzureDataServices.MobileServiceClient.GetSyncTable<Job>();
                string errorString = null;

                if (ApplicationData.Current.LocalSettings.Values[Constants.Settings.StorageMode].ToString() == Constants.Online)
                {
                    try
                    {
                        await AzureDataServices.MobileServiceClient.SyncContext.PushAsync();
                        await localTable.PullAsync();
                    }
                    catch (MobileServicePushFailedException ex)
                    {
                        CapptainAgent.Instance.SendError("MobileServicePushFailedException.Error", new Dictionary<object, object>() { { "Internal Push operation during pull request failed because of sync errors:", ex.Message } });
                        errorString = "Internal Push operation during pull request failed because of sync errors: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        CapptainAgent.Instance.SendError("Pull Error:", new Dictionary<object, object>() { { "Pull failed:", ex.Message } });
                        throw;
                    }

                    if (errorString != null)
                    {
                        MessageDialog d = new MessageDialog(errorString);
                        await d.ShowAsync();
                    }
                }

                this.jobs = await localTable.ToListAsync();
            }

            return this.jobs;
        }

        /// <summary>
        /// This method returns the complete details about a job using the Job ID.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>Job object</returns>
        public async Task<Job> GetDetailsAsync(string jobId)
        {
            var allJobs = await this.GetAllAsync();
            var matches = allJobs.Where((item) => item.Id.Equals(jobId));
            if (matches != null && matches.Count() == 1)
            {
                return matches.First();
            }

            return null;
        }

        /// <summary>
        /// This method gets all the jobs which are still pending (jobs with status 'Not Started').
        /// </summary>
        /// <returns>List of Pending Jobs</returns>
        public async Task<List<Job>> GetPendingJobsAsync()
        {
            var allJobs = await this.GetAllAsync();
            var matches = allJobs.Where((item) => item.Status == Constants.PendingStatus).ToList();
            return matches;
        }

        /// <summary>
        /// This method groups all the jobs by the Job Status (On-Site/ Completed/ Not Started) 
        /// and returns the groups.
        /// </summary>
        /// <returns>Groups of Jobs grouped by Status</returns>
        public async Task<List<JobGroup>> GetJobGroupsAsync()
        {
            var allJobs = await this.GetAllAsync();
            var groupCollection = new List<JobGroup>
                {
                    new JobGroup()
                        {
                            Title = Constants.CurrentStatus,
                            Jobs = allJobs.Where(job => job.Status.Equals(Constants.CurrentStatus)).ToList()
                        },
                    new JobGroup()
                        {
                            Title = Constants.PendingStatus,
                            Jobs = allJobs.Where(job => job.Status.Equals(Constants.PendingStatus)).ToList()
                        },
                    new JobGroup()
                        {
                            Title = Constants.CompletedStatus,
                            Jobs = allJobs.Where(job => job.Status.Equals(Constants.CompletedStatus)).ToList()
                        }
                };

            return groupCollection;
        }

        /// <summary>
        /// This method searches the jobs by search text. The search text can be a part of the 
        /// Job ID, Job Title or Customer Name
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <returns>Search results</returns>
        public async Task<List<Job>> SearchJobsBySearchTextAsync(string searchText)
        {
            var allJobs = await this.GetAllAsync();
            var filteredList =
                allJobs.Where(
                    item =>
                    item.Id.Contains(searchText) || item.Title.ToUpper().Contains(searchText.ToUpper()) ||
                    item.Customer.FullName.ToUpper().Contains(searchText.ToUpper()));
            return filteredList.ToList();
        }

        /// <summary>
        /// This method returns the complete list of jobs
        /// </summary>
        /// <returns>List of Jobs</returns>
        public async Task<List<Job>> GetAllJobs(bool refresh = false)
        {
            var allJobs = await this.GetAllAsync(refresh);
            return allJobs.ToList();
        }

        /// <summary>
        /// This method updates the status of a job to 'Completed'
        /// It also sets the next job as the 'Current Job'
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public async Task UpdateJobStatus(string jobID)
        {
            var allJobs = await this.GetAllAsync();
            var currentJob = allJobs.Single(x => x.Status.Equals(Constants.CurrentStatus));
            var toUpdate = allJobs.Single(x => x.Id.Equals(jobID));
            toUpdate.Status = Constants.CompletedStatus;
            await AzureDataServices.UpdateJob(toUpdate);
            if (toUpdate.Id.Equals(currentJob.Id))
            {
                var setNextCurrent = allJobs.FirstOrDefault(x => x.Status.Equals(Constants.PendingStatus));
                if (setNextCurrent != null)
                {
                    setNextCurrent.Status = Constants.CurrentStatus;
                    await AzureDataServices.UpdateJob(setNextCurrent);
                }
            }
        }
    }
}
