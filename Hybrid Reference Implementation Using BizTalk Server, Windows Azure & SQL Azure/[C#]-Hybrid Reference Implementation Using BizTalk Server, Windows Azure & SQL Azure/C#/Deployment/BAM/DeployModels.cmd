@echo off
set BtsInstallPath=%ProgramFiles(x86)%\Microsoft BizTalk Server 2010
set BAMPath=%BtsInstallPath%\Tracking
set ActivitiesPath=.

"%BAMPath%"\bm.exe remove-all -DefinitionFile:"%ActivitiesPath%\InventoryDataTrackingActivity.xml"
"%BAMPath%"\bm.exe deploy-all -DefinitionFile:"%ActivitiesPath%\InventoryDataTrackingActivity.xml"
