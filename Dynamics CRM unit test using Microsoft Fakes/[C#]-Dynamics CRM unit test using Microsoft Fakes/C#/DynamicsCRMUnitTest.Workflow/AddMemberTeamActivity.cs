using System;
using System.Activities;
using System.Linq;
using System.ServiceModel;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Workflow;

namespace DynamicsCRMUnitTest.Workflow
{
    public sealed class AddMemberTeamActivity : CodeActivity
    {
        [RequiredArgument]
        [Input("User to Add")]
        [ReferenceTarget("systemuser")]
        public InArgument<EntityReference> User { get; set; }

        [RequiredArgument]
        [Input("Team to Add To")]
        [ReferenceTarget("team")]
        public InArgument<EntityReference> Team { get; set; }

        /// <summary>
        /// Executes the workflow activity.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        protected override void Execute(CodeActivityContext executionContext)
        {
            // Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            if (tracingService == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve tracing service.");
            }

            tracingService.Trace("Entered AddMemberTeamActivity.Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                executionContext.ActivityInstanceId,
                executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace("AddMemberTeamActivity.Execute(), Correlation Id: {0}, Initiating User: {1}",
                context.CorrelationId,
                context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
                EntityReference user = this.User.Get(executionContext);
                EntityReference team = this.Team.Get(executionContext);

                if (!IsMemberInTeam(service, team.Id, user.Id))
                {
                    OrganizationRequest request = new AddMembersTeamRequest { MemberIds = new Guid[] { user.Id }, TeamId = team.Id };

                    var response = service.Execute(request) as AddMembersTeamResponse;
                }
            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());

                // Handle the exception.
                throw;
            }

            tracingService.Trace("Exiting AddMemberTeamActivity.Execute(), Correlation Id: {0}", context.CorrelationId);
        }

        internal bool IsMemberInTeam(IOrganizationService service, Guid teamId, Guid memberId)
        {
            OrganizationServiceContext context = new OrganizationServiceContext(service);

            var query = from relationship in context.CreateQuery("teammembership")
                        where relationship.GetAttributeValue<Guid>("teamid") == teamId
                        && relationship.GetAttributeValue<Guid>("systemuserid") == memberId
                        select relationship;

            return query.FirstOrDefault() != null;
        }
    }
}
