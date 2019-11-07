''' <summary>
''' Formulario con el tablero de juego
''' </summary>
Public Class ChessGameForm

    Private _game As New Game()
    Private _squares As New List(Of SquareControl)

    Private Sub ChessGameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creamos los controles para las celdas del tablero
        For Each square As Square In _game.Board
            Dim control As New SquareControl()
            control.BoardSquare = square
            _squares.Add(control)
            AddHandler control.CheckedChanged, AddressOf Square_CheckedChanged
        Next
        panelBoard.Controls.AddRange(_squares.ToArray())
        ' Controlador para el evento de cambio de estado del juego
        AddHandler _game.StateChanged, AddressOf Game_StateChanged
        ' Inicia el juego colocando en la parte superior el color seleccionado
        _game.Start(IIf(radioBlack.Checked, PlayerColor.Black, PlayerColor.White))
    End Sub

    ''' <summary>
    ''' Método que controla la pulsación de una celda por parte del usuario
    ''' </summary>
    Private Sub Square_CheckedChanged(sender As Object, e As EventArgs)
        Dim square As SquareControl = sender
        If square.Checked Then
            If _game.State = GameState.PendingForWhiteMove OrElse _game.State = GameState.PendingForBlackMove Then
                ' Si el juego está pendiente de iniciar movimiento se selecciona la celda pulsada
                _game.SelectPiece(square.BoardSquare)
            ElseIf _game.State = GameState.WhitePlayerMoving OrElse _game.State = GameState.BlackPlayerMoving Then
                ' Si el juego está pendiente de finalizar movimiento se ejecuta el movimiento correspondiente
                ' y se deseleccionan las celdas del movimiento
                If _game.MoveToSquare(square.BoardSquare) Then
                    square.Checked = False
                    _squares.First(Function(s) s.Checked).Checked = False
                End If
            End If
        Else
            ' Si el juego está pendiente de completar el movimiento se deselecciona la celda
            If _game.State = GameState.WhitePlayerMoving OrElse _game.State = GameState.BlackPlayerMoving Then
                _game.UnselectPiece()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Controlador para el evento de cambio de estado del juego
    ''' </summary>
    Private Sub Game_StateChanged(sender As Object, e As EventArgs)
        Select Case _game.State
            Case GameState.PendingForWhiteMove, GameState.PendingForBlackMove
                ' Si el juego está pendiente de inciar movimiento habilitamos las celdas
                ' seleccionables (las que tienen piezas del color del jugador)
                Dim selectionableSquares As IEnumerable(Of Square) = _game.GetSquaresThatCanBeSelected()
                For Each square As SquareControl In _squares
                    square.Enabled = selectionableSquares.Contains(square.BoardSquare)
                    square.FlatAppearance.BorderSize = 0
                Next
            Case GameState.WhitePlayerMoving, GameState.BlackPlayerMoving
                ' Si el juego está pendiente de finalizar el movimiento habilitamos:
                ' - las celdas posible destino del movimiento
                ' - la celda inicio del movimiento para dar la posibilidad de deseleccionarla
                ' También establecemos un borde en las celdas destino para marcárselas al usuario
                Dim destinationSquares As IEnumerable(Of Square) = _game.PosibleDestinationSquares()
                For Each square As SquareControl In _squares
                    square.Enabled = destinationSquares.Contains(square.BoardSquare) _
                        OrElse square.BoardSquare Is _game.SelectedSquare
                    If square.Enabled Then
                        square.FlatAppearance.BorderSize = 1
                    End If
                Next
            Case GameState.WhitePlayerWin, GameState.BlackPlayerWin
                ' Si ha finalizado el juego deshabilitamos todas las celdas
                For Each square As SquareControl In _squares
                    square.Enabled = False
                    square.FlatAppearance.BorderSize = 0
                Next
                ' Mostramos el Label con el ganador
                lblWin.Text = String.Format("{0} Ganan",
                        IIf(_game.State = GameState.WhitePlayerWin, "Blancas", "Negras"))
                lblWin.Visible = True

        End Select
    End Sub

    ''' <summary>
    ''' Al redimensionar el formulario se redimensiona el panel del tablero
    ''' </summary>
    Private Sub ChessGameForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        panelBoard.Width = Width - 180
    End Sub

    ''' <summary>
    ''' Al pulsar el botón se inicia una nueva partida colocando en la parte
    ''' superior las piezas del color seleccionado
    ''' </summary>
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        lblWin.Visible = False
        _game.Start(IIf(radioBlack.Checked, PlayerColor.Black, PlayerColor.White))
    End Sub

End Class
