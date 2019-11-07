#   [Field Engineer](https://github.com/WindowsAzure/azure-mobile-accelerators-pr/wiki/Field-Engineer)
  

## This solution contains the following projects: ##

**AzureMobile.Samples.FieldEngineer.Setup**

- Uses ADGraph Client API to add manager relationships to users in your Azure Active Directory (AAD)

- Uses Entity Framework to connect to your database and assign jobs to users in your AAD

**AzureMobile.Samples.FieldEngineer.Service**
 
- MobileService .Net Backend service with SQL Azure database

- Works with the database setup by the AzureMobile.Samples.FieldEngineer.Setup project

- Uses Azure Active Directory Role Based Authentication

- Uses NotificationHub template to send Toast notification to agent/user when a new job is assigned

- Uses AutoMapper to work with relationships in DB data models   

**AzureMobile.Samples.FieldEngineer.Windows**
 
- Windows Store App that connects to Mobile Service setup by AzureMobile.Samples.FieldEngineer.Service

- Uses Azure Active Directory authentication

- Uses **offline** support in Mobile Services SDK to work with data if the app is offline 

- Lists jobs owned by the logged in user. Lets user update the job even when the app is offline

# Setup and Run #
Please see setup instructions [here](AzureMobile.Samples.FieldEngineer.Setup/ReadMe.md) to deploy your own MobileService and use your own Windows Store App

   