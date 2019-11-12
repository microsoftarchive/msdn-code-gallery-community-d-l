Public Class yC

    Private _Y As Integer
    Private _Height As Integer

    Public Sub New(y As Integer, h As Integer)
        Me.Y = y
        Me.Height = h
    End Sub

    Public Property Y As Integer
        Get
            Return _Y
        End Get
        Set(value As Integer)
            _Y = value
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return _Height
        End Get
        Set(value As Integer)
            _Height = value
        End Set
    End Property

End Class
