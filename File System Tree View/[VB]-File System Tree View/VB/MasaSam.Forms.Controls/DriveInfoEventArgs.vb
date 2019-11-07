Imports System.IO

Public NotInheritable Class DriveInfoEventArgs
    Inherits EventArgs

    Private m_drive As DriveInfo

    Public Sub New(ByVal drive As DriveInfo)
        Me.m_drive = drive
    End Sub

    Public ReadOnly Property Drive As DriveInfo
        Get
            Return Me.m_drive
        End Get
    End Property

End Class
