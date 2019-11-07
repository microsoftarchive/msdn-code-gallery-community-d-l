Imports ChessGame
''' <summary>
''' Clase base para definir las diferentes piezas de ajedrez
''' </summary>
MustInherit Class ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de <see cref="ChessPiece"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        Color = pieceColor
    End Sub

    ''' <summary>
    ''' Color de la pieza
    ''' </summary>
    Property Color As PlayerColor

    ''' <summary>
    ''' Celda en la que se encuentra la pieza
    ''' </summary>
    Property BoardSquare As Square

    ''' <summary>
    ''' Devuelve las celdas a las que puede moverse la pieza
    ''' </summary>
    Public MustOverride Function GetDestinationSquares() As IEnumerable(Of Square)

    ''' <summary>
    ''' Comprueba si una celda puede ser destino de un movimiento de la pieza:
    ''' si está vacía o contiene una pieza de un color diferente
    ''' </summary>
    ''' <param name="destinationSquare">Celda a comprobar</param>
    ''' <returns>true o false indicando si puede ser destino del movimiento</returns>
    Public Function CanBeDestination(destinationSquare As Square) As Boolean
        If destinationSquare Is Nothing Then Return False

        Return (destinationSquare.Piece Is Nothing OrElse destinationSquare.Piece.Color <> Color)
    End Function

    ''' <summary>
    ''' Devuelve la lista de los posibles destinos de movimiento de la pieza
    ''' en una dirección determinada
    ''' La dirección a tomar viene dada por un incremento hacia adelante y
    ''' otro horizontal
    ''' </summary>
    ''' <param name="forwardIncrement">Incremento hacia adelante.
    ''' Si la dirección es hacia atrás será un valor negativo.</param>
    ''' <param name="rightIncrement">Incremento hacia la derecha.
    ''' Si la dirección es hacia la izquierda será un valor negativo.</param>
    ''' <returns>Lista de celdas posibles destinos de movimiento</returns>
    Protected Function DestinationSquaresOnOneDirection(
        forwardIncrement As Integer, rightIncrement As Integer) As IEnumerable(Of Square)

        Dim board As Chessboard = BoardSquare.Board

        Dim squares As New List(Of Square)
        Dim forward As Integer = forwardIncrement
        Dim right As Integer = rightIncrement
        Dim pieceOrEndFounded As Boolean = False

        Do While Not pieceOrEndFounded
            Dim destination As Square = board.GetSquare(BoardSquare,
                    New Movement() With {.Forward = forward, .ToRight = right})
            If CanBeDestination(destination) Then
                squares.Add(destination)
            End If
            pieceOrEndFounded = (destination Is Nothing OrElse destination.Piece IsNot Nothing)
            forward += forwardIncrement
            right += rightIncrement
        Loop
        Return squares
    End Function

    ''' <summary>
    ''' Devuelve la lista de los posibles destinos de movimiento de la pieza
    ''' a partir de una lista de movimientos
    ''' </summary>
    ''' <param name="moves">Lista de movimientos que puede realizar la pieza</param>
    ''' <returns>Lista de celdas posibles destinos</returns>
    Protected Function DestinationSquaresForMoves(
        moves As IEnumerable(Of Movement)) As IEnumerable(Of Square)

        Dim board As Chessboard = BoardSquare.Board
        Dim squares As New List(Of Square)
        For Each move As Movement In moves
            Dim destination As Square = board.GetSquare(BoardSquare, move)
            If CanBeDestination(destination) Then
                squares.Add(destination)
            End If
        Next
        Return squares
    End Function

End Class

''' <summary>
''' Rey
''' </summary>
Class King
    Inherits ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="King"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        MyBase.New(pieceColor)
    End Sub

    Private moves As Movement() = {
            New Movement() With {.Forward = 1, .ToRight = -1},
            New Movement() With {.Forward = 1, .ToRight = 0},
            New Movement() With {.Forward = 1, .ToRight = 1},
            New Movement() With {.Forward = 0, .ToRight = -1},
            New Movement() With {.Forward = 0, .ToRight = 1},
            New Movement() With {.Forward = -1, .ToRight = -1},
            New Movement() With {.Forward = -1, .ToRight = 0},
            New Movement() With {.Forward = -1, .ToRight = 1}
        }

    ''' <summary>
    ''' Devuelve las celdas a las que puede moverse la pieza
    ''' </summary>
    ''' <returns>Lista de celdas</returns>
    Public Overrides Function GetDestinationSquares() As IEnumerable(Of Square)
        If BoardSquare Is Nothing Then Return Nothing

        Return DestinationSquaresForMoves(moves)
    End Function

End Class

''' <summary>
''' Torre
''' </summary>
Class Rook
    Inherits ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="Rook"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la Pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        MyBase.New(pieceColor)
    End Sub

    ''' <summary>
    ''' Lista de celdas posibles destinos
    ''' </summary>
    ''' <returns>Lista de celdas</returns>
    Public Overrides Function GetDestinationSquares() As IEnumerable(Of Square)
        If BoardSquare Is Nothing Then Return Nothing

        Dim posibleSquares As New List(Of Square)
        ' A la izquierda
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, -1))
        ' A la derecha
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, 1))
        ' Hacia adelante
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 0))
        ' Hacia atrás
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 0))

        Return posibleSquares
    End Function
End Class

''' <summary>
''' Alfil
''' </summary>
Class Bishop
    Inherits ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de <see cref="Bishop"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        MyBase.New(pieceColor)
    End Sub

    ''' <summary>
    ''' Devuelve las celdas a las que puede moverse la pieza
    ''' </summary>
    ''' <returns>Lista de celdas</returns>
    Public Overrides Function GetDestinationSquares() As IEnumerable(Of Square)
        If BoardSquare Is Nothing Then Return Nothing

        Dim posibleSquares As New List(Of Square)
        ' Hacia adelante a la izquierda
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, -1))
        ' Hacia adelante a la derecha
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 1))
        ' Hacia atrás a la izquierda
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, -1))
        ' Hacia atrás a la derecha
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 1))

        Return posibleSquares

    End Function

End Class

''' <summary>
''' Reina
''' </summary>
Class Queen
    Inherits ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="Queen"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        MyBase.New(pieceColor)
    End Sub

    ''' <summary>
    ''' Devuelve las celdas a las que puede moverse la pieza
    ''' </summary>
    ''' <returns>Lista de celdas</returns>
    Public Overrides Function GetDestinationSquares() As IEnumerable(Of Square)
        If BoardSquare Is Nothing Then Return Nothing

        Dim posibleSquares As New List(Of Square)
        ' Hacia adelante a la izquierda
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, -1))
        ' Hacia adelante
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 0))
        ' Hacia adelante a la derecha
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 1))
        ' Hacia la izquierda
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, -1))
        ' Hacia la derecha
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, 1))
        ' Hacia atrás a la izquierda
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, -1))
        ' Hacia atrás
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 0))
        ' Hacia atrás a la derecha
        posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 1))

        Return posibleSquares

    End Function
End Class

''' <summary>
''' Caballo
''' </summary>
Class Knight
    Inherits ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="Knight"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        MyBase.New(pieceColor)
    End Sub

    ''' <summary>
    ''' Movimmientos que puede realizar el caballo
    ''' </summary>
    Private moves As Movement() = {
            New Movement() With {.Forward = 1, .ToRight = -2},
            New Movement() With {.Forward = 2, .ToRight = -1},
            New Movement() With {.Forward = 2, .ToRight = 1},
            New Movement() With {.Forward = 1, .ToRight = 2},
            New Movement() With {.Forward = -1, .ToRight = -2},
            New Movement() With {.Forward = -2, .ToRight = -1},
            New Movement() With {.Forward = -2, .ToRight = 1},
            New Movement() With {.Forward = -1, .ToRight = 2}
        }

    ''' <summary>
    ''' Devuelve las celdas a las que puede moverse la pieza
    ''' </summary>
    ''' <returns>Lista de celdas</returns>
    Public Overrides Function GetDestinationSquares() As IEnumerable(Of Square)
        If BoardSquare Is Nothing Then Return Nothing

        Return DestinationSquaresForMoves(moves)
    End Function
End Class

''' <summary>
''' Peón
''' </summary>
Class Pawn
    Inherits ChessPiece

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="Pawn"/>
    ''' </summary>
    ''' <param name="pieceColor">Color de la pieza</param>
    Public Sub New(pieceColor As PlayerColor)
        MyBase.New(pieceColor)
    End Sub

    ''' <summary>
    ''' Devuelve las celdas a las que puede moverse la pieza
    ''' </summary>
    ''' <returns>Lista de celdas</returns>
    Public Overrides Function GetDestinationSquares() As IEnumerable(Of Square)
        If BoardSquare Is Nothing Then Return Nothing

        Dim board As Chessboard = BoardSquare.Board
        Dim isInStartPosition =
            (board.GetSquare(BoardSquare, New Movement With {.Forward = -2, .ToRight = 0}) Is Nothing)

        Dim posibleSquares As New List(Of Square)
        Dim destinationSquare =
            board.GetSquare(BoardSquare, New Movement With {.Forward = 1, .ToRight = 0})
        If (destinationSquare IsNot Nothing AndAlso destinationSquare.Piece Is Nothing) Then
            posibleSquares.Add(destinationSquare)
            If isInStartPosition Then
                destinationSquare =
                    board.GetSquare(BoardSquare, New Movement With {.Forward = 2, .ToRight = 0})
                If (destinationSquare IsNot Nothing AndAlso destinationSquare.Piece Is Nothing) Then
                    posibleSquares.Add(destinationSquare)
                End If
            End If
        End If
        destinationSquare =
            board.GetSquare(BoardSquare, New Movement With {.Forward = 1, .ToRight = -1})
        If (destinationSquare IsNot Nothing AndAlso destinationSquare.Piece IsNot Nothing _
            AndAlso destinationSquare.Piece.Color <> Color) Then
            posibleSquares.Add(destinationSquare)
        End If
        destinationSquare =
            board.GetSquare(BoardSquare, New Movement With {.Forward = 1, .ToRight = 1})
        If destinationSquare IsNot Nothing AndAlso destinationSquare.Piece IsNot Nothing _
            AndAlso destinationSquare.Piece.Color <> Color Then
            posibleSquares.Add(destinationSquare)
        End If

        Return posibleSquares

    End Function

End Class