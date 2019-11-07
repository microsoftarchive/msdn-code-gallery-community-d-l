using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.ServiceRuntime;

using Contoso.Cloud.Integration.Framework.Configuration;
using Contoso.Cloud.Integration.Common.Activities;
using Contoso.Cloud.Integration.Azure.Services.Framework;
using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
using Contoso.Cloud.Integration.Azure.Services.Common.RulesEngine;

using Contoso.Cloud.Integration.Demo.LoanApplication.Data;
using Contoso.Cloud.Integration.Demo.LoanApplication.Contract;

namespace Contoso.Cloud.Integration.Demo.LoanApplication
{
    public partial class LoanForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            ChangeDisplayState();
            ClearResultsDisplay();

            LoanApplicationData loanApp = new LoanApplicationData
            {
                ApplicationID = Guid.NewGuid().ToString(),
                Ssn = tbSsn.Text,
                City = tbCity.Text,
                CreditDescription = ddlCredit.SelectedValue,
                CurrentInterestRate = ParseDouble(ddlFirstMortgageInterest.SelectedValue),
                CurrentMorgagePayment = ParseInt(ddlCurrentMortgagePayment.SelectedValue),
                DateOfBirth = ParseDate(ddlMonth.SelectedValue, ddlDay.SelectedValue, ddlYear.SelectedValue),
                Email = tbEmail.Text,
                EstimatedHomeValue = ParseInt(ddlEstimatedHomeValue.SelectedValue),
                FirstMorgageBalance = ParseInt(ddlBalanceFirstMortgage.SelectedValue),
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                MailingZip = tbPropertyZip.Text,
                Phone = tbPhone.Text,
                PropertyType = ddlPropertyType.SelectedValue,
                PropertyUse = ddlPropertyUse.SelectedValue,
                PropertyZip = tbPropertyZip.Text,
                State = ddlState.SelectedValue,
                StreetAddress = tbStreet.Text,
            };

            SubmitApplication(loanApp);
        }

        private double ParseDouble(string value)
        {
            double d = default(double);
            Double.TryParse(value, out d);
            return d;
        }

        private int ParseInt(string value)
        {
            int i = default(int);
            Int32.TryParse(value, out i);
            return i;
        }

        private DateTime ParseDate(string month, string day, string year)
        {
            string date = string.Format("{0}/{1}/{2}", month, day, year);
            DateTime dt = default(DateTime);
            DateTime.TryParse(date, out dt);
            return dt;
        }

        private void ChangeDisplayState()
        {
            if (!Context.Application.Contents.AllKeys.Contains("testDisplay"))
            {
                Context.Application.Contents.Add("testDisplay", true);
            }
            else
            {
                Context.Application.Contents["testDisplay"] = !GetCurrentDisplayState();
            }
        }

        private void ClearResultsDisplay()
        {
            tbResult.Visible = false;
            imgResult.Visible = false;
        }

        private void SubmitApplication(LoanApplicationData loanApp)
        {
            LoanApplicationProcess loanRequestActivity = new LoanApplicationProcess(loanApp.ApplicationID)
            {
                ApplicantID = loanApp.Ssn,
                LoanApplicationSubmitted = DateTime.UtcNow
            };

            // Ensure the availability of required extensions, throw an exception if not available.
            Global.WebRoleSingleton.Extensions.Demand<IActivityTrackingEventStreamExtension>();
            Global.WebRoleSingleton.Extensions.Demand<IRulesEngineServiceClientExtension>();

            IActivityTrackingEventStreamExtension trackingEventStream = Global.WebRoleSingleton.Extensions.Find<IActivityTrackingEventStreamExtension>();
            IRulesEngineServiceClientExtension ruleEngineClient = Global.WebRoleSingleton.Extensions.Find<IRulesEngineServiceClientExtension>();
            IRoleConfigurationSettingsExtension roleConfig = Global.WebRoleSingleton.Extensions.Find<IRoleConfigurationSettingsExtension>();

            // Tells the event stream to invoke the BeginActivity operation.
            trackingEventStream.BeginActivity(loanRequestActivity);

            // Call BRE rule to obtain a pre-approval.
            SimpleValueFact result = ruleEngineClient.ExecutePolicy<SimpleValueFact>("Contoso.Cloud.Integration.Demo.LoanPreapproval", loanApp);

            // Update the LoanPreapprovalReceived milestone.
            loanRequestActivity.LoanPreapprovalDecision = Convert.ToString(result.Value);
            loanRequestActivity.LoanPreapprovalReceived = DateTime.UtcNow;

            // Display pre-approval decision.
            SetResultDisplay(loanRequestActivity.LoanPreapprovalDecision);

            // Tells the event stream to invoke the UpdateActivity.
            trackingEventStream.UpdateActivity(loanRequestActivity);

            // Submit pre-approved loan for final processing.
            if (String.Compare(loanRequestActivity.LoanPreapprovalDecision, "Preapproved", true) == 0)
            {
                // Submit the loan application for processing (this will update LoanApplicationStarted, LoanFinalDecision and LoanFinalDecisionMade milestones.
                using (var loanProcessor = new ReliableServiceBusClient<ILoanApplicationProcessingServiceChannel>(roleConfig.GetServiceBusEndpoint("LoanApplication"), roleConfig.CommunicationRetryPolicy))
                {
                    loanProcessor.RetryPolicy.ExecuteAction(() =>
                    {
                        loanProcessor.Client.Submit(loanApp);
                    });
                }
            }

            // Update the LoanFinalDecisionReceived milestone.
            loanRequestActivity.LoanFinalDecisionReceived = DateTime.UtcNow;

            // Tells the event stream to invoke the UpdateActivity and EndActivity operations.
            trackingEventStream.CompleteActivity(loanRequestActivity);
        }

        private void SetResultDisplay(string result)
        {
            tbResult.Visible = true;
            imgResult.Visible = true;

            if (String.Compare(result, "Preapproved", true) == 0)
            {
                tbResult.Text = result;
                imgResult.ImageUrl = @"/Data/Images/ThumbUp.png";
            }
            else
            {
                tbResult.Text = result;
                imgResult.ImageUrl = @"/Data/Images/ThumbDown.png";
            }
        }

        private bool GetCurrentDisplayState()
        {
            return (bool)Context.Application.Contents["testDisplay"];
        }
    }
}
