Public Class xC

    Private _X As Integer
    Private _Width As Integer

    Public Sub New()

    End Sub

    Public Sub New(x As Integer, w As Integer)
        Me.X = x
        Me.Width = w
    End Sub

    Public Property X As Integer
        Get
            Return _X
        End Get
        Set(value As Integer)
            _X = value
        End Set
    End Property

    Public Property Width As Integer
        Get
            Return _Width
        End Get
        Set(value As Integer)
            _Width = value
        End Set
    End Property

End Class
