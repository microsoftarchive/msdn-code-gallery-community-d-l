using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
using System.Windows.Forms;
//using System.Windows.Input;
using System.IO;
//v0.980 change: Removed Assembly Info file
//v0.980 change: Project properties -> Build -> Build for x86 specific
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//No need for threading (maybe in future versions)
//using System.Threading.Tasks;
//using System.Threading;

namespace HuoChessW8
{
    public partial class Form1 : Form
    {
        public static int playerClicks;
        public static int playerClick_X;
        public static int playerClick_Y;
        public static int i_MouseIsIn;
        public static int j_MouseIsIn;
        public static int rankClicked;
        public static String columnClicked;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            // v0.991: Activated logs again to test
            Form1.HuoChess_main.huo_sw1.Close();
            this.Close();
        }

        private void skakiera_Click(object sender, EventArgs e)
        {
            MessageBox.Show("skakiera clicked");
        }


        // Redraw the pictureboxes
        private void RedrawTheSkakiera(string[,] RSkakiera)
        {
            string piecePath = "";
            string path = Directory.GetCurrentDirectory();

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    piecePath = "";

                    if (RSkakiera[(i), (j)].CompareTo("White Pawn") == 0)
                        piecePath = "\\Resources\\WPawn.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("White Rook") == 0)
                        piecePath = "\\Resources\\WRook.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("White Knight") == 0)
                        piecePath = "\\Resources\\WKnight.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("White Bishop") == 0)
                        piecePath = "\\Resources\\WBishop.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("White Queen") == 0)
                        piecePath = "\\Resources\\WQueen.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("White King") == 0)
                        piecePath = "\\Resources\\WKing.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("Black Pawn") == 0)
                        piecePath = "\\Resources\\BPawn.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("Black Rook") == 0)
                        piecePath = "\\Resources\\BRook.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("Black Knight") == 0)
                        piecePath = "\\Resources\\BKnight.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("Black Bishop") == 0)
                        piecePath = "\\Resources\\BBishop.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("Black Queen") == 0)
                        piecePath = "\\Resources\\BQueen.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("Black King") == 0)
                        piecePath = "\\Resources\\BKing.gif";
                    else if (RSkakiera[(i), (j)].CompareTo("") == 0)
                        piecePath = "\\Resources\\nothing.gif";

                    if ((i == 0) & (j == 0))
                        pictureBoxA1.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 1))
                        pictureBoxA2.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 2))
                        pictureBoxA3.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 3))
                        pictureBoxA4.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 4))
                        pictureBoxA5.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 5))
                        pictureBoxA6.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 6))
                        pictureBoxA7.Load(string.Concat(path, piecePath));
                    else if ((i == 0) & (j == 7))
                        pictureBoxA8.Load(string.Concat(path, piecePath));

                    else if ((i == 1) & (j == 0))
                        pictureBoxB1.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 1))
                        pictureBoxB2.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 2))
                        pictureBoxB3.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 3))
                        pictureBoxB4.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 4))
                        pictureBoxB5.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 5))
                        pictureBoxB6.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 6))
                        pictureBoxB7.Load(string.Concat(path, piecePath));
                    else if ((i == 1) & (j == 7))
                        pictureBoxB8.Load(string.Concat(path, piecePath));

                    else if ((i == 2) & (j == 0))
                        pictureBoxC1.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 1))
                        pictureBoxC2.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 2))
                        pictureBoxC3.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 3))
                        pictureBoxC4.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 4))
                        pictureBoxC5.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 5))
                        pictureBoxC6.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 6))
                        pictureBoxC7.Load(string.Concat(path, piecePath));
                    else if ((i == 2) & (j == 7))
                        pictureBoxC8.Load(string.Concat(path, piecePath));

                    else if ((i == 3) & (j == 0))
                        pictureBoxD1.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 1))
                        pictureBoxD2.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 2))
                        pictureBoxD3.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 3))
                        pictureBoxD4.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 4))
                        pictureBoxD5.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 5))
                        pictureBoxD6.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 6))
                        pictureBoxD7.Load(string.Concat(path, piecePath));
                    else if ((i == 3) & (j == 7))
                        pictureBoxD8.Load(string.Concat(path, piecePath));

                    else if ((i == 4) & (j == 0))
                        pictureBoxE1.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 1))
                        pictureBoxE2.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 2))
                        pictureBoxE3.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 3))
                        pictureBoxE4.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 4))
                        pictureBoxE5.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 5))
                        pictureBoxE6.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 6))
                        pictureBoxE7.Load(string.Concat(path, piecePath));
                    else if ((i == 4) & (j == 7))
                        pictureBoxE8.Load(string.Concat(path, piecePath));

                    else if ((i == 5) & (j == 0))
                        pictureBoxF1.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 1))
                        pictureBoxF2.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 2))
                        pictureBoxF3.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 3))
                        pictureBoxF4.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 4))
                        pictureBoxF5.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 5))
                        pictureBoxF6.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 6))
                        pictureBoxF7.Load(string.Concat(path, piecePath));
                    else if ((i == 5) & (j == 7))
                        pictureBoxF8.Load(string.Concat(path, piecePath));

                    else if ((i == 6) & (j == 0))
                        pictureBoxG1.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 1))
                        pictureBoxG2.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 2))
                        pictureBoxG3.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 3))
                        pictureBoxG4.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 4))
                        pictureBoxG5.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 5))
                        pictureBoxG6.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 6))
                        pictureBoxG7.Load(string.Concat(path, piecePath));
                    else if ((i == 6) & (j == 7))
                        pictureBoxG8.Load(string.Concat(path, piecePath));

                    else if ((i == 7) & (j == 0))
                        pictureBoxH1.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 1))
                        pictureBoxH2.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 2))
                        pictureBoxH3.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 3))
                        pictureBoxH4.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 4))
                        pictureBoxH5.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 5))
                        pictureBoxH6.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 6))
                        pictureBoxH7.Load(string.Concat(path, piecePath));
                    else if ((i == 7) & (j == 7))
                        pictureBoxH8.Load(string.Concat(path, piecePath));
                }
            }

            Application.DoEvents();
            //Invalidate();
        }

        class HuoChess_main
        {
            // HuoChessConsole.cpp : main project file.

            /////////////////////////////////////////////
            // Huo Chess                               //
            // version: 0.991                          //
            // Changes in v0.991: Fixed the MinMax algorithm. Allowed to check for all moves, but assign penalty for stupid moves or moves to dangerous squares.
            // Changes in v0.990: Updated engine. Fixed bugs. [Visual Studio 2015/ 2017]
            // Changes in v0.980: Fixed bugs related to check and invalid human moves, added the "resign" functionality [Visual Studio 2013/ 2015]
            // Changes in v0.971: Fixed the Nodes Analysis: Created a different NodesAnalysis array for each level. Fixed bugs so that the analysis stores correctly the values and the MiniMax algorithm performs as it should. Fixed the “Stupid move” filter for the computer moves. Fixed the “Possibility to eat back” functionality.
            // Changes from version 0.81: Removed the ComputerMove functions and used a template function to create all new ComputerMove functions I need.
            // Changes from version 0.722: Changed the ComputerMove, HumanMove, CountScore, ElegxosOrthotitas functions.
            // Changes from verion 0.721: Removed some useless code and added the variable thinking depth (depending on the piece the opponent moves)
            // Changes from version 0.6: Added more thinking depths
            // Year: 2008-2019                         //
            // Place: Earth - Greece                   //
            // Programmed by Spiros I. Kakos (huo)     //
            // License: TOTALLY FREEWARE!              //
            //          Do anything you want with it!  //
            //          Spread the knowledge!          //
            //          Fix its bugs!                  //
            //          Sell it (if you can...)!       //
            //          Call me for help! :P           //
            // Site: harmoniaPhilosophica.com          //
            //       Dedicated to Matoula!!!           //
            //       The light of my life!!!! E-U!     //
            /////////////////////////////////////////////

            // Icon created with : http://www.rw-designer.com/online_icon_maker.php
            // Algorithm analysis: http://www.codeproject.com/KB/game/cpp_microchess.aspx

            ///////////////////////////////////////////////////////////////////////////////////////////
            // MAIN ALGORITHM
            // 1. ComputerMove: Scans the chessboard and makes all possible moves.
            // 2. CheckMove: It checks the legality and correctness of these possible moves.
            // 3. (if thinking depth not reached) => call HumanMove
            // 4. HumanMove2: Checks and finds the possible answers of the human opponent for the next move.
            // 5. ComputerMove2: Scans the chessboard and makes all possible moves at the next thinking level.
            // 6. CheckMove: It checks the legality and correctness of these possible moves.
            // 7. (if thinking depth not reached) => call HumanMove for the next level of thinking
            // 8. HumanMove4: Checks and finds the possible answers of the human opponent for the next move.
            // 9. ComputerMove4: Scans the chessboard and makes all possible moves at the next thinking level.
            // 10. CheckMove: It checks the legality and correctness of these possible moves.
            // 11. (if thinking depth reached) => record the score of the final position.
            // 12. (if score of position the best so far) => record the move as best move!
            // 13. The algorithm continues until all possible moves are scanned.
            // SET huo_debug to TRUE to see live the progress of the computer thought!
            // FIND us at Codeproject (www.codeproject.com) or MSDN Code Gallery!
            // ---------------------------------------------------------------------------
            // The score before every human opponents move and after any human opponents move are stored in the
            // Temp_Score_Move_1_human (i.e. the score after the first move of the H/Y and before the 1st move of human
            // while at the 2nd -ply of computer thinking), Temp_Score_Move_2, etc variables.
            // ---------------------------------------------------------------------------
            // At every level of thinking, the scores are stored in the NodesAnalysis table. This table is used for the
            // implementation of the MiniMax algorithm.
            ////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // DECLARE VARIABLES (v0.970: Sanitization)
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Writer for logging the thought process
            public static StreamWriter huo_sw1 = new StreamWriter("HUO_CHESS_LOG_Minimax_Thought_Process.txt", true);
            // Writers for logging the attackers, the defenders and the dangerous squares
            public static StreamWriter huo_sw_attackers = new StreamWriter("HUO_CHESS_LOG_Attackers_Defenders.txt", true);
            //public static StreamWriter huo_sw_defenders = new StreamWriter("Defenders.txt", true);
            //public static StreamWriter huo_sw_dangerous = new StreamWriter("Dangerous.txt", true);

            public static String NextLine;
            public static string FinalPositions;

            //v0.990
            public static String ThisIsStupidMove = "N";
            public static bool Danger_for_piece;
            public static bool ThereIsCheck;
            //Is it possible to eat a piece of greater value?
            public static bool possibility_to_eat;
            public static int ValueOfKommati = 0;
            public static int ValueOfTargetPiece = 0;
            // Chessboard for logging purposes
            public static String[,] SkakieraLog = new String[8, 8];  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα

            //v0.980: Change small Strings to Int
            //0 = Not dangerous square
            //1 = Dangerous square
            public static int[,] Skakiera_Dangerous_Squares = new int[8, 8];
            //v0.990: New dangerous squares check to see if the computer moves his pieve into a square,
            //where the only defender was the same moving piece! (and there exists an attacker of course...)
            //public static int[,] Skakiera_Dangerous_Squares_2 = new int[8, 8];
            public static int[,] Number_of_defenders = new int[8, 8];
            public static int[,] Number_of_attackers = new int[8, 8];
            //v0.980: Removed Attackers_coordinates_column/ rank since they are not used!
            //public static int[,] Attackers_coordinates_column = new int[8, 8];
            //public static int[,] Attackers_coordinates_rank = new int[8, 8];
            public static int[,] Value_of_defenders = new int[8, 8];
            public static int[,] Value_of_attackers = new int[8, 8];
            //v0.980: Removed Exception_defender_column/ rank since they are not used!
            //public static int[,] Exception_defender_column = new int[8, 8];
            //public static int[,] Exception_defender_rank = new int[8, 8];

            //Parameter which determined the weight of danger in the counting of the score of positions
            //v0.980: Removed humanDangerParameter and computerDangerParameter
            //public static int humanDangerParameter = 0;
            //public static int computerDangerParameter = 1;

            // Is it possible to eat back the piece that was moved by the computer?
            public static bool possibility_to_eat_back;

            // v0.970 added
            public static int ValueOfHumanMovingPiece = 0;
            public static int ValueOfMovingPiece = 0;

            // Variables to store the scores of positions during the analysis
            // v0.970: Changed them to integers
            public static int Temp_Score_Move_0;
            public static int Temp_Score_Move_1_human;
            public static int Temp_Score_Move_2;
            public static int Temp_Score_Move_3_human;
            public static int Temp_Score_Move_4;
            public static int Temp_Score_Move_5_human;
            public static int Temp_Score_Move_6;

            // 0.970
            // These arrays will hold the Minimax analysis nodes data (skakos)
            // Dimension ,1: For the score
            // Dimension ,2: For the parent
            // Dimensions 3-6: For the initial move starting/ finishing columns-ranks (only for the 0-level array)
            // Changed them to integers for less memory usage
            // v0.980: Reduced size of arrays
            public static int[,] NodesAnalysis0 = new int[1000000, 6];
            public static int[,] NodesAnalysis1 = new int[1000000, 2];
            public static int[,] NodesAnalysis2 = new int[1000000, 2];
            // v0.991 - Tables to store the average score of the branch
            // public static double[] NodesAnalysisA = new double[1000000];
            // v0.990 Move 4 changes
            public static int[,] NodesAnalysis3 = new int[10000000, 2];
            public static int[,] NodesAnalysis4 = new int[100000000, 2];  // Increased depth => Increased size (logical...)

            // For the logs...
            // v0.991: Variable to denote if logs are activated
            public static bool activateLogs;
            // v0.991: Variables to store the moves the computer thinks of
            public static String Move0_text;
            public static String Move1_text;
            public static String Move2_text;
            public static String[] NodesAnalysis0_MoveText = new String[1000000];  //v0.991
            public static String[] NodesAnalysis1_MoveText = new String[1000000];  //v0.991
            public static String[] NodesAnalysis2_MoveText = new String[1000000];  //v0.991
            public static String Best_Variant_text;
            // Tables to store the chessboards to show in the logs
            public static String[,,] NodesAnalysis0_Chessboard = new String[8, 8, 1000000];  //v0.990
            public static String[,,] NodesAnalysis1_Chessboard = new String[8, 8, 1000000];  //v0.990
            public static String[,,] NodesAnalysis2_Chessboard = new String[8,8,1000000];  //v0.990
            public static String[,,] NodesAnalysis2_Chessboard_2 = new String[8, 8, 1000000];  //v0.990
            public static String[,,] NodesAnalysis4_Chessboard_4 = new String[8, 8, 1000000];  //v0.990
            public static String[,,] NodesAnalysis0_Chessboard_before = new String[8, 8, 1000000];  //v0.990
            public static String[,,] NodesAnalysis1_Chessboard_before = new String[8, 8, 1000000];  //v0.990
            public static String[,,] NodesAnalysis2_Chessboard_before = new String[8, 8, 1000000];  //v0.990

            // Nodes count (per level)
            public static int Nodes_Total_count;
            public static int NodeLevel_0_count;
            public static int NodeLevel_1_count;
            public static int NodeLevel_2_count;
            public static int NodeLevel_3_count;
            public static int NodeLevel_4_count;
            public static int NodeLevel_5_count;
            public static int NodeLevel_6_count;

            // If HY eats a piece, then make the square a preferred target!!!
            public static int Human_last_move_target_column;
            public static int Human_last_move_target_row;

            // The chessboard (= 'skakiera' in Greek)
            public static String[,] Skakiera = new String[8, 8];  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα

            public static String m_PlayerColor;
            public static String m_WhoPlays;
            public static String m_WhichColorPlays;
            public static String MovingPiece;

            // Variable to store temporarily the piece that is moving
            public static String ProsorinoKommati;
            public static String ProsorinoKommati_KingCheck;

            // Variables to check the legality of the move
            public static bool exit_elegxos_nomimothtas = false;
            public static int h;
            public static int p;
            public static int how_to_move_Rank;
            public static int how_to_move_Column;

            public static bool KingCheck = false;

            // Coordinates of the starting square of the move
            public static String m_StartingColumn;
            public static int m_StartingRank;
            public static String m_FinishingColumn;
            public static int m_FinishingRank;

            // Variable for en passant moves
            public static bool enpassant_occured;

            // Move number
            public static int Move;
            //v0.980
            public static int number_of_moves_analysed;

            // Variable to show if promotion of a pawn occured
            public static bool Promotion_Occured = false;

            // Variable to show if castrling occured
            public static bool Castling_Occured = false;

            // Variables to show where the kings are in the chessboard
            public static int WhiteKingColumn;
            public static int WhiteKingRank;
            public static int BlKingColumn;
            public static int BlKingRank;

            // Variables to show if king is in check
            public static bool WhiteKingCheck;
            public static bool BlackKingCheck;

            // Variable to show if a move is found for the H/Y to do
            public static bool Best_Move_Found;

            // Variables to help find if a king is under check.
            // (see CheckForWhiteCheck and CheckForBlackCheck functions)
            public static bool DangerFromRight;
            public static bool DangerFromLeft;
            public static bool DangerFromUp;
            public static bool DangerFromDown;
            public static bool DangerFromUpRight;
            public static bool DangerFromDownRight;
            public static bool DangerFromUpLeft;
            public static bool DangerFromDownLeft;

            // Initial coordinates of the two kings
            // (see CheckForWhiteCheck and CheckForBlackCheck functions)
            public static int StartingWhiteKingColumn;
            public static int StartingWhiteKingRank;
            public static int StartingBlKingColumn;
            public static int StartingBlKingRank;

            // Volumn number inserted by the user
            public static int m_StartingColumnNumber;
            public static int m_FinishingColumnNumber;

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            // Μεταβλητές για τον έλεγχο της "ορθότητας" και της "νομιμότητας" μιας κίνησης του χρήστη
            // Variables to check the correctess (ορθότητα) and the legality (νομιμότητα) of the moves
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            // Variable for the correctness of the move
            public static bool m_OrthotitaKinisis;
            // Variable for the legality of the move
            public static bool m_NomimotitaKinisis;
            // Has the user entered a wrong column?
            public static bool m_WrongColumn;

            // Variables for 'For' loops
            public static int i;
            public static int j;

            // User choices
            public static int ApophasiXristi = 1;
            public static int choise_of_user;

            //////////////////////////////////////
            // Computer Thought
            //////////////////////////////////////
            // Chessboards used for the computer throught
            public static String[,] Skakiera_Move_0 = new String[8, 8]; // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα
            public static String[,] Skakiera_Move_After = new String[8, 8];
            public static String[,] Skakiera_Thinking = new String[8, 8];
            public static String[,] Skakiera_CM_Check = new String[8, 8];
            // Rest of variables used for computer thought
            //public static double Best_Move_Score;
            public static int Current_Move_Score;
            public static int Best_Move_StartingColumnNumber;
            public static int Best_Move_FinishingColumnNumber;
            public static int Best_Move_StartingRank;
            public static int Best_Move_FinishingRank;
            public static int Move_Analyzed;
            public static bool Stop_Analyzing;
            public static int Thinking_Depth;
            public static int m_StartingColumnNumber_HY;
            public static int m_FinishingColumnNumber_HY;
            public static int m_StartingRank_HY;
            public static int m_FinishingRank_HY;
            public static bool First_Call;
            public static String Who_Is_Analyzed;
            public static String MovingPiece_HY;

            // For writing the computer move
            public static String HY_Starting_Column_Text;
            public static String HY_Finishing_Column_Text;

            // Coordinates of the square Where the player can perform en passant
            public static int enpassant_possible_target_rank;
            public static int enpassant_possible_target_column;

            //v0.980: Removed unused variables
            // Is there a possible mate?
            //public static bool Human_is_in_check;
            //public static bool Possible_mate;
            // Does the HY moves its King with the move it is analyzing?
            //public static bool moving_the_king;
            // Variables which help find the best move of the Hu-opponent during the HY thought analysis
            //v0.980 removed
            //public static bool First_Call_Human_Thought;
            //public static String MovingPiece_Human = "";
            //public static int m_StartingColumnNumber_Human = 1;
            //public static int m_FinishingColumnNumber_Human = 1;
            //public static int m_StartingRank_Human = 1;
            //public static int m_FinishingRank_Human = 1;
            // Variables to help find out if it is legal for the computer to perform castling
            //v0.980: Removed all that code! It was not used anyway!
            //public static bool White_King_Moved = false;
            //public static bool Bl_King_Moved = false;
            //public static bool White_Rook_a1_Moved = false;
            //public static bool White_Rook_h1_Moved = false;
            //public static bool Bl_Rook_a8_Moved = false;
            //public static bool Bl_Rook_h8_Moved = false;
            //v0.980: Removed unsused variables.
            //public static bool Can_Castle_Big_White;
            //public static bool Can_Castle_Big_Bl;
            //public static bool Can_Castle_Small_White;
            //public static bool Can_Castle_Small_Bl;
            // If it possible to eat the queen of the opponent, go for it!
            // v0.980: removed since it was not used
            //public static bool go_for_it;
            // Variable which determines of the program will show the inner
            // thinking process of the AI. Good for educational purposes!!!
            // UNCOMMENT TO SHOW INNER THINKING MECHANISM!
            //bool huo_debug;
            // Arrays to use in ComputerMove function
            // Penalty for moving the only piece that defends a square to that square (thus leavind the defender
            // alone in the square he once defended, defenceless!)
            // This penalty is also used to indicate that the computer loses its Queen with the move analyzed
            //v0.980: Removed. It wa not used.
            //public static bool Danger_penalty;
            //v0.980
            //public static String m_ComputerLevel = "Kakos";
            // Variables to show if there is a possibility for mate
            //public static bool WhiteMate = false;
            //public static bool BlMate = false;
            //public static bool Mate;

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            // END OF VARIABLES DECLARATION
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            public static void Main_Console()
            {
                /////////////////////
                // Setup game
                /////////////////////

                //String the_choise_of_user = Console.ReadLine();

                //if ((the_choise_of_user.CompareTo("w") == 0) || (the_choise_of_user.CompareTo("W") == 0))
                //{
                //    m_PlayerColor = "White";
                //    m_WhoPlays = "Human";
                //}
                //else if ((the_choise_of_user.CompareTo("b") == 0) || (the_choise_of_user.CompareTo("B") == 0))
                //{
                //    m_PlayerColor = "Black";
                //    m_WhoPlays = "HY";
                //}

                /////////////////////////////////////////////////////////////////////////
                // CHANGE Thinking_Depth TO HAVE MORE THINKING DEPTHS
                // BUT REMEMBER TO ALSO ADD Analyze_Move functions!
                // ALWAYS CHANGE THE Thinking Depth to even numbers! (2, 4, ...)
                /////////////////////////////////////////////////////////////////////////
                // ΠΡΟΣΟΧΗ: Αν βάλω τον υπολογιστή να σκεφτεί σε βάθος 1 κίνησης
                // (ήτοι Thinking_Depth = 0), τότε ΔΕΝ σκέφτεται σωστά! Αυτό συμβαίνει
                // διότι η HumanMove πρέπει να κληθεί τουλάχιστον μία φορά για να
                // ολοκληρωθεί σωστά τουλάχιστον ένας πλήρης κύκλος σκέψης του ΗΥ.
                /////////////////////////////////////////////////////////////////////////

                // MiniMax algorithm currently only utilizes 4-ply thinking depth maximum
                // Add more "for loops" in the required section in ComputerMove to allow more deep thinking
                // However remember that the NodesAnalysis table has a limit!!! (and so does the memory)
                // Thinking depth must be ζυγός number because the nodes are recorded only in the Analyze_Computer functions!

                Thinking_Depth = 2;

                // v0.991
                /////////////////////////////////////////////////////////////////////////////////////
                // ACTIVATE LOGS?
                // ATTENTION: Remember to delete logs after every run if you activate them!!!!
                /////////////////////////////////////////////////////////////////////////////////////
                activateLogs = false;

                ////////////////////////////////////////////////////////////
                // SHOW THE INNER THINKING PROCESS OF THE COMPUTER?
                // GOOD FOR EDUCATIONAL PURPOSES!
                // SET huo_debug to TRUE to show inner thinking process!
                ////////////////////////////////////////////////////////////
                //Console.Write("Show thinking process (y/n)? ");
                //the_choise_of_user = Console.ReadLine();
                //if((the_choise_of_user.CompareTo("y") == 0)||(the_choise_of_user.CompareTo("Y") == 0))
                //	huo_debug = true;
                //else if((the_choise_of_user.CompareTo("n") == 0)||(the_choise_of_user.CompareTo("N") == 0))
                //	huo_debug = false;

                MessageBox.Show("\nHuo Chess v0.991 by Spiros I.Kakos (huo) [2018-9] - C# Edition\n\nCURRENT EXPERIMENT: Depth 2 (Minimax Algorithm)\n\nWhat about a nice game of chess?", "Huo Chess W8", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // v0.991: Ability to easily activate/ deactivate logs
                if(activateLogs == true)
                {
                    MessageBox.Show("Logs are active!\rRemember to delete them after every run!!!");
                }

                // Initial values
                Move = 0;
                m_WhichColorPlays = "White";

                // Setup startup position
                // v0.990: Removed. This is already called before this function is called!
                Starting_position();

                if (m_WhoPlays.CompareTo("HY") == 0)
                    {
                        // call HY Thought function
                        Move = 0;
                        Move_Analyzed = 0;
                        Stop_Analyzing = false;
                        First_Call = true;
                        Best_Move_Found = false;
                        Who_Is_Analyzed = "HY";

                        // v0.991: Deleted the Check for Danger squares check

                        ComputerMove(Skakiera);

                        // Make player clicks zero so as to wait again for the player to click his moves with the mouse
                        m_WhoPlays = "Human";
                        playerClicks = 0;
                    }

                        ////////////////////////////
                        // Human enters his move
                        ////////////////////////////
                        //MessageBox.Show("Enter your move by pressing the keys");

                        //MessageBox.Show("");
                        //Console.Write("Starting column (A to H)...");
                        //m_StartingColumn = Console.ReadLine().ToUpper();
                        //Console.Write("Starting rank (1 to 8).....");
                        //m_StartingRank = Int32.Parse(Console.ReadLine());
                        //Console.Write("Finishing column (A to H)...");
                        //m_FinishingColumn = Console.ReadLine().ToUpper();
                        //Console.Write("Finishing rank (1 to 8).....");
                        //m_FinishingRank = Int32.Parse(Console.ReadLine());

                        //////////////////////////////////////////////////////////////////////////////

                        // Show the move entered

                        // 2012
                        //huoMove = String.Concat(m_StartingColumn, m_StartingRank.ToString(), " > ");
                        //huoMove = String.Concat(huoMove, m_FinishingColumn, m_FinishingRank.ToString());
                        //MessageBox.Show(huoMove);

                        ////StreamWriter huo_sw3 = new StreamWriter("game.txt", true);
                        ////huo_sw3.WriteLine(huoMove);
                        ////huo_sw3.Close();

                        //MessageBox.Show("");
                        //MessageBox.Show("Thinking...");

                        //// check the move entered by the human for correctness (='Orthotita' in Greek)
                        //// and legality (='Nomimotita' in Greek)
                        //Enter_move();
            }

            // v0.990 changes
            public static bool CheckForBlackCheck(string[,] BCSkakiera)
            {
                // Check if the BK is under threat

                bool KingCheck;
                //v0.990
                int klopa;

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Εύρεση των συντεταγμένων του βασιλιά.
                // Αν σε κάποιο τετράγωνο βρεθεί ότι υπάρχει ένας βασιλιάς, τότε απλά καταγράφεται η τιμή του εν λόγω
                // τετραγώνου στις αντίστοιχες μεταβλητές που δηλώνουν τη στήλη και τη γραμμή στην οποία υπάρχει μαύρος
                // βασιλιάς.
                // ΠΡΟΣΟΧΗ: Γράφω (i+1) αντί για i και (j+1) αντί για j γιατί το πρώτο στοιχείο του πίνακα BCSkakiera[(8),(8)]
                // είναι το BCSkakiera[(0),(0)] και ΟΧΙ το BCSkakiera[(1),(1)]!
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (BCSkakiera[(i), (j)].CompareTo("Black King") == 0)
                        {
                            BlKingColumn = (i + 1);
                            BlKingRank = (j + 1);
                        }

                    }
                }

                ///////////////////////////////////////////////////////////////
                // Έλεγχος του αν ο μαύρος βασιλιάς υφίσταται "σαχ"
                ///////////////////////////////////////////////////////////////

                KingCheck = false;

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Ελέγχουμε αρχικά αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΤΑ ΔΕΞΙΑ ΤΟΥ. Για να μην βγούμε έξω από τα
                // όρια της BCSkakiera[(8),(8)] έχουμε προσθέσει τον έλεγχο (BlKingColumn + 1) <= 8 στο "if". Αρχικά ο "κίνδυνος"
                // από τα "δεξιά" είναι υπαρκτός, άρα DangerFromRight = true. Ωστόσο αν βρεθεί ότι στα δεξιά του μαύρου βασι-
                // λιά υπάρχει κάποιο μαύρο κομμάτι, τότε δεν είναι δυνατόν ο εν λόγω βασιλιάς να υφίσταται σαχ από τα δεξιά
                // του (αφού θα "προστατεύεται" από το κομμάτι ιδίου χρώματος), οπότε η DangerFromRight = false και ο έλεγχος
                // για απειλές από τα δεξιά σταματάει (για αυτό και έχω προσθέσει την προϋπόθεση (DangerFromRight == true) στα
                // "if" που κάνουν αυτόν τον έλεγχο).
                // Αν όμως δεν υπάρχει κανένα μαύρο κομμάτι δεξιά του βασιλιά για να τον προστατεύει, τότε συνεχίζει να
                // υπάρχει πιθανότητα να απειλείται ο βασιλιάς από τα δεξιά του, οπότε ο έλεγχος συνεχίζεται.
                // Σημείωση: Ο έλεγχος γίνεται για πιθανό σαχ από πύργο ή βασίλισσα αντίθετου χρώματος.
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromRight = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingColumn + klopa) <= 8) && (DangerFromRight == true))
                    {
                        if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("Black Queen") == 0))
                            DangerFromRight = false;
                        else if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - 1)].CompareTo("White King") == 0))
                            DangerFromRight = false;
                    }
                }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΤΑ ΑΡΙΣΤΕΡΑ ΤΟΥ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromLeft = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingColumn - klopa) >= 1) && (DangerFromLeft == true))
                    {
                        if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("Black Queen") == 0))
                            DangerFromLeft = false;
                        else if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - 1)].CompareTo("White King") == 0))
                            DangerFromLeft = false;
                    }
                }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΠΑΝΩ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////


                DangerFromUp = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingRank + klopa) <= 8) && (DangerFromUp == true))
                    {
                        if ((BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromUp = false;
                        else if ((BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank + klopa - 1)].CompareTo("White King") == 0))
                            DangerFromUp = false;
                    }
                }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΚΑΤΩ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDown = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingRank - klopa) >= 1) && (DangerFromDown == true))
                    {
                        if ((BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromDown = false;
                        else if ((BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn - 1), (BlKingRank - klopa - 1)].CompareTo("White King") == 0))
                            DangerFromDown = false;
                    }
                }



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΠΑΝΩ-ΔΕΞΙΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromUpRight = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingColumn + klopa) <= 8) && ((BlKingRank + klopa) <= 8) && (DangerFromUpRight == true))
                    {
                        if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromUpRight = false;
                        else if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White King") == 0))
                            DangerFromUpRight = false;
                    }
                }



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΚΑΤΩ-ΑΡΙΣΤΕΡΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDownLeft = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingColumn - klopa) >= 1) && ((BlKingRank - klopa) >= 1) && (DangerFromDownLeft == true))
                    {
                        if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromDownLeft = false;
                        else if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White King") == 0))
                            DangerFromDownLeft = false;
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΚΑΤΩ-ΔΕΞΙΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDownRight = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingColumn + klopa) <= 8) && ((BlKingRank - klopa) >= 1) && (DangerFromDownRight == true))
                    {
                        if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromDownRight = false;
                        else if ((BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn + klopa - 1), (BlKingRank - klopa - 1)].CompareTo("White King") == 0))
                            DangerFromDownRight = false;
                    }
                }



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΠΑΝΩ-ΑΡΙΣΤΕΡΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromUpLeft = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlKingColumn - klopa) >= 1) && ((BlKingRank + klopa) <= 8) && (DangerFromUpLeft == true))
                    {
                        if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromUpLeft = false;
                        else if ((BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlKingColumn - klopa - 1), (BlKingRank + klopa - 1)].CompareTo("White King") == 0))
                            DangerFromUpLeft = false;
                    }
                }


                //////////////////////////////////////////////////////////////////////////
                // Έλεγχος για το αν ο μαύρος βασιλιάς απειλείται από πιόνι.
                //////////////////////////////////////////////////////////////////////////

                if (((BlKingColumn + 1) <= 8) && ((BlKingRank - 1) >= 1))
                {
                    if (BCSkakiera[(BlKingColumn + 1 - 1), (BlKingRank - 1 - 1)].CompareTo("White Pawn") == 0)
                    {
                        KingCheck = true;
                    }
                }


                if (((BlKingColumn - 1) >= 1) && ((BlKingRank - 1) >= 1))
                {
                    if (BCSkakiera[(BlKingColumn - 1 - 1), (BlKingRank - 1 - 1)].CompareTo("White Pawn") == 0)
                    {
                        KingCheck = true;
                    }
                }


                ///////////////////////////////////////////////////////////////////////
                // Έλεγχος για το αν ο μαύρος βασιλιάς απειλείται από ίππο.
                ///////////////////////////////////////////////////////////////////////

                if (((BlKingColumn + 1) <= 8) && ((BlKingRank + 2) <= 8))
                    if (BCSkakiera[(BlKingColumn + 1 - 1), (BlKingRank + 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn + 2) <= 8) && ((BlKingRank - 1) >= 1))
                    if (BCSkakiera[(BlKingColumn + 2 - 1), (BlKingRank - 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn + 1) <= 8) && ((BlKingRank - 2) >= 1))
                    if (BCSkakiera[(BlKingColumn + 1 - 1), (BlKingRank - 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 1) >= 1) && ((BlKingRank - 2) >= 1))
                    if (BCSkakiera[(BlKingColumn - 1 - 1), (BlKingRank - 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 2) >= 1) && ((BlKingRank - 1) >= 1))
                    if (BCSkakiera[(BlKingColumn - 2 - 1), (BlKingRank - 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 2) >= 1) && ((BlKingRank + 1) <= 8))
                    if (BCSkakiera[(BlKingColumn - 2 - 1), (BlKingRank + 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 1) >= 1) && ((BlKingRank + 2) <= 8))
                    if (BCSkakiera[(BlKingColumn - 1 - 1), (BlKingRank + 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlKingColumn + 2) <= 8) && ((BlKingRank + 1) <= 8))
                    if (BCSkakiera[(BlKingColumn + 2 - 1), (BlKingRank + 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                return KingCheck;
            }

            // v0.990 changes
            public static bool CheckForBlackMate(string[,] BMSkakiera)
            {
                // Check if the BK is under checkmate

                bool Mate;
                //v0.990: Changed MovingPiece and ProsorinoKommati with the CBM variables
                String MovingPieceCBM;
                String ProsorinoKommatiCBM;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Μεταβλητή που χρησιμεύει στον έλεγχο για το αν υπάρχει ματ (βλ. συναρτήσεις CheckForWhiteMate() και
                // CheckForBlMate()).
                // Αναλυτικότερα, το πρόγραμμα ελέγχει αν αρχικά υπάρχει σαχ και, αν υπάρχει, ελέγχει αν αυτό το
                // σαχ μπορεί να αποφευχθεί με τη μετακίνηση του υπό απειλή βασιλιά σε κάποιο γειτονικό τετράγωνο.
                // Η μεταβλητή καταγράφει το αν συνεχίζει να υπάρχει πιθανότητα να υπάρχει ματ στη σκακιέρα.
                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                bool DangerForMate;

                ////////////////////////////////////////////////////////////
                // Έλεγχος του αν υπάρχει "ματ" στον μαύρο βασιλιά
                ////////////////////////////////////////////////////////////

                Mate = false;
                DangerForMate = true;    // Αρχικά, προφανώς υπάρχει πιθανότητα να υπάρχει ματ στη σκακιέρα.
                                         // Αν, ωστόσο, κάποια στιγμή βρεθεί ότι αν ο βασιλιάς μπορεί να μετακινηθεί
                                         // σε ένα διπλανό τετράγωνο και να πάψει να υφίσταται σαχ, τότε παύει να
                                         // υπάρχει πιθανότητα να υπάρχει ματ (προφανώς) και η μεταβλητή παίρνει την
                                         // τιμή false.


                //////////////////////////////////////////////////////////////
                // Εύρεση των αρχικών συντεταγμένων του βασιλιά
                //////////////////////////////////////////////////////////////

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (BMSkakiera[(i), (j)].CompareTo("Black King") == 0)
                        {
                            StartingBlKingColumn = (i + 1);
                            StartingBlKingRank = (j + 1);
                        }

                    }
                }


                //////////////////////////////////////////////////
                // Έλεγχος αν ο μαύρος βασιλιάς είναι ματ
                //////////////////////////////////////////////////


                if (m_WhichColorPlays.CompareTo("Black") == 0)
                {

                    ////////////////////////////////////////////////
                    // Έλεγχος αν υπάρχει σαχ αυτή τη στιγμή
                    ////////////////////////////////////////////////

                    BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                    if (BlackKingCheck == false)     // Αν αυτή τη στιγμή δεν υφίσταται σαχ, τότε να μη συνεχιστεί ο έλεγχος
                        DangerForMate = false;         // καθώς ΔΕΝ συνεχίζει να υφίσταται πιθανότητα να υπάρχει ματ.

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlKingRank < 8)
                    {
                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1 + 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingRank - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.
                            // Ο έλεγχος γίνεται μόνο αν στο τετράγωνο που μετακινείται προσωρινά ο βασιλιάς δεν υπάρχει άλλο κομμάτι
                            // του ίδιου χρώματος που να τον εμποδίζει και αν, φυσικά, ο βασιλιάς δεν βγαίνει έξω από τη σκακιέρα με
                            // αυτή του την κίνηση και αν, προφανώς, συνεχίζει να υπάρχει πιθανότητα να ύπάρχει ματ (καθώς αν δεν
                            // υπάρχει τέτοια πιθανότητα, τότε ο έλεγχος είναι άχρηστος).

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1 + 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1 + 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlKingColumn < 8) && (StartingBlKingRank < 8))
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1 + 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingRank - 1 + 1) <= 7) && ((StartingBlKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1 + 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1 + 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlKingColumn < 8)
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlKingColumn < 8) && (StartingBlKingRank > 1))
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1 - 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingRank - 1 - 1) >= 0) && ((StartingBlKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1 - 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1 + 1), (StartingBlKingRank - 1 - 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlKingRank > 1)
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1 - 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingRank - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1 - 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1 - 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlKingColumn > 1) && (StartingBlKingRank > 1))
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1 - 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingRank - 1 - 1) >= 0) && ((StartingBlKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1 - 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1 - 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlKingColumn > 1)
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1)] = ProsorinoKommatiCBM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlKingColumn > 1) && (StartingBlKingRank < 8))
                    {

                        MovingPieceCBM = BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)];
                        ProsorinoKommatiCBM = BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1 + 1)];

                        if ((ProsorinoKommatiCBM.CompareTo("Black Queen") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Rook") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Knight") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Bishop") == 1) && (ProsorinoKommatiCBM.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlKingRank - 1 + 1) <= 7) && ((StartingBlKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = "";
                            BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1 + 1)] = MovingPieceCBM;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlKingColumn - 1), (StartingBlKingRank - 1)] = MovingPieceCBM;
                            BMSkakiera[(StartingBlKingColumn - 1 - 1), (StartingBlKingRank - 1 + 1)] = ProsorinoKommatiCBM;

                        }

                    }

                    if (DangerForMate == true)
                        Mate = true;

                }

                return Mate;
            }

            // v0.990 changes
            public static bool CheckForWhiteCheck(string[,] WCSkakiera)
            {
                // Check if the WK is under check

                bool KingCheck;
                //v0.990
                int klopa;

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Εύρεση των συντεταγμένων του βασιλιά.
                // Αν σε κάποιο τετράγωνο βρεθεί ότι υπάρχει ένας βασιλιάς, τότε απλά καταγράφεται η τιμή του εν λόγω
                // τετραγώνου στις αντίστοιχες μεταβλητές που δηλώνουν τη στήλη και τη γραμμή στην οποία υπάρχει λευκός
                // βασιλιάς.
                // ΠΡΟΣΟΧΗ: Γράφω (i+1) αντί για i και (j+1) αντί για j γιατί το πρώτο στοιχείο του πίνακα WCWCSkakiera[(8),(8)]
                // είναι το WCSkakiera[(0),(0)] και ΟΧΙ το WCSkakiera[(1),(1)]!
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (WCSkakiera[(i), (j)].CompareTo("White King") == 0)
                        {
                            WhiteKingColumn = (i + 1);
                            WhiteKingRank = (j + 1);
                        }

                    }
                }

                ///////////////////////////////////////////////////////////////
                // Έλεγχος του αν ο λευκός βασιλιάς υφίσταται "σαχ"
                ///////////////////////////////////////////////////////////////

                KingCheck = false;

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Ελέγχουμε αρχικά αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΤΑ ΔΕΞΙΑ ΤΟΥ. Για να μην βγούμε έξω από τα
                // όρια της WCSkakiera[(8),(8)] έχουμε προσθέσει τον έλεγχο (WhiteKingColumn + 1) <= 8 στο "if". Αρχικά ο "κίνδυνος"
                // από τα "δεξιά" είναι υπαρκτός, άρα DangerFromRight = true. Ωστόσο αν βρεθεί ότι στα δεξιά του λευκού βασι-
                // λιά υπάρχει κάποιο λευκό κομμάτι, τότε δεν είναι δυνατόν ο εν λόγω βασιλιάς να υφίσταται σαχ από τα δεξιά
                // του (αφού θα "προστατεύεται" από το κομμάτι ιδίου χρώματος), οπότε η DangerFromRight = false και ο έλεγχος
                // για απειλές από τα δεξιά σταματάει (για αυτό και έχω προσθέσει την προϋπόθεση (DangerFromRight == true) στα
                // "if" που κάνουν αυτόν τον έλεγχο).
                // Αν όμως δεν υπάρχει κανένα λευκό κομμάτι δεξιά του βασιλιά για να τον προστατεύει, τότε συνεχίζει να
                // υπάρχει πιθανότητα να απειλείται ο βασιλιάς από τα δεξιά του, οπότε ο έλεγχος συνεχίζεται.
                // Σημείωση: Ο έλεγχος γίνεται για πιθανό σαχ από πύργο ή βασίλισσα αντίθετου χρώματος.
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromRight = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingColumn + klopa) <= 8) && (DangerFromRight == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("White Queen") == 0))
                            DangerFromRight = false;
                        else if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - 1)].CompareTo("Black King") == 0))
                            DangerFromRight = false;
                    }
                }


                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΤΑ ΑΡΙΣΤΕΡΑ ΤΟΥ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromLeft = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingColumn - klopa) >= 1) && (DangerFromLeft == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("White Queen") == 0))
                            DangerFromLeft = false;
                        else if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - 1)].CompareTo("Black King") == 0))
                            DangerFromLeft = false;
                    }
                }


                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΠΑΝΩ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////


                DangerFromUp = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingRank + klopa) <= 8) && (DangerFromUp == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            DangerFromUp = false;
                        else if ((WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black King") == 0))
                            DangerFromUp = false;
                    }
                }


                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΚΑΤΩ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDown = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingRank - klopa) >= 1) && (DangerFromDown == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            DangerFromDown = false;
                        else if ((WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black King") == 0))
                            DangerFromDown = false;
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΠΑΝΩ-ΔΕΞΙΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromUpRight = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingColumn + klopa) <= 8) && ((WhiteKingRank + klopa) <= 8) && (DangerFromUpRight == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            DangerFromUpRight = false;
                        else if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black King") == 0))
                            DangerFromUpRight = false;
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΚΑΤΩ-ΑΡΙΣΤΕΡΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDownLeft = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingColumn - klopa) >= 1) && ((WhiteKingRank - klopa) >= 1) && (DangerFromDownLeft == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            DangerFromDownLeft = false;
                        else if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black King") == 0))
                            DangerFromDownLeft = false;
                    }
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΚΑΤΩ-ΔΕΞΙΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDownRight = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingColumn + klopa) <= 8) && ((WhiteKingRank - klopa) >= 1) && (DangerFromDownRight == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            DangerFromDownRight = false;
                        else if ((WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn + klopa - 1), (WhiteKingRank - klopa - 1)].CompareTo("Black King") == 0))
                            DangerFromDownRight = false;
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το λευκό βασιλιά ΑΠΟ ΠΑΝΩ-ΑΡΙΣΤΕΡΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromUpLeft = true;

                for (klopa = 1; klopa <= 7; klopa++)
                {
                    if (((WhiteKingColumn - klopa) >= 1) && ((WhiteKingRank + klopa) <= 8) && (DangerFromUpLeft == true))
                    {
                        if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            KingCheck = true;
                        else if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            DangerFromUpLeft = false;
                        else if ((WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (WCSkakiera[(WhiteKingColumn - klopa - 1), (WhiteKingRank + klopa - 1)].CompareTo("Black King") == 0))
                            DangerFromUpLeft = false;
                    }
                }



                //////////////////////////////////////////////////////////////////////////
                // Έλεγχος για το αν ο λευκός βασιλιάς απειλείται από πιόνι.
                //////////////////////////////////////////////////////////////////////////

                if (((WhiteKingColumn + 1) <= 8) && ((WhiteKingRank + 1) <= 8))
                {
                    if (WCSkakiera[(WhiteKingColumn + 1 - 1), (WhiteKingRank + 1 - 1)].CompareTo("Black Pawn") == 0)
                    {
                        KingCheck = true;
                    }
                }


                if (((WhiteKingColumn - 1) >= 1) && ((WhiteKingRank + 1) <= 8))
                {
                    if (WCSkakiera[(WhiteKingColumn - 1 - 1), (WhiteKingRank + 1 - 1)].CompareTo("Black Pawn") == 0)
                    {
                        KingCheck = true;
                    }
                }


                ///////////////////////////////////////////////////////////////////////
                // Έλεγχος για το αν ο λευκός βασιλιάς απειλείται από ίππο.
                ///////////////////////////////////////////////////////////////////////

                if (((WhiteKingColumn + 1) <= 8) && ((WhiteKingRank + 2) <= 8))
                    if (WCSkakiera[(WhiteKingColumn + 1 - 1), (WhiteKingRank + 2 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn + 2) <= 8) && ((WhiteKingRank - 1) >= 1))
                    if (WCSkakiera[(WhiteKingColumn + 2 - 1), (WhiteKingRank - 1 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn + 1) <= 8) && ((WhiteKingRank - 2) >= 1))
                    if (WCSkakiera[(WhiteKingColumn + 1 - 1), (WhiteKingRank - 2 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 1) >= 1) && ((WhiteKingRank - 2) >= 1))
                    if (WCSkakiera[(WhiteKingColumn - 1 - 1), (WhiteKingRank - 2 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 2) >= 1) && ((WhiteKingRank - 1) >= 1))
                    if (WCSkakiera[(WhiteKingColumn - 2 - 1), (WhiteKingRank - 1 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 2) >= 1) && ((WhiteKingRank + 1) <= 8))
                    if (WCSkakiera[(WhiteKingColumn - 2 - 1), (WhiteKingRank + 1 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 1) >= 1) && ((WhiteKingRank + 2) <= 8))
                    if (WCSkakiera[(WhiteKingColumn - 1 - 1), (WhiteKingRank + 2 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn + 2) <= 8) && ((WhiteKingRank + 1) <= 8))
                    if (WCSkakiera[(WhiteKingColumn + 2 - 1), (WhiteKingRank + 1 - 1)].CompareTo("Black Knight") == 0)
                        KingCheck = true;

                return KingCheck;
            }

            // v0.990 changes
            public static bool CheckForWhiteMate(string[,] WMSkakiera)
            {
                // Check if the WK is under checkmate

                bool Mate;
                //v0.990: Changed MovingPiece and ProsorinoKommati with the CWM variables
                String MovingPieceCWM;
                String ProsorinoKommatiCWM;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Μεταβλητή που χρησιμεύει στον έλεγχο για το αν υπάρχει ματ (βλ. συναρτήσεις CheckForWhiteMate() και
                // CheckForBlMate()).
                // Αναλυτικότερα, το πρόγραμμα ελέγχει αν αρχικά υπάρχει σαχ και, αν υπάρχει, ελέγχει αν αυτό το
                // σαχ μπορεί να αποφευχθεί με τη μετακίνηση του υπό απειλή βασιλιά σε κάποιο γειτονικό τετράγωνο.
                // Η μεταβλητή καταγράφει το αν συνεχίζει να υπάρχει πιθανότητα να υπάρχει ματ στη σκακιέρα.
                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                bool DangerForMate;

                ////////////////////////////////////////////////////////////
                // Έλεγχος του αν υπάρχει "ματ" στον λευκό βασιλιά
                ////////////////////////////////////////////////////////////

                Mate = false;
                DangerForMate = true;    // Αρχικά, προφανώς υπάρχει πιθανότητα να υπάρχει ματ στη σκακιέρα.
                                         // Αν, ωστόσο, κάποια στιγμή βρεθεί ότι αν ο βασιλιάς μπορεί να μετακινηθεί
                                         // σε ένα διπλανό τετράγωνο και να πάψει να υφίσταται σαχ, τότε παύει να
                                         // υπάρχει πιθανότητα να υπάρχει ματ (προφανώς) και η μεταβλητή παίρνει την
                                         // τιμή false.


                //////////////////////////////////////////////////////////////
                // Εύρεση των αρχικών συντεταγμένων του βασιλιά
                //////////////////////////////////////////////////////////////

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (WMSkakiera[(i), (j)].CompareTo("White King") == 0)
                        {
                            StartingWhiteKingColumn = (i + 1);
                            StartingWhiteKingRank = (j + 1);
                        }

                    }
                }


                //////////////////////////////////////////////////
                // Έλεγχος αν ο λευκός βασιλιάς είναι ματ
                //////////////////////////////////////////////////


                if (m_WhichColorPlays.CompareTo("White") == 0)
                {

                    ////////////////////////////////////////////////
                    // Έλεγχος αν υπάρχει σαχ αυτή τη στιγμή
                    ////////////////////////////////////////////////

                    WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                    if (WhiteKingCheck == false)     // Αν αυτή τη στιγμή δεν υφίσταται σαχ, τότε να μη συνεχιστεί ο έλεγχος
                        DangerForMate = false;         // καθώς ΔΕΝ συνεχίζει να υφίσταται πιθανότητα να υπάρχει ματ.

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingRank < 8)
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 + 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.
                            // Ο έλεγχος γίνεται μόνο αν στο τετράγωνο που μετακινείται προσωρινά ο βασιλιάς δεν υπάρχει άλλο κομμάτι
                            // του ίδιου χρώματος που να τον εμποδίζει και αν, φυσικά, ο βασιλιάς δεν βγαίνει έξω από τη σκακιέρα με
                            // αυτή του την κίνηση και αν, προφανώς, συνεχίζει να υπάρχει πιθανότητα να ύπάρχει ματ (καθώς αν δεν
                            // υπάρχει τέτοια πιθανότητα, τότε ο έλεγχος είναι άχρηστος).

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 + 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 + 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn < 8) && (StartingWhiteKingRank < 8))
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 + 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 + 1) <= 7) && ((StartingWhiteKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 + 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 + 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingColumn < 8)
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn < 8) && (StartingWhiteKingRank > 1))
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 - 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 - 1) >= 0) && ((StartingWhiteKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 - 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 - 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingRank > 1)
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 - 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 - 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 - 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn > 1) && (StartingWhiteKingRank > 1))
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 - 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 - 1) >= 0) && ((StartingWhiteKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 - 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 - 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingColumn > 1)
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1)] = ProsorinoKommatiCWM;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn > 1) && (StartingWhiteKingRank < 8))
                    {

                        MovingPieceCWM = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommatiCWM = WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 + 1)];

                        if ((ProsorinoKommatiCWM.CompareTo("White Queen") == 1) && (ProsorinoKommatiCWM.CompareTo("White Rook") == 1) && (ProsorinoKommatiCWM.CompareTo("White Knight") == 1) && (ProsorinoKommatiCWM.CompareTo("White Bishop") == 1) && (ProsorinoKommatiCWM.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 + 1) <= 7) && ((StartingWhiteKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 + 1)] = MovingPieceCWM;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPieceCWM;
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 + 1)] = ProsorinoKommatiCWM;

                        }

                    }

                    if (DangerForMate == true)
                        Mate = true;

                }

                return Mate;
            }

            // v0.990 changes
            public static void CheckMove(string[,] CMSkakiera, int m_StartingRankCM, int m_StartingColumnNumberCM, int m_FinishingRankCM, int m_FinishingColumnNumberCM, String MovingPieceCM)
            {
                #region WriteLog
                if (activateLogs == true)
                {
                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("ChMo -- Entered CheckMove");
                    huo_sw1.WriteLine(string.Concat("ChMo -- Depth analyzed: ", Move_Analyzed.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                    huo_sw1.WriteLine("");
                }
                #endregion WriteLog

                String ProsorinoKommatiCM;

                for (int iii = 0; iii <= 7; iii++)
                {
                    for (int jjj = 0; jjj <= 7; jjj++)
                    {
                        Skakiera_CM_Check[iii, jjj] = CMSkakiera[(iii), (jjj)];
                    }
                }

                number_of_moves_analysed++;

                m_WhoPlays = "Human";
                m_WrongColumn = false;

                // Check correctness of move
                m_OrthotitaKinisis = ElegxosOrthotitas(CMSkakiera, 0, m_StartingRankCM, m_StartingColumnNumberCM, m_FinishingRankCM, m_FinishingColumnNumberCM, MovingPieceCM);
                // if move is correct, then check the legality also
                if (m_OrthotitaKinisis == true)
                    m_NomimotitaKinisis = ElegxosNomimotitas(CMSkakiera, 0, m_StartingRankCM, m_StartingColumnNumberCM, m_FinishingRankCM, m_FinishingColumnNumberCM, MovingPieceCM);

                // Restore the normal value of the m_WhoPlays
                m_WhoPlays = "HY";

                #region CheckCheck

                // Temporarily move the piece to see if the king will continue to be under check
                Skakiera_CM_Check[(m_StartingColumnNumberCM - 1), (m_StartingRankCM - 1)] = "";
                ProsorinoKommatiCM = Skakiera_CM_Check[(m_FinishingColumnNumberCM - 1), (m_FinishingRankCM - 1)];
                // Προσωρινή αποθήκευση του κομματιού που βρίσκεται στο τετράγωνο προορισμού
                // (βλ. μετά για τη χρησιμότητα του, εκεί που γίνεται έλεγχος για το αν συνεχίζει να υφίσταται σαχ).
                Skakiera_CM_Check[(m_FinishingColumnNumberCM - 1), (m_FinishingRankCM - 1)] = MovingPieceCM;

                #region Remove
                //v0.990: Need to check again the dangerous squares? The computer might attempt to move
                //        his piece to a square where the moving piece was the only defender!
                //v0.990 change: The dangerous squares must be checked AGAIN after the move!
                //The moving piece might be moving into a dangerous square!
                //v0.990 change: Added this section here!
                /*
                #region DangerousSquares
           
                Danger_for_piece = false;

                for (int o1 = 0; o1 <= 7; o1++)
                {
                    for (int p1 = 0; p1 <= 7; p1++)
                    {
                        //v0.980: Change small Strings to Int
                        Skakiera_Dangerous_Squares_2[(o1), (p1)] = 0;
                    }
                }

                // Find attackers-defenders
                FindAttackers(CMSkakiera);
                FindDefenders(CMSkakiera);

                // Determine dangerous squares
                for (int o1 = 0; o1 <= 7; o1++)
                {
                    for (int p1 = 0; p1 <= 7; p1++)
                    {
                        //v0.990 debug
                        //MessageBox.Show(String.Concat("Number of attackers for ", (o1 + 1).ToString(), (p1 + 1).ToString(), " : ", Number_of_attackers[o1, p1].ToString()));
                        //MessageBox.Show(String.Concat("Number of defenders for ", (o1 + 1).ToString(), (p1 + 1).ToString(), " : ", Number_of_defenders[o1, p1].ToString()));

                        //v0.990 change: Changed ">" to ">="
                        if (Number_of_attackers[o1, p1] >= Number_of_defenders[o1, p1])
                            //if (Number_of_attackers[o1, p1] > Number_of_defenders[o1, p1])
                            //v0.980: Change small Strings to Int
                            Skakiera_Dangerous_Squares_2[(o1), (p1)] = 1;
                    }
                }
                #endregion DangerousSquares

                if(Skakiera_Dangerous_Squares_2[(m_FinishingColumnNumberCM - 1), (m_FinishingRankCM - 1)] == 1)
                    m_NomimotitaKinisis = false;
                */
                #endregion Remove

                //////////////////////////////////////////////////////////////////////////
                // is the king still under check?
                //////////////////////////////////////////////////////////////////////////

                //v0.990
                WhiteKingCheck = CheckForWhiteCheck(Skakiera_CM_Check);
                //WhiteKingCheck = CheckForWhiteCheck(CMSkakiera);

                if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
                {
                    m_NomimotitaKinisis = false;
                }

                ///////////////////////////////////////////////////////////////////////////
                // is the black king under check?
                ///////////////////////////////////////////////////////////////////////////

                //v0.990
                //BlackKingCheck = CheckForBlackCheck(CMSkakiera);
                BlackKingCheck = CheckForBlackCheck(Skakiera_CM_Check);

                if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
                {
                    m_NomimotitaKinisis = false;
                }

                // Restore pieces to their initial positions
                // CMSkakiera[(m_StartingColumnNumberCM - 1), (m_StartingRankCM - 1)] = MovingPieceCM;
                // CMSkakiera[(m_FinishingColumnNumberCM - 1), (m_FinishingRankCM - 1)] = ProsorinoKommatiCM;
                #endregion CheckCheck

            }

            public static void ComputerMove(string[,] Skakiera_Thinking_init)
            {
                // v0.991: Ability to activate/ deactivate logs easily
                #region WriteLog
                if (activateLogs == true)
                {
                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("CoMo -- Entered ComputerMove");
                    huo_sw1.WriteLine(string.Concat("CoMo -- Depth analyzed: ", Move_Analyzed.ToString()));
                    huo_sw1.WriteLine(string.Concat("CoMo -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                    huo_sw1.WriteLine(string.Concat("CoMo -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                    huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));

                    #region checkInitialComputerMoveValues
                    ////Write initial values of variables (to solve the variables initialization issue - SOLVED)
                    //huo_sw1.WriteLine("Global Variables...");
                    //huo_sw1.WriteLine(String.Concat("DoNotMakeStupidMove           : ", ThisIsStupidMove));
                    //huo_sw1.WriteLine(String.Concat("Danger_for_piece              : ", Danger_for_piece.ToString()));
                    //huo_sw1.WriteLine(String.Concat("possibility_to_eat_back       : ", possibility_to_eat_back.ToString()));
                    //huo_sw1.WriteLine(String.Concat("ValueOfHumanMovingPiece       : ", ValueOfHumanMovingPiece.ToString()));
                    //huo_sw1.WriteLine(String.Concat("ValueOfMovingPiece            : ", ValueOfMovingPiece.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Temp_Score_Move_0             : ", Temp_Score_Move_0.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Temp_Score_Move_1_human       : ", Temp_Score_Move_1_human.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Temp_Score_Move_2             : ", Temp_Score_Move_2.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Nodes_Total_count             : ", Nodes_Total_count.ToString()));
                    //huo_sw1.WriteLine(String.Concat("NodeLevel_0_count             : ", NodeLevel_0_count.ToString()));
                    //huo_sw1.WriteLine(String.Concat("NodeLevel_1_count             : ", NodeLevel_1_count.ToString()));
                    //huo_sw1.WriteLine(String.Concat("NodeLevel_2_count             : ", NodeLevel_2_count.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Human_last_move_target_column : ", Human_last_move_target_column.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Human_last_move_target_row    : ", Human_last_move_target_row.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_PlayerColor                 : ", m_PlayerColor));
                    //huo_sw1.WriteLine(String.Concat("m_WhoPlays                    : ", m_WhoPlays));
                    //huo_sw1.WriteLine(String.Concat("m_WhichColorPlays             : ", m_WhichColorPlays));
                    //huo_sw1.WriteLine(String.Concat("MovingPiece                   : ", MovingPiece));
                    //huo_sw1.WriteLine(String.Concat("ProsorinoKommati              : ", ProsorinoKommati));
                    //huo_sw1.WriteLine(String.Concat("exit_elegxos_nomimothtas      : ", exit_elegxos_nomimothtas.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Move_Analyzed                 : ", Move_Analyzed.ToString()));
                    //huo_sw1.WriteLine(String.Concat("First_Call                    : ", First_Call.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Who_Is_Analyzed               : ", Who_Is_Analyzed.ToString()));
                    //huo_sw1.WriteLine(String.Concat("First_Call                    : ", Stop_Analyzing.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Stop_Analyzing                : ", First_Call.ToString()));
                    //huo_sw1.WriteLine(String.Concat("h                             : ", h.ToString()));
                    //huo_sw1.WriteLine(String.Concat("p                             : ", p.ToString()));
                    //huo_sw1.WriteLine(String.Concat("KingCheck                     : ", KingCheck.ToString()));
                    ////huo_sw1.WriteLine(String.Concat("m_StartingRank              : ", m_StartingRank.ToString()));
                    ////huo_sw1.WriteLine(String.Concat("m_StartingColumn            : ", m_StartingColumn.ToString()));
                    ////huo_sw1.WriteLine(String.Concat("m_FinishingColumn           : ", m_FinishingColumn.ToString()));
                    ////huo_sw1.WriteLine(String.Concat("m_FinishingRank             : ", m_FinishingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("enpassant_occured             : ", enpassant_occured.ToString()));
                    //huo_sw1.WriteLine(String.Concat("number_of_moves_analysed      : ", number_of_moves_analysed.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Promotion_Occured             : ", Promotion_Occured.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Castling_Occured              : ", Castling_Occured.ToString()));
                    //huo_sw1.WriteLine(String.Concat("WhiteKingColumn               : ", WhiteKingColumn.ToString()));
                    //huo_sw1.WriteLine(String.Concat("WhiteKingRank                 : ", WhiteKingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("BlKingColumn                  : ", BlKingColumn.ToString()));
                    //huo_sw1.WriteLine(String.Concat("BlKingRank                    : ", BlKingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("WhiteKingCheck                : ", WhiteKingCheck.ToString()));
                    //huo_sw1.WriteLine(String.Concat("BlackKingCheck                : ", BlackKingCheck.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Best_Move_Found               : ", Best_Move_Found.ToString()));
                    //huo_sw1.WriteLine(String.Concat("DangerFromDown                : ", DangerFromDown.ToString()));
                    //huo_sw1.WriteLine(String.Concat("DangerFromDownLeft            : ", DangerFromDownLeft.ToString()));
                    //huo_sw1.WriteLine(String.Concat("DangerFromDownRight           : ", DangerFromDownRight.ToString()));
                    //huo_sw1.WriteLine(String.Concat("DangerFromLeft                : ", DangerFromLeft.ToString()));
                    //huo_sw1.WriteLine(String.Concat("DangerFromRight               : ", DangerFromRight.ToString()));
                    //huo_sw1.WriteLine(String.Concat("DangerFromUp                  : ", DangerFromUp.ToString()));
                    //huo_sw1.WriteLine(String.Concat("StartingBlKingColumn          : ", StartingBlKingColumn.ToString()));
                    //huo_sw1.WriteLine(String.Concat("StartingBlKingRank            : ", StartingBlKingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("StartingWhiteKingColumn       : ", StartingWhiteKingColumn.ToString()));
                    //huo_sw1.WriteLine(String.Concat("StartingWhiteKingRank         : ", StartingWhiteKingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_OrthotitaKinisis            : ", m_OrthotitaKinisis.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_NomimotitaKinisis           : ", m_NomimotitaKinisis.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_WrongColumn                 : ", m_WrongColumn.ToString()));
                    //huo_sw1.WriteLine(String.Concat("i                             : ", i.ToString()));
                    //huo_sw1.WriteLine(String.Concat("j                             : ", j.ToString()));
                    //huo_sw1.WriteLine(String.Concat("ApophasiXristi                : ", ApophasiXristi.ToString()));
                    //huo_sw1.WriteLine(String.Concat("choise_of_user                : ", choise_of_user.ToString()));

                    //huo_sw1.WriteLine(String.Concat("Skakiera_Move_0               : ", Skakiera_Move_0.ToString()));

                    ////for (i = 0; i <= 7; i++)
                    ////{
                    ////    huo_sw1.WriteLine(String.Concat(Skakiera_Move_0[i, 0].ToString(),
                    ////                                    Skakiera_Move_0[i, 1].ToString(),
                    ////                                    Skakiera_Move_0[i, 2].ToString(),
                    ////                                    Skakiera_Move_0[i, 3].ToString(),
                    ////                                    Skakiera_Move_0[i, 4].ToString(),
                    ////                                    Skakiera_Move_0[i, 5].ToString(),
                    ////                                    Skakiera_Move_0[i, 6].ToString(),
                    ////                                    Skakiera_Move_0[i, 7].ToString()));
                    ////}

                    //huo_sw1.WriteLine(String.Concat("Skakiera_Thinking             : ", Skakiera_Thinking.ToString()));

                    ////for (i = 0; i <= 7; i++)
                    ////{
                    ////    huo_sw1.WriteLine(String.Concat(Skakiera_Thinking[i, 0].ToString(),
                    ////                                    Skakiera_Thinking[i, 1].ToString(),
                    ////                                    Skakiera_Thinking[i, 2].ToString(),
                    ////                                    Skakiera_Thinking[i, 3].ToString(),
                    ////                                    Skakiera_Thinking[i, 4].ToString(),
                    ////                                    Skakiera_Thinking[i, 5].ToString(),
                    ////                                    Skakiera_Thinking[i, 6].ToString(),
                    ////                                    Skakiera_Thinking[i, 7].ToString()));
                    ////}

                    //huo_sw1.WriteLine(String.Concat("Current_Move_Score            : ", Current_Move_Score.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Best_Move_FinishingColumnNumber : ", Best_Move_FinishingColumnNumber.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Best_Move_FinishingRank         : ", Best_Move_FinishingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Best_Move_StartingColumnNumber  : ", Best_Move_StartingColumnNumber.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Best_Move_StartingRank        : ", Best_Move_StartingRank.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Best_Move_Found               : ", Best_Move_Found.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Move_Analyzed                 : ", Move_Analyzed.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Stop_Analyzing                : ", Stop_Analyzing.ToString()));
                    //huo_sw1.WriteLine(String.Concat("Thinking_Depth                : ", Thinking_Depth.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_StartingColumnNumber_HY     : ", m_StartingColumnNumber_HY.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_StartingRank_HY             : ", m_StartingRank_HY.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_FinishingColumnNumber_HY    : ", m_FinishingColumnNumber_HY.ToString()));
                    //huo_sw1.WriteLine(String.Concat("m_FinishingRank_HY            : ", m_FinishingRank_HY.ToString()));
                    ////huo_sw1.WriteLine(String.Concat("MovingPiece_HY                : ", MovingPiece_HY.ToString()));
                    //huo_sw1.WriteLine(String.Concat("enpassant_occured             : ", enpassant_occured.ToString()));
                    //huo_sw1.WriteLine(String.Concat("enpassant_possible_target_column          : ", enpassant_possible_target_column.ToString()));
                    //huo_sw1.WriteLine(String.Concat("First_Caenpassant_possible_target_rankll  : ", enpassant_possible_target_rank.ToString()));

                    ////huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                    ////huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                    ////huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                    ////huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));

                    //////v0.990
                    ////huo_sw1.WriteLine("");
                    ////huo_sw1.WriteLine("CHESSBOARD when calling ComputerMove");
                    ////huo_sw1.WriteLine("-----------------------------------------");
                    ////for (int yj = 7; yj >= 0; yj--)
                    ////{
                    ////    huo_sw1.WriteLine(String.Concat("| ", Skakiera_Thinking_init[0, yj], " | ", Skakiera_Thinking_init[1, yj], " | ", Skakiera_Thinking_init[2, yj], " | ", Skakiera_Thinking_init[3, yj], " | ", Skakiera_Thinking_init[4, yj], " | ", Skakiera_Thinking_init[5, yj], " | ", Skakiera_Thinking_init[6, yj], " | ", Skakiera_Thinking_init[7, yj], " |"));
                    ////    huo_sw1.WriteLine("-----------------------------------------");
                    ////}
                    ////huo_sw1.WriteLine("");
                    #endregion checkInitialComputerMoveValues

                    //#region WriteLog
                    //v0.990
                    for (i = 0; i <= 7; i++)
                    {
                        for (j = 0; j <= 7; j++)
                        {
                            switch (Skakiera_Thinking_init[(i), (j)])
                            {
                                case "White Rook":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "WR";
                                    break;

                                case "White Knight":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "WN";
                                    break;

                                case "White Bishop":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "WB";
                                    break;

                                case "White Queen":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "WQ";
                                    break;

                                case "White King":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "WK";
                                    break;

                                case "White Pawn":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "WP";
                                    break;

                                case "Black Rook":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "BR";
                                    break;

                                case "Black Knight":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "BN";
                                    break;

                                case "Black Bishop":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "BB";
                                    break;

                                case "Black Queen":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "BQ";
                                    break;

                                case "Black King":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "BK";
                                    break;

                                case "Black Pawn":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "BP";
                                    break;

                                case "":
                                    NodesAnalysis0_Chessboard_before[i, j, NodeLevel_0_count] = "  ";
                                    break;
                            }
                        }
                    }

                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("CHESSBOARD Computer Move (upon calling function)");
                    huo_sw1.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw1.WriteLine(String.Concat("| ", NodesAnalysis0_Chessboard_before[0, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[1, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[2, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[3, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[4, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[5, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[6, yj, NodeLevel_0_count], " | ", NodesAnalysis0_Chessboard_before[7, yj, NodeLevel_0_count], " |"));
                        huo_sw1.WriteLine("-----------------------------------------");
                    }
                    huo_sw1.WriteLine("CHESSBOARD END");
                    //huo_sw1.WriteLine("");
                    //#endregion WriteLog

                    ////huo_sw1.WriteLine("");
                }
                #endregion WriteLog

                //v0.990: Added to be sure that all variables are the same at every cycle. Potentially not needed.
                #region Initialize
                // v0.990 change: The best score for every move will be stored at each level. Only if the new move analyzed
                // has a better score than the best score, will it be analyzed (target: trim the analysis tree)
                int bestScoreLevel0 = 0;
                //V0.990: Initialized the values
                int iii = 0;
                int jjj = 0;
                Temp_Score_Move_0 = 0;
                Temp_Score_Move_1_human = 0;
                Temp_Score_Move_2 = 0;
                Human_last_move_target_column = 0;
                Human_last_move_target_row = 0;
                MovingPiece = "";
                ProsorinoKommati = "";
                exit_elegxos_nomimothtas = false;
                First_Call = true;
                h = 0;
                p = 0;
                WhiteKingColumn = 0;
                WhiteKingRank = 0;
                BlKingColumn = 0;
                BlKingRank = 0;
                DangerFromUp = false;
                m_OrthotitaKinisis = false;
                m_NomimotitaKinisis = false;
                i = 0;
                j = 0;
                Current_Move_Score = 0;
                Best_Move_FinishingColumnNumber = 0;
                Best_Move_FinishingRank = 0;
                Best_Move_StartingColumnNumber = 0;
                Best_Move_StartingRank = 0;
                Stop_Analyzing = true;
                m_StartingColumnNumber_HY = 0;
                m_StartingRank_HY = 0;
                m_FinishingColumnNumber_HY = 0;
                m_FinishingRank_HY = 0;
                enpassant_possible_target_column = 0;
                //First_Caenpassant_possible_target_rankll = 0;
                //v0.990: Removed the "0" variables.
                //String MovingPiece;
                //String ProsorinoKommati0;
                //int m_StartingColumnNumber;
                //int m_FinishingColumnNumber;
                //int m_StartingRank;
                //int m_FinishingRank;
                // v0.991
                Best_Variant_text = "";

                //v0.990
                String[,] Skakiera_Move_After_0 = new String[8, 8];

                // If there is a possibility to eat back what was eaten, then go for it!
                possibility_to_eat_back = false;
                possibility_to_eat = false;

                #region InitializeNodes
                // START [MiniMax algorithm - skakos]
                NodeLevel_0_count = 0;
                NodeLevel_1_count = 0;
                NodeLevel_2_count = 0;
                //v0.980: Removed unwanted nodes (+total nodes)
                //NodeLevel_3_count = 0;
                //NodeLevel_4_count = 0;
                Nodes_Total_count = 0;

                //v0.990 Added initialization of variables
                ValueOfHumanMovingPiece = 0;
                ValueOfMovingPiece = 0;

                //0.970 comment out
                //for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                //{
                //    for (int dimension2 = 0; dimension2 < 26; dimension2++)
                //    {
                //        for (int dimension3 = 0; dimension3 < 2; dimension3++)
                //        {
                //            NodesAnalysis[dimension1, dimension2, dimension3] = 0;
                //        }
                //    }
                //}

                //0.970
                for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                {
                    for (int dimension2 = 0; dimension2 < 6; dimension2++)
                    {
                        NodesAnalysis0[dimension1, dimension2] = 0;
                    }
                }

                for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                {
                    for (int dimension2 = 0; dimension2 < 2; dimension2++)
                    {
                        NodesAnalysis1[dimension1, dimension2] = 0;
                        NodesAnalysis2[dimension1, dimension2] = 0;
                        //NodesAnalysis3[dimension1, dimension2] = 0;
                    }
                }

                // v0.991
                for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                {
                    NodesAnalysis0_MoveText[dimension1] = "";
                    NodesAnalysis1_MoveText[dimension1] = "";
                    NodesAnalysis2_MoveText[dimension1] = "";
                }

                #endregion InitializeNodes

                #endregion Initialize

                // v0.992: Is this needed at all?
                #region StoreInitialPosition
                // Store the initial position in the chessboard
                for (iii = 0; iii <= 7; iii++)
                {
                    for (jjj = 0; jjj <= 7; jjj++)
                    {
                        Skakiera_Thinking[iii, jjj] = Skakiera_Thinking_init[(iii), (jjj)];
                        Skakiera_Move_0[(iii), (jjj)] = Skakiera_Thinking_init[(iii), (jjj)];
                    }
                }
                #endregion StoreInitialPosition

                #region WriteLog
                //// Write log after the initialization
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("Global Variables after initialization...");
                //huo_sw1.WriteLine(String.Concat("DoNotMakeStupidMove           : ", ThisIsStupidMove));
                //huo_sw1.WriteLine(String.Concat("Danger_for_piece              : ", Danger_for_piece.ToString()));
                //huo_sw1.WriteLine(String.Concat("possibility_to_eat_back       : ", possibility_to_eat_back.ToString()));
                //huo_sw1.WriteLine(String.Concat("ValueOfHumanMovingPiece       : ", ValueOfHumanMovingPiece.ToString()));
                //huo_sw1.WriteLine(String.Concat("ValueOfMovingPiece            : ", ValueOfMovingPiece.ToString()));
                //huo_sw1.WriteLine(String.Concat("Temp_Score_Move_0             : ", Temp_Score_Move_0.ToString()));
                //huo_sw1.WriteLine(String.Concat("Temp_Score_Move_1_human       : ", Temp_Score_Move_1_human.ToString()));
                //huo_sw1.WriteLine(String.Concat("Temp_Score_Move_2             : ", Temp_Score_Move_2.ToString()));
                //huo_sw1.WriteLine(String.Concat("Nodes_Total_count             : ", Nodes_Total_count.ToString()));
                //huo_sw1.WriteLine(String.Concat("NodeLevel_0_count             : ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(String.Concat("NodeLevel_1_count             : ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(String.Concat("NodeLevel_2_count             : ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(String.Concat("Human_last_move_target_column : ", Human_last_move_target_column.ToString()));
                //huo_sw1.WriteLine(String.Concat("Human_last_move_target_row    : ", Human_last_move_target_row.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_PlayerColor                 : ", m_PlayerColor));
                //huo_sw1.WriteLine(String.Concat("m_WhoPlays                    : ", m_WhoPlays));
                //huo_sw1.WriteLine(String.Concat("m_WhichColorPlays             : ", m_WhichColorPlays));
                //huo_sw1.WriteLine(String.Concat("MovingPiece                   : ", MovingPiece));
                //huo_sw1.WriteLine(String.Concat("ProsorinoKommati              : ", ProsorinoKommati));
                //huo_sw1.WriteLine(String.Concat("exit_elegxos_nomimothtas      : ", exit_elegxos_nomimothtas.ToString()));
                //huo_sw1.WriteLine(String.Concat("Move_Analyzed                 : ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(String.Concat("First_Call                    : ", First_Call.ToString()));
                //huo_sw1.WriteLine(String.Concat("Who_Is_Analyzed               : ", Who_Is_Analyzed.ToString()));
                //huo_sw1.WriteLine(String.Concat("First_Call                    : ", Stop_Analyzing.ToString()));
                //huo_sw1.WriteLine(String.Concat("Stop_Analyzing                : ", First_Call.ToString()));
                //huo_sw1.WriteLine(String.Concat("h                             : ", h.ToString()));
                //huo_sw1.WriteLine(String.Concat("p                             : ", p.ToString()));
                //huo_sw1.WriteLine(String.Concat("KingCheck                     : ", KingCheck.ToString()));
                ////huo_sw1.WriteLine(String.Concat("m_StartingRank              : ", m_StartingRank.ToString()));
                ////huo_sw1.WriteLine(String.Concat("m_StartingColumn            : ", m_StartingColumn.ToString()));
                ////huo_sw1.WriteLine(String.Concat("m_FinishingColumn           : ", m_FinishingColumn.ToString()));
                ////huo_sw1.WriteLine(String.Concat("m_FinishingRank             : ", m_FinishingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("enpassant_occured             : ", enpassant_occured.ToString()));
                //huo_sw1.WriteLine(String.Concat("number_of_moves_analysed      : ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(String.Concat("Promotion_Occured             : ", Promotion_Occured.ToString()));
                //huo_sw1.WriteLine(String.Concat("Castling_Occured              : ", Castling_Occured.ToString()));
                //huo_sw1.WriteLine(String.Concat("WhiteKingColumn               : ", WhiteKingColumn.ToString()));
                //huo_sw1.WriteLine(String.Concat("WhiteKingRank                 : ", WhiteKingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("BlKingColumn                  : ", BlKingColumn.ToString()));
                //huo_sw1.WriteLine(String.Concat("BlKingRank                    : ", BlKingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("WhiteKingCheck                : ", WhiteKingCheck.ToString()));
                //huo_sw1.WriteLine(String.Concat("BlackKingCheck                : ", BlackKingCheck.ToString()));
                //huo_sw1.WriteLine(String.Concat("Best_Move_Found               : ", Best_Move_Found.ToString()));
                //huo_sw1.WriteLine(String.Concat("DangerFromDown                : ", DangerFromDown.ToString()));
                //huo_sw1.WriteLine(String.Concat("DangerFromDownLeft            : ", DangerFromDownLeft.ToString()));
                //huo_sw1.WriteLine(String.Concat("DangerFromDownRight           : ", DangerFromDownRight.ToString()));
                //huo_sw1.WriteLine(String.Concat("DangerFromLeft                : ", DangerFromLeft.ToString()));
                //huo_sw1.WriteLine(String.Concat("DangerFromRight               : ", DangerFromRight.ToString()));
                //huo_sw1.WriteLine(String.Concat("DangerFromUp                  : ", DangerFromUp.ToString()));
                //huo_sw1.WriteLine(String.Concat("StartingBlKingColumn          : ", StartingBlKingColumn.ToString()));
                //huo_sw1.WriteLine(String.Concat("StartingBlKingRank            : ", StartingBlKingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("StartingWhiteKingColumn       : ", StartingWhiteKingColumn.ToString()));
                //huo_sw1.WriteLine(String.Concat("StartingWhiteKingRank         : ", StartingWhiteKingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_OrthotitaKinisis            : ", m_OrthotitaKinisis.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_NomimotitaKinisis           : ", m_NomimotitaKinisis.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_WrongColumn                 : ", m_WrongColumn.ToString()));
                //huo_sw1.WriteLine(String.Concat("i                             : ", i.ToString()));
                //huo_sw1.WriteLine(String.Concat("j                             : ", j.ToString()));
                //huo_sw1.WriteLine(String.Concat("ApophasiXristi                : ", ApophasiXristi.ToString()));
                //huo_sw1.WriteLine(String.Concat("choise_of_user                : ", choise_of_user.ToString()));
                //huo_sw1.WriteLine(String.Concat("Skakiera_Move_0               : ", Skakiera_Move_0.ToString()));
                //huo_sw1.WriteLine(String.Concat("Skakiera_Thinking             : ", Skakiera_Thinking.ToString()));
                //huo_sw1.WriteLine(String.Concat("Current_Move_Score            : ", Current_Move_Score.ToString()));
                //huo_sw1.WriteLine(String.Concat("Best_Move_FinishingColumnNumber : ", Best_Move_FinishingColumnNumber.ToString()));
                //huo_sw1.WriteLine(String.Concat("Best_Move_FinishingRank         : ", Best_Move_FinishingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("Best_Move_StartingColumnNumber  : ", Best_Move_StartingColumnNumber.ToString()));
                //huo_sw1.WriteLine(String.Concat("Best_Move_StartingRank        : ", Best_Move_StartingRank.ToString()));
                //huo_sw1.WriteLine(String.Concat("Best_Move_Found               : ", Best_Move_Found.ToString()));
                //huo_sw1.WriteLine(String.Concat("Move_Analyzed                 : ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(String.Concat("Stop_Analyzing                : ", Stop_Analyzing.ToString()));
                //huo_sw1.WriteLine(String.Concat("Thinking_Depth                : ", Thinking_Depth.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_StartingColumnNumber_HY     : ", m_StartingColumnNumber_HY.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_StartingRank_HY             : ", m_StartingRank_HY.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_FinishingColumnNumber_HY    : ", m_FinishingColumnNumber_HY.ToString()));
                //huo_sw1.WriteLine(String.Concat("m_FinishingRank_HY            : ", m_FinishingRank_HY.ToString()));
                ////huo_sw1.WriteLine(String.Concat("MovingPiece_HY                : ", MovingPiece_HY.ToString()));
                //huo_sw1.WriteLine(String.Concat("enpassant_occured             : ", enpassant_occured.ToString()));
                //huo_sw1.WriteLine(String.Concat("enpassant_possible_target_column          : ", enpassant_possible_target_column.ToString()));
                //huo_sw1.WriteLine(String.Concat("First_Caenpassant_possible_target_rankll  : ", enpassant_possible_target_rank.ToString()));
                #endregion WriteLog

                // v0.991: Add (again) opening book capability
                #region OpeningBook
                ////////////////////////////////////////////////////////////////////////
                // CHECK IF POSITION IS IN THE OPENING BOOK
                ////////////////////////////////////////////////////////////////////////

                int op_iii;
                int op_jjj;
                bool foundOpening;

                int opening = 1;
                foundOpening = false;

                bool exit_opening_loop = false;
                // Μεταβλητή που καταδεικνύει το αν υπάρχει ταίριασμα της παρούσας θέσης με κάποια από τις θέσεις που υπάρχουν αποθηκευμένες στο βιβλίο ανοιγμάτων του ΗΥ
                bool match_found;

                String line_in_opening_book;

                do
                {
                    if (File.Exists(String.Concat("Huo Chess Opening Book\\", opening.ToString(), ".txt")))
                    {
                        // Άνοιγμα των αρχείων .txt που περιέχει η βάση δεδομένων του ΗΥ
                        StreamReader sr = new StreamReader(String.Concat("Huo Chess Opening Book\\", opening.ToString(), ".txt"));
                        match_found = true;

                        for (op_iii = 0; op_iii <= 7; op_iii++)
                        {
                            for (op_jjj = 0; op_jjj <= 7; op_jjj++)
                            {
                                line_in_opening_book = sr.ReadLine();
                                if (Skakiera_Thinking[op_iii, op_jjj].CompareTo(line_in_opening_book) != 0)
                                    match_found = false;
                            }
                        }

                        // Αν βρέθηκε μια θέση που είναι αποθηκευμένη στο βιβλίο ανοιγμάτων,
                        // τότε διάβασε και τις επόμενες σειρές στο αρχείο text οι οποίες περιέχουν
                        // την κίνηση που πρέπει να κάνει ο ΗΥ στην παρούσα θέση.

                        if (match_found == true)
                        {
                            // Αφού βρέθηκε θέση, τότε δεν χρειάζεται περαιτέρω ανάλυση.
                            exit_opening_loop = true;

                            // Αφού βρέθηκε θέση, τότε ο ΗΥ δεν χρειάζεται να σκεφτεί για την κίνηση του, την έχει βρει έτοιμη!
                            Stop_Analyzing = true;

                            // Διάβασμα της κενής γραμμής που υπάρχει στο αρχείο.
                            line_in_opening_book = sr.ReadLine();

                            line_in_opening_book = sr.ReadLine();
                            Best_Move_StartingColumnNumber = Int32.Parse(line_in_opening_book);
                            line_in_opening_book = sr.ReadLine();
                            Best_Move_StartingRank = Int32.Parse(line_in_opening_book);

                            line_in_opening_book = sr.ReadLine();
                            Best_Move_FinishingColumnNumber = Int32.Parse(line_in_opening_book);
                            line_in_opening_book = sr.ReadLine();
                            Best_Move_FinishingRank = Int32.Parse(line_in_opening_book);

                            foundOpening = true;
                            //MessageBox.Show("Found position in opening book!");
                        }
                    }
                    else
                    {
                        exit_opening_loop = true;
                    }

                    opening = opening + 1;
                } while (exit_opening_loop == false);

                //////////////////////////////////////
                // END OF OPENING BOOK CHECK
                //////////////////////////////////////
                #endregion OpeningBook

                // CHECK FOR DANGEROUS SQUARES
                // Also find number and value of attackers and defenders for each square of the chessboard: will be used below to determine if the move is stupid
                #region DangerousSquares
                Danger_for_piece = false;

                for (int o1 = 0; o1 <= 7; o1++)
                {
                    for (int p1 = 0; p1 <= 7; p1++)
                    {
                        //v0.980: Change small Strings to Int
                        Skakiera_Dangerous_Squares[(o1), (p1)] = 0;
                        //v0.990 test. Added initialization. By adding it it makes the computer not wanting to eat the bishop.
                        Value_of_defenders[(o1), (p1)] = 0;
                        Value_of_attackers[(o1), (p1)] = 0;
                        //v0.990: Added also these initializations! Let's see what happens now...
                        //        I had forgot those! Could this be the reason the HY did not
                        //        want to eat the bishop?
                        Number_of_defenders[(o1), (p1)] = 0;
                        Number_of_attackers[(o1), (p1)] = 0;
                    }
                }

                // Find attackers-defenders
                FindAttackers(Skakiera_Thinking);
                FindDefenders(Skakiera_Thinking);

                // Determine dangerous squares
                for (int o1 = 0; o1 <= 7; o1++)
                {
                    for (int p1 = 0; p1 <= 7; p1++)
                    {
                        //v0.990 debug
                        //MessageBox.Show(String.Concat("Number of attackers for ", (o1 + 1).ToString(), (p1 + 1).ToString(), " : ", Number_of_attackers[o1, p1].ToString()));
                        //MessageBox.Show(String.Concat("Number of defenders for ", (o1 + 1).ToString(), (p1 + 1).ToString(), " : ", Number_of_defenders[o1, p1].ToString()));
                        //MessageBox.Show(String.Concat("Value_of_defenders for ", (o1 + 1).ToString(), (p1 + 1).ToString(), " : ", Value_of_defenders[o1, p1].ToString()));
                        //MessageBox.Show(String.Concat("Value_of_attackers for ", (o1 + 1).ToString(), (p1 + 1).ToString(), " : ", Value_of_attackers[o1, p1].ToString()));

                        //v0.990 change: Should ">" change to ">=" ??? No!
                        //The case where the only defender is the moving piece can only be captured 
                        //in the CheckMove function!
                        if (Number_of_attackers[o1, p1] > Number_of_defenders[o1, p1])
                            //v0.980: Change small Strings to Int
                            Skakiera_Dangerous_Squares[(o1), (p1)] = 1;
                    }
                }

                #region WriteLog
                if (activateLogs == true)
                {
                    //v0.990
                    for (i = 0; i <= 7; i++)
                    {
                        for (j = 0; j <= 7; j++)
                        {
                            switch (Skakiera_Thinking_init[(i), (j)])
                            {
                                case "White Rook":
                                    SkakieraLog[i, j] = "WR";
                                    break;

                                case "White Knight":
                                    SkakieraLog[i, j] = "WN";
                                    break;

                                case "White Bishop":
                                    SkakieraLog[i, j] = "WB";
                                    break;

                                case "White Queen":
                                    SkakieraLog[i, j] = "WQ";
                                    break;

                                case "White King":
                                    SkakieraLog[i, j] = "WK";
                                    break;

                                case "White Pawn":
                                    SkakieraLog[i, j] = "WP";
                                    break;

                                case "Black Rook":
                                    SkakieraLog[i, j] = "BR";
                                    break;

                                case "Black Knight":
                                    SkakieraLog[i, j] = "BN";
                                    break;

                                case "Black Bishop":
                                    SkakieraLog[i, j] = "BB";
                                    break;

                                case "Black Queen":
                                    SkakieraLog[i, j] = "BQ";
                                    break;

                                case "Black King":
                                    SkakieraLog[i, j] = "BK";
                                    break;

                                case "Black Pawn":
                                    SkakieraLog[i, j] = "BP";
                                    break;

                                case "":
                                    SkakieraLog[i, j] = "  ";
                                    break;
                            }
                        }
                    }

                    huo_sw_attackers.WriteLine("CHESSBOARD");
                    huo_sw_attackers.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw_attackers.WriteLine(String.Concat("| ", SkakieraLog[0, yj], " | ", SkakieraLog[1, yj], " | ", SkakieraLog[2, yj], " | ", SkakieraLog[3, yj], " | ", SkakieraLog[4, yj], " | ", SkakieraLog[5, yj], " | ", SkakieraLog[6, yj], " | ", SkakieraLog[7, yj], " |"));
                        huo_sw_attackers.WriteLine("-----------------------------------------");
                    }

                    huo_sw_attackers.WriteLine("");
                    huo_sw_attackers.WriteLine("");

                    huo_sw_attackers.WriteLine("CHESSBOARD: Number of attackers");
                    huo_sw_attackers.WriteLine(String.Concat("Move = ", Move.ToString()));
                    huo_sw_attackers.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw_attackers.WriteLine(String.Concat("| ", Number_of_attackers[0, yj], " | ", Number_of_attackers[1, yj], " | ", Number_of_attackers[2, yj], " | ", Number_of_attackers[3, yj], " | ", Number_of_attackers[4, yj], " | ", Number_of_attackers[5, yj], " | ", Number_of_attackers[6, yj], " | ", Number_of_attackers[7, yj], " |"));
                        huo_sw_attackers.WriteLine("-----------------------------------------");
                    }

                    huo_sw_attackers.WriteLine("");
                    huo_sw_attackers.WriteLine("");

                    huo_sw_attackers.WriteLine("CHESSBOARD: Value of attackers");
                    huo_sw_attackers.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw_attackers.WriteLine(String.Concat("| ", Value_of_attackers[0, yj], " | ", Value_of_attackers[1, yj], " | ", Value_of_attackers[2, yj], " | ", Value_of_attackers[3, yj], " | ", Value_of_attackers[4, yj], " | ", Value_of_attackers[5, yj], " | ", Value_of_attackers[6, yj], " | ", Value_of_attackers[7, yj], " |"));
                        huo_sw_attackers.WriteLine("-----------------------------------------");
                    }

                    huo_sw_attackers.WriteLine("");
                    huo_sw_attackers.WriteLine("");

                    huo_sw_attackers.WriteLine("CHESSBOARD: Number of defenders");
                    huo_sw_attackers.WriteLine(String.Concat("Move = ", Move.ToString()));
                    huo_sw_attackers.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw_attackers.WriteLine(String.Concat("| ", Number_of_defenders[0, yj], " | ", Number_of_defenders[1, yj], " | ", Number_of_defenders[2, yj], " | ", Number_of_defenders[3, yj], " | ", Number_of_defenders[4, yj], " | ", Number_of_defenders[5, yj], " | ", Number_of_defenders[6, yj], " | ", Number_of_defenders[7, yj], " |"));
                        huo_sw_attackers.WriteLine("-----------------------------------------");
                    }

                    huo_sw_attackers.WriteLine("");
                    huo_sw_attackers.WriteLine("");

                    huo_sw_attackers.WriteLine("CHESSBOARD: Value of defenders");
                    huo_sw_attackers.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw_attackers.WriteLine(String.Concat("| ", Value_of_defenders[0, yj], " | ", Value_of_defenders[1, yj], " | ", Value_of_defenders[2, yj], " | ", Value_of_defenders[3, yj], " | ", Value_of_defenders[4, yj], " | ", Value_of_defenders[5, yj], " | ", Value_of_defenders[6, yj], " | ", Value_of_defenders[7, yj], " |"));
                        huo_sw_attackers.WriteLine("-----------------------------------------");
                    }

                    huo_sw_attackers.WriteLine("");
                    huo_sw_attackers.WriteLine("");

                    huo_sw_attackers.WriteLine("CHESSBOARD: Dangerous squares");
                    huo_sw_attackers.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw_attackers.WriteLine(String.Concat("| ", Skakiera_Dangerous_Squares[0, yj], " | ", Skakiera_Dangerous_Squares[1, yj], " | ", Skakiera_Dangerous_Squares[2, yj], " | ", Skakiera_Dangerous_Squares[3, yj], " | ", Skakiera_Dangerous_Squares[4, yj], " | ", Skakiera_Dangerous_Squares[5, yj], " | ", Skakiera_Dangerous_Squares[6, yj], " | ", Skakiera_Dangerous_Squares[7, yj], " |"));
                        huo_sw_attackers.WriteLine("-----------------------------------------");
                    }
                }
                #endregion WriteLog

                #endregion DangerousSquares

                // v0.990
                // Check if HY is currently under check
                ThereIsCheck = false;

                if (m_PlayerColor.CompareTo("White") == 0)
                    ThereIsCheck = CheckForBlackCheck(Skakiera_Thinking);
                else if (m_PlayerColor.CompareTo("Black") == 0)
                    ThereIsCheck = CheckForBlackCheck(Skakiera_Thinking);

                //---------------------------------------
                // CHECK ALL POSSIBLE MOVES!
                //---------------------------------------
                // v0.991: Added opening book capability
                if (foundOpening == false)
                {
                    #region checkAllMoves
                    for (iii = 0; iii <= 7; iii++)
                    {
                        for (jjj = 0; jjj <= 7; jjj++)
                        {
                            //v0.980: Reduce all texts ("White King" for "Wh King", "White Knight" for "Wh Knight" and so on...)
                            if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Skakiera_Thinking[(iii), (jjj)].CompareTo("White King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Thinking[(iii), (jjj)].CompareTo("Black King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))) || ((Who_Is_Analyzed.CompareTo("Hu") == 0) && ((((Skakiera_Thinking[(iii), (jjj)].CompareTo("White King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)) || (((Skakiera_Thinking[(iii), (jjj)].CompareTo("Black King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)))))
                            {

                                for (int w = 0; w <= 7; w++)
                                {
                                    for (int r = 0; r <= 7; r++)
                                    {
                                        //v0.980: Removed. It was not used.
                                        //Danger_penalty = false;
                                        MovingPiece = Skakiera_Thinking[(iii), (jjj)];
                                        m_StartingColumnNumber = iii + 1;
                                        m_FinishingColumnNumber = w + 1;
                                        m_StartingRank = jjj + 1;
                                        m_FinishingRank = r + 1;

                                        #region ObsoleteCode
                                        // Store temporary move data in local variables, so as to use them in the Undo of the move
                                        // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                        // changed by next functions as well, so using them leads to problems)
                                        //v0.990: Removed the copy to MovingPiece variable
                                        //MovingPiece = MovingPiece;
                                        //m_StartingColumnNumber = m_StartingColumnNumber;
                                        //m_FinishingColumnNumber = m_FinishingColumnNumber;
                                        //m_StartingRank = m_StartingRank;
                                        //m_FinishingRank = m_FinishingRank;
                                        //v0.991: This is not needed here. (it is also done after we see the move is valid)
                                        //ProsorinoKommati = Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];

                                        // Check for stupid moves in the start of the game
                                        //v0.980: Reduce all texts ("Y" for "Y", "N" for "N")
                                        //v0.990 test (ThisIsStupidMove is public now)
                                        //String ThisIsStupidMove = "N";
                                        // V0.990: Renamed the DoNotMakeStupidMove to ThisIsStupidMove
                                        #endregion ObsoleteCode

                                        ThisIsStupidMove = "N";
                                        #region CheckStupidMove
                                        //v0.990: MovingPiece -> MovingPiece (AND all other related variables)
                                        //v0.990 test: Remove for now the stupid move checks... (for testing)
                                        //if (Move < 0)
                                        if (Move < 5)
                                        {
                                            if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0) ||
                                                    (MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if (((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                                    && (m_FinishingColumnNumber == 1))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if (((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                                    && (m_FinishingColumnNumber == 8))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("White Knight") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 4)
                                                    && (Skakiera_Thinking[(2), (0)].CompareTo("White Bishop") == 0))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("White Knight") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 5)
                                                    && (Skakiera_Thinking[(5), (0)].CompareTo("White Bishop") == 0))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("Black Knight") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 4)
                                                    && (Skakiera_Thinking[(2), (7)].CompareTo("Black Bishop") == 0))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("Black Knight") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 5)
                                                    && (Skakiera_Thinking[(5), (7)].CompareTo("Black Bishop") == 0))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("White Pawn") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("White Pawn") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("Black Pawn") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("Black Pawn") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if ((MovingPiece.CompareTo("White King") == 0) || (MovingPiece.CompareTo("Black King") == 0))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                            else if (((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                                                && ((m_FinishingRank == 3) || (m_FinishingRank == 5) || (m_FinishingRank == 6)))
                                            {
                                                ThisIsStupidMove = "Y";
                                            }
                                        }

                                        // v0.970
                                        // Store the value of the moving piece
                                        if ((MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                                            ValueOfMovingPiece = 5;
                                        if ((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                            ValueOfMovingPiece = 3;
                                        if ((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                                            ValueOfMovingPiece = 3;
                                        if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0))
                                            ValueOfMovingPiece = 9;
                                        if ((MovingPiece.CompareTo("White King") == 0) || (MovingPiece.CompareTo("Black King") == 0))
                                            ValueOfMovingPiece = 119;
                                        if ((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0))
                                            ValueOfMovingPiece = 1;

                                        //v0.990 debug
                                        //if ((m_StartingColumnNumber == 3)  &&
                                        //    (m_StartingRank == 1)          &&
                                        //    (m_FinishingColumnNumber == 6) &&
                                        //    (m_FinishingRank == 4))
                                        //{
                                        //    MessageBox.Show(String.Concat("Moving ", MovingPiece, ": ", m_StartingColumnNumber.ToString(), m_StartingRank.ToString(), " -> ", m_FinishingColumnNumber.ToString(), m_FinishingRank.ToString()));
                                        //    MessageBox.Show(Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].ToString());
                                        //}
                                        //v0.990 debug
                                        //if ((m_StartingColumnNumber == 3) &&
                                        //    (m_StartingRank == 1) &&
                                        //    (m_FinishingColumnNumber == 6) &&
                                        //    (m_FinishingRank == 4))
                                        //{
                                        //    MessageBox.Show(String.Concat("Moving ", MovingPiece, ": ", m_StartingColumnNumber.ToString(), m_StartingRank.ToString(), " -> ", m_FinishingColumnNumber.ToString(), m_FinishingRank.ToString()));
                                        //    MessageBox.Show(Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].ToString());
                                        //}

                                        //v0.990: Here we use the w and r variables, while the move is defined by the m_FinishingColumnNumber, m_FinishingRank variables!
                                        // The change was not needed! w = m_FinishingColumnNumber - 1 anyway!
                                        // (and in the same way r is also correct!)
                                        // Left the change for clarity purposes!
                                        // If a pieve of lower value attacks the square where the computer moves, then... stupid move!
                                        //if ((Number_of_attackers[w, r] == 1) && (Value_of_attackers[w, r] < ValueOfMovingPiece))
                                        //No need to have the "Number of attackers = 1" condition, changed it to >=
                                        //v0.990: m_FinishingColumnNumber -> m_FinishingColumnNumber - 1
                                        if ((Number_of_attackers[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] >= 1) && (Value_of_attackers[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] < ValueOfMovingPiece))
                                        {
                                            ThisIsStupidMove = "Y";
                                        }
                                        #endregion CheckStupidMove

                                        #region HuoChessHistory
                                        //V0.990 Helsinki fix
                                        //The CheckStupidMove did not work correctly.
                                        //It made the computer do different move in the same position
                                        //depending on whether it started the game from that position or not
                                        //ThisIsStupidMove = "N";
                                        //At the end this was not the problem!
                                        //The lack of initialization of dangerous squares tables was to blame!
                                        #endregion HuoChessHistory

                                        // If the move is not stupid or the destination square is not dangerous then do the move to check it...
                                        // v0.991: Have the stupid move or moving into dagerous sqaures generate penalty in the score (and NOT block them from analysis alltogether), so that all the moves are analyzed!
                                        // if ((ThisIsStupidMove.CompareTo("N") == 0) && (Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] == 0))
                                        // if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] == 0))
                                        if (1 == 1)
                                        {
                                            // THE HEART OF THE THINKING MECHANISM: Here the computer checks the moves

                                            // Validity and legality of the move will be checked in CheckMove (plus some additional checks for possible mate etc)
                                            // CheckMove(Skakiera_Thinking);
                                            CheckMove(Skakiera_Thinking, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                                            //v0.980: Removed
                                            //number_of_moves_analysed++;

                                            if (((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true)) && (Move_Analyzed == 0))
                                            {
                                                // Store the move to ***_HY variables (because after continuous calls of ComputerMove the initial move under analysis will be lost...)

                                                MovingPiece_HY = MovingPiece;
                                                m_StartingColumnNumber_HY = m_StartingColumnNumber;
                                                m_FinishingColumnNumber_HY = m_FinishingColumnNumber;
                                                m_StartingRank_HY = m_StartingRank;
                                                m_FinishingRank_HY = m_FinishingRank;

                                                // Store the initial move coordinates (at the node 0 level)
                                                // v0.992: Store the initial move in another dedicated table with less size
                                                //         (reduce the size of NodesAnalysis0 table)
                                                NodesAnalysis0[NodeLevel_0_count, 2] = m_StartingColumnNumber_HY;
                                                NodesAnalysis0[NodeLevel_0_count, 3] = m_FinishingColumnNumber_HY;
                                                NodesAnalysis0[NodeLevel_0_count, 4] = m_StartingRank_HY;
                                                NodesAnalysis0[NodeLevel_0_count, 5] = m_FinishingRank_HY;

                                                #region ObsoleteCode
                                                // Check is HY eats the opponents queen (so it is preferable to do so...)
                                                // Not operational yet...
                                                //if ((ProsorinoKommati.CompareTo("White Queen") == 0) || (ProsorinoKommati.CompareTo("Black Queen") == 0))
                                                //    go_for_it = true;
                                                // v0.970: Danger penalty now checked directly in ComputerMove
                                                #endregion ObsoleteCode

                                                // v0.990
                                                // Now at least one legal move is found (used to determine if there is checkmate)
                                                Best_Move_Found = true;
                                            }


                                            // If everything is OK, then do the move and measure it's score
                                            if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                            {
                                                // v0.991
                                                #region MoveText
                                                String m_StartingColumnNumber_moveText;
                                                String m_FinishingColumnNumber_moveText;

                                                switch (m_StartingColumnNumber)
                                                {
                                                    case (1):
                                                        m_StartingColumnNumber_moveText = "a";
                                                        break;

                                                    case (2):
                                                        m_StartingColumnNumber_moveText = "b";
                                                        break;

                                                    case (3):
                                                        m_StartingColumnNumber_moveText = "c";
                                                        break;

                                                    case (4):
                                                        m_StartingColumnNumber_moveText = "d";
                                                        break;

                                                    case (5):
                                                        m_StartingColumnNumber_moveText = "e";
                                                        break;

                                                    case (6):
                                                        m_StartingColumnNumber_moveText = "f";
                                                        break;

                                                    case (7):
                                                        m_StartingColumnNumber_moveText = "g";
                                                        break;

                                                    case (8):
                                                        m_StartingColumnNumber_moveText = "h";
                                                        break;

                                                    default:
                                                        m_StartingColumnNumber_moveText = "Error";
                                                        break;
                                                }

                                                switch (m_FinishingColumnNumber)
                                                {
                                                    case (1):
                                                        m_FinishingColumnNumber_moveText = "a";
                                                        break;

                                                    case (2):
                                                        m_FinishingColumnNumber_moveText = "b";
                                                        break;

                                                    case (3):
                                                        m_FinishingColumnNumber_moveText = "c";
                                                        break;

                                                    case (4):
                                                        m_FinishingColumnNumber_moveText = "d";
                                                        break;

                                                    case (5):
                                                        m_FinishingColumnNumber_moveText = "e";
                                                        break;

                                                    case (6):
                                                        m_FinishingColumnNumber_moveText = "f";
                                                        break;

                                                    case (7):
                                                        m_FinishingColumnNumber_moveText = "g";
                                                        break;

                                                    case (8):
                                                        m_FinishingColumnNumber_moveText = "h";
                                                        break;

                                                    default:
                                                        m_FinishingColumnNumber_moveText = "Error";
                                                        break;
                                                }

                                                Move0_text = String.Concat(m_StartingColumnNumber_moveText,
                                                                           m_StartingRank.ToString(), " -> ",
                                                                           m_FinishingColumnNumber_moveText,
                                                                           m_FinishingRank.ToString());

                                                NodesAnalysis0_MoveText[NodeLevel_0_count] = Move0_text;
                                                #endregion MoveText

                                                // Do the move
                                                ProsorinoKommati = Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                                Skakiera_Thinking[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                                Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                                // v0.990: Find value of moving piece and of the target piece eaten
                                                #region findValueOfPieces
                                                if ((MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                                                    ValueOfKommati = 5;
                                                if ((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                                    ValueOfKommati = 3;
                                                if ((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                                                    ValueOfKommati = 3;
                                                if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0))
                                                    ValueOfKommati = 9;
                                                if ((MovingPiece.CompareTo("White King") == 0) || (MovingPiece.CompareTo("Black King") == 0))
                                                    ValueOfKommati = 119;
                                                if ((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0))
                                                    ValueOfKommati = 1;

                                                if ((ProsorinoKommati.CompareTo("White Rook") == 0) || (ProsorinoKommati.CompareTo("Black Rook") == 0))
                                                    ValueOfTargetPiece = 5;
                                                if ((ProsorinoKommati.CompareTo("White Knight") == 0) || (ProsorinoKommati.CompareTo("Black Knight") == 0))
                                                    ValueOfTargetPiece = 3;
                                                if ((ProsorinoKommati.CompareTo("White Bishop") == 0) || (ProsorinoKommati.CompareTo("Black Bishop") == 0))
                                                    ValueOfTargetPiece = 3;
                                                if ((ProsorinoKommati.CompareTo("White Queen") == 0) || (ProsorinoKommati.CompareTo("Black Queen") == 0))
                                                    ValueOfTargetPiece = 9;
                                                if ((ProsorinoKommati.CompareTo("White King") == 0) || (ProsorinoKommati.CompareTo("Black King") == 0))
                                                    ValueOfTargetPiece = 119;
                                                if ((ProsorinoKommati.CompareTo("White Pawn") == 0) || (ProsorinoKommati.CompareTo("Black Pawn") == 0))
                                                    ValueOfTargetPiece = 1;
                                                #endregion findValueOfPieces

                                                #region ObsoleteCode
                                                // Check the score after the computer move
                                                //v0.990: Removed the (Move_Analyzed == 0) part
                                                //if (Move_Analyzed == 0)
                                                //{
                                                // v0.991 - This should not be done here!
                                                // NodeLevel_0_count++;
                                                #endregion ObsoleteCode

                                                Temp_Score_Move_0 = CountScore(Skakiera_Thinking);

                                                // v0.990 change
                                                // Store the best move score at this level
                                                // v0.991: Attention! Here this section will be removed if we want to start trimming the tree from this function!
                                                // (see the Analyze_Move_2 for details on how this happens)
                                                if ((m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_0 > bestScoreLevel0))
                                                {
                                                    bestScoreLevel0 = Temp_Score_Move_0;
                                                }
                                                else if ((m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_0 < bestScoreLevel0))
                                                {
                                                    bestScoreLevel0 = Temp_Score_Move_0;
                                                }

                                                #region ObsoleteCode
                                                //}
                                                //v0.980: This is Move Analyzed 0, so no need for the other ifs!
                                                //if (Move_Analyzed == 2)
                                                //{
                                                //    NodeLevel_2_count++;
                                                //    Temp_Score_Move_2 = CountScore(Skakiera_Thinking, humanDangerParameter);
                                                //}
                                                // v0.980: Removed addional calls for additional depths of analysis

                                                //if (activateLogs == true)
                                                //{
                                                //#region WriteLog
                                                ////v0.990
                                                //NodesAnalysis0_Move[NodeLevel_0_count] = String.Concat("Move Analyzed for Node ", NodeLevel_0_count.ToString(), " [Level 0]: ", MovingPiece, " ", m_StartingColumnNumber.ToString(), m_StartingRank.ToString(), " -> ", m_FinishingColumnNumber.ToString(), m_FinishingRank.ToString());

                                                ////v0.990
                                                //for (i = 0; i <= 7; i++)
                                                //{
                                                //    for (j = 0; j <= 7; j++)
                                                //    {
                                                //        switch (Skakiera_Thinking[(i), (j)])
                                                //        {
                                                //            case "White Rook":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "WR";
                                                //                break;

                                                //            case "White Knight":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "WN";
                                                //                break;

                                                //            case "White Bishop":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "WB";
                                                //                break;

                                                //            case "White Queen":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "WQ";
                                                //                break;

                                                //            case "White King":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "WK";
                                                //                break;

                                                //            case "White Pawn":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "WP";
                                                //                break;

                                                //            case "Black Rook":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "BR";
                                                //                break;

                                                //            case "Black Knight":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "BN";
                                                //                break;

                                                //            case "Black Bishop":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "BB";
                                                //                break;

                                                //            case "Black Queen":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "BQ";
                                                //                break;

                                                //            case "Black King":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "BK";
                                                //                break;

                                                //            case "Black Pawn":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "BP";
                                                //                break;

                                                //            case "":
                                                //                NodesAnalysis0_Chessboard[i, j, NodeLevel_0_count] = "  ";
                                                //                break;
                                                //        }
                                                //    }
                                                //}
                                                //#endregion WriteLog
                                                //}
                                                #endregion ObsoleteCode

                                                // -------------------------------------------------------
                                                // Check if the computer can eat a piece of the opponent
                                                // -------------------------------------------------------
                                                #region Eat
                                                if (ValueOfKommati < ValueOfTargetPiece)
                                                {
                                                    Best_Move_StartingColumnNumber = m_StartingColumnNumber;
                                                    Best_Move_StartingRank = m_StartingRank;
                                                    Best_Move_FinishingColumnNumber = m_FinishingColumnNumber;
                                                    Best_Move_FinishingRank = m_FinishingRank;

                                                    possibility_to_eat = true;
                                                }
                                                #endregion Eat

                                                // ------------------------------------------------------------
                                                // Check if the computer can eat back a piece of the opponent
                                                // ------------------------------------------------------------
                                                #region EatBack
                                                // v0.970: Check if you can eat back the piece of the Hu which moved!
                                                if ((m_FinishingColumnNumber == Human_last_move_target_column)
                                                     && (m_FinishingRank == Human_last_move_target_row)
                                                     && (ValueOfMovingPiece <= ValueOfHumanMovingPiece))
                                                {
                                                    Best_Move_StartingColumnNumber = m_StartingColumnNumber;
                                                    Best_Move_StartingRank = m_StartingRank;
                                                    Best_Move_FinishingColumnNumber = m_FinishingColumnNumber;
                                                    Best_Move_FinishingRank = m_FinishingRank;

                                                    possibility_to_eat_back = true;
                                                }
                                                #endregion EatBack

                                                #region ObsoleteCode
                                                // v0.970: If you can eat back the piece of the HY, then go for it and don't analyze!
                                                // v0.990: Added the possibility_to_eat
                                                // v0.991: Removed possibility to eat! Why not think for everything?
                                                // if ((Move_Analyzed < Thinking_Depth) && (possibility_to_eat_back == false) && (possibility_to_eat == false))
                                                // v0.990 test: Trim the tree... (Not needed here, but it is needed at the deeper depths of the analysis for sure)
                                                // if (  (((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_0 <= bestScoreLevel0))
                                                //       || ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_0 >= bestScoreLevel0)))
                                                //       && (possibility_to_eat_back == false))
                                                #endregion ObsoleteCode

                                                // If thinking depth not reached and there is not an easy option to eat back...
                                                if ((Move_Analyzed < Thinking_Depth) && (possibility_to_eat_back == false))
                                                {
                                                    Move_Analyzed = Move_Analyzed + 1;

                                                    #region HuoChessHistory
                                                    //v0.980: Tried to remove and pass over Skakiera to Analyze_Move_1_HumanMove,
                                                    //but the result changed. Must check it. It should be the same!!!
                                                    //The problem is probably that Skakiera_Thinking is used/ referenced somewhere else in the program
                                                    //and its values are distorted later on.
                                                    //v0.990: Removed the copy to Skakiera_Move_After
                                                    #endregion HuoChessHistory

                                                    //v0.990: Added a new separate chessboard to use when passing over to a new function.
                                                    String[,] Skakiera_Move_After_0_new = new String[8, 8];

                                                    for (i = 0; i <= 7; i++)
                                                    {
                                                        for (j = 0; j <= 7; j++)
                                                        {
                                                            Skakiera_Move_After_0[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                                            Skakiera_Move_After_0_new[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                                        }
                                                    }

                                                    //v0.980: Removed
                                                    Who_Is_Analyzed = "Human";

                                                    #region ObsoleteCode
                                                    //First_Call_Human_Thought = true;
                                                    // Check Hu move (to find the best possible answer of the Hu
                                                    // to the move currently analyzed by the HY Thought process)
                                                    //v0.980: You will always have to call the next level of thought here!
                                                    //if (Move_Analyzed == 1)
                                                    //v0.990: Skakiera_Move_After -> Skakiera_Move_After_0 -> Skakiera_Move_After_0_new (to be sure tables do not interfere with each other)
                                                    //v0.990 Helsinki
                                                    #endregion ObsoleteCode

                                                    Analyze_Move_1_HumanMove(Skakiera_Move_After_0_new);

                                                    #region ObsoleteCode
                                                    //v0.990 Helsinki
                                                    //if (Move == 0)
                                                    //    Analyze_Move_1_HumanMove(Skakiera_Move_After_0_new);
                                                    //else if (Move >= 1)
                                                    //    Analyze_Move_11_HumanMove(Skakiera_Move_After_0_new);
                                                    #endregion ObsoleteCode
                                                }

                                                // Undo the move
                                                Skakiera_Thinking[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                                                Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = ProsorinoKommati;

                                                // v0.991 - This should be done here!
                                                NodeLevel_0_count++;
                                            }

                                        }

                                    }
                                }

                            }


                        }
                    }
                    #endregion checkAllMoves
                }

                // Find if there is mate
                // v0.980: Simplified!
                #region CheckIfMate
                //if ((Move_Analyzed == 0) && ((WhiteKingCheck == true) || (BlackKingCheck == true)))
                //{

                //    // Αν ο υπολογιστής δεν κατόρθωσε να βρει καμία νόμιμη κίνηση να κάνει εξαιτίας του ότι είναι ματ

                //    if (Best_Move_Found == false)
                //    {
                //        //Mate = true;

                //        if (m_PlayerColor.CompareTo("White") == 0)
                //            Console.WriteLine("Bl is MATE!");
                //        else if (m_PlayerColor.CompareTo("Black") == 0)
                //            Console.WriteLine("Wh is MATE!");
                //    }

                //}

                // v0.990
                //if (((WhiteKingCheck == true) || (BlackKingCheck == true)) && (Best_Move_Found == false))
                if ((ThereIsCheck == true) && (Best_Move_Found == false))
                {
                    //v0.990
                    MessageBox.Show("Checkmate!");
                    //Console.WriteLine("Checkmate!");
                }
                #endregion CheckIfMate

                // v0.990 test: Add a log of the nodes
                #region WriteLog
                if (activateLogs == true)
                {
                    StreamWriter huo_sw4 = new StreamWriter("HUO_CHESS_LOG_Minmax_Before.txt", true);

                    //V0.990 test: Add a log
                    huo_sw4.WriteLine("");
                    huo_sw4.WriteLine("----------- BEFORE ---------");
                    huo_sw4.WriteLine("");
                    huo_sw4.WriteLine("-------------- Level 2 Nodes (2nd computer move) -------------");
                    huo_sw4.WriteLine("");
                    for (int lala = 0; lala < NodeLevel_2_count; lala++)
                    {
                        huo_sw4.WriteLine(String.Concat("NodeLevel2[", lala.ToString(), "] (Score)  = ", NodesAnalysis2[lala, 0].ToString(), " [Parent = ", NodesAnalysis2[lala, 1].ToString(), "]"));
                        huo_sw4.WriteLine(String.Concat("Variant in the node: ", NodesAnalysis2_MoveText[lala]));
                        huo_sw4.WriteLine("");
                        //huo_sw4.WriteLine("CHESSBOARD Nodes Level 2");
                        //v0.990
                        //huo_sw4.WriteLine("-----------------------------------------");
                        //for (int yj = 7; yj >= 0; yj--)
                        //{
                        //    huo_sw4.WriteLine(String.Concat("| ", NodesAnalysis2_Chessboard[0, yj, lala], " | ", NodesAnalysis2_Chessboard[1, yj, lala], " | ", NodesAnalysis2_Chessboard[2, yj, lala], " | ", NodesAnalysis2_Chessboard[3, yj, lala], " | ", NodesAnalysis2_Chessboard[4, yj, lala], " | ", NodesAnalysis2_Chessboard[5, yj, lala], " | ", NodesAnalysis2_Chessboard[6, yj, lala], " | ", NodesAnalysis2_Chessboard[7, yj, lala], " |"));
                        //    huo_sw4.WriteLine("-----------------------------------------");
                        //}
                        huo_sw4.WriteLine("");
                    }

                    huo_sw4.WriteLine("");
                    huo_sw4.WriteLine("-------------- Level 1 Nodes (1st human response) -------------");
                    huo_sw4.WriteLine("");
                    for (int lala = 0; lala < NodeLevel_1_count; lala++)
                    {
                        huo_sw4.WriteLine(String.Concat("NodeLevel1[", lala.ToString(), "] (Score)  = ", NodesAnalysis1[lala, 0].ToString(), " [Parent = ", NodesAnalysis1[lala, 1].ToString(), "]"));
                        huo_sw4.WriteLine(String.Concat("Variant in the node: ", NodesAnalysis1_MoveText[lala]));
                        huo_sw4.WriteLine("");
                        //huo_sw4.WriteLine("CHESSBOARD Nodes Level 1");
                        //v0.990
                        //huo_sw4.WriteLine("-----------------------------------------");
                        //for (int yj = 7; yj >= 0; yj--)
                        //{
                        //    huo_sw4.WriteLine(String.Concat("| ", NodesAnalysis1_Chessboard[0, yj, lala], " | ", NodesAnalysis1_Chessboard[1, yj, lala], " | ", NodesAnalysis1_Chessboard[2, yj, lala], " | ", NodesAnalysis1_Chessboard[3, yj, lala], " | ", NodesAnalysis1_Chessboard[4, yj, lala], " | ", NodesAnalysis1_Chessboard[5, yj, lala], " | ", NodesAnalysis1_Chessboard[6, yj, lala], " | ", NodesAnalysis1_Chessboard[7, yj, lala], " |"));
                        //    huo_sw4.WriteLine("-----------------------------------------");
                        //}
                        //huo_sw4.WriteLine("");
                    }

                    huo_sw4.WriteLine("");
                    huo_sw4.WriteLine("-------------- Level 0 Nodes (initial computer move) -------------");
                    huo_sw4.WriteLine("");
                    for (int lala = 0; lala < NodeLevel_0_count; lala++)
                    {
                        huo_sw4.WriteLine(String.Concat("NodeLevel0[", lala.ToString(), "] (Score)  = ", NodesAnalysis0[lala, 0].ToString(), " [Parent = ", NodesAnalysis0[lala, 1].ToString(), "]"));
                        huo_sw4.WriteLine(String.Concat("Variant in the node: ", NodesAnalysis0_MoveText[lala]));
                        huo_sw4.WriteLine("");
                        //huo_sw4.WriteLine("CHESSBOARD Nodes Level 0");
                        //v0.990
                        //huo_sw4.WriteLine("-----------------------------------------");
                        //for (int yj = 7; yj >= 0; yj--)
                        //{
                        //    huo_sw4.WriteLine(String.Concat("| ", NodesAnalysis0_Chessboard[0, yj, lala], " | ", NodesAnalysis0_Chessboard[1, yj, lala], " | ", NodesAnalysis0_Chessboard[2, yj, lala], " | ", NodesAnalysis0_Chessboard[3, yj, lala], " | ", NodesAnalysis0_Chessboard[4, yj, lala], " | ", NodesAnalysis0_Chessboard[5, yj, lala], " | ", NodesAnalysis0_Chessboard[6, yj, lala], " | ", NodesAnalysis0_Chessboard[7, yj, lala], " |"));
                        //    huo_sw4.WriteLine("-----------------------------------------");
                        //}
                        //huo_sw4.WriteLine("");
                    }

                    huo_sw4.Close();
                }
                #endregion WriteLog

                // -------------------------------------------------------------------------------
                // DO THE BEST MOVE FOUND
                // Analyze only if possibility to eat back is not true!!!
                // MessageBox.Show("Entered Best Move found area!");
                // v0.990: Added the possibility_to_eat
                // v0.991: Removed possibility to eat! Why not think everything?
                // v0.991: Added the opening book check
                // if ((possibility_to_eat_back == false) && (possibility_to_eat == false))
                // -------------------------------------------------------------------------------
                if ((possibility_to_eat_back == false) && (foundOpening == false))
                {
                    // [MiniMax algorithm - skakos]
                    // MessageBox.Show("Entered checkpoint 1");
                    // Find node 1 move with the best score via the MiniMax algorithm.
                    // v0.980: Remove unsued counters.
                    // v0.990: Move 4 changes
                    // v0.991: Added counter4 again (needed if Thinking_Depth = 4)
                    int counter0, counter1, counter2, counter3, counter4;

                    // -------------------------------------------------------------------
                    // NodesAnalysis
                    // -------------------------------------------------------------------
                    // Nodes structure...
                    // [ccc, xxx, 0]: Score of node No. ccc at level xxx
                    // [ccc, xxx, 1]: Parent of node No. ccc at level xxx-1
                    // -------------------------------------------------------------------
                    // v0.991 Added the move 4 section - Needed if Thinking_Depth = 4.
                    // -------------------------------------------------------------------

                    // Move 4 level (Computer)

                    int parentNodeAnalyzed = -999;

                    // v0.991: Added this so as to make this activated only when Thinking_Depth = 4.
                    if (Thinking_Depth == 4)
                    {
                        // v0.991: Start from 0!
                        for (counter4 = 0; counter4 < NodeLevel_4_count; counter4++)
                        {
                            if (Int32.Parse(NodesAnalysis4[counter4, 1].ToString()) != parentNodeAnalyzed)
                            {
                                //parentNodeAnalyzedchanged = true;
                                parentNodeAnalyzed = Int32.Parse(NodesAnalysis4[counter4, 1].ToString());
                                NodesAnalysis3[Int32.Parse(NodesAnalysis4[counter4, 1].ToString()), 0] = NodesAnalysis4[counter4, 0];
                            }

                            //v0.990: Do we need to check for "<=" here? Os should we start checking for ">="?
                            //v0.991: Start analysis with < instead of > ?
                            if (NodesAnalysis4[counter4, 0] >= NodesAnalysis3[Int32.Parse(NodesAnalysis4[counter4, 1].ToString()), 0])
                                NodesAnalysis3[Int32.Parse(NodesAnalysis4[counter4, 1].ToString()), 0] = NodesAnalysis4[counter4, 0];
                        }

                        // Move 3 level (Human)

                        parentNodeAnalyzed = -999;

                        //v0.992: Calculate the average value in every path to find the best move
                        #region AverageScore
                        //for (counter3 = 1; counter3 <= NodeLevel_3_count; counter3++)
                        //{
                        //    NodesAnalysis3[counter3, 0] =
                        //        (NodesAnalysis3[counter3, 0]
                        //        + NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0]
                        //        + NodesAnalysis1[Int32.Parse(NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 1].ToString()), 0]
                        //        + NodesAnalysis0[NodesAnalysis1[Int32.Parse(NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 1].ToString()), 1], 0]) / 4;
                        //}
                        #endregion AverageScore

                        // v0.990: Move 4 changes
                        // v0.991: Start from 0!
                        for (counter3 = 0; counter3 < NodeLevel_3_count; counter3++)
                        {
                            if (Int32.Parse(NodesAnalysis3[counter3, 1].ToString()) != parentNodeAnalyzed)
                            {
                                //parentNodeAnalyzedchanged = true;
                                parentNodeAnalyzed = Int32.Parse(NodesAnalysis3[counter3, 1].ToString());
                                NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0] = NodesAnalysis3[counter3, 0];
                            }

                            //v0.990: Do we need to check for "<=" here? Os should we start checking for ">="?
                            if (NodesAnalysis3[counter3, 0] <= NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0])
                                NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0] = NodesAnalysis3[counter3, 0];
                        }

                    }

                    // Now the Node2 level is filled with the score data

                    // Move 2 level (Computer) -- The analysis starts from here if Thinking_Depth = 2.

                    //v0.980: Remove
                    parentNodeAnalyzed = -999;

                    //v0.992: Calculate the average value in every path to find the best move
                    #region AverageScore
                    //for (counter2 = 1; counter2 <= NodeLevel_2_count; counter2++)
                    //{
                    //    NodesAnalysis2[counter2, 0] =
                    //        (NodesAnalysis2[counter2, 0]
                    //        + NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0]
                    //        + NodesAnalysis0[Int32.Parse(NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 1].ToString()), 0]) / 3;
                    //}
                    #endregion AverageScore

                    // v0.991: Start from 0!
                    // v0.991: Use "counter2 < NodeLevel_2_count" instead of "counter2 <= NodeLevel_2_count"!
                    //         The increase in the number of Nodes at each level happens AFTER the node analysis is
                    //         completed, so at the end (after the last node is successfully analyzed) there is an
                    //         addiitonal node in the nodes count which contains nothing! Take that into account and
                    //         everything will be ruined.
                    for (counter2 = 0; counter2 < NodeLevel_2_count; counter2++)
                    {
                        if (Int32.Parse(NodesAnalysis2[counter2, 1].ToString()) != parentNodeAnalyzed)
                        {
                            //parentNodeAnalyzedchanged = true;
                            parentNodeAnalyzed = Int32.Parse(NodesAnalysis2[counter2, 1].ToString());
                            NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
                        }

                        // v0.991: Original: >=
                        // v0.991: This should depend on the colour of the computer!!!
                        // v0.991: Tried to fix the problem in MinMax. Node1 elements for the SAME parent of Node2 must be filled accordingly.
                        //         We do not need to take into account the Node2 elements which are empty, thus having a score of 0 but no
                        //         assigned move! (this is why the Best Variant text is empty in the first moves)
                        if (m_PlayerColor.CompareTo("White") == 0)
                        {
                            if ( (NodesAnalysis2[counter2, 0] <= NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0]) &&
                                 (NodesAnalysis2_MoveText[counter2].CompareTo("") == 1) )
                            {
                                NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
                                NodesAnalysis1_MoveText[Int32.Parse(NodesAnalysis2[counter2, 1].ToString())] = NodesAnalysis2_MoveText[counter2];
                            }
                        }
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                        {
                            if (NodesAnalysis2[counter2, 0] >= NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0])
                            {
                                NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
                                NodesAnalysis1_MoveText[Int32.Parse(NodesAnalysis2[counter2, 1].ToString())] = NodesAnalysis2_MoveText[counter2];
                            }
                        }
                    }

                    // Now the Node1 level is filled with the score data
                    // this is line 1 in the shape at http://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Minimax.svg/300px-Minimax.svg.png

                    // Move 1 level (Human)

                    parentNodeAnalyzed = -999;

                    // v0.991: Start from 0!
                    for (counter1 = 0; counter1 < NodeLevel_1_count; counter1++)
                    {
                        if (Int32.Parse(NodesAnalysis1[counter1, 1].ToString()) != parentNodeAnalyzed)
                        {
                            //parentNodeAnalyzedchanged = true;
                            parentNodeAnalyzed = Int32.Parse(NodesAnalysis1[counter1, 1].ToString());
                            NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
                        }

                        // v0.991: Choose different based on colour!
                        if (m_PlayerColor.CompareTo("White") == 0)
                        {
                            //v0.991: Original: <=
                            if (NodesAnalysis1[counter1, 0] >= NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0])
                            {
                                NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
                                NodesAnalysis0_MoveText[Int32.Parse(NodesAnalysis1[counter1, 1].ToString())] = NodesAnalysis1_MoveText[counter1];
                            }
                        }
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                        {
                            //v0.991: Original: <=
                            if (NodesAnalysis1[counter1, 0] <= NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0])
                            {
                                NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
                                NodesAnalysis0_MoveText[Int32.Parse(NodesAnalysis1[counter1, 1].ToString())] = NodesAnalysis1_MoveText[counter1];
                            }
                        }
                    }

                    // Choose the biggest score at the Node0 level
                    // Check example at http://en.wikipedia.org/wiki/Minimax#Example_2
                    // This is line 0 at the shape at http://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Minimax.svg/300px-Minimax.svg.png

                    // Move 0 level (Computer)

                    // Initialize the score with the first score and move found
                    // v0.991: Start from 0!
                    double temp_score = NodesAnalysis0[0, 0];
                    Best_Variant_text = "";
                    Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[1, 2].ToString());
                    Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[1, 4].ToString());
                    Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[1, 3].ToString());
                    Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[1, 5].ToString());
                    // v0.991: Added the variant analyzed text (mainly for the logs)
                    Best_Variant_text = NodesAnalysis0_MoveText[0];
                    // MessageBox.Show(String.Concat("Best variant: ", Best_Variant_text));

                    for (counter0 = 0; counter0 < NodeLevel_0_count; counter0++)
                    {
                        // v0.991: Choose different based on colour!
                        if (m_PlayerColor.CompareTo("Black") == 0)
                        {
                            //v0.991: Original: >
                            if (NodesAnalysis0[counter0, 0] > temp_score)
                            {
                                temp_score = NodesAnalysis0[counter0, 0];

                                Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 2].ToString());
                                Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[counter0, 4].ToString());
                                Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 3].ToString());
                                Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[counter0, 5].ToString());
                                Best_Variant_text = NodesAnalysis0_MoveText[counter0];
                            }
                        }
                        else if (m_PlayerColor.CompareTo("White") == 0)
                        {
                            if (NodesAnalysis0[counter0, 0] < temp_score)
                            {
                                temp_score = NodesAnalysis0[counter0, 0];

                                Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 2].ToString());
                                Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[counter0, 4].ToString());
                                Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 3].ToString());
                                Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[counter0, 5].ToString());
                                Best_Variant_text = NodesAnalysis0_MoveText[counter0];
                            }
                        }
                    }

                }

                // Total final positions analyzed is...
                HuoChess_main.FinalPositions = Nodes_Total_count.ToString();

                // v0.990 test: Add a log of the nodes
                StreamWriter huo_sw5 = new StreamWriter("HUO_CHESS_LOG_Minmax_After.txt", true);

                // v0.990 test: Add a log
                #region WriteLog
                if (activateLogs == true)
                {
                    huo_sw5.WriteLine("");
                    huo_sw5.WriteLine("----------- AFTER ---------");
                    huo_sw5.WriteLine("");
                    huo_sw5.WriteLine("-------------- Node 2 -------------");
                    huo_sw5.WriteLine("");
                    for (int lala = 0; lala < NodeLevel_2_count; lala++)
                    {
                        huo_sw5.WriteLine("");
                        huo_sw5.WriteLine(String.Concat("NodeLevel2[2,", lala.ToString(), "] (Score)  = ", NodesAnalysis2[lala, 0].ToString(), " [Parent = ", NodesAnalysis2[lala, 1].ToString(), "]"));
                        huo_sw5.WriteLine(String.Concat("Variant in this node: ", NodesAnalysis2_MoveText[lala]));
                    }
                    huo_sw5.WriteLine("");
                    huo_sw5.WriteLine("-------------- Node 1 -------------");
                    huo_sw5.WriteLine("");
                    for (int lala = 0; lala < NodeLevel_1_count; lala++)
                    {
                        huo_sw5.WriteLine("");
                        huo_sw5.WriteLine(String.Concat("NodeLevel1[1,", lala.ToString(), "] (Score)  = ", NodesAnalysis1[lala, 0].ToString(), " [Parent = ", NodesAnalysis1[lala, 1].ToString(), "]"));
                        huo_sw5.WriteLine(String.Concat("Variant in this node: ", NodesAnalysis1_MoveText[lala]));
                    }
                    huo_sw5.WriteLine("");
                    huo_sw5.WriteLine("-------------- Node 0 -------------");
                    huo_sw5.WriteLine("");
                    for (int lala = 0; lala < NodeLevel_0_count; lala++)
                    {
                        huo_sw5.WriteLine("");
                        huo_sw5.WriteLine(String.Concat("NodeLevel0[0,", lala.ToString(), "] (Score)  = ", NodesAnalysis0[lala, 0].ToString(), " [Parent = ", NodesAnalysis0[lala, 1].ToString(), "]"));
                        huo_sw5.WriteLine(String.Concat("Variant in this node: ", NodesAnalysis0_MoveText[lala]));
                    }

                    huo_sw5.Close();
                }
                #endregion WriteLog

                /////////////////////////////////////////////////////////////////////////////////////////////////
                // REDRAW THE CHESSBOARD
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Erase the initial square
                //v0.980: Removed. The move is un-done previously anyway
                //for (iii = 0; iii <= 7; iii++)
                //{
                //    for (jjj = 0; jjj <= 7; jjj++)
                //    {
                //        Skakiera[(iii), (jjj)] = Skakiera_Move_0[(iii), (jjj)];
                //    }
                //}

                // v0.981: If no move found => Resign. If best move found => OK. Go do it.
                if (Best_Move_StartingColumnNumber > 0)
                {
                    MovingPiece = Skakiera[(Best_Move_StartingColumnNumber - 1), (Best_Move_StartingRank - 1)];
                    Skakiera[(Best_Move_StartingColumnNumber - 1), (Best_Move_StartingRank - 1)] = "";

                    if (Best_Move_StartingColumnNumber == 1)
                        HY_Starting_Column_Text = "a";
                    else if (Best_Move_StartingColumnNumber == 2)
                        HY_Starting_Column_Text = "b";
                    else if (Best_Move_StartingColumnNumber == 3)
                        HY_Starting_Column_Text = "c";
                    else if (Best_Move_StartingColumnNumber == 4)
                        HY_Starting_Column_Text = "d";
                    else if (Best_Move_StartingColumnNumber == 5)
                        HY_Starting_Column_Text = "e";
                    else if (Best_Move_StartingColumnNumber == 6)
                        HY_Starting_Column_Text = "f";
                    else if (Best_Move_StartingColumnNumber == 7)
                        HY_Starting_Column_Text = "g";
                    else if (Best_Move_StartingColumnNumber == 8)
                        HY_Starting_Column_Text = "h";

                    // Position piece to the square of destination

                    Skakiera[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = MovingPiece;

                    if (Best_Move_FinishingColumnNumber == 1)
                        HY_Finishing_Column_Text = "a";
                    else if (Best_Move_FinishingColumnNumber == 2)
                        HY_Finishing_Column_Text = "b";
                    else if (Best_Move_FinishingColumnNumber == 3)
                        HY_Finishing_Column_Text = "c";
                    else if (Best_Move_FinishingColumnNumber == 4)
                        HY_Finishing_Column_Text = "d";
                    else if (Best_Move_FinishingColumnNumber == 5)
                        HY_Finishing_Column_Text = "e";
                    else if (Best_Move_FinishingColumnNumber == 6)
                        HY_Finishing_Column_Text = "f";
                    else if (Best_Move_FinishingColumnNumber == 7)
                        HY_Finishing_Column_Text = "g";
                    else if (Best_Move_FinishingColumnNumber == 8)
                        HY_Finishing_Column_Text = "h";

                    #region ObsoleteCode
                    // If king is moved, no castling can occur
                    //v0.980: Removed all this code! It is not used anyway!
                    //if (MovingPiece.CompareTo("White King") == 0)
                    //    White_King_Moved = true;
                    //else if (MovingPiece.CompareTo("Black King") == 0)
                    //    Bl_King_Moved = false;
                    //else if (MovingPiece.CompareTo("White Rook") == 0)
                    //{
                    //    if ((Best_Move_StartingColumnNumber == 1) && (Best_Move_StartingRank == 1))
                    //        White_Rook_a1_Moved = false;
                    //    else if ((Best_Move_StartingColumnNumber == 8) && (Best_Move_StartingRank == 1))
                    //        White_Rook_h1_Moved = false;
                    //}
                    //else if (MovingPiece.CompareTo("Black Rook") == 0)
                    //{
                    //    if ((Best_Move_StartingColumnNumber == 1) && (Best_Move_StartingRank == 8))
                    //        Bl_Rook_a8_Moved = false;
                    //    else if ((Best_Move_StartingColumnNumber == 8) && (Best_Move_StartingRank == 8))
                    //        Bl_Rook_h8_Moved = false;
                    //}
                    #endregion ObsoleteCode

                    // Is there a pawn to promote?

                    // v0.980: (m_WhoPlays.CompareTo("HY") == 0) not needed, we are in ComputerMove anyway!
                    // if (((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0)) && (m_WhoPlays.CompareTo("HY") == 0))
                    if ((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0))
                    {
                        if (Best_Move_FinishingRank == 8)
                        {
                            Skakiera[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = "White Queen";
                            MessageBox.Show("Queen!");
                            //Console.WriteLine("Queen!");
                        }
                        else if (Best_Move_FinishingRank == 1)
                        {
                            Skakiera[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = "Black Queen";
                            MessageBox.Show("Queen!");
                            //Console.WriteLine("Queen!");
                        }
                    }

                    //////////////////////////////////////////////////////////////////////
                    // Show HY move
                    //////////////////////////////////////////////////////////////////////

                    #region ObsoleteCode
                    // UNCOMMENT TO SHOW THINKING TIME!
                    // Uncomment to have the program record the start and stop time to a log .txt file
                    // StreamWriter huo_sw2 = new StreamWriter("game.txt", true);
                    // MessageBox.Show(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                    // huo_sw2.WriteLine(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                    // MessageBox.Show(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                    // huo_sw2.WriteLine(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                    #endregion ObsoleteCode

                    // v0.980: No need to have NextLine
                    NextLine = String.Concat(HY_Starting_Column_Text, Best_Move_StartingRank.ToString(), " -> ", HY_Finishing_Column_Text, Best_Move_FinishingRank.ToString());
                    //Console.WriteLine(String.Concat("My move: ", HY_Starting_Column_Text, Best_Move_StartingRank.ToString(), " -> ", HY_Finishing_Column_Text, Best_Move_FinishingRank.ToString()));
                    //Display_board(Skakiera);
                    //MessageBox.Show(number_of_moves_analysed.ToString());
                    //MessageBox.Show(NextLine);

                    // v0.980: Removed
                    number_of_moves_analysed = 0;

                    #region ObsoleteCode
                    // v0.980: Added Move = Move + 1; in the second "if"
                    // Αν ο υπολογιστής παίζει με τα λευκά, τότε αυξάνεται τώρα το νούμερο της κίνησης.
                    // If the computer plays with Wh, now is the time to increase the number of moves in the game.
                    // if (m_PlayerColor.CompareTo("Black") == 0)
                    //     Move = Move + 1;
                    #endregion ObsoleteCode

                    // Now it is the other color's turn to play
                    if (m_PlayerColor.CompareTo("Black") == 0)
                    {
                        m_WhichColorPlays = "Black";
                        Move = Move + 1;
                    }
                    else if (m_PlayerColor.CompareTo("White") == 0)
                        m_WhichColorPlays = "White";

                    // Now it is the Human's turn to play
                    m_WhoPlays = "Human";
                }
                // v0.981: If no move found => Resign
                else
                {
                    MessageBox.Show("I resign!");
                    //Console.WriteLine("I resign!");
                }
            }

            // v0.970: Changed the return type to integer to help memory usage
            // v0.970: Return to basics! Remove too much sauce!
            // v0.980: Changed to be more simple. Removed DangerWeight from the parameters of the function.
            // v0.990: Changes
            // v0.991: Added a penalty for stupid moves and moves to dangerous squares
            public static int CountScore(string[,] CSSkakiera)
            {
                // White pieces: positive score
                // Black pieces: negative score

                Current_Move_Score = 0;

                // v0.991: Have the stupid move generate penalty in the score, without blocking the analysis of moves (all the moves are analyzed)!
                if (ThisIsStupidMove.CompareTo("Y") == 0)
                {
                    if (m_PlayerColor.CompareTo("White") == 0)
                        Current_Move_Score = Current_Move_Score + 1;
                    else if (m_PlayerColor.CompareTo("Black") == 0)
                        Current_Move_Score = Current_Move_Score - 1;
                }

                // v0.991: Added a penalty for moving to dangerous square, without blocking the analysis of moves (all the moves are analyzed)!
                if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] != 0))
                {
                    if (m_PlayerColor.CompareTo("White") == 0)
                        Current_Move_Score = Current_Move_Score + 1;
                    else if (m_PlayerColor.CompareTo("Black") == 0)
                        Current_Move_Score = Current_Move_Score - 1;
                }

                // v0.991: Add points if possibility to eat is true
                if ((possibility_to_eat == true))
                {
                    if (m_PlayerColor.CompareTo("White") == 0)
                        Current_Move_Score = Current_Move_Score - 1;
                    else if (m_PlayerColor.CompareTo("Black") == 0)
                        Current_Move_Score = Current_Move_Score + 1;
                }

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {
                        if (CSSkakiera[(i), (j)].CompareTo("White Pawn") == 0)
                            Current_Move_Score = Current_Move_Score + 1;
                        else if (CSSkakiera[(i), (j)].CompareTo("White Rook") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 5;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White Knight") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 3;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White Bishop") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 3;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White Queen") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 9;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White King") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 15;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Pawn") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 1;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Rook") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 5;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Knight") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 3;
                            // Decrease score based on the danger in which the piece is in
                            // v0.970: Delete tis polles malakies
                            // Current_Move_Score = Current_Move_Score + DangerWeight * CheckDanger_Bl(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Bishop") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 3;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Queen") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 9;
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black King") == 0)
                            Current_Move_Score = Current_Move_Score - 15;    //v0.990: Changed + to -

                    }
                }

                return Current_Move_Score;
            }

            // FUNCTION TO CHECK THE LEGALITY (='Nomimotita' in Greek) OF A MOVE
            // (i.e. if between the initial and the destination square lies another piece, then the move is not legal).
            // The ElegxosNomimotitas "checkForDanger" function differs from the normal function in that it does not make all the validations
            // (since it is used to check for "Dangerous" squares in the chessboard and not to actually judge the correctness of an actual move)
            public static bool ElegxosNomimotitas(string[,] ENSkakiera, int checkForDanger, int startRank, int startColumn, int finishRank, int finishColumn, String MovingPiece_EN)
            {
                //v0.990: Changed MovingPiece_2 to MovingPiece_EN
                String ProsorinoKommati_EN;  // Replaced ProsorinoKommati_KingCheck

                // TODO: Add your control notification handler code here

                bool Nomimotita;
                //Console.WriteLine("into Elegxos Nomimotitas");

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος της "ΝΟΜΙΜΟΤΗΤΑΣ" της κίνησης. Αν π.χ. ο χρήστης έχει επιλέξει να κινήσει έναν πύργο από
                // το α2 στο α5, αλλά στο α4 υπάρχει κάποιο πιόνι του, τότε η Nomimotita έχει τιμή false.
                // Η συνάρτηση "επιστρέφει" τη boolean μεταβλητή Nomimotita.
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////

                Nomimotita = true;

                if (((finishRank - 1) > 7) || ((finishRank - 1) < 0) || ((finishColumn - 1) > 7) || ((finishColumn - 1) < 0))
                    Nomimotita = false;

                // if a piece of the same colour is in the destination square...
                if (checkForDanger == 0)
                {
                    if ((MovingPiece_EN.CompareTo("White King") == 0) || (MovingPiece_EN.CompareTo("White Queen") == 0) || (MovingPiece_EN.CompareTo("White Rook") == 0) || (MovingPiece_EN.CompareTo("White Knight") == 0) || (MovingPiece_EN.CompareTo("White Bishop") == 0) || (MovingPiece_EN.CompareTo("White Pawn") == 0))
                    {
                        if ((ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White King") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Queen") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Rook") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Knight") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Bishop") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Pawn") == 0))
                        {
                            Nomimotita = false;
                        }
                    }
                    else if ((MovingPiece_EN.CompareTo("Black King") == 0) || (MovingPiece_EN.CompareTo("Black Queen") == 0) || (MovingPiece_EN.CompareTo("Black Rook") == 0) || (MovingPiece_EN.CompareTo("Black Knight") == 0) || (MovingPiece_EN.CompareTo("Black Bishop") == 0) || (MovingPiece_EN.CompareTo("Black Pawn") == 0))
                    {
                        if ((ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black King") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Queen") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Rook") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Knight") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Bishop") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Pawn") == 0))
                            Nomimotita = false;
                    }
                }

                if (MovingPiece_EN.CompareTo("White King") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        /////////////////////////
                        // WK
                        /////////////////////////
                        // Is the king threatened in the destination square?
                        // Temporarily move king
                        // huo_sw1.WriteLine(String.Concat("[Point X1 -> ", ENSkakiera[(4), (0)].ToString(), "]"));

                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "";
                        //V0.990
                        //ProsorinoKommati_KingCheck = ENSkakiera[(finishColumn - 1), (finishRank - 1)];
                        ProsorinoKommati_EN = ENSkakiera[(finishColumn - 1), (finishRank - 1)];
                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = "White King";

                        WhiteKingCheck = CheckForWhiteCheck(ENSkakiera);

                        //huo_sw1.WriteLine(String.Concat("[Point X2 -> ", ENSkakiera[4, 0].ToString(), "]"));

                        if (WhiteKingCheck == true)
                            Nomimotita = false;

                        // Restore pieces

                        // v0.990: Switched line order in restoration of King, because if the starting and destination points are the same, then the King will dissapear! :)
                        // ENSkakiera[(startColumn - 1), (startRank - 1)] = "White King";
                        // v0.990 QUESTION: How can this change affect the table Skakiera_Thinking_HY_2 in Analyze_Move_2_ComputerMove?
                        // v0.990 test of the way changes in ENSkakiera affect the original table in the calling function: ENSkakiera[(startColumn - 1), (startRank - 1)] = "Trela!";
                        // huo_sw1.WriteLine(String.Concat("[Point X3 -> ", ENSkakiera[4, 0].ToString(), "]"));

                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = ProsorinoKommati_EN; //v0.990 ProsorinoKommati_KingCheck;
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "White King";
                    }
                }
                else if (MovingPiece_EN.CompareTo("Black King") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        ///////////////////////////
                        // BK
                        ///////////////////////////
                        // Is the BK threatened in the destination square?
                        // Temporarily move king
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "";
                        // v0.990
                        // ProsorinoKommati_KingCheck = ENSkakiera[(finishColumn - 1), (finishRank - 1)];
                        ProsorinoKommati_EN = ENSkakiera[(finishColumn - 1), (finishRank - 1)];
                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = "Black King";

                        BlackKingCheck = CheckForBlackCheck(ENSkakiera);

                        if (BlackKingCheck == true)
                            Nomimotita = false;

                        // Restore pieces

                        // v0.990: Switched line order in restoration of King, because if the starting and destination points are the same, then the King will dissapear! :)
                        // ENSkakiera[(startColumn - 1), (startRank - 1)] = "Black King";

                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = ProsorinoKommati_EN; //v0.990 ProsorinoKommati_KingCheck;
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "Black King";
                    }
                }
                else if (MovingPiece_EN.CompareTo("White Pawn") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        //Console.WriteLine("checking WP");

                        /////////////////////
                        // WP
                        /////////////////////

                        // Move forward

                        if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                        {
                            if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1)
                            {
                                //Console.WriteLine("pawn Nomimotita false");
                                Nomimotita = false;
                            }
                        }

                        // Move forward for 2 squares
                        else if ((finishRank == (startRank + 2)) && (finishColumn == startColumn))
                        {
                            if (startRank == 2)
                            {
                                if ((ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1) || (ENSkakiera[(finishColumn - 1), (finishRank - 1 - 1)].CompareTo("") == 1))
                                    Nomimotita = false;
                            }
                        }

                        // Eat forward to the right

                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn + 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    Nomimotita = false;
                            }
                        }

                        // Eat forward to the left

                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn - 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    Nomimotita = false;
                            }
                        }
                    }
                }
                else if (MovingPiece_EN.CompareTo("Black Pawn") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        /////////////////////
                        // BP
                        /////////////////////

                        // Move forward

                        if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                        {
                            if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1)
                                Nomimotita = false;
                        }

                        // Move forward for 2 squares
                        else if ((finishRank == (startRank - 2)) && (finishColumn == startColumn))
                        {
                            if (startRank == 7)
                            {
                                if ((ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1) || (ENSkakiera[(finishColumn - 1), (finishRank + 1 - 1)].CompareTo("") == 1))
                                    Nomimotita = false;
                            }
                        }

                        // Eat forward to the right

                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn + 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    Nomimotita = false;
                            }
                        }

                        // Eat forward to the left

                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn - 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    Nomimotita = false;
                            }
                        }
                    }
                }
                else if ((MovingPiece_EN.CompareTo("White Rook") == 0) || (MovingPiece_EN.CompareTo("White Queen") == 0) || (MovingPiece_EN.CompareTo("White Bishop") == 0) || (MovingPiece_EN.CompareTo("Black Rook") == 0) || (MovingPiece_EN.CompareTo("Black Queen") == 0) || (MovingPiece_EN.CompareTo("Black Bishop") == 0))
                {
                    h = 0;
                    p = 0;
                    //hhh = 0;
                    how_to_move_Rank = 0;
                    how_to_move_Column = 0;

                    if (((finishRank - 1) > (startRank - 1)) || ((finishRank - 1) < (startRank - 1)))
                        how_to_move_Rank = ((finishRank - 1) - (startRank - 1)) / System.Math.Abs((finishRank - 1) - (startRank - 1));

                    if (((finishColumn - 1) > (startColumn - 1)) || ((finishColumn - 1) < (startColumn - 1)))
                        how_to_move_Column = ((finishColumn - 1) - (startColumn - 1)) / System.Math.Abs((finishColumn - 1) - (startColumn - 1));

                    exit_elegxos_nomimothtas = false;

                    do
                    {
                        h = h + how_to_move_Rank;
                        p = p + how_to_move_Column;

                        if ((((startRank - 1) + h) == (finishRank - 1)) && ((((startColumn - 1) + p)) == (finishColumn - 1)))
                            exit_elegxos_nomimothtas = true;

                        if ((startColumn - 1 + p) < 0)
                            exit_elegxos_nomimothtas = true;
                        else if ((startRank - 1 + h) < 0)
                            exit_elegxos_nomimothtas = true;
                        else if ((startColumn - 1 + p) > 7)
                            exit_elegxos_nomimothtas = true;
                        else if ((startRank - 1 + h) > 7)
                            exit_elegxos_nomimothtas = true;

                        // If a piece exists between the initial and the destination square, then the move is illegal!
                        if (exit_elegxos_nomimothtas == false)
                        {
                            if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("White Rook") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("White Knight") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("White Bishop") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("White Queen") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("White King") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("White Pawn") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }

                            if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("Black Rook") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("Black Knight") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("Black Bishop") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("Black Queen") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("Black King") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                            else if (ENSkakiera[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("Black Pawn") == 0)
                            {
                                Nomimotita = false;
                                exit_elegxos_nomimothtas = true;
                            }
                        }
                    } while (exit_elegxos_nomimothtas == false);
                }
                return Nomimotita;
            }

            // FUNCTION TO CHECK THE CORRECTNESS (='Orthotita' in Greek) OF THE MOVE
            // (i.e. a Bishop can only move in diagonals, rooks in lines and columns etc)
            // The ElegxosOrthotitas "checkForDanger" mode differs from the ElegxosOrthotitas normal mode in that it does not make all the validations
            // (since it is used to check for "Dangerous" squares in the chessboard and not to actually judge the correctness of an actual move)
            public static bool ElegxosOrthotitas(string[,] EOSkakiera, int checkForDanger, int startRank, int startColumn, int finishRank, int finishColumn, String MovingPiece_EO)
            {
                // v0.990: Changed MovingPiece_2 to MovingPiece_EO
                // TODO: Add your control notification handler code here
                // If called for checking dangerous squares, put a virtual piece in the destination square so as to pass the validation checks
                // if (checkForDanger == 1)
                // Don't care about checking for the existence of a piece in the destination square

                bool Orthotita;
                Orthotita = false;
                enpassant_occured = false;

                //Console.WriteLine("ElegxosOrthotitas");
                //Console.WriteLine(MovingPiece_EO);

                if ((m_WhoPlays.CompareTo("Human") == 0) && (m_WrongColumn == false) && (MovingPiece_EO.CompareTo("") == 1))    // Αν ο χρήστης έχει γράψει μία έγκυρη στήλη και έχει
                {                                                         // επιλέξει να κινήσει ένα κομμάτι (και δεν έχει επι-
                                                                          // λέξει να κινήσει ένα "κενό" τετράγωνο) και είναι η σειρά του να παίξει, τότε να γί-
                                                                          // νει έλεγχος της ορθότητας της κίνησης. 

                    // Console.WriteLine("1");

                    // ROOK

                    if ((MovingPiece_EO.CompareTo("White Rook") == 0) || (MovingPiece_EO.CompareTo("Black Rook") == 0))
                    {
                        if ((finishColumn != startColumn) && (finishRank == startRank))       // Κίνηση σε στήλη
                            Orthotita = true;
                        else if ((finishRank != startRank) && (finishColumn == startColumn))  // Κίνηση σε γραμμή
                            Orthotita = true;
                    }

                    // Horse (with knight...)

                    if ((MovingPiece_EO.CompareTo("White Knight") == 0) || (MovingPiece_EO.CompareTo("Black Knight") == 0))
                    {
                        if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank + 2)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn + 2)) && (finishRank == (startRank - 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank - 2)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank - 2)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 2)) && (finishRank == (startRank - 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 2)) && (finishRank == (startRank + 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank + 2)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn + 2)) && (finishRank == (startRank + 1)))
                            Orthotita = true;
                    }

                    // Bishop

                    if ((MovingPiece_EO.CompareTo("White Bishop") == 0) || (MovingPiece_EO.CompareTo("Black Bishop") == 0))
                    {
                        ////////////////////
                        // 2009 v4 change
                        ////////////////////
                        //if ((Math.Abs(finishColumn - startColumn)) == (Math.Abs(finishRank - startRank)))
                        //    Orthotita = true;
                        if (((Math.Abs(finishColumn - startColumn)) == (Math.Abs(finishRank - startRank))) && (finishColumn != startColumn) && (finishRank != startRank))
                            Orthotita = true;
                        ////////////////////
                        // 2009 v4 change
                        ////////////////////
                    }

                    // Queen

                    if ((MovingPiece_EO.CompareTo("White Queen") == 0) || (MovingPiece_EO.CompareTo("Black Queen") == 0))
                    {
                        if ((finishColumn != startColumn) && (finishRank == startRank))       // Κίνηση σε στήλη
                            Orthotita = true;
                        else if ((finishRank != startRank) && (finishColumn == startColumn))  // Κίνηση σε γραμμή
                            Orthotita = true;

                        ////////////////////
                        // 2009 v4 change
                        ////////////////////
                        // move in diagonals
                        //if ((Math.Abs(finishColumn - startColumn)) == (Math.Abs(finishRank - startRank)))
                        //    Orthotita = true;
                        if (((Math.Abs(finishColumn - startColumn)) == (Math.Abs(finishRank - startRank))) && (finishColumn != startColumn) && (finishRank != startRank))
                            Orthotita = true;
                        ////////////////////
                        // 2009 v4 change
                        ////////////////////
                    }

                    // King

                    if ((MovingPiece_EO.CompareTo("White King") == 0) || (MovingPiece_EO.CompareTo("Black King") == 0))
                    {
                        // Move in rows and columns

                        if ((finishColumn == (startColumn + 1)) && (finishRank == startRank))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == startRank))
                            Orthotita = true;
                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                            Orthotita = true;
                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                            Orthotita = true;

                        // Move in diagonals

                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank + 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank - 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank - 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank + 1)))
                            Orthotita = true;

                    }

                    // WP

                    if (MovingPiece_EO.CompareTo("White Pawn") == 0)
                    {
                        // Move forward
                        // Console.WriteLine("2");

                        if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                            Orthotita = true;

                        // Move forward for 2 squares
                        else if ((finishRank == (startRank + 2)) && (finishColumn == startColumn) && (startRank == 2))
                            Orthotita = true;

                        else if ((finishRank == (startRank + 1)) && ((finishColumn == (startColumn - 1)) || (finishColumn == (startColumn + 1))))
                        {
                            if (checkForDanger == 0)
                            {
                                // Eat forward to the left
                                if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn - 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Queen") == 0)))
                                    Orthotita = true;

                                // Eat forward to the right
                                if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn + 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Queen") == 0)))
                                    Orthotita = true;
                            }
                            else if (checkForDanger == 1)
                            {
                                Orthotita = true;
                            }
                        }

                        // En Passant eat forward to the left
                        else if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn - 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                //Console.WriteLine(finishRank.ToString());
                                //Console.WriteLine(finishColumn.ToString());
                                //Console.WriteLine("checking En passant...");
                                if ((finishRank == 6) && (EOSkakiera[(finishColumn - 1), (4)].CompareTo("Black Pawn") == 0))
                                {
                                    Orthotita = true;
                                    enpassant_occured = true;
                                    EOSkakiera[(finishColumn - 1), (finishRank - 1 - 1)] = "";
                                    //Console.WriteLine("En passant true");
                                }
                                else
                                {
                                    Orthotita = false;
                                    enpassant_occured = false;
                                }
                            }
                        }

                        // En Passant eat forward to the right
                        else if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn + 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                if ((finishRank == 6) && (EOSkakiera[(finishColumn - 1), (4)].CompareTo("Black Pawn") == 0))
                                {
                                    Orthotita = true;
                                    enpassant_occured = true;
                                    EOSkakiera[(finishColumn - 1), (finishRank - 1 - 1)] = "";
                                }
                                else
                                {
                                    Orthotita = false;
                                    enpassant_occured = false;
                                }
                            }
                        }

                    }


                    // BP

                    if (MovingPiece_EO.CompareTo("Black Pawn") == 0)
                    {
                        // Move forward

                        if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                            Orthotita = true;

                        // Move forward for 2 squares
                        else if ((finishRank == (startRank - 2)) && (finishColumn == startColumn) && (startRank == 7))
                            Orthotita = true;

                        else if ((finishRank == (startRank - 1)) && ((finishColumn == (startColumn + 1)) || (finishColumn == (startColumn - 1))))
                        {
                            if (checkForDanger == 0)
                            {
                                // Eat forward to the left
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Queen") == 0)))
                                    Orthotita = true;

                                // Eat forward to the right
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn - 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Queen") == 0)))
                                    Orthotita = true;
                            }
                            else if (checkForDanger == 1)
                            {
                                // Eat forward to the left
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)))
                                    Orthotita = true;

                                // Eat forward to the right
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn - 1)))
                                    Orthotita = true;
                            }
                        }

                        // En Passant eat forward to the left
                        else if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                if ((finishRank == 3) && (EOSkakiera[(finishColumn - 1), (3)].CompareTo("White Pawn") == 0))
                                {
                                    Orthotita = true;
                                    enpassant_occured = true;
                                    EOSkakiera[(finishColumn - 1), (finishRank + 1 - 1)] = "";
                                }
                                else
                                {
                                    Orthotita = false;
                                    enpassant_occured = false;
                                }
                            }
                        }

                        // En Passant eat forward to the right
                        else if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn - 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                if ((finishRank == 3) && (EOSkakiera[(finishColumn - 1), (3)].CompareTo("White Pawn") == 0))
                                {
                                    Orthotita = true;
                                    enpassant_occured = true;
                                    EOSkakiera[(finishColumn - 1), (finishRank + 1 - 1)] = "";
                                }
                                else
                                {
                                    Orthotita = false;
                                    enpassant_occured = false;
                                }
                            }
                        }

                    }

                }

                //Console.WriteLine(Orthotita.ToString());
                return Orthotita;
            }

            // v0.970: Fixed comments
            // v0.980: Fixed it!
            // v0.990 changes
            public static void Enter_move()
            {
                // Validate the move the Hu opponent entered

                // Show the move entered by the Hu player

                if (m_StartingColumn.CompareTo("A") == 0)
                    m_StartingColumnNumber = 1;
                else if (m_StartingColumn.CompareTo("B") == 0)
                    m_StartingColumnNumber = 2;
                else if (m_StartingColumn.CompareTo("C") == 0)
                    m_StartingColumnNumber = 3;
                else if (m_StartingColumn.CompareTo("D") == 0)
                    m_StartingColumnNumber = 4;
                else if (m_StartingColumn.CompareTo("E") == 0)
                    m_StartingColumnNumber = 5;
                else if (m_StartingColumn.CompareTo("F") == 0)
                    m_StartingColumnNumber = 6;
                else if (m_StartingColumn.CompareTo("G") == 0)
                    m_StartingColumnNumber = 7;
                else if (m_StartingColumn.CompareTo("H") == 0)
                    m_StartingColumnNumber = 8;


                if (m_FinishingColumn.CompareTo("A") == 0)
                    m_FinishingColumnNumber = 1;
                else if (m_FinishingColumn.CompareTo("B") == 0)
                    m_FinishingColumnNumber = 2;
                else if (m_FinishingColumn.CompareTo("C") == 0)
                    m_FinishingColumnNumber = 3;
                else if (m_FinishingColumn.CompareTo("D") == 0)
                    m_FinishingColumnNumber = 4;
                else if (m_FinishingColumn.CompareTo("E") == 0)
                    m_FinishingColumnNumber = 5;
                else if (m_FinishingColumn.CompareTo("F") == 0)
                    m_FinishingColumnNumber = 6;
                else if (m_FinishingColumn.CompareTo("G") == 0)
                    m_FinishingColumnNumber = 7;
                else if (m_FinishingColumn.CompareTo("H") == 0)
                    m_FinishingColumnNumber = 8;


                // Is it his turn?
                if (m_WhoPlays.CompareTo("HY") == 0)   // Αν είναι η σειρά του υπολογιστή να παίξει (και όχι του χρήστη), τότε άκυρο!!
                    Console.WriteLine("Not your turn");  // v0.980: Reduced the text everywhere

                // Is the column entered valid?

                // Αν χρήστης έχει εισάγει μία έγκυρη στήλη (π.χ. "ε" ή "ζ") και πάει να κινήσει ένα κομμάτι του σωστού
                // χρώματος (π.χ. έναν λευκό ίππο και είναι πράγματι η σειρά των λευκών να παίξουν) τότε να προχωρήσει το
                // πρόγραμμα σε ό,τι κάνει.
                // Δεν είναι απαραίτητο να γίνει και έλεγχος του αν ο χρήστης έχει γράψει σωστή γραμμή (ήτοι ένα
                // νούμερο από το 1 έως το 8), διότι αυτό απαγορεύεται από τη δήλωση των μεταβλητών m_StartingRank και
                // m_FinishingRank (οι οποίες έχουν δηλωθεί σαν ακέραιοι που παίρνουν τιμές από 1 έως 8).

                //v0.980: Convert small strings to Int. Make "else if" -> "if"
                if (((m_WhoPlays.CompareTo("Human") == 0)) && (((m_WhichColorPlays.CompareTo("White") == 0) && ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Pawn") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White King") == 0))) || ((m_WhichColorPlays.CompareTo("Black") == 0) && ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Pawn") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black King") == 0)))))
                {

                    m_WrongColumn = false;
                    MovingPiece = Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];
                }
                else
                {
                    m_WrongColumn = true;
                }

                // Check correctness of move entered
                m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                // Check legality of move entered (only if it is correct - so as to save time!)
                if (m_OrthotitaKinisis == true)
                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                // Check if the Human's king is in check even after his move!
                // Temporarily move the piece the user wants to move
                Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                ProsorinoKommati = Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                // Check if king is still under check
                WhiteKingCheck = CheckForWhiteCheck(Skakiera);

                if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
                    m_NomimotitaKinisis = false;

                // Check if BK is still under check
                BlackKingCheck = CheckForBlackCheck(Skakiera);

                if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
                    m_NomimotitaKinisis = false;

                // Restore all pieces to the initial state
                Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = ProsorinoKommati;


                // CHECK IF THE Hu HAS ENTERED A CASTLING MOVE
                // v0.980: Simplify & Add the m_OrthotitaKinisis = false cases so as to work correctly!
                #region checkCastling

                // White castling

                // Small castling
                if ((m_PlayerColor.CompareTo("White") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 7) && (m_StartingRank == 1) && (m_FinishingRank == 1))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White King") == 0) && (Skakiera[(7), (0)].CompareTo("White Rook") == 0) && (Skakiera[(5), (0)].CompareTo("") == 0) && (Skakiera[(6), (0)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }

                // Big castling
                if ((m_PlayerColor.CompareTo("White") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 3) && (m_StartingRank == 1) && (m_FinishingRank == 1))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White King") == 0) && (Skakiera[(0), (0)].CompareTo("White Rook") == 0) && (Skakiera[(1), (0)].CompareTo("") == 0) && (Skakiera[(2), (0)].CompareTo("") == 0) && (Skakiera[(3), (0)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }

                // Black castling

                // Small castling
                if ((m_PlayerColor.CompareTo("Black") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 7) && (m_StartingRank == 8) && (m_FinishingRank == 8))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black King") == 0) && (Skakiera[(7), (7)].CompareTo("Black Rook") == 0) && (Skakiera[(5), (7)].CompareTo("") == 0) && (Skakiera[(6), (7)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }

                // Big castling
                if ((m_PlayerColor.CompareTo("Black") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 3) && (m_StartingRank == 8) && (m_FinishingRank == 8))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black King") == 0) && (Skakiera[(0), (7)].CompareTo("Black Rook") == 0) && (Skakiera[(1), (7)].CompareTo("") == 0) && (Skakiera[(2), (7)].CompareTo("") == 0) && (Skakiera[(3), (7)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }
                #endregion checkCastling

                // v0.990
                // Promotion
                if ((MovingPiece.CompareTo("White Pawn") == 0) && (m_FinishingRank == 8))
                    MovingPiece = "White Queen";
                if ((MovingPiece.CompareTo("Black Pawn") == 0) && (m_FinishingRank == 1))
                    MovingPiece = "Black Queen";

                // Redraw the chessboard
                if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                {
                    if ((MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                        ValueOfHumanMovingPiece = 5;
                    if ((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                        ValueOfHumanMovingPiece = 3;
                    if ((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                        ValueOfHumanMovingPiece = 3;
                    if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0))
                        ValueOfHumanMovingPiece = 9;
                    if ((MovingPiece.CompareTo("White King") == 0) || (MovingPiece.CompareTo("Black King") == 0))
                        ValueOfHumanMovingPiece = 119;
                    if ((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0))
                        ValueOfHumanMovingPiece = 1;

                    // Game moves increase by 1 move only when the player plays, so as to avoid increasing the game moves every half-move!)
                    //v0.980: Removed! It was increased in another place as well!
                    //if (m_PlayerColor.CompareTo("White") == 0)
                    //    Move = Move + 1;

                    // Erase initial square
                    Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";

                    Human_last_move_target_column = -1;
                    Human_last_move_target_row = -1;
                    // v0.980: String comparisons with '== 1' transformed to '!= 0'
                    if (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("") != 0)
                    {
                        Human_last_move_target_column = m_FinishingColumnNumber;
                        Human_last_move_target_row = m_FinishingRank;
                        //MessageBox.Show("target column: ");
                        //MessageBox.Show(target_column.ToString());
                        //MessageBox.Show("target rank: ");
                        //MessageBox.Show(target_row.ToString());
                    }

                    // Go to destination square
                    Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                    // Check for en passant
                    #region checkEnPassant
                    if (enpassant_occured == true)
                    {
                        if (m_PlayerColor.CompareTo("White") == 0)
                            Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 - 1)] = "";
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                            Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 + 1)] = "";
                    }

                    ////////////////////////////////////////////////////////////////////
                    // Record possible square when the next one playing will be able to perform en passant
                    ////////////////////////////////////////////////////////////////////
                    if ((m_StartingRank == 2) && (m_FinishingRank == 4))
                    {
                        enpassant_possible_target_rank = m_FinishingRank - 1;
                        enpassant_possible_target_column = m_FinishingColumnNumber;
                    }
                    else if ((m_StartingRank == 7) && (m_FinishingRank == 5))
                    {
                        enpassant_possible_target_rank = m_FinishingRank + 1;
                        enpassant_possible_target_column = m_FinishingColumnNumber;
                    }
                    else
                    {
                        // Invalid value for enpassant move (= enpassant not possible in the next move)
                        enpassant_possible_target_rank = -9;
                        enpassant_possible_target_column = -9;
                    }
                    #endregion checkEnPassant

                    // Check if castling occured (so as to move the rook next to the moving king)
                    #region castlingOccured
                    if (Castling_Occured == true)
                    {
                        if (m_PlayerColor.CompareTo("White") == 0)
                        {
                            if (Skakiera[(6), (0)].CompareTo("White King") == 0)
                            {
                                Skakiera[(5), (0)] = "White Rook";
                                Skakiera[(7), (0)] = "";
                                //MessageBox.Show( "Ο λευκός κάνει μικρό ροκε." );
                            }
                            else if (Skakiera[(2), (0)].CompareTo("White King") == 0)
                            {
                                Skakiera[(3), (0)] = "White Rook";
                                Skakiera[(0), (0)] = "";
                                //MessageBox.Show( "Ο λευκός κάνει μεγάλο ροκε." );
                            }
                        }
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                        {
                            if (Skakiera[(6), (7)].CompareTo("Black King") == 0)
                            {
                                Skakiera[(5), (7)] = "Black Rook";
                                Skakiera[(7), (7)] = "";
                                //MessageBox.Show( "Ο μαύρος κάνει μικρό ροκε." );
                            }
                            else if (Skakiera[(2), (7)].CompareTo("Black King") == 0)
                            {
                                Skakiera[(3), (7)] = "Black Rook";
                                Skakiera[(0), (7)] = "";
                                //MessageBox.Show( "Ο μαύρος κάνει μεγάλο ροκε." );
                            }
                        }

                        // Restore the Castling_Occured variable to false, so as to avoid false castlings in the future!
                        Castling_Occured = false;
                    }
                    #endregion castlingOccured

                    // Does a pawn needs promotion?
                    PawnPromotion();

                    // v0.980: This is not required
                    //if ((m_PlayerColor.CompareTo("White") == 0) || (m_PlayerColor.CompareTo("Black") == 0))
                    m_WhoPlays = "HY";

                    // It is the other color's turn to play
                    if (m_WhichColorPlays.CompareTo("White") == 0)
                        m_WhichColorPlays = "Black";
                    else if (m_WhichColorPlays.CompareTo("Black") == 0)
                        m_WhichColorPlays = "White";

                    // Restore variable values to initial values
                    m_StartingColumn = "";
                    m_FinishingColumn = "";
                    m_StartingRank = 1;
                    m_FinishingRank = 1;

                    // CHECK MESSAGE
                    WhiteKingCheck = CheckForWhiteCheck(Skakiera);
                    BlackKingCheck = CheckForBlackCheck(Skakiera);

                    if ((WhiteKingCheck == true) || (BlackKingCheck == true))
                    {
                        //Console.WriteLine("CHECK!");
                        MessageBox.Show("CHECK!");
                    }


                    // If it is the turn of the HY to play, then call the respective HY Thought function
                    if (m_WhoPlays.CompareTo("HY") == 0)
                    {
                        Move_Analyzed = 0;
                        Stop_Analyzing = false;
                        First_Call = true;
                        Best_Move_Found = false;
                        Who_Is_Analyzed = "HY";
                    }

                }

                else
                {
                    //v0.980: Simplify
                    //Console.WriteLine("Invalid move");
                    MessageBox.Show("Invalid move");
                    //v0.980: These are not required. WhoPlayes will remain unchanged if move is not legal
                    //Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                    //MovingPiece = "";
                    //m_WhoPlays = "Human";
                }


            }

            //v0.980: Reduced code size
            public static void PawnPromotion()
            {
                for (i = 0; i <= 7; i++)
                {
                    if ((Skakiera[(i), (0)].CompareTo("Black Pawn") == 0) && (m_WhoPlays.CompareTo("Human") == 0))
                    {
                        ///////////////////////////
                        // Promote pawn
                        ///////////////////////////

                        Skakiera[(i), (0)] = "Black Queen";

                        // v0.991: Need to fix this, so that the user can select what to promote the pawn to!

                        //Console.WriteLine("Promote to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop? ");
                        //choise_of_user = Int32.Parse(Console.ReadLine());

                        //switch (choise_of_user)
                        //{
                        //    case 1:
                        //        Skakiera[(i), (0)] = "Black Queen";
                        //        break;

                        //    case 2:
                        //        Skakiera[(i), (0)] = "Black Rook";
                        //        break;

                        //    case 3:
                        //        Skakiera[(i), (0)] = "Black Knight";
                        //        break;

                        //    case 4:
                        //        Skakiera[(i), (0)] = "Black Bishop";
                        //        break;
                        //};

                    }


                    if ((Skakiera[(i), (7)].CompareTo("White Pawn") == 0) && (m_WhoPlays.CompareTo("Human") == 0))
                    {
                        ///////////////////////////
                        // Promote pawn
                        ///////////////////////////

                        Skakiera[(i), (7)] = "White Queen";

                        // v0.991: Need to fix this, so that the user can select what to promote the pawn to!

                        //Console.WriteLine("Promote to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop? ");
                        //choise_of_user = Int32.Parse(Console.ReadLine());

                        //switch (choise_of_user)
                        //{
                        //    case 1:
                        //        Skakiera[(i), (7)] = "White Queen";
                        //        break;

                        //    case 2:
                        //        Skakiera[(i), (7)] = "White Rook";
                        //        break;

                        //    case 3:
                        //        Skakiera[(i), (7)] = "White Knight";
                        //        break;

                        //    case 4:
                        //        Skakiera[(i), (7)] = "White Bishop";
                        //        break;
                        //};
                    }

                }
            }

            // Setup the starting position
            // v0.990 Test: Changed the starting position. Remember to reset again! :)
            public static void Starting_position()
            {
                // TODO: Add your control notification handler code here

                for (int a = 0; a <= 7; a++)
                {
                    for (int b = 0; b <= 7; b++)
                    {
                        Skakiera[(a), (b)] = "";
                    }
                }

                // Initial
                Skakiera[(0), (0)] = "White Rook";
                Skakiera[(0), (1)] = "White Pawn";
                Skakiera[(0), (6)] = "Black Pawn";
                Skakiera[(0), (7)] = "Black Rook";
                Skakiera[(1), (0)] = "White Knight";
                Skakiera[(1), (1)] = "White Pawn";
                Skakiera[(1), (6)] = "Black Pawn";
                Skakiera[(1), (7)] = "Black Knight";
                Skakiera[(2), (0)] = "White Bishop";
                Skakiera[(2), (1)] = "White Pawn";
                Skakiera[(2), (6)] = "Black Pawn";
                Skakiera[(2), (7)] = "Black Bishop";
                Skakiera[(3), (0)] = "White Queen";
                Skakiera[(3), (1)] = "White Pawn";
                Skakiera[(3), (6)] = "Black Pawn";
                Skakiera[(3), (7)] = "Black Queen";
                Skakiera[(4), (0)] = "White King";
                Skakiera[(4), (1)] = "White Pawn";
                Skakiera[(4), (6)] = "Black Pawn";
                Skakiera[(4), (7)] = "Black King";
                Skakiera[(5), (0)] = "White Bishop";
                Skakiera[(5), (1)] = "White Pawn";
                Skakiera[(5), (6)] = "Black Pawn";
                Skakiera[(5), (7)] = "Black Bishop";
                Skakiera[(6), (0)] = "White Knight";
                Skakiera[(6), (1)] = "White Pawn";
                Skakiera[(6), (6)] = "Black Pawn";
                Skakiera[(6), (7)] = "Black Knight";
                Skakiera[(7), (0)] = "White Rook";
                Skakiera[(7), (1)] = "White Pawn";
                Skakiera[(7), (6)] = "Black Pawn";
                Skakiera[(7), (7)] = "Black Rook";

                // v0.990 Test1: Will the computer eat the bishop at B4?
                //Skakiera[(0), (0)] = "White Rook";
                //Skakiera[(0), (1)] = "White Pawn";
                //Skakiera[(0), (6)] = "Black Pawn";
                //Skakiera[(0), (7)] = "Black Rook";
                //Skakiera[(1), (0)] = "White Knight";
                //Skakiera[(1), (1)] = "White Pawn";
                //Skakiera[(1), (6)] = "Black Pawn";
                //Skakiera[(1), (7)] = "Black Knight";
                //Skakiera[(2), (0)] = "White Bishop";
                //Skakiera[(2), (2)] = "White Pawn";
                //Skakiera[(2), (6)] = "Black Pawn";
                //Skakiera[(2), (7)] = "Black Bishop";
                //Skakiera[(3), (0)] = "White Queen";
                //Skakiera[(3), (1)] = "";
                //Skakiera[(3), (4)] = "Black Pawn";
                //Skakiera[(3), (7)] = "Black Queen";
                //Skakiera[(4), (0)] = "White King";
                //Skakiera[(4), (1)] = "White Pawn";
                //Skakiera[(4), (4)] = "Black Pawn";
                //Skakiera[(4), (7)] = "Black King";
                //Skakiera[(5), (0)] = "White Bishop";
                //Skakiera[(5), (1)] = "White Pawn";
                //Skakiera[(5), (6)] = "Black Pawn";
                //Skakiera[(5), (7)] = "Black Bishop";
                //Skakiera[(6), (0)] = "White Knight";
                //Skakiera[(6), (1)] = "White Pawn";
                //Skakiera[(6), (6)] = "Black Pawn";
                //Skakiera[(6), (7)] = "Black Knight";
                //Skakiera[(7), (0)] = "White Rook";
                //Skakiera[(7), (1)] = "White Pawn";
                //Skakiera[(7), (6)] = "Black Pawn";
                //Skakiera[(7), (7)] = "Black Rook";
                //v0.990 Test result: Moves a2 -> a4. The first move analyzed since all have the same score.
                // PROBLEM 1
                // If black plays bishop to b4, then white playes Knight at a3.
                // (note: the above move is made if you disable the Check Stupid Move by putting "if Move < 0" instead of "if Move < 5".
                // HOWEVER, if we set up the same position programatically (see below), white plays a different move! (Qb3)
                // There must be a problem in the initialization of variables in ComputerMove!
                // STATUS: PROBLEM SOLVED! (with v0.990)
                // PROBLEM 2
                // If black plays bishop at B4 will the computer eat it?
                // Now with the possibility_to_eat functionality it will!

                // v0.990 Test2: Will the computer eat bishop at b4?
                //Skakiera[(0), (0)] = "White Rook";
                //Skakiera[(0), (3)] = "White Pawn";  // Moved
                //Skakiera[(0), (6)] = "Black Pawn";
                //Skakiera[(0), (7)] = "Black Rook";
                //Skakiera[(1), (0)] = "White Knight";
                //Skakiera[(1), (1)] = "White Pawn";
                //Skakiera[(1), (6)] = "Black Pawn";
                //Skakiera[(1), (7)] = "Black Knight";
                //Skakiera[(2), (0)] = "White Bishop";
                //Skakiera[(2), (2)] = "White Pawn";
                //Skakiera[(2), (6)] = "Black Pawn";
                //Skakiera[(2), (7)] = "Black Bishop";
                //Skakiera[(3), (0)] = "White Queen";
                //Skakiera[(3), (1)] = "";
                //Skakiera[(3), (4)] = "Black Pawn";
                //Skakiera[(3), (7)] = "Black Queen";
                //Skakiera[(4), (0)] = "White King";
                //Skakiera[(4), (1)] = "White Pawn";
                //Skakiera[(4), (4)] = "Black Pawn";
                //Skakiera[(4), (7)] = "Black King";
                //Skakiera[(5), (0)] = "White Bishop";
                //Skakiera[(5), (1)] = "White Pawn";
                //Skakiera[(5), (6)] = "Black Pawn";
                //Skakiera[(1), (3)] = "Black Bishop";  // Changed from (5),(7) to (1),(3)
                //Skakiera[(6), (0)] = "White Knight";
                //Skakiera[(6), (1)] = "White Pawn";
                //Skakiera[(6), (6)] = "Black Pawn";
                //Skakiera[(6), (7)] = "Black Knight";
                //Skakiera[(7), (0)] = "White Rook";
                //Skakiera[(7), (1)] = "White Pawn";
                //Skakiera[(7), (6)] = "Black Pawn";
                //Skakiera[(7), (7)] = "Black Rook";
                // PROBLEM:
                // Computer plays queen to b3. Why doesn't it eat the bishop? To be analyzed...
                // (after I fix the problem with the initialization of ComputerMove)
                // STATUS: After I added the possibility_to_eat this behavior has changed...

                // v0.991: Will the computer move the threatened bishop? And why not?
                //Skakiera[(0), (0)] = "White Rook";
                //Skakiera[(0), (1)] = "White Pawn";
                //Skakiera[(0), (6)] = "Black Pawn";
                //Skakiera[(0), (7)] = "Black Rook";
                //Skakiera[(1), (0)] = "White Knight";
                //Skakiera[(1), (1)] = "White Pawn";
                //Skakiera[(1), (6)] = "Black Pawn";
                //Skakiera[(1), (7)] = "Black Knight";
                ////Skakiera[(2), (0)] = "White Bishop";
                //Skakiera[(2), (2)] = "White Pawn";
                //Skakiera[(2), (6)] = "Black Pawn";
                //Skakiera[(2), (7)] = "Black Bishop";
                //Skakiera[(3), (0)] = "White Queen";
                //Skakiera[(3), (3)] = "White Pawn";
                //Skakiera[(3), (4)] = "Black Pawn";
                //Skakiera[(3), (7)] = "Black Queen";
                //Skakiera[(4), (0)] = "White King";
                //Skakiera[(4), (1)] = "White Pawn";
                //Skakiera[(4), (5)] = "Black Pawn";
                //Skakiera[(4), (3)] = "White Bishop";
                //Skakiera[(4), (7)] = "Black King";
                //Skakiera[(5), (0)] = "White Bishop";
                //Skakiera[(5), (1)] = "White Pawn";
                //Skakiera[(5), (6)] = "Black Pawn";
                //Skakiera[(5), (7)] = "Black Bishop";
                //Skakiera[(6), (0)] = "White Knight";
                //Skakiera[(6), (1)] = "White Pawn";
                //Skakiera[(6), (6)] = "Black Pawn";
                //Skakiera[(6), (7)] = "Black Knight";
                //Skakiera[(7), (0)] = "White Rook";
                //Skakiera[(7), (1)] = "White Pawn";
                //Skakiera[(7), (6)] = "Black Pawn";
                //Skakiera[(7), (7)] = "Black Rook";

                // V0.991 [Scenario V0991.A]
                // v0.991: Will the computer play f4->c7? And why?
                //Skakiera[(0), (0)] = "White Rook";
                //Skakiera[(0), (1)] = "White Pawn";
                //Skakiera[(0), (6)] = "Black Pawn";
                //Skakiera[(0), (7)] = "Black Rook";
                //Skakiera[(1), (0)] = "White Knight";
                //Skakiera[(1), (1)] = "White Pawn";
                //Skakiera[(1), (6)] = "Black Pawn";
                //Skakiera[(1), (7)] = "Black Knight";
                ////Skakiera[(2), (0)] = "White Bishop";
                //Skakiera[(2), (2)] = "White Pawn";
                //Skakiera[(2), (6)] = "Black Pawn";
                //Skakiera[(2), (7)] = "Black Bishop";
                //Skakiera[(3), (0)] = "White Queen";
                //Skakiera[(3), (3)] = "White Pawn";
                //Skakiera[(3), (4)] = "Black Pawn";
                //Skakiera[(3), (7)] = "Black Queen";
                //Skakiera[(4), (0)] = "White King";
                //Skakiera[(4), (1)] = "White Pawn";
                //Skakiera[(4), (5)] = "Black Pawn";
                //Skakiera[(5), (3)] = "White Bishop";
                //Skakiera[(4), (7)] = "Black King";
                //Skakiera[(5), (0)] = "White Bishop";
                //Skakiera[(5), (1)] = "White Pawn";
                //Skakiera[(5), (6)] = "Black Pawn";
                //Skakiera[(5), (7)] = "Black Bishop";
                //Skakiera[(6), (0)] = "White Knight";
                //Skakiera[(6), (1)] = "White Pawn";
                //Skakiera[(6), (6)] = "Black Pawn";
                //Skakiera[(6), (7)] = "Black Knight";
                //Skakiera[(7), (0)] = "White Rook";
                //Skakiera[(7), (1)] = "White Pawn";
                //Skakiera[(7), (6)] = "Black Pawn";
                //Skakiera[(7), (7)] = "Black Rook";

                // V0.991 [Scenario V0991.B]
                // v0.991: Will the computer eat the knight?
                //         RESULT: Success
                //Skakiera[(0), (0)] = "White Rook";
                //Skakiera[(0), (1)] = "White Pawn";
                //Skakiera[(0), (6)] = "Black Pawn";
                //Skakiera[(0), (7)] = "Black Rook";
                //Skakiera[(1), (0)] = "White Knight";
                //Skakiera[(1), (1)] = "White Pawn";
                //Skakiera[(1), (6)] = "Black Pawn";
                //Skakiera[(1), (7)] = "Black Knight";
                //Skakiera[(2), (0)] = "White Bishop";
                //Skakiera[(2), (1)] = "White Pawn";
                //Skakiera[(2), (6)] = "Black Pawn";
                //Skakiera[(2), (7)] = "Black Bishop";
                //Skakiera[(3), (0)] = "White Queen";
                //Skakiera[(3), (1)] = "White Pawn";
                //Skakiera[(3), (6)] = "Black Pawn";
                //Skakiera[(3), (7)] = "Black Queen";
                //Skakiera[(4), (0)] = "White King";
                //Skakiera[(4), (4)] = "White Pawn";
                //Skakiera[(4), (6)] = "Black Pawn";
                //Skakiera[(4), (7)] = "Black King";
                //Skakiera[(5), (0)] = "White Bishop";
                //Skakiera[(5), (1)] = "White Pawn";
                //Skakiera[(5), (6)] = "Black Pawn";
                //Skakiera[(5), (7)] = "Black Bishop";
                //Skakiera[(6), (0)] = "White Knight";
                //Skakiera[(6), (1)] = "White Pawn";
                //Skakiera[(6), (6)] = "Black Pawn";
                //Skakiera[(5), (5)] = "Black Knight";
                //Skakiera[(7), (0)] = "White Rook";
                //Skakiera[(7), (1)] = "White Pawn";
                //Skakiera[(7), (6)] = "Black Pawn";
                //Skakiera[(7), (7)] = "Black Rook";

                m_WhichColorPlays = "White";
            }

            public static void Analyze_Move_1_HumanMove(string[,] Skakiera_Human_Thinking_2)
            {
                #region WriteLog
                if (activateLogs == true)
                {
                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("HMT2 -- Entered Analyze_Move_1_HumanMove");
                    huo_sw1.WriteLine(string.Concat("HMT2 -- Depth analyzed: ", Move_Analyzed.ToString()));
                    huo_sw1.WriteLine(string.Concat("HMT2 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                    huo_sw1.WriteLine(string.Concat("HMT2 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                    huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));

                    //v0.990
                    //huo_sw1.WriteLine("");
                    //huo_sw1.WriteLine("CHESSBOARD MOVE 1 - START");
                    //huo_sw1.WriteLine("-----------------------------------------");
                    //for (int yj = 7; yj >= 0; yj--)
                    //{
                    //    huo_sw1.WriteLine(String.Concat("| ", Skakiera_Human_Thinking_2[0, yj], " | ", Skakiera_Human_Thinking_2[1, yj], " | ", Skakiera_Human_Thinking_2[2, yj], " | ", Skakiera_Human_Thinking_2[3, yj], " | ", Skakiera_Human_Thinking_2[4, yj], " | ", Skakiera_Human_Thinking_2[5, yj], " | ", Skakiera_Human_Thinking_2[6, yj], " | ", Skakiera_Human_Thinking_2[7, yj], " |"));
                    //    huo_sw1.WriteLine("-----------------------------------------");
                    //}
                    //huo_sw1.WriteLine("");

                    #region WriteLog
                    //v0.990
                    for (i = 0; i <= 7; i++)
                    {
                        for (j = 0; j <= 7; j++)
                        {
                            switch (Skakiera_Human_Thinking_2[(i), (j)])
                            {
                                case "White Rook":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "WR";
                                    break;

                                case "White Knight":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "WN";
                                    break;

                                case "White Bishop":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "WB";
                                    break;

                                case "White Queen":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "WQ";
                                    break;

                                case "White King":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "WK";
                                    break;

                                case "White Pawn":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "WP";
                                    break;

                                case "Black Rook":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "BR";
                                    break;

                                case "Black Knight":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "BN";
                                    break;

                                case "Black Bishop":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "BB";
                                    break;

                                case "Black Queen":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "BQ";
                                    break;

                                case "Black King":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "BK";
                                    break;

                                case "Black Pawn":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "BP";
                                    break;

                                case "":
                                    NodesAnalysis1_Chessboard_before[i, j, NodeLevel_1_count] = "  ";
                                    break;
                            }
                        }
                    }

                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("CHESSBOARD Move 1 (upon calling function)");
                    huo_sw1.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw1.WriteLine(String.Concat("| ", NodesAnalysis1_Chessboard_before[0, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[1, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[2, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[3, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[4, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[5, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[6, yj, NodeLevel_1_count], " | ", NodesAnalysis1_Chessboard_before[7, yj, NodeLevel_1_count], " |"));
                        huo_sw1.WriteLine("-----------------------------------------");
                    }
                    huo_sw1.WriteLine("CHESSBOARD Move 1 - END");
                    huo_sw1.WriteLine("");
                    #endregion WriteLog

                    //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                    //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                    //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                    //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                    //huo_sw1.WriteLine("");
                }
                #endregion WriteLog

                // v0.990 change: The best score for every move will be stored at each level. Only if the new move analyzed
                // has a better score than the best score, will it be analyzed (target: trim the analysis tree)
                int bestScoreLevel1 = 0;

                // Scan chessboard . Find a piece of the Hu player . Move to all possible squares.
                // Check corr1ectness and legality of move . If all OK then measure the move's score.
                // Do the best move and handle over to the ComputerMove function to continue analysis in the next move (deeper depth...)
                // v0.990: Initialized the values
                int skakos1 = 0;
                int trelos35 = 0;
                String MovingPiece1 = "";
                String ProsorinoKommati1 = "";
                int m_StartingColumnNumber1 = 0;
                int m_FinishingColumnNumber1 = 0;
                int m_StartingRank1 = 0;
                int m_FinishingRank1 = 0;

                // v0.990: Added a new separate chessboard ('skakiera' in Greek) to pass over information from one function to the other.
                String[,] Skakiera_Move_After_1 = new String[8, 8];

                // Check all possible moves
                for (skakos1 = 0; skakos1 <= 7; skakos1++)
                {
                    for (trelos35 = 0; trelos35 <= 7; trelos35++)
                    {
                        // v0.990: (Who_Is_Analyzed.CompareTo("Hu") == 0) -> (Who_Is_Analyzed.CompareTo("Human") == 0)
                        if (((Who_Is_Analyzed.CompareTo("Human") == 0) && ((((Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("Black King") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("Black Queen") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("Black Rook") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("Black Knight") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("Black Bishop") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("White King") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("White Queen") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("White Rook") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("White Knight") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("White Bishop") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos35)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    // v0.990: Removed the m_FinishingRank column and replace with m_FinishingRank1
                                    MovingPiece1 = Skakiera_Human_Thinking_2[(skakos1), (trelos35)];
                                    m_StartingColumnNumber1 = skakos1 + 1;
                                    m_FinishingColumnNumber1 = w + 1;
                                    m_StartingRank1 = trelos35 + 1;
                                    m_FinishingRank1 = r + 1;

                                    #region ObsoleteCode
                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    // v0.990: Removed the m_FinishingRank column and replace with m_FinishingRank1
                                    // MovingPiece1 = MovingPiece;
                                    // m_StartingColumnNumber1 = m_StartingColumnNumber;
                                    // m_FinishingColumnNumber1 = m_FinishingColumnNumber;
                                    // m_StartingRank1 = m_StartingRank;
                                    // m_FinishingRank1 = m_FinishingRank;
                                    #endregion ObsoleteCode

                                    ProsorinoKommati1 = Skakiera_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)];

                                    // Check the move
                                    // v0.980: Removed
                                    number_of_moves_analysed++;

                                    // Necessary values for variables for the ElegxosOrthotitas (check move corr1ectness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    // v0.990: MovingPiece -> MovingPiece1
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Human_Thinking_2, 0, m_StartingRank1, m_StartingColumnNumber1, m_FinishingRank1, m_FinishingColumnNumber1, MovingPiece1);
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Human_Thinking_2, 0, m_StartingRank1, m_StartingColumnNumber1, m_FinishingRank1, m_FinishingColumnNumber1, MovingPiece1);
                                    // Restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // v0.991
                                        #region MoveText
                                        String m_StartingColumnNumber1_moveText;
                                        String m_FinishingColumnNumber1_moveText;

                                        switch (m_StartingColumnNumber1)
                                        {
                                            case (1):
                                                m_StartingColumnNumber1_moveText = "a";
                                                break;

                                            case (2):
                                                m_StartingColumnNumber1_moveText = "b";
                                                break;

                                            case (3):
                                                m_StartingColumnNumber1_moveText = "c";
                                                break;

                                            case (4):
                                                m_StartingColumnNumber1_moveText = "d";
                                                break;

                                            case (5):
                                                m_StartingColumnNumber1_moveText = "e";
                                                break;

                                            case (6):
                                                m_StartingColumnNumber1_moveText = "f";
                                                break;

                                            case (7):
                                                m_StartingColumnNumber1_moveText = "g";
                                                break;

                                            case (8):
                                                m_StartingColumnNumber1_moveText = "h";
                                                break;

                                            default:
                                                m_StartingColumnNumber1_moveText = "Error";
                                                break;
                                        }

                                        switch (m_FinishingColumnNumber1)
                                        {
                                            case (1):
                                                m_FinishingColumnNumber1_moveText = "a";
                                                break;

                                            case (2):
                                                m_FinishingColumnNumber1_moveText = "b";
                                                break;

                                            case (3):
                                                m_FinishingColumnNumber1_moveText = "c";
                                                break;

                                            case (4):
                                                m_FinishingColumnNumber1_moveText = "d";
                                                break;

                                            case (5):
                                                m_FinishingColumnNumber1_moveText = "e";
                                                break;

                                            case (6):
                                                m_FinishingColumnNumber1_moveText = "f";
                                                break;

                                            case (7):
                                                m_FinishingColumnNumber1_moveText = "g";
                                                break;

                                            case (8):
                                                m_FinishingColumnNumber1_moveText = "h";
                                                break;

                                            default:
                                                m_FinishingColumnNumber1_moveText = "Error";
                                                break;
                                        }

                                        Move1_text = String.Concat(m_StartingColumnNumber1_moveText,
                                                                   m_StartingRank1.ToString(), " -> ",
                                                                   m_FinishingColumnNumber1_moveText,
                                                                   m_FinishingRank1.ToString());

                                        NodesAnalysis1_MoveText[NodeLevel_1_count] = Move1_text;
                                        #endregion MoveText

                                        // Do the move
                                        // v0.990: ProsorinoKommati -> ProsorinoKommati1, MovingPiece -> MovingPiece1
                                        ProsorinoKommati1 = Skakiera_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)];
                                        Skakiera_Human_Thinking_2[(m_StartingColumnNumber1 - 1), (m_StartingRank1 - 1)] = "";
                                        Skakiera_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)] = MovingPiece1;

                                        #region ObsoleteCode
                                        // Measure score AFTER the move
                                        //v0.990: Removed the "if (Move_Analyzed == 1)"
                                        //if (Move_Analyzed == 1)
                                        //{
                                        // v0.991 - This should not be done here!
                                        // NodeLevel_1_count++;
                                        //v0.990 test
                                        //if ((ThisIsStupidMove.CompareTo("Y") == 0) && (m_PlayerColor.CompareTo("Black") == 0))
                                        //    Temp_Score_Move_1_human = Temp_Score_Move_1_human - 100;
                                        //else if ((ThisIsStupidMove.CompareTo("Y") == 0) && (m_PlayerColor.CompareTo("White") == 0))
                                        //    Temp_Score_Move_1_human = Temp_Score_Move_1_human + 100;
                                        #endregion ObsoleteCode

                                        Temp_Score_Move_1_human = CountScore(Skakiera_Human_Thinking_2);

                                        // v0.990 change
                                        // Store the best move at this level
                                        // v0.991: Attention! Here this section will be removed if we want to start trimming the tree from this function! (see the Analyze_Move_2 for details on this)
                                        if ((m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_1_human < bestScoreLevel1))
                                        {
                                            bestScoreLevel1 = Temp_Score_Move_1_human;
                                        }
                                        else if ((m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_1_human > bestScoreLevel1))
                                        {
                                            bestScoreLevel1 = Temp_Score_Move_1_human;
                                        }

                                        #region WriteLog
                                        ////v0.990
                                        //NodesAnalysis1_Move[NodeLevel_1_count] = String.Concat("Move Analyzed for Node ", NodeLevel_1_count.ToString(), " [Level 1]: ", MovingPiece1, " ", m_StartingColumnNumber1.ToString(), m_StartingRank1.ToString(), " -> ", m_FinishingColumnNumber1.ToString(), m_FinishingRank1.ToString());

                                        ////v0.990
                                        //for (i = 0; i <= 7; i++)
                                        //{
                                        //    for (j = 0; j <= 7; j++)
                                        //    {
                                        //        switch (Skakiera_Human_Thinking_2[(i), (j)])
                                        //        {
                                        //            case "White Rook":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "WR";
                                        //                break;

                                        //            case "White Knight":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "WN";
                                        //                break;

                                        //            case "White Bishop":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "WB";
                                        //                break;

                                        //            case "White Queen":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "WQ";
                                        //                break;

                                        //            case "White King":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "WK";
                                        //                break;

                                        //            case "White Pawn":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "WP";
                                        //                break;

                                        //            case "Black Rook":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "BR";
                                        //                break;

                                        //            case "Black Knight":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "BN";
                                        //                break;

                                        //            case "Black Bishop":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "BB";
                                        //                break;

                                        //            case "Black Queen":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "BQ";
                                        //                break;

                                        //            case "Black King":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "BK";
                                        //                break;

                                        //            case "Black Pawn":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "BP";
                                        //                break;

                                        //            case "":
                                        //                NodesAnalysis1_Chessboard[i, j, NodeLevel_1_count] = "  ";
                                        //                break;
                                        //        }
                                        //    }
                                        //}
                                        #endregion WriteLog

                                        if (Move_Analyzed < Thinking_Depth)
                                        // Trim the tree
                                        // if ( ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_1_human >= bestScoreLevel1))
                                        //   || ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_1_human <= bestScoreLevel1)) )
                                        {
                                            // Call ComputerMove for the HY throught process to continue
                                            Move_Analyzed = Move_Analyzed + 1;

                                            Who_Is_Analyzed = "HY";

                                            // v0.990: Added new chessboard to pass over information between functions.
                                            // v0.990: Why copy everything in Skakiera_Move_After?
                                            // Just use Skakiera_Human_Thinking_2 directly! No!
                                            // Remember the problem with the "reference" of the array at with ElegxosNomimotitas!)
                                            // Arrays can be passed as arguments to method parameters. Because arrays are reference types, the method can change the value of the elements.
                                            // SOURCES...
                                            // https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/arrays/passing-arrays-as-arguments]
                                            // http://stackoverflow.com/questions/10325323/passing-arrays-by-value-and-by-reference
                                            // http://stackoverflow.com/questions/967402/are-arrays-or-lists-passed-by-default-by-reference-in-c

                                            String[,] Skakiera_Move_After_1_new = new String[8, 8];

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After_1[(i), (j)] = Skakiera_Human_Thinking_2[(i), (j)];
                                                    Skakiera_Move_After_1_new[(i), (j)] = Skakiera_Human_Thinking_2[(i), (j)];
                                                }
                                            }

                                            // v0.990: Skakiera_Move_After -> Skakiera_Move_After_1 -> Skakiera_Move_After_1_new
                                            if (Move_Analyzed == 2)
                                                Analyze_Move_2_ComputerMove(Skakiera_Move_After_1_new);
                                        }

                                        // Undo the move
                                        Skakiera_Human_Thinking_2[(m_StartingColumnNumber1 - 1), (m_StartingRank1 - 1)] = MovingPiece1;
                                        Skakiera_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)] = ProsorinoKommati1;

                                        // v0.991 - This should be done here!
                                        NodeLevel_1_count++;
                                    }

                                } // For 4
                            } // For 3

                        }// IF

                    } // For 2
                } // For 1

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "HY";
            }

            public static void Analyze_Move_3_HumanMove(string[,] Skakiera_Human_Thinking_3)
            {
                // v0.990 change: The best score for every move will be stored at each level. Only if the new move analyzed
                // has a better score than the best score, will it be analyzed (target: trim the analysis tree)
                int bestScoreLevel3 = 0;

                // Scan chessboard . Find a piece of the Hu player . Move to all possible squares.
                // Check correctness and legality of move . If all OK then measure the move's score.
                // Do the best move and handle over to the ComputerMove function to continue analysis in the next move (deeper depth...)
                // v0.990: Initialized the values
                int skakos3 = 0;
                int trelos35 = 0;
                String MovingPiece3 = "";
                String ProsorinoKommati3 = "";
                int m_StartingColumnNumber3 = 0;
                int m_FinishingColumnNumber3 = 0;
                int m_StartingRank3 = 0;
                int m_FinishingRank3 = 0;

                //v0.990
                String[,] Skakiera_Move_After_3 = new String[8, 8];

                // Check all possible moves
                for (skakos3 = 0; skakos3 <= 7; skakos3++)
                {
                    for (trelos35 = 0; trelos35 <= 7; trelos35++)
                    {
                        // v0.990: (Who_Is_Analyzed.CompareTo("Hu") == 0) -> (Who_Is_Analyzed.CompareTo("Human") == 0)
                        if (((Who_Is_Analyzed.CompareTo("Human") == 0) && ((((Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("Black King") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("Black Queen") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("Black Rook") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("Black Knight") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("Black Bishop") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("White King") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("White Queen") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("White Rook") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("White Knight") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("White Bishop") == 0) || (Skakiera_Human_Thinking_3[(skakos3), (trelos35)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    // v0.990: Removed the m_FinishingRank column and replace with m_FinishingRank3
                                    MovingPiece3 = Skakiera_Human_Thinking_3[(skakos3), (trelos35)];
                                    m_StartingColumnNumber3 = skakos3 + 1;
                                    m_FinishingColumnNumber3 = w + 1;
                                    m_StartingRank3 = trelos35 + 1;
                                    m_FinishingRank3 = r + 1;

                                    #region ObsoleteCode
                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    //v0.990: Removed the m_FinishingRank column and replace with m_FinishingRank3
                                    //MovingPiece3 = MovingPiece;
                                    //m_StartingColumnNumber3 = m_StartingColumnNumber;
                                    //m_FinishingColumnNumber3 = m_FinishingColumnNumber;
                                    //m_StartingRank3 = m_StartingRank;
                                    //m_FinishingRank3 = m_FinishingRank;
                                    #endregion ObsoleteCode

                                    ProsorinoKommati3 = Skakiera_Human_Thinking_3[(m_FinishingColumnNumber3 - 1), (m_FinishingRank3 - 1)];

                                    // Check the move
                                    // v0.980: Removed
                                    number_of_moves_analysed++;

                                    // Necessary values for variables for the ElegxosOrthotitas (check move corr1ectness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Human_Thinking_3, 0, m_StartingRank3, m_StartingColumnNumber3, m_FinishingRank3, m_FinishingColumnNumber3, MovingPiece3);
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Human_Thinking_3, 0, m_StartingRank3, m_StartingColumnNumber3, m_FinishingRank3, m_FinishingColumnNumber3, MovingPiece3);
                                    // Restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // Do the move
                                        // v0.990: ProsorinoKommati -> ProsorinoKommati3, MovingPiece -> MovingPiece3
                                        ProsorinoKommati3 = Skakiera_Human_Thinking_3[(m_FinishingColumnNumber3 - 1), (m_FinishingRank3 - 1)];
                                        Skakiera_Human_Thinking_3[(m_StartingColumnNumber3 - 1), (m_StartingRank3 - 1)] = "";
                                        Skakiera_Human_Thinking_3[(m_FinishingColumnNumber3 - 1), (m_FinishingRank3 - 1)] = MovingPiece3;

                                        NodeLevel_3_count++;
                                        Temp_Score_Move_3_human = CountScore(Skakiera_Human_Thinking_3);

                                        #region ObsoleteCode
                                        //v0.990 test
                                        //if ((ThisIsStupidMove.CompareTo("Y") == 0) && (m_PlayerColor.CompareTo("Black") == 0))
                                        //    Temp_Score_Move_1_human = Temp_Score_Move_1_human - 100;
                                        //else if ((ThisIsStupidMove.CompareTo("Y") == 0) && (m_PlayerColor.CompareTo("White") == 0))
                                        //    Temp_Score_Move_1_human = Temp_Score_Move_1_human + 100;
                                        //}
                                        #endregion ObsoleteCode

                                        // if (Move_Analyzed < Thinking_Depth)
                                        // v0.990 test
                                        // v0.990 Move 4 changes: Trim the tree!
                                        if ( ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_3_human >= bestScoreLevel3))
                                          || ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_3_human <= bestScoreLevel3)) )
                                        {
                                            // Call ComputerMove for the HY throught process to continue
                                            Move_Analyzed = Move_Analyzed + 1;

                                            // v0.990 change: Store the best move at this level
                                            bestScoreLevel3 = Temp_Score_Move_3_human;

                                            Who_Is_Analyzed = "HY";

                                            String[,] Skakiera_Move_After_3_new = new String[8, 8];

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After_3[(i), (j)] = Skakiera_Human_Thinking_3[(i), (j)];
                                                    Skakiera_Move_After_3_new[(i), (j)] = Skakiera_Human_Thinking_3[(i), (j)];
                                                }
                                            }

                                            // v0.990: Skakiera_Move_After -> Skakiera_Move_After_3 -> Skakiera_Move_After_3_new
                                            if (Move_Analyzed == 2)
                                                Analyze_Move_2_ComputerMove(Skakiera_Move_After_3_new);
                                            else if (Move_Analyzed == 4)
                                                Analyze_Move_4_ComputerMove(Skakiera_Move_After_3_new);
                                        }

                                        // Undo the move
                                        Skakiera_Human_Thinking_3[(m_StartingColumnNumber3 - 1), (m_StartingRank3 - 1)] = MovingPiece3;
                                        Skakiera_Human_Thinking_3[(m_FinishingColumnNumber3 - 1), (m_FinishingRank3 - 1)] = ProsorinoKommati3;
                                    }

                                } // For 4
                            } // For 3

                        }// IF

                    } // For 2
                } // For 1

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "HY";
            }

            public static void Analyze_Move_2_ComputerMove(string[,] Skakiera_Thinking_HY_2)
            {
                #region WriteLog
                if (activateLogs == true)
                {
                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("CMT2 -- Entered Analyze_Move_2_ComputerMove");
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Depth analyzed: ", Move_Analyzed.ToString()));
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));

                    //v0.990
                    //huo_sw1.WriteLine("");
                    //huo_sw1.WriteLine("CHESSBOARD MOVE 2  - START");
                    //huo_sw1.WriteLine("-----------------------------------------");
                    //for (int yj = 7; yj >= 0; yj--)
                    //{
                    //    huo_sw1.WriteLine(String.Concat("| ", Skakiera_Thinking_HY_2[0, yj], " | ", Skakiera_Thinking_HY_2[1, yj], " | ", Skakiera_Thinking_HY_2[2, yj], " | ", Skakiera_Thinking_HY_2[3, yj], " | ", Skakiera_Thinking_HY_2[4, yj], " | ", Skakiera_Thinking_HY_2[5, yj], " | ", Skakiera_Thinking_HY_2[6, yj], " | ", Skakiera_Thinking_HY_2[7, yj], " |"));
                    //    huo_sw1.WriteLine("-----------------------------------------");
                    //}
                    //huo_sw1.WriteLine("");

                    //v0.990
                    for (i = 0; i <= 7; i++)
                    {
                        for (j = 0; j <= 7; j++)
                        {
                            switch (Skakiera_Thinking_HY_2[(i), (j)])
                            {
                                case "White Rook":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "WR";
                                    break;

                                case "White Knight":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "WN";
                                    break;

                                case "White Bishop":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "WB";
                                    break;

                                case "White Queen":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "WQ";
                                    break;

                                case "White King":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "WK";
                                    break;

                                case "White Pawn":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "WP";
                                    break;

                                case "Black Rook":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "BR";
                                    break;

                                case "Black Knight":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "BN";
                                    break;

                                case "Black Bishop":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "BB";
                                    break;

                                case "Black Queen":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "BQ";
                                    break;

                                case "Black King":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "BK";
                                    break;

                                case "Black Pawn":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "BP";
                                    break;

                                case "":
                                    NodesAnalysis2_Chessboard_before[i, j, NodeLevel_2_count] = "  ";
                                    break;
                            }
                        }
                    }

                    huo_sw1.WriteLine("");
                    huo_sw1.WriteLine("CHESSBOARD Move 2 (upon calling function)");
                    huo_sw1.WriteLine("-----------------------------------------");
                    for (int yj = 7; yj >= 0; yj--)
                    {
                        huo_sw1.WriteLine(String.Concat("| ", NodesAnalysis2_Chessboard_before[0, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[1, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[2, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[3, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[4, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[5, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[6, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_before[7, yj, NodeLevel_2_count], " |"));
                        huo_sw1.WriteLine("-----------------------------------------");
                    }
                    huo_sw1.WriteLine("CHESSBOARD Move 2 - END");
                    huo_sw1.WriteLine("");

                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                    huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                    huo_sw1.WriteLine("");
                }
                #endregion WriteLog

                // v0.990 change: The best score for every move will be stored at each level. Only if the new move analyzed
                // has a better score than the best score, will it be analyzed (target: trim the analysis tree)
                int bestScoreLevel2 = 0;

                // Δήλωση μεταβλητών που χρησιμοποιούνται στο βρόγχο "for" (δεν μπορεί να χρησιμοποιηθούν οι μεταβλητές i και j διότι αυτές οι
                // μεταβλητές είναι καθολικές και δημιουργείται πρόβλημα κατά την επιστροφή στην ComputerMove από την CheckMove)
                // v0.990: Initialized the values
                int iii2 = 0;
                int jjj2 = 0;
                String MovingPiece2 = "";
                String ProsorinoKommati2 = "";
                int m_StartingColumnNumber2 = 0;
                int m_FinishingColumnNumber2 = 0;
                int m_StartingRank2 = 0;
                int m_FinishingRank2 = 0;

                // v0.990: Added a new separate chessboard to communicate between different functions.
                String[,] Skakiera_Move_After_2 = new String[8, 8];

                //huo_sw1.WriteLine(String.Concat("[Point 0] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));

                // Σκανάρισμα της σκακιέρας: Όταν εντοπίζεται κάποιο κομμάτι του υπολογιστή,
                // θα υπολογίζονται ΟΛΕΣ οι πιθανές κινήσεις του προς κάθε κατεύθυνση, ακόμα
                // και αυτές που δεν μπορεί να κάνει το κομμάτι. Στη συνέχεια, με τη βοήθεια
                // των συναρτήσεων ElegxosNomimotitas και ElegxosOrthotitas θα ελέγχεται το
                // αν η κίνηση είναι ορθή και νόμιμη. Αν είναι, η εν λόγω κίνηση θα γίνεται
                // προσωρινά στη σκακιέρα και θα καταγράφεται το σκορ της νέας θέσης που προέκυψε

                // ΣΗΜΕΙΩΣΗ: Σε όλες τις στήλες και τις οριζόντιους προστίθεται η μονάδα (+1)
                // διότι πρέπει να μετατραπούν από το "σύστημα" μέτρησης "0-7" (που χρησιμο-
                // ποιείται στο παρακάτω "for i…next" αλλά και στο συμβολισμό του πίνακα
                // Skakiera) στο σύστημα μέτρησης "1-8" το οποίο χρησιμοποιείται στις
                // μεταβλητές Starting/Finishing_Column/Rank σε όλο το υπόλοιπο πρόγραμμα.

                for (iii2 = 0; iii2 <= 7; iii2++)
                {
                    for (jjj2 = 0; jjj2 <= 7; jjj2++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("White King") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("White Queen") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("White Rook") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("White Knight") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("Black King") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking_HY_2[(iii2), (jjj2)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            // huo_sw1.WriteLine(String.Concat("[Point 1] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));

                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    #region ObsoleteCode
                                    //huo_sw1.WriteLine(String.Concat("[Point 2] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));
                                    //v0.990: Replaced m_StartingColumnNumber with m_StartingColumnNumber2
                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    //v0.990: Removed this m_FinishingRank -> m_FinishingRank2 useless piece
                                    //MovingPiece2 = MovingPiece;
                                    //m_StartingColumnNumber2 = m_StartingColumnNumber2;
                                    //m_FinishingColumnNumber2 = m_FinishingColumnNumber;
                                    //m_StartingRank2 = m_StartingRank;
                                    //m_FinishingRank2 = m_FinishingRank;
                                    //huo_sw1.WriteLine(String.Concat("[Point 3] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));
                                    //huo_sw1.WriteLine(String.Concat("[Point 3] -> Move analyzed: ", MovingPiece2, " ", m_StartingColumnNumber2.ToString(), m_StartingRank2.ToString(), " -> ", m_FinishingColumnNumber2.ToString(), m_FinishingRank2.ToString()));
                                    //huo_sw1.WriteLine("");
                                    #endregion ObsoleteCode

                                    MovingPiece2 = Skakiera_Thinking_HY_2[(iii2), (jjj2)];
                                    m_StartingColumnNumber2 = iii2 + 1;
                                    m_FinishingColumnNumber2 = w + 1;
                                    m_StartingRank2 = jjj2 + 1;
                                    m_FinishingRank2 = r + 1;
                                    ProsorinoKommati2 = Skakiera_Thinking_HY_2[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)];

                                    // Έλεγχος της κίνησης (Check the move)

                                    // Validity and legality of the move has been checked in CheckMove
                                    // CheckMove(Skakiera_Thinking_HY_2);
                                    // v0.990: MovingPiece -> MovingPiece2

                                    // Check validity and legality
                                    // Necessary values for variables for the ElegxosOrthotitas (check move corr1ectness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    
                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Thinking_HY_2, 0, m_StartingRank2, m_StartingColumnNumber2, m_FinishingRank2, m_FinishingColumnNumber2, MovingPiece2);
                                    // huo_sw1.WriteLine(String.Concat("[Point 3.1] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));
                                    // v0.990 TEST: Here the King dissapears!!!! [START]
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Thinking_HY_2, 0, m_StartingRank2, m_StartingColumnNumber2, m_FinishingRank2, m_FinishingColumnNumber2, MovingPiece2);
                                    // v0.990 TEST: Here the King dissapears!!!! [END]
                                    // v0.990 QUESTION: How does the ElegxosNomimotitas function affect the Skakiera_Thinking_HY_2?
                                    // v0.990 ANSWER: By calling ElegxosNomimotitas and passing Skakiera_Thinking_HY_2 as reference, any change in the ENSkakiera array of ElegxosNomimotitas function is reflected in the Skakiera_Thinking_HY_2 because the ENSkakiera references the Skakiera_Thinking_HY_2! (I suppose so anyaway, this is the only logical explanation)
                                    
                                    // Restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    #region ObsoleteCode
                                    //huo_sw1.WriteLine(String.Concat("[Point 4] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));
                                    //huo_sw1.WriteLine(String.Concat("Orthotita  = ", m_OrthotitaKinisis.ToString()));
                                    //huo_sw1.WriteLine(String.Concat("Nomimotita = ", m_NomimotitaKinisis.ToString()));
                                    //v0.980: Removed
                                    //number_of_moves_analysed++;
                                    #endregion ObsoleteCode

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // v0.991
                                        #region MoveText
                                        String m_StartingColumnNumber2_moveText;
                                        String m_FinishingColumnNumber2_moveText;

                                        switch (m_StartingColumnNumber2)
                                        {
                                            case (1):
                                                m_StartingColumnNumber2_moveText = "a";
                                                break;

                                            case (2):
                                                m_StartingColumnNumber2_moveText = "b";
                                                break;

                                            case (3):
                                                m_StartingColumnNumber2_moveText = "c";
                                                break;

                                            case (4):
                                                m_StartingColumnNumber2_moveText = "d";
                                                break;

                                            case (5):
                                                m_StartingColumnNumber2_moveText = "e";
                                                break;

                                            case (6):
                                                m_StartingColumnNumber2_moveText = "f";
                                                break;

                                            case (7):
                                                m_StartingColumnNumber2_moveText = "g";
                                                break;

                                            case (8):
                                                m_StartingColumnNumber2_moveText = "h";
                                                break;

                                            default:
                                                m_StartingColumnNumber2_moveText = "Error";
                                                break;
                                        }

                                        switch (m_FinishingColumnNumber2)
                                        {
                                            case (1):
                                                m_FinishingColumnNumber2_moveText = "a";
                                                break;

                                            case (2):
                                                m_FinishingColumnNumber2_moveText = "b";
                                                break;

                                            case (3):
                                                m_FinishingColumnNumber2_moveText = "c";
                                                break;

                                            case (4):
                                                m_FinishingColumnNumber2_moveText = "d";
                                                break;

                                            case (5):
                                                m_FinishingColumnNumber2_moveText = "e";
                                                break;

                                            case (6):
                                                m_FinishingColumnNumber2_moveText = "f";
                                                break;

                                            case (7):
                                                m_FinishingColumnNumber2_moveText = "g";
                                                break;

                                            case (8):
                                                m_FinishingColumnNumber2_moveText = "h";
                                                break;

                                            default:
                                                m_FinishingColumnNumber2_moveText = "Error";
                                                break;
                                        }

                                        Move2_text = String.Concat(m_StartingColumnNumber2_moveText,
                                                                   m_StartingRank2.ToString(), " -> ",
                                                                   m_FinishingColumnNumber2_moveText,
                                                                   m_FinishingRank2.ToString());

                                        NodesAnalysis2_MoveText[NodeLevel_2_count] = Move2_text;
                                        #endregion MoveText

                                        //huo_sw1.WriteLine(string.Concat("Hu move 1: Found a legal move!"));
                                        //huo_sw1.WriteLine(String.Concat("[Point 5] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));

                                        // Do the move
                                        //v0.990: ProsorinoKommati -> ProsorinoKommati2, MovingPiece -> MovingPiece2
                                        ProsorinoKommati2 = Skakiera_Thinking_HY_2[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)];
                                        Skakiera_Thinking_HY_2[(m_StartingColumnNumber2 - 1), (m_StartingRank2 - 1)] = "";
                                        Skakiera_Thinking_HY_2[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)] = MovingPiece2;

                                        #region ObsoleteCode
                                        //huo_sw1.WriteLine(String.Concat("[Point 6] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));
                                        // Check the score after the computer move.
                                        //v0.980: This is Move Analyzed 2, so no need for the other ifs!
                                        //if (Move_Analyzed == 0)
                                        //{
                                        //    NodeLevel_0_count++;
                                        //    Temp_Score_Move_0 = CountScore(Skakiera_Thinking_HY_2, humanDangerParameter);
                                        //}
                                        //v0.990: Removed the "if (Move_Analyzed == 2)"
                                        //if (Move_Analyzed == 2)
                                        //{
                                        // v0.991 - This should not be done here!
                                        // NodeLevel_2_count++;
                                        #endregion ObsoleteCode

                                        //v0.980: Removed humanDangerParameter from every call of CountScore
                                        Temp_Score_Move_2 = CountScore(Skakiera_Thinking_HY_2);

                                        #region ObsoleteCode
                                        //v0.980: This is the end of the analysis, so no need to call anymore the Analyze_Move functions!
                                        //if (Move_Analyzed < Thinking_Depth)
                                        //{
                                        //    Move_Analyzed = Move_Analyzed + 1;

                                        //    for (i = 0; i <= 7; i++)
                                        //    {
                                        //        for (j = 0; j <= 7; j++)
                                        //        {
                                        //            Skakiera_Move_After[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                        //        }
                                        //    }

                                        //    Who_Is_Analyzed = "Hu";
                                        //    First_Call_Human_Thought = true;

                                        //    // Check Hu move
                                        //    if (Move_Analyzed == 1)
                                        //        Analyze_Move_1_HumanMove(Skakiera_Move_After);
                                        //}
                                        #endregion ObsoleteCode

                                        #region ObsoleteCode
                                        // v0.990 change: Added back the part which calls deeper levels of analysis
                                        // v0.990 change: Must trim the tree or else the app does not work and consums a lot of memory!
                                        // if (Move_Analyzed < Thinking_Depth)
                                        // v0.990 Move 4 changes: Trim the tree!
                                        // v0.991 change: Trim more?!
                                        // if (((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_2 <= (bestScoreLevel2 - 5)))
                                        //   || ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_2 >= (bestScoreLevel2 + 5))))
                                        #endregion ObsoleteCode

                                        // If thinking depth not reached? (Don't forget to trim the tree!)
                                        if (((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_2 <= bestScoreLevel2))
                                          || ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_2 >= bestScoreLevel2)))
                                            {
                                                Move_Analyzed = Move_Analyzed + 1;

                                            // v0.990 change
                                            // Store the best score at this level
                                            // v0.990 change: Moved it here, AFTER we check that the move is better than the existing best score!
                                            // v0.990 change: (if we have this outside the 'if' statement, then the conditions will always be met)
                                            bestScoreLevel2 = Temp_Score_Move_2;

                                            // v0.991: Keep this section! It is needed so as not to pass over the
                                            // existing chessboard as argument to the other function, which will
                                            // change it! (and we do not want this to happen)
                                            // v0.990: Skakiera_Move_After -> Skakiera_Move_After_2
                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After_2[(i), (j)] = Skakiera_Thinking_HY_2[(i), (j)];
                                                }
                                            }

                                            Who_Is_Analyzed = "Human";

                                            #region HuoChessHistory
                                            // v0.980 REMOVED First_Call_Human_Thought = true;
                                            // v0.990 Move 4 changes
                                            // Check human move
                                            //v0.990: Skakiera_Move_After -> Skakiera_Thinking_HY_2
                                            #endregion HuoChessHistory

                                            if (Move_Analyzed == 1)
                                                Analyze_Move_1_HumanMove(Skakiera_Move_After_2);
                                            else if (Move_Analyzed == 3)
                                                Analyze_Move_3_HumanMove(Skakiera_Move_After_2);
                                        }


                                        if (Move_Analyzed == Thinking_Depth)
                                        {
                                            // [MiniMax algorithm - skakos]
                                            // Record the node in the Nodes Analysis array (to use with MiniMax algorithm) skakos

                                            //v0.970
                                            NodesAnalysis0[NodeLevel_0_count, 0] = Temp_Score_Move_0;
                                            NodesAnalysis1[NodeLevel_1_count, 0] = Temp_Score_Move_1_human;
                                            NodesAnalysis2[NodeLevel_2_count, 0] = Temp_Score_Move_2;

                                            // v0.991: Text of the move variant analyzed (used for logs mainly)
                                            NodesAnalysis2_MoveText[NodeLevel_2_count] = String.Concat(Move0_text, " , ",
                                                                                                       Move1_text, " , ",
                                                                                                       Move2_text);

                                            NodesAnalysis1_MoveText[NodeLevel_1_count] = String.Concat(Move0_text, " , ",
                                                                                                       Move1_text);

                                            NodesAnalysis0_MoveText[NodeLevel_0_count] = String.Concat(Move0_text);

                                            // v0.991: Ability to activate/ deactivate logs easily
                                            #region WriteLog
                                            if (activateLogs == true)
                                            {
                                                huo_sw1.WriteLine("");
                                                huo_sw1.WriteLine("CMT2 --------------------------------------------");
                                                //huo_sw1.WriteLine(string.Concat("CMT2 -- VARIANT ANALYZED -- Level 1: ",
                                                //                  NodesAnalysis0_MoveText[NodeLevel_0_count]));
                                                //huo_sw1.WriteLine(string.Concat("CMT2 -- VARIANT ANALYZED -- Level 2: ",
                                                //                  NodesAnalysis0_MoveText[NodeLevel_0_count],
                                                //                  NodesAnalysis1_MoveText[NodeLevel_1_count]));
                                                huo_sw1.WriteLine(string.Concat("CMT2 -- VARIANT ANALYZED : ",
                                                                  NodesAnalysis2_MoveText[NodeLevel_2_count]));
                                                huo_sw1.WriteLine(string.Concat("CMT2 -- FINAL SCORE REACHED : ",
                                                                  NodesAnalysis2[NodeLevel_2_count, 0].ToString()));
                                                huo_sw1.WriteLine("CMT2 --------------------------------------------");
                                            }
                                            #endregion WriteLog

                                            // v0.992 - Store the average score of the branch
                                            // (do this here or in the ComputerMove function at the MiniMax algorithm section directly)
                                            // NodesAnalysisA[NodeLevel_2_count, 0] = (Temp_Score_Move_0 +
                                            //                                         Temp_Score_Move_1_human +
                                            //                                         Temp_Score_Move_2) / 3;

                                            #region HuoChessLog
                                            ////v0.990
                                            //NodesAnalysis2_Move[NodeLevel_2_count] = String.Concat("Move Analyzed for Node ", NodeLevel_2_count.ToString(), " [Level 2]: ", MovingPiece2, " ", m_StartingColumnNumber2.ToString(), m_StartingRank2.ToString(), " -> ", m_FinishingColumnNumber2.ToString(), m_FinishingRank2.ToString());
                                            ////v0.990
                                            //for (i = 0; i <= 7; i++)
                                            //{
                                            //    for (j = 0; j <= 7; j++)
                                            //    {
                                            //        switch(Skakiera_Thinking_HY_2[(i), (j)])
                                            //        {
                                            //            case "White Rook":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "WR";
                                            //                break;

                                            //            case "White Knight":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "WN";
                                            //                break;

                                            //            case "White Bishop":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "WB";
                                            //                break;

                                            //            case "White Queen":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "WQ";
                                            //                break;

                                            //            case "White King":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "WK";
                                            //                break;

                                            //            case "White Pawn":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "WP";
                                            //                break;

                                            //            case "Black Rook":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "BR";
                                            //                break;

                                            //            case "Black Knight":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "BN";
                                            //                break;

                                            //            case "Black Bishop":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "BB";
                                            //                break;

                                            //            case "Black Queen":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "BQ";
                                            //                break;

                                            //            case "Black King":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "BK";
                                            //                break;

                                            //            case "Black Pawn":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "BP";
                                            //                break;

                                            //            case "":
                                            //                NodesAnalysis2_Chessboard[i, j, NodeLevel_2_count] = "  ";
                                            //                break;
                                            //        }
                                            //    }
                                            //}

                                            //huo_sw1.WriteLine("");
                                            //huo_sw1.WriteLine(String.Concat("CMT2 -- Computer 2nd move: ", NodesAnalysis2_Move[NodeLevel_2_count].ToString()));
                                            //huo_sw1.WriteLine("");
                                            //huo_sw1.WriteLine("CHESSBOARD (after final move of computer)");
                                            ////huo_sw1.WriteLine("-----------------------------------------");
                                            ////for (int yj = 7; yj >= 0; yj--)
                                            ////{
                                            ////    huo_sw1.WriteLine(String.Concat("| ", NodesAnalysis2_Chessboard[0, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[1, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[2, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[3, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[4, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[5, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[6, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard[7, yj, NodeLevel_2_count], " |"));
                                            ////    huo_sw1.WriteLine("-----------------------------------------");
                                            ////}
                                            //huo_sw1.WriteLine("");

                                            //huo_sw1.WriteLine(string.Concat("CMT2 -- Computer 2nd move: Above position corresponds to Node ", NodeLevel_2_count.ToString(), " of Level 2"));
                                            #endregion HuoChessLog

                                            // Store the parents (number of the node of the upper level)
                                            NodesAnalysis0[NodeLevel_0_count, 1] = 0;
                                            NodesAnalysis1[NodeLevel_1_count, 1] = NodeLevel_0_count;
                                            NodesAnalysis2[NodeLevel_2_count, 1] = NodeLevel_1_count;

                                            #region toRemove
                                            //v0.980: Removed
                                            //if (Danger_penalty == true)
                                            //{
                                            //    //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] - 2000000000;
                                            //    //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] + 2000000000;
                                            //}

                                            //if (go_for_it == true)
                                            //{
                                            //    //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] + 2000000000;
                                            //    //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] - 2000000000;
                                            //}
                                            #endregion toRemove

                                            //v0.980: removed
                                            Nodes_Total_count++;

                                            #region toRemove
                                            //v0.980: Removed
                                            // Safety valve in case we reach the end of the table capacity
                                            // This is a limit for the memory. Will have to do something about it!
                                            //if (Nodes_Total_count > 1000000)
                                            //{
                                            //    Console.WriteLine("Limit of memory in NodesAnalysis array reached!");
                                            //    Nodes_Total_count = 1000000;
                                            //}
                                            #endregion toRemove
                                        }

                                        #region toRemove
                                        //huo_sw1.WriteLine(String.Concat("[Point 7] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_2[4, 0].ToString()));

                                        //if (MovingPiece2.CompareTo("White King") == 0)
                                        //{
                                        //    huo_sw1.WriteLine("");
                                        //    huo_sw1.WriteLine("King moving...");
                                        //    huo_sw1.WriteLine(String.Concat("MovingPiece2 = ", MovingPiece2));
                                        //    huo_sw1.WriteLine(String.Concat("ProsorinoKommati2 = ", ProsorinoKommati2));
                                        //    huo_sw1.WriteLine("");
                                        //}
                                        //if ((MovingPiece2.CompareTo("White Pawn") == 0) && (m_StartingColumnNumber2 == 5) && (m_StartingRank2 == 2))
                                        //{
                                        //    huo_sw1.WriteLine("");
                                        //    huo_sw1.WriteLine("White Pawn e2 moving...");
                                        //    huo_sw1.WriteLine(String.Concat("Target column : ", m_FinishingColumnNumber2));
                                        //    huo_sw1.WriteLine(String.Concat("Target rank   : ", m_FinishingRank2));
                                        //    huo_sw1.WriteLine(String.Concat("MovingPiece2 = ", MovingPiece2));
                                        //    huo_sw1.WriteLine(String.Concat("ProsorinoKommati2 = ", ProsorinoKommati2));
                                        //    huo_sw1.WriteLine("");
                                        //}
                                        #endregion toRemove

                                        // Undo the move
                                        Skakiera_Thinking_HY_2[(m_StartingColumnNumber2 - 1), (m_StartingRank2 - 1)] = MovingPiece2;
                                        Skakiera_Thinking_HY_2[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)] = ProsorinoKommati2;

                                        // v0.991 - This should be done here!
                                        NodeLevel_2_count++;

                                        #region WriteLog
                                        //if ( (MovingPiece2.CompareTo("White King") == 0) ||
                                        //     ((MovingPiece2.CompareTo("White Pawn") == 0) && (m_StartingColumnNumber2 == 5) && (m_StartingRank2 == 2)) )
                                        //{
                                        //    huo_sw1.WriteLine("");
                                        //    huo_sw1.WriteLine("Restored chessboard...");
                                        //    for (i = 0; i <= 7; i++)
                                        //    {
                                        //        for (j = 0; j <= 7; j++)
                                        //        {
                                        //            switch (Skakiera_Thinking_HY_2[(i), (j)])
                                        //            {
                                        //                case "White Rook":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "WR";
                                        //                    break;

                                        //                case "White Knight":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "WN";
                                        //                    break;

                                        //                case "White Bishop":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "WB";
                                        //                    break;

                                        //                case "White Queen":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "WQ";
                                        //                    break;

                                        //                case "White King":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "WK";
                                        //                    break;

                                        //                case "White Pawn":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "WP";
                                        //                    break;

                                        //                case "Black Rook":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "BR";
                                        //                    break;

                                        //                case "Black Knight":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "BN";
                                        //                    break;

                                        //                case "Black Bishop":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "BB";
                                        //                    break;

                                        //                case "Black Queen":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "BQ";
                                        //                    break;

                                        //                case "Black King":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "BK";
                                        //                    break;

                                        //                case "Black Pawn":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "BP";
                                        //                    break;

                                        //                case "":
                                        //                    NodesAnalysis2_Chessboard_2[i, j, NodeLevel_2_count] = "  ";
                                        //                    break;
                                        //            }
                                        //        }
                                        //    }

                                        //    huo_sw1.WriteLine("CHESSBOARD (after restoring it to check next move)");
                                        //    huo_sw1.WriteLine("-----------------------------------------");
                                        //    for (int yj = 7; yj >= 0; yj--)
                                        //    {
                                        //        huo_sw1.WriteLine(String.Concat("| ", NodesAnalysis2_Chessboard_2[0, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[1, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[2, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[3, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[4, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[5, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[6, yj, NodeLevel_2_count], " | ", NodesAnalysis2_Chessboard_2[7, yj, NodeLevel_2_count], " |"));
                                        //        huo_sw1.WriteLine("-----------------------------------------");
                                        //    }
                                        //    huo_sw1.WriteLine("");
                                        //}
                                        #endregion WriteLog
                                    }

                                }
                            }

                        }


                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "Human";
            }

            public static void Analyze_Move_4_ComputerMove(string[,] Skakiera_Thinking_HY_4)
            {
                // v0.990 change: The best score for every move will be stored at each level. Only if the new move analyzed
                // has a better score than the best score, will it be analyzed (target: trim the analysis tree)
                int bestScoreLevel4 = 0;

                // Δήλωση μεταβλητών που χρησιμοποιούνται στο βρόγχο "for" (δεν μπορεί να χρησιμοποιηθούν οι μεταβλητές i και j διότι αυτές οι
                // μεταβλητές είναι καθολικές και δημιουργείται πρόβλημα κατά την επιστροφή στην ComputerMove από την CheckMove)
                // v0.990: Initialized the values
                int iii42 = 0;
                int jjj42 = 0;
                String MovingPiece4 = "";
                String ProsorinoKommati4 = "";
                int m_StartingColumnNumber4 = 0;
                int m_FinishingColumnNumber4 = 0;
                int m_StartingRank4 = 0;
                int m_FinishingRank4 = 0;

                // v0.990
                String[,] Skakiera_Move_After_4 = new String[8, 8];

                //huo_sw1.WriteLine(String.Concat("[Point 0] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));

                // Σκανάρισμα της σκακιέρας: Όταν εντοπίζεται κάποιο κομμάτι του υπολογιστή,
                // θα υπολογίζονται ΟΛΕΣ οι πιθανές κινήσεις του προς κάθε κατεύθυνση, ακόμα
                // και αυτές που δεν μπορεί να κάνει το κομμάτι. Στη συνέχεια, με τη βοήθεια
                // των συναρτήσεων ElegxosNomimotitas και ElegxosOrthotitas θα ελέγχεται το
                // αν η κίνηση είναι ορθή και νόμιμη. Αν είναι, η εν λόγω κίνηση θα γίνεται
                // προσωρινά στη σκακιέρα και θα καταγράφεται το σκορ της νέας θέσης που προέκυψε.

                // ΣΗΜΕΙΩΣΗ: Σε όλες τις στήλες και τις οριζόντιους προστίθεται η μονάδα (+1)
                // διότι πρέπει να μετατραπούν από το "σύστημα" μέτρησης "0-7" (που χρησιμο-
                // ποιείται στο παρακάτω "for i…next" αλλά και στο συμβολισμό του πίνακα
                // Skakiera) στο σύστημα μέτρησης "1-8" το οποίο χρησιμοποιείται στις
                // μεταβλητές Starting/Finishing_Column/Rank σε όλο το υπόλοιπο πρόγραμμα.

                for (iii42 = 0; iii42 <= 7; iii42++)
                {
                    for (jjj42 = 0; jjj42 <= 7; jjj42++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("White King") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("White Queen") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("White Rook") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("White Knight") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("Black King") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking_HY_4[(iii42), (jjj42)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            //huo_sw1.WriteLine(String.Concat("[Debug Point 1] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));

                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    //huo_sw1.WriteLine(String.Concat("[Debug Point 2] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));

                                    //v0.990: Replaced m_StartingColumnNumber with m_StartingColumnNumber4
                                    MovingPiece4 = Skakiera_Thinking_HY_4[(iii42), (jjj42)];
                                    m_StartingColumnNumber4 = iii42 + 1;
                                    m_FinishingColumnNumber4 = w + 1;
                                    m_StartingRank4 = jjj42 + 1;
                                    m_FinishingRank4 = r + 1;

                                    #region ObsoleteCode
                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    // v0.990: Removed this m_FinishingRank -> m_FinishingRank4 useless piece
                                    // MovingPiece4 = MovingPiece;
                                    // m_StartingColumnNumber4 = m_StartingColumnNumber4;
                                    // m_FinishingColumnNumber4 = m_FinishingColumnNumber;
                                    // m_StartingRank4 = m_StartingRank;
                                    // m_FinishingRank4 = m_FinishingRank;
                                    //huo_sw1.WriteLine(String.Concat("[Point 3] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));
                                    //huo_sw1.WriteLine(String.Concat("[Point 3] -> Move analyzed: ", MovingPiece4, " ", m_StartingColumnNumber4.ToString(), m_StartingRank4.ToString(), " -> ", m_FinishingColumnNumber4.ToString(), m_FinishingRank4.ToString()));
                                    //huo_sw1.WriteLine("");
                                    #endregion ObsoleteCode

                                    ProsorinoKommati4 = Skakiera_Thinking_HY_4[(m_FinishingColumnNumber4 - 1), (m_FinishingRank4 - 1)];

                                    // Έλεγχος της κίνησης (Check move)

                                    #region ObsoleteCode
                                    // Validity and legality of the move has been checked in CheckMove
                                    // CheckMove(Skakiera_Thinking_HY_4);
                                    //v0.990: MovingPiece -> MovingPiece4
                                    #endregion ObsoleteCode

                                    // Check validity and legality
                                    // Necessary values for variables for the ElegxosOrthotitas (check move corr1ectness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;

                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Thinking_HY_4, 0, m_StartingRank4, m_StartingColumnNumber4, m_FinishingRank4, m_FinishingColumnNumber4, MovingPiece4);
                                    //huo_sw1.WriteLine(String.Concat("[Point 3.1] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));
                                    //v0.990 TEST: Here the King dissapears!!!! [START]
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Thinking_HY_4, 0, m_StartingRank4, m_StartingColumnNumber4, m_FinishingRank4, m_FinishingColumnNumber4, MovingPiece4);
                                    //v0.990 TEST: Here the King dissapears!!!! [END]
                                    //v0.990 QUESTION: How does the ElegxosNomimotitas function affect the Skakiera_Thinking_HY_4?
                                    //v0.990 ANSWER: By calling ElegxosNomimotitas and passing Skakiera_Thinking_HY_4 as reference, any change in the ENSkakiera array of ElegxosNomimotitas function is reflected in the Skakiera_Thinking_HY_4 because the ENSkakiera references the Skakiera_Thinking_HY_4! (I suppose so anyaway, this is the only logical explanation)
                                    
                                    // Restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    #region ObsoleteCode
                                    //huo_sw1.WriteLine(String.Concat("[Point 4] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));
                                    //huo_sw1.WriteLine(String.Concat("Orthotita  = ", m_OrthotitaKinisis.ToString()));
                                    //huo_sw1.WriteLine(String.Concat("Nomimotita = ", m_NomimotitaKinisis.ToString()));
                                    //v0.980: Removed
                                    //number_of_moves_analysed++;
                                    #endregion ObsoleteCode

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        //huo_sw1.WriteLine(string.Concat("Hu move 1: Found a legal move!"));
                                        //huo_sw1.WriteLine(String.Concat("[Point 5] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));

                                        // Do the move
                                        // v0.990: ProsorinoKommati -> ProsorinoKommati4, MovingPiece -> MovingPiece4
                                        ProsorinoKommati4 = Skakiera_Thinking_HY_4[(m_FinishingColumnNumber4 - 1), (m_FinishingRank4 - 1)];
                                        Skakiera_Thinking_HY_4[(m_StartingColumnNumber4 - 1), (m_StartingRank4 - 1)] = "";
                                        Skakiera_Thinking_HY_4[(m_FinishingColumnNumber4 - 1), (m_FinishingRank4 - 1)] = MovingPiece4;

                                        #region ObsoleteCode
                                        //huo_sw1.WriteLine(String.Concat("[Point 6] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));
                                        // Check the score after the computer move.
                                        //v0.980: This is Move Analyzed 2, so no need for the other ifs!
                                        //if (Move_Analyzed == 0)
                                        //{
                                        //    NodeLevel_0_count++;
                                        //    Temp_Score_Move_0 = CountScore(Skakiera_Thinking_HY_4, humanDangerParameter);
                                        //}
                                        //v0.990: Removed the "if (Move_Analyzed == 2)"
                                        //if (Move_Analyzed == 2)
                                        //{
                                        #endregion ObsoleteCode

                                        NodeLevel_4_count++;
                                        //v0.980: Removed humanDangerParameter from every call of CountScore
                                        Temp_Score_Move_4 = CountScore(Skakiera_Thinking_HY_4);

                                        #region ObsoleteCode
                                        //v0.980: This is the end of the analysis, so no need to call anymore the Analyze_Move functions!
                                        //if (Move_Analyzed < Thinking_Depth)
                                        //{
                                        //    Move_Analyzed = Move_Analyzed + 1;

                                        //    for (i = 0; i <= 7; i++)
                                        //    {
                                        //        for (j = 0; j <= 7; j++)
                                        //        {
                                        //            Skakiera_Move_After[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                        //        }
                                        //    }

                                        //    Who_Is_Analyzed = "Hu";
                                        //    First_Call_Human_Thought = true;

                                        //    // Check Hu move
                                        //    if (Move_Analyzed == 1)
                                        //        Analyze_Move_1_HumanMove(Skakiera_Move_After);
                                        //}
                                        #endregion ObsoleteCode

                                        // v0.990 change: Added back the part which calls deeper levels of analysis
                                        // if (Move_Analyzed < Thinking_Depth)
                                        // v0.990 Move 4 changes
                                        if ((  (Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("White") == 0) && (Temp_Score_Move_4 <= bestScoreLevel4))
                                           || ((Move_Analyzed < Thinking_Depth) && (m_PlayerColor.CompareTo("Black") == 0) && (Temp_Score_Move_4 >= bestScoreLevel4)))
                                        {
                                            Move_Analyzed = Move_Analyzed + 1;

                                            // v0.990 change
                                            // Store the best score at this level
                                            bestScoreLevel4 = Temp_Score_Move_4;

                                            #region toRemove
                                            //v0.990: Skakiera_Move_After -> Skakiera_Move_After_4
                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After_4[(i), (j)] = Skakiera_Thinking_HY_4[(i), (j)];
                                                }
                                            }
                                            #endregion toRemove

                                            Who_Is_Analyzed = "Human";

                                            // Check human move
                                            if (Move_Analyzed == 1)
                                                Analyze_Move_1_HumanMove(Skakiera_Move_After_4);
                                            else if (Move_Analyzed == 3)
                                                Analyze_Move_3_HumanMove(Skakiera_Move_After_4);
                                        }


                                        if (Move_Analyzed == Thinking_Depth)
                                        {
                                            // [MiniMax algorithm - skakos]
                                            // Record the node in the Nodes Analysis array (to use with MiniMax algorithm) skakos

                                            //v0.970
                                            NodesAnalysis0[NodeLevel_0_count, 0] = Temp_Score_Move_0;
                                            NodesAnalysis1[NodeLevel_1_count, 0] = Temp_Score_Move_1_human;
                                            NodesAnalysis2[NodeLevel_2_count, 0] = Temp_Score_Move_2;
                                            NodesAnalysis3[NodeLevel_3_count, 0] = Temp_Score_Move_3_human;
                                            NodesAnalysis4[NodeLevel_4_count, 0] = Temp_Score_Move_4;

                                            // Store the parents (number of the node of the upper level)
                                            NodesAnalysis0[NodeLevel_0_count, 1] = 0;
                                            NodesAnalysis1[NodeLevel_1_count, 1] = NodeLevel_0_count;
                                            NodesAnalysis2[NodeLevel_2_count, 1] = NodeLevel_1_count;
                                            NodesAnalysis3[NodeLevel_3_count, 1] = NodeLevel_2_count;
                                            NodesAnalysis4[NodeLevel_4_count, 1] = NodeLevel_3_count;

                                            #region toRemove
                                            //v0.980: Removed
                                            //if (Danger_penalty == true)
                                            //{
                                            //    //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] - 2000000000;
                                            //    //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] + 2000000000;
                                            //}

                                            //if (go_for_it == true)
                                            //{
                                            //    //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] + 2000000000;
                                            //    //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] - 2000000000;
                                            //}
                                            #endregion toRemove

                                            Nodes_Total_count++;

                                            #region toRemove
                                            //v0.980: Removed
                                            // Safety valve in case we reach the end of the table capacity
                                            // This is a limit for the memory. Will have to do something about it!
                                            // v0.991 fix
                                            if (Nodes_Total_count > 1000000)
                                            {
                                                //Console.WriteLine("Limit of memory in NodesAnalysis array reached!");
                                                //MessageBox.Show("Limit of memory in NodesAnalysis array reached!");
                                                Nodes_Total_count = 1000000;
                                            }
                                            #endregion toRemove
                                        }

                                        #region toRemove
                                        //huo_sw1.WriteLine(String.Concat("[Point 7] -> Σκακιέρα[5,1] = ", Skakiera_Thinking_HY_4[4, 0].ToString()));

                                        //if (MovingPiece4.CompareTo("White King") == 0)
                                        //{
                                        //    huo_sw1.WriteLine("");
                                        //    huo_sw1.WriteLine("King moving...");
                                        //    huo_sw1.WriteLine(String.Concat("MovingPiece4 = ", MovingPiece4));
                                        //    huo_sw1.WriteLine(String.Concat("ProsorinoKommati4 = ", ProsorinoKommati4));
                                        //    huo_sw1.WriteLine("");
                                        //}
                                        //if ((MovingPiece4.CompareTo("White Pawn") == 0) && (m_StartingColumnNumber4 == 5) && (m_StartingRank4 == 2))
                                        //{
                                        //    huo_sw1.WriteLine("");
                                        //    huo_sw1.WriteLine("White Pawn e2 moving...");
                                        //    huo_sw1.WriteLine(String.Concat("Target column : ", m_FinishingColumnNumber4));
                                        //    huo_sw1.WriteLine(String.Concat("Target rank   : ", m_FinishingRank4));
                                        //    huo_sw1.WriteLine(String.Concat("MovingPiece4 = ", MovingPiece4));
                                        //    huo_sw1.WriteLine(String.Concat("ProsorinoKommati4 = ", ProsorinoKommati4));
                                        //    huo_sw1.WriteLine("");
                                        //}
                                        #endregion toRemove

                                        // Undo the move
                                        Skakiera_Thinking_HY_4[(m_StartingColumnNumber4 - 1), (m_StartingRank4 - 1)] = MovingPiece4;
                                        Skakiera_Thinking_HY_4[(m_FinishingColumnNumber4 - 1), (m_FinishingRank4 - 1)] = ProsorinoKommati4;

                                        #region WriteLog
                                        //if ((MovingPiece4.CompareTo("White King") == 0) ||
                                        //     ((MovingPiece4.CompareTo("White Pawn") == 0) && (m_StartingColumnNumber4 == 5) && (m_StartingRank4 == 2)))
                                        //{
                                        //    huo_sw1.WriteLine("");
                                        //    huo_sw1.WriteLine("Restored chessboard...");
                                        //    for (i = 0; i <= 7; i++)
                                        //    {
                                        //        for (j = 0; j <= 7; j++)
                                        //        {
                                        //            switch (Skakiera_Thinking_HY_4[(i), (j)])
                                        //            {
                                        //                case "White Rook":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "WR";
                                        //                    break;

                                        //                case "White Knight":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "WN";
                                        //                    break;

                                        //                case "White Bishop":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "WB";
                                        //                    break;

                                        //                case "White Queen":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "WQ";
                                        //                    break;

                                        //                case "White King":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "WK";
                                        //                    break;

                                        //                case "White Pawn":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "WP";
                                        //                    break;

                                        //                case "Black Rook":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "BR";
                                        //                    break;

                                        //                case "Black Knight":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "BN";
                                        //                    break;

                                        //                case "Black Bishop":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "BB";
                                        //                    break;

                                        //                case "Black Queen":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "BQ";
                                        //                    break;

                                        //                case "Black King":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "BK";
                                        //                    break;

                                        //                case "Black Pawn":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "BP";
                                        //                    break;

                                        //                case "":
                                        //                    NodesAnalysis4_Chessboard_4[i, j, NodeLevel_4_count] = "  ";
                                        //                    break;
                                        //            }
                                        //        }
                                        //    }

                                        //    huo_sw1.WriteLine("CHESSBOARD (after restoring it to check next move)");
                                        //    huo_sw1.WriteLine("-----------------------------------------");
                                        //    for (int yj = 7; yj >= 0; yj--)
                                        //    {
                                        //        huo_sw1.WriteLine(String.Concat("| ", NodesAnalysis4_Chessboard_4[0, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[1, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[2, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[3, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[4, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[5, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[6, yj, NodeLevel_4_count], " | ", NodesAnalysis4_Chessboard_4[7, yj, NodeLevel_4_count], " |"));
                                        //        huo_sw1.WriteLine("-----------------------------------------");
                                        //    }
                                        //    huo_sw1.WriteLine("");
                                        //}
                                        #endregion WriteLog
                                    }

                                }
                            }

                        }


                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "Human";
            }

            public static void FindAttackers(string[,] SkakieraAttackers)
            {
                //v0.990: Initialized the values
                String MovingPiece_Attack = "";
                int m_StartingRank_Attack = 0;
                int m_StartingColumnNumber_Attack = 0;
                int m_FinishingRank_Attack = 0;
                int m_FinishingColumnNumber_Attack = 0;

                // Scan the chessboard . if a piece of HY is found . check all
                // possible destinations in the chessboard . check correctness of
                // the move analyzed . check legality of the move analyzed . if
                // correct and legal, then do the move.
                // NOTE: In all column and rank numbers I add +1, because I must transform
                // them from the 0...7 'measure system' of the chessboard (='Skakiera' in Greek) table
                // to the 1...8 'measure system' of the chessboard.

                for (int iii2 = 0; iii2 <= 7; iii2++)
                {
                    for (int jjj2 = 0; jjj2 <= 7; jjj2++)
                    {
                        if ((((SkakieraAttackers[(iii2), (jjj2)].CompareTo("White King") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("White Queen") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("White Rook") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("White Knight") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("White Bishop") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)) || (((SkakieraAttackers[(iii2), (jjj2)].CompareTo("Black King") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("Black Queen") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("Black Rook") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("Black Knight") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("Black Bishop") == 0) || (SkakieraAttackers[(iii2), (jjj2)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)))
                        {

                            MovingPiece_Attack = SkakieraAttackers[(iii2), (jjj2)];
                            m_StartingColumnNumber_Attack = iii2 + 1;
                            m_StartingRank_Attack = jjj2 + 1;

                            // find squares where the Hu opponent can hit
                            for (int w2 = 0; w2 <= 7; w2++)
                            {
                                for (int r2 = 0; r2 <= 7; r2++)
                                {
                                    m_FinishingColumnNumber_Attack = w2 + 1;
                                    m_FinishingRank_Attack = r2 + 1;

                                    // check the move
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    if (m_OrthotitaKinisis == true)
                                    {
                                        m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    }
                                    // restore normal value of m_whoplays
                                    m_WhoPlays = "HY";
                                    // 2012: If a pawn is moving, then take into account only moves of eating other pieces!
                                    // and not moves of moving forward
                                    if ((MovingPiece_Attack.CompareTo("White Pawn") == 0) || (MovingPiece_Attack.CompareTo("Black Pawn") == 0))
                                    {
                                        if (m_FinishingColumnNumber_Attack == m_StartingColumnNumber_Attack)
                                        {
                                            m_OrthotitaKinisis = false;
                                        }
                                    }

                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // Another attacker on that square found!
                                        Number_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Number_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;
                                        // v0.96
                                        //Skakiera_Dangerous_Squares[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = "Danger";

                                        //2012 new
                                        //v0.980: Removed Attackers_coordinates_column/rank since they are not used!
                                        //Attackers_coordinates_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = m_StartingColumnNumber_Attack - 1;
                                        //Attackers_coordinates_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = m_StartingRank_Attack - 1;

                                        // Calculate the value (total value) of the attackers
                                        //MessageBox.Show(string.Concat("Added something to the value of attackers: ", MovingPiece_Attack.ToString()));

                                        if ((MovingPiece_Attack.CompareTo("White Rook") == 0) || (MovingPiece_Attack.CompareTo("Black Rook") == 0))
                                            Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 5;
                                        else if ((MovingPiece_Attack.CompareTo("White Bishop") == 0) || (MovingPiece_Attack.CompareTo("Black Bishop") == 0))
                                            Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("White Knight") == 0) || (MovingPiece_Attack.CompareTo("Black Knight") == 0))
                                            Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("White Queen") == 0) || (MovingPiece_Attack.CompareTo("Black Queen") == 0))
                                            Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 9;
                                        else if ((MovingPiece_Attack.CompareTo("White Pawn") == 0) || (MovingPiece_Attack.CompareTo("Black Pawn") == 0))
                                            Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;
                                        //v0.95
                                        //else if ((MovingPiece_Attack.CompareTo("White King") == 0) || (MovingPiece_Attack.CompareTo("Black King") == 0))
                                        //    Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attackers[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 15;
                                    }
                                }
                            }
                        }
                    }
                }


            }

            // v0.990 changes
            public static void FindDefenders(string[,] SkakieraDefenders)
            {
                //v0.990: Initialized the values
                String MovingPiece_Attack = "";
                int m_StartingRank_Attack = 0;
                int m_StartingColumnNumber_Attack = 0;
                int m_FinishingRank_Attack = 0;
                int m_FinishingColumnNumber_Attack = 0;

                // Find squares that are also 'protected' by a piece of the HY.
                // If protected, then the square is not really dangerous

                // Changed in version 0.5
                // Initialize all variables used to find exceptions in the non-dangerous squares.
                // Exceptions definition: If Hu can hit a square and the computer defends it with its pieces, then the
                // square is not dangerous. However, if the computer has only one (1) piece to defend that square, then
                // it cannot move that specific piece to that square (because then the square would have no defenders and
                // would become again a dangerous square!).

                for (int iii3 = 0; iii3 <= 7; iii3++)
                {
                    for (int jjj3 = 0; jjj3 <= 7; jjj3++)
                    {
                        if ((((SkakieraDefenders[(iii3), (jjj3)].CompareTo("White King") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("White Queen") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("White Rook") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("White Knight") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("White Bishop") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((SkakieraDefenders[(iii3), (jjj3)].CompareTo("Black King") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("Black Queen") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("Black Rook") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("Black Knight") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("Black Bishop") == 0) || (SkakieraDefenders[(iii3), (jjj3)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))
                        {
                            MovingPiece_Attack = SkakieraDefenders[(iii3), (jjj3)];
                            m_StartingColumnNumber_Attack = iii3 + 1;
                            m_StartingRank_Attack = jjj3 + 1;

                            for (int w1 = 0; w1 <= 7; w1++)
                            {
                                for (int r1 = 0; r1 <= 7; r1++)
                                {

                                    m_FinishingColumnNumber_Attack = w1 + 1;
                                    m_FinishingRank_Attack = r1 + 1;

                                    // Έλεγχος της κίνησης
                                    // Απόδοση τιμών στις μεταβλητές m_WhoPlays και m_WrongColumn, οι οποίες είναι απαραίτητες για να λειτουργήσει σωστά οι συναρτήσεις ElegxosNomimotitas και ElegxosOrthotitas
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    m_OrthotitaKinisis = ElegxosOrthotitas(SkakieraDefenders, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    if (m_OrthotitaKinisis == true)
                                    {
                                        m_NomimotitaKinisis = ElegxosNomimotitas(SkakieraDefenders, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    }
                                    // Επαναφορά της κανονικής τιμής της m_WhoPlays
                                    m_WhoPlays = "HY";

                                    // NEW
                                    // You can count for all moves that "defend" a square,
                                    // except the move of a pawn forward! :)
                                    if ((MovingPiece_Attack.CompareTo("White Pawn") == 0) || (MovingPiece_Attack.CompareTo("Black Pawn") == 0))
                                    {
                                        if (m_FinishingColumnNumber_Attack == m_StartingColumnNumber_Attack)
                                        {
                                            m_OrthotitaKinisis = false;
                                        }
                                    }

                                    m_WhoPlays = "HY";
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // A new defender for that square is found!
                                        Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;

                                        // Calculate the value (total value) of the defenders
                                        //MessageBox.Show(string.Concat("Added something to the value of defenders for (", (m_FinishingColumnNumber_Attack).ToString(), ",", (m_FinishingRank_Attack).ToString(), "): ", MovingPiece_Attack.ToString()));

                                        if ((MovingPiece_Attack.CompareTo("White Rook") == 0) || (MovingPiece_Attack.CompareTo("Black Rook") == 0))
                                            Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 5;
                                        else if ((MovingPiece_Attack.CompareTo("White Bishop") == 0) || (MovingPiece_Attack.CompareTo("Black Bishop") == 0))
                                            Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("White Knight") == 0) || (MovingPiece_Attack.CompareTo("Black Knight") == 0))
                                            Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("White Queen") == 0) || (MovingPiece_Attack.CompareTo("Black Queen") == 0))
                                            Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 9;
                                        else if ((MovingPiece_Attack.CompareTo("White Pawn") == 0) || (MovingPiece_Attack.CompareTo("Black Pawn") == 0))
                                            Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;
                                        else if ((MovingPiece_Attack.CompareTo("White King") == 0) || (MovingPiece_Attack.CompareTo("Black King") == 0))
                                            Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 15;

                                        //v0.980: Removed Exception_defender_column/ rank since they are not used!
                                        // Exception for Defenders!
                                        // If the defender found is the only one, then that defender cannot move to that square,
                                        // since then the square would be again dangerous (since its only defender would have moved into it!)
                                        // If more than one defenders is found, then no exceptions exist.
                                        //if (Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] == 1)
                                        //{
                                        //    Exception_defender_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = (m_StartingColumnNumber_Attack - 1);
                                        //    Exception_defender_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = (m_StartingRank_Attack - 1);

                                        //    // DEBUGGING
                                        //    //if (((m_FinishingColumnNumber_Attack - 1) == 2) && ((m_FinishingRank_Attack - 1) == 4))
                                        //    //{
                                        //    //    MessageBox.Show("hOU");
                                        //    //    MessageBox.Show(String.Concat("Move found: ", m_StartingColumnNumber_Attack.ToString(), m_StartingRank_Attack.ToString(), "->", m_FinishingColumnNumber_Attack.ToString(), m_FinishingRank_Attack.ToString()));
                                        //    //    MessageBox.Show(String.Concat("Exception column: ",Exception_defender_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)]));
                                        //    //    MessageBox.Show(String.Concat("Exception rank: ",Exception_defender_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)]));
                                        //    //    MessageBox.Show(String.Concat("Exception column: ",(iii3).ToString()));
                                        //    //    MessageBox.Show(String.Concat("Exception rank: ",(jjj3).ToString() ));
                                        //    //}
                                        //    // PLAYING
                                        //}
                                        //else if (Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] > 1)
                                        //{
                                        //    Exception_defender_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = -99;
                                        //    Exception_defender_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = -99;
                                        //}

                                    }
                                }
                            }
                        }
                    }
                }
            }

        };



        private void button_Play_Click(object sender, EventArgs e)
        {
            try
            {
                // v0.991: Delete logs
                System.IO.File.Delete("HUO_CHESS_LOG_Minimax_Thought_Process.txt");
                System.IO.File.Delete("HUO_CHESS_LOG_Minmax_Before.txt");
                System.IO.File.Delete("HUO_CHESS_LOG_Minmax_After.txt");
                System.IO.File.Delete("HUO_CHESS_LOG_Attackers_Defenders.txt");
                //System.IO.File.Delete("Defenders.txt");
                //System.IO.File.Delete("Dangerous.txt");
            }

            catch
            {

            }

            try
            {
                Form1.HuoChess_main.Starting_position();
                RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            }

            catch
            {

            }

            try
            {
                if (Form1.HuoChess_main.m_WhoPlays.CompareTo("HY") == 0)
                {
                    label2.Text = "Thinking...";
                    label3.Text = "";
                    // v0.991
                    label_variant_thought.Text = "-";
                }
            }

            catch { }

            try
            {
                Form1.HuoChess_main.Main_Console();
            }

            catch {

            }

            try {
                RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            }

            catch {

            }

            // v0.991
            //label2.Text = "I played! Now it is your turn!";
            //Application.DoEvents();
            label2.Text = string.Concat("Huo Chess move: ", HuoChess_main.NextLine);
            label3.Text = string.Concat("Final positions analyzed: ", HuoChess_main.FinalPositions);
            label_variant_thought.Text = HuoChess_main.Best_Variant_text;
            Application.DoEvents();
        }

        private void radioButton_White_Click(object sender, EventArgs e)
        {
            Form1.HuoChess_main.m_PlayerColor = "White";
            Form1.HuoChess_main.m_WhoPlays = "Human";
        }

        private void radioButton_Black_Click(object sender, EventArgs e)
        {
            try {
                Form1.HuoChess_main.m_PlayerColor = "Black";
                Form1.HuoChess_main.m_WhoPlays = "HY";
            }

            catch
            {

            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // For test purposes
            //HuoChess_main.m_StartingColumn = "D";
            //HuoChess_main.m_StartingRank = 2;
            //HuoChess_main.m_FinishingColumn = "D";
            //HuoChess_main.m_FinishingRank = 4;
            //playerClicks++;
            //HuoChess_main.Enter_move();
            //call_AI();
        }

        private void ManageGameSequence()
        {
            // If this is the first click, then it is the starting square
            if (playerClicks == 0)
            {
                HuoChess_main.m_StartingColumn = columnClicked;
                HuoChess_main.m_StartingRank = rankClicked;
                playerClicks++;
            }
            // If this is the second click, then it is the finishing square
            else if (playerClicks == 1)
            {
                HuoChess_main.m_FinishingColumn = columnClicked;
                HuoChess_main.m_FinishingRank = rankClicked;
                playerClicks++;
                HuoChess_main.Enter_move();
                //v0.981
                if ((HuoChess_main.m_OrthotitaKinisis == true) && (HuoChess_main.m_NomimotitaKinisis == true))
                    call_AI();
                else
                    playerClicks = 0;
            }
        }

        private void call_AI()
        {
            playerClicks = 0;
            RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            label2.Text = "Thinking...";
            label3.Text = "";
            Application.DoEvents();

            //v0.990
            // call HY Thought function
            HuoChess_main.Move = 0;
            HuoChess_main.Move_Analyzed = 0;
            HuoChess_main.Stop_Analyzing = false;
            HuoChess_main.First_Call = true;
            HuoChess_main.Best_Move_Found = false;
            HuoChess_main.Who_Is_Analyzed = "HY";
            HuoChess_main.Nodes_Total_count = 0;
            HuoChess_main.NodeLevel_0_count = 0;
            HuoChess_main.NodeLevel_1_count = 0;
            HuoChess_main.NodeLevel_2_count = 0;
            HuoChess_main.NodeLevel_3_count = 0;
            HuoChess_main.NodeLevel_4_count = 0;
            HuoChess_main.NodeLevel_5_count = 0;
            HuoChess_main.NodeLevel_6_count = 0;

            HuoChess_main.ComputerMove(Form1.HuoChess_main.Skakiera);
            RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            label2.Text = string.Concat("Huo Chess move: ", HuoChess_main.NextLine);
            label3.Text = string.Concat("Final positions analyzed: ", HuoChess_main.FinalPositions);
            label_variant_thought.Text = HuoChess_main.Best_Variant_text;
        }



        private void pictureBoxD2_Click(object sender, EventArgs e)
        {
            rankClicked = 2;
            columnClicked = "D";
            ManageGameSequence();
        }

        private void pictureBoxD4_Click(object sender, EventArgs e)
        {
            rankClicked = 4;
            columnClicked = "D";
            ManageGameSequence();

            //string path = Directory.GetCurrentDirectory();
            //MessageBox.Show("before changing 21 from INSIDE");
            //string whole_path = string.Concat(path, "\\Resources\\WKing.gif");
            //pictureBox21.Load(whole_path);
            //pictureBox21.Show();
            //MessageBox.Show("is it drawn?");
            //Application.DoEvents();
            //pictureBox21.Show();
            //Invalidate();
        }

        private void pictureBoxA1_Click(object sender, EventArgs e)
        {
            rankClicked = 1;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA2_Click(object sender, EventArgs e)
        {
            rankClicked = 2;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA3_Click(object sender, EventArgs e)
        {
            rankClicked = 3;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA4_Click(object sender, EventArgs e)
        {
            rankClicked = 4;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA5_Click(object sender, EventArgs e)
        {
            rankClicked = 5;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA6_Click(object sender, EventArgs e)
        {
            rankClicked = 6;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA7_Click(object sender, EventArgs e)
        {
            rankClicked = 7;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxA8_Click(object sender, EventArgs e)
        {
            rankClicked = 8;
            columnClicked = "A";
            ManageGameSequence();
        }

        private void pictureBoxB1_Click(object sender, EventArgs e)
        {
            rankClicked = 1;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB2_Click(object sender, EventArgs e)
        {
            rankClicked = 2;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB3_Click(object sender, EventArgs e)
        {
            rankClicked = 3;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB4_Click(object sender, EventArgs e)
        {
            rankClicked = 4;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB5_Click(object sender, EventArgs e)
        {
            rankClicked = 5;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB6_Click(object sender, EventArgs e)
        {
            rankClicked = 6;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB7_Click(object sender, EventArgs e)
        {
            rankClicked = 7;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxB8_Click(object sender, EventArgs e)
        {
            rankClicked = 8;
            columnClicked = "B";
            ManageGameSequence();
        }

        private void pictureBoxC1_Click(object sender, EventArgs e)
        {
            rankClicked = 1;
            columnClicked = "C";
            ManageGameSequence();
        }

        private void pictureBoxC2_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 2;
            ManageGameSequence();
        }

        private void pictureBoxC3_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 3;
            ManageGameSequence();
        }

        private void pictureBoxC4_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 4;
            ManageGameSequence();
        }

        private void pictureBoxC5_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 5;
            ManageGameSequence();
        }

        private void pictureBoxC6_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 6;
            ManageGameSequence();
        }

        private void pictureBoxC7_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 7;
            ManageGameSequence();
        }

        private void pictureBoxC8_Click(object sender, EventArgs e)
        {
            columnClicked = "C";
            rankClicked = 8;
            ManageGameSequence();
        }

        private void pictureBoxD1_Click(object sender, EventArgs e)
        {
            columnClicked = "D";
            rankClicked = 1;
            ManageGameSequence();
        }

        private void pictureBoxD3_Click(object sender, EventArgs e)
        {
            columnClicked = "D";
            rankClicked = 3;
            ManageGameSequence();
        }

        private void pictureBoxD5_Click(object sender, EventArgs e)
        {
            columnClicked = "D";
            rankClicked = 5;
            ManageGameSequence();
        }

        private void pictureBoxD6_Click(object sender, EventArgs e)
        {
            columnClicked = "D";
            rankClicked = 6;
            ManageGameSequence();
        }

        private void pictureBoxD7_Click(object sender, EventArgs e)
        {
            columnClicked = "D";
            rankClicked = 7;
            ManageGameSequence();
        }

        private void pictureBoxD8_Click(object sender, EventArgs e)
        {
            columnClicked = "D";
            rankClicked = 8;
            ManageGameSequence();
        }

        private void pictureBoxE1_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 1;
            ManageGameSequence();
        }

        private void pictureBoxE2_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 2;
            ManageGameSequence();
        }

        private void pictureBoxE3_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 3;
            ManageGameSequence();
        }

        private void pictureBoxE4_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 4;
            ManageGameSequence();
        }

        private void pictureBoxE5_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 5;
            ManageGameSequence();
        }

        private void pictureBoxE6_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 6;
            ManageGameSequence();
        }

        private void pictureBoxE7_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 7;
            ManageGameSequence();
        }

        private void pictureBoxE8_Click(object sender, EventArgs e)
        {
            columnClicked = "E";
            rankClicked = 8;
            ManageGameSequence();
        }

        private void pictureBoxF1_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 1;
            ManageGameSequence();
        }

        private void pictureBoxF2_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 2;
            ManageGameSequence();
        }

        private void pictureBoxF3_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 3;
            ManageGameSequence();
        }

        private void pictureBoxF4_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 4;
            ManageGameSequence();
        }

        private void pictureBoxF5_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 5;
            ManageGameSequence();
        }

        private void pictureBoxF6_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 6;
            ManageGameSequence();
        }

        private void pictureBoxF7_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 7;
            ManageGameSequence();
        }

        private void pictureBoxF8_Click(object sender, EventArgs e)
        {
            columnClicked = "F";
            rankClicked = 8;
            ManageGameSequence();
        }

        private void pictureBoxG1_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 1;
            ManageGameSequence();
        }

        private void pictureBoxG2_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 2;
            ManageGameSequence();
        }

        private void pictureBoxG3_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 3;
            ManageGameSequence();
        }

        private void pictureBoxG4_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 4;
            ManageGameSequence();
        }

        private void pictureBoxG5_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 5;
            ManageGameSequence();
        }

        private void pictureBoxG6_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 6;
            ManageGameSequence();
        }

        private void pictureBoxG7_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 7;
            ManageGameSequence();
        }

        private void pictureBoxG8_Click(object sender, EventArgs e)
        {
            columnClicked = "G";
            rankClicked = 8;
            ManageGameSequence();
        }

        private void pictureBoxH1_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 1;
            ManageGameSequence();
        }

        private void pictureBoxH2_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 2;
            ManageGameSequence();
        }

        private void pictureBoxH3_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 3;
            ManageGameSequence();
        }

        private void pictureBoxH4_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 4;
            ManageGameSequence();
        }

        private void pictureBoxH5_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 5;
            ManageGameSequence();
        }

        private void pictureBoxH6_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 6;
            ManageGameSequence();
        }

        private void pictureBoxH7_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 7;
            ManageGameSequence();
        }

        private void pictureBoxH8_Click(object sender, EventArgs e)
        {
            columnClicked = "H";
            rankClicked = 8;
            ManageGameSequence();
        }
    }
}
