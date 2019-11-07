Imports System.IO

Friend Class ComputerNode
    Inherits FileSystemNode

    Private Const ComputerKeyValue As String = "computer.png"

    Public Sub New()
        Me.New("My Computer")
    End Sub

    Public Sub New(ByVal text As String)
        MyBase.New(FileSystemNodeType.Computer, text)
        Me.ImageKey = ComputerKeyValue
        Me.SelectedImageKey = ComputerKeyValue
    End Sub

    Public Function Add(ByVal drive As DriveInfo) As DriveNode
        Dim node As New DriveNode(drive)
        Me.Nodes.Add(node)
        Return node
    End Function

End Class
