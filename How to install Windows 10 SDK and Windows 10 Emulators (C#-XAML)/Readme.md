# How to install Windows 10 SDK and Windows 10 Emulators (C#-XAML)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Visual Studio 2015
- Windows 10
- UWP
## Topics
- How to Install Windows 10 SDK?
- How to install Windows 10 Emulators
- What is UWP apps?
## Updated
- 03/27/2016
## Description

<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Introduction:</strong></span></p>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">If you are a beginner with UWP(Universal Windows Platform) apps, this post is here to help you get started. Step by step, I am going to show you&nbsp;</span><span style="font-family:verdana,sans-serif">&quot;</span><strong>How
 to install windows 10 sdk ?</strong><span style="font-family:verdana,sans-serif">&quot; and also &quot;</span><strong>How to&nbsp;<strong>install windows 10 New Emulators&nbsp;</strong>?</strong><span style="font-family:verdana,sans-serif">&quot; with Visual Studio 2015
 Community Update 1.&nbsp;</span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">&nbsp;</span></span><span style="font-family:verdana,sans-serif; font-size:small">You can also read this article from original blog from
<a title="SubramanyamRaju Windows App Tutorials" href="http://bsubramanyamraju.blogspot.com/2016/03/how-to-install-windows-10-sdk-and.html" target="_blank">
here</a>.&nbsp;</span></p>
</div>
<div>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://2.bp.blogspot.com/-IAYaHCnx4Is/VvaA3p1aLiI/AAAAAAAACdk/OA95Ao7znTwDX6SjIqROvmDpxlhl4A_3g/s1600/1.IntroductionImage.png"><img src=":-1.introductionimage.png" border="0" alt=""></a></span></p>
<span style="font-family:verdana,sans-serif; font-size:small">
<p class="separator">This article can explain you about below topics:</p>
</span></div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. Why UWP apps?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">2. How to install Windows 10 sdk?</span></p>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">3. How to repair, modify and&nbsp;</span><span style="font-family:verdana,sans-serif">uninstall&nbsp;</span><span style="font-family:verdana,sans-serif">Windows 10 sdk?</span></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">4. How&nbsp;to install Windows 10 Emulators?</span></p>
</div>
<div>
<p><span style="font-size:small"><strong>Requirements:</strong></span></p>
<ul>
<li><span style="font-size:small"><span style="font-family:verdana,sans-serif">Windows 10 SDK works best on the Windows 10 operating system. And it is&nbsp;</span><span style="font-family:verdana,sans-serif">also supported on: Windows 8.1, Windows 8, Windows
 7, Windows Server 2012, Windows Server 2008 R2, but n</span><span style="font-family:verdana,sans-serif">ot all tools are supported on these operating systems.</span></span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">Current release (Version 1511)&nbsp;of the Windows SDK doesn't include a .NET Framework Redistributable Package. So we may need to install&nbsp;<a href="https://www.microsoft.com/en-us/download/details.aspx?id=48130">Microsoft
 .NET Framework 4.6 Package</a>.</span> </li><li><span style="font-family:verdana,sans-serif; font-size:small">Make sure the computer you&rsquo;re installing on has the minimum required disk space that is from 10MB to 2.5GB hard disk space, otherwise, setup will return an error.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">If you are trying to attempt online installer for windows 10 sdk. Make sure your system having good internet connectivity.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">We can get Windows 10 SDK by installing&nbsp;<a href="https://dev.windows.com/en-us/downloads/windows-10-sdk">Windows 10 Standalone SDK</a>&nbsp;or you don&rsquo;t need to install this SDK if
 you already having&nbsp;<a href="https://dev.windows.com/en-us/downloads">Visual Studio 2015 Update 1 or later</a>.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">You must enable&nbsp;<a href="https://msdn.microsoft.com/library/windows/apps/jj863509(v=vs.105).aspx" target="_blank">Hyper-V</a>&nbsp;on your machine to use windows 10 emulators</span>
</li></ul>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Description:</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>1. Why UWP apps?</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">There are so many improvements on Unviersal Windows app development for Windows 10 from Windows 8.1 experience.</span></p>
</div>
<div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">Previously in&nbsp;windows 8.1 universal app project, we need to create two different app packages (.APPX) for windows phone &amp; Windows, but now no more than one app package and&nbsp;we can
 use only one app package that can run across all&nbsp;Microsoft&nbsp;platforms&nbsp;(Mobile,Desktop,Xbox,Surface Hub, Holographic, IOT..etc)</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">Now no need to create two separate&nbsp;projects for windows phone and windows, with windows 10 sdk now build one Universal Windows app that runs on all Windows 10 devices.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">We no longer need a developer license with Windows 10. But we must&nbsp;<a href="http://bsubramanyamraju.blogspot.in/2016/02/windows-10-uwp-apps-how-to-deploy-appx.html">Enable Developer Mode</a>&nbsp;to
 your device for development.</span> </li></ul>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>2. How to install Windows 10 SDK ?</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Please follow below steps to install Windows 10 SDK.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Step 1:</strong>&nbsp;Make sure you&rsquo;ve to downloaded the latest Windows 10 SDK or Microsoft Visual Studio 2015 from&nbsp;<a href="https://dev.windows.com/en-us/downloads">here</a>&nbsp;(Note:
 current version is VS 2015 Update 1). After that downloaded file will be locate at 'Downloads' folder,&nbsp;And I am locating&nbsp;downloaded&nbsp;file&nbsp;in below path.</span><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
</div>
<div>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-ue_i9T4Z2NA/VvaRX4n-5jI/AAAAAAAACd8/PHn0Njbpsxsv-1TuJmisHHRFvn1NeaplQ/s1600/1.InstallPath.PNG"><img src=":-1.installpath.png" border="0" alt=""></a></span></p>
<span style="font-size:small"><span style="font-family:verdana,sans-serif">
<p class="separator">Now to install setup double click on above file. And it will launch below VS dialog box</p>
<p class="separator"><a href="https://2.bp.blogspot.com/-yvL3YlIc_Uk/VvaR_x2uS_I/AAAAAAAACeA/3AcxyzedFT0lfXMGx4mt7egLD2ojNQ7Ow/s1600/2.InstallLaunch.PNG"><img src=":-2.installlaunch.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator">We can make custom installation of visual studio 2015 only for Windows 10 development and so make sure to select 'Custom' option and press 'Next' button. Then we would find below screen</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-kRlbT2SWbzw/VvaTZL_ZH1I/AAAAAAAACeQ/e2xSK2AWdbYLBwOPjIceeDON-tJL6ql0Q/s1600/3.CustomInstall.PNG"><img src=":-3.custominstall.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator">Universal Windows App Development Tools are enough to create your Windows 10 universal apps. So make sure to select them from above screen and press 'Next' button and it will ask us for confirmation of visual studio custom installation
 settings like below,</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-qtWD3FAqO2M/VvaT4tLrfpI/AAAAAAAACeU/duFDqMhdH1wzaiZ9ksdGsW1wq7pk1g4IQ/s1600/4.CustomInstallConfirm.PNG"><img src=":-4.custominstallconfirm.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator">Now press on 'Install' button and setup will start to run like below</p>
<p class="separator"><a href="https://3.bp.blogspot.com/-QllsoIHam38/VvaUY9tAT2I/AAAAAAAACec/KxyUym9sjVAKn6lwyPKHev5F21WIig2AA/s1600/5.CustomInstallStart.PNG"><img src=":-5.custominstallstart.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator">It will take more time and it depends on network speed and your system processor as well. So after some time, windows 10 sdk will be install on your system and screen could be comes with a message like '<strong>All specified components
 have been installed successfully</strong>&quot; and also its better to restart your system before to use windows 10 sdk.</p>
</span><span style="font-family:verdana,sans-serif">
<p class="separator"><a href="https://3.bp.blogspot.com/-X04-bkG2rOg/VvaYR0xvNaI/AAAAAAAACeo/0C7HLjL75HA4Z6c6vTiHZiOAWvcHhIovw/s1600/6.CustomInstallComplete.PNG"><img src=":-6.custominstallcomplete.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator"><strong>3. How to repair, modify and&nbsp;uninstall&nbsp;Windows 10 sdk?</strong></p>
<p class="separator">This step is very easy as same like general software, we need go to Control Panel, open Programs and Features and select our software name is Microsoft Visual Studio Community 2015 with Update1 and right click on to change.&nbsp;</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-vbAuv94F-Po/VvaZZa07gtI/AAAAAAAACe0/XIxDu4bD2v8PtgZTpuJcjjA6MxH9Dk6Pw/s1600/Uninstall.PNG"><img src=":-uninstall.png" border="0" alt="" width="640" height="261"></a></p>
<p class="separator">&nbsp;</p>
<p class="separator">&nbsp;</p>
<p class="separator">Now wizard would be like below</p>
<p class="separator"><a href="https://3.bp.blogspot.com/-ihTov5XrJpA/VvaaGEqtu6I/AAAAAAAACe4/OMZ3EEjEde0JNqRpRF_oouvZ-hnYRbnfA/s1600/Uninstall2.PNG"><img src=":-uninstall2.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator">Now press what ever you want to perform on setup below actions</p>
<p class="separator"><strong>Modify:</strong>&nbsp;This options is for changing custom installation of Visual Studio</p>
<p class="separator"><strong>Repair:</strong>&nbsp;If you think any package installation was missing from your current custom installation settings, then&nbsp;again&nbsp;you can repair setup to get missing package installation on your machine.</p>
<p class="separator"><strong>Uninstall:</strong>&nbsp;This option is for removing setup from your PC, Note: you need to also remove shared components of&nbsp;Microsoft .NET Framework 4.6 SDK.</p>
<p class="separator">if you think any package was missing from your installation, press 'Repair' button from wizard, but it will take time for repairing setup and screen could be comes with below message like 'All specified components have been repaired successfully&quot;
 and also we need to restart our system for making better result of setup file.</p>
</span><span style="font-family:verdana,sans-serif">
<p class="separator"><a href="https://3.bp.blogspot.com/-wC7dRzKyEUE/VvacrWSriDI/AAAAAAAACfI/W7DHXrIUaCgfUy9bf8lQ4ePUEENqGVXig/s1600/6.CustomInstallComplete.PNG"><img src=":-6.custominstallcomplete.png" border="0" alt="" width="285" height="400"></a></p>
<p class="separator">&nbsp;</p>
</span><span style="font-family:verdana,sans-serif">
<p class="separator"><span style="font-family:verdana,sans-serif"><strong>4. How&nbsp;to install Windows 10 Emulators?</strong></span></p>
Generally it is impossible to test our UWP app on every Windows 10 physical device, So visual studio made an nice extension is called Emulator concept, So Emulators can help us to see how our app appears on a different Windows device. But there are below few
 limitation to use windows 10 emulators</span></span></div>
<div>
<ul>
<li><span style="font-size:small">To test app in any of the emulators, you must have to install Visual Studio 2015 update 1 or later on a your machine.(Like in earlier above discussions)</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">Your processor should supports Client Hyper-V and Second Level Address Translation (SLAT).</span>
</li></ul>
</div>
<div><span style="font-size:small">By default, directly Windows 10 Emulators may not available w<span style="font-family:verdana,sans-serif">ith current version of Visual Studio 2015 Update 1 and you need to download windows 10 emulators&nbsp;separately. So
 please follow below steps to install window 10 emulators</span></span></div>
<div><span style="font-family:verdana,sans-serif; font-size:small"><strong>Step 1: How to to download windows 10 Emulators SDK?</strong></span></div>
<div><span style="font-family:verdana,sans-serif; font-size:small">When you open your visual studio to create new UWP app and&nbsp;trying to run your app on emulators from Debug section you would be find below screen:
<p class="separator"><a href="https://2.bp.blogspot.com/-ueCcWMZ-2Sw/Vvd0OiKNcCI/AAAAAAAACfs/Muz-hTC0CwMAAz_sl9o6xW_dqrXmFWMFw/s1600/Emulator1AskforEmulators.PNG"><img src=":-emulator1askforemulators.png" border="0" alt=""></a></p>
<p class="separator">So click on 'Download New Emulators' and it will redirect to a&nbsp;<a href="https://dev.windows.com/en-us/downloads/sdk-archive" target="_blank">Windows 10 Emulators link</a>&nbsp;there you will find below option to download latest emulators</p>
<p class="separator"><a href="https://4.bp.blogspot.com/-ZKlo7mlJlKk/Vvd182vDcqI/AAAAAAAACf4/2BkXGGaw0-Myf9a3ZYEObqMnaUBHHLggA/s1600/Emulator1DownlodLink.PNG"><img src=":-emulator1downlodlink.png" border="0" alt="" width="640" height="102"></a></p>
</span></div>
<div><span style="font-family:verdana,sans-serif">
<div>
<p><span style="font-size:small">Okay to download emulators, Tap on 'Install Emulators' and it will start to download setup file and locate it in 'Downloads' folder. So after completion of download i placed the setup file in below folder path:</span></p>
</div>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-aYlDXjKhFDA/Vvd2lynfekI/AAAAAAAACgA/2HXLqQ48IroKKhsUIcDgQnvZVBVLoQCxQ/s1600/Emulator1InstallationPath.PNG"><img src=":-emulator1installationpath.png" border="0" alt=""></a></span></p>
<p class="separator"><span style="font-size:small">Now double tap on above setup file name is 'EmulatorSetup' and you will find below screen:</span></p>
<p class="separator"><span style="font-size:small"><a href="https://3.bp.blogspot.com/-5XpjbBSpmIM/Vvd3PhqG_LI/AAAAAAAACgI/_aHaQs1PH-I9STDA-l7UoNRsp_joXDJRw/s1600/Emulator1.PNG"><img src=":-emulator1.png" border="0" alt="" width="640" height="469"></a></span></p>
<p class="separator"><span style="font-size:small">In above screen for offline installation, I am trying to download entire setup file to specific folder path is 'D:\Softwares\VStudio\2015\EmulatorSetup\EmulatorOffline'. you can also choose first option for
 direct online installation if you have good network speed in your PC.</span></p>
<p class="separator"><span style="font-size:small">Now the wizard will ask you about 'Windows Kits Privacy' with below screen, choose 'yes' and press 'Next' button</span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-M_aHJzcUyvs/Vvd45P2dfII/AAAAAAAACgU/L4z1WnmvkbggLnPpuUbcDfs1UKli-WFoQ/s1600/Emulator2.PNG"><img src=":-emulator2.png" border="0" alt="" width="640" height="468"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small">Now you can get download option for windows 10 emulators and press 'Download' button to start.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://4.bp.blogspot.com/-IRcBXRXaXCw/Vvd5VGK8iiI/AAAAAAAACgY/tcml4dnyVNUULHUg_ry4lHXJpa_SnArYg/s1600/Emulator3.PNG"><img src=":-emulator3.png" border="0" alt="" width="640" height="468"></a></span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="font-size:small">After some time it will complete download and shows &nbsp;where it is downloaded like below screen.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-UVzn6-r8sLE/Vvd5-_pScOI/AAAAAAAACgk/9dTNhDLv7d87DOi9XMS6bb_TEFbNBdelQ/s1600/Emulator5.PNG"><img src=":-emulator5.png" border="0" alt="" width="640" height="468"></a></span></p>
<p class="separator"><span style="font-size:small"><strong>Step 2: How to to install windows 10 Emulators?</strong></span></p>
<p class="separator"><span style="font-size:small">So now its time for installing emulators, go to setup download folder path at 'D:\Softwares\VStudio\2015\EmulatorSetup\EmulatorOffline'. here you will find below files</span></p>
<p class="separator"><span style="font-size:small"><a href="https://4.bp.blogspot.com/-c5bcTQbBDRA/Vvd7rDmDfeI/AAAAAAAACg4/8TFMEKOKV_EpqWpnH_BIr2trgeMM00YQw/s1600/Emulator7offlineComplete.PNG"><img src=":-emulator7offlinecomplete.png" border="0" alt=""></a></span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="font-size:small">Now run above setup file name is 'EmulatorSetup' and you will find below screen:</span></p>
<p class="separator"><span style="font-size:small"><a href="https://3.bp.blogspot.com/-PwMi5iHtRcU/Vvd7-CpRZLI/AAAAAAAAChA/5dU_mwMVgAwiSzEuU2sGMTF8ALzoCGE4w/s1600/Emulator8Install.PNG"><img src=":-emulator8install.png" border="0" alt="" width="640" height="468"></a></span></p>
<p class="separator"><span style="font-size:small">Press 'Next' button and it will again ask you about 'Windows Kits Privacy' choose 'Yes' and Click on 'Next' button. After that you need to accept 'License Agreement'. So finally you will get 'Install' option
 from below screen</span></p>
<p class="separator"><span style="font-size:small"><a href="https://3.bp.blogspot.com/-f-XWBelmdnA/Vvd9afrW2MI/AAAAAAAAChM/wOHpAk9HNgUNgvWI1V8iGa6ZQzLI99tKA/s1600/Emulator11Install.PNG"><img src=":-emulator11install.png" border="0" alt="" width="640" height="468"></a></span></p>
<p class="separator"><span style="font-size:small">Now setup will start for installation, and one more important note you must enable Hyper-V in your machine otherwise it will throw an error like below</span></p>
<p class="separator"><span style="font-size:small"><a href="https://3.bp.blogspot.com/-ukfXsbz-kHA/Vvd99PL5DoI/AAAAAAAAChU/kroibk-tNIsZ08XOeB33eepaJLulasUZQ/s1600/Emulator13InstallHyperV.PNG"><img src=":-emulator13installhyperv.png" border="0" alt="" width="640" height="468"></a></span></p>
<p class="separator"><span style="font-size:small">If you have already enabled Hyper-V machine, setup file will be smoothly install on your machine and you will get success installation message.</span></p>
<p class="separator"><span style="font-size:small">Wow!!! now every thing is configured for your Windows 10 development, and you can start to build nice Windows 10 Universal Windows Platform(UWP) apps.</span></p>
<p class="separator"><span style="font-size:small">I added sample source code of Windows 10 UWP app and you can get source code from the download option of this artilce.</span></p>
<p class="separator"><span style="font-size:small"><span>All the very best :)</span><br>
</span></p>
<p class="separator"><span style="font-size:small"><strong>Help me with feedback:</strong></span></p>
<p class="separator"><span style="font-size:small"><strong>&nbsp;</strong>Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with&nbsp;<img id="67168" src="67168-ratings.png" alt="" width="74" height="15">&nbsp;star
 rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice).&nbsp;</span></p>
<h2>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><span style="color:#000000">Follow me always at&nbsp;&nbsp;</span><a class="account-group x_x_x_js-account-group x_x_x_js-action-profile x_x_x_js-user-profile-link x_x_x_js-nav" href="https://twitter.com/Subramanyam_B"><span class="username js-action-profile-name" style="color:#8899a6"><span style="color:#b1bbc3">@</span>Subramanyam_B</span>&nbsp;</a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Have a nice day by<span style="color:#000000">&nbsp;</span><a href="http://bsubramanyamraju.blogspot.in/p/about-me.html">Subramanyam Raju</a><span style="color:#000000">&nbsp;:)</span></span></p>
</h2>
</span></div>
