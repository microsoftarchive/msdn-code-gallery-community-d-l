using System.Collections.Generic;

namespace ChessGame.Model
{

    /// <summary>
    /// Clase base para definir las diferentes piezas de ajedrez
    /// </summary>
    abstract class ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ChessPiece"/>
        /// </summary>
        /// <param name="color">Color de la pieza</param>
        public ChessPiece(PlayerColor color)
        {
            Color = color;
        }

        /// <summary>
        /// Color de la pieza
        /// </summary>
        public PlayerColor Color { get; set; }

        /// <summary>
        /// Celda en la que se encuentra la pieza
        /// </summary>
        public Square BoardSquare { get; internal set; }

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<Square> GetDestinationSquares();

        /// <summary>
        /// Comprueba si una celda puede ser destino de un movimiento de la pieza:
        /// si está vacía o contiene una pieza de un color diferente
        /// </summary>
        /// <param name="destinationSquare">Celda a comprobar</param>
        /// <returns>true o false indicando si puede ser destino del movimiento</returns>
        protected virtual bool CanBeDestination(Square destinationSquare)
        {
            if (destinationSquare == null) return false;

            return (destinationSquare.Piece == null || destinationSquare.Piece.Color != Color);
        }

        /// <summary>
        /// Devuelve la lista de los posibles destinos de movimiento de la pieza
        /// en una dirección determinada
        /// La dirección a tomar viene dada por un incremento hacia adelante y
        /// otro horizontal
        /// </summary>
        /// <param name="forwardIncrement">Incremento hacia adelante.
        /// Si la dirección es hacia atrás será un valor negativo.</param>
        /// <param name="rightIncrement">Incremento hacia la derecha.
        /// Si la dirección es hacia la izquierda será un valor negativo.</param>
        /// <returns>Lista de celdas posibles destinos de movimiento</returns>
        protected IEnumerable<Square> DestinationSquaresOnOneDirection(
            int forwardIncrement, int rightIncrement)
        {
            Chessboard board = BoardSquare.Board;

            List<Square> squares = new List<Square>();
            int forward = forwardIncrement;
            int right = rightIncrement;
            bool pieceOrEndFounded = false;
            while (!pieceOrEndFounded)
            {
                Square destination = board.GetSquare(BoardSquare, new Movement { Forward = forward, ToRight = right });
                if (CanBeDestination(destination))
                    squares.Add(destination);
                pieceOrEndFounded = (destination == null || destination.Piece != null);
                forward += forwardIncrement;
                right += rightIncrement;
            }
            return squares;
        }
        /// <summary>
        /// Devuelve la lista de los posibles destinos de movimiento de la pieza
        /// a partir de una lista de movimientos
        /// </summary>
        /// <param name="moves">Lista de movimientos que puede realizar la pieza</param>
        /// <returns>Lista de celdas posibles destinos</returns>
        protected IEnumerable<Square> DestinationSquaresForMoves(IEnumerable<Movement> moves)
        {
            Chessboard board = BoardSquare.Board;
            List<Square> squares = new List<Square>();
            foreach (Movement move in moves)
            {
                Square destination = board.GetSquare(BoardSquare, move);
                if (CanBeDestination(destination))
                    squares.Add(destination);
            }
            return squares;

        }

    }

    /// <summary>
    /// Rey
    /// </summary>
    class King : ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="King"/>
        /// </summary>
        /// <param name="color">Color de la pieza</param>
        public King(PlayerColor color): base(color) { }

        /// <summary>
        /// Movimientos que puede realizar el rey
        /// </summary>
        private Movement[] moves =
        {
            new Movement() {Forward=1, ToRight=-1 },
            new Movement() {Forward=1, ToRight=0 },
            new Movement() {Forward=1, ToRight=1 },
            new Movement() {Forward=0, ToRight=-1 },
            new Movement() {Forward=0, ToRight=1 },
            new Movement() {Forward=-1, ToRight=-1 },
            new Movement() {Forward=-1, ToRight=0 },
            new Movement() {Forward=-1, ToRight=1 }
        };

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns>Lista de celdas</returns>
        public override IEnumerable<Square> GetDestinationSquares()
        {
            if (BoardSquare == null) return null;

            return DestinationSquaresForMoves(moves);
        }

    }

    /// <summary>
    /// Torre
    /// </summary>
    class Rook : ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva clase de <see cref="Rook"/>
        /// </summary>
        /// <param name="color">Color de la Pieza</param>
        public Rook(PlayerColor color) : base(color) { }

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns>Lista de celdas</returns>
        public override IEnumerable<Square> GetDestinationSquares()
        {
            if (BoardSquare == null) return null;

            List<Square> posibleSquares = new List<Square>();
            // A la izquierda
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, -1));
            // A la derecha
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, 1));
            // Hacia adelante
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 0));
            // Hacia atrás
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 0));

            return posibleSquares;
        }

    }

    /// <summary>
    /// Alfil
    /// </summary>
    class Bishop : ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Bishop"/>
        /// </summary>
        /// <param name="color">Color de la pieza</param>
        public Bishop(PlayerColor color) : base(color) { }

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns>Lista de celdas</returns>
        public override IEnumerable<Square> GetDestinationSquares()
        {
            if (BoardSquare == null) return null;

            List<Square> posibleSquares = new List<Square>();
            // Hacia adelante a la izquierda
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, -1));
            // Hacia adelante a la derecha
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 1));
            // Hacia atrás a la izquierda
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, -1));
            // Hacia atrás a la derecha
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 1));

            return posibleSquares;
        }
    }

    /// <summary>
    /// Reina
    /// </summary>
    class Queen : ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Queen"/>
        /// </summary>
        /// <param name="color">Color de la pieza</param>
        public Queen(PlayerColor color): base(color) { }

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns>Lista de celdas</returns>
        public override IEnumerable<Square> GetDestinationSquares()
        {
            if (BoardSquare == null) return null;

            List<Square> posibleSquares = new List<Square>();
            // Hacia adelante a la izquierda
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, -1));
            // Hacia adelante
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 0));
            // Hacia adelante a la derecha
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(1, 1));
            // Hacia la izquierda
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, -1));
            // Hacia la derecha
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(0, 1));
            // Hacia atrás a la izquierda
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, -1));
            // Hacia atrás
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 0));
            // Hacia atrás a la derecha
            posibleSquares.AddRange(DestinationSquaresOnOneDirection(-1, 1));

            return posibleSquares;
        }
    }

    /// <summary>
    /// Caballo
    /// </summary>
    class Knight : ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Knight"/>
        /// </summary>
        /// <param name="color">Color de la pieza</param>
        public Knight(PlayerColor color): base(color) { }

        /// <summary>
        /// Movimmientos que puede realizar el caballo
        /// </summary>
        private Movement[] moves =
        {
            new Movement {Forward=1, ToRight=-2 },
            new Movement {Forward=2, ToRight=-1 },
            new Movement {Forward=2, ToRight=1 },
            new Movement {Forward=1, ToRight=2 },
            new Movement {Forward=-1, ToRight=-2 },
            new Movement {Forward=-2, ToRight=-1 },
            new Movement {Forward=-2, ToRight=1 },
            new Movement {Forward=-1, ToRight=2 }
        };

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns>Lista de celdas</returns>
        public override IEnumerable<Square> GetDestinationSquares()
        {
            if (BoardSquare == null) return null;

            return DestinationSquaresForMoves(moves);
        }
    }

    /// <summary>
    /// Peón
    /// </summary>
    class Pawn : ChessPiece
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Pawn"/>
        /// </summary>
        /// <param name="color">Color de la pieza</param>
        public Pawn(PlayerColor color): base(color) { }

        /// <summary>
        /// Devuelve las celdas a las que puede moverse la pieza
        /// </summary>
        /// <returns>Lista de celdas</returns>
        public override IEnumerable<Square> GetDestinationSquares()
        {
            if (BoardSquare == null) return null;

            Chessboard board = BoardSquare.Board;
            bool isInStartPosition = (board.GetSquare(BoardSquare, new Movement { Forward = -2, ToRight = 0 }) == null);

            List<Square> posibleSquares = new List<Square>();
            Square destinationSquare = board.GetSquare(BoardSquare, new Movement { Forward = 1, ToRight = 0 });
            if (destinationSquare != null && destinationSquare.Piece == null)
            {
                posibleSquares.Add(destinationSquare);
                if (isInStartPosition)
                {
                    destinationSquare = board.GetSquare(BoardSquare, new Movement { Forward = 2, ToRight = 0 });
                    if (destinationSquare != null && destinationSquare.Piece == null)
                        posibleSquares.Add(destinationSquare);
                }
            }
            destinationSquare = board.GetSquare(BoardSquare, new Movement { Forward = 1, ToRight = -1 });
            if (destinationSquare != null && destinationSquare.Piece != null && destinationSquare.Piece.Color != Color)
                posibleSquares.Add(destinationSquare);
            destinationSquare = board.GetSquare(BoardSquare, new Movement { Forward = 1, ToRight = 1 });
            if (destinationSquare != null && destinationSquare.Piece != null && destinationSquare.Piece.Color != Color)
                posibleSquares.Add(destinationSquare);

            return posibleSquares;
        }
    }

}
