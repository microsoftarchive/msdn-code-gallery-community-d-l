Imports System.IO

Friend MustInherit Class DirectoryTreeNode
    Inherits FileSystemNode

    Protected Sub New(ByVal nodeType As FileSystemNodeType)
        Me.New(nodeType, String.Empty)
    End Sub

    Protected Sub New(ByVal nodeType As FileSystemNodeType, ByVal text As String)
        MyBase.New(nodeType, text)
    End Sub

    Public ReadOnly Property DirectoryNodes As IEnumerable(Of DirectoryNode)
        Get
            Return Me.Nodes.OfType(Of DirectoryNode)()
        End Get
    End Property

    Public Function Add(ByVal directory As DirectoryInfo) As DirectoryNode
        Dim node As New DirectoryNode(directory)
        Me.Nodes.Add(node)
        Return node
    End Function

End Class
