## Tools needed ##

 - [Visual Studio 2013](http://www.visualstudio.com/en-us/downloads) 
 - [Windows Store Developer account](https://appdev.microsoft.com/StorePortals/en-US/Account/signup/start)
 - [SQL Server management studio](http://www.microsoft.com/en-us/download/details.aspx?id=29062)
 - [Azure User Management Console]( http://aumc.codeplex.com/)
 - [Azure Subscription](http://azure.microsoft.com/en-us/)
 
## Building Solution ##

- Install [Bing Maps Extension](http://visualstudiogallery.msdn.microsoft.com/224eb93a-ebc4-46ba-9be7-90ee777ad9e1)
- Install [SQLite for Windows 8.1](http://visualstudiogallery.msdn.microsoft.com/1d04f82f-2fe9-4727-a2f9-a2db127ddc9a)
- Open [../AzureMobile.Samples.FieldEngineer.sln](../AzureMobile.Samples.FieldEngineer.sln) and build solution. This will download all the required nuget package references

## Mobile Service Setup ##

1. Create New MobileService with new database on [Azure Portal](https://manage.windowsazure.com/)
2. [Register an app with windows store](http://msdn.microsoft.com/en-US/windows/apps/br211386)
3. [Setup Push credentials](http://msdn.microsoft.com/en-us/library/azure/jj591526.aspx)

## Azure Active Directory Setup ##

1. Follow instructions at  [Single Sign on with AAD](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-windows-store-dotnet-adal-sso-authentication/ "AADNativeApp") to setup AAD native app.
2. Follow instructions [AAD authentication with Mobile Service](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-how-to-register-active-directory-authentication/ "MobileServiceAADAuth") to use AAD authentication with MobileService
3. Go to configure page for the AAD Web App created above: 
 (This App will be used to update/read information about AAD users)
 -  Update permissions to include all the delegated permissions. 
 -  Update permissions to include Read and Write Directory Data Application Permissions.
 -  Create a key. **Make sure you save the key created at this step. We will need this later**
 
4. GO to Groups tab on AD and create two groups:
	   - FieldAgents 
	   - Managers
5. Save following information from the AD:

 - Go to FieldAgent group configure page. Get the object id for the group. 
 - Go to Manager group configure page. Get the object id for the group. 
 - Go to Domains page for directory. Get the default domain. 

## Create Active Directory Users ##
1. Go to Users tab, create a minimum of **3** users. Once the user is created add alternate email address on profile tab. 
2. Go to FieldAgents Group and Add 2 members
3. Go to Managers Group and 1 member

Jobs in database are equally distributed among the users in FieldAgents. You can increase the number of users to suit your needs.


## Database setup ##

1. Configure SQL server to allow connecting from SQL Management studio by updating allowed IP addresses from SQL Server configure page
2. Connect to sql server from SQL Management studio. Server name looks like: <xxxxx>.database.windows.net
3. Right click on the database connected to MobileService. Open New Query.
4. Open "azure-mobile-accelerators-pr\FieldEngineer\AzureMobile.Samples.FieldEngineer.Setup\SQLDBSetup.sql" file 	in the query window. And run the script. Once the query executes, you should able to query data in the tables.
5. Now, sql db connected to MobileService has the data to work with windows store app. Tables are created in [dbo] schema. Database user created by MobileService does not have permissions to access dbo schema. Open [Azure User Management Console]( http://aumc.codeplex.com/). Connect to the SQL server. Open Database attached. Double click on the User  with name like xxxxxLoginUser and give db_datawriter and db_datareader permissions

6. Open AzureMobile.Samples.FieldEngineer.Setup project and update following in App.config:
  - AadTenantDomain : Your Active Directory Domain name. Get this from Domains tab on your directory. This looks like: xxxxxxxx.onmicrosoft.com
  - MS_AadClientID: Client id for the Web App you setup
  - AadServiceAppKey: Key you saved earlier in Active Directory Setup
  - AadFieldAgentGroupObjectId: ObjectId for FieldAgents Group. You can get this from FieldAgents Group configure page
  - AadFieldManagerGroupObjectId: ObjectId for Managers Group. You can get this from Managers Group configure page
  - MS_TableConnectionString : SQL Azure Connection string. Get ADO.Net connection string from Azure SQL DB Dashboard.
  - Run project

## Publish Mobile Service ##

1.  Add following AppSettings from Mobile Service from Configure page on [Azure Portal](https://manage.windowsazure.com)
	- Key: AadFieldAgentGroupObjectId Value: Object Id for the FieldAgents group
	- Key: AadFieldManagerGroupObjectId Value: Object Id for the Managers group
	- Key: AadTenantDomain Value: AAD Domain
	- Key: AadServiceAppKey Value: This is the key from AD Web App 	

2. To send email when job is completed, set up SendGrid account and add following AppSettings in MobileService:
	- Key: SendGridUserName value: SendGrid account user name
	- Key: SendGridPassword value: Send grid account password
	- Key: SendGridFromEmailId value: Address from which you Email will be sent
	- Key: SendGridFromEmailUserName value: Your name

  
3. Publish Service to the MobileService you created. To see how to publish take a look at "Publish Your Mobile Service" section [in this article](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-dotnet-backend-windows-store-dotnet-get-started/)

## Run Windows Store App ##
1. Update following in Secrets.cs:
 - MobileServiceUrl = "https Mobile Service URL";
 - MobileServiceAccessKey = "Mobile Service Application Key";
 - AadDomainName = "AAD Domain Name";
 - AadNativeClientId = "Native App Client ID";

2. Run AzureMobile.Samples.FieldEngineer.Windows project

3. Login using AD user credentials. You can login with any user from FieldAgents group
