// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AzureMobile.Samples.AAD.Graph;
using AzureMobile.Samples.FieldEngineer.Service.DataObjects;
using AzureMobile.Samples.FieldEngineer.Service.Models;
using Microsoft.ServiceBus.Notifications;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace AzureMobile.Samples.FieldEngineer.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class JobController : TableController<JobDTO>
    {
        private readonly IAadHelperProvider aadHelperProvider;
        private MobileServiceContext context;

        public JobController(IAadHelperProvider aadHelperProvider)
        {
            this.aadHelperProvider = aadHelperProvider;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.context = new MobileServiceContext();
            this.DomainManager = new JobMappedDomainManager(this.context, Request, Services);
        }

        public async Task<IQueryable<JobDTO>> GetAllJobs()
        {
            ServiceUser mobileServiceUser = (ServiceUser)this.User;
            this.Services.Log.Info("User logged in: " + mobileServiceUser.Id);
            var aadCreds = (await mobileServiceUser.GetIdentitiesAsync()).OfType<AzureActiveDirectoryCredentials>().FirstOrDefault();
            this.Services.Log.Info("GetAll jobs for user: " + aadCreds.ObjectId);
            return this.context.Jobs
                                .Include("Customer")
                                .Include("Equipments")
                                .Include("JobHistories")
                                .Where(j => j.AgentId == aadCreds.ObjectId)
                                .Project().To<JobDTO>();
        }

        public SingleResult<JobDTO> GetJob(string id)
        {
            return this.Lookup(id);
        }

        public async Task DeleteJob(string id)
        {
            var job = this.context.Jobs.Include("equipments").FirstOrDefault(j => j.Id == id);
            if (job != null)
            {
                // Remove related equipments
                var jobEquipments = job.Equipments.ToArray();
                foreach (var eq in jobEquipments)
                {
                    job.Equipments.Remove(eq);
                    eq.Jobs.Clear();
                }

                // Remove related history items for that job
                var historyItems = this.context.JobHistories.Where(jh => jh.JobId == job.Id).ToArray();
                foreach (var item in historyItems)
                {
                    this.context.JobHistories.Remove(item);
                }

                await context.SaveChangesAsync();
            }

            await this.DeleteAsync(id);
        }

        public async Task<JobDTO> PatchJob(string id, Delta<JobDTO> patch)
        {
            Job currentJob = this.context.Jobs
                                .Include("Customer")
                                .Include("Equipments")
                                .Include("JobHistories").First(j => (j.Id == id));

            object value;
            string updatedJobStatus;
            patch.TryGetPropertyValue("Status", out value);
            updatedJobStatus = value as string;

            var statusUpdated = updatedJobStatus != null && updatedJobStatus != currentJob.Status;

            string jobHistoryComments = "Job Updated";
            if (statusUpdated)
            {
                if (updatedJobStatus == Utilities.Constants.CompletedStatus)
                {
                    jobHistoryComments = "Job completed";
                    patch.TrySetPropertyValue("EndTime", DateTimeOffset.UtcNow);
                }
                else if (updatedJobStatus == Utilities.Constants.CurrentStatus)
                {
                    patch.TrySetPropertyValue("StartTime", DateTimeOffset.UtcNow);
                }
            }

            string accessToken = this.aadHelperProvider.GetAccessToken();
            string aadObjectId = await this.GetAadObjectId();
            string actionBy = this.aadHelperProvider.GetUserDisplayName(aadObjectId, accessToken);

            JobHistory historyItem = new JobHistory
            {
                ActionBy = actionBy,
                Comments = jobHistoryComments,
                JobId = id,
                Id = Guid.NewGuid().ToString(),
                Job = currentJob,
                TimeStamp = DateTimeOffset.UtcNow
            };

            currentJob.JobHistories.Add(historyItem);
            var result = await base.UpdateAsync(id, patch);
            this.Services.Log.Info("Updated Job: " + currentJob.Title);
            if (result.Status == Utilities.Constants.CompletedStatus)
            {
                Utilities.EmailHelper.SendEmail(this.Services, currentJob, aadObjectId, this.aadHelperProvider);
            }

            return result;
        }

        [AuthorizeAadGroup(AadGroups.FieldManager)]
        public async Task<IHttpActionResult> PostJob(JobDTO item)
        {
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            Job newJob = Mapper.Map<JobDTO, Job>(item);
            newJob.Status = Utilities.Constants.PendingStatus;
            newJob.CreatedAt = DateTimeOffset.UtcNow;

            //If there are no jobs that agent is currently working on, update new job status to On Site
            Job currentJob = this.context.Jobs.FirstOrDefault(j => (j.AgentId.Equals(item.AgentId) && j.Status == Utilities.Constants.CurrentStatus));
            if (currentJob == null)
            {
                newJob.Status = Utilities.Constants.CurrentStatus;
            }
            Customer customer = this.context.Customers.FirstOrDefault(eq => eq.Id.Equals(item.CustomerId));
            ThrowBadRequestIfNull(customer, "Customer with id '" + item.CustomerId + "' does not exist");

            newJob.Customer = customer;

            foreach (EquipmentDTO equipmentDTO in item.Equipments)
            {
                Equipment equipment = this.context.Equipments.FirstOrDefault(eq => eq.Id.Equals(equipmentDTO.Id));
                ThrowBadRequestIfNull(equipment, "Equipment with id '" + equipmentDTO.Id + "' does not exist.");
                equipment.Jobs.Add(newJob);
                newJob.Equipments.Add(equipment);
            }

            string accessToken = this.aadHelperProvider.GetAccessToken();
            string aadObjectId = await this.GetAadObjectId();
            string actionBy = this.aadHelperProvider.GetUserDisplayName(aadObjectId, accessToken);

            JobHistory historyItem = new JobHistory
            {
                ActionBy = actionBy,
                Comments = "New Job Created",
                JobId = newJob.Id,
                Id = Guid.NewGuid().ToString(),
                Job = newJob,
                TimeStamp = DateTimeOffset.UtcNow
            };

            newJob.JobHistories.Add(historyItem);

            await this.context.SaveChangesAsync();
            this.Services.Log.Info("Added new Job: " + newJob.Title);

            await this.SendPush(newJob);
            item = Mapper.Map<Job, JobDTO>(newJob);
            return this.CreatedAtRoute("Tables", new { id = item.Id }, item);
        }

        private void ThrowBadRequestIfNull(object value, string message)
        {
            if (value == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "{\"error\":\"" + message + "\"}",
                        Encoding.UTF8,
                        "application/json")
                });
            }
        }

        private async Task SendPush(Job job)
        {
            TemplatePushMessage message = new TemplatePushMessage()
            {
               { "message", "New job assigned: " + job.Title },
            };

            try
            {
                this.Services.Log.Info("Sending push to user: " + job.AgentId);
                NotificationOutcome pushResponse = await this.Services.Push.SendAsync(message, job.AgentId);
                this.Services.Log.Info("Push sent: " + pushResponse);
            }
            catch (Exception ex)
            {
                this.Services.Log.Error("Error sending push: " + ex.Message);
            }
        }

        private async Task<string> GetAadObjectId()
        {
            ServiceUser mobileServiceUser = (ServiceUser)this.User;
            AzureActiveDirectoryCredentials aadCreds = (await mobileServiceUser.GetIdentitiesAsync()).OfType<AzureActiveDirectoryCredentials>().First();
            return aadCreds.ObjectId;
        }

        private class JobMappedDomainManager : MappedEntityDomainManager<JobDTO, Job>
        {
            private MobileServiceContext context;

            public JobMappedDomainManager(MobileServiceContext context, HttpRequestMessage request, ApiServices services)
                : base(context, request, services)
            {
                this.context = context;
            }

            public async override Task<bool> DeleteAsync(string id)
            {
                return await this.DeleteItemAsync(id);
            }

            public override SingleResult<JobDTO> Lookup(string id)
            {
                return this.LookupEntity(j => j.Id == id);
            }

            public override Task<JobDTO> UpdateAsync(string id, Delta<JobDTO> patch)
            {
                return this.UpdateEntityAsync(patch, id);
            }

            protected override void SetOriginalVersion(Job model, byte[] version)
            {
                this.Context.Entry(model).OriginalValues["Version"] = version;
            }
        }
    }
}
