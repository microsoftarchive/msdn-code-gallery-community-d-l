namespace HRApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Web.Profile;
    using System.Web.Security;
    using HRApp.Web.Resources;

    /// <summary>
    ///   RIA Services Domain Service that exposes methods for performing user
    ///   registrations.
    /// </summary>
    [EnableClientAccess]
    public class UserRegistrationService : DomainService
    {
        // Users will be added to this role by default
        public const string DefaultRole = "Registered Users";

        //// NOTE: This is a sample code to get your application started. In the production code you would 
        //// want to provide a mitigation against a denial of service attack by providing CAPTCHA 
        //// control functionality or verifying user's email address.

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void AddUser(RegistrationData user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            // Run this BEFORE creating the user to make sure roles are enabled and the default role
            // will be available
            //
            // If there are a problem with the role manager it is better to fail now than to have it
            // happening after the user is created
            if (!Roles.RoleExists(UserRegistrationService.DefaultRole))
            {
                Roles.CreateRole(UserRegistrationService.DefaultRole);
            }

            // NOTE: ASP.NET by default uses SQL Server Express to create the user database. 
            // CreateUser will fail if you do not have SQL Server Express installed.
            MembershipCreateStatus createStatus;
            Membership.CreateUser(user.UserName, user.Password, user.Email, user.Question, user.Answer, true, null, out createStatus);

            if (createStatus != MembershipCreateStatus.Success)
            {
                throw new DomainException(ErrorCodeToString(createStatus));
            }

            // Assign it to the default role
            // This *can* fail but only if role management is disabled
            Roles.AddUserToRole(user.UserName, UserRegistrationService.DefaultRole);

            // Set its friendly name (profile setting)
            // This *can* fail but only if Web.config is configured incorrectly 
            ProfileBase profile = ProfileBase.Create(user.UserName, true);
            profile.SetPropertyValue("FriendlyName", user.FriendlyName);
            profile.Save();
        }

        // This is never used but without it RIA Services will complain RegistrationData
        // is not exposed as an entity
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IEnumerable<RegistrationData> GetUsers()
        {
            throw new NotSupportedException();
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx for
            // a full list of status codes and add appropriate error handling.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return ClientCultureBasedResources.GetResource(() => ErrorResources.MembershipCreateStatusDuplicateUserName);

                case MembershipCreateStatus.DuplicateEmail:
                    return ClientCultureBasedResources.GetResource(() => ErrorResources.MembershipCreateStatusDuplicateEmail);

                case MembershipCreateStatus.ProviderError:
                    return ClientCultureBasedResources.GetResource(() => ErrorResources.MembershipCreateStatusProviderError);

                case MembershipCreateStatus.UserRejected:
                    return ClientCultureBasedResources.GetResource(() => ErrorResources.MembershipCreateStatusUserRejected);

                case MembershipCreateStatus.InvalidPassword:
                case MembershipCreateStatus.InvalidEmail:
                case MembershipCreateStatus.InvalidAnswer:
                case MembershipCreateStatus.InvalidQuestion:
                case MembershipCreateStatus.InvalidUserName:
                    // All this errors should have been handled by the UI validation so theoretically
                    // we should never get to this point
                    return "Validation Error: " + createStatus.ToString();

                default:
                    return "Could not register the user, please verify the provided information and try again.";
            }
        }
    }
}