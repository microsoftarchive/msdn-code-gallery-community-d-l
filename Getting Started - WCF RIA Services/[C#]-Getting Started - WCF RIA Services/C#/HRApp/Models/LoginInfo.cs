namespace HRApp.LoginUI
{
    using System.ComponentModel.DataAnnotations;
    using System.ServiceModel.DomainServices.Client;
    using HRApp.Web.Resources;
    using HRApp.Resources;

    /// <summary>
    ///     This internal entity is used to ease the binding between the UI controls
    ///     (DataForm and the label displaying a validation error) and the log on
    ///     credentials entered by the user
    /// </summary>
    public class LoginInfo : Entity
    {
        [Display(Name = "UserNameLabel", ResourceType = typeof(RegistrationDataResources))]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "PasswordLabel", ResourceType = typeof(RegistrationDataResources))]
        [Required]
        public string Password { get; set; }

        [Display(Name = "RememberMeLabel", ResourceType = typeof(ApplicationStrings))]
        public bool RememberMe { get; set; }

        /// <summary>
        ///     Creates a new <see cref="System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters"/>
        ///     using the data stored in this entity
        /// </summary>
        public System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters ToLoginParameters()
        {
            return new System.ServiceModel.DomainServices.Client.ApplicationServices.LoginParameters(this.UserName, this.Password, this.RememberMe, null);
        }
    }
}
