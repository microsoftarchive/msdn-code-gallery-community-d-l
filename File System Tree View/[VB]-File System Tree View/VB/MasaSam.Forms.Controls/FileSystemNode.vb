Imports System.Windows.Forms

''' <summary>
''' Class that represents file system tree node.
''' </summary>
Friend MustInherit Class FileSystemNode
    Inherits TreeNode

    Private m_nodeType As FileSystemNodeType

    ''' <summary>
    ''' Initializes new instance of <see cref="FileSystemNode"/> class.
    ''' </summary>
    ''' <param name="nodeType">A <see cref="FileSystemNodeType"/> of the node.</param>
    Protected Sub New(ByVal nodeType As FileSystemNodeType)
        Me.New(nodeType, String.Empty)
    End Sub

    ''' <summary>
    ''' Initializes new instance of <see cref="FileSystemNode"/> class.
    ''' </summary>
    ''' <param name="nodeType">A <see cref="FileSystemNodeType"/> of the node.</param>
    ''' <param name="text">A text of the node.</param>
    Protected Sub New(ByVal nodeType As FileSystemNodeType, ByVal text As String)
        MyBase.New(text)
        Me.m_nodeType = nodeType
    End Sub

    ''' <summary>
    ''' Gets the <see cref="FileSystemNodeType"/> of the node.
    ''' </summary>
    Public ReadOnly Property NodeType As FileSystemNodeType
        Get
            Return Me.m_nodeType
        End Get
    End Property

    Public Overridable ReadOnly Property FullName As String
        Get
            Return Me.Text
        End Get
    End Property

End Class
