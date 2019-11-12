Imports System
Imports System.Management
Imports System.Windows.Forms
Imports System.Text

Public Class Form1



    Private Sub cmbHardwareCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHardwareCom.SelectedIndexChanged
        If cmbHardwareCom.SelectedIndex = 0 Then
            SetPhysicalMemoryinfo()
        Else
            SetCacheMemoryInfo()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbHardwareCom.Items.Add("PhysicalMemory")
        cmbHardwareCom.Items.Add("CacheMemory")
    End Sub
    Private Sub SetPhysicalMemoryinfo()
        Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PhysicalMemory")
        Dim index As Integer = 0
        Dim str As New StringBuilder

        For Each queryObj As ManagementObject In searcher.Get()
            On Error Resume Next
        
            str.Append("BankLabel: " & queryObj("BankLabel") & vbCrLf)
            str.Append("Capacity: " & queryObj("Capacity") & vbCrLf)
            str.Append("Caption: " & queryObj("Caption") & vbCrLf)
            str.Append("CreationClassName: " & queryObj("CreationClassName") & vbCrLf)
            str.Append("DataWidth: " & queryObj("DataWidth") & vbCrLf)
            str.Append("Description: " & queryObj("Description") & vbCrLf)
            str.Append("DeviceLocator: " & queryObj("DeviceLocator") & vbCrLf)
            str.Append("FormFactor: " & queryObj("FormFactor") & vbCrLf)
            str.Append("HotSwappable: " & queryObj("HotSwappable") & vbCrLf)
            str.Append("InstallDate: " & queryObj("InstallDate") & vbCrLf)
            str.Append("InterleaveDataDepth: " & queryObj("InterleaveDataDepth") & vbCrLf)
            str.Append("InterleavePosition: " & queryObj("InterleavePosition") & vbCrLf)
            str.Append("Manufacturer: " & queryObj("Manufacturer") & vbCrLf)
            str.Append("MemoryType: " & queryObj("MemoryType") & vbCrLf)
            str.Append("Model: " & queryObj("Model") & vbCrLf)
            str.Append("Name: " & queryObj("Name") & vbCrLf)
            str.Append("OtherIdentifyingInfo: " & queryObj("OtherIdentifyingInfo") & vbCrLf)
            str.Append("PartNumber: " & queryObj("PartNumber") & vbCrLf)
            str.Append("PositionInRow: " & queryObj("PositionInRow") & vbCrLf)
            str.Append("PoweredOn: " & queryObj("PoweredOn") & vbCrLf)
            str.Append("Removable: " & queryObj("Removable") & vbCrLf)
            str.Append("Replaceable: " & queryObj("Replaceable") & vbCrLf)
            str.Append("SerialNumber: " & queryObj("SerialNumber") & vbCrLf)
            str.Append("SKU: " & queryObj("SKU") & vbCrLf)
            str.Append("Speed: " & queryObj("Speed") & vbCrLf)
            str.Append("Status: " & queryObj("Status") & vbCrLf)
            str.Append("Tag: " & queryObj("Tag") & vbCrLf)
            str.Append("TotalWidth: " & queryObj("TotalWidth") & vbCrLf)
            str.Append("TypeDetail: " & queryObj("TypeDetail") & vbCrLf)
            str.Append("Version: " & queryObj("Version") & vbCrLf)
            str.Append("------------------------------------")

        Next
        TextBox1.Text = str.ToString()
    End Sub
    Private Sub SetCacheMemoryInfo()
        Dim searcher As New ManagementObjectSearcher( _
                    "root\CIMV2", _
                    "SELECT * FROM Win32_CacheMemory")

        Dim index As Integer = 0
        Dim str As New StringBuilder

        For Each queryObj As ManagementObject In searcher.Get()
            On Error Resume Next
            str.Append("Access: " & queryObj("Access") & vbCrLf)
            str.Append("Associativity: " & queryObj("Associativity") & vbCrLf)
            str.Append("Availability: " & queryObj("Availability") & vbCrLf)
            str.Append("BlockSize: " & queryObj("BlockSize") & vbCrLf)
            str.Append("CacheSpeed: " & queryObj("CacheSpeed") & vbCrLf)
            str.Append("CacheType: " & queryObj("CacheType") & vbCrLf)
            str.Append("Caption: " & queryObj("Caption") & vbCrLf)
            str.Append("ConfigManagerErrorCode: " & queryObj("ConfigManagerErrorCode") & vbCrLf)
            str.Append("ConfigManagerUserConfig: " & queryObj("ConfigManagerUserConfig") & vbCrLf)
            str.Append("CorrectableError: " & queryObj("CorrectableError") & vbCrLf)
            str.Append("CreationClassName: " & queryObj("CreationClassName") & vbCrLf)
            str.Append("Description: " & queryObj("Description") & vbCrLf)
            str.Append("DeviceID: " & queryObj("DeviceID") & vbCrLf)
            str.Append("EndingAddress: " & queryObj("EndingAddress") & vbCrLf)
            str.Append("FlushTimer: " & queryObj("FlushTimer") & vbCrLf)
            str.Append("InstallDate: " & queryObj("InstallDate") & vbCrLf)
            str.Append("InstalledSize: " & queryObj("InstalledSize") & vbCrLf)
            str.Append("LastErrorCode: " & queryObj("LastErrorCode") & vbCrLf)
            str.Append("Level: " & queryObj("Level") & vbCrLf)
            str.Append("LineSize: " & queryObj("LineSize") & vbCrLf)
            str.Append("Location: " & queryObj("Location") & vbCrLf)
            str.Append("MaxCacheSize: " & queryObj("MaxCacheSize") & vbCrLf)
            str.Append("Name: " & queryObj("Name") & vbCrLf)
            str.Append("NumberOfBlocks: " & queryObj("NumberOfBlocks") & vbCrLf)
            str.Append("OtherErrorDescription: " & queryObj("OtherErrorDescription") & vbCrLf)
            str.Append("PNPDeviceID: " & queryObj("PNPDeviceID") & vbCrLf)
            str.Append("PowerManagementSupported: " & queryObj("PowerManagementSupported") & vbCrLf)
            str.Append("Purpose: " & queryObj("Purpose") & vbCrLf)
            str.Append("ReadPolicy: " & queryObj("ReadPolicy") & vbCrLf)
            str.Append("ReplacementPolicy: " & queryObj("ReplacementPolicy") & vbCrLf)
            str.Append("StartingAddress: " & queryObj("StartingAddress") & vbCrLf)
            str.Append("Status: " & queryObj("Status") & vbCrLf)
            str.Append("StatusInfo: " & queryObj("StatusInfo") & vbCrLf)
            str.Append("SystemCreationClassName: " & queryObj("SystemCreationClassName") & vbCrLf)
            str.Append("SystemLevelAddress: " & queryObj("SystemLevelAddress") & vbCrLf)
            str.Append("SystemName: " & queryObj("SystemName") & vbCrLf)
            str.Append("WritePolicy: " & queryObj("WritePolicy") & vbCrLf)
            str.Append("------------------------------------")
        Next
        TextBox1.Text = str.ToString()
    End Sub
  
End Class
