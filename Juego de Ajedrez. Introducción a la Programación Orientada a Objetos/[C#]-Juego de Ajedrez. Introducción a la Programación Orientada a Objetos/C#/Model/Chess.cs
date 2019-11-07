using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Model
{

    /// <summary>
    /// Colores de los jugadores
    /// </summary>
    enum PlayerColor
    {
        White, Black
    }

    /// <summary>
    /// Posibles estados que puede tomar el juego
    /// </summary>
    enum GameState
    {
        PendingForWhiteMove,
        PendingForBlackMove,
        WhitePlayerMoving,
        BlackPlayerMoving,
        WhitePlayerWin,
        BlackPlayerWin
    }

    /// <summary>
    /// Estructura que define un movimiento
    /// </summary>
    struct Movement
    {
        /// <summary>
        /// Número de posiciones a avanzar hacia adelante
        /// Si se mueve hacia atrás el valor será negativo
        /// El movimiento se realizará hacia arriba o haciaa abajo en función
        /// del color de la pieza a la que se aplica
        /// </summary>
        public int Forward;
        /// <summary>
        /// Número de posiciones a mover hacia la derecha
        /// Si el movimiento es hacia la izquierda el valor será negativo
        /// </summary>
        public int ToRight;
    }

    /// <summary>
    /// Representa el juego, manteniendo el estado en el que se encuentra
    /// </summary>
    class Game
    {

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Game"/>
        /// </summary>
        public Game()
        {
            Board = new Chessboard();
        }

        /// <summary>
        /// Tablero del juego
        /// </summary>
        public Chessboard Board { get; private set; }

        /// <summary>
        /// Estado en el que se encuentra el juego
        /// Cuando se asigna un nuevo estado se lanza el evento <see cref="StateChanged"/>
        /// </summary>
        private GameState _state;
        public GameState State {
            get { return _state; }
            private set
            {
                if (_state != value)
                {
                    _state = value;
                    OnStateChanged(new EventArgs());
                }
            }
        }

        /// <summary>
        /// Devuelve la celda seleccionada por el usuario
        /// </summary>
        public Square SelectedSquare { get; private set; }

        /// <summary>
        /// Inicia un nuevo juego disponiendo las piezas del color indicado
        /// en la parte superior del tablero
        /// </summary>
        /// <param name="playerOnTop">Color de las piezas de la parte superior del tablero</param>
        public void Start(PlayerColor playerOnTop)
        {
            Board.Init(playerOnTop);
            // Se establece el estado a través de la variable privada para que no se genere
            // el evento StateChanged ya que lo lanzamos manualmente
            _state = GameState.PendingForWhiteMove;
            OnStateChanged(new EventArgs());
        }

        /// <summary>
        /// Devuelve las celdas que pueden ser seleccionadas: las celdas con piezas del color del jugador
        /// cuando el juego está pendiente de que éste inicie el movimiento
        /// </summary>
        /// <returns>Las celdas que pueden ser seleccionadas</returns>
        public IEnumerable<Square> GetSquaresThatCanBeSelected()
        {
            if (State != GameState.PendingForWhiteMove && State != GameState.PendingForBlackMove)
                return null;

            return Board.Where(s => s.Piece != null
                && s.Piece.Color == (State == GameState.PendingForWhiteMove ? 
                                        PlayerColor.White : PlayerColor.Black));
        }

        /// <summary>
        /// Selecciona la celda indicada como celda inicio del movimiento
        /// </summary>
        /// <param name="squareToSelect">Celda a seleccionar</param>
        /// <returns>true o false indicando si se ha realizado la selección
        /// El juego debe estar pendiente de iniciar un movimiento y la celda ser una de
        /// las celdas seleccionables</returns>
        public bool SelectPiece(Square squareToSelect)
        {
            if (squareToSelect == null || squareToSelect.Piece == null) return false;

            if (State==GameState.PendingForWhiteMove && squareToSelect.Piece.Color== PlayerColor.White
                || State==GameState.PendingForBlackMove && squareToSelect.Piece.Color==PlayerColor.Black)
            {
                SelectedSquare = squareToSelect;
                State = (State == GameState.PendingForWhiteMove ? 
                    GameState.WhitePlayerMoving : GameState.BlackPlayerMoving);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deselecciona la celda actualmente seleccionada
        /// </summary>
        /// <returns>true o false indicando si se ha realizado la deselección
        /// Para que exista celda seleccionada el juego debe estar pediente de finalizar movimiento</returns>
        public bool UnselectPiece()
        {
            if (State==GameState.WhitePlayerMoving || State == GameState.BlackPlayerMoving)
            {
                SelectedSquare = null;
                State = (State == GameState.WhitePlayerMoving ? 
                    GameState.PendingForWhiteMove : GameState.PendingForBlackMove);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve las celdas que pueden ser destino del movimiento en función
        /// de la celda actualmente seleccionada.
        /// Los posibles destinos dependen de la pieza contenida en la celda seleccionada.
        /// </summary>
        /// <returns>Las celdas que pueden ser destino del movimiento</returns>
        public IEnumerable<Square> PosibleDestinationSquares()
        {
            if (SelectedSquare == null) return null;

            return SelectedSquare.Piece.GetDestinationSquares();
        }

        /// <summary>
        /// Ejecuta el movimiento desde la celda seleccionada a la 
        /// celda indicada
        /// </summary>
        /// <param name="squareToMove">Celda destino del movimiento</param>
        /// <returns>true o false en función de si se ha podido realizar
        /// el movimiento</returns>
        public bool MoveToSquare(Square squareToMove)
        {
            if (SelectedSquare == null) return false;

            if (Board.Move(SelectedSquare, squareToMove))
            {
                SelectedSquare = null;
                // Una vez realizado el movimiento se comprueba si ha finalizado
                // (si hay ganador)
                if (!CheckForWin())
                    State = (State == GameState.WhitePlayerMoving ? 
                        GameState.PendingForBlackMove : GameState.PendingForWhiteMove);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Se produce cuando cambia el estado del juego
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        /// Genera el evento StateChanged
        /// </summary>
        protected virtual void OnStateChanged(EventArgs e)
        {
            EventHandler handler = StateChanged;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Comprueba si el juego ha finalizado (si existe ganador)
        /// </summary>
        /// <returns>true o false indicando si el juego ha finalizado</returns>
        private bool CheckForWin()
        {
            // Si únicamente queda un rey el juego ha terminado
            IEnumerable<ChessPiece> kings = Board.Select(s => s.Piece)
                .Where(p => p != null && p is King);
            if (kings.Count()==1)
            {
                State = (kings.First().Color == PlayerColor.White ? 
                    GameState.WhitePlayerWin : GameState.BlackPlayerWin);
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
