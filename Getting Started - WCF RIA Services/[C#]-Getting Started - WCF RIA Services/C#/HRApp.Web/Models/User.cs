namespace HRApp.Web
{
    using System.Runtime.Serialization;
    using System.ServiceModel.DomainServices.Server.ApplicationServices;

    public partial class User : UserBase
    {
        //// NOTE: Profile properties can be added for use in Silverlight application.
        //// To enable profiles, edit the appropriate section of web.config file.
        ////
        //// public string MyProfileProperty { get; set; }

        public string FriendlyName { get; set; }
    }
}
