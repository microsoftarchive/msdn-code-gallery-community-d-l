# Hyper-V generation 2 VM conversion utility (Convert-VMGeneration)
## License
- MS-LPL
## Technologies
- Hyper-V
## Topics
- Hyper-V
## Updated
- 12/11/2013
## Description

<h1>Latest Version</h1>
<p>Version 1.04 6th December 2013</p>
<p><span style="font-size:small"><strong>Please read <a href="http://blogs.technet.com/b/jhoward/archive/2013/11/14/hyper-v-generation-2-virtual-machines-part-10.aspx">
this</a> for more information on this script including tips and further examples, or
<a href="http://blogs.technet.com/b/jhoward/archive/2013/11/06/hyper-v-generation-2-virtual-machines-part-8.aspx">
this </a>for a detailed manual walkthrough of the overall steps this script follows.</strong></span></p>
<p><br>
If&nbsp;you find Convert-VMGeneration useful, please drop me an email through <a href="http://blogs.technet.com/jhoward">
my&nbsp;blog</a> or provide a rating above ^^^. Thank you! :)</p>
<h1><span>About</span></h1>
<p><span>Convert-VMGeneration converts a generation 1 virtual machine running on Hyper-V in Windows Server 2012 R2 or Windows 8.1 to generation 2. It does not change the source generation 1 virtual machine during the process - a new virtual machine is created
 with a new boot disk. <br>
</span></p>
<p>Convert-VMGeneration.ps1 is self-documenting. After saving to a local disk, run &quot;get-help .\Convert-VMGeneration.ps1&quot; from a Windows PowerShell prompt.</p>
<p>Due to virtual hardware differences between a generation 1 and generation 2 virtual machines, certain devices such as floppy disk drives, DVD drives using physical media, legacy network adapters and COM: ports are not migrated. Additional data or recovery
 image partitions on the boot disk are not migrated.</p>
<p>Due to the highly destructive action of wiping a disk (the new boot disk for the generation 2 virtual machine) during the conversion process, the warning check and prompt for user configuration cannot be overridden. You should make absolutely sure before
 confirming that the right disk is about to be wiped. While every attempt has been made to validate there is not a bug in the code, no liability is accepted should accidental data loss occur. If in doubt, to minimise risks, run this script on a machine where
 no essential data exists, and use an exported/backup copy of the generation 1 virtual machine as the source for the conversion.<span><br>
&nbsp;</span><span> <br>
</span></p>
<p><span><img id="100204" src="100204-ps%20windows%201.01.jpg" alt="" width="703" height="598"></span></p>
<p><span><img id="100205" src="100205-converted%20vm%201.01.jpg" alt="" width="710" height="1137"></span></p>
<h1><span>Requirements</span></h1>
<p><span>Convert-VMGeneration must be run on Windows 8.1 or Windows Server 2012 R2 with the Hyper-V feature/role enabled. It has not been tested on server core installations of Windows Server 2012 R2 or Microsoft Hyper-V Server 2012 R2.</span><span> Convert-VMGeneration
 supports the following guest operating systems:</span></p>
<ul>
<li><span>Windows 8 (64-bit editions)</span> </li><li><span>Windows 8.1 (64-bit editions)</span> </li><li><span>Windows Server 2012</span> </li><li><span>Windows Server 2012 R2</span> </li></ul>
<p><span>Convert-VMGeneration will not convert a virtual machine that</span></p>
<ul>
<li>Has checkpoints </li><li>Is running </li><li>Uses virtual hard disk sharing </li><li>Has Hyper-V replica enabled (experimental support with -IgnoreReplicaCheck) </li></ul>
<h1>Installation &amp; Removal</h1>
<p>Save&nbsp;Convert-VMGeneration.ps1 to a directory on the local disk (eg c:\Scripts\). There is no setup program.&nbsp;Run it from an elevated Windows PowerShell command prompt. To uninstall, simply delete the file.&nbsp;</p>
<h1>Known Issues</h1>
<ul>
<li>If you close the Windows PowerShell window while a conversion is in progress, you may find that a drive letter remains present in Windows File Explorer which cannot be removed without a reboot of the machine.&nbsp; &quot;Control-C&quot; the script and let it cleanup
 itself before closing the window. (This is in fact a bug in Windows rather than the script.)
</li><li>Dual boot virtual machine configurations may be incorrectly migrated. </li><li>Very occasionally, partitions are not assigned drive letters. If the partition in question is the Windows partition of the source VMs virtual hard disk, the conversion will fail. This is being investigated. A workaround is in the Q&amp;A.
</li><li>Please report any other exceptions that are reported on the Q&amp;A tab to help make this utility better.
</li></ul>
<h1>Acknowledgements</h1>
<p>Many, many&nbsp;thanks to Stefan Wernli and Brian Young, both developers on the Hyper-V team. Without their assistance, on multiple occasions, I would never have succeeded in completing this project.&nbsp;</p>
<p>I make no apologies in admitting that this was my first significant PowerShell undertaking. As such, any coding 'standard' should not be used as an example of how to write good PowerShell. Its style is more a cocktail fusion of my experiences in&nbsp;C,
 VB6, .NET and VBScript, with a twist of &quot;that'll get the job done&quot; and &quot;dumb luck&quot; :) It does however have some great examples of VM cloning, in particular networking cloning (thanks again Brian!).</p>
<h1>Disclaimer</h1>
<p>Although I work for Microsoft and am a Program Manager in the Hyper-V team, I must point you to the disclaimer on my blog, the disclaimer in files associated with this project, and the license conditions at the top of this page before use.&nbsp;Convert-VMGeneration.ps1
 and any associated files are provided &quot;as-is&quot;. You bear the risk of using it. No express warranties, guarantees or conditions are provided. It is not supported or endorsed by Microsoft Corporation and should be used at your own risk.</p>
<p>Legal &amp; jargon-free moment - although this tool itself is unsupported, the steps and processes the tool follows to convert an operating system installation from generation 1 to generation 2, including dism, diskpart, bcdboot, cloning a VMs configuration,
 the use of reagentc for configuring the recovery environment and anything I missed in that list&nbsp;are supported. Everything the tool does uses APIs, applications and recommendations fully documented/supported in the ADK, Technet and/or MSDN.</p>
<p>Thanks,<br>
John</p>
<div id="_mcePaste" class="mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
