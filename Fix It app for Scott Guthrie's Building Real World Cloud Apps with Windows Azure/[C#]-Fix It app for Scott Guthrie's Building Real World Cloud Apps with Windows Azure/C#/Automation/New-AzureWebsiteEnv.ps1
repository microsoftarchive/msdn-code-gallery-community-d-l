<#
    .SYNOPSIS
    Creates the environment for a Windows Azure web site, including the 
    databases and storage that the website requires.
            
    .DESCRIPTION
    The New-AzureWebsiteEnv.ps1 script automates the process of 
    creating a Windows Azure web site and its environment, including 
    a storage account for blobs and queues, a SQL Database server, 
    an application database, and a membership database.
    
    This script also adds environment variables ("AppSettings") and 
    connection strings that allow the web site to access the storage 
    account and databases.

    New-AzureWebsiteEnv.ps1 requires that Windows Azure PowerShell
    be installed and configured to work with your Windows Azure
    subscription. For details, see "How to install and configure 
    Windows Azure PowerShell" at 
    http://go.microsoft.com/fwlink/?LinkID=320552.

    It also calls two helper scripts, New-AzureSql.ps1 and
    New-AzureStorage.ps1, which must be in the same directory
    as this script.

    Finally, the script createes the website-environment.xml 
    file for the website deployment script and the <Website_Name>.pubxml
    file that Windows Azure needs to deploy the website. It 
    saves these files in the script directory.
    
           
    .PARAMETER  Name
    Specifies the name of the web site. Web site names must be
    unique in the azurewebsites.net domain. Enter an alphanumber string.
    The name is case-insensitive and is also used to name resources
    that are related to the website, such as the storage account. 
    This parameter is required.

    .PARAMETER  Location
    Specifies a Windows Azure location. The location must support web 
    sites. The default value is "West US". 

    Valid values:
    -- East Asia
    -- East US
    -- North Central US
    -- North Europe
    -- West Europe
    -- West US

    .PARAMETER  SqlDatabaseUserName
    Specify a user name for the SQL database that the script 
    creates for the web site. The script creates one user with 
    a user name and password. The default value is "dbuser".

    .PARAMETER  SqlDatabasePassword
    Specify a password for the SQL database user account that the 
    script creates. This parameter is required by the helper script
    that creates the database. If you omit this parameter, you'll be
    prompted for a password when database script is called.

    .PARAMETER StartIPAddress
    The starting address of the range of IP addresses in the SQL 
    Azure firewall rule. If you omit this parameter, the script 
    creates an IP address range from the public IP address of the 
    local machine.

    .PARAMETER EndIPAddress
    The last address of the range of IP addresses in the SQL 
    Azure firewall rule. If you omit this parameter, the script 
    creates an IP address range from the public IP address of the 
    local machine.

    
    .INPUTS
    System.String

    .OUTPUTS

    .NOTES
    This script sets the $VerbosePreference variable to "Continue", so all 
    Verbose messages are displayed without using the Verbose common parameter. 
    It also sets the $ErrorActionPreference variable to "Stop" which stops the
    script when it generates non-terminating errors.

    This script calls the following helper scripts and expects them to be in 
    the same directory:
    -- New-AzureSql.ps1
    -- New-AzureStorage.ps1

    .EXAMPLE
    New-AzureWebsiteEnv.ps1 -Name ContosoTesting -SqlDatabasePassword P@ssw0rd

    .EXAMPLE
    New-AzureWebsiteEnv.ps1 -Name TestSite -Location "West Europe" -SqlDatabaseUserName AdminUser `
        -SqlDatabasePassword P@ssw0rd -StartIpAddress 216.142.28.0 -EndIPAddress 216.142.28.255
 
    .LINK
    New-AzureWebsite
    
    .LINK
    Set-AzureWebsite
    
    .LINK
    New-AzureSql.ps1
    
    .LINK
    New-AzureStorage.ps1

    .LINK
    Windows Azure Management Cmdlets (http://go.microsoft.com/fwlink/?LinkID=386337)

    .LINK
    How to install and configure Windows Azure PowerShell (http://go.microsoft.com/fwlink/?LinkID=320552)
#>


[CmdletBinding(PositionalBinding=$True)]
Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$Name,                             # required    needs to be alphanumeric    
    [String]$Location = "West US",             # optional    default to "West US", needs to be a location which all the services created here are available
    [String]$SqlDatabaseUserName = "dbuser",   # optional    default to "dbuser"
    [String]$SqlDatabasePassword,              # optional    optional, but required by a helper script. Set the value here or the helper script prompts you.
    [String]$StartIPAddress,                   # optional    start IP address of the range you want to whitelist in SQL Azure firewall will try to detect if not specified
    [String]$EndIPAddress                      # optional    end IP address of the range you want to whitelist in SQL Azure firewall will try to detect if not specified
    )

# Begin - Helper functions --------------------------------------------------------------------------------------------------------------------------


<#
    .SYNOPSIS 
    Creates an environment xml file to deploy the website.
            
    .DESCRIPTION
    The New-EnvironmentXml function creates and saves
    to disk a website-environment.xml file. Windows Azure
    requires this file to deploy a website.

    New-EnvironmentXml requires a website-environment.template
    file in the script directory. This file is packaged with 
    the New-AzureWebsiteEnv.ps1 script. If the template file
    is missing, the function will fail.

    This function is designed as a helper function for
    the New-AzureWebsiteEnv.ps1 script.
            
    .PARAMETER  EnvironmentName
    Specifies a name for the website environment. Enter
    an alphanumic string. It's helpful when the name
    of the environment is related to the website name. 
    
    New-AzureWebsiteEnv.ps1 uses the website name 
    as the value of this parameter.

    .PARAMETER  WebsiteName
    Specifies the name of the website for which this
    environment is created. To get or to verify the 
    website name, use the Get-AzureWebsite cmdlet.

    .PARAMETER  Storage
    Specifies a hashtable of values about a Windows
    Azure storage account. The New-AzureStorage.ps1 script 
    returns this hashtable.

    .PARAMETER  Sql
    Specifies a hashtable of values about a Windows
    Azure database server and the member and application 
    databasaes. The New-AzureSql.ps1 script returns this 
    hashtable.

    .INPUTS
    System.String
    System.Collections.Hashtable

    .OUTPUTS
    None. This function creates and saves a
    website-environment.xml file to disk in the
    script directory.

    .EXAMPLE
    $sqlHash = .\New-AzureSql.ps1 -Password P@ssw0rd
    $storageHash = .\New-AzureStorage.ps1 -Name ContosoStorage
    
    New-EnvironmentXml -EnvironmentName MyWebSite -WebsiteName MyWebSite `
       -Storage $storageHash -Sql $sqlHash

    .LINK
    New-AzureWebsiteEnv.ps1

    .LINK
    Get-AzureWebsite
#>
Function New-EnvironmentXml
{
    Param(
        [String]$EnvironmentName,
        [String]$WebsiteName,
        [System.Collections.Hashtable]$Storage,
        [System.Collections.Hashtable]$Sql
    )

    [String]$template = Get-Content $scriptPath\website-environment.template
    
    $xml = $template -f $EnvironmentName, $WebsiteName, `
                        $Storage.AccountName, $Storage.AccessKey, $Storage.ConnectionString, `
                        ([String]$Sql.Server).Trim(), $Sql.UserName, $Sql.Password, `
                        $Sql.AppDatabase.Name, $Sql.AppDatabase.ConnectionString, `
                        $Sql.MemberDatabase.Name, $Sql.MemberDatabase.ConnectionString
    
    $xml | Out-File -Encoding utf8 -FilePath $scriptPath\website-environment.xml
}

<#
    .SYNOPSIS 
    Creates the pubxml file that's used to deploy the website.

    .DESCRIPTION
    The New-PublishXml function creates and saves
    to disk a <website_name>.pubxml file. The file includes
    values from the publishsettings file for the website. Windows 
    Azure requires a pubxml file to deploy a website.

    New-PublishXml requires a pubxml.template file in the 
    script directory. This file is packaged with the 
    New-AzureWebsiteEnv.ps1 script. If the template file
    is missing, the function will fail.

    This function is designed as a helper function for
    the New-AzureWebsiteEnv.ps1 script.
            

    .PARAMETER  WebsiteName
    Specifies the name of the website for which this
    environment is created. To get or to verify the 
    website name, use the Get-AzureWebsite cmdlet.

    .INPUTS
    System.String

    .OUTPUTS
    None. This function creates and saves a
    <WebsiteName>.xml file to disk in the
    script directory.

    .EXAMPLE
    New-PublishXml -WebsiteName MyWebSite

    .LINK
    New-AzureWebsiteEnv.ps1

    .LINK
    Get-AzureWebsite
#>
Function New-PublishXml
{
    Param(
        [Parameter(Mandatory = $true)]
        [String]$WebsiteName
    )
    
    # Get the current subscription
    $s = Get-AzureSubscription -Current
    if (!$s) {throw "Cannot get Windows Azure subscription. Failure in Get-AzureSubscription in New-PublishXml in New-AzureWebsiteEnv.ps1"}

    $thumbprint = $s.Certificate.Thumbprint
    if (!$thumbprint) {throw "Cannot get subscription cert thumbprint. Failure in Get-AzureSubscription in New-PublishXml in New-AzureWebsiteEnv.ps1"}
    
    # Get the certificate of the current subscription from your local cert store
    $cert = Get-ChildItem Cert:\CurrentUser\My\$thumbprint
    if (!$cert) {throw "Cannot find subscription cert in Cert: drive. Failure in New-PublishXml in New-AzureWebsiteEnv.ps1"}

    $website = Get-AzureWebsite -Name $WebsiteName
    if (!$website) {throw "Cannot get Windows Azure website: $WebsiteName. Failure in Get-AzureWebsite in New-PublishXml in New-AzureWebsiteEnv.ps1"}
    
    # Compose the REST API URI from which you will get the publish settings info
    $uri = "https://management.core.windows.net:8443/{0}/services/WebSpaces/{1}/sites/{2}/publishxml" -f `
        $s.SubscriptionId, $website.WebSpace, $Website.Name

    # Get the publish settings info from the REST API
    $publishSettings = Invoke-RestMethod -Uri $uri -Certificate $cert -Headers @{"x-ms-version" = "2013-06-01"}
    if (!$publishSettings) {throw "Cannot get Windows Azure website publishSettings. Failure in Invoke-RestMethod in New-PublishXml in New-AzureWebsiteEnv.ps1"}

    # Save the publish settings info into a .publishsettings file
    # and read the content as xml
    $publishSettings.InnerXml > $scriptPath\$WebsiteName.publishsettings
    [Xml]$xml = Get-Content $scriptPath\$WebsiteName.publishsettings
    if (!$xml) {throw "Cannot get website publishSettings XML for $WebsiteName website. Failure in Get-Content in New-PublishXml in New-AzureWebsiteEnv.ps1"}

    # Get the publish xml template and generate the .pubxml file
    [String]$template = Get-Content $scriptPath\pubxml.template
    ($template -f $website.HostNames[0], $xml.publishData.publishProfile.publishUrl.Get(0), $WebsiteName) `
        | Out-File -Encoding utf8 ("{0}\{1}.pubxml" -f $scriptPath, $WebsiteName)
}

function Get-MissingFiles
{
    $Path = Split-Path $MyInvocation.PSCommandPath
    $files = dir $Path | foreach {$_.Name}
    $required= 'New-AzureSql.ps1',
               'New-AzureStorage.ps1',
               'New-AzureWebsiteEnv.ps1',
               'pubxml.template',
               'website-environment.template'

    foreach ($r in $required)
    {            
        if ($r -notin $files)
        {
            [PSCustomObject]@{"Name"=$r; "Error"="Missing"}
        }
    }
}


# End - Helper funtions -----------------------------------------------------------------------------------------------------------------------------


# Begin - Actual script -----------------------------------------------------------------------------------------------------------------------------

# Set the output level to verbose and make the script stop on error
$VerbosePreference = "Continue"
$ErrorActionPreference = "Stop"

# Get the time that script execution starts
$startTime = Get-Date
Write-Verbose "Checking for required files."
$missingFiles = Get-MissingFiles
if ($missingFiles) {$missingFiles; throw "Required files missing from WebSite subdirectory. Download and upzip the package and try again."}

# Running Get-AzureWebsite only to verify that Azure credentials in the PS session have not expired (expire 12 hours)
# If the credentials are expired, cmdlet throws a terminating error that stops the script.
Write-Verbose "Verifying that Windows Azure credentials in the Windows PowerShell session have not expired."
Get-AzureWebsite | Out-Null


Write-Verbose "[Start] creating Windows Azure website environment: $Name"
# Get the directory of the current script
$scriptPath = Split-Path -parent $PSCommandPath

# Define the names of website, storage account, SQL Azure database and SQL Azure database server firewall rule
$Name = $Name.ToLower()
$storageAccountName = $Name + "storage"
$sqlAppDatabaseName = "appdb"
$sqlMemberDatabaseName = "memberdb"
$sqlDatabaseServerFirewallRuleName = $Name + "rule"

Write-Verbose "Creating a Windows Azure website: $Name"
# Create a new website
#    The New-AzureWebsite cmdlet is exported by the Azure module.
$website = New-AzureWebsite -Name $Name -Location $Location -Verbose
if (!$website) {throw "Error: Website was not created. Terminating the script unsuccessfully. Fix the errors that New-AzureWebsite returned and try again."}

Write-Verbose "Creating a Windows Azure storage account: $storageAccountName"
# Create a new storage account
$storage = & "$scriptPath\New-AzureStorage.ps1" -Name $storageAccountName -Location $Location
if (!$storage) {throw "Error: Storage account was not created. Terminating the script unsuccessfully. Fix the errors that New-AzureStorage.ps1 script returned and try again."}

Write-Verbose "Creating a Windows Azure database server and databases"
# Create a SQL Azure database server, app and member databases
$sql = & "$scriptPath\New-AzureSql.ps1" `
    -AppDatabaseName $sqlAppDatabaseName `
    -MemberDatabaseName $sqlMemberDatabaseName `
    -UserName $SqlDatabaseUserName `
    -Password $SqlDatabasePassword `
    -FirewallRuleName $sqlDatabaseServerFirewallRuleName `
    -StartIPAddress $StartIPAddress `
    -EndIPAddress $EndIPAddress `
    -Location $Location
if (!$sql) {throw "Error: The database server or databases were not created. Terminating the script unsuccessfully. Failures occurred in New-AzureSql.ps1."}

Write-Verbose "[Start] Adding settings to website: $Name"
# Configure app settings for storage account and New Relic
$appSettings = @{ `
    "StorageAccountName" = $storageAccountName; `
    "StorageAccountAccessKey" = $storage.AccessKey; `
    "COR_ENABLE_PROFILING" = "1"; `
    "COR_PROFILER" = "{71DA0A04-7777-4EC6-9643-7D28B46A8A41}"; `
    "COR_PROFILER_PATH" = "C:\Home\site\wwwroot\newrelic\NewRelic.Profiler.dll"; `
    "NEWRELIC_HOME" = "C:\Home\site\wwwroot\newrelic" `
}

# Configure connection strings for appdb and ASP.NET member db
$connectionStrings = ( `
    @{Name = $sqlAppDatabaseName; Type = "SQLAzure"; ConnectionString = $sql.AppDatabase.ConnectionString}, `
    @{Name = "DefaultConnection"; Type = "SQLAzure"; ConnectionString = $sql.MemberDatabase.ConnectionString}
)

Write-Verbose "Adding connection strings and storage account name/key to the new $Name website."
# Add the connection string and storage account name/key to the website
$error.clear()
Set-AzureWebsite -Name $Name -AppSettings $appSettings -ConnectionStrings $connectionStrings
if ($error) {throw "Error: Call to Set-AzureWebsite with database connection strings failed."}


# Restart the website to let New Relic hook kick in
$error.clear()
Restart-AzureWebsite -Name $Name
if ($error) {throw "Error: Call to Restart-AzureWebsite to make the relic effective failed."}

Write-Verbose "[Finish] Adding settings to website: $Name"
Write-Verbose "[Finish] creating Windows Azure environment: $Name"

# Write the environment info to an xml file so that the deploy script can consume
Write-Verbose "[Begin] writing environment info to website-environment.xml"
New-EnvironmentXml -EnvironmentName $Name -WebsiteName $Name -Storage $storage -Sql $sql

if (!(Test-path $scriptPath\website-environment.xml))
{
    throw "The script did not generate a website-environment.xml file that is required to deploy the website. Try to rerun the New-EnvironmentXml function in the New-AzureWebisteEnv.ps1 script."
}
else 
{
    Write-Verbose "$scriptPath\website-environment.xml"
    Write-Verbose "[Finish] writing environment info to website-environment.xml"
}

# Generate the .pubxml file which will be used by webdeploy later
Write-Verbose "[Begin] generating $Name.pubxml file"
New-PublishXml -Website $Name
if (!(Test-path $scriptPath\$Name.pubxml))
{
    throw "The script did not generate a $Name.pubxml file that is required for deployment. Try to rerun the New-PublishXml function in the New-AzureWebisteEnv.ps1 script."
}
else 
{
    Write-Verbose "$scriptPath\$Name.pubxml"
    Write-Verbose "[Finish] generating $Name.pubxml file"
}

Write-Verbose "Script is complete."
# Mark the finish time of the script execution
$finishTime = Get-Date
# Output the time consumed in seconds
$TotalTime = ($finishTime - $startTime).TotalSeconds
Write-Output "Total time used (seconds): $TotalTime"

# End - Actual script ------------------------------------------------------------------------------------------------------------------------------- -