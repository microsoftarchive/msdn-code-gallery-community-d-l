using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
// No need for threading (maybe in future versions)
//using System.Threading.Tasks;
using System.Windows.Forms;
// Added presentationCore.dll reference
using System.Windows.Input;
using System.IO;

// Additional changes in HuoChess Windows 8:
// - Remove ComputerMove(Skakiera); from Enter_Move() function!

namespace HuoChessW8
{
    public partial class Form1 : Form
    {
        // Parameter which determined the weight of danger in the counting of the score of positions

        //v0.95
        //public static int humanDangerParameter = 0;
        //public static int computerDangerParameter = 1;

        public static int playerClicks;
        public static int playerClick_X;
        public static int playerClick_Y;
        public static int i_MouseIsIn;
        public static int j_MouseIsIn;
        public static int rankClicked;
        public static String columnClicked;
        //public static String[,] RSkakiera = new String[8, 8];
        // the chessboard (=skakiera in Greek)
        //public static String[,] Skakiera = new String[8, 8];  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα

        public Form1()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skakiera_Click(object sender, EventArgs e)
        {
            MessageBox.Show("skakiera clicked");
        }


        //2012: redraw the pictureboxes
        private void RedrawTheSkakiera(string[,] RSkakiera)
        {
            //Form1 huoForm = new Form1();
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


            //MessageBox.Show("before changing 21");
            //string whole_path = string.Concat(path, "\\Resources\\WKing.gif");
            //pictureBoxD4.Load(whole_path);
            //pictureBoxD4.Show();
            //MessageBox.Show("is it drawn?");
            //pictureBoxD4.Show();
            //Invalidate();
        }

        class HuoChess_main
        {
            // HuoChessConsole.cpp : main project file.

            /////////////////////////////////////////////
            // Huo Chess                               //
            // version: 0.82                           //
            // Changes from version 0.81: Removed the  //
            // ComputerMove functions and used a       //
            // template function to create all new     //
            // ComputerMove functions I need.          //
            // Changes from version 0.722: Changed the //
            // ComputerMove, HumanMove, CountScore,    //
            // ElegxosOrthotitas functions.            //
            // Changes from verion 0.721: removed some //
            // useless code and added the variable     //
            // thinking depth (depending on the piece  //
            // the opponent moves) (see parts marked   //
            // with "2009 version 1 change")           //
            // Changes from version 0.6: Added more    //
            // thinking depths                         //
            // Year: 2008                              //
            // Place: Earth - Greece                   //
            // Programmed by Spiros I. Kakos (huo)     //
            // License: TOTALLY FREEWARE!              //
            //          Do anything you want with it!  //
            //          Spread the knowledge!          //
            //          Fix its bugs!                  //
            //          Sell it (if you can...)!       //
            //          Call me for help!              //
            // Site: www.kakos.com.gr                  //
            //       www.kakos.eu                      //
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


            //public:
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // DECLARE VARIABLES
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //public static StreamWriter huo_sw1 = new StreamWriter("Thought_Process.txt", true);

            public static String NextLine;
            public static string FinalPositions;

            public static bool Danger_for_piece;
            public static String[,] Skakiera_Dangerous_Squares = new String[8, 8];
            public static int[,] Number_of_defenders = new int[8, 8];
            public static int[,] Number_of_attackers = new int[8, 8];
            public static int[,] Attackers_coordinates_column = new int[8, 8];
            public static int[,] Attackers_coordinates_rank = new int[8, 8];
            public static int[,] Value_of_defenders = new int[8, 8];
            public static int[,] Value_of_attackers = new int[8, 8];
            public static int[,] Exception_defender_column = new int[8, 8];
            public static int[,] Exception_defender_rank = new int[8, 8];

            // Parameter which determined the weight of danger in the counting of the score of positions
            //v0.95
            public static int humanDangerParameter = 0;
            public static int computerDangerParameter = 1;

            // 2011 START
            //public static bool danger_penalty;
            //public static bool danger_penalty_human;
            public static bool possibility_to_eat_back;

            //public static int Destination_Piece_Value;
            //public static int Moving_Piece_Value;

            //public static double Temp_Score_Human_before_0;
            //v0.96
            public static double Temp_Score_Move_0;
            public static double Temp_Score_Move_1_human;
            public static double Temp_Score_Move_2;
            public static double Temp_Score_Move_3_human;
            public static double Temp_Score_Move_4;
            public static double Temp_Score_Move_5_human;
            public static double Temp_Score_Move_6;
            //public static double Temp_Score_Human_before_8;
            //public static double Temp_Score_Human_after_8;
            //public static double Temp_Score_Human_before_10;
            //public static double Temp_Score_Human_after_10;
            //public static double Temp_Score_Human_before_12;
            //public static double Temp_Score_Human_after_12;
            //public static double Temp_Score_Human_before_14;
            //public static double Temp_Score_Human_after_14;
            //public static double Temp_Score_Human_before_16;
            //public static double Temp_Score_Human_after_16;
            //public static double Temp_Score_Human_before_18;
            //public static double Temp_Score_Human_after_18;
            //public static double Temp_Score_Human_before_20;
            //public static double Temp_Score_Human_after_20;

            //public static bool Human_Stupid_Move_2_penalty;
            //public static bool Human_Stupid_Move_4_penalty;
            //public static bool Human_Stupid_Move_6_penalty;
            //public static bool Human_Stupid_Move_8_penalty;
            //public static bool Human_Stupid_Move_10_penalty;
            //public static bool Human_Stupid_Move_12_penalty;
            //public static bool Human_Stupid_Move_14_penalty;
            //public static bool Human_Stupid_Move_16_penalty;
            //public static bool Human_Stupid_Move_18_penalty;
            //public static bool Human_Stupid_Move_20_penalty;

            // This array will hold the minimax analysis nodes skakos
            // 2012 change: int -> double
            public static double[, ,] NodesAnalysis = new double[1000000, 26, 2];
            public static int Nodes_Total_count;
            //v0.96
            public static int NodeLevel_0_count;
            public static int NodeLevel_1_count;
            public static int NodeLevel_2_count;
            public static int NodeLevel_3_count;
            public static int NodeLevel_4_count;
            public static int NodeLevel_5_count;
            public static int NodeLevel_6_count;
            public static int NodeLevel_7_count;
            public static int NodeLevel_8_count;
            public static int NodeLevel_9_count;
            public static int NodeLevel_10_count;
            public static int NodeLevel_11_count;
            public static int NodeLevel_12_count;
            public static int NodeLevel_13_count;
            public static int NodeLevel_14_count;
            public static int NodeLevel_15_count;
            public static int NodeLevel_16_count;
            public static int NodeLevel_17_count;
            public static int NodeLevel_18_count;
            public static int NodeLevel_19_count;
            public static int NodeLevel_20_count;
            // 2011 END

            ///////////////////
            // 2009 v4 change
            ///////////////////

            // if human eats a piece, then make the square a preferred target!!!
            public static int target_column;
            public static int target_row;
            //public static String target_piece;

            // v0.82
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_2 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_4 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_6 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_8 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_10 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_12 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_14 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_16 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_18 = new HuoChess_main();
            public static HuoChessW8.Form1.HuoChess_main HuoChess_new_depth_20 = new HuoChess_main();
            // v0.82
            ///////////////////
            // 2009 v4 change
            ///////////////////

            // UNCOMMENT TO SHOW THINKING TIME!
            // (this and the other commands that use 'start' variable to record thinking time...)
            // public static int start; 

            // the chessboard (=skakiera in Greek)
            public static String[,] Skakiera = new String[8, 8];  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα

            // CODE FOR COMPARISON
            public static int number_of_moves_analysed;

            // Variable to note if the computer moves its piece to a square threatened by a pawn
            //public static bool knight_pawn_threat;
            //public static bool bishop_pawn_threat;
            //public static bool rook_pawn_threat;
            //public static bool queen_pawn_threat;
            //public static bool checked_for_pawn_threats;

            // Variable which determines of the program will show the inner
            // thinking process of the AI. Good for educational purposes!!!
            // UNCOMMENT TO SHOW INNER THINKING MECHANISM!
            //bool huo_debug;

            // Arrays to use in ComputerMove function
            // Changed in version 0.5
            // Penalty for moving the only piece that defends a square to that square (thus leavind the defender
            // alone in the square he once defended, defenceless!)
            // This penalty is also used to indicate that the computer loses its Queen with the move analyzed
            public static bool Danger_penalty;
            //bool LoseQueen_penalty;
            // Penalty for moving your piece to a square that the human opponent can hit with more power than the computer.
            //public static bool Attackers_penalty;
            // Penalty if the pieces of the human defending a square in which the computer movies in, have much less
            // value than the pieces the computer has to support the attack on that square
            //public static bool Defenders_value_penalty;

            public static String m_PlayerColor;
            public static String m_ComputerLevel = "Kakos";
            public static String m_WhoPlays;
            public static String m_WhichColorPlays;
            public static String MovingPiece;

            // variable to store temporarily the piece that is moving
            public static String ProsorinoKommati;
            public static String ProsorinoKommati_KingCheck;

            // variables to check the legality of the move
            public static bool exit_elegxos_nomimothtas = false;
            public static int h;
            public static int p;
            public static int how_to_move_Rank;
            public static int how_to_move_Column;
            //public static int hhh;

            // NEW
            //public static int kopa = 1;
            public static bool KingCheck = false;

            // coordinates of the starting square of the move
            public static String m_StartingColumn;
            public static int m_StartingRank;
            public static String m_FinishingColumn;
            public static int m_FinishingRank;

            // variable for en passant moves
            public static bool enpassant_occured;

            // move number
            public static int Move;

            // variable to show if promotion of a pawn occured
            public static bool Promotion_Occured = false;

            // variable to show if castrling occured
            public static bool Castling_Occured = false;

            // variables to help find out if it is legal for the computer to perform castling
            public static bool White_King_Moved = false;
            public static bool Black_King_Moved = false;
            public static bool White_Rook_a1_Moved = false;
            public static bool White_Rook_h1_Moved = false;
            public static bool Black_Rook_a8_Moved = false;
            public static bool Black_Rook_h8_Moved = false;
            public static bool Can_Castle_Big_White;
            public static bool Can_Castle_Big_Black;
            public static bool Can_Castle_Small_White;
            public static bool Can_Castle_Small_Black;

            public static bool go_for_it;

            // variables to show where the kings are in the chessboard
            public static int WhiteKingColumn;
            public static int WhiteKingRank;
            public static int BlackKingColumn;
            public static int BlackKingRank;

            // variables to show if king is in check
            public static bool WhiteKingCheck;
            public static bool BlackKingCheck;

            // variables to show if there is a possibility for mate
            //public static bool WhiteMate = false;
            //public static bool BlackMate = false;
            //public static bool Mate;

            // variable to show if a move is found for the hy to do
            public static bool Best_Move_Found;

            // variables to help find if a king is under check.
            // (see CheckForWhiteCheck and CheckForBlackCheck functions)
            public static bool DangerFromRight;
            public static bool DangerFromLeft;
            public static bool DangerFromUp;
            public static bool DangerFromDown;
            public static bool DangerFromUpRight;
            public static bool DangerFromDownRight;
            public static bool DangerFromUpLeft;
            public static bool DangerFromDownLeft;

            // initial coordinates of the two kings
            // (see CheckForWhiteCheck and CheckForBlackCheck functions)
            public static int StartingWhiteKingColumn;
            public static int StartingWhiteKingRank;
            public static int StartingBlackKingColumn;
            public static int StartingBlackKingRank;

            // column number inserted by the user
            public static int m_StartingColumnNumber;
            public static int m_FinishingColumnNumber;

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            // Μεταβλητές για τον έλεγχο της "ορθότητας" και της "νομιμότητας" μιας κίνησης του χρήστη
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            // variable for the correctness of the move
            public static bool m_OrthotitaKinisis;
            // variable for the legality of the move
            public static bool m_NomimotitaKinisis;
            // has the user entered a wrong column?
            public static bool m_WrongColumn;

            // variables for 'For' loops
            public static int i;
            public static int j;

            public static int ApophasiXristi = 1;

            //////////////////////////////////////
            // Computer Thought
            //////////////////////////////////////
            // Chessboards used for the computer throught
            public static String[,] Skakiera_Move_0 = new String[8, 8]; // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα
            public static String[,] Skakiera_Move_After = new String[8, 8];
            public static String[,] Skakiera_Thinking = new String[8, 8];
            //static array<String, 2> Skakiera_Move_After = new array<String, 2>(8,8);  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα
            //static array<String, 2> Skakiera_Thinking = new array<String, 2>(8,8);  // Δήλωση πίνακα που χρησιμοποιείται στη σκέψη του υπολογιστή.
            // rest of variables used for computer thought
            public static double Best_Move_Score;
            public static double Current_Move_Score;
            public static int Best_Move_StartingColumnNumber;
            public static int Best_Move_FinishingColumnNumber;
            public static int Best_Move_StartingRank;
            public static int Best_Move_FinishingRank;
            public static int Move_Analyzed;
            public static bool Stop_Analyzing;
            public static int Thinking_Depth;
            //public static int Thinking_Depth_temp; // used when human eats a piece of the computer
            public static int m_StartingColumnNumber_HY;
            public static int m_FinishingColumnNumber_HY;
            public static int m_StartingRank_HY;
            public static int m_FinishingRank_HY;
            public static bool First_Call;
            public static String Who_Is_Analyzed;
            public static String MovingPiece_HY;

            // for writing the computer move
            public static String HY_Starting_Column_Text;
            public static String HY_Finishing_Column_Text;

            // chessboard to store the chessboard squares where it is dangerous
            // for the HY to move a piece
            // SEE function ComputerMove!
            //static array<String, 2> Skakiera_Dangerous_Squares = new array<String, 2>(8,8);  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα

            // variables which help find the best move of the human-opponent
            // during the HY thought analysis
            //public static String[,] Skakiera_Human_Move_0 = new String[8, 8];
            //public static String[,] Skakiera_Human_Thinking = new String[8, 8];
            //static array<String, 2> Skakiera_Human_Move_0 = new array<String, 2>(8,8);
            //static array<String, 2> Skakiera_Human_Thinking = new array<String, 2>(8,8);
            public static bool First_Call_Human_Thought;
            // 2009 version 1 change
            //public static int iii_Human;
            //public static int jjj_Human;
            public static String MovingPiece_Human = "";
            public static int m_StartingColumnNumber_Human = 1;
            public static int m_FinishingColumnNumber_Human = 1;
            public static int m_StartingRank_Human = 1;
            public static int m_FinishingRank_Human = 1;
            //public static double Current_Human_Move_Score;
            //public static double Best_Human_Move_Score;
            //public static int Best_Move_Human_StartingColumnNumber;
            //public static int Best_Move_Human_FinishingColumnNumber;
            //public static int Best_Move_Human_StartingRank;
            //public static int Best_Move_Human_FinishingRank;
            //public static bool Best_Human_Move_Found;

            // does the HY eats the queen of his opponent with the move it analyzes?
            // Changed in version 0.5
            public static bool eat_queen;

            // where the player can perform en passant
            public static int enpassant_possible_target_rank;
            public static int enpassant_possible_target_column;

            // is there a possible mate?
            public static bool Human_is_in_check;
            public static bool Possible_mate;

            // does the HY moves its King with the move it is analyzing?
            public static bool moving_the_king;

            public static int choise_of_user;
            //private static string test_starting_column;
            //private static string test_finishing_column;

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
                // BUT REMEMBER TO ALSO UNCOMMENT ComputerMove4,6,8 functions and
                // the respective part in HumanMove function that calls them!
                /////////////////////////////////////////////////////////////////////////
                // ΠΡΟΣΟΧΗ: Αν βάλω τον υπολογιστή να σκεφτεί σε βάθος 1 κίνησης
                // (ήτοι Thinking_Depth = 0), τότε ΔΕΝ σκέφτεται σωστά! Αυτό συμβαίνει
                // διότι η HumanMove πρέπει να κληθεί τουλάχιστον μία φορά για να
                // ολοκληρωθεί σωστά τουλάχιστον ένας πλήρης κύκλος σκέψης του ΗΥ.
                /////////////////////////////////////////////////////////////////////////

                //Thinking_Depth = 20;
                // MiniMax algorithm currently only utilizes 8-ply thinking depth
                // Add more "for loops" in the required section in ComputerMove to allow more deep thinking
                // However remember that the NodesAnalysis table has a limit!!! (and so does the memory)
                // Thinking depth must be ζυγός number because the nodes are recorded only in the Analyze_Computer functions!
                //QQQ1
                Thinking_Depth = 2;

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

                MessageBox.Show("\nHuo Chess v0.961 by Spiros I.Kakos (huo) [2014] - C# Edition\n\nCURRENT EXPERIMENT: Depth 2 (Minimax Algorithm)\n\nWhat about a nice game of chess?", "Huo Chess W8", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // initial values
                //White_King_Moved = false;
                //Black_King_Moved = false;
                //White_Rook_a1_Moved = false;
                //White_Rook_h1_Moved = false;
                //Black_Rook_a8_Moved = false;
                //Black_Rook_h8_Moved = false;
                //Can_Castle_Big_White = true;
                //Can_Castle_Big_Black = true;
                //Can_Castle_Small_White = true;
                //Can_Castle_Small_Black = true;
                Move = 0;
                m_WhichColorPlays = "White";

                // fix startup position
                Starting_position();

                // if it is the turn of HY to play, then call the respective function
                // to implement HY thought

                //bool exit_game = false;

                //2012:do
                //2012:{

                    if (m_WhoPlays.CompareTo("HY") == 0)
                    {
                        // call HY Thought function
                        Move = 0;

                        if (Move == 0)
                        {
                            //MessageBox.Show("");
                            //MessageBox.Show("Press to let me start thinking...");
                        }

                        Move_Analyzed = 0;
                        Stop_Analyzing = false;
                        First_Call = true;
                        Best_Move_Found = false;
                        Who_Is_Analyzed = "HY";


                        //----------------CHECK DANGER---------------------------------------
                        // Find the dangerous squares in the chessboard, where if the HY
                        // moves its piece, it will immediately (or most probably) loose it.

                        for (i = 0; i <= 7; i++)
                        {
                            for (j = 0; j <= 7; j++)
                            {
                                Skakiera_Dangerous_Squares[i, j] = "";
                            }
                        }

                        // Changed in version 0.5
                        // Initialize variables for finfind the dangerous squares
                        for (int di = 0; di <= 7; di++)
                        {
                            for (int dj = 0; dj <= 7; dj++)
                            {
                                Number_of_attackers[di, dj] = 0;
                                Number_of_defenders[di, dj] = 0;
                                Value_of_attackers[di, dj] = 0;
                                //2012 added Attackers_coordinates table
                                Attackers_coordinates_column[di, dj] = 0;
                                Attackers_coordinates_rank[di, dj] = 0;
                                Value_of_defenders[di, dj] = 0;
                                Exception_defender_column[di, dj] = -9;
                                Exception_defender_rank[di, dj] = -9;
                            }
                        }

                        FindAttackers(Skakiera);
                        FindDefenders(Skakiera);

                        //-----------------------------------------------------------------------

                        ComputerMove(Skakiera);

                        // 2012: Make player clicks zero so as to wait again for the player to click his moves with the mouse
                        m_WhoPlays = "Human";
                        playerClicks = 0;
                    }
                    //2012:else if (m_WhoPlays.CompareTo("Human") == 0)
                    //2012:{
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

                        // show the move entered

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
                    //2012:}

                //2012:} while (exit_game == false);

            }



            public static bool CheckForBlackCheck(string[,] BCSkakiera)
            {
                // TODO: Add your control notification handler code here

                bool KingCheck;

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
                            BlackKingColumn = (i + 1);
                            BlackKingRank = (j + 1);
                        }

                    }
                }

                ///////////////////////////////////////////////////////////////
                // Έλεγχος του αν ο μαύρος βασιλιάς υφίσταται "σαχ"
                ///////////////////////////////////////////////////////////////

                KingCheck = false;

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Ελέγχουμε αρχικά αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΤΑ ΔΕΞΙΑ ΤΟΥ. Για να μην βγούμε έξω από τα
                // όρια της BCSkakiera[(8),(8)] έχουμε προσθέσει τον έλεγχο (BlackKingColumn + 1) <= 8 στο "if". Αρχικά ο "κίνδυνος"
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

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingColumn + klopa) <= 8) && (DangerFromRight == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("Black Queen") == 0))
                            DangerFromRight = false;
                        else if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - 1)].CompareTo("White King") == 0))
                            DangerFromRight = false;
                    }
                }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΤΑ ΑΡΙΣΤΕΡΑ ΤΟΥ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromLeft = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingColumn - klopa) >= 1) && (DangerFromLeft == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("Black Queen") == 0))
                            DangerFromLeft = false;
                        else if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - 1)].CompareTo("White King") == 0))
                            DangerFromLeft = false;
                    }
                }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΠΑΝΩ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////


                DangerFromUp = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingRank + klopa) <= 8) && (DangerFromUp == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromUp = false;
                        else if ((BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank + klopa - 1)].CompareTo("White King") == 0))
                            DangerFromUp = false;
                    }
                }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΚΑΤΩ (από πύργο ή βασίλισσα).
                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDown = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingRank - klopa) >= 1) && (DangerFromDown == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromDown = false;
                        else if ((BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn - 1), (BlackKingRank - klopa - 1)].CompareTo("White King") == 0))
                            DangerFromDown = false;
                    }
                }



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΠΑΝΩ-ΔΕΞΙΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromUpRight = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingColumn + klopa) <= 8) && ((BlackKingRank + klopa) <= 8) && (DangerFromUpRight == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromUpRight = false;
                        else if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White King") == 0))
                            DangerFromUpRight = false;
                    }
                }



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΚΑΤΩ-ΑΡΙΣΤΕΡΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDownLeft = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingColumn - klopa) >= 1) && ((BlackKingRank - klopa) >= 1) && (DangerFromDownLeft == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromDownLeft = false;
                        else if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White King") == 0))
                            DangerFromDownLeft = false;
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΚΑΤΩ-ΔΕΞΙΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromDownRight = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingColumn + klopa) <= 8) && ((BlackKingRank - klopa) >= 1) && (DangerFromDownRight == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromDownRight = false;
                        else if ((BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn + klopa - 1), (BlackKingRank - klopa - 1)].CompareTo("White King") == 0))
                            DangerFromDownRight = false;
                    }
                }



                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Έλεγχος αν υπάρχει κίνδυνος για το μαύρο βασιλιά ΑΠΟ ΠΑΝΩ-ΑΡΙΣΤΕΡΑ ΤΟΥ (από βασίλισσα ή αξιωματικό).
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                DangerFromUpLeft = true;

                for (int klopa = 1; klopa <= 7; klopa++)
                {
                    if (((BlackKingColumn - klopa) >= 1) && ((BlackKingRank + klopa) <= 8) && (DangerFromUpLeft == true))
                    {
                        if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Bishop") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Queen") == 0))
                            KingCheck = true;
                        else if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Pawn") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Rook") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Knight") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Bishop") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("Black Queen") == 0))
                            DangerFromUpLeft = false;
                        else if ((BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Pawn") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Rook") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White Knight") == 0) || (BCSkakiera[(BlackKingColumn - klopa - 1), (BlackKingRank + klopa - 1)].CompareTo("White King") == 0))
                            DangerFromUpLeft = false;
                    }
                }


                //////////////////////////////////////////////////////////////////////////
                // Έλεγχος για το αν ο μαύρος βασιλιάς απειλείται από πιόνι.
                //////////////////////////////////////////////////////////////////////////

                if (((BlackKingColumn + 1) <= 8) && ((BlackKingRank - 1) >= 1))
                {
                    if (BCSkakiera[(BlackKingColumn + 1 - 1), (BlackKingRank - 1 - 1)].CompareTo("White Pawn") == 0)
                    {
                        KingCheck = true;
                    }
                }


                if (((BlackKingColumn - 1) >= 1) && ((BlackKingRank - 1) >= 1))
                {
                    if (BCSkakiera[(BlackKingColumn - 1 - 1), (BlackKingRank - 1 - 1)].CompareTo("White Pawn") == 0)
                    {
                        KingCheck = true;
                    }
                }


                ///////////////////////////////////////////////////////////////////////
                // Έλεγχος για το αν ο μαύρος βασιλιάς απειλείται από ίππο.
                ///////////////////////////////////////////////////////////////////////

                if (((BlackKingColumn + 1) <= 8) && ((BlackKingRank + 2) <= 8))
                    if (BCSkakiera[(BlackKingColumn + 1 - 1), (BlackKingRank + 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn + 2) <= 8) && ((BlackKingRank - 1) >= 1))
                    if (BCSkakiera[(BlackKingColumn + 2 - 1), (BlackKingRank - 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn + 1) <= 8) && ((BlackKingRank - 2) >= 1))
                    if (BCSkakiera[(BlackKingColumn + 1 - 1), (BlackKingRank - 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn - 1) >= 1) && ((BlackKingRank - 2) >= 1))
                    if (BCSkakiera[(BlackKingColumn - 1 - 1), (BlackKingRank - 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn - 2) >= 1) && ((BlackKingRank - 1) >= 1))
                    if (BCSkakiera[(BlackKingColumn - 2 - 1), (BlackKingRank - 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn - 2) >= 1) && ((BlackKingRank + 1) <= 8))
                    if (BCSkakiera[(BlackKingColumn - 2 - 1), (BlackKingRank + 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn - 1) >= 1) && ((BlackKingRank + 2) <= 8))
                    if (BCSkakiera[(BlackKingColumn - 1 - 1), (BlackKingRank + 2 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                if (((BlackKingColumn + 2) <= 8) && ((BlackKingRank + 1) <= 8))
                    if (BCSkakiera[(BlackKingColumn + 2 - 1), (BlackKingRank + 1 - 1)].CompareTo("White Knight") == 0)
                        KingCheck = true;

                return KingCheck;
            }



            public static bool CheckForBlackMate(string[,] BMSkakiera)
            {
                // TODO: Add your control notification handler code here

                bool Mate;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Μεταβλητή που χρησιμεύει στον έλεγχο για το αν υπάρχει ματ (βλ. συναρτήσεις CheckForWhiteMate() και
                // CheckForBlackMate()).
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
                            StartingBlackKingColumn = (i + 1);
                            StartingBlackKingRank = (j + 1);
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

                    if (StartingBlackKingRank < 8)
                    {
                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1 + 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingRank - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.
                            // Ο έλεγχος γίνεται μόνο αν στο τετράγωνο που μετακινείται προσωρινά ο βασιλιάς δεν υπάρχει άλλο κομμάτι
                            // του ίδιου χρώματος που να τον εμποδίζει και αν, φυσικά, ο βασιλιάς δεν βγαίνει έξω από τη σκακιέρα με
                            // αυτή του την κίνηση και αν, προφανώς, συνεχίζει να υπάρχει πιθανότητα να ύπάρχει ματ (καθώς αν δεν
                            // υπάρχει τέτοια πιθανότητα, τότε ο έλεγχος είναι άχρηστος).

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1 + 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1 + 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlackKingColumn < 8) && (StartingBlackKingRank < 8))
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1 + 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingRank - 1 + 1) <= 7) && ((StartingBlackKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1 + 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1 + 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlackKingColumn < 8)
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlackKingColumn < 8) && (StartingBlackKingRank > 1))
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1 - 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingRank - 1 - 1) >= 0) && ((StartingBlackKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1 - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1 + 1), (StartingBlackKingRank - 1 - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlackKingRank > 1)
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1 - 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingRank - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1 - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1 - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlackKingColumn > 1) && (StartingBlackKingRank > 1))
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1 - 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingRank - 1 - 1) >= 0) && ((StartingBlackKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1 - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1 - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingBlackKingColumn > 1)
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο μαύρος βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingBlackKingColumn > 1) && (StartingBlackKingRank < 8))
                    {

                        MovingPiece = BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)];
                        ProsorinoKommati = BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1 + 1)];

                        if ((ProsorinoKommati.CompareTo("Black Queen") == 1) && (ProsorinoKommati.CompareTo("Black Rook") == 1) && (ProsorinoKommati.CompareTo("Black Knight") == 1) && (ProsorinoKommati.CompareTo("Black Bishop") == 1) && (ProsorinoKommati.CompareTo("Black Pawn") == 1) && (DangerForMate == true) && ((StartingBlackKingRank - 1 + 1) <= 7) && ((StartingBlackKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = "";
                            BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1 + 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(BMSkakiera);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            BMSkakiera[(StartingBlackKingColumn - 1), (StartingBlackKingRank - 1)] = MovingPiece;
                            BMSkakiera[(StartingBlackKingColumn - 1 - 1), (StartingBlackKingRank - 1 + 1)] = ProsorinoKommati;

                        }

                    }

                    if (DangerForMate == true)
                        Mate = true;

                }

                return Mate;
            }






            public static bool CheckForWhiteCheck(string[,] WCSkakiera)
            {


                // TODO: Add your control notification handler code here

                bool KingCheck;

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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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

                for (int klopa = 1; klopa <= 7; klopa++)
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




            public static bool CheckForWhiteMate(string[,] WMSkakiera)
            {
                // TODO: Add your control notification handler code here

                bool Mate;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Μεταβλητή που χρησιμεύει στον έλεγχο για το αν υπάρχει ματ (βλ. συναρτήσεις CheckForWhiteMate() και
                // CheckForBlackMate()).
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

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 + 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.
                            // Ο έλεγχος γίνεται μόνο αν στο τετράγωνο που μετακινείται προσωρινά ο βασιλιάς δεν υπάρχει άλλο κομμάτι
                            // του ίδιου χρώματος που να τον εμποδίζει και αν, φυσικά, ο βασιλιάς δεν βγαίνει έξω από τη σκακιέρα με
                            // αυτή του την κίνηση και αν, προφανώς, συνεχίζει να υπάρχει πιθανότητα να ύπάρχει ματ (καθώς αν δεν
                            // υπάρχει τέτοια πιθανότητα, τότε ο έλεγχος είναι άχρηστος).

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 + 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 + 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn < 8) && (StartingWhiteKingRank < 8))
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 + 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 + 1) <= 7) && ((StartingWhiteKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 + 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 + 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingColumn < 8)
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-δεξιά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn < 8) && (StartingWhiteKingRank > 1))
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 - 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 - 1) >= 0) && ((StartingWhiteKingColumn - 1 + 1) <= 7))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1 + 1), (StartingWhiteKingRank - 1 - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingRank > 1)
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 - 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά προς τα πάνω και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1 - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα κάτω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn > 1) && (StartingWhiteKingRank > 1))
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 - 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 - 1) >= 0) && ((StartingWhiteKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (StartingWhiteKingColumn > 1)
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1)] = ProsorinoKommati;

                        }

                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Έλεγχος του αν θα συνεχίσει να υπάρχει σαχ αν ο λευκός βασιλιάς προσπαθήσει να διαφύγει μετακινούμενος
                    // προς τα πάνω-αριστερά
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if ((StartingWhiteKingColumn > 1) && (StartingWhiteKingRank < 8))
                    {

                        MovingPiece = WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)];
                        ProsorinoKommati = WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 + 1)];

                        if ((ProsorinoKommati.CompareTo("White Queen") == 1) && (ProsorinoKommati.CompareTo("White Rook") == 1) && (ProsorinoKommati.CompareTo("White Knight") == 1) && (ProsorinoKommati.CompareTo("White Bishop") == 1) && (ProsorinoKommati.CompareTo("White Pawn") == 1) && (DangerForMate == true) && ((StartingWhiteKingRank - 1 + 1) <= 7) && ((StartingWhiteKingColumn - 1 - 1) >= 0))
                        {

                            // (Προσωρινή) μετακίνηση του βασιλιά και έλεγχος του αν συνεχίζει τότε να υπάρχει σαχ.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = "";
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 + 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WMSkakiera);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            // Επαναφορά της σκακιέρας στην κατάσταση στην οποία βρισκόταν πριν μετακινηθεί ο βασιλιάς για τους
                            // σκοπούς του ελέγχου.

                            WMSkakiera[(StartingWhiteKingColumn - 1), (StartingWhiteKingRank - 1)] = MovingPiece;
                            WMSkakiera[(StartingWhiteKingColumn - 1 - 1), (StartingWhiteKingRank - 1 + 1)] = ProsorinoKommati;

                        }

                    }

                    if (DangerForMate == true)
                        Mate = true;

                }

                return Mate;
            }


            // Changed in version 0.961!
            public static void CheckMove(string[,] CMSkakiera)
            {
                #region WriteLog
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("ChMo -- Entered CheckMove");
                //huo_sw1.WriteLine(string.Concat("ChMo -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("ChMo -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");
                #endregion WriteLog

                number_of_moves_analysed++;

                m_WhoPlays = "Human";
                m_WrongColumn = false;
                MovingPiece = CMSkakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];

                // Check correctness of move
                m_OrthotitaKinisis = ElegxosOrthotitas(CMSkakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                // if move is correct, then check the legality also
                if (m_OrthotitaKinisis == true)
                    m_NomimotitaKinisis = ElegxosNomimotitas(CMSkakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                // restore the normal value of the m_WhoPlays
                m_WhoPlays = "HY";

                // CHECK FOR MATE
                #region CheckForMate

                if (((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true)) && (Move_Analyzed == 0))
                {
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // temporarily move the piece to see if the king will continue to be under check
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////

                    CMSkakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                    ProsorinoKommati = CMSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];   // Προσωρινή αποθήκευση του
                    // κομματιού που βρίσκεται στο
                    // τετράγωνο προορισμού
                    // (βλ. μετά για τη χρησιμότητα
                    // του, εκεί που γίνεται έλεγ-
                    // χος για το αν συνεχίζει να
                    // υφίσταται σαχ).

                    CMSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                    //////////////////////////////////////////////////////////////////////////
                    // is the king still under check?
                    //////////////////////////////////////////////////////////////////////////

                    WhiteKingCheck = CheckForWhiteCheck(CMSkakiera);

                    if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
                    {
                        m_NomimotitaKinisis = false;
                    }


                    ///////////////////////////////////////////////////////////////////////////
                    // is the black king under check?
                    ///////////////////////////////////////////////////////////////////////////

                    BlackKingCheck = CheckForBlackCheck(CMSkakiera);

                    if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
                    {
                        m_NomimotitaKinisis = false;
                    }


                    // restore pieces to their initial positions
                    CMSkakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                    CMSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = ProsorinoKommati;

                }
                #endregion CheckForMate

                if (((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true)) && (Move_Analyzed == 0))
                {
                    // Store the move to ***_HY variables (because after continuous calls of ComputerMove the initial move under analysis will be lost...)

                    MovingPiece_HY = MovingPiece;
                    m_StartingColumnNumber_HY = m_StartingColumnNumber;
                    m_FinishingColumnNumber_HY = m_FinishingColumnNumber;
                    m_StartingRank_HY = m_StartingRank;
                    m_FinishingRank_HY = m_FinishingRank;

                    // Store the initial move coordinates (at the node 0 level)
                    NodesAnalysis[NodeLevel_0_count, 21, 0] = m_StartingColumnNumber_HY;
                    NodesAnalysis[NodeLevel_0_count, 22, 0] = m_FinishingColumnNumber_HY;
                    NodesAnalysis[NodeLevel_0_count, 23, 0] = m_StartingRank_HY;
                    NodesAnalysis[NodeLevel_0_count, 24, 0] = m_FinishingRank_HY;

                    // Temporarily move the piece to see if the king will continue to be under check
                    #region CheckCheck

                    CMSkakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                    ProsorinoKommati = CMSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                    // Προσωρινή αποθήκευση του κομματιού που βρίσκεται στο τετράγωνο προορισμού
                    // (βλ. μετά για τη χρησιμότητα του, εκεί που γίνεται έλεγχος για το αν συνεχίζει να υφίσταται σαχ).

                    CMSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                    //////////////////////////////////////////////////////////////////////////
                    // is the king still under check?
                    //////////////////////////////////////////////////////////////////////////

                    WhiteKingCheck = CheckForWhiteCheck(CMSkakiera);

                    if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
                    {
                        m_NomimotitaKinisis = false;
                    }


                    ///////////////////////////////////////////////////////////////////////////
                    // is the black king under check?
                    ///////////////////////////////////////////////////////////////////////////

                    BlackKingCheck = CheckForBlackCheck(CMSkakiera);

                    if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
                    {
                        m_NomimotitaKinisis = false;
                    }


                    // restore pieces to their initial positions
                    CMSkakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                    CMSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = ProsorinoKommati;
                    #endregion CheckCheck

                    // check is HY eats the opponents queen (so it is preferable to do so...)
                    if ((ProsorinoKommati.CompareTo("White Queen") == 0) || (ProsorinoKommati.CompareTo("Black Queen") == 0))
                        go_for_it = true;
                    // Not operational yet...
                    go_for_it = false;

                    // CHECK FOR DANGER PENALTY
                    #region DangerPenalty
                    int Existing_Danger_level = 0;
                    int Current_Danger_level = 0;
                    Danger_penalty = false;
                    Danger_for_piece = false;
                    int Piece_in_danger_rank = 0;
                    int Piece_in_danger_column = 0;

                    // Find value of piece in Skakiera(y,u)
                    // v0.96
                    int Value_of_piece_in_square = 0;
                    if ((Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Rook") == 0) || (Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Rook") == 0))
                        Value_of_piece_in_square = 5;
                    else if ((Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Bishop") == 0))
                        Value_of_piece_in_square = 3;
                    else if ((Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Knight") == 0) || (Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Knight") == 0))
                        Value_of_piece_in_square = 3;
                    else if ((Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Queen") == 0) || (Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Queen") == 0))
                        Value_of_piece_in_square = 9;
                    else if ((Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Pawn") == 0) || (Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Pawn") == 0))
                        Value_of_piece_in_square = 1;

                    int Value_of_moving_piece = 0;
                    if ((MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                        Value_of_moving_piece = 5;
                    else if ((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                        Value_of_moving_piece = 3;
                    else if ((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                        Value_of_moving_piece = 3;
                    else if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0))
                        Value_of_moving_piece = 9;
                    else if ((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0))
                        Value_of_moving_piece = 1;

                    if ((Number_of_defenders[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] == Number_of_attackers[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)]) && ((Value_of_defenders[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)]) > Value_of_attackers[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)]))
                    {
                        Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = "Danger";
                    }

                    if (Number_of_defenders[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] < Number_of_attackers[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)])
                    {
                        Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = "Danger";
                    }

                    // Check danger for specific pieces
                    if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Queen") == 0) && (m_PlayerColor.CompareTo("Black") == 0))
                    {
                        Current_Danger_level = 9;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for White Queen!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Queen") == 0) && (m_PlayerColor.CompareTo("White") == 0))
                    {
                        Current_Danger_level = 9;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for Black Queen!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Rook") == 0) && (m_PlayerColor.CompareTo("Black") == 0))
                    {
                        Current_Danger_level = 5;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for White Rook!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Rook") == 0) && (m_PlayerColor.CompareTo("White") == 0))
                    {
                        Current_Danger_level = 5;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for Black Rook!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Knight") == 0) && (m_PlayerColor.CompareTo("Black") == 0))
                    {
                        Current_Danger_level = 3;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for White Knight!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Knight") == 0) && (m_PlayerColor.CompareTo("White") == 0))
                    {
                        Current_Danger_level = 3;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for Black Knight!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("White Bishop") == 0) && (m_PlayerColor.CompareTo("Black") == 0))
                    {
                        Current_Danger_level = 3;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for White Bishop!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }
                    else if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0) && (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Black Bishop") == 0) && (m_PlayerColor.CompareTo("White") == 0))
                    {
                        Current_Danger_level = 3;

                        if (Current_Danger_level > Existing_Danger_level)
                        {
                            //Console.WriteLine("Danger for Black Bishop!");
                            Danger_for_piece = true;
                            Piece_in_danger_rank = (m_FinishingRank - 1);
                            Piece_in_danger_column = (m_FinishingColumnNumber - 1);
                            Existing_Danger_level = Current_Danger_level;
                        }
                    }


                    if ((Skakiera_Dangerous_Squares[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("Danger") == 0))
                    {
                        Danger_penalty = true;
                    }

                    // If you do not move the threatened piece, then: Danger Penalty!
                    if (Danger_for_piece == true)
                    {
                        if (((m_StartingColumnNumber - 1) != Piece_in_danger_column) || ((m_StartingRank - 1) != Piece_in_danger_rank))
                        {
                            //Console.WriteLine("Didn't you save the queen?");
                            Danger_penalty = true;
                        }

                        // Check again if the move eats the piece which threatens the computer's piece
                        if ((((m_FinishingColumnNumber - 1) == Attackers_coordinates_column[(Piece_in_danger_column), (Piece_in_danger_rank)]) && ((m_FinishingRank - 1) == Attackers_coordinates_rank[(Piece_in_danger_column), (Piece_in_danger_rank)])))
                        {
                            //Console.WriteLine(string.Concat("The move ", m_StartingColumnNumber.ToString(), m_StartingRank.ToString(), "->", m_FinishingColumnNumber.ToString(), m_FinishingRank.ToString(), " saves the queen!"));
                            Danger_penalty = false;
                        }
                    }

                    // Penalty for moving the only piece that defends a square to that square (thus leavind the defender
                    // alone in the square he once defended, defenceless!)
                    if ((Exception_defender_column[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] == (m_StartingColumnNumber - 1)) && (Exception_defender_rank[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] == (m_StartingRank - 1)))
                    {
                        //MessageBox.Show("Debug message - Danger penalty checkpoint 1");
                        Danger_penalty = true;
                    }

                    //------------------- END OF DANGER PENALTY CHECK --------------------------
                    #endregion DangerPenalty
                }

            }

            // Changed in version 0.961!
            public static void ComputerMove(string[,] Skakiera_Thinking_init)
            {
                #region WriteLog
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("CoMo -- Entered ComputerMove");
                //huo_sw1.WriteLine(string.Concat("CoMo -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CoMo -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");
                #endregion WriteLog

                int iii;
                int jjj;
                String MovingPiece0;
                String ProsorinoKommati0;
                int m_StartingColumnNumber0;
                int m_FinishingColumnNumber0;
                int m_StartingRank0;
                int m_FinishingRank0;     

                #region InitializeNodes
                // START [MiniMax algorithm - skakos]
                NodeLevel_0_count = 0;
                NodeLevel_1_count = 0;
                NodeLevel_2_count = 0;
                NodeLevel_3_count = 0;
                NodeLevel_4_count = 0;
                NodeLevel_5_count = 0;
                NodeLevel_6_count = 0;
                NodeLevel_7_count = 0;
                NodeLevel_8_count = 0;
                NodeLevel_9_count = 0;
                NodeLevel_10_count = 0;
                NodeLevel_11_count = 0;
                NodeLevel_12_count = 0;
                NodeLevel_13_count = 0;
                NodeLevel_14_count = 0;
                NodeLevel_15_count = 0;
                NodeLevel_16_count = 0;
                NodeLevel_17_count = 0;
                NodeLevel_18_count = 0;
                NodeLevel_19_count = 0;
                NodeLevel_20_count = 0;
                Nodes_Total_count = 0;

                for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                {
                    for (int dimension2 = 0; dimension2 < 26; dimension2++)
                    {
                        for (int dimension3 = 0; dimension3 < 2; dimension3++)
                        {
                            NodesAnalysis[dimension1, dimension2, dimension3] = 0;
                        }
                    }
                }
                #endregion InitializeNodes

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

                // CHECK IF POSITION IS IN THE OPENING BOOK
                #region OpeningBookCheck
                int op_iii;
                int op_jjj;

                int opening = 1;

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
                        }
                    }
                    else
                    {
                        exit_opening_loop = true;
                    }

                    opening = opening + 1;
                } while (exit_opening_loop == false);
                #endregion OpeningBookCheck

                // CHECK FOR DANGEROUS SQUARES
                #region DangerousSquares
                Danger_for_piece = false;

                    for (int o1 = 0; o1 <= 7; o1++)
                    {
                        for (int p1 = 0; p1 <= 7; p1++)
                        {
                            Skakiera_Dangerous_Squares[(o1), (p1)] = "";
                        }
                    }

                    FindAttackers(Skakiera_Thinking);
                    FindDefenders(Skakiera_Thinking);
                    #endregion DangerousSquares


                //---------------------------------------
                // CHECK ALL POSSIBLE MOVES!
                //---------------------------------------

                for (iii = 0; iii <= 7; iii++)
                {
                    for (jjj = 0; jjj <= 7; jjj++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Skakiera_Thinking[(iii), (jjj)].CompareTo("White King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Thinking[(iii), (jjj)].CompareTo("Black King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))) || ((Who_Is_Analyzed.CompareTo("Human") == 0) && ((((Skakiera_Thinking[(iii), (jjj)].CompareTo("White King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)) || (((Skakiera_Thinking[(iii), (jjj)].CompareTo("Black King") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking[(iii), (jjj)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)))))
                        {

                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    Danger_penalty = false;
                                    //Attackers_penalty = false;
                                    //Defenders_value_penalty = false;

                                    MovingPiece = Skakiera_Thinking[(iii), (jjj)];
                                    m_StartingColumnNumber = iii + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = jjj + 1;
                                    m_FinishingRank = r + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece0             = MovingPiece;
                                    m_StartingColumnNumber0  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber0 = m_FinishingColumnNumber;
                                    m_StartingRank0          = m_StartingRank;
                                    m_FinishingRank0         = m_FinishingRank;
                                    ProsorinoKommati0 = Skakiera_Thinking[(m_FinishingColumnNumber0 - 1), (m_FinishingRank0 - 1)];

                                    possibility_to_eat_back = false;
                                    if ((m_FinishingColumnNumber == target_column) && (m_FinishingRank == target_row))
                                        possibility_to_eat_back = true;

                                    // Check for stupid moves in the start of the game
                                    bool DoNotMakeStupidMove = false;
                                    #region CheckStupidMove
                                    if (Move < 5)
                                    {
                                        if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0) ||
                                                (MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if (((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                                && (m_FinishingColumnNumber == 1))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if (((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                                && (m_FinishingColumnNumber == 8))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("White Knight") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 4)
                                                && (Skakiera_Thinking[(2), (0)].CompareTo("White Bishop") == 0))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("White Knight") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 5)
                                                && (Skakiera_Thinking[(5), (0)].CompareTo("White Bishop") == 0))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("Black Knight") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 4)
                                                && (Skakiera_Thinking[(2), (7)].CompareTo("Black Bishop") == 0))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("Black Knight") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 5)
                                                && (Skakiera_Thinking[(5), (7)].CompareTo("Black Bishop") == 0))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("White Pawn") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("White Pawn") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("Black Pawn") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("Black Pawn") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if ((MovingPiece.CompareTo("White King") == 0) || (MovingPiece.CompareTo("Black King") == 0))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                        else if (((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                                            && ((m_FinishingRank == 3) || (m_FinishingRank == 5) || (m_FinishingRank == 6)))
                                        {
                                            DoNotMakeStupidMove = true;
                                        }
                                    }
                                    #endregion CheckStupidMove

                                    if (DoNotMakeStupidMove == false)
                                    {
                                        // THE HEART OF THE THINKING MECHANISM - Here the computer checks the moves

                                        // Validity and legality of the move has been checked in CheckMove
                                        // (plus some additional checks)
                                        CheckMove(Skakiera_Thinking);

                                        number_of_moves_analysed++;

                                        // If all ok, then do the move and measure it
                                        if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                        {
                                            // huo_sw1.WriteLine(string.Concat("Human move 1: Found a legal move!"));

                                            // Do the move
                                            ProsorinoKommati = Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                            Skakiera_Thinking[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                            Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                            // Check the score after the computer move.
                                            if (Move_Analyzed == 0)
                                            {
                                                NodeLevel_0_count++;
                                                Temp_Score_Move_0 = CountScore(Skakiera_Thinking, humanDangerParameter);
                                            }
                                            if (Move_Analyzed == 2)
                                            {
                                                NodeLevel_2_count++;
                                                Temp_Score_Move_2 = CountScore(Skakiera_Thinking, humanDangerParameter);
                                            }
                                            if (Move_Analyzed == 4)
                                            {
                                                NodeLevel_4_count++;
                                                Temp_Score_Move_4 = CountScore(Skakiera_Thinking, humanDangerParameter);
                                            }
                                            if (Move_Analyzed == 6)
                                            {
                                                NodeLevel_6_count++;
                                                Temp_Score_Move_6 = CountScore(Skakiera_Thinking, humanDangerParameter);
                                            }

                                            if (Move_Analyzed < Thinking_Depth)
                                            {
                                                Move_Analyzed = Move_Analyzed + 1;

                                                for (i = 0; i <= 7; i++)
                                                {
                                                    for (j = 0; j <= 7; j++)
                                                    {
                                                        Skakiera_Move_After[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                                    }
                                                }

                                                Who_Is_Analyzed = "Human";
                                                First_Call_Human_Thought = true;

                                                // Check human move (to find the best possible answer of the human
                                                // to the move currently analyzed by the HY Thought process)
                                                if (Move_Analyzed == 1)
                                                    Analyze_Move_1_HumanMove(Skakiera_Move_After);
                                                else if (Move_Analyzed == 3)
                                                    Analyze_Move_3_HumanMove(Skakiera_Move_After);
                                                else if (Move_Analyzed == 5)
                                                    Analyze_Move_5_HumanMove(Skakiera_Move_After);
                                            }

                                            if (Move_Analyzed == Thinking_Depth)
                                            {
                                                // [MiniMax algorithm - skakos]
                                                // Record the node in the Nodes Analysis array (to use with MiniMax algorithm) skakos
                                                NodesAnalysis[NodeLevel_0_count, 0, 0] = Temp_Score_Move_0;
                                                NodesAnalysis[NodeLevel_1_count, 1, 0] = Temp_Score_Move_1_human;
                                                NodesAnalysis[NodeLevel_2_count, 2, 0] = Temp_Score_Move_2;
                                                NodesAnalysis[NodeLevel_3_count, 3, 0] = Temp_Score_Move_3_human;
                                                NodesAnalysis[NodeLevel_4_count, 4, 0] = Temp_Score_Move_4;
                                                NodesAnalysis[NodeLevel_5_count, 5, 0] = Temp_Score_Move_5_human;
                                                NodesAnalysis[NodeLevel_6_count, 6, 0] = Temp_Score_Move_6;

                                                // Store the parents (number of the node of the upper level)
                                                NodesAnalysis[NodeLevel_0_count, 0, 1] = 0;
                                                NodesAnalysis[NodeLevel_1_count, 1, 1] = NodeLevel_0_count;
                                                NodesAnalysis[NodeLevel_2_count, 2, 1] = NodeLevel_1_count;
                                                NodesAnalysis[NodeLevel_3_count, 3, 1] = NodeLevel_2_count;
                                                NodesAnalysis[NodeLevel_4_count, 4, 1] = NodeLevel_3_count;
                                                NodesAnalysis[NodeLevel_5_count, 5, 1] = NodeLevel_4_count;
                                                NodesAnalysis[NodeLevel_6_count, 6, 1] = NodeLevel_5_count;

                                                if (Danger_penalty == true)
                                                {
                                                    //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] - 2000000000;
                                                    //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] + 2000000000;
                                                }

                                                if (go_for_it == true)
                                                {
                                                    //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] + 2000000000;
                                                    //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] - 2000000000;
                                                }

                                                Nodes_Total_count++;

                                                // Safety valve in case we reach the end of the table capacity
                                                // This is a limit for the memory. Will have to do something about it!
                                                if (Nodes_Total_count > 1000000)
                                                {
                                                    Console.WriteLine("Limit of memory in NodesAnalysis array reached!");
                                                    Nodes_Total_count = 1000000;
                                                }
                                            }

                                            // Undo the move
                                            Skakiera_Thinking[(m_StartingColumnNumber0 - 1), (m_StartingRank0 - 1)] = MovingPiece0;
                                            Skakiera_Thinking[(m_FinishingColumnNumber0 - 1), (m_FinishingRank0 - 1)] = ProsorinoKommati0;
                                        }

                                    }


                                }
                            }

                        }


                    }
                }

                // Find if there is mate
                #region CheckIfMate
                if ((Move_Analyzed == 0) && ((WhiteKingCheck == true) || (BlackKingCheck == true)))
                {

                    // Αν ο υπολογιστής δεν κατόρθωσε να βρει καμία νόμιμη κίνηση να κάνει εξαιτίας του ότι είναι ματ

                    if (Best_Move_Found == false)
                    {
                        //Mate = true;

                        if (m_PlayerColor.CompareTo("White") == 0)
                            Console.WriteLine("Black is MATE!");
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                            Console.WriteLine("White is MATE!");
                    }

                }
                #endregion CheckIfMate

                // DO THE BEST MOVE FOUND

                // [MiniMax algorithm - skakos]
                // Find node 1 move with the best score" part to stop using the MiniMax algorithm.
                int counter0, counter1, counter2, counter3, counter4, counter5, counter6, counter7, counter8, counter9, counter10;
                int counter11, counter12, counter13, counter14, counter15, counter16, counter17, counter18, counter19;
                int counter20;

                // Write log of nodes BEFORE
                #region NodesLogBEFORE

                //StreamWriter huo_sw2 = new StreamWriter("NodesAnalysis_before.txt", true);

                ////MessageBox.Show(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                //huo_sw2.WriteLine(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                ////MessageBox.Show(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw2.WriteLine(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw2.WriteLine("");

                //for (counter20 = 1; counter20 <= NodeLevel_20_count; counter20++)
                //{

                //    huo_sw2.WriteLine(string.Concat("20, ", counter20.ToString(), " , ", NodesAnalysis[counter20, 20, 0].ToString(), " , ", NodesAnalysis[counter20, 20, 1].ToString()));
                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 19"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter19 = 1; counter19 <= NodeLevel_19_count; counter19++)
                //{

                //    huo_sw2.WriteLine(string.Concat("19, ", counter19.ToString(), " , ", NodesAnalysis[counter19, 19, 0].ToString(), " , ", NodesAnalysis[counter19, 19, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 18"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter18 = 1; counter18 <= NodeLevel_18_count; counter18++)
                //{

                //    huo_sw2.WriteLine(string.Concat("18, ", counter18.ToString(), " , ", NodesAnalysis[counter18, 18, 0].ToString(), " , ", NodesAnalysis[counter18, 18, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 17"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter17 = 1; counter17 <= NodeLevel_17_count; counter17++)
                //{

                //    huo_sw2.WriteLine(string.Concat("17, ", counter17.ToString(), " , ", NodesAnalysis[counter17, 17, 0].ToString(), " , ", NodesAnalysis[counter17, 17, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 16"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter16 = 1; counter16 <= NodeLevel_16_count; counter16++)
                //{

                //    huo_sw2.WriteLine(string.Concat("16, ", counter16.ToString(), " , ", NodesAnalysis[counter16, 16, 0].ToString(), " , ", NodesAnalysis[counter16, 16, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 15"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter15 = 1; counter15 <= NodeLevel_15_count; counter15++)
                //{

                //    huo_sw2.WriteLine(string.Concat("15, ", counter15.ToString(), " , ", NodesAnalysis[counter15, 15, 0].ToString(), " , ", NodesAnalysis[counter15, 15, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 14"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter14 = 1; counter14 <= NodeLevel_14_count; counter14++)
                //{

                //    huo_sw2.WriteLine(string.Concat("14, ", counter14.ToString(), " , ", NodesAnalysis[counter14, 14, 0].ToString(), " , ", NodesAnalysis[counter14, 14, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 13"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter13 = 1; counter13 <= NodeLevel_13_count; counter13++)
                //{

                //    huo_sw2.WriteLine(string.Concat("13, ", counter13.ToString(), " , ", NodesAnalysis[counter13, 13, 0].ToString(), " , ", NodesAnalysis[counter13, 13, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 12"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter12 = 1; counter12 <= NodeLevel_12_count; counter12++)
                //{

                //    huo_sw2.WriteLine(string.Concat("12, ", counter12.ToString(), " , ", NodesAnalysis[counter12, 12, 0].ToString(), " , ", NodesAnalysis[counter12, 12, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 11"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter11 = 1; counter11 <= NodeLevel_11_count; counter11++)
                //{

                //    huo_sw2.WriteLine(string.Concat("11, ", counter11.ToString(), " , ", NodesAnalysis[counter11, 11, 0].ToString(), " , ", NodesAnalysis[counter11, 11, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 10"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter10 = 1; counter10 <= NodeLevel_10_count; counter10++)
                //{

                //    huo_sw2.WriteLine(string.Concat("10, ", counter10.ToString(), " , ", NodesAnalysis[counter10, 10, 0].ToString(), " , ", NodesAnalysis[counter10, 10, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 9"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter9 = 1; counter9 <= NodeLevel_9_count; counter9++)
                //{

                //    huo_sw2.WriteLine(string.Concat("9, ", counter9.ToString(), " , ", NodesAnalysis[counter9, 9, 0].ToString(), " , ", NodesAnalysis[counter9, 9, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 8"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter8 = 1; counter8 <= NodeLevel_8_count; counter8++)
                //{

                //    huo_sw2.WriteLine(string.Concat("8, ", counter8.ToString(), " , ", NodesAnalysis[counter8, 8, 0].ToString(), " , ", NodesAnalysis[counter8, 8, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 7"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter7 = 1; counter7 <= NodeLevel_7_count; counter7++)
                //{

                //    huo_sw2.WriteLine(string.Concat("7, ", counter7.ToString(), " , ", NodesAnalysis[counter7, 7, 0].ToString(), " , ", NodesAnalysis[counter7, 7, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 6"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter6 = 1; counter6 <= NodeLevel_6_count; counter6++)
                //{
   
                //    huo_sw2.WriteLine(string.Concat("6, ", counter6.ToString(), " , ", NodesAnalysis[counter6, 6, 0].ToString(), " , ", NodesAnalysis[counter6, 6, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 5"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter5 = 1; counter5 <= NodeLevel_5_count; counter5++)
                //{

                //    huo_sw2.WriteLine(string.Concat("5, ", counter5.ToString(), " , ", NodesAnalysis[counter5, 5, 0].ToString(), " , ", NodesAnalysis[counter5, 5, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 4"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter4 = 1; counter4 <= NodeLevel_4_count; counter4++)
                //{

                //    huo_sw2.WriteLine(string.Concat("4, ", counter4.ToString(), " , ", NodesAnalysis[counter4, 4, 0].ToString(), " , ", NodesAnalysis[counter4, 4, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 3"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter3 = 1; counter3 <= NodeLevel_3_count; counter3++)
                //{

                //    huo_sw2.WriteLine(string.Concat("3, ", counter3.ToString(), " , ", NodesAnalysis[counter3, 3, 0].ToString(), " , ", NodesAnalysis[counter3, 3, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 2"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter2 = 1; counter2 <= NodeLevel_2_count; counter2++)
                //{

                //    huo_sw2.WriteLine(string.Concat("2, ", counter2.ToString(), " , ", NodesAnalysis[counter2, 2, 0].ToString(), " , ", NodesAnalysis[counter2, 2, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 1"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter1 = 1; counter1 <= NodeLevel_1_count; counter1++)
                //{

                //    huo_sw2.WriteLine(string.Concat("1, ", counter1.ToString(), " , ", NodesAnalysis[counter1, 1, 0].ToString(), " , ", NodesAnalysis[counter1, 1, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 0"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter0 = 1; counter0 <= NodeLevel_0_count; counter0++)
                //{
                //    huo_sw2.WriteLine(string.Concat("Move: ", NodesAnalysis[counter0, 21, 0].ToString(), NodesAnalysis[counter0, 23, 0].ToString(), " -> ", NodesAnalysis[counter0, 22, 0].ToString(), NodesAnalysis[counter0, 24, 0].ToString()));
                //    huo_sw2.WriteLine(string.Concat("0, ", counter0.ToString(), " , ", NodesAnalysis[counter0, 0, 0].ToString(), " , ", NodesAnalysis[counter0, 0, 1].ToString()));
                //    huo_sw2.WriteLine("");
                //}

                //huo_sw2.Close();

                #endregion NodesLogBEFORE

                // ------------------------------------------------------
                // NodesAnalysis
                // ------------------------------------------------------
                // Nodes structure...
                // [ccc, xxx, 0]: Score of node No. ccc at level xxx
                // [ccc, xxx, 1]: Parent of node No. ccc at level xxx-1
                // ------------------------------------------------------

                int parentNodeAnalyzed = -999;

                parentNodeAnalyzed = -999;

                for (counter6 = 1; counter6 <= NodeLevel_6_count; counter6++)
                {
                    if (Int32.Parse(NodesAnalysis[counter6, 6, 1].ToString()) != parentNodeAnalyzed)
                    {
                        //parentNodeAnalyzedchanged = true;
                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis[counter6, 6, 1].ToString());
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter6, 6, 1].ToString()), 5, 0] = NodesAnalysis[counter6, 6, 0];
                    }

                    if (NodesAnalysis[counter6, 6, 0] >= NodesAnalysis[Int32.Parse(NodesAnalysis[counter6, 6, 1].ToString()), 5, 0])
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter6, 6, 1].ToString()), 5, 0] = NodesAnalysis[counter6, 6, 0];
                }

                parentNodeAnalyzed = -999;

                for (counter5 = 1; counter5 <= NodeLevel_5_count; counter5++)
                {
                    if (Int32.Parse(NodesAnalysis[counter5, 5, 1].ToString()) != parentNodeAnalyzed)
                    {
                        //parentNodeAnalyzedchanged = true;
                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis[counter5, 5, 1].ToString());
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter5, 5, 1].ToString()), 4, 0] = NodesAnalysis[counter5, 5, 0];
                    }

                    if (NodesAnalysis[counter5, 5, 0] <= NodesAnalysis[Int32.Parse(NodesAnalysis[counter5, 5, 1].ToString()), 4, 0])
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter5, 5, 1].ToString()), 4, 0] = NodesAnalysis[counter5, 5, 0];
                }

                parentNodeAnalyzed = -999;

                for (counter4 = 1; counter4 <= NodeLevel_4_count; counter4++)
                {
                    if (Int32.Parse(NodesAnalysis[counter4, 4, 1].ToString()) != parentNodeAnalyzed)
                    {
                        //parentNodeAnalyzedchanged = true;
                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis[counter4, 4, 1].ToString());
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter4, 4, 1].ToString()), 3, 0] = NodesAnalysis[counter4, 4, 0];
                    }

                    if (NodesAnalysis[counter4, 4, 0] >= NodesAnalysis[Int32.Parse(NodesAnalysis[counter4, 4, 1].ToString()), 3, 0])
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter4, 4, 1].ToString()), 3, 0] = NodesAnalysis[counter4, 4, 0];
                }

                parentNodeAnalyzed = -999;

                for (counter3 = 1; counter3 <= NodeLevel_3_count; counter3++)
                {
                    if (Int32.Parse(NodesAnalysis[counter3, 3, 1].ToString()) != parentNodeAnalyzed)
                    {
                        //parentNodeAnalyzedchanged = true;
                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis[counter3, 3, 1].ToString());
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter3, 3, 1].ToString()), 2, 0] = NodesAnalysis[counter3, 3, 0];
                    }

                    if (NodesAnalysis[counter3, 3, 0] <= NodesAnalysis[Int32.Parse(NodesAnalysis[counter3, 3, 1].ToString()), 2, 0])
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter3, 3, 1].ToString()), 2, 0] = NodesAnalysis[counter3, 3, 0];
                }

                parentNodeAnalyzed = -999;

                for (counter2 = 1; counter2 <= NodeLevel_2_count; counter2++)
                {
                    if (Int32.Parse(NodesAnalysis[counter2, 2, 1].ToString()) != parentNodeAnalyzed)
                    {
                        //parentNodeAnalyzedchanged = true;
                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis[counter2, 2, 1].ToString());
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter2, 2, 1].ToString()), 1, 0] = NodesAnalysis[counter2, 2, 0];
                    }

                    if (NodesAnalysis[counter2, 2, 0] >= NodesAnalysis[Int32.Parse(NodesAnalysis[counter2, 2, 1].ToString()), 1, 0])
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter2, 2, 1].ToString()), 1, 0] = NodesAnalysis[counter2, 2, 0];
                }

                // Now the node0 level is filled with the score data
                // this is line 1 in the shape at http://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Minimax.svg/300px-Minimax.svg.png

                parentNodeAnalyzed = -999;

                for (counter1 = 1; counter1 <= NodeLevel_1_count; counter1++)
                {
                    if (Int32.Parse(NodesAnalysis[counter1, 1, 1].ToString()) != parentNodeAnalyzed)
                    {
                        //parentNodeAnalyzedchanged = true;
                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis[counter1, 1, 1].ToString());
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter1, 1, 1].ToString()), 0, 0] = NodesAnalysis[counter1, 1, 0];
                    }

                    if (NodesAnalysis[counter1, 1, 0] <= NodesAnalysis[Int32.Parse(NodesAnalysis[counter1, 1, 1].ToString()), 0, 0])
                        NodesAnalysis[Int32.Parse(NodesAnalysis[counter1, 1, 1].ToString()), 0, 0] = NodesAnalysis[counter1, 1, 0];
                }

                // Choose the biggest score at the Node0 level
                // Check example at http://en.wikipedia.org/wiki/Minimax#Example_2
                // This is line 0 at the shape at http://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Minimax.svg/300px-Minimax.svg.png

                // Initialize the score with the first score and move found
                double temp_score = NodesAnalysis[1, 0, 0];
                Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis[1, 21, 0].ToString());
                Best_Move_StartingRank = Int32.Parse(NodesAnalysis[1, 23, 0].ToString());
                Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis[1, 22, 0].ToString());
                Best_Move_FinishingRank = Int32.Parse(NodesAnalysis[1, 24, 0].ToString());

                for (counter0 = 1; counter0 <= NodeLevel_0_count; counter0++)
                {
                    if (NodesAnalysis[counter0, 0, 0] > temp_score)
                    {
                        temp_score = NodesAnalysis[counter0, 0, 0];

                        Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis[counter0, 21, 0].ToString());
                        Best_Move_StartingRank = Int32.Parse(NodesAnalysis[counter0, 23, 0].ToString());
                        Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis[counter0, 22, 0].ToString());
                        Best_Move_FinishingRank = Int32.Parse(NodesAnalysis[counter0, 24, 0].ToString());
                    }
                }

                // Limit of total nodes: 1000000
                //MessageBox.Show(String.Concat("Total final positions analyzed: ", Nodes_Total_count.ToString()));
                HuoChess_main.FinalPositions = Nodes_Total_count.ToString();

                // Record log of nodes AFTER the MiniMax algorithm
                #region NodesLogAFTER

                //huo_sw2 = new StreamWriter("NodesAnalysis_after.txt", true);

                ////MessageBox.Show(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                //huo_sw2.WriteLine(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                ////MessageBox.Show(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw2.WriteLine(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw2.WriteLine("");

                //for (counter20 = 1; counter20 <= NodeLevel_20_count; counter20++)
                //{

                //    huo_sw2.WriteLine(string.Concat("20, ", counter20.ToString(), " , ", NodesAnalysis[counter20, 20, 0].ToString(), " , ", NodesAnalysis[counter20, 20, 1].ToString()));
                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 19"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter19 = 1; counter19 <= NodeLevel_19_count; counter19++)
                //{

                //    huo_sw2.WriteLine(string.Concat("19, ", counter19.ToString(), " , ", NodesAnalysis[counter19, 19, 0].ToString(), " , ", NodesAnalysis[counter19, 19, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 18"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter18 = 1; counter18 <= NodeLevel_18_count; counter18++)
                //{

                //    huo_sw2.WriteLine(string.Concat("18, ", counter18.ToString(), " , ", NodesAnalysis[counter18, 18, 0].ToString(), " , ", NodesAnalysis[counter18, 18, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 17"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter17 = 1; counter17 <= NodeLevel_17_count; counter17++)
                //{

                //    huo_sw2.WriteLine(string.Concat("17, ", counter17.ToString(), " , ", NodesAnalysis[counter17, 17, 0].ToString(), " , ", NodesAnalysis[counter17, 17, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 16"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter16 = 1; counter16 <= NodeLevel_16_count; counter16++)
                //{

                //    huo_sw2.WriteLine(string.Concat("16, ", counter16.ToString(), " , ", NodesAnalysis[counter16, 16, 0].ToString(), " , ", NodesAnalysis[counter16, 16, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 15"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter15 = 1; counter15 <= NodeLevel_15_count; counter15++)
                //{

                //    huo_sw2.WriteLine(string.Concat("15, ", counter15.ToString(), " , ", NodesAnalysis[counter15, 15, 0].ToString(), " , ", NodesAnalysis[counter15, 15, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 14"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter14 = 1; counter14 <= NodeLevel_14_count; counter14++)
                //{

                //    huo_sw2.WriteLine(string.Concat("14, ", counter14.ToString(), " , ", NodesAnalysis[counter14, 14, 0].ToString(), " , ", NodesAnalysis[counter14, 14, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 13"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter13 = 1; counter13 <= NodeLevel_13_count; counter13++)
                //{

                //    huo_sw2.WriteLine(string.Concat("13, ", counter13.ToString(), " , ", NodesAnalysis[counter13, 13, 0].ToString(), " , ", NodesAnalysis[counter13, 13, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 12"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter12 = 1; counter12 <= NodeLevel_12_count; counter12++)
                //{

                //    huo_sw2.WriteLine(string.Concat("12, ", counter12.ToString(), " , ", NodesAnalysis[counter12, 12, 0].ToString(), " , ", NodesAnalysis[counter12, 12, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 11"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter11 = 1; counter11 <= NodeLevel_11_count; counter11++)
                //{

                //    huo_sw2.WriteLine(string.Concat("11, ", counter11.ToString(), " , ", NodesAnalysis[counter11, 11, 0].ToString(), " , ", NodesAnalysis[counter11, 11, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 10"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter10 = 1; counter10 <= NodeLevel_10_count; counter10++)
                //{

                //    huo_sw2.WriteLine(string.Concat("10, ", counter10.ToString(), " , ", NodesAnalysis[counter10, 10, 0].ToString(), " , ", NodesAnalysis[counter10, 10, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 9"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter9 = 1; counter9 <= NodeLevel_9_count; counter9++)
                //{

                //    huo_sw2.WriteLine(string.Concat("9, ", counter9.ToString(), " , ", NodesAnalysis[counter9, 9, 0].ToString(), " , ", NodesAnalysis[counter9, 9, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 8"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");


                //for (counter8 = 1; counter8 <= NodeLevel_8_count; counter8++)
                //{

                //    huo_sw2.WriteLine(string.Concat("8, ", counter8.ToString(), " , ", NodesAnalysis[counter8, 8, 0].ToString(), " , ", NodesAnalysis[counter8, 8, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 7"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter7 = 1; counter7 <= NodeLevel_7_count; counter7++)
                //{

                //    huo_sw2.WriteLine(string.Concat("7, ", counter7.ToString(), " , ", NodesAnalysis[counter7, 7, 0].ToString(), " , ", NodesAnalysis[counter7, 7, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 6"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter6 = 1; counter6 <= NodeLevel_6_count; counter6++)
                //{

                //    huo_sw2.WriteLine(string.Concat("6, ", counter6.ToString(), " , ", NodesAnalysis[counter6, 6, 0].ToString(), " , ", NodesAnalysis[counter6, 6, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 5"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter5 = 1; counter5 <= NodeLevel_5_count; counter5++)
                //{

                //    huo_sw2.WriteLine(string.Concat("5, ", counter5.ToString(), " , ", NodesAnalysis[counter5, 5, 0].ToString(), " , ", NodesAnalysis[counter5, 5, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 4"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter4 = 1; counter4 <= NodeLevel_4_count; counter4++)
                //{

                //    huo_sw2.WriteLine(string.Concat("4, ", counter4.ToString(), " , ", NodesAnalysis[counter4, 4, 0].ToString(), " , ", NodesAnalysis[counter4, 4, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 3"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter3 = 1; counter3 <= NodeLevel_3_count; counter3++)
                //{

                //    huo_sw2.WriteLine(string.Concat("3, ", counter3.ToString(), " , ", NodesAnalysis[counter3, 3, 0].ToString(), " , ", NodesAnalysis[counter3, 3, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 2"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter2 = 1; counter2 <= NodeLevel_2_count; counter2++)
                //{

                //    huo_sw2.WriteLine(string.Concat("2, ", counter2.ToString(), " , ", NodesAnalysis[counter2, 2, 0].ToString(), " , ", NodesAnalysis[counter2, 2, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 1"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter1 = 1; counter1 <= NodeLevel_1_count; counter1++)
                //{

                //    huo_sw2.WriteLine(string.Concat("1, ", counter1.ToString(), " , ", NodesAnalysis[counter1, 1, 0].ToString(), " , ", NodesAnalysis[counter1, 1, 1].ToString()));

                //}

                //huo_sw2.WriteLine("");
                //huo_sw2.WriteLine(string.Concat("Node Level 0"));
                //huo_sw2.WriteLine(string.Concat("****************************"));
                //huo_sw2.WriteLine(string.Concat("Level, Count, Score, Parent"));
                //huo_sw2.WriteLine("");

                //for (counter0 = 1; counter0 <= NodeLevel_0_count; counter0++)
                //{
                //    huo_sw2.WriteLine(string.Concat("Move: ", NodesAnalysis[counter0, 21, 0].ToString(), NodesAnalysis[counter0, 23, 0].ToString(), " -> ", NodesAnalysis[counter0, 22, 0].ToString(), NodesAnalysis[counter0, 24, 0].ToString()));
                //    huo_sw2.WriteLine(string.Concat("0, ", counter0.ToString(), " , ", NodesAnalysis[counter0, 0, 0].ToString(), " , ", NodesAnalysis[counter0, 0, 1].ToString())); 
                //    huo_sw2.WriteLine("");
                //}

                //huo_sw2.Close();

                #endregion NodesLogAFTER


                /////////////////////////////////////////////////////////////////////////////////////////////////
                // REDRAW THE CHESSBOARD
                /////////////////////////////////////////////////////////////////////////////////////////////////

                // Erase the initial square

                for (iii = 0; iii <= 7; iii++)
                {
                    for (jjj = 0; jjj <= 7; jjj++)
                    {
                        Skakiera[(iii), (jjj)] = Skakiera_Move_0[(iii), (jjj)];
                    }
                }

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

                // position piece to the square of destination

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

                // if king is moved, no castling can occur
                if (MovingPiece.CompareTo("White King") == 0)
                    White_King_Moved = true;
                else if (MovingPiece.CompareTo("Black King") == 0)
                    Black_King_Moved = false;
                else if (MovingPiece.CompareTo("White Rook") == 0)
                {
                    if ((Best_Move_StartingColumnNumber == 1) && (Best_Move_StartingRank == 1))
                        White_Rook_a1_Moved = false;
                    else if ((Best_Move_StartingColumnNumber == 8) && (Best_Move_StartingRank == 1))
                        White_Rook_h1_Moved = false;
                }
                else if (MovingPiece.CompareTo("Black Rook") == 0)
                {
                    if ((Best_Move_StartingColumnNumber == 1) && (Best_Move_StartingRank == 8))
                        Black_Rook_a8_Moved = false;
                    else if ((Best_Move_StartingColumnNumber == 8) && (Best_Move_StartingRank == 8))
                        Black_Rook_h8_Moved = false;
                }

                // is there a pawn to promote?
                if (((MovingPiece.CompareTo("White Pawn") == 0) || (MovingPiece.CompareTo("Black Pawn") == 0)) && (m_WhoPlays.CompareTo("HY") == 0))
                {

                    if (Best_Move_FinishingRank == 8)
                    {
                        Skakiera[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = "White Queen";
                        Console.WriteLine("Κάνω βασίλισσα!");
                    }
                    else if (Best_Move_FinishingRank == 1)
                    {
                        Skakiera[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = "Black Queen";
                        Console.WriteLine("Κάνω βασίλισσα!");
                    }

                }


                //////////////////////////////////////////////////////////////////////
                // show HY move
                //////////////////////////////////////////////////////////////////////
                // COMPARISON CODE
                // UNCOMMENT TO SHOW THINKING TIME!
                // Uncomment to have the program record the start and stop time to a log .txt file
                //StreamWriter huo_sw2 = new StreamWriter("game.txt", true);
                //MessageBox.Show(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                //huo_sw2.WriteLine(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
                //MessageBox.Show(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw2.WriteLine(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));

                NextLine = String.Concat(HY_Starting_Column_Text, Best_Move_StartingRank.ToString(), " -> ", HY_Finishing_Column_Text, Best_Move_FinishingRank.ToString());
                Console.WriteLine(String.Concat("My move is: ", NextLine));
                //MessageBox.Show(number_of_moves_analysed.ToString());

                number_of_moves_analysed = 0;

                // Αν ο υπολογιστής παίζει με τα λευκά, τότε αυξάνεται τώρα το νούμερο της κίνησης.
                // If the computer plays with White, now is the time to increase the number of moves in the game.
                if (m_PlayerColor.CompareTo("Black") == 0)
                    Move = Move + 1;

                // now it is the other color's turn to play
                if (m_PlayerColor.CompareTo("Black") == 0)
                    m_WhichColorPlays = "Black";
                else if (m_PlayerColor.CompareTo("White") == 0)
                    m_WhichColorPlays = "White";

                // now it is the human's turn to play
                m_WhoPlays = "Human";

                //}
                //else
                //{
                //    Move_Analyzed = Move_Analyzed - 2;
                //    Who_Is_Analyzed = "HY";
                //    for (i = 0; i <= 7; i++)
                //    {
                //        for (j = 0; j <= 7; j++)
                //        {
                //            Skakiera_Thinking[i, j] = Skakiera_Move_0[i, j];
                //        }
                //    }
                //}
            }


            //v0.95
            public static double CountScore(string[,] CSSkakiera, int DangerWeight)
            {
                // white pieces: positive score
                // black pieces: negative score

                Current_Move_Score = 0;
                int addValueWhite = 0;
                int addValueBlack = 0;
                double Multiplier_White = 1;
                double Multiplier_Black = 1;

                // v0.96
                DangerWeight = 0;

                //if (m_PlayerColor.CompareTo("White") == 0)
                //{
                //    DangerWeight = 1;
                //}
                //else if (m_PlayerColor.CompareTo("Black") == 0)
                //{
                //    DangerWeight = 1;
                //}
                //if(Who_Is_Analyzed.CompareTo("HY")==0)
                //{
                //     DangerWeight = 1;
                //}

                //if (Destination_Piece_Value >= Moving_Piece_Value)
                //{
                //    if (m_PlayerColor.CompareTo("White") == 0)
                //        Current_Move_Score = Current_Move_Score - 500; // * (Destination_Piece_Value - Moving_Piece_Value);
                //    else if (m_PlayerColor.CompareTo("Black") == 0)
                //        Current_Move_Score = Current_Move_Score + 500; // * (Destination_Piece_Value - Moving_Piece_Value);
                //}

                // Make the computer care more for losing a piece
                if (m_PlayerColor.CompareTo("White") == 0)
                {
                    addValueWhite = 0;
                    addValueBlack = 0;
                    Multiplier_White = 1;
                    Multiplier_Black = 1;
                }
                else if (m_PlayerColor.CompareTo("Black") == 0)
                {
                    addValueWhite = 0;
                    addValueBlack = 0;
                    Multiplier_White = 1;
                    Multiplier_Black = 1;
                }

                if (possibility_to_eat_back == true)
                {
                    //MessageBox.Show("Enter possibility to eat back");
                    if (m_PlayerColor.CompareTo("White") == 0)
                        Current_Move_Score = Current_Move_Score - 1000 * DangerWeight;
                    else if (m_PlayerColor.CompareTo("Black") == 0)
                        Current_Move_Score = Current_Move_Score + 1000 * DangerWeight;
                }

                if (Danger_penalty == true)
                {
                    if (m_PlayerColor.CompareTo("White") == 0)
                        Current_Move_Score = Current_Move_Score + 2000 * DangerWeight;
                    else if (m_PlayerColor.CompareTo("Black") == 0)
                        Current_Move_Score = Current_Move_Score - 2000 * DangerWeight;
                }

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {
                        if (CSSkakiera[(i), (j)].CompareTo("White Pawn") == 0)
                            Current_Move_Score = Current_Move_Score + 1 * Multiplier_White + (10 * addValueWhite);
                        else if (CSSkakiera[(i), (j)].CompareTo("White Rook") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 5 * Multiplier_White + (10 * addValueWhite);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score - DangerWeight * CheckDanger_White(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White Knight") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 3 * Multiplier_White + (10 * addValueWhite);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score - DangerWeight * CheckDanger_White(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White Bishop") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 3 * Multiplier_White + (10 * addValueWhite);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score - DangerWeight * CheckDanger_White(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White Queen") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 9 * Multiplier_White + (10 * addValueWhite);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score - DangerWeight * CheckDanger_White(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("White King") == 0)
                            Current_Move_Score = Current_Move_Score + 15 * Multiplier_White + (10 * addValueWhite);
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Pawn") == 0)
                            Current_Move_Score = Current_Move_Score - 1 * Multiplier_Black + (10 * addValueBlack);
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Rook") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 5 * Multiplier_Black + (10 * addValueBlack);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score + DangerWeight * CheckDanger_Black(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Knight") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 3 * Multiplier_Black + (10 * addValueBlack);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score + DangerWeight * CheckDanger_Black(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Bishop") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 3 * Multiplier_Black + (10 * addValueBlack);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score + DangerWeight * CheckDanger_Black(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black Queen") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 9 * Multiplier_Black + (10 * addValueBlack);
                            // Decrease score based on the danger in which the piece is in
                            Current_Move_Score = Current_Move_Score + DangerWeight * CheckDanger_Black(CSSkakiera, i, j);
                        }
                        else if (CSSkakiera[(i), (j)].CompareTo("Black King") == 0)
                            Current_Move_Score = Current_Move_Score + 15 * Multiplier_Black + (10 * addValueBlack);

                    }
                }

                return Current_Move_Score;
            }


            public static double CheckDanger_White(string[,] CDSkakiera, int i, int j)
            {
                // i = Column
                // j = Line

                bool stopCheck = false;
                int addValue = 1;
                double decreaseScore = 0;

                // Danger from up-right
                do
                {
                    if ((i + addValue < 8) && (j + addValue < 8))
                    {
                        if ((CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Bishop") == 0)
                            || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from down-right
                do
                {
                    if ((i + addValue < 8) && (j - addValue > 0))
                    {
                        if ((CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Bishop") == 0)
                            || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from down-left
                do
                {
                    if ((i - addValue > 0) && (j - addValue > 0))
                    {
                        if ((CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Bishop") == 0)
                            || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from up-left
                do
                {
                    if ((i - addValue > 0) && (j + addValue < 8))
                    {
                        if ((CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Bishop") == 0)
                            || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from right
                do
                {
                    if (i + addValue < 8)
                    {
                        if ((CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Rook") == 0)
                            || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from left
                do
                {
                    if (i - addValue > 0)
                    {
                        if ((CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Rook") == 0)
                            || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from up
                do
                {
                    if (j + addValue < 8)
                    {
                        if ((CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Rook") == 0)
                            || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from down
                do
                {
                    if (j - addValue > 0)
                    {
                        if ((CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Rook") == 0)
                            || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Rook") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Knight") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Bishop") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Queen") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("White King") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from pawn
                if ((i - 1 > 0) && (j + 1 < 8))
                {
                    if ((CDSkakiera[(i - 1), (j + 1)].CompareTo("Black Pawn") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 1 < 8) && (j + 1 < 8))
                {
                    if ((CDSkakiera[(i + 1), (j + 1)].CompareTo("Black Pawn") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }

                ////////////////////////////////////////
                // Danger from Horse
                ////////////////////////////////////////
                if ((i + 2 < 8) && (j - 1 > 0))
                {
                    if ((CDSkakiera[(i + 2), (j - 1)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 2 < 8) && (j + 1 < 8))
                {
                    if ((CDSkakiera[(i + 2), (j + 1)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 1 < 8) && (j + 2 < 8))
                {
                    if ((CDSkakiera[(i + 1), (j + 2)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 1 > 0) && (j + 2 < 8))
                {
                    if ((CDSkakiera[(i - 1), (j + 2)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 2 > 0) && (j + 1 < 8))
                {
                    if ((CDSkakiera[(i - 2), (j + 1)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 2 > 0) && (j - 1 > 0))
                {
                    if ((CDSkakiera[(i - 2), (j - 1)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 1 > 0) && (j - 2 > 0))
                {
                    if ((CDSkakiera[(i - 1), (j - 2)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 1 < 8) && (j - 2 > 0))
                {
                    if ((CDSkakiera[(i + 1), (j - 2)].CompareTo("Black Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }


                return decreaseScore;
            }


            public static double CheckDanger_Black(string[,] CDSkakiera, int i, int j)
            {
                // i = Column
                // j = Line

                bool stopCheck = false;
                int addValue = 1;
                double decreaseScore = 0;

                // Danger from up-right
                do
                {
                    if ((i + addValue < 8) && (j + addValue < 8))
                    {
                        if ((CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Bishop") == 0)
                            || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i + addValue), (j + addValue)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from down-right
                do
                {
                    if ((i + addValue < 8) && (j - addValue > 0))
                    {
                        if ((CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Bishop") == 0)
                            || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i + addValue), (j - addValue)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from down-left
                do
                {
                    if ((i - addValue > 0) && (j - addValue > 0))
                    {
                        if ((CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Bishop") == 0)
                            || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i - addValue), (j - addValue)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from up-left
                do
                {
                    if ((i - addValue > 0) && (j + addValue < 8))
                    {
                        if ((CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Bishop") == 0)
                            || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i - addValue), (j + addValue)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from right
                do
                {
                    if (i + addValue < 8)
                    {
                        if ((CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Rook") == 0)
                            || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i + addValue), (j - 0)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from left
                do
                {
                    if (i - addValue > 0)
                    {
                        if ((CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Rook") == 0)
                            || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i - addValue), (j - 0)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from up
                do
                {
                    if (j + addValue < 8)
                    {
                        if ((CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Rook") == 0)
                            || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i + 0), (j + addValue)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from down
                do
                {
                    if (j - addValue > 0)
                    {
                        if ((CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Rook") == 0)
                            || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("White Queen") == 0))
                        {
                            decreaseScore = decreaseScore + 0.05;
                            stopCheck = true;
                        }
                        else if ((CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Rook") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Knight") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Bishop") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Queen") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black King") == 0)
                              || (CDSkakiera[(i + 0), (j - addValue)].CompareTo("Black Pawn") == 0))
                        {
                            stopCheck = true;
                        }
                    }
                    else
                    {
                        stopCheck = true;
                    }

                    addValue++;
                } while (stopCheck == false);

                stopCheck = false;

                // Danger from pawn
                if ((i - 1 > 0) && (j - 1 > 0))
                {
                    if ((CDSkakiera[(i - 1), (j - 1)].CompareTo("White Pawn") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 1 < 8) && (j - 1 > 0))
                {
                    if ((CDSkakiera[(i + 1), (j - 1)].CompareTo("White Pawn") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }

                ////////////////////////////////////////
                // Danger from Horse
                ////////////////////////////////////////
                if ((i + 2 < 8) && (j - 1 > 0))
                {
                    if ((CDSkakiera[(i + 2), (j - 1)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 2 < 8) && (j + 1 < 8))
                {
                    if ((CDSkakiera[(i + 2), (j + 1)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 1 < 8) && (j + 2 < 8))
                {
                    if ((CDSkakiera[(i + 1), (j + 2)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 1 > 0) && (j + 2 < 8))
                {
                    if ((CDSkakiera[(i - 1), (j + 2)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 2 > 0) && (j + 1 < 8))
                {
                    if ((CDSkakiera[(i - 2), (j + 1)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 2 > 0) && (j - 1 > 0))
                {
                    if ((CDSkakiera[(i - 2), (j - 1)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i - 1 > 0) && (j - 2 > 0))
                {
                    if ((CDSkakiera[(i - 1), (j - 2)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }
                if ((i + 1 < 8) && (j - 2 > 0))
                {
                    if ((CDSkakiera[(i + 1), (j - 2)].CompareTo("White Knight") == 0))
                    {
                        decreaseScore = decreaseScore + 0.05;
                    }
                }


                return decreaseScore;
            }




            // 2011: This function has changed
            public static void Enter_move()
            {
                // TODO: Add your control notification handler code here

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // show the move entered by the human player
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

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


                /////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////
                // record which piece is moving
                /////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////

                if (m_WhoPlays.CompareTo("HY") == 0)   // Αν είναι η σειρά του υπολογιστή να παίξει (και όχι του χρήστη), τότε άκυρο!!
                    MessageBox.Show("It's not your turn.");

                // Αν χρήστης έχει εισάγει μία έγκυρη στήλη (π.χ. "ε" ή "ζ") και πάει να κινήσει ένα κομμάτι του σωστού
                // χρώματος (π.χ. έναν λευκό ίππο και είναι πράγματι η σειρά των λευκών να παίξουν) τότε να προχωρήσει το
                // πρόγραμμα σε ό,τι κάνει.
                // Δεν είναι απαραίτητο να γίνει και έλεγχος του αν ο χρήστης έχει γράψει σωστή γραμμή (ήτοι ένα
                // νούμερο από το 1 έως το 8), διότι αυτό απαγορεύεται από τη δήλωση των μεταβλητών m_StartingRank και
                // m_FinishingRank (οι οποίες έχουν δηλωθεί σαν ακέραιοι που παίρνουν τιμές από 1 έως 8).

                else if (((m_WhoPlays.CompareTo("Human") == 0) || (m_PlayerColor.CompareTo("Self") == 0)) && (((m_WhichColorPlays.CompareTo("White") == 0) && ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Pawn") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White King") == 0))) || ((m_WhichColorPlays.CompareTo("Black") == 0) && ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Pawn") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black King") == 0)))))
                {

                    m_WrongColumn = false;
                    MovingPiece = "";

                    // is the king under check?
                    if (m_PlayerColor.CompareTo("White") == 0)
                        WhiteKingCheck = CheckForWhiteCheck(Skakiera);
                    else if (m_PlayerColor.CompareTo("Black") == 0)
                        BlackKingCheck = CheckForBlackCheck(Skakiera);

                    MovingPiece = Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];

                    // if he chooses to move a piece of different colour...
                    if (((m_PlayerColor.CompareTo("White") == 0) || (m_PlayerColor.CompareTo("Self") == 0) && ((Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White King") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Pawn") == 0))) || (((m_PlayerColor.CompareTo("Black") == 0) || (m_PlayerColor.CompareTo("Self") == 0)) && ((Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black King") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Pawn") == 0))))
                    {
                        Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                    }

                }
                else
                {
                    if (m_WhichColorPlays.CompareTo("White") == 0)
                        MessageBox.Show("White plays.");
                    else if (m_WhichColorPlays.CompareTo("Black") == 0)
                        MessageBox.Show("Black plays.");

                    m_WrongColumn = true;          // Η μεταβλητή αυτή τίθεται true για να βγει "μη ορθή" η κίνηση από
                    // τη συνάρτηση που ακολουθεί ακριβώς από κάτω και ελέγχει την "ορθότητα"
                    // της κίνησης.
                }

                // Check correctness of move entered
                m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                // check legality of move entered
                // (only if it is correct - so as to save time!)
                if (m_OrthotitaKinisis == true)
                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                else
                    m_NomimotitaKinisis = false;

                // check if the human's king is in check even after his move!
                // temporarily move the piece the user wants to move
                Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                ProsorinoKommati = Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                // check if king is still under check
                WhiteKingCheck = CheckForWhiteCheck(Skakiera);

                if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
                    m_NomimotitaKinisis = false;


                // check if black king is still under check
                BlackKingCheck = CheckForBlackCheck(Skakiera);

                if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
                    m_NomimotitaKinisis = false;

                // restore all pieces to the initial state
                Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = ProsorinoKommati;

                ///////////////////////////////////////////////////////////////////
                // CHECK IF THE HUMAN HAS ENTERED A CASTLING MOVE
                ///////////////////////////////////////////////////////////////////

                ///////////////////////////
                // WHITE CASTLING
                ///////////////////////////

                // small castling

                if ((m_PlayerColor.CompareTo("White") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 7) && (m_StartingRank == 1) && (m_FinishingRank == 1))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White King") == 0) && (Skakiera[(7), (0)].CompareTo("White Rook") == 0) && (Skakiera[(5), (0)].CompareTo("") == 0) && (Skakiera[(6), (0)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }

                // big castling

                if ((m_PlayerColor.CompareTo("White") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 3) && (m_StartingRank == 1) && (m_FinishingRank == 1))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("White King") == 0) && (Skakiera[(0), (0)].CompareTo("White Rook") == 0) && (Skakiera[(1), (0)].CompareTo("") == 0) && (Skakiera[(2), (0)].CompareTo("") == 0) && (Skakiera[(3), (0)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }


                ///////////////////////////
                // black castling
                ///////////////////////////

                // small castling

                if ((m_PlayerColor.CompareTo("Black") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 7) && (m_StartingRank == 8) && (m_FinishingRank == 8))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black King") == 0) && (Skakiera[(7), (7)].CompareTo("Black Rook") == 0) && (Skakiera[(5), (7)].CompareTo("") == 0) && (Skakiera[(6), (7)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }

                // big castling

                if ((m_PlayerColor.CompareTo("Black") == 0) && (m_StartingColumnNumber == 5) && (m_FinishingColumnNumber == 3) && (m_StartingRank == 8) && (m_FinishingRank == 8))
                {
                    if ((Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("Black King") == 0) && (Skakiera[(0), (7)].CompareTo("Black Rook") == 0) && (Skakiera[(1), (7)].CompareTo("") == 0) && (Skakiera[(2), (7)].CompareTo("") == 0) && (Skakiera[(3), (7)].CompareTo("") == 0))
                    {
                        m_OrthotitaKinisis = true;
                        m_NomimotitaKinisis = true;
                        Castling_Occured = true;
                    }
                }

                // redraw the chessboard
                if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                {

                    // game moves on by 1 move (this happens only when the player plays,
                    // so as to avoid increasing the game moves every half-move!)
                    if (m_PlayerColor.CompareTo("White") == 0)
                        Move = Move + 1;

                    // erase initial square
                    Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";

                    //2011
                    //if (Thinking_Depth == 3)
                    //    Thinking_Depth = Thinking_Depth_temp;

                    ////2011
                    //if (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("") == 1)
                    //{
                    //    Thinking_Depth_temp = Thinking_Depth;
                    //    Thinking_Depth = 3;
                    //}

                    // 2011 START
                    target_column = -1;
                    target_row = -1;
                    if (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("") == 1)
                    {
                        target_column = m_FinishingColumnNumber;
                        target_row = m_FinishingRank;
                        //MessageBox.Show("target column: ");
                        //MessageBox.Show(target_column.ToString());
                        //MessageBox.Show("target rank: ");
                        //MessageBox.Show(target_row.ToString());
                    }
                    // 2011 END

                    // go to destination square
                    Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                    //////////////////////////////////////////////////////////
                    // check for en passant
                    //////////////////////////////////////////////////////////
                    if (enpassant_occured == true)
                    {
                        if (m_PlayerColor.CompareTo("White") == 0)
                            Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 - 1)] = "";
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                            Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 + 1)] = "";
                    }


                    ////////////////////////////////////////////////////////////////////
                    // record possible sqaure when the next one playing will
                    // be able to perform en passant
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
                        // invalid value for enpassant move (= enpassant not possible in the next move)
                        enpassant_possible_target_rank = -9;
                        enpassant_possible_target_column = -9;
                    }

                    // check if castling occured (so as to move the rook next to the
                    // moving king)
                    if (Castling_Occured == true)
                    {

                        if (m_PlayerColor.CompareTo("White") == 0)
                        {
                            if (Skakiera[(6), (0)].CompareTo("White King") == 0)
                            {
                                Skakiera[(5), (0)] = "White Rook";
                                Skakiera[(7), (0)] = "";
                                //MessageBox.Show( "Ο λευκός κάνει μικρό ροκε." ); // Changed in version 0.5
                            }
                            else if (Skakiera[(2), (0)].CompareTo("White King") == 0)
                            {
                                Skakiera[(3), (0)] = "White Rook";
                                Skakiera[(0), (0)] = "";
                                //MessageBox.Show( "Ο λευκός κάνει μεγάλο ροκε." ); // Changed in version 0.5
                            }
                        }
                        else if (m_PlayerColor.CompareTo("Black") == 0)
                        {
                            if (Skakiera[(6), (7)].CompareTo("Black King") == 0)
                            {
                                Skakiera[(5), (7)] = "Black Rook";
                                Skakiera[(7), (7)] = "";
                                //MessageBox.Show( "Ο μαύρος κάνει μικρό ροκε." ); // Changed in version 0.5
                            }
                            else if (Skakiera[(2), (7)].CompareTo("Black King") == 0)
                            {
                                Skakiera[(3), (7)] = "Black Rook";
                                Skakiera[(0), (7)] = "";
                                //MessageBox.Show( "Ο μαύρος κάνει μεγάλο ροκε." ); // Changed in version 0.5
                            }
                        }

                        // restore the Castling_Occured variable to false, so as to avoid false castlings in the future!
                        Castling_Occured = false;

                    }


                    //////////////////////////////////////////////////////////
                    // does a pawn needs promotion?
                    //////////////////////////////////////////////////////////

                    PawnPromotion();

                    if ((m_PlayerColor.CompareTo("White") == 0) || (m_PlayerColor.CompareTo("Black") == 0))
                        m_WhoPlays = "HY";

                    // it is the other color's turn to play
                    if (m_WhichColorPlays.CompareTo("White") == 0)
                        m_WhichColorPlays = "Black";
                    else if (m_WhichColorPlays.CompareTo("Black") == 0)
                        m_WhichColorPlays = "White";

                    // restore variable values to initial values
                    m_StartingColumn = "";
                    m_FinishingColumn = "";
                    m_StartingRank = 1;
                    m_FinishingRank = 1;




                    /////////////////////////////////////////////
                    // CHECK MESSAGE
                    /////////////////////////////////////////////

                    WhiteKingCheck = CheckForWhiteCheck(Skakiera);
                    BlackKingCheck = CheckForBlackCheck(Skakiera);

                    if ((WhiteKingCheck == true) || (BlackKingCheck == true))
                    {
                        MessageBox.Show("CHECK!");
                    }


                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // if it is the turn of the HY to play, then call the respective
                    // HY Thought function
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (m_WhoPlays.CompareTo("HY") == 0)
                    {
                        Move_Analyzed = 0;
                        Stop_Analyzing = false;
                        First_Call = true;
                        Best_Move_Found = false;
                        Who_Is_Analyzed = "HY";
                        //2012: ComputerMove(Skakiera);
                    }

                }

                else
                {
                    MessageBox.Show("INVALID MOVE!");
                    Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                    MovingPiece = "";
                    m_WhoPlays = "Human";
                }


            }


            public static void PawnPromotion()
            {
                for (i = 0; i <= 7; i++)
                {

                    if (Skakiera[(i), (0)].CompareTo("Black Pawn") == 0)
                    {

                        if (m_WhoPlays.CompareTo("Human") == 0)
                        {
                            ///////////////////////////
                            // promote pawn
                            ///////////////////////////

                            MessageBox.Show("");

                            MessageBox.Show("Promote your pawn to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop");
                            Console.Write("CHOOSE (1-4): ");
                            choise_of_user = Int32.Parse(Console.ReadLine());

                            switch (choise_of_user)
                            {
                                case 1:
                                    Skakiera[(i), (0)] = "Black Queen";
                                    break;

                                case 2:
                                    Skakiera[(i), (0)] = "Black Rook";
                                    break;

                                case 3:
                                    Skakiera[(i), (0)] = "Black Knight";
                                    break;

                                case 4:
                                    Skakiera[(i), (0)] = "Black Bishop";
                                    break;
                            };
                        }

                    }

                    if (Skakiera[(i), (7)].CompareTo("White Pawn") == 0)
                    {
                        if (m_WhoPlays.CompareTo("Human") == 0)
                        {
                            ///////////////////////////
                            // promote pawn
                            ///////////////////////////

                            MessageBox.Show("");

                            MessageBox.Show("Promote your pawn to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop");
                            Console.Write("CHOOSE (1-4): ");
                            choise_of_user = Int32.Parse(Console.ReadLine());

                            switch (choise_of_user)
                            {
                                case 1:
                                    Skakiera[(i), (0)] = "White Queen";
                                    break;

                                case 2:
                                    Skakiera[(i), (0)] = "White Rook";
                                    break;

                                case 3:
                                    Skakiera[(i), (0)] = "White Knight";
                                    break;

                                case 4:
                                    Skakiera[(i), (0)] = "White Bishop";
                                    break;
                            };
                        }

                    }

                }
            }


            // FUNCTION TO CHECK THE LEGALITY (='Nomimotita' in Greek) OF A MOVE
            // (i.e. if between the initial and the destination square lies another
            // piece, then the move is not legal).
            // The ElegxosNomimotitas "checkForDanger" function differs from the normal function in that it does not make all the validations
            // (since it is used to check for "Dangerous" squares in the chessboard and not to actually judge the correctness of an actual move)
            // Changed in version 0.961!
            public static bool ElegxosNomimotitas(string[,] ENSkakiera, int checkForDanger, int startRank, int startColumn, int finishRank, int finishColumn, String MovingPiece_2)
            {
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

                // if a piece of the same colout is in the destination square...
                if (checkForDanger == 0)
                {
                    if ((MovingPiece_2.CompareTo("White King") == 0) || (MovingPiece_2.CompareTo("White Queen") == 0) || (MovingPiece_2.CompareTo("White Rook") == 0) || (MovingPiece_2.CompareTo("White Knight") == 0) || (MovingPiece_2.CompareTo("White Bishop") == 0) || (MovingPiece_2.CompareTo("White Pawn") == 0))
                    {
                        if ((ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White King") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Queen") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Rook") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Knight") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Bishop") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("White Pawn") == 0))
                        {
                            Nomimotita = false;
                        }
                    }
                    else if ((MovingPiece_2.CompareTo("Black King") == 0) || (MovingPiece_2.CompareTo("Black Queen") == 0) || (MovingPiece_2.CompareTo("Black Rook") == 0) || (MovingPiece_2.CompareTo("Black Knight") == 0) || (MovingPiece_2.CompareTo("Black Bishop") == 0) || (MovingPiece_2.CompareTo("Black Pawn") == 0))
                    {
                        if ((ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black King") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Queen") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Rook") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Knight") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Bishop") == 0) || (ENSkakiera[((finishColumn - 1)), ((finishRank - 1))].CompareTo("Black Pawn") == 0))
                            Nomimotita = false;
                    }
                }

                if (MovingPiece_2.CompareTo("White King") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        /////////////////////////
                        // white king
                        /////////////////////////
                        // is the king threatened in the destination square?
                        // temporarily move king
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "";
                        ProsorinoKommati_KingCheck = ENSkakiera[(finishColumn - 1), (finishRank - 1)];
                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = "White King";

                        WhiteKingCheck = CheckForWhiteCheck(ENSkakiera);

                        if (WhiteKingCheck == true)
                            Nomimotita = false;

                        // restore pieces
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "White King";
                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = ProsorinoKommati_KingCheck;
                    }
                }
                else if (MovingPiece_2.CompareTo("Black King") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        ///////////////////////////
                        // black king
                        ///////////////////////////
                        // is the black king threatened in the destination square?
                        // temporarily move king
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "";
                        ProsorinoKommati_KingCheck = ENSkakiera[(finishColumn - 1), (finishRank - 1)];
                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = "Black King";

                        BlackKingCheck = CheckForBlackCheck(ENSkakiera);

                        if (BlackKingCheck == true)
                            Nomimotita = false;

                        // restore pieces
                        ENSkakiera[(startColumn - 1), (startRank - 1)] = "Black King";
                        ENSkakiera[(finishColumn - 1), (finishRank - 1)] = ProsorinoKommati_KingCheck;
                    }
                }
                else if (MovingPiece_2.CompareTo("White Pawn") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        //Console.WriteLine("checking white pawn");

                        /////////////////////
                        // white pawn
                        /////////////////////

                        // move forward

                        if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                        {
                            if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1)
                            {
                                //Console.WriteLine("pawn Nomimotita false");
                                Nomimotita = false;
                            }
                        }

                        // move forward for 2 squares
                        else if ((finishRank == (startRank + 2)) && (finishColumn == startColumn))
                        {
                            if (startRank == 2)
                            {
                                if ((ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1) || (ENSkakiera[(finishColumn - 1), (finishRank - 1 - 1)].CompareTo("") == 1))
                                    Nomimotita = false;
                            }
                        }

                        // eat forward to the right

                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn + 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    Nomimotita = false;
                            }
                        }

                        // eat forward to the left

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
                else if (MovingPiece_2.CompareTo("Black Pawn") == 0)
                {
                    if (checkForDanger == 0)
                    {
                        /////////////////////
                        // black pawn
                        /////////////////////

                        // move forward

                        if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                        {
                            if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1)
                                Nomimotita = false;
                        }

                        // move forward for 2 squares
                        else if ((finishRank == (startRank - 2)) && (finishColumn == startColumn))
                        {
                            if (startRank == 7)
                            {
                                if ((ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1) || (ENSkakiera[(finishColumn - 1), (finishRank + 1 - 1)].CompareTo("") == 1))
                                    Nomimotita = false;
                            }
                        }

                        // eat forward to the right

                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn + 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (ENSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    Nomimotita = false;
                            }
                        }

                        // eat forward to the left

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
                else if ((MovingPiece_2.CompareTo("White Rook") == 0) || (MovingPiece_2.CompareTo("White Queen") == 0) || (MovingPiece_2.CompareTo("White Bishop") == 0) || (MovingPiece_2.CompareTo("Black Rook") == 0) || (MovingPiece_2.CompareTo("Black Queen") == 0) || (MovingPiece_2.CompareTo("Black Bishop") == 0))
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

                        // if a piece exists between the initial and the destination square,
                        // then the move is illegal!
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

                // Check if HY moves the king next to the king of the opponent
                // (this case is not controlled in the lines above)
                #region CheckKindNextToKing
                if (MovingPiece_2.CompareTo("White King") == 0)
                {
                    if (((m_FinishingColumnNumber - 1 + 1) >= 0) && ((m_FinishingColumnNumber - 1 + 1) <= 7) && ((m_FinishingRank - 1 + 1) >= 0) && ((m_FinishingRank - 1 + 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 + 1), (m_FinishingRank - 1 + 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1) >= 0) && ((m_FinishingColumnNumber - 1) <= 7) && ((m_FinishingRank - 1 + 1) >= 0) && ((m_FinishingRank - 1 + 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 + 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 - 1) >= 0) && ((m_FinishingColumnNumber - 1 - 1) <= 7) && ((m_FinishingRank - 1 + 1) >= 0) && ((m_FinishingRank - 1 + 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 - 1), (m_FinishingRank - 1 + 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 - 1) >= 0) && ((m_FinishingColumnNumber - 1 - 1) <= 7) && ((m_FinishingRank - 1) >= 0) && ((m_FinishingRank - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 - 1), (m_FinishingRank - 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 - 1) >= 0) && ((m_FinishingColumnNumber - 1 - 1) <= 7) && ((m_FinishingRank - 1 - 1) >= 0) && ((m_FinishingRank - 1 - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 - 1), (m_FinishingRank - 1 - 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1) >= 0) && ((m_FinishingColumnNumber - 1) <= 7) && ((m_FinishingRank - 1 - 1) >= 0) && ((m_FinishingRank - 1 - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 - 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 + 1) >= 0) && ((m_FinishingColumnNumber - 1 + 1) <= 7) && ((m_FinishingRank - 1 - 1) >= 0) && ((m_FinishingRank - 1 - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 + 1), (m_FinishingRank - 1 - 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 + 1) >= 0) && ((m_FinishingColumnNumber - 1 + 1) <= 7) && ((m_FinishingRank - 1) >= 0) && ((m_FinishingRank - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 + 1), (m_FinishingRank - 1)].CompareTo("Black King") == 0)
                            m_NomimotitaKinisis = false;
                    }
                }


                if (MovingPiece_2.CompareTo("Black King") == 0)
                {
                    if (((m_FinishingColumnNumber - 1 + 1) >= 0) && ((m_FinishingColumnNumber - 1 + 1) <= 7) && ((m_FinishingRank - 1 + 1) >= 0) && ((m_FinishingRank - 1 + 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 + 1), (m_FinishingRank - 1 + 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1) >= 0) && ((m_FinishingColumnNumber - 1) <= 7) && ((m_FinishingRank - 1 + 1) >= 0) && ((m_FinishingRank - 1 + 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 + 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 - 1) >= 0) && ((m_FinishingColumnNumber - 1 - 1) <= 7) && ((m_FinishingRank - 1 + 1) >= 0) && ((m_FinishingRank - 1 + 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 - 1), (m_FinishingRank - 1 + 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 - 1) >= 0) && ((m_FinishingColumnNumber - 1 - 1) <= 7) && ((m_FinishingRank - 1) >= 0) && ((m_FinishingRank - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 - 1), (m_FinishingRank - 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 - 1) >= 0) && ((m_FinishingColumnNumber - 1 - 1) <= 7) && ((m_FinishingRank - 1 - 1) >= 0) && ((m_FinishingRank - 1 - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 - 1), (m_FinishingRank - 1 - 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1) >= 0) && ((m_FinishingColumnNumber - 1) <= 7) && ((m_FinishingRank - 1 - 1) >= 0) && ((m_FinishingRank - 1 - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 - 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 + 1) >= 0) && ((m_FinishingColumnNumber - 1 + 1) <= 7) && ((m_FinishingRank - 1 - 1) >= 0) && ((m_FinishingRank - 1 - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 + 1), (m_FinishingRank - 1 - 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }

                    if (((m_FinishingColumnNumber - 1 + 1) >= 0) && ((m_FinishingColumnNumber - 1 + 1) <= 7) && ((m_FinishingRank - 1) >= 0) && ((m_FinishingRank - 1) <= 7))
                    {
                        if (ENSkakiera[(m_FinishingColumnNumber - 1 + 1), (m_FinishingRank - 1)].CompareTo("White King") == 0)
                            m_NomimotitaKinisis = false;
                    }
                }
                #endregion CheckKindNextToKing

                return Nomimotita;
            }


            // FUNCTION TO CHECK THE CORRECTNESS (='Orthotita' in Greek) OF THE MOVE
            // (i.e. a Bishop can only move in diagonals, rooks in lines and columns etc)
            // The ElegxosOrthotitas "checkForDanger" mode differs from the ElegxosOrthotitas normal mode in that it does not make all the validations
            // (since it is used to check for "Dangerous" squares in the chessboard and not to actually judge the correctness of an actual move)
            public static bool ElegxosOrthotitas(string[,] EOSkakiera, int checkForDanger, int startRank, int startColumn, int finishRank, int finishColumn, String MovingPiece_2)
            {
                // TODO: Add your control notification handler code here

                // If called for checking dangerous squares, put a virtual piece in the destination square so as to pass the validation checks
                // if (checkForDanger == 1)
                // Don't care about checking for the existence of a piece in the destination square


                bool Orthotita;
                Orthotita = false;
                enpassant_occured = false;

                //Console.WriteLine("ElegxosOrthotitas");
                //Console.WriteLine(MovingPiece_2);

                if ((m_WhoPlays.CompareTo("Human") == 0) && (m_WrongColumn == false) && (MovingPiece_2.CompareTo("") == 1))    // Αν ο χρήστης έχει γράψει μία έγκυρη στήλη και έχει
                {                                                         // επιλέξει να κινήσει ένα κομμάτι (και δεν έχει επι-
                    // λέξει να κινήσει ένα "κενό" τετράγωνο) και είναι η σειρά του να παίξει, τότε να γί-
                    // νει έλεγχος της ορθότητας της κίνησης. 

                    //Console.WriteLine("1");

                    // ROOK

                    if ((MovingPiece_2.CompareTo("White Rook") == 0) || (MovingPiece_2.CompareTo("Black Rook") == 0))
                    {
                        if ((finishColumn != startColumn) && (finishRank == startRank))       // Κίνηση σε στήλη
                            Orthotita = true;
                        else if ((finishRank != startRank) && (finishColumn == startColumn))  // Κίνηση σε γραμμή
                            Orthotita = true;
                    }

                    // horse (with knight...)

                    if ((MovingPiece_2.CompareTo("White Knight") == 0) || (MovingPiece_2.CompareTo("Black Knight") == 0))
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

                    // bishop

                    if ((MovingPiece_2.CompareTo("White Bishop") == 0) || (MovingPiece_2.CompareTo("Black Bishop") == 0))
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

                    // queen

                    if ((MovingPiece_2.CompareTo("White Queen") == 0) || (MovingPiece_2.CompareTo("Black Queen") == 0))
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

                    // king

                    if ((MovingPiece_2.CompareTo("White King") == 0) || (MovingPiece_2.CompareTo("Black King") == 0))
                    {
                        // move in rows and columns

                        if ((finishColumn == (startColumn + 1)) && (finishRank == startRank))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == startRank))
                            Orthotita = true;
                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                            Orthotita = true;
                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                            Orthotita = true;

                        // move in diagonals

                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank + 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank - 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank - 1)))
                            Orthotita = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank + 1)))
                            Orthotita = true;

                    }

                    // white pawn

                    if (MovingPiece_2.CompareTo("White Pawn") == 0)
                    {
                        // move forward
                        //Console.WriteLine("2");

                        if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                            Orthotita = true;

                        // move forward for 2 squares
                        else if ((finishRank == (startRank + 2)) && (finishColumn == startColumn) && (startRank == 2))
                            Orthotita = true;

                        else if ((finishRank == (startRank + 1)) && ((finishColumn == (startColumn - 1)) || (finishColumn == (startColumn + 1))))
                        {
                            if (checkForDanger == 0)
                            {
                                // eat forward to the left
                                if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn - 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("Black Queen") == 0)))
                                    Orthotita = true;

                                // eat forward to the right
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


                    // black pawn

                    if (MovingPiece_2.CompareTo("Black Pawn") == 0)
                    {
                        // move forward

                        if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                            Orthotita = true;

                        // move forward for 2 squares
                        else if ((finishRank == (startRank - 2)) && (finishColumn == startColumn) && (startRank == 7))
                            Orthotita = true;

                        else if ((finishRank == (startRank - 1)) && ((finishColumn == (startColumn + 1)) || (finishColumn == (startColumn - 1))))
                        {
                            if (checkForDanger == 0)
                            {
                                // eat forward to the left
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Queen") == 0)))
                                    Orthotita = true;

                                // eat forward to the right
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn - 1)) && ((EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Pawn") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Rook") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Knight") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Bishop") == 0) || (EOSkakiera[(finishColumn - 1), (finishRank - 1)].CompareTo("White Queen") == 0)))
                                    Orthotita = true;
                            }
                            else if (checkForDanger == 1)
                            {
                                // eat forward to the left
                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)))
                                    Orthotita = true;

                                // eat forward to the right
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

                m_WhichColorPlays = "White";
            }

            public static void Analyze_Move_1_HumanMove(string[,] Skakiera_Human_Thinking_2)
            {
                #region WriteLog
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("HMT2 -- Entered HumanMove_template 2");
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT2 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");
                #endregion WriteLog

                // Scan chessboard . Find a piece of the human player . Move to all possible squares.
                // Check corr1ectness and legality of move . If all OK then measure the move's score.
                // Do the best move and handle over to the ComputerMove function to continue analysis in the next move (deeper depth...)
                int skakos1;
                int trelos5;
                String MovingPiece1;
                String ProsorinoKommati1;
                int m_StartingColumnNumber1;
                int m_FinishingColumnNumber1; 
                int m_StartingRank1;
                int m_FinishingRank1;         

                // Checl all possible moves
                for (skakos1 = 0; skakos1 <= 7; skakos1++)
                {
                    for (trelos5 = 0; trelos5 <= 7; trelos5++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("Human") == 0) && ((((Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("Black King") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("Black Queen") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("Black Rook") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("Black Knight") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("Black Bishop") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("White King") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("White Queen") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("White Rook") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("White Knight") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("White Bishop") == 0) || (Skakiera_Human_Thinking_2[(skakos1), (trelos5)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    MovingPiece = Skakiera_Human_Thinking_2[(skakos1), (trelos5)];
                                    m_StartingColumnNumber = skakos1 + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = trelos5 + 1;
                                    m_FinishingRank = r + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece1             = MovingPiece;
                                    m_StartingColumnNumber1  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber1 = m_FinishingColumnNumber;
                                    m_StartingRank1          = m_StartingRank;
                                    m_FinishingRank1         = m_FinishingRank;
                                    ProsorinoKommati1 = Skakiera_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)];

                                    // Check the move
                                    number_of_moves_analysed++;

                                    // Necessary values for variables for the ElegxosOrthotitas (check move corr1ectness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    MovingPiece = Skakiera_Human_Thinking_2[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];
                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Human_Thinking_2, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Human_Thinking_2, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    // Restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // Do the move
                                        ProsorinoKommati = Skakiera_Human_Thinking_2[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Skakiera_Human_Thinking_2[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Skakiera_Human_Thinking_2[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                        // Measure score AFTER the move
                                        if (Move_Analyzed == 1)
                                        {
                                            NodeLevel_1_count++;
                                            Temp_Score_Move_1_human = CountScore(Skakiera_Human_Thinking_2, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 3)
                                        {
                                            NodeLevel_3_count++;
                                            Temp_Score_Move_3_human = CountScore(Skakiera_Human_Thinking_2, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 5)
                                        {
                                            NodeLevel_5_count++;
                                            Temp_Score_Move_5_human = CountScore(Skakiera_Human_Thinking_2, humanDangerParameter);
                                        }

                                        if (Move_Analyzed < Thinking_Depth)
                                        {
                                            // Call ComputerMove for the HY throught process to continue
                                            Move_Analyzed = Move_Analyzed + 1;

                                            Who_Is_Analyzed = "HY";

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After[(i), (j)] = Skakiera_Human_Thinking_2[(i), (j)];
                                                }
                                            }

                                            if (Move_Analyzed == 2)
                                                Analyze_Move_2_ComputerMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 4)
                                                Analyze_Move_4_ComputerMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 6)
                                                Analyze_Move_6_ComputerMove(Skakiera_Move_After);
                                        }

                                        // Undo the move
                                        Skakiera_Human_Thinking_2[(m_StartingColumnNumber1 - 1), (m_StartingRank1 - 1)] = MovingPiece1;
                                        Skakiera_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)] = ProsorinoKommati1;
                                    }

                                } // For 4
                            } // For 3

                        }// IF

                    } // For 2
                } // For 1

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "HY";
            }

            public static void Analyze_Move_3_HumanMove(string[,] Skakiera_Human_Thinking_4)
            {
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("HMT4 -- Entered HumanMove_template 4");
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT4 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");

                // scan chessboard . find a piece of the human player . move to all
                // possible squares . check correctness and legality of move . if
                // all ok then measure the move's score . do the best move and handle
                // over to the ComputerMove function to continue analysis in the next
                // move (deeper depth...)
                int ww2;
                int rr2;
                int www2;
                int rrr2;
                String MovingPiece3;
                String ProsorinoKommati3;
                int m_StartingColumnNumber3;
                int m_FinishingColumnNumber3;
                int m_StartingRank3;
                int m_FinishingRank3;   

                // Check all possible moves
                for (www2 = 0; www2 <= 7; www2++)
                {
                    for (rrr2 = 0; rrr2 <= 7; rrr2++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("Human") == 0) && ((((Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("Black King") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("Black Queen") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("Black Rook") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("Black Knight") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("Black Bishop") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("White King") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("White Queen") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("White Rook") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("White Knight") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("White Bishop") == 0) || (Skakiera_Human_Thinking_4[(www2), (rrr2)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            for (ww2 = 0; ww2 <= 7; ww2++)
                            {
                                for (rr2 = 0; rr2 <= 7; rr2++)
                                {
                                    MovingPiece = Skakiera_Human_Thinking_4[(www2), (rrr2)];
                                    m_StartingColumnNumber = www2 + 1;
                                    m_FinishingColumnNumber = ww2 + 1;
                                    m_StartingRank = rrr2 + 1;
                                    m_FinishingRank = rr2 + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece3             = MovingPiece;
                                    m_StartingColumnNumber3  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber3 = m_FinishingColumnNumber;
                                    m_StartingRank3          = m_StartingRank;
                                    m_FinishingRank3         = m_FinishingRank;
                                    ProsorinoKommati3 = Skakiera_Human_Thinking_4[(m_FinishingColumnNumber3 - 1), (m_FinishingRank3 - 1)];

                                    // Check the move
                                    number_of_moves_analysed++;

                                    // Necessary values for variables for the ElegxosOrthotitas (check move correctness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    MovingPiece = Skakiera_Human_Thinking_4[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];

                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Human_Thinking_4, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Human_Thinking_4, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                                    // restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    // if all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // do the move
                                        ProsorinoKommati = Skakiera_Human_Thinking_4[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Skakiera_Human_Thinking_4[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Skakiera_Human_Thinking_4[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                        // Measure score AFTER the move
                                        //Temp_Score_Human_before_0 = CountScore(Skakiera_Human_Thinking_4);
                                        if (Move_Analyzed == 1)
                                        {
                                            NodeLevel_1_count++;
                                            Temp_Score_Move_1_human = CountScore(Skakiera_Human_Thinking_4, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 3)
                                        {
                                            NodeLevel_3_count++;
                                            Temp_Score_Move_3_human = CountScore(Skakiera_Human_Thinking_4, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 5)
                                        {
                                            NodeLevel_5_count++;
                                            Temp_Score_Move_5_human = CountScore(Skakiera_Human_Thinking_4, humanDangerParameter);
                                        }

                                        ///////////////////////////////////////////////////////////////////
                                        // Is the king still under check? If yes, then we have mate!
                                        ///////////////////////////////////////////////////////////////////
                                        Possible_mate = false;

                                        if (Human_is_in_check == true)
                                        {
                                            WhiteKingCheck = CheckForWhiteCheck(Skakiera_Human_Thinking_4);
                                            if ((m_PlayerColor.CompareTo("White") == 0) && (WhiteKingCheck == true))
                                                Possible_mate = true;

                                            BlackKingCheck = CheckForBlackCheck(Skakiera_Human_Thinking_4);
                                            if ((m_PlayerColor.CompareTo("Black") == 0) && (BlackKingCheck == true))
                                                Possible_mate = true;
                                        }

                                        if (Move_Analyzed < Thinking_Depth)
                                        {
                                            // Call ComputerMove for the HY throught process to continue
                                            Move_Analyzed = Move_Analyzed + 1;

                                            Who_Is_Analyzed = "HY";

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After[(i), (j)] = Skakiera_Human_Thinking_4[(i), (j)];
                                                }
                                            }

                                            if (Move_Analyzed == 2)
                                                Analyze_Move_2_ComputerMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 4)
                                                Analyze_Move_4_ComputerMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 6)
                                                Analyze_Move_6_ComputerMove(Skakiera_Move_After);
                                        }

                                        // Undo the move
                                        Skakiera_Human_Thinking_4[(m_StartingColumnNumber3 - 1), (m_StartingRank3 - 1)] = MovingPiece3;
                                        Skakiera_Human_Thinking_4[(m_FinishingColumnNumber3 - 1), (m_FinishingRank3 - 1)] = ProsorinoKommati3;
                                    }
                                }
                            }
                        }

                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "HY";
            }

            public static void Analyze_Move_5_HumanMove(string[,] Skakiera_Human_Thinking_6)
            {
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("HMT6 -- Entered HumanMove_template 6");
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("HMT6 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");

                // scan chessboard . find a piece of the human player . move to all
                // possible squares . check correctness and legality of move . if
                // all ok then measure the move's score . do the best move and handle
                // over to the ComputerMove function to continue analysis in the next
                // move (deeper depth...)
                int ww5;
                int rr5;
                int www5;
                int rrr5;
                String MovingPiece5;
                String ProsorinoKommati5;
                int m_StartingColumnNumber5;
                int m_FinishingColumnNumber5;
                int m_StartingRank5;
                int m_FinishingRank5;   

                // Check all possible moves
                for (www5 = 0; www5 <= 7; www5++)
                {
                    for (rrr5 = 0; rrr5 <= 7; rrr5++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("Human") == 0) && ((((Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("Black King") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("Black Queen") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("Black Rook") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("Black Knight") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("Black Bishop") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("White King") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("White Queen") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("White Rook") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("White Knight") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("White Bishop") == 0) || (Skakiera_Human_Thinking_6[(www5), (rrr5)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {
                            for (ww5 = 0; ww5 <= 7; ww5++)
                            {
                                for (rr5 = 0; rr5 <= 7; rr5++)
                                {
                                    MovingPiece = Skakiera_Human_Thinking_6[(www5), (rrr5)];
                                    m_StartingColumnNumber = www5 + 1;
                                    m_FinishingColumnNumber = ww5 + 1;
                                    m_StartingRank = rrr5 + 1;
                                    m_FinishingRank = rr5 + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece5             = MovingPiece;
                                    m_StartingColumnNumber5  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber5 = m_FinishingColumnNumber;
                                    m_StartingRank5          = m_StartingRank;
                                    m_FinishingRank5         = m_FinishingRank;
                                    ProsorinoKommati5 = Skakiera_Human_Thinking_6[(m_FinishingColumnNumber5 - 1), (m_FinishingRank5 - 1)];

                                    // Check the move
                                    number_of_moves_analysed++;

                                    // Necessary values for variables for the ElegxosOrthotitas (check move correctness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    MovingPiece = Skakiera_Human_Thinking_6[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];

                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Human_Thinking_6, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Human_Thinking_6, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                                    // restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // Do the move
                                        ProsorinoKommati = Skakiera_Human_Thinking_6[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Skakiera_Human_Thinking_6[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Skakiera_Human_Thinking_6[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                                        // Measure score AFTER the move
                                        if (Move_Analyzed == 1)
                                        {
                                            NodeLevel_1_count++;
                                            //Human_Stupid_Move_2_penalty = false;
                                            // Chessboard score before the human plays (i.e. before depth 2 computer move)
                                            Temp_Score_Move_1_human = CountScore(Skakiera_Human_Thinking_6, humanDangerParameter);
                                            //Temp_Score_Move_1_human = CountScore(Skakiera_Human_Thinking_6);
                                        }
                                        if (Move_Analyzed == 3)
                                        {
                                            NodeLevel_3_count++;
                                            //Human_Stupid_Move_4_penalty = false;
                                            Temp_Score_Move_3_human = CountScore(Skakiera_Human_Thinking_6, humanDangerParameter);
                                            //Temp_Score_Move_3_human = CountScore(Skakiera_Human_Thinking_6);
                                        }
                                        if (Move_Analyzed == 5)
                                        {
                                            NodeLevel_5_count++;
                                            //Human_Stupid_Move_6_penalty = false;
                                            Temp_Score_Move_5_human = CountScore(Skakiera_Human_Thinking_6, humanDangerParameter);
                                            //Temp_Score_Move_5_human = CountScore(Skakiera_Human_Thinking_6);
                                        }


                                        ///////////////////////////////////////////////////////////////////
                                        // is the king still under check? if yes, then we have mate!
                                        ///////////////////////////////////////////////////////////////////
                                        Possible_mate = false;

                                        if (Human_is_in_check == true)
                                        {
                                            WhiteKingCheck = CheckForWhiteCheck(Skakiera_Human_Thinking_6);
                                            if ((m_PlayerColor.CompareTo("White") == 0) && (WhiteKingCheck == true))
                                                Possible_mate = true;

                                            BlackKingCheck = CheckForBlackCheck(Skakiera_Human_Thinking_6);
                                            if ((m_PlayerColor.CompareTo("Black") == 0) && (BlackKingCheck == true))
                                                Possible_mate = true;
                                        }

                                        if (Move_Analyzed < Thinking_Depth)
                                        {
                                            // Call ComputerMove for the HY throught process to continue
                                            Move_Analyzed = Move_Analyzed + 1;

                                            Who_Is_Analyzed = "HY";

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After[(i), (j)] = Skakiera_Human_Thinking_6[(i), (j)];
                                                }
                                            }

                                            if (Move_Analyzed == 2)
                                                Analyze_Move_2_ComputerMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 4)
                                                Analyze_Move_4_ComputerMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 6)
                                                Analyze_Move_6_ComputerMove(Skakiera_Move_After);
                                        }

                                        // Undo the move
                                        Skakiera_Human_Thinking_6[(m_StartingColumnNumber5 - 1), (m_StartingRank5 - 1)] = MovingPiece5;
                                        Skakiera_Human_Thinking_6[(m_FinishingColumnNumber5 - 1), (m_FinishingRank5 - 1)] = ProsorinoKommati5;
                                    }
                                }
                            }
                        }

                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "HY";
            }

            // HY Thought Process:
            // Depth 0 (Move_Analyzed = 0): First half move analyzed - First HY half move analyzed
            // Depth 1 (Move_Analyzed = 1): Second half move analyzed - First human half move analyzed
            // Depth 2 (Move_Analyzed = 2): Thirf half move analyzed - Second HY half move analyzed
            // et cetera...

            // Functions for analyzing the HY Thought in depth...
            // ...of the 3rd half move (Analyze_Move_2_ComputerMove)
            // ...of the 5th half move (Analyze_Move_4_ComputerMove)
            // ...of the 7th half move (Analyze_Move_6_ComputerMove)

            public static void Analyze_Move_2_ComputerMove(string[,] Skakiera_Thinking_HY_2)
            {
                #region WriteLog
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("CMT2 -- Entered ComputerMove_template 2");
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT2 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");
                #endregion WriteLog

                // Δήλωση μεταβλητών που χρησιμοποιούνται στο βρόγχο "for" (δεν μπορεί να χρησιμοποιηθούν οι μεταβλητές i και j διότι αυτές οι
                // μεταβλητές είναι καθολικές και δημιουργείται πρόβλημα κατά την επιστροφή στην ComputerMove από την CheckMove)

                int iii2;
                int jjj2;
                String MovingPiece2;
                String ProsorinoKommati2;
                int m_StartingColumnNumber2;
                int m_FinishingColumnNumber2;
                int m_StartingRank2;
                int m_FinishingRank2;   

                // Σκανάρισμα της σκακιέρας: Όταν εντοπίζεται κάποιο κομμάτι του υπολογιστή,
                // θα υπολογίζονται ΟΛΕΣ οι πιθανές κινήσεις του προς κάθε κατεύθυνση, ακόμα
                // και αυτές που δεν μπορεί να κάνει το κομμάτι. Στη συνέχεια, με τη βοήθεια
                // των συναρτήσεων ElegxosNomimotitas και ElegxosOrthotitas θα ελέγχεται το
                // αν η κίνηση είναι ορθή και νόμιμη. Αν είναι, η εν λόγω κίνηση θα γίνεται
                // προσωρινά στη σκακιέρα και θα καταγράφεται το σκορ της νέας θέσης που
                // προέκυψε

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


                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    MovingPiece = Skakiera_Thinking_HY_2[(iii2), (jjj2)];
                                    m_StartingColumnNumber = iii2 + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = jjj2 + 1;
                                    m_FinishingRank = r + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece2             = MovingPiece;
                                    m_StartingColumnNumber2  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber2 = m_FinishingColumnNumber;
                                    m_StartingRank2          = m_StartingRank;
                                    m_FinishingRank2         = m_FinishingRank;
                                    ProsorinoKommati2 = Skakiera_Thinking_HY_2[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)];

                                    // Έλεγχος της κίνησης

                                    // Validity and legality of the move has been checked in CheckMove
                                    // CheckMove(Skakiera_Thinking_HY_2);

                                    // Check validity and legality
                                    // Necessary values for variables for the ElegxosOrthotitas (check move corr1ectness) and
                                    // ElegxosNomimotitas (check move legality) function to...function properly.
                                    m_WhoPlays = "Human";
                                    m_WrongColumn = false;
                                    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera_Thinking_HY_2, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera_Thinking_HY_2, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    // restore normal value of m_WhoPlays
                                    m_WhoPlays = "HY";

                                    number_of_moves_analysed++;

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // huo_sw1.WriteLine(string.Concat("Human move 1: Found a legal move!"));

                                        // Do the move
                                        ProsorinoKommati = Skakiera_Thinking_HY_2[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Skakiera_Thinking_HY_2[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Skakiera_Thinking_HY_2[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                        // Check the score after the computer move.
                                        if (Move_Analyzed == 0)
                                        {
                                            NodeLevel_0_count++;
                                            Temp_Score_Move_0 = CountScore(Skakiera_Thinking_HY_2, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 2)
                                        {
                                            NodeLevel_2_count++;
                                            Temp_Score_Move_2 = CountScore(Skakiera_Thinking_HY_2, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 4)
                                        {
                                            NodeLevel_4_count++;
                                            Temp_Score_Move_4 = CountScore(Skakiera_Thinking_HY_2, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 6)
                                        {
                                            NodeLevel_6_count++;
                                            Temp_Score_Move_6 = CountScore(Skakiera_Thinking_HY_2, humanDangerParameter);
                                        }

                                        if (Move_Analyzed < Thinking_Depth)
                                        {
                                            Move_Analyzed = Move_Analyzed + 1;

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                                }
                                            }

                                            Who_Is_Analyzed = "Human";
                                            First_Call_Human_Thought = true;

                                            // Check human move
                                            if (Move_Analyzed == 1)
                                                Analyze_Move_1_HumanMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 3)
                                                Analyze_Move_3_HumanMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 5)
                                                Analyze_Move_5_HumanMove(Skakiera_Move_After);
                                        }


                                        if (Move_Analyzed == Thinking_Depth)
                                        {
                                            // [MiniMax algorithm - skakos]
                                            // Record the node in the Nodes Analysis array (to use with MiniMax algorithm) skakos

                                            NodesAnalysis[NodeLevel_0_count, 0, 0] = Temp_Score_Move_0;
                                            NodesAnalysis[NodeLevel_1_count, 1, 0] = Temp_Score_Move_1_human;
                                            NodesAnalysis[NodeLevel_2_count, 2, 0] = Temp_Score_Move_2;
                                            NodesAnalysis[NodeLevel_3_count, 3, 0] = Temp_Score_Move_3_human;
                                            NodesAnalysis[NodeLevel_4_count, 4, 0] = Temp_Score_Move_4;
                                            NodesAnalysis[NodeLevel_5_count, 5, 0] = Temp_Score_Move_5_human;
                                            NodesAnalysis[NodeLevel_6_count, 6, 0] = Temp_Score_Move_6;

                                            // Store the parents (number of the node of the upper level)
                                            NodesAnalysis[NodeLevel_0_count, 0, 1] = 0;
                                            NodesAnalysis[NodeLevel_1_count, 1, 1] = NodeLevel_0_count;
                                            NodesAnalysis[NodeLevel_2_count, 2, 1] = NodeLevel_1_count;
                                            NodesAnalysis[NodeLevel_3_count, 3, 1] = NodeLevel_2_count;
                                            NodesAnalysis[NodeLevel_4_count, 4, 1] = NodeLevel_3_count;
                                            NodesAnalysis[NodeLevel_5_count, 5, 1] = NodeLevel_4_count;
                                            NodesAnalysis[NodeLevel_6_count, 6, 1] = NodeLevel_5_count;

                                            if (Danger_penalty == true)
                                            {
                                                //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] - 2000000000;
                                                //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] + 2000000000;
                                            }

                                            if (go_for_it == true)
                                            {
                                                //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] + 2000000000;
                                                //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] - 2000000000;
                                            }

                                            Nodes_Total_count++;

                                            // Safety valve in case we reach the end of the table capacity
                                            // This is a limit for the memory. Will have to do something about it!
                                            if (Nodes_Total_count > 1000000)
                                            {
                                                Console.WriteLine("Limit of memory in NodesAnalysis array reached!");
                                                Nodes_Total_count = 1000000;
                                            }
                                        }

                                        // Undo the move
                                        Skakiera_Thinking_HY_2[(m_StartingColumnNumber2 - 1), (m_StartingRank2 - 1)] = MovingPiece2;
                                        Skakiera_Thinking_HY_2[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)] = ProsorinoKommati2;
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
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("CMT4 -- Entered ComputerMove_template 4");
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT4 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");

                // Δήλωση μεταβλητών που χρησιμοποιούνται στο βρόγχο "for"
                // (δεν μπορεί να χρησιμοποιηθούν οι μεταβλητές i και j διότι αυτές οι
                // μεταβλητές είναι καθολικές και δημιουργείται πρόβλημα κατά την
                // επιστροφή στην ComputerMove από την CheckMove

                int iii4;
                int jjj4;
                String MovingPiece4;
                String ProsorinoKommati4;
                int m_StartingColumnNumber4;
                int m_FinishingColumnNumber4;
                int m_StartingRank4;
                int m_FinishingRank4;   

                // Σκανάρισμα της σκακιέρας: Όταν εντοπίζεται κάποιο κομμάτι του υπολογιστή,
                // θα υπολογίζονται ΟΛΕΣ οι πιθανές κινήσεις του προς κάθε κατεύθυνση, ακόμα
                // και αυτές που δεν μπορεί να κάνει το κομμάτι. Στη συνέχεια, με τη βοήθεια
                // των συναρτήσεων ElegxosNomimotitas και ElegxosOrthotitas θα ελέγχεται το
                // αν η κίνηση είναι ορθή και νόμιμη. Αν είναι, η εν λόγω κίνηση θα γίνεται
                // προσωρινά στη σκακιέρα και θα καταγράφεται το σκορ της νέας θέσης που
                // προέκυψε

                // ΣΗΜΕΙΩΣΗ: Σε όλες τις στήλες και τις οριζόντιους προστίθεται η μονάδα (+1)
                // διότι πρέπει να μετατραπούν από το "σύστημα" μέτρησης "0-7" (που χρησιμο-
                // ποιείται στο παρακάτω "for i…next" αλλά και στο συμβολισμό του πίνακα
                // Skakiera) στο σύστημα μέτρησης "1-8" το οποίο χρησιμοποιείται στις
                // μεταβλητές Starting/Finishing_Column/Rank σε όλο το υπόλοιπο πρόγραμμα.

                for (iii4 = 0; iii4 <= 7; iii4++)
                {
                    for (jjj4 = 0; jjj4 <= 7; jjj4++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("White King") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("White Queen") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("White Rook") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("White Knight") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("Black King") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking_HY_4[(iii4), (jjj4)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {


                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    MovingPiece = Skakiera_Thinking_HY_4[(iii4), (jjj4)];
                                    m_StartingColumnNumber = iii4 + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = jjj4 + 1;
                                    m_FinishingRank = r + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece4             = MovingPiece;
                                    m_StartingColumnNumber4  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber4 = m_FinishingColumnNumber;
                                    m_StartingRank4          = m_StartingRank;
                                    m_FinishingRank4         = m_FinishingRank;
                                    ProsorinoKommati4 = Skakiera_Thinking_HY_4[(m_FinishingColumnNumber4 - 1), (m_FinishingRank4 - 1)];

                                    // Έλεγχος της κίνησης
                                    // Validity and legality of the move has been checked in CheckMove
                                    CheckMove(Skakiera_Thinking_HY_4);

                                    number_of_moves_analysed++;

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // huo_sw1.WriteLine(string.Concat("Human move 1: Found a legal move!"));

                                        // Do the move
                                        ProsorinoKommati = Skakiera_Thinking_HY_4[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Skakiera_Thinking_HY_4[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Skakiera_Thinking_HY_4[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                        // Check the score after the computer move.
                                        if (Move_Analyzed == 0)
                                        {
                                            NodeLevel_0_count++;
                                            Temp_Score_Move_0 = CountScore(Skakiera_Thinking_HY_4, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 2)
                                        {
                                            NodeLevel_2_count++;
                                            Temp_Score_Move_2 = CountScore(Skakiera_Thinking_HY_4, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 4)
                                        {
                                            NodeLevel_4_count++;
                                            Temp_Score_Move_4 = CountScore(Skakiera_Thinking_HY_4, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 6)
                                        {
                                            NodeLevel_6_count++;
                                            Temp_Score_Move_6 = CountScore(Skakiera_Thinking_HY_4, humanDangerParameter);
                                        }

                                        // Change 2014-08 - Start
                                        if (Move_Analyzed < Thinking_Depth)
                                        // Change 2014-08 - End
                                        {
                                            Move_Analyzed = Move_Analyzed + 1;

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                                }
                                            }

                                            Who_Is_Analyzed = "Human";
                                            First_Call_Human_Thought = true;

                                            // Check human move (to find the best possible answer of the human
                                            // to the move currently analyzed by the HY Thought process)
                                            if (Move_Analyzed == 1)
                                                Analyze_Move_1_HumanMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 3)
                                                Analyze_Move_3_HumanMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 5)
                                                Analyze_Move_5_HumanMove(Skakiera_Move_After);
                                        }

                                        if (Move_Analyzed == Thinking_Depth)
                                        {
                                            // [MiniMax algorithm - skakos]
                                            // Record the node in the Nodes Analysis array (to use with MiniMax algorithm) skakos
                                            NodesAnalysis[NodeLevel_0_count, 0, 0] = Temp_Score_Move_0;
                                            NodesAnalysis[NodeLevel_1_count, 1, 0] = Temp_Score_Move_1_human;
                                            NodesAnalysis[NodeLevel_2_count, 2, 0] = Temp_Score_Move_2;
                                            NodesAnalysis[NodeLevel_3_count, 3, 0] = Temp_Score_Move_3_human;
                                            NodesAnalysis[NodeLevel_4_count, 4, 0] = Temp_Score_Move_4;
                                            NodesAnalysis[NodeLevel_5_count, 5, 0] = Temp_Score_Move_5_human;
                                            NodesAnalysis[NodeLevel_6_count, 6, 0] = Temp_Score_Move_6;

                                            // Store the parents (number of the node of the upper level)
                                            NodesAnalysis[NodeLevel_0_count, 0, 1] = 0;
                                            NodesAnalysis[NodeLevel_1_count, 1, 1] = NodeLevel_0_count;
                                            NodesAnalysis[NodeLevel_2_count, 2, 1] = NodeLevel_1_count;
                                            NodesAnalysis[NodeLevel_3_count, 3, 1] = NodeLevel_2_count;
                                            NodesAnalysis[NodeLevel_4_count, 4, 1] = NodeLevel_3_count;
                                            NodesAnalysis[NodeLevel_5_count, 5, 1] = NodeLevel_4_count;
                                            NodesAnalysis[NodeLevel_6_count, 6, 1] = NodeLevel_5_count;

                                            if (Danger_penalty == true)
                                            {
                                                //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] - 2000000000;
                                                //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] + 2000000000;
                                            }

                                            if (go_for_it == true)
                                            {
                                                //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] + 2000000000;
                                                //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] - 2000000000;
                                            }

                                            Nodes_Total_count++;

                                            // Safety valve in case we reach the end of the table capacity
                                            // This is a limit for the memory. Will have to do something about it!
                                            if (Nodes_Total_count > 1000000)
                                            {
                                                Console.WriteLine("Limit of memory in NodesAnalysis array reached!");
                                                Nodes_Total_count = 1000000;
                                            }
                                        }

                                        // Undo the move
                                        Skakiera_Thinking_HY_4[(m_StartingColumnNumber4 - 1), (m_StartingRank4 - 1)] = MovingPiece4;
                                        Skakiera_Thinking_HY_4[(m_FinishingColumnNumber4 - 1), (m_FinishingRank4 - 1)] = ProsorinoKommati4;
                                    }

                                }
                            }

                        }


                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "Human";
            }

            public static void Analyze_Move_6_ComputerMove(string[,] Skakiera_Thinking_HY_6)
            {
                //huo_sw1.WriteLine("");
                //huo_sw1.WriteLine("CMT6 -- Entered ComputerMove_template 6");
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Depth analyzed: ", Move_Analyzed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of moves analyzed: ", number_of_moves_analysed.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Move analyzed: ", m_StartingColumnNumber_HY.ToString(), m_StartingRank_HY.ToString(), " -> ", m_FinishingColumnNumber_HY.ToString(), m_FinishingRank_HY.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 0: ", NodeLevel_0_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 1: ", NodeLevel_1_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 2: ", NodeLevel_2_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 3: ", NodeLevel_3_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 4: ", NodeLevel_4_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 5: ", NodeLevel_5_count.ToString()));
                //huo_sw1.WriteLine(string.Concat("CMT6 -- Number of Nodes 6: ", NodeLevel_6_count.ToString()));
                //huo_sw1.WriteLine("");

                // Δήλωση μεταβλητών που χρησιμοποιούνται στο βρόγχο "for"
                // (δεν μπορεί να χρησιμοποιηθούν οι μεταβλητές i και j διότι αυτές οι
                // μεταβλητές είναι καθολικές και δημιουργείται πρόβλημα κατά την
                // επιστροφή στην ComputerMove από την CheckMove

                int iii6;
                int jjj6;
                String MovingPiece6;
                String ProsorinoKommati6;
                int m_StartingColumnNumber6;
                int m_FinishingColumnNumber6;
                int m_StartingRank6;
                int m_FinishingRank6;   

                // Σκανάρισμα της σκακιέρας: Όταν εντοπίζεται κάποιο κομμάτι του υπολογιστή,
                // θα υπολογίζονται ΟΛΕΣ οι πιθανές κινήσεις του προς κάθε κατεύθυνση, ακόμα
                // και αυτές που δεν μπορεί να κάνει το κομμάτι. Στη συνέχεια, με τη βοήθεια
                // των συναρτήσεων ElegxosNomimotitas και ElegxosOrthotitas θα ελέγχεται το
                // αν η κίνηση είναι ορθή και νόμιμη. Αν είναι, η εν λόγω κίνηση θα γίνεται
                // προσωρινά στη σκακιέρα και θα καταγράφεται το σκορ της νέας θέσης που
                // προέκυψε

                // ΣΗΜΕΙΩΣΗ: Σε όλες τις στήλες και τις οριζόντιους προστίθεται η μονάδα (+1)
                // διότι πρέπει να μετατραπούν από το "σύστημα" μέτρησης "0-7" (που χρησιμο-
                // ποιείται στο παρακάτω "for i…next" αλλά και στο συμβολισμό του πίνακα
                // Skakiera) στο σύστημα μέτρησης "1-8" το οποίο χρησιμοποιείται στις
                // μεταβλητές Starting/Finishing_Column/Rank σε όλο το υπόλοιπο πρόγραμμα.

                for (iii6 = 0; iii6 <= 7; iii6++)
                {
                    for (jjj6 = 0; jjj6 <= 7; jjj6++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("White King") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("White Queen") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("White Rook") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("White Knight") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("White Bishop") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("White Pawn") == 0)) && (m_PlayerColor.CompareTo("Black") == 0)) || (((Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("Black King") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("Black Queen") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("Black Rook") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("Black Knight") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("Black Bishop") == 0) || (Skakiera_Thinking_HY_6[(iii6), (jjj6)].CompareTo("Black Pawn") == 0)) && (m_PlayerColor.CompareTo("White") == 0)))))
                        {


                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    MovingPiece = Skakiera_Thinking_HY_6[(iii6), (jjj6)];
                                    m_StartingColumnNumber = iii6 + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = jjj6 + 1;
                                    m_FinishingRank = r + 1;

                                    // Store temporary move data in local variables, so as to use them in the Undo of the move
                                    // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                                    // changed by next functions as well, so using them leads to problems)
                                    MovingPiece6             = MovingPiece;
                                    m_StartingColumnNumber6  = m_StartingColumnNumber;
                                    m_FinishingColumnNumber6 = m_FinishingColumnNumber;
                                    m_StartingRank6          = m_StartingRank;
                                    m_FinishingRank6         = m_FinishingRank;
                                    ProsorinoKommati6 = Skakiera_Thinking_HY_6[(m_FinishingColumnNumber6 - 1), (m_FinishingRank6 - 1)];

                                    // Έλεγχος της κίνησης
                                    // Validity and legality of the move has been checked in CheckMove
                                    CheckMove(Skakiera_Thinking_HY_6);

                                    number_of_moves_analysed++;

                                    // If all ok, then do the move and measure it
                                    if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                                    {
                                        // huo_sw1.WriteLine(string.Concat("Human move 1: Found a legal move!"));

                                        // Do the move
                                        ProsorinoKommati = Skakiera_Thinking_HY_6[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Skakiera_Thinking_HY_6[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Skakiera_Thinking_HY_6[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                        // Check the score after the computer move.
                                        if (Move_Analyzed == 0)
                                        {
                                            NodeLevel_0_count++;
                                            Temp_Score_Move_0 = CountScore(Skakiera_Thinking_HY_6, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 2)
                                        {
                                            NodeLevel_2_count++;
                                            Temp_Score_Move_2 = CountScore(Skakiera_Thinking_HY_6, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 4)
                                        {
                                            NodeLevel_4_count++;
                                            Temp_Score_Move_4 = CountScore(Skakiera_Thinking_HY_6, humanDangerParameter);
                                        }
                                        if (Move_Analyzed == 6)
                                        {
                                            NodeLevel_6_count++;
                                            Temp_Score_Move_6 = CountScore(Skakiera_Thinking_HY_6, humanDangerParameter);
                                        }

                                        if (Move_Analyzed < Thinking_Depth)
                                        {
                                            Move_Analyzed = Move_Analyzed + 1;

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Skakiera_Move_After[(i), (j)] = Skakiera_Thinking[(i), (j)];
                                                }
                                            }

                                            Who_Is_Analyzed = "Human";
                                            First_Call_Human_Thought = true;

                                            // Check human move
                                            if (Move_Analyzed == 1)
                                                Analyze_Move_1_HumanMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 3)
                                                Analyze_Move_3_HumanMove(Skakiera_Move_After);
                                            else if (Move_Analyzed == 5)
                                                Analyze_Move_5_HumanMove(Skakiera_Move_After);
                                        }

                                        if (Move_Analyzed == Thinking_Depth)
                                        {
                                            // [MiniMax algorithm - skakos]
                                            // Record the node in the Nodes Analysis array (to use with MiniMax algorithm) skakos
                                            NodesAnalysis[NodeLevel_0_count, 0, 0] = Temp_Score_Move_0;
                                            NodesAnalysis[NodeLevel_1_count, 1, 0] = Temp_Score_Move_1_human;
                                            NodesAnalysis[NodeLevel_2_count, 2, 0] = Temp_Score_Move_2;
                                            NodesAnalysis[NodeLevel_3_count, 3, 0] = Temp_Score_Move_3_human;
                                            NodesAnalysis[NodeLevel_4_count, 4, 0] = Temp_Score_Move_4;
                                            NodesAnalysis[NodeLevel_5_count, 5, 0] = Temp_Score_Move_5_human;
                                            NodesAnalysis[NodeLevel_6_count, 6, 0] = Temp_Score_Move_6;

                                            // Store the parents (number of the node of the upper level)
                                            NodesAnalysis[NodeLevel_0_count, 0, 1] = 0;
                                            NodesAnalysis[NodeLevel_1_count, 1, 1] = NodeLevel_0_count;
                                            NodesAnalysis[NodeLevel_2_count, 2, 1] = NodeLevel_1_count;
                                            NodesAnalysis[NodeLevel_3_count, 3, 1] = NodeLevel_2_count;
                                            NodesAnalysis[NodeLevel_4_count, 4, 1] = NodeLevel_3_count;
                                            NodesAnalysis[NodeLevel_5_count, 5, 1] = NodeLevel_4_count;
                                            NodesAnalysis[NodeLevel_6_count, 6, 1] = NodeLevel_5_count;

                                            if (Danger_penalty == true)
                                            {
                                                //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] - 2000000000;
                                                //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] + 2000000000;
                                            }

                                            if (go_for_it == true)
                                            {
                                                //NodesAnalysis[NodeLevel_0_count, 0, 0] = NodesAnalysis[NodeLevel_0_count, 0, 0] + 2000000000;
                                                //NodesAnalysis[NodeLevel_1_count, 1, 0] = NodesAnalysis[NodeLevel_1_count, 1, 0] - 2000000000;
                                            }

                                            Nodes_Total_count++;

                                            // Safety valve in case we reach the end of the table capacity
                                            // This is a limit for the memory. Will have to do something about it!
                                            if (Nodes_Total_count > 1000000)
                                            {
                                                Console.WriteLine("Limit of memory in NodesAnalysis array reached!");
                                                Nodes_Total_count = 1000000;
                                            }
                                        }

                                        // Undo the move
                                        Skakiera_Thinking_HY_6[(m_StartingColumnNumber6 - 1), (m_StartingRank6 - 1)] = MovingPiece6;
                                        Skakiera_Thinking_HY_6[(m_FinishingColumnNumber6 - 1), (m_FinishingRank6 - 1)] = ProsorinoKommati6;
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
                String MovingPiece_Attack;
                int m_StartingRank_Attack;
                int m_StartingColumnNumber_Attack;
                int m_FinishingRank_Attack;
                int m_FinishingColumnNumber_Attack;

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

                            // find squares where the human opponent can hit
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
                                        Attackers_coordinates_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = m_StartingColumnNumber_Attack - 1;
                                        Attackers_coordinates_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = m_StartingRank_Attack - 1;

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

            public static void FindDefenders(string[,] SkakieraDefenders)
            {
                String MovingPiece_Attack;
                int m_StartingRank_Attack;
                int m_StartingColumnNumber_Attack;
                int m_FinishingRank_Attack;
                int m_FinishingColumnNumber_Attack;

                // Find squares that are also 'protected' by a piece of the HY.
                // If protected, then the square is not really dangerous

                // Changed in version 0.5
                // Initialize all variables used to find exceptions in the non-dangerous squares.
                // Exceptions definition: If human can hit a square and the computer defends it with its pieces, then the
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

                                        // Record the coordinates of the defender.
                                        // If the defender found is the only one, then that defender cannot move to that square,
                                        // since then the square would be again dangerous (since its only defender would have moved into it!)
                                        // If more than one defenders is found, then no exceptions exist.
                                        if (Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] == 1)
                                        {
                                            Exception_defender_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = (m_StartingColumnNumber_Attack - 1);
                                            Exception_defender_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = (m_StartingRank_Attack - 1);

                                            // DEBUGGING
                                            //if (((m_FinishingColumnNumber_Attack - 1) == 2) && ((m_FinishingRank_Attack - 1) == 4))
                                            //{
                                            //    MessageBox.Show("hOU");
                                            //    MessageBox.Show(String.Concat("Move found: ", m_StartingColumnNumber_Attack.ToString(), m_StartingRank_Attack.ToString(), "->", m_FinishingColumnNumber_Attack.ToString(), m_FinishingRank_Attack.ToString()));
                                            //    MessageBox.Show(String.Concat("Exception column: ",Exception_defender_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)]));
                                            //    MessageBox.Show(String.Concat("Exception rank: ",Exception_defender_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)]));
                                            //    MessageBox.Show(String.Concat("Exception column: ",(iii3).ToString()));
                                            //    MessageBox.Show(String.Concat("Exception rank: ",(jjj3).ToString() ));
                                            //}
                                            // PLAYING
                                        }
                                        if (Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] > 1)
                                        {
                                            Exception_defender_column[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = -99;
                                            Exception_defender_rank[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = -99;
                                        }

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
            Form1.HuoChess_main.Starting_position();
            RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);

            if (Form1.HuoChess_main.m_WhoPlays.CompareTo("HY") == 0)
            {
                label2.Text = "Thinking...";
                label3.Text = "";
            }

            Form1.HuoChess_main.Main_Console();
            RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            label2.Text = "I played! Now it is your turn!";
            Application.DoEvents();
        }

        private void radioButton_White_Click(object sender, EventArgs e)
        {
            Form1.HuoChess_main.m_PlayerColor = "White";
            Form1.HuoChess_main.m_WhoPlays = "Human";
        }

        private void radioButton_Black_Click(object sender, EventArgs e)
        {
            Form1.HuoChess_main.m_PlayerColor = "Black";
            Form1.HuoChess_main.m_WhoPlays = "HY";
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
                call_AI();
            }
        }

        private void call_AI()
        {
            playerClicks = 0;
            RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            label2.Text = "Thinking...";
            label3.Text = "";
            Application.DoEvents();
            HuoChess_main.ComputerMove(Form1.HuoChess_main.Skakiera);
            RedrawTheSkakiera(Form1.HuoChess_main.Skakiera);
            label2.Text = string.Concat("Huo Chess move: ", HuoChess_main.NextLine);
            label3.Text = string.Concat("Final positions analyzed: ", HuoChess_main.FinalPositions);
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
