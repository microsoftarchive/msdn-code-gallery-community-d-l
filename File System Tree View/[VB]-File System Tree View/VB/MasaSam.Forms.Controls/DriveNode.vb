Imports System.IO

Friend Class DriveNode
    Inherits DirectoryTreeNode

    Private m_drive As DriveInfo
    Private Const DriveImageKey As String = "drive.png"
    Private Const DriveRemovableImgeKey As String = "drive_cd.png"
    Private Const DriveNetworkImageKey As String = "drive_network.png"
    Private Const DriveOtherImageKey As String = "drive_cd_empty.png"

    Public Sub New(ByVal drive As DriveInfo)
        MyBase.New(FileSystemNodeType.Drive, drive.Name)
        Me.m_drive = drive
        Me.SetDriveImage()
    End Sub

    Public ReadOnly Property Drive As DriveInfo
        Get
            Return Me.m_drive
        End Get
    End Property

    Private Sub SetDriveImage()
        Select Case Drive.DriveType
            Case DriveType.Network
                Me.ImageKey = DriveNetworkImageKey
                Me.SelectedImageKey = DriveNetworkImageKey
            Case DriveType.CDRom Or DriveType.Removable
                Me.ImageKey = DriveRemovableImgeKey
                Me.SelectedImageKey = DriveRemovableImgeKey
            Case DriveType.Fixed
                Me.ImageKey = DriveImageKey
                Me.SelectedImageKey = DriveImageKey
            Case Else
                Me.ImageKey = DriveOtherImageKey
                Me.SelectedImageKey = DriveOtherImageKey
        End Select
    End Sub

End Class
