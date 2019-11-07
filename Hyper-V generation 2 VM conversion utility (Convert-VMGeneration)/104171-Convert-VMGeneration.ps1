#
# ---------------------------------------------------------------------------------------------------------------------------
#
# http://code.msdn.microsoft.com/ConvertVMGeneration
# See the above site for license terms (Microsoft Limited Public License, MS-LPL)
#
# By:                  John Howard                - Program Manager, Hyper-V Team    
#                                                 - Prototype & Bulk of code [http://blogs.technet.com/jhoward]
#
#                      Stefan Wernli, Brian Young - Developers, Hyper-V Team         
#                                                 - Gave me lots of invaluable assistance. Thank you! :)
#
# Originally Created:  May - October 2013
#
# About:               Script for converting a Hyper-V virtual machine from generation 1 to generation 2.
#                      This script is not endorsed or supported by Microsoft Corporation.
#
# Requires:            Windows 8.1/Windows Server 2012 R2 with Hyper-V enabled as machine to run this script on
#                      Windows 8/8.1 (64-bit)/Windows Server 2012 or 2012 R2 as VM being converted to Generation 2
#
# History:             23rd Oct 2013, Version 1.01 - First public release
#                      31st Oct 2013, Version 1.02 - Additional trace points (make it easier to debug user reported problems)
#                                                  - Cache avoidance for new version check
#                                                  - Fixed bug where single partition source boot disk (eg using Convert-WindowsImage)
#                      5th Nov 2013,  Version 1.03 - Additions to tracing. In particular to catch a couple of reported exceptions
#                      6th Dec 2013,  Version 1.04 - Fixed exception in networking cloning
#                                                  - Additional tracing and logging
#
# ---------------------------------------------------------------------------------------------------------------------------
#
# Future improvements to consider: (Just keeping a list somewhere handy)
#
#  - Have parameter set including VM object http://technet.microsoft.com/en-us/library/hh847743.aspx
#  - Check for enough disk space before running the capture or apply
#  - Better handling of SCSI locations with multiple originating VM SCSI controllers. Including support for >64 devices.
#  - Handle FibreChannelConnection and FibreChannelPort resource pools. If anyone asks...
#
# ---------------------------------------------------------------------------------------------------------------------------
#

<#
  .SYNOPSIS
  Converts a Hyper-V generation 1 Windows based virtual machine to generation 2
  By John Howard, Hyper-V Team, Microsoft Corporation. (c) 2013.

  Please leave feedback on the home page for this utility if you find it useful (link below). Thank you :)
  .LINK
  http://blogs.technet.com/jhoward (Author blog)
  .LINK
  http://code.msdn.microsoft/ConvertVMGeneration
    .DESCRIPTION
  Generation 2 virtual machines were introduced in Hyper-V for Windows 8.1 and Windows Server 2012 R2.
  
  There is no in-box capability in Hyper-V to convert a generation 1 virtual machine to a generation 2 
  virtual machine. To manually convert, it would generally be necessary to install a new guest operating
  system instance, and migrate application settings across. Alternately, assuming the guest operating 
  system can run in a generation 2 virtual machine, a manual conversion can be performed.
  
  This cmdlet automates the conversion process. The process is done in three phases, each of which 
  can be performed seperately if desired using the -Action parameter.
  
  During the conversion process, this cmdlet leaves the source generation 1 virtual machine intact. However,
  you should ensure that once converted, both virtual machines are not started simultaneously as, for example,
  they may be attempting to access the same data disks; both appear to be the same machine from the network.

  Windows Recovery Environment (WinRE) and Push Button Reset (PBR) are not migrated. See parameters
  -IgnoreWinRE and -IgnorePBR for more information. 

  There are a number of features which are not migrated to the generation 2 virtual machine. Some due to
  devices differences between generation 1 and generation 2 virtual machines; some due to no API support;
  some due to my time when creating this script. A non-exhaustive list is below:

  - COM ports; Floppy; Empty and physical DVD drives; Legacy Network Adapters; RemoteFX; .VHD disks are skipped.
  - VMs with checkpoints cannot be converted
  - VMs with multiple windows partitions on the source boot disk cannot be converted
  - Additional data partitions on the source boot disk are not converted (although additional disks are)
  - 32-bit guest operating systems cannot be converted
  - Windows operating systems prior to Windows 8/Windows Server 2012 cannot be converted
  - Non-Windows operating systems cannot be converted (although other tools may exist)
  - Resource metering is not carried across to the converted virtual machine

  IMPORTANT
  ---------

  During the conversion process, there is one highly destructive operation which entails deleting all 
  data on a disk (the VHDX used as the boot disk for the generation 2 virtual machine). As this is such
  a destructive operation, and there is always a risk of a coding error, there is a prompt to confirm
  this operation. Further, against PowerShell guidelines, this prompt cannot be suppressed. This is a 
  conscious design choice rendering this script unsuitable for batch usage.
   
  .EXAMPLE
  .\Convert-VMGeneration.ps1 -VMName "Convert me" -Path C:\ClusterStorage\Volume1 
  
  Converts a generation 1 virtual machine named 'Convert me'. The result will be the creation
  of a virtual machine 'Convert me (Generation 2)' with a new boot disk. 
  .EXAMPLE
  .\Convert-VMGeneration.ps1 -VMName "Convert me" -VHDXSizeGB 40
  
  Converts a generation 1 virtual machine named 'Convert me'. The result will be the creation
  of a virtual machine 'Convert me (Generation 2)' with a new boot disk of size 40GB. This
  will fail if there is not enough space to fit the contents into the new VHDX.
  .EXAMPLE  
  .\Convert-VMGeneration.ps1 -VMName "Convert me" -OverwriteVM -OverwriteVHDX -OverwriteWIM -WIM "c:\interim.wim" -KeepWIM

  Converts a generation 1 virtual machine named 'Convert me' to a generation 2 virtual machine
  named 'Convert me (Generation 2)'. In this example, if the interim .WIM file, the new boot disk
  for the generation 2 virtual machine, or the virtual machine 'Convert me (Generation 2)' exists,
  they will be overwritten.
    .EXAMPLE
  .\Convert-VMGeneration.ps1 -VMName "Convert me" -Action Capture -WIM "c:\storage\captured.wim" -OverwriteWIM

  Captures the boot disk of a generation 1 virtual machine named 'Convert me' into
  c:\storage\captured.wim, which already exists and should be overwritten.
  .PARAMETER VMName
  The name of the virtual machine to be converted from generation 1 to generation 2.
  Required for All, Capture and Clone Actions.
  Optional for Apply action. If not present, -TargetVHDSizeGB must be supplied.
  .PARAMETER Action
  Defines what phase of the conversion process this script will perform. 
  
  Capture - Capture the Windows partition of the boot VHD(X) from a generation 1 virtual machine to a WIM
  Apply   - Applies the WIM to a boot VHDX for a generation 2 virtual machine and makes it bootable
  Clone   - Creates a generation 2 VM using the configuration template from a generation 1 virtual machine
  All     - Default action. Performs all the above in one pass in the order Capture, Apply, Clone
  .PARAMETER Path
  If supplied, this is used as the path in which to create the generation 2 virtual machine. By
  default, the path will be the same path as the source generation 1 virtual machine. It is
  recommended that this parameter is used.  
  .PARAMETER NoVersionCheck
  If present, this script will not look for a newer version of this script being available
  .PARAMETER NoPSVersionCheck
  If present, no validation on the version of PowerShell is made. It is not recommended that this is
  used, and only Windows PowerShell in Windows 8.1 and Windows Server 2012 R2 has been tested.
  .PARAMETER Quiet
  If present, informational output will be suppressed. Warnings, errors and a summary will not be suppressed.
  .PARAMETER IgnoreWinRE
  If present, this script will not stop if Windows Recovery Environment (WinRE) is configured on the 
  source virtual machine. It will be necessary to reconfigure WinRE in the target virtual machine
  after it has been created. It is strongly recommended that prior to conversion, WinRE is disabled
  in the source VM by running 'reagentc /disable' from an elevated command prompt. In the target VM,
  re-enable by running 'reagentc /enable' from an elevated command prompt.
  .PARAMETER IgnorePBR
  If present, this script will not stop if Push Button Reset is configured in the virtual machine.
  This script ignores OS recovery partitions during the conversion process. It will be necessary to
  manually reconfigure PBR in the generation 2 VM if desired. Note that this is not generally an
  issue in a virtual machine environment as PBR is not usually configured.
  More information can be found at http://technet.microsoft.com/library/jj126997.aspx
  .PARAMETER VHDXSizeGB
  If supplied, this is the size in GB of the newly created boot disk for use in the generation 2
  virtual machine. It must be between 1 and 64. If it is not supplied, the generation 2 boot VHDX
  size is calculated based on the size of the Windows partition in the source VMs boot disk, 
  combined with the size of other partitions necessary to support booting in a generation 2 virtual
  machine, and a WinRE partition. Making this size too small may mean that this script will fail.
  .PARAMETER VHDX
  Full file path to the VHDX to be used by the generation 2 virtual machine. By default, this script
  will create a new VHDX with the same name and path as the boot disk on the generation 1 virtual machine,
  appending '(Generation 2)' to the name. 
  .PARAMETER OverwriteVHDX
  If supplied, this script will not stop when attempting to create the VHDX for the boot disk of the
  generation 2 virtual machine if it already exists.
  .PARAMETER WIM
  Full file path to the WIM file containing a captured image of the generation 1 virtual machines
  boot disk Windows partition. By default, this script will create the WIM file in the %TEMP%
  directory. Use this parameter if you do not have enough diskspace in the %TEMP% directory, or
  intend to keep an archive as a time-saver for cloning.
  .PARAMETER KeepWIM
  If supplied, the WIM file will not be deleted after it is applied to the converted generation 2
  virtual machine.
  .PARAMETER OverwriteWIM
  If supplied, this script will not stop when attempting to create the WIM file containing an image
  of the Windows partition on the boot disk of the generation 1 virtual machine if it already exists.
  .PARAMETER OverwriteVM
  If supplied, this script will not stop when attempting to create the generation 2 virtual machine
  if it already exists.
  .PARAMETER NewVMName
  If supplied, this is the name used to create the generation 2 virtual machine. By default, the
  new virtual machine has the same name as the source generation 1 virtual machine, appended with
  '(Generation 2)'.
  .PARAMETER IgnoreReplicaCheck
  If supplied, this script will ignore the check to determine if the generation 1 virtual machine
  has Hyper-V Replica enabled for it. This is experimental - I have done no validation that this
  script works when replica is enabled.
 #>

[CmdletBinding(SupportsShouldProcess=$true, ConfirmImpact="High")]

param
(
    # Name of the VM
    # Removed [parameter(Mandatory=$true)] for the following reason:
    # If the action is apply, the only reason we would need the source VM is to find the boot disk so that subsequently we can find the size of the
    # Windows partition on it, so we can throw that into the calculation for the size of the target VHDX. However, as we have an explicit parameter
    # for the size of the target, if that is supplied on Apply, we don't need the originating VM name.
    [string] [ValidateNotNullOrEmpty()] [alias("Name")] $VMName="",

    # What this script is going to do
    [string] [ValidateSet("Capture", "Apply", "Clone", "All")] $Action="All",

    # Path of new VM (otherwise defaults to same path as source VM)
    [string]$Path="",

    # Check for later version
    [switch] $NoVersionCheck=$False,

    # Check for correct version of PS
    [switch] $NoPSVersionCheck=$False,

    # To be quiet in output (banners for example)
    [switch] $Quiet=$False,

    # Ignore if RE is configured. In Capture and All (validated seperately)
    [switch] $IgnoreWinRE=$False, 

    # Ignore if PBR is configured. In Capture and All (validated seperately)
    [switch] $IgnorePBR=$False,
    
    # Size of the new VHDX to be created. In Apply and All (validated seperately)
    [int32] [ValidateRange(1,64)] $VHDXSizeGB=0,

    # Name of the VHDX captured from the source and to boot the target VM. In Apply, Clone and All (validate seperately)
    [string] $VHDX="", 

    # Whether to overwrite the VHDX. In Capture and All (validated seperately)
    [switch]$OverwriteVHDX=$False,

    # Name of the WIM to use. In Capture, Apply and All (validated seperately)
    # - In Apply, the WIM must exist.
    # - In Apply or Capture, KeepWIM defaulted to True
    [string] $WIM="", 

    # Whether to keep the WIM after it's been used. In Apply and All (validated seperately)
    [switch] $KeepWIM=$False,

    # Whether to overwrite the WIM if it already exists. In Capture and All (validated seperately)
    [switch] $OverwriteWIM=$False,

    # Whether to overwrite the VM. In Clone and All (validated seperately)
    [switch]$OverwriteVM=$False,

    # Name of new VM (otherwise defaults to name of source VM plus "(generation 2)"
    [string] $NewVMName="",

    # To ignore the check for replica. Experimental
    [switch] $IgnoreReplicaCheck
      
)

# Make life a little more challenging.... All goodness though :)
Set-PSDebug -Strict
Set-StrictMode -Version latest

$script:Version = "1.04"                          # Version number of this script
$script:LastModified = "6th Dec 2013"             # Last modified date of this script
$script:TargetBootDiskMounted = $False            # Is the target VMs boot disk mounted?
$script:TargetDriveLetterESP = ""                 # Drive letter allocated to the ESP on the target disk
$script:TargetDriveLetterWindows = ""             # Drive letter allocated to the Windows partition on the target disk
$script:TargetDriveESPConfigured = $False         # Set to true once diskpart has been run on new VHDX
$script:SourceVMObject = $Null                    # Represents the VM being migrated to generation 1
$script:SourceBootDiskMounted = $False            # Is the source VMs boot disk mounted?
$script:SourceBootDiskPath = ""                   # From Get-VMDiskDrive for source boot disk
$script:SourceBootDiskWindowsPartition = $Null    # The partition on source VM boot disk containing Windows installation to migrate
$script:SourceBootDiskWindowsPartitionNum = -1    # The partition number of above. Only used for summary message, not for procesing.
$script:SourceBootDiskWindowsPartitionUsed = 0    # The bytes used on the source windows partition.
$script:CleanupCalled = $False                    # To stop re-entrant calls to cleanup()
$script:WarningCount = 0                          # Number of warnings found as we went along
$script:ReachedEndOfProcessing = $False           # Have we got to the end of everythign
$script:TestHookBCDBootWindowsDrive = ""          # Just a test hook. Nothing to see here, move along please...
$script:TestHookIgnoreParameterChecks = $False    # Same deal as above.
[int32]$script:ProgressPoint = 0                  # For tracking exit point

# ---------------------------------------------------------------------------------------------------------------------------
# Function to output progress
# ---------------------------------------------------------------------------------------------------------------------------
Function Write-Info ($info)   { if (!$Quiet){ Write-Host "INFO:    $info"  } }

# ---------------------------------------------------------------------------------------------------------------------------
# Function to cleanup everything when we're going to be quitting
# ---------------------------------------------------------------------------------------------------------------------------
Function Cleanup([string] $sDetail)  {

    # Only as I put cleanup() in the main finally block of code to absolutely make sure we clean up regardless
    if ($script:cleanupcalled) { 
        Write-Verbose "Exiting cleanup as already called"
        exit
    }
    $script:CleanupCalled = $True

    if ($sDetail.Length) { Write-Host -ForegroundColor Red ("`n" + $sDetail + "`n") }

    if (($script:SourceBootDiskMounted -eq $True) -and (($script:SourceBootDiskPath).Length)) {
        Write-Verbose ("Cleanup - unmounting " + ($script:SourceBootDiskPath))
        Dismount-DiskImage ($script:SourceBootDiskPath) -ErrorAction SilentlyContinue
        if (!$?) { Write-Error ("Failed to unmount "+ ($script:SourceBootDiskPath) + "`n"+ $Error[0][0]) }
    } else { Write-Verbose "Source was not mounted so not cleaning up" }
  
    if ($script:TargetBootDiskMounted -eq $True) {
        Write-Verbose "Cleanup - Unmounting the converted VHDX"
        # Workaround for bug where the ESP drive letter is leaked if the disk is unmounted without releasing the access path
        if ($script:TargetDriveLetterESP -ne "") {
            if ($script:TargetDriveESPConfigured -eq $True) {
                Write-Verbose ("TargetDriveLetterESP is " + ($script:TargetDriveLetterESP))
                Write-Verbose ("VHDX is " + ($VHDX))
                $DiskImage = (Get-DiskImage $VHDX )
                Write-Verbose ("DiskImage | Get-Disk is " + ($DiskImage | Get-Disk ))
                Write-Verbose ("DiskImage | Get-Disk Number is " + (($DiskImage | Get-Disk ).Number))
                Remove-PartitionAccessPath -disknumber (($DiskImage | Get-Disk).Number) `
                                           -PartitionNumber 3 `
                                           -AccessPath $script:TargetDriveLetterESP `
                                           -ErrorAction SilentlyContinue
                if (!$?) { Write-Error ("Failed to remove drive letter "+ $script:TargetDriveLetterESP + "`n"+ $Error[0][0]) }
                else { Write-Verbose "Called Remove-PartitionAccessPath OK" }
            } else { Write-Verbose "ESP is not configured" }
        } else { Write-Verbose "No target drive letter for ESP" }
        Write-Verbose ("Unmounting "+$VHDX)
        Dismount-DiskImage $VHDX -erroraction SilentlyContinue
        if (!$?) { Write-Error ("Failed to unmount "+ $VHDX + "`n"+ $Error[0][0]) }
    } else { Write-Verbose "Target was not mounted so not cleaning up" }

    # Delete (or retain) the WIM depending on user selection
    $WIMDeleted = $False
    if ($WIM -ne "") {
        if (!($KeepWIM)) {
            if (Test-Path $WIM) {
                Write-Verbose "Deleting captured image..."
                Remove-Item $WIM -ErrorAction SilentlyContinue
                if (!$?) { Write-Error ("Failed to remove WIM "+ $WIM + "`n"+ $Error[0][0]) }
                $WIMDeleted = $True
            } else {
                Write-Verbose ($WIM + " does not exist so not deleting")
            }
        } else {
            Write-Verbose ("WIM file " + $WIM + " retained")
        }
    } else { Write-Verbose "Don't have a WIM file to consider deleting" }


    Write-Verbose "Checking latest version"
    if (!$NoVersionCheck) { 
        if (-3 -eq (Check-LatestVersion "http://blogpics.dyndns.org/Convert-VMGeneration.txt")) { 
            $lvcheck = (Check-LatestVersion "http://blogs.technet.com/jhoward/pages/convertvmgenerationlatestversion.aspx")
        }
    }

    # All complete message.
    if ($sDetail.Length -eq 0) {
        if ($script:ReachedEndOfProcessing) {
            Write-Host ""
            Write-Host -ForegroundColor Yellow "SUMMARY:"

            switch ($script:Action) {
                "Capture" { Write-Host -ForegroundColor Yellow ("· Image file '" + $WIM + "' was created.")
                            Write-Host -ForegroundColor Yellow ("· Image contains partition " + $script:SourceBootDiskWindowsPartitionNum + " from '" + $script:SourceBootDiskPath + "' attached to virtual machine '" + $VMName + "'.")
                          }
                "Apply"   { Write-Host -ForegroundColor Yellow ("· '" + $VHDX + "' was created")
                            Write-Host -ForegroundColor Yellow ("· The contents of '" + $script:WIM + "' was applied to the Windows partition." ) 
                            if ($WIMDeleted) { Write-Host -ForegroundColor Yellow ("· WIM has been deleted (-KeepWIM to retain)." ) }
                          }
                "Clone"   { Write-Host -ForegroundColor Yellow ("· Virtual machine '" + $NewVMName + "' was created.")
                            Write-Host -ForegroundColor Yellow ("· Boot disk is '" + $VHDX + "'.")
                            Write-Host -ForegroundColor Yellow ("· Configuration was cloned from VM '" + $VMName + "'." )
                          }
                "All"     { Write-Host -ForegroundColor Yellow ("· Virtual machine '" + $NewVMName + "' was created.")
                            Write-Host -ForegroundColor Yellow ("· Boot disk is '" + $VHDX + "'.")
                            Write-Host -ForegroundColor Yellow ("· Configuration was cloned from VM '" + $VMName + "'." )
                            if (!($WIMDeleted)) { 
                                Write-Host -ForegroundColor Yellow ("· Image file '" + $WIM + "' has been retained." ) 
                                Write-Host -ForegroundColor Yellow ("· Image contains partition " + $script:SourceBootDiskWindowsPartitionNum + " from '" + $script:SourceBootDiskPath + "'.")
                            }
                          }
            } 
        } 

        Write-Host ""
	if ($script:ReachedEndOfProcessing) {
            if ($script:WarningCount -gt 0) {
                if ($script:WarningCount -gt 1) {
                    Write-Warning ("Completed with $script:WarningCount warnings. Trace status code " + $script:ProgressPoint)
                } else {
                    Write-Warning ("Completed with $script:WarningCount warning. Trace status code " + $script:ProgressPoint)
                }
            } else {
               Write-Info ("Complete.") 
            }
        } else { 
            $script:ProgressPoint += 100000
            Write-Host -ForegroundColor Cyan ("Terminated early. Trace status code " + $script:ProgressPoint)
        }
    } else { Write-Host -ForegroundColor Red ("Completed with error. Trace status code " + $script:ProgressPoint) }


    if ($script:ProgressPoint -gt 100000) { $script:ProgressPoint -= 100000 }  # Just in case (added above)
    if (($script:ProgressPoint -ge 90000) -and ($sDetail.Length)) {
        Write-Host -Foregroundcolor Cyan "--------------------------------------------------------------------------------------"
        Write-Host -Foregroundcolor Cyan "An exception occurred. Please report this bug by going to the home-page for this tool,"
        Write-Host -Foregroundcolor Cyan "selecting the 'Q and A' tab and starting a new question. In the report, please post"
        Write-Host -Foregroundcolor Cyan "the full output above showing the command line used. It would be useful too to post"
        Write-Host -Foregroundcolor Cyan "configuration information about the VM being converted such as number of disks, "
        Write-Host -Foregroundcolor Cyan "operating system, disk partition layout on the boot disk and anything else you think"
        Write-Host -Foregroundcolor Cyan "may be pertinent and helpful. Thank you for making this utility better!`n"
        Write-Host -Foregroundcolor Cyan ("Trace status code: " + $script:ProgressPoint)
        Write-Host -Foregroundcolor Cyan "--------------------------------------------------------------------------------------"
    }


    Write-Verbose ("Calling exit from cleanup " + $script:ProgressPoint)
    exit
}

# ---------------------------------------------------------------------------------------------------------------------------
# Function to perform additional parameter validation
# ---------------------------------------------------------------------------------------------------------------------------
Function Validate-Parameters {

    try {

        # Additional parameter validation. I do this here as, for example, a [switch] parameter, the .IsPresent attribute 
        # is always $True in a [ValidateScript] code block. Generally gave up in the end with the use of any [ValidateScript] for consistency.
        # See Parameter Validation spreadsheet for more info on the code in this function (that's a comment for me BTW...)
    
        Write-Verbose (">>Validate-Parameters")
        $script:ProgressPoint = 100
    
        # >>>>> Important: Do the things which change KeepWIM first to avoid accidental cleanup which deletes the WIM!
        # KeepWIM can only be supplied in Capture, Apply and All.
        if ($KeepWIM.GetType().name -eq "SwitchParameter") {
            if (($KeepWIM.IsPresent) -and (($Action -ne "Capture") -and ($Action -ne "Apply") -and ($Action -ne "All"))) { Cleanup "-KeepWIM not valid with action '$Action'" }
        } else {
            if (($KeepWIM) -and (($Action -ne "Capture") -and ($Action -ne "Apply") -and ($Action -ne "All"))) { Cleanup "-KeepWIM not valid with action '$Action'" }
        }

        # KeepWIM is set to true if just capturing (otherwise it's a bit silly....)
        if ($Action -eq "Capture") { $script:KeepWIM = $true }

        # KeepWIM is set to true if user specified WIM during Apply or Capture (otherwise we use a temporary WIM file)
        # Do this AFTER any checks which rely on $KeepWim.IsPresent
        if (($WIM.Length) -and (($Action -eq "Apply") -or ($Action -eq "Capture"))) { $script:KeepWIM = $true }
        # >>>>> Important: Do the things which change KeepWIM first to avoid accidental cleanup which deletes the WIM!

        # VMName is mandatory for Clone, Capture, All. Mandatory for Apply if VHDXSizeGB is not specified, otherwise optional.
        if (($Action -eq "Apply") -and ($VHDXSizeGB -eq 0) -and ($VMName -eq "")) { Cleanup "-VMName or -VHDXSizeGB must be supplied with action '$Action'" }
        if (($Action -ne "Apply") -and ($VMName -eq "")) { Cleanup "-VMName must be supplied with action '$Action'" }

        # IgnoreWinRE. Only valid in Capture and All
        if ($IgnoreWinRE.GetType().name -eq "SwitchParameter") {
            if (($IgnoreWinRE.IsPresent) -and (($Action -ne "capture") -and ($Action -ne "all"))) { CleanUp "-IgnoreWinRE not valid with action '$Action'" } 
        } else {
            if (($IgnoreWinRE) -and (($Action -ne "capture") -and ($Action -ne "all"))) { CleanUp "-IgnoreWinRE not valid with action '$Action'" } 
        }
        
        # IgnorePBR. Only valid in Capture and All
        if ($IgnorePBR.GetType().name -eq "SwitchParameter") {
            if (($IgnorePBR.IsPresent) -and (($Action -ne "capture") -and ($Action -ne "all"))) { CleanUp "-IgnorePBR not valid with action '$Action'" } 
        } else {
            if (($IgnorePBR) -and (($Action -ne "capture") -and ($Action -ne "all"))) { CleanUp "-IgnorePBR not valid with action '$Action'" } 
        }
    
        # VHDXSizeGB can only be supplied in Apply and All. We already have validated the range.
        if (($VHDXSizeGB -ne 0) -and (($Action -ne "Apply") -and ($Action -ne "All"))) { Cleanup "-VHDXSizeGB not valid with action '$Action'" } 

        # VMName should not be present in apply if VHDXSizeGB is supplied
        if (($VHDXSizeGB -ne 0) -and ($Action -eq "Apply") -and ($VMName -ne "")) { Cleanup "-VMName cannot be specified with action '$Action' when -VHDXSizeGB is specified" }
    
        # VHDX can only be supplied in Apply, Clone and All. 
        if (($VHDX.Length) -and (($Action -ne "Apply") -and ($Action -ne "Clone") -and ($Action -ne "All"))) { Cleanup "-VHDX not valid with action '$Action'" }

        # VHDX must be supplied in Apply if VMName is not supplied
        if (($Action -eq "Apply") -and ($VHDX -eq "") -and ($VMName -eq "")) { Cleanup "-VHDX must be specified with action '$Action' when -VMName is not specified"}
   
        # VHDX must not exist if supplied in Apply and All unless OverwriteVHDX is also supplied.
        if (($VHDX.Length) -and `
            (!($OverwriteVHDX)) -and `
            (($Action -eq "Apply") -or ($Action -eq "All")) -and `
            (Test-Path $VHDX) ) { Cleanup "$VHDX exists. Use -OverwriteVHDX or supply a different VHDX filename" }
    
        # VHDX must exist if supplied in Clone
        if (($VHDX.Length) -and ($Action -eq "Clone") -and (!(Test-Path $VHDX))) { Cleanup "$VHDX not found" }
    
        # OverwriteVHDX can only be supplied in Apply and All.
        if ($OverwriteVHDX.GetType().name -eq "SwitchParameter") {
            if (($OverwriteVHDX.IsPresent) -and (($Action -ne "Apply") -and ($Action -ne "All"))) { Cleanup "-OverwriteVHDX not valid with action '$Action'" }
        } else {
            if (($OverwriteVHDX) -and (($Action -ne "Apply") -and ($Action -ne "All"))) { Cleanup "-OverwriteVHDX not valid with action '$Action'" }
        }
    
        # WIM can only be supplied with Capture, Apply and All.
        if (($WIM.Length) -and (($Action -ne "Capture") -and ($Action -ne "Apply") -and ($Action -ne "All"))) { Cleanup "-WIM not valid with action '$Action'" }
    
        # WIM must exist if requesting an Apply operation
        if (($WIM.Length) -and ($Action -eq "Apply") -and (!(Test-Path $WIM))) { Cleanup "$WIM could not be found" }
    
        # WIM must not exist if supplied in Capture or All unless OverwriteWIM is also supplied.
        if (($WIM.Length) -and `
            (!($OverwriteWIM)) -and `
            (($Action -eq "Capture") -or ($Action -eq "All")) -and `
            (Test-Path $WIM) ) { Cleanup "$WIM exists. Use -OverwriteWIM or supply a different WIM filename" }
    
        # WIM must be supplied on an Apply action
        if (($WIM.Length -eq 0) -and ($Action -eq "Apply")) { Cleanup "-WIM must be specified with action '$Action'" }

        # OverwriteWIM can only be supplied in Capture and All
        if ($OverwriteWIM.GetType().name -eq "SwitchParameter") {        
            if (($OverwriteWIM.IsPresent) -and (($Action -ne "Capture") -and ($Action -ne "All"))) { Cleanup "-OverwriteWIM not valid with action '$Action'" }
        } else {
            if (($OverwriteWIM) -and (($Action -ne "Capture") -and ($Action -ne "All"))) { Cleanup "-OverwriteWIM not valid with action '$Action'" }
        }
   
        # OverwriteVM can only be supplied in Clone and All
        if ($OverwriteVM.GetType().name -eq "SwitchParameter") {
            if (($OverwriteVM.IsPresent) -and (($Action -ne "Clone") -and ($Action -ne "All"))) { Cleanup "-OverwriteVM not valid with action '$Action'" }
        } else {
            if (($OverwriteVM) -and (($Action -ne "Clone") -and ($Action -ne "All"))) { Cleanup "-OverwriteVM not valid with action '$Action'" }
        }

        # NewVMName can only be supplied with Clone and All.
        if (($NewVMName.Length) -and (($Action -ne "Clone") -and ($Action -ne "All"))) { Cleanup "-NewVMName not valid with action '$Action'" }

        # Path can only be supplied with Clone and All
        if (($Path.Length) -and (($Action -ne "Clone") -and ($Action -ne "All"))) { Cleanup "-Path not valid with action '$Action'" }

        Write-Verbose ("<< Validate-Parameters")
        $script:ProgressPoint = 197

    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Validate-Parameters: " + $_.Exception.ToString())
        Cleanup ("Exception in Validate-Parameters")
    }
    Finally {
        Write-Verbose "<< Validate-Parameters()"
    }
}

# ---------------------------------------------------------------------------------------------------------------------------
# Function to get value of an item from an XML Document
# ---------------------------------------------------------------------------------------------------------------------------
Function GetTag([System.Xml.XmlDocument] $Document, [String] $Item) {

    Try {
        $Nodes = $Document.SelectNodes("/Version/$Item")
        if (0 -eq $Nodes.Count) {
            Write-Verbose ("Zero nodes for item $Item")
            return "" 
        }
        Write-Verbose ("Value of $item is "+ $Nodes.value)
        return $Nodes.value
    } catch [Exception] {  # Clone catch
        Write-Host -ForegroundColor Red "ERROR: Exception in GetTag()"
        Write-Host -ForegroundColor Red $_.Exception.ToString()
        return ""
    }
}

# ---------------------------------------------------------------------------------------------------------------------------
# Function to check for the latest version of this script
# ---------------------------------------------------------------------------------------------------------------------------
Function Check-LatestVersion($URL) {

    # Returns:  -3 if an error occurs (URL retrieval error, invalid content, other exception etc.)
    #           -2 if the version of this script is newer than what the web says. This probably means I'm developing
    #           -1 if a newer version is available.
    #            0 if this is the latest version available.

    #Example:
    #  <?xml version='1.0'?>
    #     <Latest  value="5.67"/>
    #     <Date    value="18th Oct 2013"/>
    #     <URL     value="http://tinyurl.com/TBD"/>
    #     <Type    value="Release Candidate"/>
    #     <About   value="Some more information about it here"/>
    #  </Version>

    Try {

        $URL = $URL + "?v=" + $script:Version + "&p=" + $script:ProgressPoint + "&a=" + $Action + "&c=" + [string]([guid]::NewGuid())  # Avoid cache
        # Try to get the Base64 encoded string containing the XML for the version. I only encode it as the
        # blog site escapes everything if a post contains just XML. It's pretty horrible.
        Try { $WebCall = (Invoke-WebRequest -URI $URL -UserAgent ("Mozilla/4.0+(compatible);") -ErrorAction SilentlyContinue) }
        Catch [Exception] {
            Write-Verbose ("Failed to get " + $URL + ". Error`n" + $Error[0][0])
            return -3
        }
        Write-Verbose ("WebCall Content`n" + $WebCall.Content)

        # Is is wrapped between "STARTLATESTVERSION" and "ENDLATESTVERSION"? (It will be for the blog site)
        if ($WebCall.content.length -gt 0) {
            if (($WebCall.Content.Contains("STARTLATESTVERSION")) -and ($WebCall.Content.Contains("ENDLATESTVERSION"))) {
                Write-Verbose "Is wrapped between START and END LATESTVERSION tags"
                $StartTag = $WebCall.Content.IndexOf("STARTLATESTVERSION")
                $EndTag = $WebCall.Content.IndexOf("ENDLATESTVERSION")
                $Base64 = $WebCall.content.substring($StartTag+18,$EndTag-$StartTag-18)
                Write-Verbose ("Extracted base64 content is " + $Base64)
            } else {
                Write-Verbose "Is not wrapped so assuming this is the base64 itself"
                $Base64 = $WebCall.Content
            }
        }

        # Unencode it back to XML
        Try { $XML = [System.Text.Encoding]::Unicode.GetString([System.Convert]::FromBase64String($Base64)) }
        Catch [Exception] {
            Write-Verbose ("Failed to un-encode the content from " + $URL + ". Error`n" + $Error[0][0])
            return -3
        }
        Write-Verbose ("XML obtained`n" + $XML)

        # Need an XML document
        Try { [System.Xml.XmlDocument] $XMLDocument = new-object System.Xml.XmlDocument }
        Catch [Exception] {
            Write-Verbose ("Failed to create a System.Xml.XmlDocument" + $Error[0][0])
            return -3
        }
        Write-Verbose ("Have an XMLDocument to load")

        # Load up the XML document from the XML
        Try { $XMLDocument.LoadXML($XML) }
        Catch [Exception] {
            Write-Verbose ("Failed to create load XMLDocument using " + $XML + $Error[0][0])
            return -3
        }
        Write-Verbose ("XML was loaded")

        # Extract all the tags
        Try {
            [String] $XMLLatest = GetTag $XMLDocument "Latest"
            [String] $XMLDate = GetTag $XMLDocument "Date"
            [String] $XMLURL = GetTag $XMLDocument "URL"
            [String] $XMLType = GetTag $XMLDocument "Type"
            [String] $XMLAbout = GetTag $XMLDocument "About"
        } Catch [Exception] {
            Write-Verbose ("Failed to GetTag " + $XML + $Error[0][0])
            return -3
        } 
        Write-Verbose ("Latest " + $XMLLatest)
        Write-Verbose ("Date " + $XMLDate)
        Write-Verbose ("URL " + $XMLURL)
        Write-Verbose ("Type " + $XMLType)
        Write-Verbose ("About " + $XMLAbout)

        if ([System.Double]$XMLLatest -gt [System.Double]$script:version) {
            $Latest = "Version " + $XMLLatest + " (" + $XMLDate + ") is available from " + $XMLURL + ". "
            if ($XMLType.Length)  {$Latest = $Latest + "`n" + ($XMLType) + ". "}
            if ($XMLAbout.Length) {$Latest = $Latest + "`n" + ($XMLAbout)}
            Write-Warning $Latest
            $script:WarningCount = $script:WarningCount + 1
            return -1
        } else { 
            if ([System.Double]$XMLLatest -eq [System.Double]$script:version) {
                Write-Verbose "Are running latest version"
                return 0
            } else {
                Write-Verbose "***Probably developing. Running $script:version Latest is $XMLLatest"
                return -2
            }
        }
    } catch [Exception] {  # Clone catch
        Write-Host -ForegroundColor Red "ERROR: Exception in Check-LatestVersion()"
        Write-Host -ForegroundColor Red $_.Exception.ToString()
        return -3
    }
}

# ---------------------------------------------------------------------------------------------------------------------------
# Function to perform simple preflight migration checks.
# ---------------------------------------------------------------------------------------------------------------------------
Function PreFlight-Checks {

    Try {

        Write-Verbose ">> PreFlight_Checks"
        $script:ProgressPoint = 200

        # Check for elevation
        $GetCurrent = New-Object Security.Principal.WindowsPrincipal $([Security.Principal.WindowsIdentity]::GetCurrent())
        if (!$GetCurrent.IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)) { Cleanup "This script must be run elevated." }
    
        #Check the PSVersion
        $script:ProgressPoint = 201
        if ($global:PSVersionTable.PSVersion.Major -ne 4 -and !$NoPSVersionCheck) {
            $script:ProgressPoint = 202
            Write-Warning "This script is designed for PowerShell v4.0. Behaviour on other versions is untested."
            Write-Warning "To override version check, specify parameter -NoPSVersionCheck."
            $script:WarningCount = $script:WarningCount + 1
            Cleanup
        }
    
        # Find the virtual machine. We don't need this for apply IFF the user has supplied both a VHDX size for the target (as we're not
        # using the source boot VHD for sizing) and the name of the output VHDX.
        $script:ProgressPoint = 203
        if (($Action -ne "Apply") -or `
            (($Action -eq "Apply") -and ($VHDXSizeGB -ne 0) -and ($VHDX -eq "")) -or `
            (($Action -eq "Apply") -and ($VHDXSizeGB -eq 0)) ) {
            $script:ProgressPoint = 204
            Write-Info "Locating virtual machine '$VMNAME'..."
            $script:SourceVMObject = Get-VM -EA SilentlyContinue -Name $VMNAME
            if (!$script:SourceVMObject){ 
                $script:ProgressPoint = 217
                Write-Verbose "Cleanup due to VM was not found"
                Cleanup "Virtual Machine '$VMNAME' could not be found."
            }
            Write-Verbose "Found VM by name"

    
            # Make sure only one VM
            $script:ProgressPoint = 205
            if ($script:SourceVMObject -is [Array]) {
                $script:ProgressPoint = 206
                Write-Verbose "Cleanup due to multiple VMs"
                Cleanup "Multiple VMs with the name '$VMNAME' were found."
            }
            Write-Verbose "And there is a single VM of that name"

            # VM must be off
            $script:ProgressPoint = 207
            Write-Info "Validating virtual machine configuration..."
            if ($script:SourceVMObject.State -ne 'Off') { 
                $script:ProgressPoint = 208
                Write-Verbose ("Cleanup due to "+ $script:SourceVMObject.State)
    	        Cleanup ("'" + $VMName + "' must be off for conversion to continue.")
            }
            Write-Verbose "VM is off"
    
            # VM must not have any checkpoints (snapshots). Not going to distinguish at this point recovery/replica etc
            $script:ProgressPoint = 209
            $Checkpoints = Get-VMSnapshot -VM $script:SourceVMObject -EA SilentlyContinue -SnapshotType Standard
            if ($Checkpoints) { 
                $script:ProgressPoint = 210
                Write-Verbose "Cleanup due to checkpoints found"
                Cleanup "Checkpoints are not supported for the conversion process."
            }
            Write-Verbose "No checkpoints were found"
    
            # Must be a Generation 1 VM
            $script:ProgressPoint = 211
            if ($script:SourceVMObject.Generation -ne 1) {
                $script:ProgressPoint = 212
                Write-Verbose "Cleanup due to not a generation 1 virtual machine"
    	        Cleanup ("'" + $VMName + "'Must be a Generation 1 VM!")
            }
    
            # Must not have replica enabled. This may work fine, but not tested or verified.
            $script:ProgressPoint = 213
            if ($script:SourceVMObject.ReplicationState -ne "Disabled") { 
                $script:ProgressPoint = 214
                Write-Verbose "Replica is enabled"
                if ($IgnoreReplicaCheck = $True) {
                    Write-Warning ("This script has not been validated for VMs with replica enabled. Using the override check is experimental only. Remember that *IF* the VM is successfully converted, you will need to re-enable replica once complete.")
                    $script:WarningCount = $script:WarningCount + 1
                } else {
                    $script:ProgressPoint = 215
                    CleanUp "Cleanup due to replication being enabled. Use the -IgnoreReplicaCheck to override. This has not been validated to operate correctly. If it works, the new generation 2 virtual machine will not have replica enabled." 
                }
            }
        }
        
        # Make sure the target does not exist (unless user says it's fine to overwrite it). Not applicable for capture and apply
        $script:ProgressPoint = 216
        if (($Action -ne "Capture") -and ($Action -ne "Apply")) {
            if ($NewVMName -eq "") {
                $script:ProgressPoint = 220
                $script:NewVMName = ($script:SourceVMObject).VMName + " (Generation 2)"
                Write-Verbose ("Settting New VMName to " + $NewVMName)
            }
            $script:ProgressPoint = 230
            $TestTargetVM = Get-VM -EA SilentlyContinue -Name $NewVMName
            if ($TestTargetVM) {
                Write-Verbose "Target VM exists"
                $script:ProgressPoint = 240
                if ($OverwriteVM) {
                    $script:ProgressPoint = 250
                    Write-Verbose ("Removing VM " + $NewVMName)
                    Remove-VM $TestTargetVM -ErrorAction SilentlyContinue -Force
                    if (!$?) { Cleanup ("Failed to remove "+ $NewVMName + "`n"+ $Error[0][0]) }
                } else {
                    $script:ProgressPoint = 260
                    CleanUp ($NewVMName + " exists. Use -OverwriteVM to force deletion")
                }
            }
            $script:ProgressPoint = 270
        }
        $script:ProgressPoint = 280

    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in PreFlight-Checks: " + $_.Exception.ToString())
        Cleanup ("Exception in PreFlight-Checks")
    }
    Finally {
        Write-Verbose "<< PreFlight-Checks()"
    }

} # PreFlight_Checks()

# ---------------------------------------------------------------------------------------------------------------------------
# Function to locate the boot disk on the source VM, check it is not shared and mount it.
# ---------------------------------------------------------------------------------------------------------------------------
Function Locate-SourceBootDisk ([Microsoft.HyperV.PowerShell.VirtualMachine] $VM, [Ref] $SourceBootDiskPath) {
    
    try {
        $script:ProgressPoint = 300
        Write-Verbose ">> Locate-SourceBootDisk"
        $SourceBootDiskPath.Value = ""

        # The boot disk is assumed to be the first disk found on IDE in order. This is far from
        # perfect, but is good for the majority case.

        $i = 0
        do {
	    $script:ProgressPoint = 301
            Write-Verbose ("Examining "+([math]::floor([int] $i / [int] 2)) + ":" +($i%2) )
            $Disk = (Get-VMHardDiskDrive $VM `
                       -ControllerType IDE `
                       -ControllerNumber  ([math]::floor([int] $i / [int] 2)) `
                       -ControllerLocation ($i%2) -ErrorAction SilentlyContinue) 
            $script:ProgressPoint = 302
            if (!$?) { Cleanup ("Failed to Get-VMHardDiskDrive`n"+ $Error[0][0]) }
            $i++
            if ($Disk -ne $Null) { Write-Verbose ($Disk.Path) }
            $script:ProgressPoint = 303
        } while (($i -le 3)  -and (!$Disk))

        $script:ProgressPoint = 310
        if (!($Disk)){ Cleanup "No boot disk was found for this VM." }


        # Give up if likely to be running a guest cluster.
        $script:ProgressPoint = 320
        if ($Disk.SupportPersistentReservations) { 
            $script:ProgressPoint = 321
	    Write-Warning (($Disk.Path) + " is shared.") 
            $script:WarningCount = $script:WarningCount + 1
        }

        # ByRef output parameter
        $script:ProgressPoint = 330
        $SourceBootDiskPath.Value = $Disk.Path
        Write-Info ("Identified boot disk is '" + $Disk.Path + "'")

        Write-Verbose "<< Locate-SourceBootDisk"
        $script:ProgressPoint = 397
    }
    Catch [Exception] {
        $script:ProgressPoint +=90000
        Write-Host -ForegroundColor Red ("Exception in Locate-SourceBootDisk: " + $_.Exception.ToString())
        Cleanup ("Exception in Locate-SourceBootDisk")
    }
    Finally {
        Write-Verbose "<< Validate-Parameters()"
    }
} # End Locate-SourceBootDisk

# ---------------------------------------------------------------------------------------------------------------------------
# Function to locate the boot disk on the source VM, check it is not shared and mount it.
# ---------------------------------------------------------------------------------------------------------------------------
Function Mount-Disk ($Path, [Ref] $Mounted) {
    
    try {
        $script:ProgressPoint = 400
        Write-Verbose ">> Mount-Disk"
        $Mounted.Value = $False
        Write-Verbose ("Mounting " + $Path + "...")
        Mount-DiskImage $Path -EA SilentlyContinue
        if (!$?) { Cleanup ("Mount operation failed`n"+ $Error[0][0]) }
        Write-Verbose "The disk was mounted"
        ($Mounted.Value) = $True
        $script:ProgressPoint = 497 
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Mount-Disk: " + $_.Exception.ToString())
        Cleanup ("Exception in Mount-Disk")
    }
    Finally {
        Write-Verbose "<< Mount-Disk()"
    }
} # End Mount-Disk

# ---------------------------------------------------------------------------------------------------------------------------
# Function to allocate two free drive letters.
# ---------------------------------------------------------------------------------------------------------------------------
Function Allocate-TwoFreeDriveLetters ([Ref] $First, [Ref] $Second) {
    try {
        $script:ProgressPoint = 500
        # Get some target drive letters which are not assigned. 
        Write-Verbose ">> Allocate-TwoFreeDriveLetters"

        if (($First.Value -ne "") -and ($Second.Value -ne "")) {
            $script:ProgressPoint = 501
            Write-Verbose ("Test hook for free drive letters " + $First.Value + " " + $Second.Value )
        } else {
            $First.Value = ""
            $Second.Value = ""
            $TempArray = ls function:[d-z]: -n | ?{ !(test-path $_) } | select -last 2
            Write-Verbose "Using temporary drive letters $($TempArray -join " ")"
            if (1 -ne $TempArray.GetUpperBound(0)) { 
                $script:ProgressPoint = 502
                CleanUp "Not enough free drive letters could be located to proceed." 
            }
            $First.Value = $TempArray[0]
            $Second.Value = $TempArray[1]
        }    
        $script:ProgressPoint = 597
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Allocate-TwoFreeDriveLetters: " + $_.Exception.ToString())
        Cleanup ("Exception in Allocate-TwoFreeDriveLetters")
    }
    Finally {
        Write-Verbose "<< Allocate-TwoFreeDriveLetters"
    }
}

# ---------------------------------------------------------------------------------------------------------------------------
# Function to validate the source boot disk contains a version of Windows we can migrate
# ---------------------------------------------------------------------------------------------------------------------------
Function Validate-SourceWindowsInstallation ( [String] $BootDiskFileName, `
                                              [Ref]    $ByRefPartition,   `
                                              [Ref]    $ByRefPartitionNum, `
                                              [Ref]    $ByRefUsed ) {

    # Taking a simple approach rather than opening the BCD store on the source active partition as in the original prototype.
    # Look at each drive letter which has been mapped from the source attempting to locate a Windows installation.
    # If more than one is found (eg multi-boot) then error out. If none are found, we have a problem.
    # When one and only one is found, that's the source partition
    
    try {
        $script:ProgressPoint = 600
        Write-Verbose ">> Validate-SourceWindowsInstallation"

        $ByRefPartition.Value = $Null
        $ByRefPartitionNum.Value = -1
        $ByRefUsed.Value = 0
        $WorkingPartition = $Null

        # Get the partition drive letters
        $SourcePartitions = ( (Get-DiskImage($BootDiskFileName)) | get-disk | get-partition)
        $script:ProgressPoint = 601

        $NumberFound = 0
        $DriveLettersAssigned = 0
        $DriveLetters = ""
        $NumberOfWindowsCopiesFound = 0

        # GPT is pretty unexpected! Worth testing though just in case
        if ("GPT" -eq (Get-DiskImage($BootDiskFileName) | Get-Disk ).PartitionStyle) {
            $script:ProgressPoint = 602
            CleanUp ("$BootDiskFileName is GPT which cannot be a valid boot disk for a generation 1 virtual machine!")
        }
        $script:ProgressPoint = 603

        # Find out what we're working with
        $SourcePartitions | ForEach-Object {
            $script:ProgressPoint = 604
            $_ | fl * | Out-String | Write-Verbose    
            $NumberFound ++
            Write-Verbose ("Found Partition "+$_.PartitionNumber+", type "+$_.Type+", size "+$_.Size+" at offset "+$_.Offset+" on disk "+ $_.DiskNumber+" drive letter "+$_.DriveLetter)

            if ($_.DriveLetter -match "^[a-zA-Z]") { # Weird. Only way I could find out whether drive letter assigned
                $script:ProgressPoint = 605
                $DriveLettersAssigned++
                $DriveLetters = $DriveLetters + $_.DriveLetter[0] + " "
            } else {
                $script:ProgressPoint = 606
                # Not when action is apply
                if ($Action -ne "Apply") {
                    Write-Warning ("Partition "+$_.PartitionNumber+", type "+$_.Type+", size "+$_.Size+" at offset "+$_.Offset+" on disk "+ $_.DiskNumber+" (" + $BootDiskFileName + ") does not have a drive letter and will be ignored")
                    $script:WarningCount++
                }
            }
        }

        $script:ProgressPoint = 620
        Write-Verbose ("Partition count "+$NumberFound)
        Write-Verbose ("Drive Letters "+$DriveLettersAssigned + " " +$DriveLetters)

        # We must have at least one partition
        if ($NumberFound -eq 0) { CleanUp "No partitions were located on the source disk" }

        # And we must have at least one partition with a drive letter
        if ($DriveLettersAssigned -eq 0) { Cleanup "No partitions on the source disk were assigned drive letters when it was mounted" } 

        $script:ProgressPoint = 630
        if ($DriveLettersAssigned -gt 1) {
            Write-Info ("Source drive letters are " + $DriveLetters)
        } else {
            Write-Info ("Source drive letter is " + $DriveLetters)
        }

        # Loop again through them looking for partitions containing Windows (over simplified check)
        $SourcePartitions | ForEach-Object {
            $script:ProgressPoint = 631
            if ($_.DriveLetter -match "^[a-zA-Z]") {
                $script:ProgressPoint = 632
                # Check for ntdll.dll
                if ($True -eq (Test-Path (($_.DriveLetter) + ":\windows\system32\ntdll.dll"))) { 
                    $script:ProgressPoint = 633
                    Write-Verbose "Found a Windows Installation"
                    $NumberOfWindowsCopiesFound++
                    $WorkingPartition = $_    # Safe for working on
                    $script:ProgressPoint = 634
                    $ByRefPartition.Value = $WorkingPartition  # And for output parameter
                    $script:ProgressPoint = 635
                    $ByRefPartitionNum.Value = $_.PartitionNumber
                } else {
                    # It doesn't count towards our copies of Windows, but could it be a data partition?
                    $script:ProgressPoint = 636
                    if ((!($_.IsActive)) -and (!($_.IsBoot)) -and (!($_.IsSystem)) ) {
                        $script:ProgressPoint = 637
                        Write-Warning ("Partition "+$_.PartitionNumber+", type "+$_.Type+", size "+$_.Size+" at offset "+$_.Offset+" on disk "+ $_.DiskNumber+" (" + $BootDiskFileName + ") will not be migrated as it is not marked as a boot, system or active partition. This is most likely a data or recovery partition. The contents will need to be manually copied across to the target virtual machine if required. For a recovery partition, after manual copying, additional configuration will be required to ensure that recovery operates correctly - consult the Windows Assessment and Deployment Kit (ADK) documentation for further information.")
                        $script:WarningCount++
                        $script:ProgressPoint = 638
                    }
                }
            } # if partition has a drive letter
        } # ForEach partition found        

        # Validate we only found one and one only
        $script:ProgressPoint = 640
        if ($NumberOfWindowsCopiesFound -eq 0) { CleanUp "No windows installation was located on the source VHD." }
        if ($NumberOfWindowsCopiesFound -gt 1) { CleanUp "The source VHD appears to have multiple Windows installations present." }
         
        # We found a partition. Read the file version and product name  
        $script:ProgressPoint = 650
        $SourceNTDLL = ($WorkingPartition.DriveLetter) + ":\windows\system32\ntdll.dll"
        $script:ProgressPoint = 651
        $SourceOSVersion = ([System.Diagnostics.FileVersionInfo]::GetVersionInfo($SourceNTDLL).FileVersion)
        $script:ProgressPoint = 652
        $SourceProductName = ([System.Diagnostics.FileVersionInfo]::GetVersionInfo($SourceNTDLL).ProductName)

        # Credit: Based on example at http://www.powershellmagazine.com/2013/03/08/pstip-how-to-determine-if-a-file-is-32bit-or-64bit/ 
        $script:ProgressPoint = 660
        $MACHINE_OFFSET = 4
        $PE_POINTER_OFFSET = 60
        $MachineType = Write-Output Native I386 Itanium x64
        $data = New-Object System.Byte[] 4096
        $script:ProgressPoint = 662
        $stream = New-Object System.IO.FileStream -ArgumentList $SourceNTDLL,Open,Read
        $script:ProgressPoint = 663
        $stream.Read($data,0,$PE_POINTER_OFFSET) | Out-Null
        $script:ProgressPoint = 664
        $PE_HEADER_ADDR = [System.BitConverter]::ToInt32($data, $PE_POINTER_OFFSET)
        $script:ProgressPoint = 665
        $machineUint = [System.BitConverter]::ToUInt16($data, $PE_HEADER_ADDR + $MACHINE_OFFSET)
        $script:ProgressPoint = 666

        # What we're going to be converting
        Write-Info ("Found " + $SourceProductName + " " + $SourceOSVersion + " " + $($MachineType[$machineUint]) + " at " + $WorkingPartition.DriveLetter + ":\windows")

        # Split the file version into constituent parts and make sure its in the format a.b.cccc.ddddd (well at least four parts)
        $script:ProgressPoint = 670
        $SourceOSVersionParts = $SourceOSVersion.Split(".")
        $script:ProgressPoint = 671
        if ($SourceOSVersionParts.GetUpperBound(0) -ne 4) { CleanUp "Could not determine OS version from source disk."  }

        # Validate that the source is Windows version 6.2 or later (6.2 is Windows 8/Windows Server 2012)
        $script:ProgressPoint = 672
        if ($SourceOSVersionParts[0] -lt 6) { CleanUp "Source OS must be version 6.2 (Windows 8/Windows Server 2012) or later." }
        $script:ProgressPoint = 673
        if (($SourceOSVersionParts[0] -eq 6) -and ($SourceOSVersionParts[1] -lt 2)) { CleanUp "Source OS must be version 6.2 (Windows 8/Windows Server 2012) or later." }

        # Validate that the source operating system is 64-bit
        $script:ProgressPoint = 674
        if ($MachineType[$machineUint] -ne "x64") { CleanUp ("Source operating system must be 64-bit") }

        # Work out how many bytes are used on this partition. We will use this later as part of the size checking algorithm.
        $script:ProgressPoint = 680
        $vol = ($WorkingPartition | get-volume)
        $script:ProgressPoint = 681
        $ByRefUsed.Value = (($vol.Size) - ($Vol.SizeRemaining))
        $script:ProgressPoint = 682
        Write-Verbose ("Used = " + ($ByRefUsed.Value))
        $script:ProgressPoint = 697
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Validate-SourceWindowsInstallation: " + $_.Exception.ToString())
        Cleanup ("Exception in Validate-SourceWindowsInstallation")
    }
    Finally {
        Write-Verbose "<< Validate-SourceWindowsInstallation()"
    }
} # End Validate-SourceWindowsInstallation

# ---------------------------------------------------------------------------------------------------------------------------
# Function to examine RE in the source Windows installation
# ---------------------------------------------------------------------------------------------------------------------------
Function Verify-RecoveryEnvironment ( [String] $SourceBootDiskWindowsPartitionDriveLetter) { 

    try {
        $script:ProgressPoint = 700
        Write-Verbose ">> Verify-RecoveryEnvironment"
    
        # Although in prototyping and manual run-through, it is possible to re-fix up BCD and reagent.xml
        # which are tightly coupled when RE is enabled, to be honest, the FAR safer option is to disable
        # it inside the guest using reagent /disable before cloning, and then re-enable in the new vm using
        # /enable. Also checks for PBR being configured as this script does not copy it across, and further
        # the BCD in the new VHDX will not contain any references to it.
    
        # Example snippits for my reference
        # Windows 8.1 RTM GPT with RE+PBR configured
        #    <WindowsRE version="2.0">  <-- Note version 2.0
        #    <WinreBCD id="{d9ebf8fe-279b-11e3-8baa-937d583d467a}"/>
        #    <WinreLocation path="\Recovery\WindowsRE" id="0" offset="1048576" guid="{1bbe1186-b3bb-4a08-af22-264b3379d8cd}"/>
        #    <PBRImageLocation path="\RecoveryImage" id="0" offset="58465452032" guid="{1bbe1186-b3bb-4a08-af22-264b3379d8cd}" index="1"/>
        #    <InstallState state="1"/>
        #    <OsBuildVersion path="9600.16384.amd64fre.winblue_rtm.130821-1623"/>
    
        # Windows 8 generation 2 GPT with RE+PBR configured
        #    <WindowsRE version="1.0">
        #    <WinreBCD id="{92b228d6-2c5b-11e3-8636-00155df13812}"/>
        #    <WinreLocation path="\Recovery\WindowsRE" id="0" offset="1048576" guid="{46d52120-8158-4242-ad3c-0a3e919752b1}"/>
        #    <OsInstallLocation path="\RecoveryImage" id="0" offset="126717263872" guid="{46d52120-8158-4242-ad3c-0a3e919752b1}" index="1"/>
        #      ^^^ v1.0 uses OsInstallLocation in PBR
        #    <InstallState state="1"/>
        #    <OsBuildVersion path="9200.16628.amd64fre.win8_gdr.130531-1504"/>
        
        if ($True -eq (Test-Path ($SourceBootDiskWindowsPartitionDriveLetter + ":\windows\system32\recovery\reagent.xml"))) {
            Write-Verbose "Examining WinRE environment..."
            [System.Xml.XmlDocument] $XMLDocument = new-object System.Xml.XmlDocument
            $XMLDocument.Load($SourceBootDiskWindowsPartitionDriveLetter + ":\windows\system32\recovery\reagent.xml")
    
            # Look if RE is enabled
            $XMLNodes = $XMLDocument.SelectNodes("/WindowsRE/InstallState")
    
            Write-Verbose "----- Recovery config -----"
             ($SourceBootDiskWindowsPartitionDriveLetter + ":\windows\system32\recovery\reagent.xml") | Write-Verbose
            Write-Verbose "----- End recovery config -----"
    
            if (0 -eq $XMLNodes.Count) {
                CleanUp "Could not determine recovery environment state in the source OS installation"
            } else {
                if (1 -eq $XMLNodes.State) {
                    Write-Verbose "WinRE is configured..."
    
                    if (!$IgnoreWinRE) {
                        CleanUp "WinRE is configured. Run reagentc /disable inside guest first, or use IgnoreWinRE parameter"
                    } else {
                        Write-Warning "WinRE is configured and will need manual fixing after migration"
                        $script:WarningCount = $script:WarningCount + 1
                    }                
                } else {
                    Write-Verbose "WinRE is not configured in the source installation"
                }
            }
    
            # Get the RE version due to the difference in PBR configuration
            $REVersion = $XMLDocument.SelectNodes("/WindowsRE").version
            Write-Verbose ("RE XML version is $REVersion")
    
            # Look for Push-Button Reset
            if ($REVersion -eq "1.0") {
                $XMLNodes = $XMLDocument.SelectNodes("/WindowsRE/OSInstallLocation")
            } else {
                $XMLNodes = $XMLDocument.SelectNodes("/WindowsRE/PBRImageLocation")
            }
    
            if (0 -eq $XMLNodes.Count) {
                Write-Verbose "No Push-Button Reset information was located"
            } else {
                Write-Verbose "Examining Push-Button Reset configuration..."
                if ("" -ne $XMLNodes.Path) {  
                    Write-Warning "Push-Button Reset is configured"
                    $script:WarningCount = $script:WarningCount + 1
    
                    if (!$IgnorePBR) {
                        CleanUp "Push-Button Reset is configured. Use IgnorePBR parameter to migrate this VM. Note that PBR will not be migrated" 
                    } else {
                        Write-Warning "PBR will not be migrated with this VM, neither will any separate partition containing an image."
                        Write-Warning "It can be manually copied and reconfigured after migration once the partition is created."
                        Write-Warning "See http://technet.microsoft.com/en-us/library/hh825041.aspx"
                    }                
                } else {
                    Write-Verbose "Push-Button Reset is not configured in the source installation"
                }
            }
            $script:ProgressPoint = 796
        } # reagent.xml exists   
        else {
            CleanUp "Recovery information was not found in source installation"
            $script:ProgressPoint = 797
        }
        
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Verify-RecoveryEnvironment: " + $_.Exception.ToString())
        Cleanup ("Exception in Verify-RecoveryEnvironment")
    }
    Finally {
        Write-Verbose "<< Verify-RecoveryEnvironment()"
    }
} # Verify-RecoveryEnvironment

# ---------------------------------------------------------------------------------------------------------------------------
# Function to capture a drive letter (used for the Windows partition on the source VHD(X))
# ---------------------------------------------------------------------------------------------------------------------------
Function Capture-ImageOfSourceVHDX ( $SourceDriveLetter ) {

    # Taking a simple approach rather than opening the BCD store on the source active partition as in the original prototype.
    # Look at each drive letter which has been mapped from the source attempting to locate a Windows installation.
    # If more than one is found (eg multi-boot) then error out. If none are found, we have a problem.
    # When one and only one is found, that's the source partition.

    try {
        $script:ProgressPoint = 800
        Write-Verbose ">> Capture-ImageOfSourceVHDX" 

        # Generate a temporary filename
        if ($WIM -eq "") {
            $WIM = "$env:temp\TEMP-$(Get-Date -format 'yyyy-MM-dd hh-mm-ss') captured.wim"      
            Write-Verbose "Generated WIM storage path is $WIM"
            $script:WIM = $WIM
        } else {
            Write-Verbose "User supplied WIM storage path is $WIM"
        }

        # Capture the source image. Note we don't need an explicit check here to see if the WIM already exists, or on the
        # OverwriteWIM parameter as dism always overwrites. We have already validated that if the WIM did exist and OverwriteWIM
        # was not supplied that the script bailed out long ago.
        Write-Info ("Capturing image. This will take some time...")        
        $DismCommand = 'dism /capture-image /imagefile:"' + $WIM + '" /name:"Captured" /capturedir:"' + $SourceDriveLetter + ':\"'
        Write-Verbose $DismCommand
        $script:ProgressPoint = 810
        $DismCaptureOutput = Invoke-Expression $DismCommand
        $script:ProgressPoint = 820
        $DismCaptureOutput | Write-Verbose

        if (0 -ne $global:lastexitcode) { 
            $script:ProgressPoint = 830
            Cleanup ("$DismCommand failed $DismCaptureOutput error code $global:lastexitcode") 
        }
        Write-Verbose "Dism must have succeeded"

        Write-Info ("Image captured to " + $WIM)

        #IMO, these new DISM cmdlets are a little broken. At least from what I can tell. First, they always put some output on success
        #which is horrible. Second, ErrorAction SilentlyContinue doesn't continue, hence needs try-catch. Sticking with dism.exe....! See 520041 in WBB database.
        #try {
        #    New-WindowsImage -imagepath $WIM -name "Captured" -capturepath ($SourceDriveLetter+":\") -ErrorAction SilentlyContinue
        #    if (!$?) { CleanUp ("Failed to capture $SourceDriveLetter to $WIM`n"+$Error[0][0]) } 
        #} catch { CleanUp ("Failed to capture $SourceDriveLetter to $WIM`n"+$Error[0][0]) }
        $script:ProgressPoint = 897
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Capture-ImageOfSourceVHDX: " + $_.Exception.ToString())
        Cleanup ("Exception in Capture-ImageOfSourceVHDX")
    }
    Finally {
        Write-Verbose "<< Capture-ImageOfSourceVHDX()"
    }
} # Capture-ImageOfSourceVHDX

# ---------------------------------------------------------------------------------------------------------------------------
# Function to generate the name of the target boot VHDX for the generation 2 virtual machine
# ---------------------------------------------------------------------------------------------------------------------------
Function Generate-PathToTargetBootDisk( [String] $SourceVHDX) {

    try {
        $script:ProgressPoint = 900
        Write-Verbose ">> Generate-PathToTargetBootDisk"
        Write-Verbose ("Source path is " + $SourceVHDX)

        # Generate the name of a VHDX if one is not supplied. Based on the path/name of the source
        # boot disk for the generation 1 VM, noting that it could be either a VHD or VHDX file
        if ($VHDX -eq "") { 
            $script:ProgressPoint = 910
            Write-Verbose ("VHDX is empty")

            # If Path is supplied, and VHDX isn't, we'll use the path as the base for the new virtual hard disk
            if ($Path -eq "") {
                $script:ProgressPoint = 920
                Write-Verbose ("Path is empty - use source vhdx path for new VHDX too")
                $VHDX = [System.IO.Path]::ChangeExtension($SourceVHDX, $null)    # Remove the extension
                $VHDX  = $VHDX.SubString(0, $VHDX.Length-1)                      # Remove the . at the end
                $VHDX  = $VHDX  + " (Generation 2).vhdx"                         # And add a generation marker
            } else {
                $script:ProgressPoint = 930
                Write-Verbose ("Path is not empty. Using it as the path for the new VHDX")
                $VHDX = [System.IO.Path]::Combine(([System.IO.Path]::Combine($Path,$NewVMName)),([System.IO.Path]::GetFileName($SourceVHDX)))
                $VHDX = [System.IO.Path]::ChangeExtension($VHDX, $null)    # Remove the extension
                $VHDX  = $VHDX.SubString(0, $VHDX.Length-1)                # Remove the . at the end
                $VHDX  = $VHDX  + " (Generation 2).vhdx"                   # And add a generation marker
            }

            Write-Verbose ("Boot disk is " + $VHDX)
        } else {
            $script:ProgressPoint = 940
            Write-Verbose ("Using user-supplied VHDX filename " + $VHDX)
        }

        # Save for use by rest of script. This could be an output parameter, but not necessary.
        $script:VHDX = $VHDX
        $script:ProgressPoint = 997
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Generate-PathToTargetBootDisk: " + $_.Exception.ToString())
        Cleanup ("Exception in Generate-PathToTargetBootDisk")
    }
    Finally {
        Write-Verbose "<< Generate-PathToTargetBootDisk()"
    }
}

# ---------------------------------------------------------------------------------------------------------------------------
# Function to size and create the VHDX which will be used as the boot disk for the target VM
# ---------------------------------------------------------------------------------------------------------------------------
Function Create-TargetVHDX ($SizeOfSourcePartition) {

    try {
        $script:ProgressPoint = 1000
        Write-Verbose ">> Create-TargetVHDX"
    
        if (Test-Path ($VHDX)) { 
            if (!$OverwriteVHDX){
                $script:ProgressPoint = 1002
                Cleanup "$VHDX exists.`nSpecify '-OverwriteVHDX' to overwrite this file."
            }
            Write-Verbose "Deleting $VHDX..."
            $script:ProgressPoint = 1004
            Dismount-VHD $VHDX -EA SilentlyContinue # Just in case, more for development than real use
            $script:ProgressPoint = 1006
            Remove-Item $VHDX -ErrorAction SilentlyContinue
            $script:ProgressPoint = 1008
            if (!$?) { 
                $script:ProgressPoint = 1009
                Cleanup ("Failed to delete $VHDX`n"+ $Error[0][0]) 
            }
        }
        
        # Calculate the target VHD size. Note there is no recovery image partition created on destination.
        if ($VHDXSizeGB -eq 0) {
            $script:ProgressPoint = 1010
            Write-Verbose "Calculating disk size"
            $TargetVHDSize = (300*1024*1024)                  # Partition 1: Hidden 300MB Recovery Tools
            $TargetVHDSize += (100*1024*1024)                 # Partition 2: Plus 100MB for ESP
            $TargetVHDSize += (128*1024*1024)                 # Partition 3: Plus 128MB for MSR
            $TargetVHDSize += $SizeOfSourcePartition          # Partition 4: Primary partition same size as source
            Write-Verbose ("Target disk size=" + $TargetVHDSize + " bytes, " + ($TargetVHDSize/1024/1024/1024) + " GB")
        } else {
            $script:ProgressPoint = 1020
            # Note this was validated in the parameter set to being in range 1..64
            Write-Verbose ("Target disk size specified as " + $VHDXSizeGB + "GB")
            $TargetVHDSize = ($VHDXSizeGB * 1024 * 1024 * 1024) # Bytes

            # Actual space required is how much data in the source partition, plus our partitions, rounded up in GB.
            $SpaceRequired = $script:SourceBootDiskWindowsPartitionUsed
            $SpaceRequired += (300*1024*1024)
            $SpaceRequired += (100*1024*1024)
            $SpaceRequired += (128*1024*1024)
            Write-Verbose ("Space required bytes is " + $SpaceRequired)
            $SpaceRequiredGB = ([math]::ceiling($SpaceRequired/1024/1024/1024))  # Rounded up
            Write-Verbose ("Space required GB is " + $SpaceRequiredGB)

            if ($VHDXSizeGB -lt $SpaceRequiredGB) {
                $script:ProgressPoint = 1030
                Cleanup ("VHDX size " + $VHDXSizeGB + "GB is too small. At least " + $SpaceRequiredGB + "GB is required.")
                $script:WarningCount = $script:WarningCount + 1
            }
        }
    
        # Just useful
        Write-Verbose ("Source Partition size=" + ($SizeOfSourcePartition) + " bytes, " + (($SizeOfSourcePartition)/1024/1024/1024) + " GB")    
    
    
        # Create a new dynamic VHDX in the same location. We already know it doesn't exist (pre-flighted)
        Write-Info ("Creating '" + $VHDX + "'...")
        $TargetVHD = New-VHD -Path $VHDX -Dynamic -Size $TargetVHDSize -ErrorAction SilentlyContinue
        if (!$?) { 
            $script:ProgressPoint = 1040
            Cleanup ("Failed to create $VHDX with size $TargetVHDSize`n"+ $Error[0][0]) 
        }
   
        Write-Verbose "<< Create-TargetVHDX"
        $script:ProgressPoint = 1097
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Create-TargetVHDX: " + $_.Exception.ToString())
        Cleanup ("Exception in Create-TargetVHDX")
    }
    Finally {
        Write-Verbose "<< Create-TargetVHDX()"
    }
} # End Create-TargetVHDX

# ---------------------------------------------------------------------------------------------------------------------------
# Function to initialise and partition the target VHDX for booting the converted virtual machine
# ---------------------------------------------------------------------------------------------------------------------------
Function Partition-TargetVHDX($ESPDriveLetter, $WindowsDriveLetter, [Ref] $ESPConfigured) {

    Try {
        $script:ProgressPoint = 1100
        Write-Verbose ">> Partition-TargetVHDX()"
        Write-Verbose ("Target path: " + $VHDX)
        Write-Verbose ("ESP Drive: " + $ESPDriveLetter)
        Write-Verbose ("Windows Drive: " + $WindowsDriveLetter)

    
        # Get the disk image and the disk number for it
        $DiskImage = Get-DiskImage $VHDX -ErrorAction SilentlyContinue
        if (!$?) { Cleanup ("Failed to call Get-DiskImage on $VHDX`n"+ $Error[0][0]) }


        $DiskNumber = ($DiskImage | Get-Disk -ErrorAction SilentlyContinue).Number
        if (!$?) { Cleanup ("Failed to Get-Disk on $VHDX`n"+ $Error[0][0]) }

        # We pre-flighted to get the drive letters, just didn't give any output (unless it failed)
        Write-Info "Disk $DiskNumber is mounted. Allocated drive letters are $ESPDriveLetter and $WindowsDriveLetter"

        # Generate a diskpart script in the temp directory using the unused drive letters
        $DiskPartFileName = "$env:temp\TEMP-$(Get-Date -format 'yyyy-MM-dd hh-mm-ss') DiskpartTemp.log"  
        $unused = New-Item $DiskPartFilename -itemType File  -ErrorAction SilentlyContinue
        if (!$?) { Cleanup ("Failed to create $DiskPartFileName`n"+ $Error[0][0]) }

        # Populate the diskpart script contents
        # Diskpart.1) We clean and make it GPT layout
        Add-Content $DiskPartFileName ("select disk " + ($DiskNumber.ToString()))
        Add-Content $DiskPartFileName "clean"
        Add-Content $DiskPartFileName "convert gpt"

        # Diskpart.2) Recovery Environment tools partition. Note we don't populate this (I did originally)
        Add-Content $DiskPartFileName "create partition efi size=300"
        Add-Content $DiskPartFileName "format quick fs=ntfs label=""Windows RE tools"""
        Add-Content $DiskPartFileName "set id=""de94bba4-06d1-4d40-a16a-bfd50179d6ac"""
        Add-Content $DiskPartFileName "gpt attributes=0x8000000000000001"

        # Diskpart.3) Create the EFI system partition and assign a drive letter (needed for bcdboot later)
        Add-Content $DiskPartFileName "create partition efi size=100"
        Add-Content $DiskPartFileName "format quick fs=fat32 label=""System"""
        Add-Content $DiskPartFileName ('assign letter="' + $ESPDriveLetter + '"')

        # Diskpart.4) Create a Microsoft Reserved Partition
        Add-Content $DiskPartFileName "create partition msr size=128"
    
        # Diskpart.5) Create the Windows Partition and assign a drive letter
        Add-Content $DiskPartFileName "create partition primary"
        Add-Content $DiskPartFileName "format quick fs=ntfs label=""Windows"""
        Add-Content $DiskPartFileName ('assign letter="' + $WindowsDriveLetter + '"')
        Add-Content $DiskPartFileName "exit"

        Write-Verbose "----- Diskpart script -----"
        Get-Content $DiskPartFileName | Write-Verbose
        Write-Verbose "--- End diskpart script ---"

        # Paranoia. Deliberately no way to -force out of this.
        $script:ProgressPoint = 1110
        $Warning = ("CONTENT ON DISK " + $DiskNumber + " IS ABOUT TO BE DESTROYED.`n`nVerify this maps to '" + $VHDX + "' in disk management (diskmgmt.msc) or diskpart.exe before confirming.`n" + 
                    "Your confirmation accepts full liability for accidental data loss due to coding errors or otherwise.")
        $YesNo = [System.Management.Automation.Host.ChoiceDescription[]]( 
                    (new-Object System.Management.Automation.Host.ChoiceDescription "&No","No"),  
                    (new-Object System.Management.Automation.Host.ChoiceDescription "&Yes","Yes"))
        if (1 -ne ($Host.UI.PromptForChoice("Warning - Loss of data",$Warning,$YesNo,0))) {
            $script:ProgressPoint = 1120
            Cleanup "Confirmation to destroy disk contents was not obtained"
        }

        # Run the diskpart script to create the partitions on the new VHDX and remove our script
        Write-Info "Preparing disk..."
        $DiskPartOutput = diskpart /s $DiskPartFileName
        $ESPConfigured.Value = $true   # Strictly this may not be correct. Solution is to do multiple diskparts, but not critical any time soon
        $DiskPartOutput | Write-Verbose
        if (0 -ne $global:lastexitcode) {
            $script:ProgressPoint = 1130
            Write-Verbose ("LastExitCode " + $global:lastexitcode)
            Write-Host ""
            Write-Host -ForegroundColor Red "You may need to reboot if a drive letter is visible in explorer but not in diskmgmt.msc"
            Write-Host -ForegroundColor Red "This occurs if you terminate this script at the wrong time and it hasn't cleaned up."
            Cleanup ("Diskpart script failed" + $DiskPartOutput) 
        }
        Write-Verbose "diskpart must have succeeded"
        $script:ProgressPoint = 1197
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Partition-TargetVHDX: " + $_.Exception.ToString())
        Cleanup ("Exception in Partition-TargetVHDX")
    }
    Finally {
        Write-Verbose "<< Partition-TargetVHDX()"
        # Don't need our diskpart script any more
        if ($DiskPartFileName.Length) { Remove-Item $DiskPartFileName -ErrorAction SilentlyContinue }
    }
} # Partition-TargetVHDX

# ---------------------------------------------------------------------------------------------------------------------------
# Function to apply a WIM to a target VHDX and make it bootable
# ---------------------------------------------------------------------------------------------------------------------------
Function Apply-ImageToTargetVHDX ($ESPDriveLetter, $WindowsDriveLetter) {

    try {
        $script:ProgressPoint = 1200
        Write-Verbose ">> Apply-ImageToTargetVHDX"
    
        # Apply the captured image into the windows partition on the target disk.
        # See New-WindowsImage in this code. Haven't tried Expand-WindowsImage -ImagePath blah.wim -Index 1 -ApplyPath d:\ for the same reason
        $DismCommand = 'dism /apply-image /imagefile:"' + $WIM + '" /index:1 /applydir:' + $WindowsDriveLetter  + '\'
        Write-Verbose $DismCommand
        Write-Info "Applying image. This will take some time..."
        $global:lastexitcode = 0
        $DismCaptureOutput = Invoke-Expression $DismCommand
        $script:ProgressPoint = 1210
        $DismCaptureOutput | Write-Verbose
        if (0 -ne $global:lastexitcode) { 
            $script:ProgressPoint = 1220
            Cleanup ("$DismCommand failed $DismCaptureOutput error code $global:lastexitcode") $DismCaptureOutput | Write-Verbose 
        }
        Write-Verbose "Dism apply must have succeeded"
        $script:ProgressPoint = 1230
        
        # Configure the EFI system partition on the target drive. We have a test hook override to make development easier.
        if ($script:TestHookBCDBootWindowsDrive -ne "") {
            Write-Host -ForegroundColor Red ("Test hook forcing BCDBoot Windows sources will be taken from " + $script:TestHookBCDBootWindowsDrive + ". The target VM will likely not boot if it's Windows 8")
            $WindowsDriveLetter = $script:TestHookBCDBootWindowsDrive
        }
    
	$script:ProgressPoint = 1240
        $BCDBootCommand = 'bcdboot ' + $WindowsDriveLetter + '\windows /s ' + $ESPDriveLetter + ' /f UEFI'
        $script:ProgressPoint = 1250
        Write-Verbose "Configuring the EFI System Partition on the target"
        Write-Verbose $BCDBootCommand
        $global:lastexitcode = 0
        $BCDBootOutput = Invoke-Expression $BCDBootCommand
        $BCDBootOutput | Write-Verbose
        if (0 -ne $global:lastexitcode) { 
            $script:ProgressPoint = 1260
            Cleanup ("$BCDBootCommand failed $BCDBootOutput error code $global:lastexitcode") 
        }
        Write-Verbose "BCDBoot must have succeeded"
    
        Write-Verbose ">> Apply-ImageToTargetVHDX"
        $script:ProgressPoint = 1297
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Apply-ImageToTargetVHDX: " + $_.Exception.ToString())
        Cleanup ("Exception in Apply-ImageToTargetVHDX")
    }
    Finally {
        Write-Verbose "<< Apply-ImageToTargetVHDX()"
    }
} # End Apply-ImageToTargetVHDX

# ---------------------------------------------------------------------------------------------------------------------------
# Function to copy networking configuration from one VM to another
# ---------------------------------------------------------------------------------------------------------------------------
Function Copy-Networking ($Source, $Target) {

    try {
        $script:ProgressPoint = 1300
        Write-Verbose "Copying networking"
    
        $vmms = Get-WmiObject -Namespace "root\virtualization\v2" -Class "Msvm_VirtualSystemManagementService"
        $wmiVM = Get-WmiObject -Namespace "root\virtualization\v2" -Class "Msvm_ComputerSystem" -Filter "Name = '$($Source.Id)'"
        $wmiNewVM = Get-WmiObject -Namespace "root\virtualization\v2" -Class "Msvm_ComputerSystem" -Filter "Name = '$($Target.Id)'"
        $wmiVSSD = $wmiVM.GetRelated("Msvm_VirtualSystemSettingData", "Msvm_SettingsDefineState", $null, $null, $null, $null, $false, $null) | %{$_}
        $wmiNewVSSD = $wmiNewVM.GetRelated("Msvm_VirtualSystemSettingData", "Msvm_SettingsDefineState", $null, $null, $null, $null, $false, $null) | %{$_}
    
        # Get original port RASDs.
        Write-Verbose "Getting original port RASDs"
        $portSettings = $wmiVSSD.GetRelated("Msvm_SyntheticEthernetPortSettingData", "Msvm_VirtualSystemSettingDataComponent", $null, $null, $null, $null, $false, $null) | %{$_}
    
        if (-Not $portSettings) {
            # This is fine - just means there were no NICs
            Write-Verbose "No ports (NICs) were found on the original VM."
            return
        }
    
        # Add port RASDs to new VM.
        Write-Verbose "Adding RASDs"
        $result = $vmms.AddResourceSettings($wmiNewVSSD.Path.Path, $portSettings.GetText(1))
    
        if ($result.ReturnValue -eq 0) {
            $newPorts = $result.ResultingResourceSettings
        } else {
            Cleanup ("Failed Calling AddResourceSettings for port RASDs")
        }
    
        # Create a mapping from old port RASDs to new port RASDs.
        $portObjectPathMap = @{}
    
        $index = 0
        foreach ($portSetting in $portSettings) {
            Write-Verbose "Looping through port settings"
            $portObjectPathMap[$portSetting.Path.Path] = $newPorts[$index]
            $index++
        }
    
        # Get original connection RASDs.
        Write-Verbose "Get original connection RASDs"
        $connectionSettings = $wmiVSSD.GetRelated("Msvm_EthernetPortAllocationSettingData", "Msvm_VirtualSystemSettingDataComponent", $null, $null, $null, $null, $false, $null) | Where-Object { $portObjectPathMap.ContainsKey($_.Parent) }
    
        if (-Not $connectionSettings) {
            Write-Warning " - No connections were found on the original VM."
            $script:WarningCount = $script:WarningCount + 1
            return
        }
    
        # Modify the connection RASDs to point to the ports on the new VM.
        foreach ($connection in $connectionSettings) {
            Write-Verbose "Modifying connection RASD to point to ports on new VM"
            $connection.Parent = $portObjectPathMap[$connection.Parent]
        }
    
        # Add the connection RASDs to the new VM.
        $result = $vmms.AddResourceSettings($wmiNewVSSD.Path.Path, $connectionSettings.GetText(1))
    
        if ($result.ReturnValue -eq 0) {
            $newConnections = $result.ResultingResourceSettings
        } else {
            Cleanup ("Failed Calling AddResourceSettings for connection RASDs")
        }
    
        # For each connection, modify its FSDs to point to the connections on the new VM.
        $index = 0
        foreach ($connection in $connectionSettings) {
            # When you add a connection, the offload feature settings are created by default.
            # Remove the default instance first before copying over the existing FSDs.
            
            $newOffloadFsd = ([wmi]$newConnections[$index]).GetRelated("Msvm_EthernetSwitchPortOffloadSettingData", "Msvm_EthernetPortSettingDataComponent", $null, $null, $null, $null, $false, $null) | %{$_}
            
            if ($newOffloadFsd) {
                $result = $vmms.RemoveFeatureSettings($newOffloadFsd.Path.Path)
                if ($result.ReturnValue -ne 0) { Cleanup ("Failed Cleaning Up Default Offload Settings") }
            }
            
            $fsds = $connection.GetRelated("Msvm_EthernetSwitchPortFeatureSettingData", "Msvm_EthernetPortSettingDataComponent", $null, $null, $null, $null, $false, $null) | %{$_}
    
            if ($fsds) {
                $result = $vmms.AddFeatureSettings($newConnections[$index], $fsds.GetText(1))
                    if ($result.ReturnValue -ne 0) { Cleanup ("Failed Calling AddFeatureSettings") }
            }
    
            $index++
        }
        $script:ProgressPoint = 1397
    }
    Catch [Exception] {
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red ("Exception in Copy-Networking: " + $_.Exception.ToString())
        Cleanup ("Exception in Copy-Networking")
    }
    Finally {
        Write-Verbose "<< Copy-Networking()"
    }
}
    
# ---------------------------------------------------------------------------------------------------------------------------
# Function to create a clone of a generation 1 VM but in generation 2 configuration.
# ---------------------------------------------------------------------------------------------------------------------------
Function Clone-SourceToGeneration2($SourceVM, $SourceBootDiskPath) {

    Write-Verbose ">> Clone-SourceToGeneration2"
    $script:ProgressPoint = 1400
    try {

        Write-Info "Configuring '$NewVMName'. Baseline configuration from '$VMName'..."

        # Resource metering. If enabled, this won't be migrated. There's actually no way to set the metrics anyway apart from an
        # extremely unsupported manner of editing the VM config XML.
        if ($script:SourceVMObject.ResourceMeteringEnabled) { 
            Write-Warning "Resource metering will not be configured on new VM"
            $script:WarningCount = $script:WarningCount + 1
        }

        # Floppy media. Yes, really. Tempted to bail here instead, to see if anyone ever complains...
        if (((Get-VMFloppyDiskDrive $script:SourceVMObject).Path) -ne $Null) { 
            Write-Warning (" - Ignoring floppy media '" + ((Get-VMFloppyDiskDrive $script:SourceVMObject).Path) +"'.")
            $script:WarningCount = $script:WarningCount + 1
        }
    
        # COM Port checks
        if ((Get-VMComport $script:SourceVMObject -number 1).Path.Length) { 
            Write-Warning " - Ignoring COM1: configuration."
            $script:WarningCount = $script:WarningCount + 1
        }

        if ((Get-VMComport $script:SourceVMObject -number 2).Path.Length) { 
            Write-Warning " - Ignoring COM2: configuration."
            $script:WarningCount = $script:WarningCount + 1
        }
    
        # RemoteFX. Warn if it's configured as generation 2 virtual machines in Windows Server 2012 R2 does not support RemoteFX
        if ($Null -ne ($script:SourceVMObject.RemoteFxAdapter)) { 
            Write-Warning " - RemoteFX will not be configured."
            $script:WarningCount = $script:WarningCount + 1
        }

        if ($script:SourceVMObject.IsClustered) { 
            Write-Warning " - New virtual machine needs to be placed in a cluster manually."
            $script:WarningCount = $script:WarningCount + 1
        }

        $script:ProgressPoint = 1410
    
        # Fibre Channel. Warn if it's configured as it won't be copied across.
        # It's more a case of priorities and machines to validate on. Generation 2 does support FC.
        #if ($Null -ne ($script:SourceVMObject.FibreChannelHostBusAdapters[0])) { 
        #    Write-Warning "Fibre Channel will not be configured on new VM"
        #    $script:WarningCount = $script:WarningCount + 1
        #} Nope. We got this now 9th Oct 2013.

        # Legacy network adapters
        if ($Null -ne (Get-VMNetworkAdapter $SourceVM -IsLegacy $True)) { 
            Write-Warning " - Ignoring legacy network adapters."
            $script:WarningCount = $script:WarningCount + 1
        }
        $script:ProgressPoint = 1420

        # Warnings for DVD passthrough and empty drives
        $i = 0
        do {
            Write-Verbose ("Examining "+([math]::floor([int] $i / [int] 2)) + ":" +($i%2) + " for DVDs and .VHDs")
            $IDEDisk = Get-VMHardDiskDrive $SourceVM -ControllerNumber  ([math]::floor([int] $i / [int] 2)) -ControllerLocation ($i%2) -ControllerType IDE -ErrorAction SilentlyContinue 
            if (!$?) { Cleanup ("Failed to query IDE Hard disk from source VM`n"+ $Error[0][0]) }

            if ($IDEDisk) { 
                if (($IDEDisk.Path).ToLower() -ne $SourceBootDiskPath.ToLower()) {
                    Write-Verbose ("Found data disk at " + ($IDEDisk.Path))
                    if (([System.IO.Path]::GetExtension($IDEDisk.Path)).ToLower() -eq ".vhd") {
                        Write-Warning (" - Ignoring .VHD file '" + ($IDEDisk.Path) + "'.")
                        $script:WarningCount = $script:WarningCount + 1
                    } 
                } else {
                    Write-Verbose ("Ignoring this disk as it's the one we had as boot")
                }
            }

            $DVD = Get-VMDVDDrive $SourceVM -ControllerNumber  ([math]::floor([int] $i / [int] 2)) -ControllerLocation ($i%2) -ErrorAction SilentlyContinue
            if (!$?) { Cleanup ("Failed to query IDE DVD drive from source VM`n"+ $Error[0][0]) }
            $i++
            if ($DVD) {
                if (($DVD.DvdMediaType) -eq "PassThrough") {
                    Write-Warning (" - Ignoring passthrough DVD to '" + ($DVD.Path) + "'.")
                    $script:WarningCount = $script:WarningCount + 1
                } else {
                    # ISO or Empty
                    Write-Verbose ("Found a DVD")
                    if (($DVD.DvdMediaType) -ne "ISO") {
                        Write-Warning (" - Ignoring DVD drive at IDE " + ([math]::floor([int] $i / [int] 2)) + ":" + ($i%2) + " with no media.")
                        $script:WarningCount = $script:WarningCount + 1
                    }
                }
            }
        } while ($i -le 3)
        $script:ProgressPoint = 1430

        # Basics of the new VM. Use the same path and memory initially. Obviously generation 2 :)
        $VMPath = $SourceVM.Path
        if ($Path -ne "") {
            Write-Verbose ("Path override for new VM to use supplied " + $Path)
            $VMPath = $Path
        }

        $NewVM = New-VM -Name $NewVMName `
                        -Path $VMPath `
                        -MemoryStartupBytes $SourceVM.MemoryStartup `
                        -Generation 2 `
                        -ErrorAction SilentlyContinue
        if (!$?) { Cleanup ("Failed to create VM $NewVMName`n"+ $Error[0][0]) }
        $script:ProgressPoint = 1440

        # Remove the default network adapter
        Remove-VMNetworkAdapter $NewVM -ErrorAction SilentlyContinue
        if (!$?) { Cleanup ("Failed to remove default NIC from $NewVMName`n"+ $Error[0][0]) }

        # Note: The paths are deliberately NOT configured (Set-VM -SmartPagingFilePath -SnapshotFileLocation...)

        #Memory settings 
        Write-Info " - Memory..."
        try {
            if ($SourceVM.DynamicMemoryEnabled) {
                Set-VM -VM $NewVM -DynamicMemory
                Set-VM -VM $NewVM -MemoryMinimumBytes $SourceVM.MemoryMinimum
                Set-VM -VM $NewVM -MemoryMaximumBytes $SourceVM.MemoryMaximum
                Set-VMMemory $NewVM -Buffer (Get-VMMemory -VM $SourceVM).Buffer
                Set-VMMemory $NewVM -Priority (Get-VMMemory -VM $SourceVM).Priority
                Set-VMMemory $NewVM -MaximumAmountPerNumaNodeBytes ((Get-VMMemory -VM $SourceVM).MaximumPerNumaNode * 1024 * 1024)
            } else {
                set-vm -vm $newvm -StaticMemory
            }
            Set-VM -VM $NewVM -MemoryStartupBytes $SourceVM.MemoryStartup
            Set-VMMemory $NewVM -ResourcePoolName (Get-VMMemory -VM $SourceVM).ResourcePoolName
        } catch { Cleanup ("Failed to configure memory on $NewVMName`n"+ $Error[0][0]) }
        $script:ProgressPoint = 1450
    
        #Processors
        try {
            Write-Info " - Processors..."
            Set-VMProcessor -VM $NewVM -Count (Get-VMProcessor -VM $SourceVM).Count
            Set-VMProcessor -VM $NewVM -CompatibilityForMigrationEnabled (Get-VMProcessor -VM $SourceVM).CompatibilityForMigrationEnabled
            Set-VMProcessor -VM $NewVM -CompatibilityForOlderOperatingSystemsEnabled (Get-VMProcessor -VM $SourceVM).CompatibilityForOlderOperatingSystemsEnabled
            Set-VMProcessor -VM $NewVM -Maximum (Get-VMProcessor -VM $SourceVM).Maximum
            Set-VMProcessor -VM $NewVM -Reserve (Get-VMProcessor -VM $SourceVM).Reserve
            Set-VMProcessor -VM $NewVM -RelativeWeight (Get-VMProcessor -VM $SourceVM).RelativeWeight
            Set-VMProcessor -VM $NewVM -MaximumCountPerNumaNode (Get-VMProcessor -VM $SourceVM).MaximumCountPerNumaNode
            Set-VMProcessor -VM $NewVM -MaximumCountPerNumaSocket (Get-VMProcessor -VM $SourceVM).MaximumCountPerNumaSocket
            Set-VMProcessor -VM $NewVM -ResourcePoolName (Get-VMProcessor -VM $SourceVM).ResourcePoolName
        } catch { Cleanup ("Failed to configure processor on $NewVMName`n"+ $Error[0][0]) }
        $script:ProgressPoint = 1460

        # Add the new disk we have converted on first SCSI controller. Note that we set QOS on this later.
        Write-Info " - Storage..."
        $NewBootVHDX = Add-VMHardDiskDrive $NewVM -Path $VHDX -ControllerType SCSI -ControllerNumber 0 -ControllerLocation 0 -PassThru -ErrorAction SilentlyContinue
        if (!$?) { Cleanup ("Failed to add $VHDX to $NewVMName`n"+ $Error[0][0]) }
        $SCSICurrentLocation  = 1  #Keep track of where we're adding disks to. Start at 1 as 0 is the boot disk we've migrated 

        # Other IDE attached devices
        $i = 0
        do {
            Write-Verbose ("Examining "+([math]::floor([int] $i / [int] 2)) + ":" +($i%2) + " for other data disks")
            $IDEDisk = Get-VMHardDiskDrive $SourceVM -ControllerNumber  ([math]::floor([int] $i / [int] 2)) -ControllerLocation ($i%2) -ControllerType IDE -ErrorAction SilentlyContinue 
            if (!$?) { Cleanup ("Failed to query IDE Hard disk from source VM`n"+ $Error[0][0]) }

            $DVD = Get-VMDVDDrive $SourceVM -ControllerNumber  ([math]::floor([int] $i / [int] 2)) -ControllerLocation ($i%2) -ErrorAction SilentlyContinue
            if (!$?) { Cleanup ("Failed to query IDE DVD drive from source VM`n"+ $Error[0][0]) }

            $i++
            if ($IDEDisk) { 
                if (($IDEDisk.Path).ToLower() -ne $SourceBootDiskPath.ToLower()) {
                    Write-Verbose ("Found data disk at " + ($IDEDisk.Path))
                    if (([System.IO.Path]::GetExtension($IDEDisk.Path)).ToLower() -ne ".vhd") {
                        if ($IDEDisk.SupportPersistentReservations) {
                            Write-Warning (($IDEDisk.Path) + " is shared. Guest cluster may be broken")
                            $script:WarningCount = $script:WarningCount + 1
                        } else {
                            Write-Verbose ("Adding " + ($IDEDisk.Path) + " at location " + ($SCSICurrentLocation))
                            Add-VMHardDiskDrive $NewVM -Path ($IDEDisk.Path) `
                                                       -ControllerType SCSI `
                                                       -ControllerNumber 0 `
                                                       -ControllerLocation $SCSICurrentLocation `
                                                       -MaximumIOPS ($IDEDisk.MaximumIOPS) `
                                                       -MinimumIOPS ($IDEDisk.MinimumIOPS) `
                                                       -ResourcePoolName ($IDEDisk.PoolName) `
                                                       -ErrorAction SilentlyContinue
                            if (!$?) { Cleanup ("Failed to add " + ($IDEDisk.Path) + " at SCSILocation " + $SCSICurrentLocation + "`n"+ $Error[0][0]) }
                            $SCSICurrentLocation = $SCSICurrentLocation + 1
                        }
                    }
                } else {
                    Write-Verbose ("Setting QOS and PoolName to mirror the source boot disk " + ($IDEDisk.Path))
                    Set-VMHardDiskDrive $NewBootVHDX -MaximumIOPS ($IDEDisk.MaximumIOPS) -MinimumIOPS ($IDEDisk.MinimumIOPS) -ResourcePoolName ($IDEDisk.PoolName) -ErrorAction SilentlyContinue
                    if (!$?) { Cleanup ("Failed to set boot disk IOPS/PoolName from " + ($IDEDisk.Path) + " at SCSILocation " + $SCSICurrentLocation + "`n"+ $Error[0][0]) }

                    # Warning for differencing and fixed disk
                    $OriginalBootDisk = Get-VHD ($IDEDisk.Path)
                    if (!$?) { Cleanup ("Failed to Get-VHD on " + ($IDEDisk.Path) + "`n"+ $Error[0][0]) }

                    if ($OriginalBootDisk.VhdType -eq "Differencing") {
                        Write-Warning ( "The original boot disk '" + $IDEDisk.Path + "' is a differencing disk. " + `
                                        "The new boot disk '" + $VHDX + "' has been created as a dynamically expanding VHDX.")
                        $script:WarningCount = $script:WarningCount + 1
                    }

                    if ($OriginalBootDisk.VhdType -eq "Fixed") {
                        Write-Warning ( "The original boot disk '" + $IDEDisk.Path + "' is a fixed disk. " + `
                                        "The new boot disk '" + $VHDX + "' has been created as a dynamically expanding VHDX.")
                        $script:WarningCount = $script:WarningCount + 1
                    }

                }
            }

            if ($DVD) {
                if (($DVD.DvdMediaType) -ne "PassThrough") {
                    # ISO or Empty
                    Write-Verbose ("Found a DVD")
                    if (($DVD.DvdMediaType) -eq "ISO") {
                        Write-Verbose ("Which has an .ISO in it so adding a DVD drive at location " + ($SCSICurrentLocation))
                        Write-Verbose ("Adding " + ($DVD.Path))
                        Add-VMDvdDrive $NewVM -Path ($DVD.Path) -ControllerNumber 0 -ControllerLocation $SCSICurrentLocation -ResourcePoolName ($DVD.PoolName) -ErrorAction SilentlyContinue
                        if (!$?) { Cleanup ("Failed to add DVD " + ($DVD.Path) + " at SCSILocation " + $SCSICurrentLocation + "`n"+ $Error[0][0]) }
                        $SCSICurrentLocation = $SCSICurrentLocation + 1
                    }
                }
            }
        } while ($i -le 3)
        $script:ProgressPoint = 1470

        # Now do the same for each SCSI controller until we hit the limit of 64. Note no DVDs
        # I could do some cleverer coding here to mirror the SCSI configuration of the source VM
        # and do the mappings the same, and cope with multiple SCSI controllers in the target.
        # However, in reality, few people will have a VM with even close to 64 drives, so
        # IMO this is an edge condition at best. Similarly, it shouldn't matter to the majority
        # of people if drives end up in different places. SCSI Controllers on generation 1 can only
        # have disks (possibly passthrough) attached to them.
        $SCSIController = 0
        $SCSILocation = 0
        Write-Verbose "Examining SCSI Controllers"
        do {
            Write-Verbose ("SCSI Controller " + ($SCSIController))
            $Controller = $Null
            $Controller = Get-VMSCSIController $SourceVM -ControllerNumber $SCSIController -ErrorAction SilentlyContinue
            if ($Controller -ne $Null) {
                do {
                    Write-Verbose ("SCSI Controller " + $SCSIController + " Location " + $SCSILocation)
                    $SCSIDisk = Get-VMHardDiskDrive $SourceVM -ControllerType SCSI -ControllerNumber $SCSIController -ControllerLocation $SCSILocation  # no error trap needed
                    if ($SCSIDisk) {
                        Write-Verbose ("Disk attached here " + ($SCSIDisk.Path) + " " + ($SCSIDisk.DiskNumber))
                        if ($Null -eq ($SCSIDisk.DiskNumber)) {
                            Write-Verbose "Is a VHD or VHDX"
                            if (([System.IO.Path]::GetExtension($SCSIDisk.Path)).ToLower() -eq ".vhd") {
                                Write-Warning ("Ignoring " + ($SCSIDisk.Path) + " due to .VHD extension")
                                $script:WarningCount = $script:WarningCount + 1
                            } else {
                                if ($SCSIDisk.SupportPersistentReservations) {
                                    Write-Warning (($SCSIDisk.Path) + " is shared. Guest cluster may be broken")
                                    $script:WarningCount = $script:WarningCount + 1
                                } else {
                                    if ($SCSICurrentLocation -le 63) {
                                        Write-Verbose ("Adding at location " + ($SCSICurrentLocation))
                                        Write-Verbose ("Adding " + ($SCSIDisk.Path)) 
                                        Add-VMHardDiskDrive $NewVM -Path ($SCSIDisk.Path)  `
                                                                   -ControllerType SCSI  `
                                                                   -ControllerNumber 0 `
                                                                   -ControllerLocation $SCSICurrentLocation `
                                                                   -MaximumIOPS ($SCSIDisk.MaximumIOPS) `
                                                                   -MinimumIOPS ($SCSIDisk.MinimumIOPS) `
                                                                   -ResourcePoolName ($SCSIDisk.PoolName) `
                                                                   -ErrorAction SilentlyContinue
                                        if (!$?) { Cleanup ("Failed to add " + ($SCSIDisk.Path) + " at SCSILocation " + $SCSICurrentLocation + "`n"+ $Error[0][0]) }
                                        $SCSICurrentLocation = $SCSICurrentLocation + 1
                                    } else {
                                        Write-Warning ("Ignoring " + ($SCSIDisk.Path) + " - more disks than this script handles")
                                        $script:WarningCount = $script:WarningCount + 1
                                    }
                                }
                            }
                        } else {
                            Write-Verbose "Is a passthrough disk"
                            if ($SCSICurrentLocation -le 63) {
                                # Note QOS is not available for passthrough disks
                                Write-Verbose ("Adding " + ($SCSIDisk.Path))
                                Add-VMHardDiskDrive $NewVM -ControllerType SCSI `
                                                           -ControllerNumber 0  `
                                                           -ControllerLocation $SCSICurrentLocation `
                                                           -DiskNumber ($SCSIDisk.DiskNumber) `
                                                           -ErrorAction SilentlyContinue
                                if (!$?) { Cleanup ("Failed to add " + ($SCSIDisk.Path) + " at SCSILocation " + $SCSICurrentLocation + "`n"+ $Error[0][0]) }
                                $SCSICurrentLocation = $SCSICurrentLocation + 1
                            } else {
                               Write-Warning (" - Ignoring '" + ($SCSIDisk.Path) + "' as there are more disks on the source VM than this script handles")
                               $script:WarningCount = $script:WarningCount + 1
                            }
                        }
                    }
                    $SCSILocation = $SCSILocation + 1
                } while ($SCSILocation -le 63) 
            } else {
                Write-Verbose ("No SCSI Controller " + ($SCSIController))
            }
            $SCSIController = $SCSIController + 1
            $SCSILocation = 0
        } while ($SCSIController -le 3) 
        Write-Verbose "Finished SCSI Controllers"
        $script:ProgressPoint = 1480

        # Fibre Channel adapters
        Write-Verbose ("FC adapters")
        $SourceVM.FibreChannelHostBusAdapters | Foreach-object {
            Write-Verbose ("Top of FC Loop " + ($_ | fl * | Out-String))
            if ($_.SanName.Length -gt 0) {
                $Added = Add-VMFibreChannelHba $NewVM `
                            -SanName $_.SanName `
                            -WorldWideNodeNameSetA $_.WorldWideNodeNameSetA `
                            -WorldWidePortNameSetA $_.WorldWidePortNameSetA `
                            -WorldWideNodeNameSetB $_.WorldWideNodeNameSetB `
                            -WorldWidePortNameSetB $_.WorldWidePortNameSetB `
                            -passthru `
                            -ErrorAction SilentlyContinue
                if (!$?) { Cleanup ("Failed to add FC adapter to VM`n"+ $Error[0][0]) }
                Write-Verbose ("Added HBA configuration" + ($_ | fl * | Out-String))
            } else {
                Write-Warning (" - Ignoring an HBA with no SAN name")
                $script:WarningCount = $script:WarningCount + 1
            }
        } # For each FC adapter         
        $script:ProgressPoint = 1485

        #Notes
        Write-Info " - Notes..."
        Set-VM -VM $NewVM -Notes ("Generation 2 conversion of '" + $SourceVM.Name + "' " + (Get-Date -format 'dd MMM yyyy hh:mm:ss'))
        $script:ProgressPoint = 1486
        if ($SourceVM.Notes) { 
            $script:ProgressPoint = 1487
            Set-VM -VM $NewVM -Notes ($NewVM.Notes + " - " + $SourceVM.Notes) 
            $script:ProgressPoint = 1488
        }

        #Integration Services
        Write-Info " - Integration Services..."
        $ICs = Get-VMIntegrationService $SourceVM
        $script:ProgressPoint = 1489
        ForEach ($IC in $ICS) {
           $script:ProgressPoint = 1490
           if ($IC.Enabled) {
               Write-Verbose ("Enabling IC " + ($IC.Name))
               Enable-VMIntegrationService -Name $IC.Name -VM $NewVM 
               $script:ProgressPoint = 1491
           } else {
               Write-Verbose ("Disabling IC " + ($IC.Name))
               Disable-VMIntegrationService -Name $IC.Name -VM $NewVM 
               $script:ProgressPoint = 1492
           }
        }

        #Start/Stop actions
        Write-Info " - Start/stop actions..."
        $script:ProgressPoint = 1493
        Set-VM -VM $NewVM -AutomaticStartAction $SourceVM.AutomaticStartAction
        Set-VM -VM $NewVM -AutomaticStartDelay $SourceVM.AutomaticStartDelay
        Set-VM -VM $NewVM -AutomaticStopAction $SourceVM.AutomaticStopAction

        #Networking
        $script:ProgressPoint = 1494
        Write-Info " - Networking..."
        Copy-Networking $SourceVM $NewVM
        $script:ProgressPoint = 1495

        #Boot Order. Set the new VHDX as the first boot device
        Write-Info " - Boot order..."
        Set-VMFirmware -VM $NewVM -FirstBootDevice $NewBootVHDX -ErrorAction SilentlyContinue
        $script:ProgressPoint = 1496
        if (!$?) { Cleanup ("Failed to change the boot order for the new VM`n"+ $Error[0][0]) }

        #RemoteFX Video Adapter (as and when generation 2 supports RemoteFX. It does not in Windows Server 2012 R2)
        #Write-Info " - Graphics..."
        #if ($Null -ne ($SourceVM.RemoteFxAdapter)) {
        #    Add-VMRemoteFx3dVideoAdapter $NewVM
        #    Set-VMRemoteFx3dVideoAdapter $NewVM -MonitorCount $SourceVM.RemoteFXAdapter.MaximumMonitors `
        #                                        -MaximumResolution $SourceVM.RemoteFXAdapter.MaximumScreenResolution
        #}

        Write-Verbose "VM has been cloned"
        $script:ProgressPoint = 1497
    }
    catch [Exception] {  # Clone catch
        $script:ProgressPoint += 90000
        Write-Host -ForegroundColor Red "ERROR: Exception creating the new VM"
        Write-Host -ForegroundColor Red $_.Exception.ToString()
        Cleanup ("Exception in Clone-SourceToGeneration2")
    }
    Finally {
        Write-Verbose "<< Clone-SourceToGeneration2"
    }
} # Clone-SourceToGeneration2

# ---------------------------------------------------------------------------------------------------------------------------
# Start of conversion code
# ---------------------------------------------------------------------------------------------------------------------------

Try {

    Write-Verbose ">> Convert-VMGeneration Starting"
    $script:ProgressPoint = 1500

    # Allows me to feed some test cases into this script. Nothing to see by end users...
    if (Test-Path ".\Convert-VMGeneration-TestSetup.ps1") { 
        Get-PSBreakpoint -variable JOHNISDEBUGGING | Remove-PSBreakpoint 
        $JOHNISDEBUGGING = $False
        Write-Host "Loading test configuration for debugging purposes"
        (. ".\Convert-VMGeneration-TestSetup.ps1") 
        Set-PSBreakPoint -Variable JOHNISDEBUGGING -Mode Write
        $JOHNISDEBUGGING = $true  # Trigger the break
    }

    # About me.
    if (!$Quiet){
        Write-Host ""
        Write-Host -fore Yellow "Hyper-V Generation 2 Virtual Machine Conversion Utility. Version $script:Version, $script:LastModified."
        Write-Host -fore Cyan   "John Howard, Hyper-V Team, Microsoft Corporation (http://blogs.technet.com/jhoward)"  
        Write-Host -fore Cyan   "http://code.msdn.microsoft.com/ConvertVMGeneration"
        Write-Host ""
    }

    # Bunch of additional parameter validation
    Write-Verbose "Calling Validate-Parameters"
    $script:ProgressPoint = 1502
    if (!$script:TestHookIgnoreParameterChecks) { 
        $script:ProgressPoint = 1504
        Validate-Parameters 
    }

    # We do a bunch of pre-flighting such as making sure VM exists, is generation 1 and so on.
    Write-Verbose "Calling PreFlight-Checks"
    $script:ProgressPoint = 1506
    PreFlight-Checks

    # Locate the boot disk from the source VM. We always need this for Capture and Clone.
    # If we don't have $VHDXSizeGB specified, we also need it for Apply (as we need to find the size of the originating boot disk Windows partition)
    $script:ProgressPoint = 1508
    if ( (($Action -eq "Capture") -or ($Action -eq "Clone") -or ($Action -eq "All")) -or `
         (($Action -eq "Apply") -and ($VHDXSizeGB -eq 0)) ) {
        $script:ProgressPoint = 1510
        Write-Verbose "Calling Locate-SourceBootDisk"
        Locate-SourceBootDisk $script:SourceVMObject ([Ref] $script:SourceBootDiskPath)
    }

    # Mount the boot disk for the source VM. Not needed for clone, we just need a reference to the object.
    # If we don't have $VHDXSizeGB specified, we also need it for Apply (as we need to find the size of the originating boot disk Windows partition)
    $script:ProgressPoint = 1512
    if ( (($Action -eq "Capture") -or ($Action -eq "All")) -or `
         (($Action -eq "Apply") -and ($VHDXSizeGB -eq 0)) ) {
        $script:ProgressPoint = 1514
        Write-Verbose "Calling Mount-Disk for source"
        Mount-Disk $script:SourceBootDiskPath ([Ref] $script:SourceBootDiskMounted) 
    }

    # Allocate a couple of drive letters which will be needed on the new VHDX. Use for the new VHDX, hence for Apply and All.
    $script:ProgressPoint = 1516
    if (($Action -eq "Apply") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1518
        Write-Verbose "Calling Allocate-TwoFreeDriveLetters"
        Allocate-TwoFreeDriveLetters ([Ref] $script:TargetDriveLetterESP) ([Ref] $script:TargetDriveLetterWindows)
    }

    # Validate the source boot disk by looking for a single copy of Windows on it of a version that will work in a generation 2 VM
    # If we don't have $VHDXSizeGB specified, we also need it for Apply (as we need to find the size of the originating boot disk Windows partition)
    $script:ProgressPoint = 1520
    if ( (($Action -eq "Capture") -or ($Action -eq "All")) -or `
         (($Action -eq "Apply") -and ($VHDXSizeGB -eq 0))) {
        $script:ProgressPoint = 1522
        Write-Verbose "Calling Validate-SourceWindowsInstallation"
        Validate-SourceWindowsInstallation $script:SourceBootDiskPath `
                                           ([Ref] $script:SourceBootDiskWindowsPartition) `
                                           ([Ref] $script:SourceBootDiskWindowsPartitionNum) `
                                           ([Ref] $script:SourceBootDiskWindowsPartitionUsed)
    }
                                      
    # Validate RE (and PBR) is appropriately configured unless user overrides
    $script:ProgressPoint = 1524
    if (($Action -eq "Capture") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1526
        Write-Verbose "Calling Verify-RecoveryEnvironment"
        Verify-RecoveryEnvironment $script:SourceBootDiskWindowsPartition.DriveLetter
    }

    # Generate the name of the boot disk to be used on the new target generation 2 virtual machine (in $VHDX)
    $script:ProgressPoint = 1528
    if (($Action -eq "Apply") -or ($Action -eq "Clone") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1530
        Write-Verbose "Calling Generate-PathToTargetBootDisk"
        Generate-PathToTargetBootDisk $script:SourceBootDiskPath 
    }

    # Size and create the boot disk which will be used on the target VM. Name is in $VHDX
    $script:ProgressPoint = 1532
    if (($Action -eq "Apply") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1534
        Write-Verbose "Calling Create-TargetVHDX"
        if ($script:SourceBootDiskWindowsPartition -eq $Null) { Create-TargetVHDX 0 } else { Create-TargetVHDX $script:SourceBootDiskWindowsPartition.Size }
    }

    # Mount the target boot disk which we will be populating
    $script:ProgressPoint = 1536
    if (($Action -eq "Apply") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1538
        Write-Verbose "Calling Mount-Disk for Target"
        Mount-Disk $VHDX ([Ref] $script:TargetBootDiskMounted)
    }

    # Initialise and partition the target VHDX
    $script:ProgressPoint = 1540
    if (($Action -eq "Apply") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1542
        Write-Verbose "Calling Partition-TargetVHDX"
        Partition-TargetVHDX $script:TargetDriveLetterESP $script:TargetDriveLetterWindows ([Ref] $script:TargetDriveESPConfigured)
    }

    # Capture the image of the source VM into a WIM. We do this after the partitioning of the target as
    # otherwise, the user waits ages for the prompt to continue. Would rather get that done as early as possible.
    $script:ProgressPoint = 1544
    if (($Action -eq "Capture") -or ($Action -eq "All")) {
    $script:ProgressPoint = 1546
        Write-Verbose "Calling Capture-ImageOfSourceVHDX"
        Capture-ImageOfSourceVHDX $script:SourceBootDiskWindowsPartition.DriveLetter
    }

    # Apply the image to the target VHDX
    $script:ProgressPoint = 1548
    if (($Action -eq "Apply") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1550
        Write-Verbose "Calling Apply-ImageToTargetVHDX"
        Apply-ImageToTargetVHDX $script:TargetDriveLetterESP $script:TargetDriveLetterWindows 
    }

    # Create the new VM which is a clone of the source VM
    $script:ProgressPoint = 1552
    if (($Action -eq "Clone") -or ($Action -eq "All")) {
        $script:ProgressPoint = 1554
        Write-Verbose "Calling Clone-SourceToGeneration2"
        Clone-SourceToGeneration2 $script:SourceVMObject $script:SourceBootDiskPath
    }

    $script:ReachedEndOfProcessing = $True
    $script:ProgressPoint = 1597
}
Catch [Exception] {
    $script:ProgressPoint += 90000
    #Write-Host -ForegroundColor Red ("Exception in main execution: " + $_.Exception.ToString())
    Cleanup ("Exception in main execution`n" + $_.Exception.ToSTring())
}
Finally {
    Write-Verbose "In Finally of main execution calling cleanup"
    Cleanup
} 
# End of Convert-VMGeneration.ps1