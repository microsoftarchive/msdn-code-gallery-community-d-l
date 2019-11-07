''' <summary>
''' Tablero de juego de ajedrez
''' </summary>
Class Chessboard
    Inherits List(Of Square)

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="Chessboard"/>
    ''' </summary>
    Public Sub New()
        For row = 0 To 7
            For column = 0 To 7
                Add(New Square(Me, row, column))
            Next
        Next
        PlayerOnTop = PlayerColor.White
    End Sub

    ''' <summary>
    ''' Establece o devuelve el color del jugador cuyas piezas se posicionan
    ''' en la parte superior del tablero
    ''' </summary>
    Property PlayerOnTop As PlayerColor

    ''' <summary>
    ''' Devuelve la celda ubicada en la fila y columna especificadas
    ''' </summary>
    ''' <param name="row">Fila</param>
    ''' <param name="column">Columna</param>
    ''' <returns>Objeto Square de la fila y columna</returns>
    Public Function GetSquare(row As Integer, column As Integer) As Square
        Return Me.FirstOrDefault(Function(s) s.Row = row AndAlso s.Column = column)
    End Function

    ''' <summary>
    ''' Devuelve la fila destino de la pieza después de aplicar un desplazamiento a partir de 
    ''' una celda origen
    ''' </summary>
    ''' <param name="fromSquare">Celda origen</param>
    ''' <param name="move">Movimiento a realizar a partir de la celda origen</param>
    ''' <returns>Objeto Square destino del movimiento</returns>
    Public Function GetSquare(fromSquare As Square, move As Movement) As Square
        Dim piece As ChessPiece = fromSquare.Piece
        If piece Is Nothing Then Return Nothing

        Return GetSquare(fromSquare.Row _
                         + IIf(piece.Color = PlayerOnTop, move.Forward, -move.Forward) _
                         , fromSquare.Column + move.ToRight)
    End Function

    ''' <summary>
    ''' Inicializa el tablero de juego colocando las piezas en su posición inicial
    ''' </summary>
    Public Sub Init()
        ClearPieces()

        Dim bottomColor As PlayerColor =
            IIf(PlayerOnTop = PlayerColor.White, PlayerColor.Black, PlayerColor.White)
        ' Kings
        Dim column As Integer = IIf(PlayerOnTop = PlayerColor.White, 4, 3)
        GetSquare(0, column).Piece = New King(PlayerOnTop)
        GetSquare(7, column).Piece = New King(bottomColor)
        ' Queens
        column = IIf(column = 4, 3, 4)
        GetSquare(0, column).Piece = New Queen(PlayerOnTop)
        GetSquare(7, column).Piece = New Queen(bottomColor)
        ' Rooks
        GetSquare(0, 0).Piece = New Rook(PlayerOnTop)
        GetSquare(0, 7).Piece = New Rook(PlayerOnTop)
        GetSquare(7, 0).Piece = New Rook(bottomColor)
        GetSquare(7, 7).Piece = New Rook(bottomColor)
        ' Knights
        GetSquare(0, 1).Piece = New Knight(PlayerOnTop)
        GetSquare(0, 6).Piece = New Knight(PlayerOnTop)
        GetSquare(7, 1).Piece = New Knight(bottomColor)
        GetSquare(7, 6).Piece = New Knight(bottomColor)
        ' Bishops
        GetSquare(0, 2).Piece = New Bishop(PlayerOnTop)
        GetSquare(0, 5).Piece = New Bishop(PlayerOnTop)
        GetSquare(7, 2).Piece = New Bishop(bottomColor)
        GetSquare(7, 5).Piece = New Bishop(bottomColor)
        ' Pawns
        For i = 0 To 7
            GetSquare(1, i).Piece = New Pawn(PlayerOnTop)
            GetSquare(6, i).Piece = New Pawn(bottomColor)
        Next
    End Sub

    ''' <summary>
    ''' Inicializa el tablero de juego colocando las piezas en su posición inicial
    ''' </summary>
    ''' <param name="colorOfTopPlayer">Color de las piezas a colocar en la parte
    ''' superior del tablero</param>
    Public Sub Init(colorOfTopPlayer As PlayerColor)
        PlayerOnTop = colorOfTopPlayer
        Init()
    End Sub

    ''' <summary>
    ''' Mueve una pieza de una celda a otra
    ''' </summary>
    ''' <param name="fromSquare">Celda desde la que se realiza el movimiento</param>
    ''' <param name="toSquare">Celda destino del movimiento</param>
    ''' <returns>true o false indicando si el movimiento se ha realizado</returns>
    Public Function Move(fromSquare As Square, toSquare As Square) As Boolean
        If fromSquare IsNot Nothing AndAlso toSquare IsNot Nothing _
            AndAlso fromSquare.Piece IsNot Nothing Then
            toSquare.Piece = fromSquare.Piece
            fromSquare.Piece = Nothing
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Elimmina todas las piezas del tablero
    ''' </summary>
    Private Sub ClearPieces()
        For Each item As Square In Me
            item.Piece = Nothing
        Next
    End Sub

End Class

''' <summary>
''' Celda del tablero de ajedrez
''' </summary>
Class Square

    ''' <summary>
    ''' Inicializa una nueva instancia de <see cref="Square"/>
    ''' </summary>
    ''' <param name="squareBoard">Referencia al tablero al que pertenece la celda</param>
    ''' <param name="squareRow">Fila (índice basado en 0)</param>
    ''' <param name="squareColumn">Columna (índice basado en 0)</param>
    Public Sub New(squareBoard As Chessboard, squareRow As Integer, squareColumn As Integer)
        Board = squareBoard
        Row = squareRow
        Column = squareColumn
    End Sub

    ''' <summary>
    ''' Tablero al que pertenece la celda
    ''' </summary>
    Property Board As Chessboard

    ''' <summary>
    ''' Fila (índice basado en 0)
    ''' </summary>
    Property Row As Integer

    ''' <summary>
    ''' Columna (índice basado en 0)
    ''' </summary>
    Property Column As Integer

    Private _piece As ChessPiece
    ''' <summary>
    ''' Devuelve o establece la pieza que se encuentra en la celda
    ''' </summary>
    Public Property Piece() As ChessPiece
        Get
            Return _piece
        End Get
        Set(ByVal value As ChessPiece)
            Dim changed As Boolean = _piece IsNot value
            _piece = value
            If _piece IsNot Nothing Then
                _piece.BoardSquare = Me
            End If
            If changed Then OnPieceChanged(New EventArgs())
        End Set
    End Property

    ''' <summary>
    ''' Se produce cuando cambia la pieza de la celda
    ''' </summary>
    Public Event PieceChanged As EventHandler

    ''' <summary>
    ''' Genera el evento PieceChanged
    ''' </summary>
    Protected Overridable Sub OnPieceChanged(e As EventArgs)
        RaiseEvent PieceChanged(Me, e)
    End Sub

End Class