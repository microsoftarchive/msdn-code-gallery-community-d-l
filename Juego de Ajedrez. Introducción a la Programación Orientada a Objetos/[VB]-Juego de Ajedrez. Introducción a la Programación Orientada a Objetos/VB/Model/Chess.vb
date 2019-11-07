''' <summary>
''' Colores de los jugadores
''' </summary>
Enum PlayerColor
    White
    Black
End Enum

''' <summary>
''' Posibles estados que puede tomar el juego
''' </summary>
Enum GameState
    PendingForWhiteMove
    PendingForBlackMove
    WhitePlayerMoving
    BlackPlayerMoving
    WhitePlayerWin
    BlackPlayerWin
End Enum

''' <summary>
''' Estructura que define un movimiento
''' </summary>
Structure Movement
    ''' <summary>
    ''' Número de posiciones a avanzar hacia adelante
    ''' Si se mueve hacia atrás el valor será negativo
    ''' El movimiento se realizará hacia arriba o haciaa abajo en función
    ''' del color de la pieza a la que se aplica
    ''' </summary>
    Public Forward As Integer
    ''' <summary>
    ''' Número de posiciones a mover hacia la derecha
    ''' Si el movimiento es hacia la izquierda el valor será negativo
    ''' </summary>
    Public ToRight As Integer
End Structure

''' <summary>
''' Representa el juego, manteniendo el estado en el que se encuentra
''' </summary>
Class Game

    Public Sub New()
        _board = New Chessboard()
    End Sub

    Private _board As Chessboard
    ''' <summary>
    ''' Tablero de juego
    ''' </summary>
    Public Property Board() As Chessboard
        Get
            Return _board
        End Get
        Private Set(ByVal value As Chessboard)
            _board = value
        End Set
    End Property

    Private _state As GameState
    ''' <summary>
    ''' Estado en el que se encuentra el juego
    ''' Cuando se asigna un nuevo estado se lanza el evento <see cref="StateChanged"/>
    ''' </summary>
    Public Property State() As GameState
        Get
            Return _state
        End Get
        Private Set(ByVal value As GameState)
            _state = value
            OnStateChanged(New EventArgs())
        End Set
    End Property

    Private _selectedSquare As Square
    ''' <summary>
    ''' Devuelve la celda seleccionada por el usuario
    ''' </summary>
    Public Property SelectedSquare() As Square
        Get
            Return _selectedSquare
        End Get
        Private Set(ByVal value As Square)
            _selectedSquare = value
        End Set
    End Property

    ''' <summary>
    ''' Inicia un nuevo juego disponiendo las piezas del color indicado
    ''' en la parte superior del tablero
    ''' </summary>
    ''' <param name="playerOnTop">Color de las piezas de la parte superior del tablero</param>
    Public Sub Start(playerOnTop As PlayerColor)
        Board.Init(playerOnTop)
        ' Se establece el estado a través de la variable privada para que no se genere
        ' el evento StateChanged ya que lo lanzamos manualmente
        _state = GameState.PendingForWhiteMove
        OnStateChanged(New EventArgs())
    End Sub

    ''' <summary>
    ''' Devuelve las celdas que pueden ser seleccionadas: las celdas con piezas del color del jugador
    ''' cuando el juego está pendiente de que éste inicie el movimiento
    ''' </summary>
    ''' <returns>Las celdas que pueden ser seleccionadas</returns>
    Public Function GetSquaresThatCanBeSelected() As IEnumerable(Of Square)
        If State <> GameState.PendingForWhiteMove AndAlso State <> GameState.PendingForBlackMove Then
            Return Nothing
        End If

        Return Board.Where(Function(s) s.Piece IsNot Nothing _
            AndAlso s.Piece.Color = IIf(State = GameState.PendingForWhiteMove, PlayerColor.White, PlayerColor.Black))
    End Function

    ''' <summary>
    ''' Selecciona la celda indicada como celda inicio del movimiento
    ''' </summary>
    ''' <param name="squareToSelect">Celda a seleccionar</param>
    ''' <returns>true o false indicando si se ha realizado la selección
    ''' El juego debe estar pendiente de iniciar un movimiento y la celda ser una de
    ''' las celdas seleccionables</returns>
    Public Function SelectPiece(squareToSelect As Square) As Boolean
        If squareToSelect Is Nothing OrElse squareToSelect.Piece Is Nothing Then Return False

        If State = GameState.PendingForWhiteMove AndAlso squareToSelect.Piece.Color = PlayerColor.White _
            OrElse State = GameState.PendingForBlackMove AndAlso squareToSelect.Piece.Color = PlayerColor.Black Then
            SelectedSquare = squareToSelect
            State = IIf(State = GameState.PendingForWhiteMove, GameState.WhitePlayerMoving, GameState.BlackPlayerMoving)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Deselecciona la celda actualmente seleccionada
    ''' </summary>
    ''' <returns>true o false indicando si se ha realizado la deselección
    ''' Para que exista celda seleccionada el juego debe estar pediente de finalizar movimiento</returns>
    Public Function UnselectPiece() As Boolean
        If State = GameState.WhitePlayerMoving OrElse State = GameState.BlackPlayerMoving Then
            SelectedSquare = Nothing
            State = IIf(State = GameState.WhitePlayerMoving,
                GameState.PendingForWhiteMove, GameState.PendingForBlackMove)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Devuelve las celdas que pueden ser destino del movimiento en función
    ''' de la celda actualmente seleccionada.
    ''' Los posibles destinos dependen de la pieza contenida en la celda seleccionada.
    ''' </summary>
    ''' <returns>Las celdas que pueden ser destino del movimiento</returns>
    Public Function PosibleDestinationSquares() As IEnumerable(Of Square)
        If SelectedSquare Is Nothing Then Return Nothing

        Return SelectedSquare.Piece.GetDestinationSquares()
    End Function

    ''' <summary>
    ''' Ejecuta el movimiento desde la celda seleccionada a la 
    ''' celda indicada
    ''' </summary>
    ''' <param name="squareToMove">Celda destino del movimiento</param>
    ''' <returns>true o false en función de si se ha podido realizar
    ''' el movimiento</returns>
    Public Function MoveToSquare(squareToMove As Square) As Boolean
        If SelectedSquare Is Nothing Then Return False

        If Board.Move(SelectedSquare, squareToMove) Then
            SelectedSquare = Nothing
            ' Una vez realizado el movimiento se comprueba si ha finalizado
            ' (si hay ganador)
            If Not CheckForWin() Then
                State = IIf(State = GameState.WhitePlayerMoving _
                          , GameState.PendingForBlackMove, GameState.PendingForWhiteMove)
            End If
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Se produce cuando cambia el estado del juego
    ''' </summary>
    Public Event StateChanged As EventHandler

    ''' <summary>
    ''' Genera el evento StateChanged
    ''' </summary>
    Protected Overridable Sub OnStateChanged(e As EventArgs)
        RaiseEvent StateChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Comprueba si el juego ha finalizado (si existe ganador)
    ''' </summary>
    ''' <returns>true o false indicando si el juego ha finalizado</returns>
    Private Function CheckForWin() As Boolean
        ' Si únicamente queda un rey el juego ha terminado
        Dim kings As IEnumerable(Of ChessPiece) = Board.Select(Function(s) s.Piece) _
            .Where(Function(p) p IsNot Nothing AndAlso TypeOf p Is King)
        If kings.Count() = 1 Then
            State = IIf(kings.First().Color = PlayerColor.White _
                      , GameState.WhitePlayerWin, GameState.BlackPlayerWin)
            Return True
        Else
            Return False
        End If
    End Function

End Class