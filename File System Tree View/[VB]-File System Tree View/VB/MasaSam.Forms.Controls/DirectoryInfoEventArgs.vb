Imports System.IO

Public NotInheritable Class DirectoryInfoEventArgs
    Inherits EventArgs

    Private m_directory As DirectoryInfo

    Public Sub New(ByVal directory As DirectoryInfo)
        Me.m_directory = directory
    End Sub

    Public ReadOnly Property Directory As DirectoryInfo
        Get
            Return Me.m_directory
        End Get
    End Property

End Class
