<#
    .SYNOPSIS 
    Publishes a Windows Azure website project
            
    .DESCRIPTION
    The Publish-AzureWebsiteDevbox.ps1 script publishes
    the project that is associated with a Windows Azure
    website. 

    To run this script, you must have a Windows Azure 
    website associated with your Windows Azure account.
    To verify, run the Get-AzureWebsite cmdlet.
            
    .PARAMETER  ProjectFile
    Specifies the .csproj file of the project that you
    want to deploy. This parameter is required.

    .PARAMETER  Launch
    Starts a browser that displays the website. This
    switch parameter is optional.

    .INPUTS
    System.String

    .OUTPUTS
    None. This script does not return any objects.

    .NOTES
    This script automatically sets the $VerbosePreference to Continue, 
    so all verbose messages are displayed, and the $ErrorActionPreference
    to Stop so that non-terminating errors stop the script.

    .EXAMPLE
    Publish-AzureWebsiteDevbox.ps1 -ProjectFile FixitDemo.csproj

    .EXAMPLE
    Publish-AzureWebsiteDevbox.ps1 -ProjectFile FixitDemo.csproj -Launch
 
    .LINK
    Show-AzureWebsite
#> 
Param(
    [Parameter(Mandatory = $true)]
    [String]$ProjectFile,
    [Switch]$Launch
)

# Begin - Actual script -----------------------------------------------------------------------------------------------------------------------------
 
# Set the output level to verbose and make the script stop on error
$VerbosePreference = "Continue"
$ErrorActionPreference = "Stop"
 
$scriptPath = Split-Path -parent $PSCommandPath

# Verify that the account credentials are current in the Windows 
#  PowerShell session. This call fails if the credentials have
#  expired in the session.
Write-Verbose "Verifying that Windows Azure credentials in the Windows PowerShell session have not expired."
Get-AzureWebsite | Out-Null
 
# Mark the start time of the script execution
$startTime = Get-Date

# Build and publish the project via web deploy package using msbuild.exe 
Write-Verbose ("[Start] deploying to Windows Azure website {0}" -f $websiteName)

# Read from website-environment.xml to get the environment name
[Xml]$envXml = Get-Content $scriptPath\website-environment.xml
if (!$envXml) {throw "Error: Cannot find the website-environment.xml in $scriptPath"}
$websiteName = $envXml.environment.name

# Read from the publish settings file to get the deploy password
$publishXmlFile = Join-Path $scriptPath -ChildPath ($websiteName + ".pubxml")
[Xml]$xml = Get-Content $scriptPath\$websiteName.publishsettings
if (!$xml) {throw "Error: Cannot find a publishsettings file for the $website web site in $scriptPath."}
$password = $xml.publishData.publishProfile.userPWD[0]

# Run MSBuild to publish the project
& "$env:windir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" $ProjectFile `
    /p:VisualStudioVersion=12.0 `
    /p:DeployOnBuild=true `
    /p:PublishProfile=$publishXmlFile `
    /p:Password=$password

Write-Verbose "[Finish] deploying to Windows Azure website $websiteName"
# Mark the finish time of the script execution
$finishTime = Get-Date

# Output the time consumed in seconds
Write-Output "Total time used (seconds): ($finishTime - $startTime).TotalSeconds)"s

# if -Launch, launch the browser to show the website
If ($Launch)
{
    Show-AzureWebsite -Name $websiteName
}

# End - Actual script -------------------------------------------------------------------------------------------------------------------------------