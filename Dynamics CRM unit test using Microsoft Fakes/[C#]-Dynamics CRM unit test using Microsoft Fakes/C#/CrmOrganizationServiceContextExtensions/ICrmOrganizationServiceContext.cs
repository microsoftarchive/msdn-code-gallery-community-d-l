using System;

namespace CrmOrganizationServiceContextExtensions
{
    public interface ICrmOrganizationServiceContext
    {
        /*
         * Microsoft.Xrm.Client.Messages.OrganizationServiceContextExtensions
         */
        Guid AddItemCampaign(Guid campaignId, Guid entityId, string entityName);
        Guid AddItemCampaignActivity(Guid campaignActivityId, Guid itemId, string entityName);
        void AddListMembersList(Guid listId, Guid[] memberIds);
        Guid AddMemberList(Guid listId, Guid entityId);
        void AddMembersTeam(Guid teamId, Guid[] memberIds);
        void AddPrivilegesRole(Guid roleId, object privileges);
        void AddProductToKit(Guid kitId, Guid productId);
        Guid AddRecurrence(global::Microsoft.Xrm.Sdk.Entity target, Guid appointmentId);
        Guid AddSolutionComponent(Guid componentId, int componentType, string solutionUniqueName, bool addRequiredComponents);
        void AddSubstituteProduct(Guid productId, Guid substituteId);
        Guid AddToQueue(global::Microsoft.Xrm.Sdk.EntityReference target, Guid sourceQueueId, Guid destinationQueueId, global::Microsoft.Xrm.Sdk.Entity queueItemProperties);
        void Assign(global::Microsoft.Xrm.Sdk.EntityReference target, global::Microsoft.Xrm.Sdk.EntityReference assignee);
        void AssociateEntities(global::Microsoft.Xrm.Sdk.EntityReference moniker1, global::Microsoft.Xrm.Sdk.EntityReference moniker2, string relationshipName);
        void AutoMapEntity(Guid entityMapId);
        TResponse BackgroundSendEmail<TResponse>(global::Microsoft.Xrm.Sdk.Query.QueryBase query) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        TResult Book<TResult>(global::Microsoft.Xrm.Sdk.Entity target);
        Guid BulkDelete(global::Microsoft.Xrm.Sdk.Query.QueryExpression[] querySet, string jobName, bool sendEmailNotification, Guid[] toRecipients, Guid[] cCRecipients, string recurrencePattern, DateTime startDateTime, Guid? sourceImportId);
        Guid BulkDetectDuplicates(global::Microsoft.Xrm.Sdk.Query.QueryBase query, string jobName, bool sendEmailNotification, Guid templateId, Guid[] toRecipients, Guid[] cCRecipients, string recurrencePattern, DateTime recurrenceStartTime);
        void BulkOperationStatusClose(Guid bulkOperationId, int failureCount, int successCount, int statusReason, int errorCode);
        decimal CalculateActualValueOpportunity(Guid opportunityId);
        long CalculateTotalTimeIncident(Guid incidentId);
        void CancelContract(Guid contractId, DateTime cancelDate, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        void CancelSalesOrder(global::Microsoft.Xrm.Sdk.Entity orderClose, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        TResponse CheckIncomingEmail<TResponse>(string messageId, string subject, string from, string to, string cc, string bcc) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        TResponse CheckPromoteEmail<TResponse>(string messageId, string subject) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        void CleanUpBulkOperation(Guid bulkOperationId, int bulkOperationSource);
        global::Microsoft.Xrm.Sdk.Entity CloneContract(Guid contractId, bool includeCanceledLines);
        void CloseIncident(global::Microsoft.Xrm.Sdk.Entity incidentResolution, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        void CloseIncident(global::Microsoft.Xrm.Sdk.Entity incidentResolution, int status);
        void CloseQuote(global::Microsoft.Xrm.Sdk.Entity quoteClose, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        Guid CompoundCreate(global::Microsoft.Xrm.Sdk.Entity entity, global::Microsoft.Xrm.Sdk.EntityCollection childEntities);
        void CompoundUpdate(global::Microsoft.Xrm.Sdk.Entity entity, global::Microsoft.Xrm.Sdk.EntityCollection childEntities);
        void CompoundUpdateDuplicateDetectionRule(global::Microsoft.Xrm.Sdk.Entity entity, global::Microsoft.Xrm.Sdk.EntityCollection childEntities);
        void ConvertKitToProduct(Guid kitId);
        void ConvertProductToKit(Guid productId);
        global::Microsoft.Xrm.Sdk.Entity ConvertQuoteToSalesOrder(Guid quoteId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.Entity ConvertSalesOrderToInvoice(Guid salesOrderId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        Guid CopyCampaign(Guid baseCampaign, bool saveAsTemplate);
        Guid CopyCampaignResponse(global::Microsoft.Xrm.Sdk.EntityReference campaignResponseId);
        Guid CopyDynamicListToStatic(Guid listId);
        void CopyMembersList(Guid sourceListId, Guid targetListId);
        Guid CopySystemForm(global::Microsoft.Xrm.Sdk.Entity target, Guid sourceId);
        Guid CreateActivitiesList(Guid listId, string friendlyName, global::Microsoft.Xrm.Sdk.Entity activity, Guid templateId, bool propagate, object ownershipOptions, global::Microsoft.Xrm.Sdk.EntityReference owner, bool sendEmail, bool postWorkflowEvent, Guid queueId);
        Guid CreateException(global::Microsoft.Xrm.Sdk.Entity target, DateTime originalStartDate, bool isDeleted);
        bool CreateInstance(global::Microsoft.Xrm.Sdk.Entity target, int count);
        Guid CreateWorkflowFromTemplate(string workflowName, Guid workflowTemplateId);
        int DeleteAuditData(DateTime endDate);
        void DeleteOpenInstances(global::Microsoft.Xrm.Sdk.Entity target, DateTime seriesEndDate, int stateOfPastInstances);
        Guid DeliverIncomingEmail(string messageId, string subject, string from, string to, string cc, string bcc, DateTime receivedOn, string submittedBy, string importance, string body, global::Microsoft.Xrm.Sdk.EntityCollection attachments);
        Guid DeliverPromoteEmail(Guid emailId, string messageId, string subject, string from, string to, string cc, string bcc, DateTime receivedOn, string submittedBy, string importance, string body, global::Microsoft.Xrm.Sdk.EntityCollection attachments, global::Microsoft.Xrm.Sdk.Entity extraProperties);
        void DeprovisionLanguage(int language);
        void DisassociateEntities(global::Microsoft.Xrm.Sdk.EntityReference moniker1, global::Microsoft.Xrm.Sdk.EntityReference moniker2, string relationshipName);
        Guid DistributeCampaignActivity(Guid campaignActivityId, bool propagate, global::Microsoft.Xrm.Sdk.Entity activity, Guid templateId, object ownershipOptions, global::Microsoft.Xrm.Sdk.EntityReference owner, bool sendEmail, Guid queueId);
        string DownloadReportDefinition(Guid reportId);
        string ExecuteByIdSavedQuery(Guid entityId);
        string ExecuteByIdUserQuery(global::Microsoft.Xrm.Sdk.EntityReference entityId);
        string ExecuteFetch(string fetchXml);
        Guid ExecuteWorkflow(Guid entityId, Guid workflowId);
        TResult ExpandCalendar<TResult>(Guid calendarId, DateTime start, DateTime end);
        byte[] ExportSolution(string solutionName, bool managed, bool exportAutoNumberingSettings, bool exportCalendarSettings, bool exportCustomizationSettings, bool exportEmailTrackingSettings, bool exportGeneralSettings, bool exportMarketingSettings, bool exportOutlookSynchronizationSettings, bool exportRelationshipRoles, bool exportIsvConfig);
        byte[] ExportTranslation(string solutionName);
        global::Microsoft.Xrm.Sdk.Query.QueryExpression FetchXmlToQueryExpression(string fetchXml);
        bool FindParentResourceGroup(Guid parentId, Guid[] childrenIds);
        void FulfillSalesOrder(global::Microsoft.Xrm.Sdk.Entity orderClose, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        global::Microsoft.Xrm.Sdk.Entity GenerateInvoiceFromOpportunity(Guid opportunityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.Entity GenerateQuoteFromOpportunity(Guid opportunityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.Entity GenerateSalesOrderFromOpportunity(Guid opportunityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.EntityCollection GetAllTimeZonesWithDisplayName(int localeId);
        string GetDecryptionKey();
        string[] GetDistinctValuesImportFile(Guid importFileId, int columnNumber, int pageNumber, int recordsPerPage);
        string[] GetHeaderColumnsImportFile(Guid importFileId);
        void GetInvoiceProductsFromOpportunity(Guid opportunityId, Guid invoiceId);
        int GetQuantityDecimal(global::Microsoft.Xrm.Sdk.EntityReference target, Guid productId, Guid uoMId);
        void GetQuoteProductsFromOpportunity(Guid opportunityId, Guid quoteId);
        int GetReportHistoryLimit(Guid reportId);
        void GetSalesOrderProductsFromOpportunity(Guid opportunityId, Guid salesOrderId);
        int GetTimeZoneCodeByLocalizedName(string localizedStandardName, int localeId);
        string GetTrackingTokenEmail(string subject);
        void GrantAccess(global::Microsoft.Xrm.Sdk.EntityReference target, object principalAccess);
        Guid ImportRecordsImport(Guid importId);
        void ImportSolution(bool overwriteUnmanagedCustomizations, bool publishWorkflows, byte[] customizationFile, Guid importJobId);
        void ImportTranslation(byte[] translationFile, Guid importJobId);
        global::Microsoft.Xrm.Sdk.Entity InitializeFrom(global::Microsoft.Xrm.Sdk.EntityReference entityMoniker, string targetEntityName, object targetFieldType);
        void InstallSampleData();
        void InstantiateFilters(global::Microsoft.Xrm.Sdk.EntityReferenceCollection templateCollection, Guid userId);
        global::Microsoft.Xrm.Sdk.EntityCollection InstantiateTemplate(Guid templateId, string objectType, Guid objectId);
        bool IsBackOfficeInstalled();
        bool IsComponentCustomizable(Guid componentId, int componentType);
        bool IsValidStateTransition(global::Microsoft.Xrm.Sdk.EntityReference entity, string newState, int newStatus);
        DateTime LocalTimeFromUtcTime(int timeZoneCode, DateTime utcTime);
        void LockInvoicePricing(Guid invoiceId);
        void LockSalesOrderPricing(Guid salesOrderId);
        void LogFailureBulkOperation(Guid bulkOperationId, Guid regardingObjectId, int regardingObjectTypeCode, int errorCode, string message, string additionalInfo);
        void LogSuccessBulkOperation(Guid bulkOperationId, Guid regardingObjectId, int regardingObjectTypeCode, Guid createdObjectId, int createdObjectTypeCode, string additionalInfo);
        void LoseOpportunity(global::Microsoft.Xrm.Sdk.Entity opportunityClose, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        void LoseOpportunity(global::Microsoft.Xrm.Sdk.Entity opportunityClose, int status);
        void MakeAvailableToOrganizationReport(Guid reportId);
        void MakeAvailableToOrganizationTemplate(Guid templateId);
        void MakeUnavailableToOrganizationReport(Guid reportId);
        void MakeUnavailableToOrganizationTemplate(Guid templateId);
        void Merge(global::Microsoft.Xrm.Sdk.EntityReference target, Guid subordinateId, global::Microsoft.Xrm.Sdk.Entity updateContent, bool performParentingChecks);
        void ModifyAccess(global::Microsoft.Xrm.Sdk.EntityReference target, object principalAccess);
        Guid ParseImport(Guid importId);
        void ProcessInboundEmail(Guid inboundEmailActivity);
        int ProcessOneMemberBulkOperation(Guid bulkOperationId, global::Microsoft.Xrm.Sdk.Entity entity, int bulkOperationSource);
        Guid PropagateByExpression(global::Microsoft.Xrm.Sdk.Query.QueryBase queryExpression, string friendlyName, bool executeImmediately, global::Microsoft.Xrm.Sdk.Entity activity, Guid templateId, object ownershipOptions, bool postWorkflowEvent, global::Microsoft.Xrm.Sdk.EntityReference owner, bool sendEmail, Guid queueId);
        void ProvisionLanguage(int language);
        void PublishAllXml();
        Guid PublishDuplicateRule(Guid duplicateRuleId);
        void PublishXml(string parameterXml);
        global::Microsoft.Xrm.Sdk.EntityReferenceCollection QualifyLead(global::Microsoft.Xrm.Sdk.EntityReference leadId, bool createAccount, bool createContact, bool createOpportunity, global::Microsoft.Xrm.Sdk.EntityReference opportunityCurrencyId, global::Microsoft.Xrm.Sdk.EntityReference opportunityCustomerId, global::Microsoft.Xrm.Sdk.EntityReference sourceCampaignId, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        void QualifyMemberList(Guid listId, Guid[] membersId, bool overrideorRemove);
        string QueryExpressionToFetchXml(global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        TResult QueryMultipleSchedules<TResult>(Guid[] resourceIds, DateTime start, DateTime end, object timeCodes);
        TResult QuerySchedule<TResult>(Guid resourceId, DateTime start, DateTime end, object timeCodes);
        void ReassignObjectsOwner(global::Microsoft.Xrm.Sdk.EntityReference fromPrincipal, global::Microsoft.Xrm.Sdk.EntityReference toPrincipal);
        void ReassignObjectsSystemUser(Guid userId, global::Microsoft.Xrm.Sdk.EntityReference reassignPrincipal);
        void Recalculate(global::Microsoft.Xrm.Sdk.EntityReference target);
        void RemoveItemCampaign(Guid campaignId, Guid entityId);
        void RemoveItemCampaignActivity(Guid campaignActivityId, Guid itemId);
        void RemoveMemberList(Guid listId, Guid entityId);
        void RemoveMembersTeam(Guid teamId, Guid[] memberIds);
        void RemoveParent(global::Microsoft.Xrm.Sdk.EntityReference target);
        void RemovePrivilegeRole(Guid roleId, Guid privilegeId);
        void RemoveProductFromKit(Guid kitId, Guid productId);
        void RemoveRelated(global::Microsoft.Xrm.Sdk.EntityReference[] target);
        Guid RemoveSolutionComponent(Guid componentId, int componentType, string solutionUniqueName);
        void RemoveSubstituteProduct(Guid productId, Guid substituteId);
        global::Microsoft.Xrm.Sdk.Entity RenewContract(Guid contractId, int status, bool includeCanceledLines);
        void ReplacePrivilegesRole(Guid roleId, object privileges);
        TResult Reschedule<TResult>(global::Microsoft.Xrm.Sdk.Entity target);
        void ResetUserFilters(int queryType);
        TResponse RetrieveAbsoluteAndSiteCollectionUrl<TResponse>(global::Microsoft.Xrm.Sdk.EntityReference target) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveAllChildUsersSystemUser(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.Metadata.EntityMetadata[] RetrieveAllEntities(global::Microsoft.Xrm.Sdk.Metadata.EntityFilters entityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Default, bool retrieveAsIfPublished = false);
        byte[] RetrieveApplicationRibbon();
        global::Microsoft.Xrm.Sdk.Metadata.AttributeMetadata RetrieveAttribute(string entityLogicalName, string logicalName, bool retrieveAsIfPublished = false);
        TResult RetrieveAttributeChangeHistory<TResult>(global::Microsoft.Xrm.Sdk.EntityReference target, string attributeLogicalName, global::Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo);
        TResult RetrieveAuditDetails<TResult>(Guid auditId);
        TResult RetrieveAuditPartitionList<TResult>();
        int[] RetrieveAvailableLanguages();
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveBusinessHierarchyBusinessUnit(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveByGroupResource(Guid resourceGroupId, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveByResourceResourceGroup(Guid resourceId, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveByResourcesService(Guid[] resourceIds, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveByTopIncidentProductKbArticle(Guid productId);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveByTopIncidentSubjectKbArticle(Guid subjectId);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveDependenciesForDelete(Guid objectId, int componentType);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveDependenciesForUninstall(string solutionUniqueName);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveDependentComponents(Guid objectId, int componentType);
        string RetrieveDeploymentLicenseType();
        int[] RetrieveDeprovisionedLanguages();
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveDuplicates(global::Microsoft.Xrm.Sdk.Entity businessEntity, string matchingEntityName, global::Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo);
        global::Microsoft.Xrm.Sdk.Metadata.EntityMetadata RetrieveEntity(string logicalName, global::Microsoft.Xrm.Sdk.Metadata.EntityFilters entityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Default, bool retrieveAsIfPublished = false);
        byte[] RetrieveEntityRibbon(string entityName, object ribbonLocationFilter);
        decimal RetrieveExchangeRate(Guid transactionCurrencyId);
        global::Microsoft.Xrm.Sdk.EntityReferenceCollection RetrieveFilteredForms(string entityLogicalName, global::Microsoft.Xrm.Sdk.OptionSetValue formType, Guid systemUserId);
        string RetrieveFormattedImportJobResults(Guid importJobId);
        TResponse RetrieveFormXml<TResponse>(string entityName) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        int[] RetrieveInstalledLanguagePacks();
        string RetrieveInstalledLanguagePackVersion(int language);
        TResponse RetrieveLicenseInfo<TResponse>(int accessMode) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        global::Microsoft.Xrm.Sdk.Label RetrieveLocLabels(global::Microsoft.Xrm.Sdk.EntityReference entityMoniker, string attributeName, bool includeUnpublished);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveMembersBulkOperation(Guid bulkOperationId, int bulkOperationSource, int entitySource, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveMembersTeam(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet memberColumnSet);
        TResult RetrieveMissingComponents<TResult>(byte[] customizationFile);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveMissingDependencies(string solutionUniqueName);
        global::Microsoft.Xrm.Sdk.Messages.RetrieveMultipleResponse RetrieveMultiple(global::Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest request);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveMultiple(global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        TResult RetrieveOrganizationResources<TResult>();
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveParentGroupsResourceGroup(Guid resourceGroupId, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        string[][] RetrieveParsedDataImportFile(Guid importFileId, global::Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo);
        TResult RetrievePrincipalAccess<TResult>(global::Microsoft.Xrm.Sdk.EntityReference target, global::Microsoft.Xrm.Sdk.EntityReference principal);
        global::Microsoft.Xrm.Sdk.AttributePrivilegeCollection RetrievePrincipalAttributePrivileges(global::Microsoft.Xrm.Sdk.EntityReference principal);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrievePrivilegeSet();
        string RetrieveProvisionedLanguagePackVersion(int language);
        int[] RetrieveProvisionedLanguages();
        TResult RetrieveRecordChangeHistory<TResult>(global::Microsoft.Xrm.Sdk.EntityReference target, global::Microsoft.Xrm.Sdk.Query.PagingInfo pagingInfo);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveRequiredComponents(Guid objectId, int componentType);
        TResult RetrieveRolePrivilegesRole<TResult>(Guid roleId);
        TResult RetrieveSharedPrincipalsAndAccess<TResult>(global::Microsoft.Xrm.Sdk.EntityReference target);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveSubGroupsResourceGroup(Guid resourceGroupId, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveSubsidiaryTeamsBusinessUnit(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveSubsidiaryUsersBusinessUnit(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        TResult RetrieveTeamPrivileges<TResult>(Guid teamId);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveTeamsSystemUser(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.Entity RetrieveUnpublished(global::Microsoft.Xrm.Sdk.EntityReference target, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        global::Microsoft.Xrm.Sdk.EntityCollection RetrieveUnpublishedMultiple(global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        TResult RetrieveUserPrivileges<TResult>(Guid userId);
        global::Microsoft.Xrm.Sdk.Entity RetrieveUserSettingsSystemUser(Guid entityId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        string RetrieveVersion();
        global::Microsoft.Xrm.Sdk.Entity ReviseQuote(Guid quoteId, global::Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        void RevokeAccess(global::Microsoft.Xrm.Sdk.EntityReference target, global::Microsoft.Xrm.Sdk.EntityReference revokee);
        global::Microsoft.Xrm.Sdk.EntityCollection Rollup(global::Microsoft.Xrm.Sdk.EntityReference target, global::Microsoft.Xrm.Sdk.Query.QueryBase query, object rollupType);
        TResult Search<TResult>(object appointmentRequest);
        global::Microsoft.Xrm.Sdk.EntityCollection SearchByBodyKbArticle(string searchText, Guid subjectId, bool useInflection, global::Microsoft.Xrm.Sdk.Query.QueryBase queryExpression);
        global::Microsoft.Xrm.Sdk.EntityCollection SearchByKeywordsKbArticle(string searchText, Guid subjectId, bool useInflection, global::Microsoft.Xrm.Sdk.Query.QueryBase queryExpression);
        global::Microsoft.Xrm.Sdk.EntityCollection SearchByTitleKbArticle(string searchText, Guid subjectId, bool useInflection, global::Microsoft.Xrm.Sdk.Query.QueryBase queryExpression);
        void SendBulkMail(global::Microsoft.Xrm.Sdk.EntityReference sender, Guid templateId, string regardingType, Guid regardingId, global::Microsoft.Xrm.Sdk.Query.QueryBase query);
        string SendEmail(Guid emailId, bool issueSend, string trackingToken);
        Guid SendEmailFromTemplate(Guid templateId, string regardingType, Guid regardingId, global::Microsoft.Xrm.Sdk.Entity target);
        void SendFax(Guid faxId, bool issueSend);
        void SendTemplate(Guid templateId, global::Microsoft.Xrm.Sdk.EntityReference sender, string recipientType, Guid[] recipientIds, string regardingType, Guid regardingId);
        void SetBusinessEquipment(Guid equipmentId, Guid businessUnitId);
        void SetBusinessSystemUser(Guid userId, Guid businessId, global::Microsoft.Xrm.Sdk.EntityReference reassignPrincipal);
        void SetLocLabels(global::Microsoft.Xrm.Sdk.EntityReference entityMoniker, string attributeName, global::Microsoft.Xrm.Sdk.LocalizedLabel[] labels);
        void SetParentBusinessUnit(Guid businessUnitId, Guid parentId);
        void SetParentSystemUser(Guid userId, Guid parentId, bool keepChildUsers);
        void SetParentTeam(Guid teamId, Guid businessId);
        void SetRelated(global::Microsoft.Xrm.Sdk.EntityReference[] target);
        void SetReportRelated(Guid reportId, int[] entities, int[] categories, int[] visibility);
        void SetState(global::Microsoft.Xrm.Sdk.EntityReference entityMoniker, global::Microsoft.Xrm.Sdk.OptionSetValue state, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        void SetState(int state, int status, global::Microsoft.Xrm.Sdk.EntityReference entityMoniker);
        void SetState(int state, int status, global::Microsoft.Xrm.Sdk.Entity entity);
        void StatusUpdateBulkOperation(Guid bulkOperationId, int failureCount, int successCount);
        Guid TransformImport(Guid importId);
        void TriggerServiceEndpointCheck(global::Microsoft.Xrm.Sdk.EntityReference entity);
        void UninstallSampleData();
        void UnlockInvoicePricing(Guid invoiceId);
        void UnlockSalesOrderPricing(Guid salesOrderId);
        void UnpublishDuplicateRule(Guid duplicateRuleId);
        void UpdateUserSettingsSystemUser(Guid userId, global::Microsoft.Xrm.Sdk.Entity settings);
        DateTime UtcTimeFromLocalTime(int timeZoneCode, DateTime localTime);
        TResult Validate<TResult>(global::Microsoft.Xrm.Sdk.EntityCollection activities);
        string ValidateRecurrenceRule(global::Microsoft.Xrm.Sdk.Entity target);
        void ValidateSavedQuery(string fetchXml, int queryType);
        bool VerifyProcessStateData(global::Microsoft.Xrm.Sdk.EntityReference target, string processState);
        TResponse WhoAmI<TResponse>() where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        void WinOpportunity(global::Microsoft.Xrm.Sdk.Entity opportunityClose, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        void WinOpportunity(global::Microsoft.Xrm.Sdk.Entity opportunityClose, int status);
        void WinQuote(global::Microsoft.Xrm.Sdk.Entity quoteClose, global::Microsoft.Xrm.Sdk.OptionSetValue status);
        /*
         * Microsoft.Xrm.Client.OrganizationServiceContextExtensions
         */
        void AddLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        void AddLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        void AddRelatedObject(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        void AddRelatedObject<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, System.Collections.Generic.IEnumerable<TTarget>>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        void AddRelatedObject<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        T AttachClone<T>(T entity, bool includeRelatedEntities = false) where T : Microsoft.Xrm.Sdk.Entity;
        void AttachLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        void AttachLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        void DeleteLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        void DeleteLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        bool Detach(System.Collections.Generic.IEnumerable<Microsoft.Xrm.Sdk.Entity> entities);
        bool DetachLink(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        bool DetachLink<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        TResponse Execute<TResponse>(Microsoft.Xrm.Sdk.OrganizationRequest request) where TResponse : Microsoft.Xrm.Sdk.OrganizationResponse;
        void IsAttached(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        bool IsAttached<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, System.Collections.Generic.IEnumerable<TTarget>>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        bool IsAttached<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        void IsDeleted(Microsoft.Xrm.Sdk.Entity source, string relationshipSchemaName, Microsoft.Xrm.Sdk.Entity target, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        bool IsDeleted<TSource, TTarget>(TSource source, System.Linq.Expressions.Expression<Func<TSource, TTarget>> propertySelector, TTarget target)
            where TSource : Microsoft.Xrm.Sdk.Entity
            where TTarget : Microsoft.Xrm.Sdk.Entity;
        void LoadProperty(Microsoft.Xrm.Sdk.Entity entity, string relationshipSchemaName, Microsoft.Xrm.Sdk.EntityRole? primaryEntityRole = null);
        void LoadProperty<TEntity>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, object>> propertySelector) where TEntity : Microsoft.Xrm.Sdk.Entity;
        T MergeClone<T>(T entity, bool includeRelatedEntities = false) where T : Microsoft.Xrm.Sdk.Entity;
        void ReAttach(Microsoft.Xrm.Sdk.Entity entity);
        bool TryAccessCache(Action<Microsoft.Xrm.Client.Services.IOrganizationServiceCache> action);
        bool TryRemoveFromCache(Microsoft.Xrm.Sdk.Entity entity);
        bool TryRemoveFromCache(Microsoft.Xrm.Sdk.EntityReference entity);
        bool TryRemoveFromCache(Microsoft.Xrm.Sdk.OrganizationRequest request);
        bool TryRemoveFromCache(string cacheKey);
        bool TryRemoveFromCache(string entityLogicalName, Guid? id);
        /*
         * Microsoft.Xrm.Client.CrmOrganizationServiceContext
         */
        void Associate(string entityName, Guid entityId, Microsoft.Xrm.Sdk.Relationship relationship, Microsoft.Xrm.Sdk.EntityReferenceCollection relatedEntities);
        Guid Create(Microsoft.Xrm.Sdk.Entity entity);
        void Delete(string entityName, Guid id);
        void Disassociate(string entityName, Guid entityId, Microsoft.Xrm.Sdk.Relationship relationship, Microsoft.Xrm.Sdk.EntityReferenceCollection relatedEntities);
        void Initialize(string name, System.Collections.Specialized.NameValueCollection config);
        Microsoft.Xrm.Sdk.Entity Retrieve(string entityName, Guid id, Microsoft.Xrm.Sdk.Query.ColumnSet columnSet);
        void Update(Microsoft.Xrm.Sdk.Entity entity);
    }
}