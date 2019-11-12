<#
    .SYNOPSIS 
    Creates a Windows Azure storage account. 
            
    .DESCRIPTION
    The New-AzureStorage.ps1 script creates a Windows
    Azure storage account (New-AzureStorageAccount)
    and returns a hashtable with the storage account 
    name, the primary account key, and a connection 
    string.
    
    This script is a helper script for the 
    New-AzureWebsiteEnv.ps1 script.
            
    .PARAMETER  Name
    Specifies a name for the storage account. The 
    name must must be globally unique. It must have
    between 3 and 24 characters and include only 
    lower-case letters and numbers. If you enter a name
    with upper-case letters, the script converts them
    to lower case. This parameter is required. 

    The New-AzureWebsiteEnv.ps1 script uses the value:
    <Website_Name>storage.
    
    .PARAMETER Location
    Specifies the location of the Windows Azure subscription. 
    The default value is "West US".
    
        Valid values:
    -- East Asia
    -- East US
    -- North Central US
    -- North Europe
    -- West Europe
    -- West US 

    .INPUTS
    System.String

    .OUTPUTS
    System.Collections.Hashtable

    This script returns a hashtable of information about the
    storage account that it creates. The keys are:

    -- AccountName
    -- AccessKey (primary)
    -- ConnectionString

    .EXAMPLE
    PS C:\> $hash = .\New-AzureStorage.ps1 -Name contosostorage -Location "North Europe"
    
    PS C:\> $hash    

    Name                           Value                                                                                                                                                           
    ----                           -----                                                                                                                                                           
    ConnectionString               BlobEndpoint=http://ContosoStorage.blob.core.windows.net/;QueueEndpoint=http://ContosoStorage.queue.core.windows.net...
    AccessKey                      XrmGWqu9qpgKX5G3lf+V5Bc0nFIGjGWiWhHTdMxkA5Mb4WjJ0rDV+3USWW/6fAWCrszrkr2+JUb1c5mxQdq4nw==                                                                        
    AccountName                    ContosoStorage                                                                                                                                                  

    PS C:\> $hash.ConnectionString
    "BlobEndpoint=http://ContosoStorage.blob.core.windows.net/;QueueEndpoint=http://ContosoStorage.queue.core.windows.net/;TableEndpoint=http://ContosoStorage.table.core.windows.net/;AccountName=ContosoStorage;AccountKey='XrmGWqu9qpgKX5G3lf+V5Bc0nFIGjGWiWhHTdMxkA5Mb4WjJ0rDV+3USWW/6fAWCrszrkr2+JUb1c5mxQdq4nw=='"
    

    .LINK
    New-AzureStorageAccount

    .LINK
    Get-AzureStorageKey

    .LINK
    New-AzureWebsiteEnv.ps1

    .LINK
    Windows Azure Management Cmdlets (http://go.microsoft.com/fwlink/?LinkID=386337)

    .LINK
    How to install and configure Windows Azure PowerShell (http://go.microsoft.com/fwlink/?LinkID=320552)
#>
[CmdletBinding(PositionalBinding=$True)]
Param(
    [Parameter(Mandatory = $true)]
    [String]$Name,    
    [String]$Location = "West US"
)

$Name = $Name.ToLower()

# Create a new storage account
Write-Verbose "[Start] creating $Name storage account $Location location"

$storageAcct = New-AzureStorageAccount -StorageAccountName $Name -Location $Location -Verbose
if ($storageAcct)
{
    Write-Verbose "[Finish] creating $Name storage account in $Location location"
}
else
{
    throw "Failed to create a Windows Azure storage account. Failure in New-AzureStorage.ps1"
}

# Get the access key of the storage account
$key = Get-AzureStorageKey -StorageAccountName $Name
if (!$key) {throw "Failed to get storage key for $Name storage account. Failure in Get-AzureStorageKey in New-AzureStorage.ps1"}
$primaryKey = $key.Primary

# Generate the connection string of the storage account
$connectionString = "BlobEndpoint=http://$Name.blob.core.windows.net/;QueueEndpoint=http://$Name.queue.core.windows.net/;TableEndpoint=http://$Name.table.core.windows.net/;AccountName=$Name;AccountKey=$primaryKey"
Return @{AccountName = $Name; AccessKey = $primaryKey; ConnectionString = $connectionString}