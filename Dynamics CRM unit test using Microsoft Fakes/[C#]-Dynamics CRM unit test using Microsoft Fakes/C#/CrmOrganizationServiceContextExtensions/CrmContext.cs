using System;
using System.Collections.Generic;
using System.Data.Services;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Configuration;
using Microsoft.Xrm.Client.Messages;
using Microsoft.Xrm.Sdk;

namespace CrmOrganizationServiceContextExtensions
{
    public class CrmContext : CrmOrganizationServiceContext, ICrmOrganizationServiceContext, IInitializable, IOrganizationService, IUpdatable, IExpandProvider, IOrganizationServiceContainer
    {
        public CrmContext() : base() { }
        public CrmContext(string contextName) : base(contextName) { }
        public CrmContext(CrmConnection connection) : base(connection) { }
        public CrmContext(IOrganizationService service) : base(service) { }

        private Microsoft.Xrm.Sdk.Client.OrganizationServiceContext _context;
        private Microsoft.Xrm.Sdk.Client.OrganizationServiceContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = this as Microsoft.Xrm.Sdk.Client.OrganizationServiceContext;
                }

                return _context;
            }
        }

        #region Microsoft.Xrm.Client.Messages.OrganizationServiceContextExtensions
        /*
         * Microsoft.Xrm.Client.Messages.OrganizationServiceContextExtensions
         */
        public Guid AddItemCampaign(Guid campaignId, Guid entityId, string entityName)
        {
            return Context.AddItemCampaign(campaignId, entityId, entityName);
        }

        public Guid AddItemCampaignActivity(Guid campaignActivityId, Guid itemId, string entityName)
        {
            return Context.AddItemCampaignActivity(campaignActivityId, itemId, entityName);
        }

        public void AddListMembersList(Guid listId, Guid[] memberIds)
        {
            Context.AddListMembersList(listId, memberIds);
        }

        public Guid AddMemberList(Guid listId, Guid entityId)
        {
            return Context.AddMemberList(listId, entityId);
        }

        public void AddMembersTeam(Guid teamId, Guid[] memberIds)
        {
            Context.AddMembersTeam(teamId, memberIds);
        }

        public void AddPrivilegesRole(Guid roleId, object privileges)
        {
            Context.AddPrivilegesRole(roleId, privileges);
        }

        public void AddProductToKit(Guid kitId, Guid productId)
        {
            Context.AddProductToKit(kitId, productId);
        }

        public Guid AddRecurrence(Microsoft.Xrm.Sdk.Entity target, Guid appointmentId)
        {
            return Context.AddRecurrence(target, appointmentId);
        }

        public Guid AddSolutionComponent(Guid componentId, int componentType, string solutionUniqueName, bool addRequiredComponents)
        {
            return Context.AddSolutionComponent(componentId, componentType, solutionUniqueName, addRequiredComponents);
        }

        public void AddSubstituteProduct(Guid productId, Guid substituteId)
        {
            Context.AddSubstituteProduct(productId, substituteId);
        }

        public Guid AddToQueue(Microsoft.Xrm.Sdk.EntityReference target, Guid sourceQueueId, Guid destinationQueueId, Microsoft.Xrm.Sdk.Entity queueItemProperties)
        {
            return Context.AddToQueue(target, sourceQueueId, destinationQueueId, queueItemProperties);
        }

        public void Assign(Microsoft.Xrm.Sdk.EntityReference target, Microsoft.Xrm.Sdk.EntityReference assignee)
        {
            Context.Assign(target, assignee);
        }

        public void AssociateEntities(Microsoft.Xrm.Sdk.EntityReference moniker1, Microsoft.Xrm.Sdk.EntityReference moniker2, string relationshipName)
        {
            Context.AssociateEntities(moniker1, moniker2, relationshipName);
        }

        public void AutoMapEntity(Guid entityMapId)
        {
            Context.AutoMapEntity(entityMapId);
        }

        public TResponse BackgroundSendEmail<TResponse>(Microsoft.Xrm.Sdk.Query.QueryBase query) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.BackgroundSendEmail<TResponse>(query);
        }

        public TResult Book<TResult>(Microsoft.Xrm.Sdk.Entity target)
        {
            return Context.Book<TResult>(target);
        }

        public Guid BulkDelete(Microsoft.Xrm.Sdk.Query.QueryExpression[] querySet, string jobName, bool sendEmailNotification, Guid[] toRecipients, Guid[] cCRecipients, string recurrencePattern, DateTime startDateTime, Guid? sourceImportId)
        {
            return Context.BulkDelete(querySet, jobName, sendEmailNotification, toRecipients, cCRecipients, recurrencePattern, startDateTime, sourceImportId);
        }

        public Guid BulkDetectDuplicates(Microsoft.Xrm.Sdk.Query.QueryBase query, string jobName, bool sendEmailNotification, Guid templateId, Guid[] toRecipients, Guid[] cCRecipients, string recurrencePattern, DateTime recurrenceStartTime)
        {
            return Context.BulkDetectDuplicates(query, jobName, sendEmailNotification, templateId, toRecipients, cCRecipients, recurrencePattern, recurrenceStartTime);
        }

        public void BulkOperationStatusClose(Guid bulkOperationId, int failureCount, int successCount, int statusReason, int errorCode)
        {
            Context.BulkOperationStatusClose(bulkOperationId, failureCount, successCount, statusReason, errorCode);
        }

        public decimal CalculateActualValueOpportunity(Guid opportunityId)
        {
            return Context.CalculateActualValueOpportunity(opportunityId);
        }

        public long CalculateTotalTimeIncident(Guid incidentId)
        {
            return Context.CalculateTotalTimeIncident(incidentId);
        }

        public void CancelContract(Guid contractId, DateTime cancelDate, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.CancelContract(contractId, cancelDate, status);
        }

        public void CancelSalesOrder(Microsoft.Xrm.Sdk.Entity orderClose, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.CancelSalesOrder(orderClose, status);
        }

        public TResponse CheckIncomingEmail<TResponse>(string messageId, string subject, string from, string to, string cc, string bcc) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.CheckIncomingEmail<TResponse>(messageId, subject, from, to, cc, bcc);
        }

        public TResponse CheckPromoteEmail<TResponse>(string messageId, string subject) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.CheckPromoteEmail<TResponse>(messageId, subject);
        }

        public void CleanUpBulkOperation(Guid bulkOperationId, int bulkOperationSource)
        {
            Context.CleanUpBulkOperation(bulkOperationId, bulkOperationSource);
        }

        public Microsoft.Xrm.Sdk.Entity CloneContract(Guid contractId, bool includeCanceledLines)
        {
            return Context.CloneContract(contractId, includeCanceledLines);
        }

        public void CloseIncident(Microsoft.Xrm.Sdk.Entity incidentResolution, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.CloseIncident(incidentResolution, status);
        }

        public void CloseIncident(Microsoft.Xrm.Sdk.Entity incidentResolution, int status)
        {
            Context.CloseIncident(incidentResolution, status);
        }

        public void CloseQuote(Microsoft.Xrm.Sdk.Entity quoteClose, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.CloseQuote(quoteClose, status);
        }

        public Guid CompoundCreate(Microsoft.Xrm.Sdk.Entity entity, Microsoft.Xrm.Sdk.EntityCollection childEntities)
        {
            return Context.CompoundCreate(entity, childEntities);
        }

        public void CompoundUpdate(Microsoft.Xrm.Sdk.Entity entity, Microsoft.Xrm.Sdk.EntityCollection childEntities)
        {
            Context.CompoundUpdate(entity, childEntities);
        }

        public void CompoundUpdateDuplicateDetectionRule(Microsoft.Xrm.Sdk.Entity entity, Microsoft.Xrm.Sdk.EntityCollection childEntities)
        {
            Context.CompoundUpdateDuplicateDetectionRule(entity, childEntities);
        }

        public void ConvertKitToProduct(Guid kitId)
        {
            Context.ConvertKitToProduct(kitId);
        }

        public void ConvertProductToKit(Guid productId)
        {
            Context.ConvertProductToKit(productId);
        }

        public Microsoft.Xrm.Sdk.Entity ConvertQuoteToSalesOrder(Guid quoteId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.ConvertQuoteToSalesOrder(quoteId, columnSet);
        }

        public Microsoft.Xrm.Sdk.Entity ConvertSalesOrderToInvoice(Guid salesOrderId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.ConvertSalesOrderToInvoice(salesOrderId, columnSet);
        }

        public Guid CopyCampaign(Guid baseCampaign, bool saveAsTemplate)
        {
            return Context.CopyCampaign(baseCampaign, saveAsTemplate);
        }

        public Guid CopyCampaignResponse(Microsoft.Xrm.Sdk.EntityReference campaignResponseId)
        {
            return Context.CopyCampaignResponse(campaignResponseId);
        }

        public Guid CopyDynamicListToStatic(Guid listId)
        {
            return Context.CopyDynamicListToStatic(listId);
        }

        public void CopyMembersList(Guid sourceListId, Guid targetListId)
        {
            Context.CopyMembersList(sourceListId, targetListId);
        }

        public Guid CopySystemForm(Microsoft.Xrm.Sdk.Entity target, Guid sourceId)
        {
            return Context.CopySystemForm(target, sourceId);
        }

        public Guid CreateActivitiesList(Guid listId, string friendlyName, Microsoft.Xrm.Sdk.Entity activity, Guid templateId, bool propagate, object ownershipOptions, Microsoft.Xrm.Sdk.EntityReference owner, bool sendEmail, bool postWorkflowEvent, Guid queueId)
        {
            return Context.CreateActivitiesList(listId, friendlyName, activity, templateId, propagate, ownershipOptions, owner, sendEmail, postWorkflowEvent, queueId);
        }

        public Guid CreateException(Microsoft.Xrm.Sdk.Entity target, DateTime originalStartDate, bool isDeleted)
        {
            return Context.CreateException(target, originalStartDate, isDeleted);
        }

        public bool CreateInstance(Microsoft.Xrm.Sdk.Entity target, int count)
        {
            return Context.CreateInstance(target, count);
        }

        public Guid CreateWorkflowFromTemplate(string workflowName, Guid workflowTemplateId)
        {
            return Context.CreateWorkflowFromTemplate(workflowName, workflowTemplateId);
        }

        public int DeleteAuditData(DateTime endDate)
        {
            return Context.DeleteAuditData(endDate);
        }

        public void DeleteOpenInstances(Microsoft.Xrm.Sdk.Entity target, DateTime seriesEndDate, int stateOfPastInstances)
        {
            Context.DeleteOpenInstances(target, seriesEndDate, stateOfPastInstances);
        }

        public Guid DeliverIncomingEmail(string messageId, string subject, string from, string to, string cc, string bcc, DateTime receivedOn, string submittedBy, string importance, string body, Microsoft.Xrm.Sdk.EntityCollection attachments)
        {
            return Context.DeliverIncomingEmail(messageId, subject, from, to, cc, bcc, receivedOn, submittedBy, importance, body, attachments);
        }

        public Guid DeliverPromoteEmail(Guid emailId, string messageId, string subject, string from, string to, string cc, string bcc, DateTime receivedOn, string submittedBy, string importance, string body, Microsoft.Xrm.Sdk.EntityCollection attachments, Microsoft.Xrm.Sdk.Entity extraProperties)
        {
            return Context.DeliverPromoteEmail(emailId, messageId, subject, from, to, cc, bcc, receivedOn, submittedBy, importance, body, attachments, extraProperties);
        }

        public void DeprovisionLanguage(int language)
        {
            Context.DeprovisionLanguage(language);
        }

        public void DisassociateEntities(Microsoft.Xrm.Sdk.EntityReference moniker1, Microsoft.Xrm.Sdk.EntityReference moniker2, string relationshipName)
        {
            Context.DisassociateEntities(moniker1, moniker2, relationshipName);
        }

        public Guid DistributeCampaignActivity(Guid campaignActivityId, bool propagate, Microsoft.Xrm.Sdk.Entity activity, Guid templateId, object ownershipOptions, Microsoft.Xrm.Sdk.EntityReference owner, bool sendEmail, Guid queueId)
        {
            return Context.DistributeCampaignActivity(campaignActivityId, propagate, activity, templateId, ownershipOptions, owner, sendEmail, queueId);
        }

        public string DownloadReportDefinition(Guid reportId)
        {
            return Context.DownloadReportDefinition(reportId);
        }

        public string ExecuteByIdSavedQuery(Guid entityId)
        {
            return Context.ExecuteByIdSavedQuery(entityId);
        }

        public string ExecuteByIdUserQuery(Microsoft.Xrm.Sdk.EntityReference entityId)
        {
            return Context.ExecuteByIdUserQuery(entityId);
        }

        public string ExecuteFetch(string fetchXml)
        {
            return Context.ExecuteFetch(fetchXml);
        }

        public Guid ExecuteWorkflow(Guid entityId, Guid workflowId)
        {
            return Context.ExecuteWorkflow(entityId, workflowId);
        }

        public TResult ExpandCalendar<TResult>(Guid calendarId, DateTime start, DateTime end)
        {
            return Context.ExpandCalendar<TResult>(calendarId, start, end);
        }

        public byte[] ExportSolution(string solutionName, bool managed, bool exportAutoNumberingSettings, bool exportCalendarSettings, bool exportCustomizationSettings, bool exportEmailTrackingSettings, bool exportGeneralSettings, bool exportMarketingSettings, bool exportOutlookSynchronizationSettings, bool exportRelationshipRoles, bool exportIsvConfig)
        {
            return Context.ExportSolution(solutionName, managed, exportAutoNumberingSettings, exportCalendarSettings, exportCustomizationSettings, exportEmailTrackingSettings, exportGeneralSettings, exportMarketingSettings, exportOutlookSynchronizationSettings, exportRelationshipRoles, exportIsvConfig);
        }

        public byte[] ExportTranslation(string solutionName)
        {
            return Context.ExportTranslation(solutionName);
        }

        public Microsoft.Xrm.Sdk.Query.QueryExpression FetchXmlToQueryExpression(string fetchXml)
        {
            return Context.FetchXmlToQueryExpression(fetchXml);
        }

        public bool FindParentResourceGroup(Guid parentId, Guid[] childrenIds)
        {
            return Context.FindParentResourceGroup(parentId, childrenIds);
        }

        public void FulfillSalesOrder(Microsoft.Xrm.Sdk.Entity orderClose, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.FulfillSalesOrder(orderClose, status);
        }

        public Microsoft.Xrm.Sdk.Entity GenerateInvoiceFromOpportunity(Guid opportunityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.GenerateInvoiceFromOpportunity(opportunityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.Entity GenerateQuoteFromOpportunity(Guid opportunityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.GenerateQuoteFromOpportunity(opportunityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.Entity GenerateSalesOrderFromOpportunity(Guid opportunityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.GenerateSalesOrderFromOpportunity(opportunityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.EntityCollection GetAllTimeZonesWithDisplayName(int localeId)
        {
            return Context.GetAllTimeZonesWithDisplayName(localeId);
        }

        public string GetDecryptionKey()
        {
            return Context.GetDecryptionKey();
        }

        public string[] GetDistinctValuesImportFile(Guid importFileId, int columnNumber, int pageNumber, int recordsPerPage)
        {
            return Context.GetDistinctValuesImportFile(importFileId, columnNumber, pageNumber, recordsPerPage);
        }

        public string[] GetHeaderColumnsImportFile(Guid importFileId)
        {
            return Context.GetHeaderColumnsImportFile(importFileId);
        }

        public void GetInvoiceProductsFromOpportunity(Guid opportunityId, Guid invoiceId)
        {
            Context.GetInvoiceProductsFromOpportunity(opportunityId, invoiceId);
        }

        public int GetQuantityDecimal(Microsoft.Xrm.Sdk.EntityReference target, Guid productId, Guid uoMId)
        {
            return Context.GetQuantityDecimal(target, productId, uoMId);
        }

        public void GetQuoteProductsFromOpportunity(Guid opportunityId, Guid quoteId)
        {
            Context.GetQuoteProductsFromOpportunity(opportunityId, quoteId);
        }

        public int GetReportHistoryLimit(Guid reportId)
        {
            return Context.GetReportHistoryLimit(reportId);
        }

        public void GetSalesOrderProductsFromOpportunity(Guid opportunityId, Guid salesOrderId)
        {
            Context.GetSalesOrderProductsFromOpportunity(opportunityId, salesOrderId);
        }

        public int GetTimeZoneCodeByLocalizedName(string localizedStandardName, int localeId)
        {
            return Context.GetTimeZoneCodeByLocalizedName(localizedStandardName, localeId);
        }

        public string GetTrackingTokenEmail(string subject)
        {
            return Context.GetTrackingTokenEmail(subject);
        }

        public void GrantAccess(Microsoft.Xrm.Sdk.EntityReference target, object principalAccess)
        {
            Context.GrantAccess(target, principalAccess);
        }

        public Guid ImportRecordsImport(Guid importId)
        {
            return Context.ImportRecordsImport(importId);
        }

        public void ImportSolution(bool overwriteUnmanagedCustomizations, bool publishWorkflows, byte[] customizationFile, Guid importJobId)
        {
            Context.ImportSolution(overwriteUnmanagedCustomizations, publishWorkflows, customizationFile, importJobId);
        }

        public void ImportTranslation(byte[] translationFile, Guid importJobId)
        {
            Context.ImportTranslation(translationFile, importJobId);
        }

        public Microsoft.Xrm.Sdk.Entity InitializeFrom(Microsoft.Xrm.Sdk.EntityReference entityMoniker, string targetEntityName, object targetFieldType)
        {
            return Context.InitializeFrom(entityMoniker, targetEntityName, targetFieldType);
        }

        public void InstallSampleData()
        {
            Context.InstallSampleData();
        }

        public void InstantiateFilters(Microsoft.Xrm.Sdk.EntityReferenceCollection templateCollection, Guid userId)
        {
            Context.InstantiateFilters(templateCollection, userId);
        }

        public Microsoft.Xrm.Sdk.EntityCollection InstantiateTemplate(Guid templateId, string objectType, Guid objectId)
        {
            return Context.InstantiateTemplate(templateId, objectType, objectId);
        }

        public bool IsBackOfficeInstalled()
        {
            return Context.IsBackOfficeInstalled();
        }

        public bool IsComponentCustomizable(Guid componentId, int componentType)
        {
            return Context.IsComponentCustomizable(componentId, componentType);
        }

        public bool IsValidStateTransition(Microsoft.Xrm.Sdk.EntityReference entity, string newState, int newStatus)
        {
            return Context.IsValidStateTransition(entity, newState, newStatus);
        }

        public DateTime LocalTimeFromUtcTime(int timeZoneCode, DateTime utcTime)
        {
            return Context.LocalTimeFromUtcTime(timeZoneCode, utcTime);
        }

        public void LockInvoicePricing(Guid invoiceId)
        {
            Context.LockInvoicePricing(invoiceId);
        }

        public void LockSalesOrderPricing(Guid salesOrderId)
        {
            Context.LockSalesOrderPricing(salesOrderId);
        }

        public void LogFailureBulkOperation(Guid bulkOperationId, Guid regardingObjectId, int regardingObjectTypeCode, int errorCode, string message, string additionalInfo)
        {
            Context.LogFailureBulkOperation(bulkOperationId, regardingObjectId, regardingObjectTypeCode, errorCode, message, additionalInfo);
        }

        public void LogSuccessBulkOperation(Guid bulkOperationId, Guid regardingObjectId, int regardingObjectTypeCode, Guid createdObjectId, int createdObjectTypeCode, string additionalInfo)
        {
            Context.LogSuccessBulkOperation(bulkOperationId, regardingObjectId, regardingObjectTypeCode, createdObjectId, createdObjectTypeCode, additionalInfo);
        }

        public void LoseOpportunity(Microsoft.Xrm.Sdk.Entity opportunityClose, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.LoseOpportunity(opportunityClose, status);
        }

        public void LoseOpportunity(Microsoft.Xrm.Sdk.Entity opportunityClose, int status)
        {
            Context.LoseOpportunity(opportunityClose, status);
        }

        public void MakeAvailableToOrganizationReport(Guid reportId)
        {
            Context.MakeAvailableToOrganizationReport(reportId);
        }

        public void MakeAvailableToOrganizationTemplate(Guid templateId)
        {
            Context.MakeAvailableToOrganizationTemplate(templateId);
        }

        public void MakeUnavailableToOrganizationReport(Guid reportId)
        {
            Context.MakeUnavailableToOrganizationReport(reportId);
        }

        public void MakeUnavailableToOrganizationTemplate(Guid templateId)
        {
            Context.MakeUnavailableToOrganizationTemplate(templateId);
        }

        public void Merge(Microsoft.Xrm.Sdk.EntityReference target, Guid subordinateId, Microsoft.Xrm.Sdk.Entity updateContent, bool performParentingChecks)
        {
            Context.Merge(target, subordinateId, updateContent, performParentingChecks);
        }

        public void ModifyAccess(Microsoft.Xrm.Sdk.EntityReference target, object principalAccess)
        {
            Context.ModifyAccess(target, principalAccess);
        }

        public Guid ParseImport(Guid importId)
        {
            return Context.ParseImport(importId);
        }

        public void ProcessInboundEmail(Guid inboundEmailActivity)
        {
            Context.ProcessInboundEmail(inboundEmailActivity);
        }

        public int ProcessOneMemberBulkOperation(Guid bulkOperationId, Microsoft.Xrm.Sdk.Entity entity, int bulkOperationSource)
        {
            return Context.ProcessOneMemberBulkOperation(bulkOperationId, entity, bulkOperationSource);
        }

        public Guid PropagateByExpression(Microsoft.Xrm.Sdk.Query.QueryBase queryExpression, string friendlyName, bool executeImmediately, Microsoft.Xrm.Sdk.Entity activity, Guid templateId, object ownershipOptions, bool postWorkflowEvent, Microsoft.Xrm.Sdk.EntityReference owner, bool sendEmail, Guid queueId)
        {
            return Context.PropagateByExpression(queryExpression, friendlyName, executeImmediately, activity, templateId, ownershipOptions, postWorkflowEvent, owner, sendEmail, queueId);
        }

        public void ProvisionLanguage(int language)
        {
            Context.ProvisionLanguage(language);
        }

        public void PublishAllXml()
        {
            Context.PublishAllXml();
        }

        public Guid PublishDuplicateRule(Guid duplicateRuleId)
        {
            return Context.PublishDuplicateRule(duplicateRuleId);
        }

        public void PublishXml(string parameterXml)
        {
            Context.PublishXml(parameterXml);
        }

        public Microsoft.Xrm.Sdk.EntityReferenceCollection QualifyLead(Microsoft.Xrm.Sdk.EntityReference leadId, bool createAccount, bool createContact, bool createOpportunity, Microsoft.Xrm.Sdk.EntityReference opportunityCurrencyId, Microsoft.Xrm.Sdk.EntityReference opportunityCustomerId, Microsoft.Xrm.Sdk.EntityReference sourceCampaignId, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            return Context.QualifyLead(leadId, createAccount, createContact, createOpportunity, opportunityCurrencyId, opportunityCustomerId, sourceCampaignId, status);
        }

        public void QualifyMemberList(Guid listId, Guid[] membersId, bool overrideorRemove)
        {
            Context.QualifyMemberList(listId, membersId, overrideorRemove);
        }

        public string QueryExpressionToFetchXml(Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.QueryExpressionToFetchXml(query);
        }

        public TResult QueryMultipleSchedules<TResult>(Guid[] resourceIds, DateTime start, DateTime end, object timeCodes)
        {
            return Context.QueryMultipleSchedules<TResult>(resourceIds, start, end, timeCodes);
        }

        public TResult QuerySchedule<TResult>(Guid resourceId, DateTime start, DateTime end, object timeCodes)
        {
            return Context.QuerySchedule<TResult>(resourceId, start, end, timeCodes);
        }

        public void ReassignObjectsOwner(Microsoft.Xrm.Sdk.EntityReference fromPrincipal, Microsoft.Xrm.Sdk.EntityReference toPrincipal)
        {
            Context.ReassignObjectsOwner(fromPrincipal, toPrincipal);
        }

        public void ReassignObjectsSystemUser(Guid userId, Microsoft.Xrm.Sdk.EntityReference reassignPrincipal)
        {
            Context.ReassignObjectsSystemUser(userId, reassignPrincipal);
        }

        public void Recalculate(Microsoft.Xrm.Sdk.EntityReference target)
        {
            Context.Recalculate(target);
        }

        public void RemoveItemCampaign(Guid campaignId, Guid entityId)
        {
            Context.RemoveItemCampaign(campaignId, entityId);
        }

        public void RemoveItemCampaignActivity(Guid campaignActivityId, Guid itemId)
        {
            Context.RemoveItemCampaignActivity(campaignActivityId, itemId);
        }

        public void RemoveMemberList(Guid listId, Guid entityId)
        {
            Context.RemoveMemberList(listId, entityId);
        }

        public void RemoveMembersTeam(Guid teamId, Guid[] memberIds)
        {
            Context.RemoveMembersTeam(teamId, memberIds);
        }

        public void RemoveParent(Microsoft.Xrm.Sdk.EntityReference target)
        {
            Context.RemoveParent(target);
        }

        public void RemovePrivilegeRole(Guid roleId, Guid privilegeId)
        {
            Context.RemovePrivilegeRole(roleId, privilegeId);
        }

        public void RemoveProductFromKit(Guid kitId, Guid productId)
        {
            Context.RemoveProductFromKit(kitId, productId);
        }

        public void RemoveRelated(Microsoft.Xrm.Sdk.EntityReference[] target)
        {
            Context.RemoveRelated(target);
        }

        public Guid RemoveSolutionComponent(Guid componentId, int componentType, string solutionUniqueName)
        {
            return Context.RemoveSolutionComponent(componentId, componentType, solutionUniqueName);
        }

        public void RemoveSubstituteProduct(Guid productId, Guid substituteId)
        {
            Context.RemoveSubstituteProduct(productId, substituteId);
        }

        public Microsoft.Xrm.Sdk.Entity RenewContract(Guid contractId, int status, bool includeCanceledLines)
        {
            return Context.RenewContract(contractId, status, includeCanceledLines);
        }

        public void ReplacePrivilegesRole(Guid roleId, object privileges)
        {
            Context.ReplacePrivilegesRole(roleId, privileges);
        }

        public TResult Reschedule<TResult>(Microsoft.Xrm.Sdk.Entity target)
        {
            return Context.Reschedule<TResult>(target);
        }

        public void ResetUserFilters(int queryType)
        {
            Context.ResetUserFilters(queryType);
        }

        public TResponse RetrieveAbsoluteAndSiteCollectionUrl<TResponse>(Microsoft.Xrm.Sdk.EntityReference target) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.RetrieveAbsoluteAndSiteCollectionUrl<TResponse>(target);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveAllChildUsersSystemUser(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveAllChildUsersSystemUser(entityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.Metadata.EntityMetadata[] RetrieveAllEntities(Microsoft.Xrm.Sdk.Metadata.EntityFilters entityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Default, bool retrieveAsIfPublished = false)
        {
            return Context.RetrieveAllEntities(entityFilters, retrieveAsIfPublished);
        }

        public byte[] RetrieveApplicationRibbon()
        {
            return Context.RetrieveApplicationRibbon();
        }

        public Microsoft.Xrm.Sdk.Metadata.AttributeMetadata RetrieveAttribute(string entityLogicalName, string logicalName, bool retrieveAsIfPublished = false)
        {
            return Context.RetrieveAttribute(entityLogicalName, logicalName, retrieveAsIfPublished);
        }

        public TResult RetrieveAttributeChangeHistory<TResult>(Microsoft.Xrm.Sdk.EntityReference target, string attributeLogicalName, Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo)
        {
            return Context.RetrieveAttributeChangeHistory<TResult>(target, attributeLogicalName, pagingInfo);
        }

        public TResult RetrieveAuditDetails<TResult>(Guid auditId)
        {
            return Context.RetrieveAuditDetails<TResult>(auditId);
        }

        public TResult RetrieveAuditPartitionList<TResult>()
        {
            return Context.RetrieveAuditPartitionList<TResult>();
        }

        public int[] RetrieveAvailableLanguages()
        {
            return Context.RetrieveAvailableLanguages();
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveBusinessHierarchyBusinessUnit(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveBusinessHierarchyBusinessUnit(entityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveByGroupResource(Guid resourceGroupId, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveByGroupResource(resourceGroupId, query);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveByResourceResourceGroup(Guid resourceId, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveByResourceResourceGroup(resourceId, query);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveByResourcesService(Guid[] resourceIds, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveByResourcesService(resourceIds, query);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveByTopIncidentProductKbArticle(Guid productId)
        {
            return Context.RetrieveByTopIncidentProductKbArticle(productId);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveByTopIncidentSubjectKbArticle(Guid subjectId)
        {
            return Context.RetrieveByTopIncidentSubjectKbArticle(subjectId);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveDependenciesForDelete(Guid objectId, int componentType)
        {
            return Context.RetrieveDependenciesForDelete(objectId, componentType);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveDependenciesForUninstall(string solutionUniqueName)
        {
            return Context.RetrieveDependenciesForUninstall(solutionUniqueName);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveDependentComponents(Guid objectId, int componentType)
        {
            return Context.RetrieveDependentComponents(objectId, componentType);
        }

        public string RetrieveDeploymentLicenseType()
        {
            return Context.RetrieveDeploymentLicenseType();
        }

        public int[] RetrieveDeprovisionedLanguages()
        {
            return Context.RetrieveDeprovisionedLanguages();
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveDuplicates(Microsoft.Xrm.Sdk.Entity businessEntity, string matchingEntityName, Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo)
        {
            return Context.RetrieveDuplicates(businessEntity, matchingEntityName, pagingInfo);
        }

        public Microsoft.Xrm.Sdk.Metadata.EntityMetadata RetrieveEntity(string logicalName, Microsoft.Xrm.Sdk.Metadata.EntityFilters entityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Default, bool retrieveAsIfPublished = false)
        {
            return Context.RetrieveEntity(logicalName, entityFilters, retrieveAsIfPublished);
        }

        public byte[] RetrieveEntityRibbon(string entityName, object ribbonLocationFilter)
        {
            return Context.RetrieveEntityRibbon(entityName, ribbonLocationFilter);
        }

        public decimal RetrieveExchangeRate(Guid transactionCurrencyId)
        {
            return Context.RetrieveExchangeRate(transactionCurrencyId);
        }

        public Microsoft.Xrm.Sdk.EntityReferenceCollection RetrieveFilteredForms(string entityLogicalName, Microsoft.Xrm.Sdk.OptionSetValue formType, Guid systemUserId)
        {
            return Context.RetrieveFilteredForms(entityLogicalName, formType, systemUserId);
        }

        public string RetrieveFormattedImportJobResults(Guid importJobId)
        {
            return Context.RetrieveFormattedImportJobResults(importJobId);
        }

        public TResponse RetrieveFormXml<TResponse>(string entityName) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.RetrieveFormXml<TResponse>(entityName);
        }

        public int[] RetrieveInstalledLanguagePacks()
        {
            return Context.RetrieveInstalledLanguagePacks();
        }

        public string RetrieveInstalledLanguagePackVersion(int language)
        {
            return Context.RetrieveInstalledLanguagePackVersion(language);
        }

        public TResponse RetrieveLicenseInfo<TResponse>(int accessMode) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.RetrieveLicenseInfo<TResponse>(accessMode);
        }

        public Microsoft.Xrm.Sdk.Label RetrieveLocLabels(Microsoft.Xrm.Sdk.EntityReference entityMoniker, string attributeName, bool includeUnpublished)
        {
            return Context.RetrieveLocLabels(entityMoniker, attributeName, includeUnpublished);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveMembersBulkOperation(Guid bulkOperationId, int bulkOperationSource, int entitySource, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveMembersBulkOperation(bulkOperationId, bulkOperationSource, entitySource, query);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveMembersTeam(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet memberColumnSet)
        {
            return Context.RetrieveMembersTeam(entityId, memberColumnSet);
        }

        public TResult RetrieveMissingComponents<TResult>(byte[] customizationFile)
        {
            return Context.RetrieveMissingComponents<TResult>(customizationFile);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveMissingDependencies(string solutionUniqueName)
        {
            return Context.RetrieveMissingDependencies(solutionUniqueName);
        }

        public Microsoft.Xrm.Sdk.Messages.RetrieveMultipleResponse RetrieveMultiple(Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest request)
        {
            return Context.RetrieveMultiple(request);
        }

        public TResult RetrieveOrganizationResources<TResult>()
        {
            return Context.RetrieveOrganizationResources<TResult>();
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveParentGroupsResourceGroup(Guid resourceGroupId, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveParentGroupsResourceGroup(resourceGroupId, query);
        }

        public string[][] RetrieveParsedDataImportFile(Guid importFileId, Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo)
        {
            return Context.RetrieveParsedDataImportFile(importFileId, pagingInfo);
        }

        public TResult RetrievePrincipalAccess<TResult>(Microsoft.Xrm.Sdk.EntityReference target, Microsoft.Xrm.Sdk.EntityReference principal)
        {
            return Context.RetrievePrincipalAccess<TResult>(target, principal);
        }

        public Microsoft.Xrm.Sdk.AttributePrivilegeCollection RetrievePrincipalAttributePrivileges(Microsoft.Xrm.Sdk.EntityReference principal)
        {
            return Context.RetrievePrincipalAttributePrivileges(principal);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrievePrivilegeSet()
        {
            return Context.RetrievePrivilegeSet();
        }

        public string RetrieveProvisionedLanguagePackVersion(int language)
        {
            return Context.RetrieveProvisionedLanguagePackVersion(language);
        }

        public int[] RetrieveProvisionedLanguages()
        {
            return Context.RetrieveProvisionedLanguages();
        }

        public TResult RetrieveRecordChangeHistory<TResult>(Microsoft.Xrm.Sdk.EntityReference target, Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo)
        {
            return Context.RetrieveRecordChangeHistory<TResult>(target, pagingInfo);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveRequiredComponents(Guid objectId, int componentType)
        {
            return Context.RetrieveRequiredComponents(objectId, componentType);
        }

        public TResult RetrieveRolePrivilegesRole<TResult>(Guid roleId)
        {
            return Context.RetrieveRolePrivilegesRole<TResult>(roleId);
        }

        public TResult RetrieveSharedPrincipalsAndAccess<TResult>(Microsoft.Xrm.Sdk.EntityReference target)
        {
            return Context.RetrieveSharedPrincipalsAndAccess<TResult>(target);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveSubGroupsResourceGroup(Guid resourceGroupId, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveSubGroupsResourceGroup(resourceGroupId, query);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveSubsidiaryTeamsBusinessUnit(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveSubsidiaryTeamsBusinessUnit(entityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveSubsidiaryUsersBusinessUnit(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveSubsidiaryUsersBusinessUnit(entityId, columnSet);
        }

        public TResult RetrieveTeamPrivileges<TResult>(Guid teamId)
        {
            return Context.RetrieveTeamPrivileges<TResult>(teamId);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveTeamsSystemUser(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveTeamsSystemUser(entityId, columnSet);
        }

        public Microsoft.Xrm.Sdk.Entity RetrieveUnpublished(Microsoft.Xrm.Sdk.EntityReference target, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveUnpublished(target, columnSet);
        }

        public Microsoft.Xrm.Sdk.EntityCollection RetrieveUnpublishedMultiple(Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            return Context.RetrieveUnpublishedMultiple(query);
        }

        public TResult RetrieveUserPrivileges<TResult>(Guid userId)
        {
            return Context.RetrieveUserPrivileges<TResult>(userId);
        }

        public Microsoft.Xrm.Sdk.Entity RetrieveUserSettingsSystemUser(Guid entityId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.RetrieveUserSettingsSystemUser(entityId, columnSet);
        }

        public string RetrieveVersion()
        {
            return Context.RetrieveVersion();
        }

        public Microsoft.Xrm.Sdk.Entity ReviseQuote(Guid quoteId, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet)
        {
            return Context.ReviseQuote(quoteId, columnSet);
        }

        public void RevokeAccess(Microsoft.Xrm.Sdk.EntityReference target, Microsoft.Xrm.Sdk.EntityReference revokee)
        {
            Context.RevokeAccess(target, revokee);
        }

        public Microsoft.Xrm.Sdk.EntityCollection Rollup(Microsoft.Xrm.Sdk.EntityReference target, Microsoft.Xrm.Sdk.Query.QueryBase query, object rollupType)
        {
            return Context.Rollup(target, query, rollupType);
        }

        public TResult Search<TResult>(object appointmentRequest)
        {
            return Context.Search<TResult>(appointmentRequest);
        }

        public Microsoft.Xrm.Sdk.EntityCollection SearchByBodyKbArticle(string searchText, Guid subjectId, bool useInflection, Microsoft.Xrm.Sdk.Query.QueryBase queryExpression)
        {
            return Context.SearchByBodyKbArticle(searchText, subjectId, useInflection, queryExpression);
        }

        public Microsoft.Xrm.Sdk.EntityCollection SearchByKeywordsKbArticle(string searchText, Guid subjectId, bool useInflection, Microsoft.Xrm.Sdk.Query.QueryBase queryExpression)
        {
            return Context.SearchByKeywordsKbArticle(searchText, subjectId, useInflection, queryExpression);
        }

        public Microsoft.Xrm.Sdk.EntityCollection SearchByTitleKbArticle(string searchText, Guid subjectId, bool useInflection, Microsoft.Xrm.Sdk.Query.QueryBase queryExpression)
        {
            return Context.SearchByTitleKbArticle(searchText, subjectId, useInflection, queryExpression);
        }

        public void SendBulkMail(Microsoft.Xrm.Sdk.EntityReference sender, Guid templateId, string regardingType, Guid regardingId, Microsoft.Xrm.Sdk.Query.QueryBase query)
        {
            Context.SendBulkMail(sender, templateId, regardingType, regardingId, query);
        }

        public string SendEmail(Guid emailId, bool issueSend, string trackingToken)
        {
            return Context.SendEmail(emailId, issueSend, trackingToken);
        }

        public Guid SendEmailFromTemplate(Guid templateId, string regardingType, Guid regardingId, Microsoft.Xrm.Sdk.Entity target)
        {
            return Context.SendEmailFromTemplate(templateId, regardingType, regardingId, target);
        }

        public void SendFax(Guid faxId, bool issueSend)
        {
            Context.SendFax(faxId, issueSend);
        }

        public void SendTemplate(Guid templateId, Microsoft.Xrm.Sdk.EntityReference sender, string recipientType, Guid[] recipientIds, string regardingType, Guid regardingId)
        {
            Context.SendTemplate(templateId, sender, recipientType, recipientIds, regardingType, regardingId);
        }

        public void SetBusinessEquipment(Guid equipmentId, Guid businessUnitId)
        {
            Context.SetBusinessEquipment(equipmentId, businessUnitId);
        }

        public void SetBusinessSystemUser(Guid userId, Guid businessId, Microsoft.Xrm.Sdk.EntityReference reassignPrincipal)
        {
            Context.SetBusinessSystemUser(userId, businessId, reassignPrincipal);
        }

        public void SetLocLabels(Microsoft.Xrm.Sdk.EntityReference entityMoniker, string attributeName, Microsoft.Xrm.Sdk.LocalizedLabel[] labels)
        {
            Context.SetLocLabels(entityMoniker, attributeName, labels);
        }

        public void SetParentBusinessUnit(Guid businessUnitId, Guid parentId)
        {
            Context.SetParentBusinessUnit(businessUnitId, parentId);
        }

        public void SetParentSystemUser(Guid userId, Guid parentId, bool keepChildUsers)
        {
            Context.SetParentSystemUser(userId, parentId, keepChildUsers);
        }

        public void SetParentTeam(Guid teamId, Guid businessId)
        {
            Context.SetParentTeam(teamId, businessId);
        }

        public void SetRelated(Microsoft.Xrm.Sdk.EntityReference[] target)
        {
            Context.SetRelated(target);
        }

        public void SetReportRelated(Guid reportId, int[] entities, int[] categories, int[] visibility)
        {
            Context.SetReportRelated(reportId, entities, categories, visibility);
        }

        public void SetState(Microsoft.Xrm.Sdk.EntityReference entityMoniker, Microsoft.Xrm.Sdk.OptionSetValue state, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.SetState(entityMoniker, state, status);
        }

        public void SetState(int state, int status, Microsoft.Xrm.Sdk.EntityReference entityMoniker)
        {
            Context.SetState(state, status, entityMoniker);
        }

        public void SetState(int state, int status, Microsoft.Xrm.Sdk.Entity entity)
        {
            Context.SetState(state, status, entity);
        }

        public void StatusUpdateBulkOperation(Guid bulkOperationId, int failureCount, int successCount)
        {
            Context.StatusUpdateBulkOperation(bulkOperationId, failureCount, successCount);
        }

        public Guid TransformImport(Guid importId)
        {
            return Context.TransformImport(importId);
        }

        public void TriggerServiceEndpointCheck(Microsoft.Xrm.Sdk.EntityReference entity)
        {
            Context.TriggerServiceEndpointCheck(entity);
        }

        public void UninstallSampleData()
        {
            Context.UninstallSampleData();
        }

        public void UnlockInvoicePricing(Guid invoiceId)
        {
            Context.UnlockInvoicePricing(invoiceId);
        }

        public void UnlockSalesOrderPricing(Guid salesOrderId)
        {
            Context.UnlockSalesOrderPricing(salesOrderId);
        }

        public void UnpublishDuplicateRule(Guid duplicateRuleId)
        {
            Context.UnpublishDuplicateRule(duplicateRuleId);
        }

        public void UpdateUserSettingsSystemUser(Guid userId, Microsoft.Xrm.Sdk.Entity settings)
        {
            Context.UpdateUserSettingsSystemUser(userId, settings);
        }

        public DateTime UtcTimeFromLocalTime(int timeZoneCode, DateTime localTime)
        {
            return Context.UtcTimeFromLocalTime(timeZoneCode, localTime);
        }

        public TResult Validate<TResult>(Microsoft.Xrm.Sdk.EntityCollection activities)
        {
            return Context.Validate<TResult>(activities);
        }

        public string ValidateRecurrenceRule(Microsoft.Xrm.Sdk.Entity target)
        {
            return Context.ValidateRecurrenceRule(target);
        }

        public void ValidateSavedQuery(string fetchXml, int queryType)
        {
            Context.ValidateSavedQuery(fetchXml, queryType);
        }

        public bool VerifyProcessStateData(Microsoft.Xrm.Sdk.EntityReference target, string processState)
        {
            return Context.VerifyProcessStateData(target, processState);
        }

        public TResponse WhoAmI<TResponse>() where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.WhoAmI<TResponse>();
        }

        public void WinOpportunity(Microsoft.Xrm.Sdk.Entity opportunityClose, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.WinOpportunity(opportunityClose, status);
        }

        public void WinOpportunity(Microsoft.Xrm.Sdk.Entity opportunityClose, int status)
        {
            Context.WinOpportunity(opportunityClose, status);
        }

        public void WinQuote(Microsoft.Xrm.Sdk.Entity quoteClose, Microsoft.Xrm.Sdk.OptionSetValue status)
        {
            Context.WinQuote(quoteClose, status);
        }

        #endregion

        #region Microsoft.Xrm.Client.OrganizationServiceContextExtensions
        /*
         * Microsoft.Xrm.Client.OrganizationServiceContextExtensions
         */
        public void AddLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.AddLink(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public void AddLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            Context.AddLink<TSource, TTarget>(source, propertySelector, target);
        }

        public void AddRelatedObject(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.AddRelatedObject(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public void AddRelatedObject<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, IEnumerable<TTarget>>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            Context.AddRelatedObject<TSource, TTarget>(source, propertySelector, target);
        }

        public void AddRelatedObject<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            Context.AddRelatedObject<TSource, TTarget>(source, propertySelector, target);
        }

        public T AttachClone<T>(T entity, bool includeRelatedEntities = false) where T : Microsoft.Xrm.Sdk.Entity
        {
            return Context.AttachClone<T>(entity, includeRelatedEntities);
        }

        public void AttachLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.AttachLink(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public void AttachLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            Context.AttachLink<TSource, TTarget>(source, propertySelector, target);
        }

        public void DeleteLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.DeleteLink(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public void DeleteLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            Context.DeleteLink<TSource, TTarget>(source, propertySelector, target);
        }

        public bool Detach(IEnumerable<Microsoft.Xrm.Sdk.Entity> entities)
        {
            return Context.Detach(entities);
        }

        public bool DetachLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            return Context.DetachLink(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public bool DetachLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            return Context.DetachLink<TSource, TTarget>(source, propertySelector, target);
        }

        public TResponse Execute<TResponse>(Microsoft.Xrm.Sdk.OrganizationRequest request) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse
        {
            return Context.Execute<TResponse>(request);
        }

        public void IsAttached(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.IsAttached(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public bool IsAttached<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, IEnumerable<TTarget>>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            return Context.IsAttached<TSource, TTarget>(source, propertySelector, target);
        }

        public bool IsAttached<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            return Context.IsAttached<TSource, TTarget>(source, propertySelector, target);
        }

        public void IsDeleted(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.IsDeleted(source, relationshipSchemaName, target, primaryEntityRole);
        }

        public bool IsDeleted<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity
        {
            return Context.IsDeleted<TSource, TTarget>(source, propertySelector, target);
        }

        public void LoadProperty(Microsoft.Xrm.Sdk.Entity entity, string relationshipSchemaName, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null)
        {
            Context.LoadProperty(entity, relationshipSchemaName, primaryEntityRole);
        }

        public void LoadProperty<TEntity>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, object>> propertySelector) where TEntity : Microsoft.Xrm.Sdk.Entity
        {
            Context.LoadProperty<TEntity>(entity, propertySelector);
        }

        public T MergeClone<T>(T entity, bool includeRelatedEntities = false) where T : Microsoft.Xrm.Sdk.Entity
        {
            return Context.MergeClone<T>(entity, includeRelatedEntities);
        }

        public void ReAttach(Microsoft.Xrm.Sdk.Entity entity)
        {
            Context.ReAttach(entity);
        }

        public bool TryAccessCache(Action<Microsoft.Xrm.Client.Services.IOrganizationServiceCache> action)
        {
            return Context.TryAccessCache(action);
        }

        public bool TryRemoveFromCache(Microsoft.Xrm.Sdk.Entity entity)
        {
            return Context.TryRemoveFromCache(entity);
        }

        public bool TryRemoveFromCache(Microsoft.Xrm.Sdk.EntityReference entity)
        {
            return Context.TryRemoveFromCache(entity);
        }

        public bool TryRemoveFromCache(Microsoft.Xrm.Sdk.OrganizationRequest request)
        {
            return Context.TryRemoveFromCache(request);
        }

        public bool TryRemoveFromCache(string cacheKey)
        {
            return Context.TryRemoveFromCache(cacheKey);
        }

        public bool TryRemoveFromCache(string entityLogicalName, Guid? id)
        {
            return Context.TryRemoveFromCache(entityLogicalName, id);
        }

        #endregion
    }
}
