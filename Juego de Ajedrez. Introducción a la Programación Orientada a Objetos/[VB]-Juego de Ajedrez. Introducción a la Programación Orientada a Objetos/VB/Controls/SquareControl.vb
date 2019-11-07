''' <summary>
''' Define un control para  las celdas del tablero de ajedrez
''' </summary>
Class SquareControl
    Inherits CheckBox

    ' Colores de fondo de las celdas
    Private DarkColor As Color = Color.DarkBlue
    Private LightColor As Color = Color.LightBlue

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="SquareControl"/>
    ''' </summary>
    Public Sub New()
        FlatStyle = FlatStyle.Flat
        Appearance = Appearance.Button
        BackgroundImageLayout = ImageLayout.Zoom
        FlatAppearance.BorderColor = Color.Red
        FlatAppearance.BorderSize = 0
    End Sub

    Private _boardSquare As Square
    Public Property BoardSquare() As Square
        Get
            Return _boardSquare
        End Get
        Set(ByVal value As Square)
            If _boardSquare IsNot value Then
                If _boardSquare IsNot Nothing Then
                    RemoveHandler _boardSquare.PieceChanged, AddressOf BoardSquare_PieceChanged
                End If
                _boardSquare = value
                SetSizeAndLocation()
                SetBackColor()
                SetImage()
                AddHandler _boardSquare.PieceChanged, AddressOf BoardSquare_PieceChanged
            End If
        End Set
    End Property

    ''' <summary>
    ''' Actualiza la imagen del control cuando cambia la pieza de la celda
    ''' </summary>
    Private Sub BoardSquare_PieceChanged(sender As Object, e As EventArgs)
        SetImage()
    End Sub

    Private _previousParent As Control
    ''' <summary>
    ''' Recalcula el tamaño y la posición del control cuando cambia
    ''' el control padre
    ''' </summary>
    Protected Overrides Sub OnParentChanged(e As EventArgs)
        MyBase.OnParentChanged(e)
        SetSizeAndLocation()
        If _previousParent IsNot Nothing Then
            RemoveHandler _previousParent.Resize, AddressOf Parent_Resize
        End If
        AddHandler Parent.Resize, AddressOf Parent_Resize
        _previousParent = Parent
    End Sub

    ''' <summary>
    ''' Recalcula el tamaño y la posición del control cuando el control
    ''' padre cambia de tamaño
    ''' </summary>
    Private Sub Parent_Resize(sender As Object, e As EventArgs)
        SetSizeAndLocation()
    End Sub

    ''' <summary>
    ''' Establece el tamaño y la posición del control en función del tamaño
    ''' del control padre y de la fila y columna de la celda que representa
    ''' </summary>
    Private Sub SetSizeAndLocation()
        If Parent IsNot Nothing Then
            Dim squareSize As Integer = IIf(Parent.Width > Parent.Height _
                    , Math.Floor(Parent.Height / 8), Math.Floor(Parent.Width / 8))
            Size = New Size(squareSize, squareSize)
            If _boardSquare IsNot Nothing Then
                Location = New Point(_boardSquare.Column * squareSize, _boardSquare.Row * squareSize)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Establece el color de fondo de la celda
    ''' </summary>
    Private Sub SetBackColor()
        If _boardSquare Is Nothing Then Return
        BackColor = IIf((_boardSquare.Row + _boardSquare.Column) Mod 2 = 0, LightColor, DarkColor)
    End Sub

    ''' <summary>
    ''' Establece la imagen a mostrar en función de la pieza posicionada en la celda
    ''' </summary>
    Private Sub SetImage()
        If _boardSquare Is Nothing OrElse _boardSquare.Piece Is Nothing Then
            BackgroundImage = Nothing
        Else
            Dim image As String = String.Format("{0}_{1}",
                    _boardSquare.Piece.GetType().Name, [Enum].GetName(GetType(PlayerColor), _boardSquare.Piece.Color))
            BackgroundImage = My.Resources.ResourceManager.GetObject(image.ToLower())
        End If
    End Sub

End Class
