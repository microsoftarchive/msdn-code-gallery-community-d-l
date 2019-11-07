using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Model
{

    /// <summary>
    /// Tablero de juego de ajedrez
    /// </summary>
    class Chessboard : List<Square>
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Chessboard"/>
        /// </summary>
        public Chessboard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                    Add(new Square(this, row, column));
            }
            PlayerOnTop = PlayerColor.White;
        }

        /// <summary>
        /// Establece o devuelve el color del jugador cuyas piezas se posicionan
        /// en la parte superior del tablero
        /// </summary>
        public PlayerColor PlayerOnTop { get; set; }

        /// <summary>
        /// Devuelve la celda ubicada en la fila y columna especificadas
        /// </summary>
        /// <param name="row">Fila</param>
        /// <param name="column">Columna</param>
        /// <returns>Objeto Square de la fila y columna</returns>
        public Square GetSquare(int row, int column)
        {
            return this.FirstOrDefault(s => s.Row == row && s.Column == column);
        }

        /// <summary>
        /// Devuelve la fila destino de la pieza después de aplicar un desplazamiento a partir de 
        /// una celda origen
        /// </summary>
        /// <param name="fromSquare">Celda origen</param>
        /// <param name="move">Movimiento a realizar a partir de la celda origen</param>
        /// <returns>Objeto Square destino del movimiento</returns>
        public Square GetSquare(Square fromSquare, Movement move)
        {
            ChessPiece piece = fromSquare.Piece;
            if (piece == null) return null;

            return GetSquare(fromSquare.Row 
                    + (piece.Color == PlayerOnTop ? move.Forward : -move.Forward)
                , fromSquare.Column + move.ToRight);
        }

        /// <summary>
        /// Inicializa el tablero de juego colocando las piezas en su posición inicial
        /// </summary>
        public void Init()
        {
            ClearPieces();

            PlayerColor bottomColor = (PlayerOnTop == PlayerColor.White ? PlayerColor.Black : PlayerColor.White);
            // Kings
            int column = (PlayerOnTop == PlayerColor.White ? 4 : 3);
            GetSquare(0, column).Piece = new King(PlayerOnTop);
            GetSquare(7, column).Piece = new King(bottomColor);
            // Queens
            column = (column == 4 ? 3 : 4);
            GetSquare(0, column).Piece = new Queen(PlayerOnTop);
            GetSquare(7, column).Piece = new Queen(bottomColor);
            // Rooks
            GetSquare(0, 0).Piece = new Rook(PlayerOnTop);
            GetSquare(0, 7).Piece = new Rook(PlayerOnTop);
            GetSquare(7, 0).Piece = new Rook(bottomColor);
            GetSquare(7, 7).Piece = new Rook(bottomColor);
            // Knights
            GetSquare(0, 1).Piece = new Knight(PlayerOnTop);
            GetSquare(0, 6).Piece = new Knight(PlayerOnTop);
            GetSquare(7, 1).Piece = new Knight(bottomColor);
            GetSquare(7, 6).Piece = new Knight(bottomColor);
            // Bishops
            GetSquare(0, 2).Piece = new Bishop(PlayerOnTop);
            GetSquare(0, 5).Piece = new Bishop(PlayerOnTop);
            GetSquare(7, 2).Piece = new Bishop(bottomColor);
            GetSquare(7, 5).Piece = new Bishop(bottomColor);
            // Pawns
            for (int i = 0; i < 8; i++)
            {
                GetSquare(1, i).Piece = new Pawn(PlayerOnTop);
                GetSquare(6, i).Piece = new Pawn(bottomColor);
            }
        }

        /// <summary>
        /// Inicializa el tablero de juego colocando las piezas en su posición inicial
        /// </summary>
        /// <param name="colorOfTopPlayer">Color de las piezas a colocar en la parte
        /// superior del tablero</param>
        public void Init(PlayerColor colorOfTopPlayer)
        {
            PlayerOnTop = colorOfTopPlayer;
            Init();
        }

        /// <summary>
        /// Mueve una pieza de una celda a otra
        /// </summary>
        /// <param name="fromSquare">Celda desde la que se realiza el movimiento</param>
        /// <param name="toSquare">Celda destino del movimiento</param>
        /// <returns>true o false indicando si el movimiento se ha realizado</returns>
        public bool Move(Square fromSquare, Square toSquare)
        {
            if (fromSquare != null && toSquare != null && fromSquare.Piece != null)
            {
                toSquare.Piece = fromSquare.Piece;
                fromSquare.Piece = null;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Elimmina todas las piezas del tablero
        /// </summary>
        private void ClearPieces()
        {
            foreach (Square square in this)
                square.Piece = null;
        }

    }

    /// <summary>
    /// Celda del tablero de ajedrez
    /// </summary>
    class Square
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Square"/>
        /// </summary>
        /// <param name="board">Referencia al tablero al que pertenece la celda</param>
        /// <param name="row">Fila (índice basado en 0)</param>
        /// <param name="column">Columna (índice basado en 0)</param>
        public Square(Chessboard board, int row, int column)
        {
            Board = board;
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Tablero al que pertenece la celda
        /// </summary>
        public Chessboard Board { get; set; }
        /// <summary>
        /// Fila (índice basado en 0)
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Columna (índice basado en 0)
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Devuelve o establece la pieza que se encuentra en la celda
        /// </summary>
        private ChessPiece _piece;
        public ChessPiece Piece
        {
            get { return _piece; }
            set
            {
                bool changed = _piece != value;
                _piece = value;
                if (_piece != null)
                    _piece.BoardSquare = this;
                if (changed) OnPieceChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Se produce cuando cambia la pieza de la celda
        /// </summary>
        public event EventHandler PieceChanged;

        /// <summary>
        /// Genera el evento PieceChanged
        /// </summary>
        protected virtual void OnPieceChanged(EventArgs e)
        {
            EventHandler handler = PieceChanged;
            if (handler != null)
                handler(this, e);
        }

    }

}
