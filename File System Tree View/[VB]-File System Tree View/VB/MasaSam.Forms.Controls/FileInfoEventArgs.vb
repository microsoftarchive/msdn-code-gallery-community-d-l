Imports System.IO

Public NotInheritable Class FileInfoEventArgs
    Inherits EventArgs

    Private m_file As FileInfo

    Public Sub New(ByVal file As FileInfo)
        Me.m_file = file
    End Sub

    Public ReadOnly Property File As FileInfo
        Get
            Return Me.m_file
        End Get
    End Property

End Class
