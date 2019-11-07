using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using DynamicsCRMUnitTest.Workflow;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Workflow;

namespace WorkflowTest.MicrosoftFakes
{
    [TestClass]
    public class AddMemberTeamActivityTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            //
            // Arrange
            //
            Guid actualUserId = Guid.NewGuid();
            Guid actualTeamId = Guid.NewGuid();
            var workflowUserId = Guid.NewGuid();
            var workflowCorrelationId = Guid.NewGuid();
            var workflowInitiatingUserId = Guid.NewGuid();

            // IOrganizationService
            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.ExecuteOrganizationRequest = r =>
                {
                    AddMembersTeamRequest request = r as AddMembersTeamRequest;
                    actualUserId = request.MemberIds[0];
                    actualTeamId = request.TeamId;
                    return new AddMembersTeamResponse();
                };

            // IWorkflowContext
            var workflowContext = new Microsoft.Xrm.Sdk.Workflow.Fakes.StubIWorkflowContext();
            workflowContext.UserIdGet = () =>
            {
                return workflowUserId;
            };
            workflowContext.CorrelationIdGet = () =>
            {
                return workflowCorrelationId;
            };
            workflowContext.InitiatingUserIdGet = () =>
            {
                return workflowInitiatingUserId;
            };

            // ITracingService
            var tracingService = new Microsoft.Xrm.Sdk.Fakes.StubITracingService();
            tracingService.TraceStringObjectArray = (f, o) =>
            {
                Debug.WriteLine(f, o);
            };

            // IOrganizationServiceFactory
            var factory = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationServiceFactory();
            factory.CreateOrganizationServiceNullableOfGuid = id =>
            {
                return service;
            };

            var expectedUserId = Guid.NewGuid();
            var expectedTeamId = Guid.NewGuid();

            AddMemberTeamActivity target = new AddMemberTeamActivity();
            using (ShimsContext.Create())
            {
                var fakeTarget = new DynamicsCRMUnitTest.Workflow.Fakes.ShimAddMemberTeamActivity(target);
                fakeTarget.IsMemberInTeamIOrganizationServiceGuidGuid = (svc, teamId, memberId) =>
                    {
                        return false;
                    };

                var invoker = new WorkflowInvoker(target);
                invoker.Extensions.Add<ITracingService>(() => tracingService);
                invoker.Extensions.Add<IWorkflowContext>(() => workflowContext);
                invoker.Extensions.Add<IOrganizationServiceFactory>(() => factory);

                var inputs = new Dictionary<string, object>
                {
                    { "User", new EntityReference("systemuser", expectedUserId) },
                    { "Team", new EntityReference("team", expectedTeamId) }
                };

                //
                // Act
                //
                var outputs = invoker.Invoke(inputs);
            }

            //
            // Assert
            //
            Assert.AreEqual(expectedUserId, actualUserId);
            Assert.AreEqual(expectedTeamId, actualTeamId);
        }

        [TestMethod]
        public void IsMemberInTeamTest()
        {
            //
            // Arrange
            //
            Guid userId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            bool expected = true;

            AddMemberTeamActivity target = new AddMemberTeamActivity();

            // IOrganizationService
            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.ExecuteOrganizationRequest = r =>
            {
                List<Entity> entities = new List<Entity>
                    {
                        new Entity()
                    };

                var response = new RetrieveMultipleResponse
                    {
                        Results = new ParameterCollection
                        {
                            { "EntityCollection", new EntityCollection(entities) }
                        }
                    };

                return response;
            };

            //
            // Act
            //
            var actual = target.IsMemberInTeam(service, teamId, userId);

            //
            // Assert
            //
            Assert.AreEqual(expected, actual);
        }
    }
}
