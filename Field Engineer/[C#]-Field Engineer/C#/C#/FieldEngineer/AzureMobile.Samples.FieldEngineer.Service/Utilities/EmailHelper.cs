// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using AzureMobile.Samples.AAD.Graph;
using AzureMobile.Samples.FieldEngineer.Service.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using SendGridMail;

namespace AzureMobile.Samples.FieldEngineer.Service.Utilities
{
    public class EmailHelper
    {
        public static string GetJobDetailsInHTML(Job job)
        {
            StringBuilder htmlcontent = new StringBuilder("<p> <Table style=\"font-family:Segoe UI;\"");
            htmlcontent.Append("<tr> <td> <b> Job Number: </b>" + job.JobNumber + "  </td> </tr> ");
            htmlcontent.Append("<tr> <td> <b> Job ID: </b>" + job.Id + " </td> </tr> ");
            htmlcontent.Append("<tr> <td> <b> Title: </b>" + job.Title + " </td> </tr> ");
            htmlcontent.Append("<tr> <td> <b> Scheduled For: </b>" + job.StartTime + " - " + job.EndTime +
                                " </td> </tr> ");
            htmlcontent.Append("<tr> <td> <b> Job Status: </b>" + job.Status + "</td> </tr> <tr> <td> </td> </tr>");
            htmlcontent.Append("<tr> <td> <b> Customer Address: </b> </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.FullName + " </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.HouseNumberOrName + ", " + job.Customer.Street +
                                " </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.Town + " </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.County + " </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.Postcode + " </td> </tr> <tr> <td> </td> </tr>");
            htmlcontent.Append("<tr> <td> <b> Customer Contact: </b> </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.PrimaryContactNumber + " </td> </tr>");
            htmlcontent.Append("<tr> <td> " + job.Customer.AdditionalContactNumber + " </td> </tr>");
            htmlcontent.Append("</table> </p>");
            return htmlcontent.ToString();
        }

        public static void SendEmail(ApiServices services, Job job, string aadObjectId, IAadHelperProvider aadHelperProvider)
        {
            var htmlContent = GetJobDetailsInHTML(job);
            string accessToken = aadHelperProvider.GetAccessToken();
            string agentName = aadHelperProvider.GetUserDisplayName(aadObjectId, accessToken);
            string managerEmail = aadHelperProvider.GetManagerEmail(aadObjectId, accessToken);
            if (managerEmail == null)
            {
                // No e-mail (possibly running locally)
                return;
            }

            try
            {
                // Read values from service app settings
                string fromEmailId = services.Settings["SendGridFromEmailId"];
                string fromEmailUserName = services.Settings["SendGridFromEmailUserName"];
                string sendGridUserName = services.Settings["SendGridUserName"];
                string sendGridPassword = services.Settings["SendGridPassword"];

                if (string.IsNullOrEmpty(fromEmailId) || string.IsNullOrEmpty(fromEmailUserName) ||
                    string.IsNullOrEmpty(sendGridUserName) || string.IsNullOrEmpty(sendGridPassword))
                {
                    services.Log.Warn("SendGrid is not properly configured, skipping sending e-mail.");
                    return;
                }

                SendGrid jobCompleteEmailMessage = SendGrid.GetInstance();
                jobCompleteEmailMessage.AddTo(managerEmail);
                jobCompleteEmailMessage.From = new MailAddress(fromEmailId, fromEmailUserName);
                jobCompleteEmailMessage.Subject = "Job Complete Report from:" + agentName;
                jobCompleteEmailMessage.Html = htmlContent;

                var credentials = new NetworkCredential(sendGridUserName, sendGridPassword);

                // Create a REST transport for sending email.
                var transportREST = Web.GetInstance(credentials);
                transportREST.Deliver(jobCompleteEmailMessage);
                services.Log.Info("Job complete email sent for jobId: " + job.Id);
            }
            catch (Exception ex)
            {
                services.Log.Error("Error sending email: " + ex.Message);
            }
        }
    }
}
