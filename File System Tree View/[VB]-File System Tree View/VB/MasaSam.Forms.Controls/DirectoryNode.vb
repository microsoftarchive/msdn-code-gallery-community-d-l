Imports System.IO

Friend Class DirectoryNode
    Inherits DirectoryTreeNode

    Private m_directory As DirectoryInfo

    Private Const FolderKeyValue As String = "folder.png"

    Public Sub New(ByVal directory As DirectoryInfo)
        MyBase.New(FileSystemNodeType.Directory, directory.Name)
        Me.m_directory = directory
        Me.ToolTipText = Me.m_directory.FullName
        Me.ImageKey = FolderKeyValue
        Me.SelectedImageKey = FolderKeyValue
    End Sub

    Public ReadOnly Property Directory As DirectoryInfo
        Get
            Return Me.m_directory
        End Get
    End Property

    Public ReadOnly Property FileNodes As IEnumerable(Of FileNode)
        Get
            Return Me.Nodes.OfType(Of FileNode)()
        End Get
    End Property

    Public Overloads Function Add(ByVal file As FileInfo) As FileNode
        Dim node As New FileNode(file)
        Me.Nodes.Add(node)
        Return node
    End Function

    Public Overrides ReadOnly Property FullName As String
        Get
            Return m_directory.FullName
        End Get
    End Property

End Class
