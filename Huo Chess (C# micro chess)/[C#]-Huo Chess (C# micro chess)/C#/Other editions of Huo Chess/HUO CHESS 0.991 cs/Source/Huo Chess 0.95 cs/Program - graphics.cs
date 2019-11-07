using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
// UNCOMMENT TO USE THREADS
//using System.Threading;

namespace Huo_Chess_0._971_cs
{
class HuoChess_main {
// HuoChessConsole.cpp : main project file.

    /////////////////////////////////////////////
    // Huo Chess                               //
    // version: 0.971                          //
    // Changes in v0.971: Fixed the Nodes Analysis: Created a different NodesAnalysis array for each level. Fixed bugs so that the analysis stores correctly the values and the MiniMax algorithm performs as it should. Fixed the “Stupid move” filter for the computer moves. Fixed the “Possibility to eat back” functionality.
    // Changes from version 0.81: Removed the ComputerMove functions and used a template function to create all new ComputerMove functions I need.
    // Changes from version 0.722: Changed the ComputerMove, HumanMove, CountScore, ElegxosOrthotitas functions.
    // Changes from verion 0.721: Removed some useless code and added the variable thinking depth (depending on the piece the opponent moves)
    // Changes from version 0.6: Added more thinking depths
    // Year: 2008-2015                         //
    // Place: Earth - Greece                   //
    // Programmed by Spiros I. Kakos (huo)     //
    // License: TOTALLY FREEWARE!              //
    //          Do anything you want with it!  //
    //          Spread the knowledge!          //
    //          Fix its bugs!                  //
    //          Sell it (if you can...)!       //
    //          Call me for help! :P           //
    // Site: www.kakos.com.gr                  //
    //       www.kakos.eu                      //
    //       Harmonia Philosophica portals     //
    // Dedicated to Matoula!!! The light of my life!!!! E-U!//
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
    public static int humanDangerParameter = 0;
    public static int computerDangerParameter = 1;

    // Is it possible to eat back the piece that was moved by the computer?
    public static bool possibility_to_eat_back;

    //v0.970 added
    public static int ValueOfHumanMovingPiece = 0;
    public static int ValueOfMovingPiece = 0;

    // Variables to store the scores of positions during the analysis
    //v0.970: Changed them to integers
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
    public static int[,] NodesAnalysis0 = new int[1000000, 6];
    public static int[,] NodesAnalysis1 = new int[1000000, 2];
    public static int[,] NodesAnalysis2 = new int[1000000, 2];
    public static int[,] NodesAnalysis3 = new int[1000000, 2];
    public static int[,] NodesAnalysis4 = new int[100000000, 2];  // Increased depth => Increased size (logical...)

    public static int Nodes_Total_count;
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

    // If human eats a piece, then make the square a preferred target!!!
    public static int Human_last_move_target_column;
    public static int Human_last_move_target_row;

    // The chessboard (=skakiera in Greek)
    public static String[,] Skakiera = new String[8, 8];  // Δήλωση πίνακα που αντιπροσωπεύει τη σκακιέρα

    // Variable which determines of the program will show the inner
    // thinking process of the AI. Good for educational purposes!!!
    // UNCOMMENT TO SHOW INNER THINKING MECHANISM!
    //bool huo_debug;

    // Arrays to use in ComputerMove function
    // Penalty for moving the only piece that defends a square to that square (thus leavind the defender
    // alone in the square he once defended, defenceless!)
    // This penalty is also used to indicate that the computer loses its Queen with the move analyzed
    public static bool Danger_penalty;

    public static String m_PlayerColor;
    public static String m_ComputerLevel = "Kakos";
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
    public static int number_of_moves_analysed;

    // Variable to show if promotion of a pawn occured
    public static bool Promotion_Occured = false;

    // Variable to show if castrling occured
    public static bool Castling_Occured = false;

    // Variables to help find out if it is legal for the computer to perform castling
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

    // If it possible to eat the queen of the opponent, go for it!
    public static bool go_for_it;

    // Variables to show where the kings are in the chessboard
    public static int WhiteKingColumn;
    public static int WhiteKingRank;
    public static int BlackKingColumn;
    public static int BlackKingRank;

    // Variables to show if king is in check
    public static bool WhiteKingCheck;
    public static bool BlackKingCheck;

    // Variables to show if there is a possibility for mate
    //public static bool WhiteMate = false;
    //public static bool BlackMate = false;
    //public static bool Mate;

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
    public static int StartingBlackKingColumn;
    public static int StartingBlackKingRank;

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
    // Rest of variables used for computer thought
    public static double Best_Move_Score;
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

    // Variables which help find the best move of the human-opponent during the HY thought analysis
    public static bool First_Call_Human_Thought;
    public static String MovingPiece_Human = "";
    public static int m_StartingColumnNumber_Human = 1;
    public static int m_FinishingColumnNumber_Human = 1;
    public static int m_StartingRank_Human = 1;
    public static int m_FinishingRank_Human = 1;

    // Coordinates of the square Where the player can perform en passant
    public static int enpassant_possible_target_rank;
    public static int enpassant_possible_target_column;

    // Is there a possible mate?
    public static bool Human_is_in_check;
    public static bool Possible_mate;

    // Does the HY moves its King with the move it is analyzing?
    public static bool moving_the_king;

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // END OF VARIABLES DECLARATION
    ///////////////////////////////////////////////////////////////////////////////////////////////////

static void Main(string[] args) {
	/////////////////////
	// Setup game
	/////////////////////
	Console.Write("Choose color (w/b): ");
	String the_choise_of_user = Console.ReadLine();

	if((the_choise_of_user.CompareTo("w") == 0)||(the_choise_of_user.CompareTo("W") == 0))
	{
		m_PlayerColor = "White";
		m_WhoPlays = "Human";
	}
	else if((the_choise_of_user.CompareTo("b") == 0)||(the_choise_of_user.CompareTo("B") == 0))
	{
		m_PlayerColor = "Black";
		m_WhoPlays = "HY";
	}

    /////////////////////////////////////////////////////////////////////////
    // CHANGE Thinking_Depth TO HAVE MORE THINKING DEPTHS
    // BUT REMEMBER TO ALSO ADD Analyze_Move functions!
    /////////////////////////////////////////////////////////////////////////
    // ΠΡΟΣΟΧΗ: Αν βάλω τον υπολογιστή να σκεφτεί σε βάθος 1 κίνησης
    // (ήτοι Thinking_Depth = 0), τότε ΔΕΝ σκέφτεται σωστά! Αυτό συμβαίνει
    // διότι η HumanMove πρέπει να κληθεί τουλάχιστον μία φορά για να
    // ολοκληρωθεί σωστά τουλάχιστον ένας πλήρης κύκλος σκέψης του ΗΥ.
    /////////////////////////////////////////////////////////////////////////

    // MiniMax algorithm currently only utilizes 4-ply thinking depth
    // Add more "for loops" in the required section in ComputerMove to allow more deep thinking
    // However remember that the NodesAnalysis table has a limit!!! (and so does the memory)
    // Thinking depth must be ζυγός number because the nodes are recorded only in the Analyze_Computer functions!

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

	Console.WriteLine( "\nHuo Chess v0.971 by Spiros I.Kakos (huo) [2015] - C# Edition" );

	// Initial values
	Move = 0;
	m_WhichColorPlays = "White";

    // Setup startup position
	Starting_position();

	// If it is the turn of HY to play, then call the respective function to implement HY thought

	bool exit_game = false;

	do
	{

	if ( m_WhoPlays.CompareTo("HY") == 0 )
	{
		// Call HY Thought function
		Move = 0;

		if( Move == 0 )
		{
			Console.WriteLine("");
			Console.WriteLine("Thinking...");
		}

		Move_Analyzed = 0;
		Stop_Analyzing = false;
		First_Call = true;
		Best_Move_Found = false;
		Who_Is_Analyzed = "HY";

        // CHECK DANGER - Start
        #region checkDanger
        // Find the dangerous squares in the chessboard, where if the HY
        // moves its piece, it will immediately (or most probably) loose it.

        for (i = 0; i <= 7; i++)
        {
            for (j = 0; j <= 7; j++)
            {
                Skakiera_Dangerous_Squares[i, j] = "";
            }
        }

        // Initialize variables for finding the dangerous squares
        for (int di = 0; di <= 7; di++)
        {
            for (int dj = 0; dj <= 7; dj++)
            {
                Number_of_attackers[di, dj] = 0;
                Number_of_defenders[di, dj] = 0;
                Value_of_attackers[di, dj] = 0;
                Attackers_coordinates_column[di, dj] = 0;
                Attackers_coordinates_rank[di, dj] = 0;
                Value_of_defenders[di, dj] = 0;
                Exception_defender_column[di, dj] = -9;
                Exception_defender_rank[di, dj] = -9;
            }
        }

        FindAttackers(Skakiera);
        FindDefenders(Skakiera);

        #endregion checkDanger
        // CHECK DANGER - End


		ComputerMove(Skakiera);
	}
	else if ( m_WhoPlays.CompareTo("Human") == 0 )
	{
		////////////////////////////
		// Human enters his move
		////////////////////////////
		Console.WriteLine("");
		Console.Write("Starting column (A to H)...");
		m_StartingColumn = Console.ReadLine().ToUpper();

		Console.Write("Starting rank (1 to 8).....");
		m_StartingRank = Int32.Parse(Console.ReadLine());

		Console.Write("Finishing column (A to H)...");
		m_FinishingColumn = Console.ReadLine().ToUpper();

		Console.Write("Finishing rank (1 to 8).....");
		m_FinishingRank = Int32.Parse(Console.ReadLine());

		// Show the move entered
		String huoMove = String.Concat("Your move: ", m_StartingColumn, m_StartingRank.ToString(), " -> " );
        huoMove = String.Concat( huoMove, m_FinishingColumn, m_FinishingRank.ToString() );
		Console.WriteLine( huoMove );

		//Console.WriteLine("");
		//Console.WriteLine("Thinking...");

		// Check the move entered by the human for correctness (='Orthotita' in Greek) and legality (='Nomimotita' in Greek)
		Enter_move();
        Display_board(Skakiera);
	}

	}while(exit_game == false);

	}


public static bool CheckForBlackCheck(string[,] BCSkakiera)
{
    // Check if the black king is under threat

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
    // Check if the black king is under checkmate

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
    // Check if the white king is under check

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
    // Check if the white king is under checkmate

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

    // Restore the normal value of the m_WhoPlays
    m_WhoPlays = "HY";

    if (((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true)) && (Move_Analyzed == 0))
    {
        // Store the move to ***_HY variables (because after continuous calls of ComputerMove the initial move under analysis will be lost...)

        MovingPiece_HY = MovingPiece;
        m_StartingColumnNumber_HY = m_StartingColumnNumber;
        m_FinishingColumnNumber_HY = m_FinishingColumnNumber;
        m_StartingRank_HY = m_StartingRank;
        m_FinishingRank_HY = m_FinishingRank;

        // Store the initial move coordinates (at the node 0 level)
        NodesAnalysis0[NodeLevel_0_count, 2] = m_StartingColumnNumber_HY;
        NodesAnalysis0[NodeLevel_0_count, 3] = m_FinishingColumnNumber_HY;
        NodesAnalysis0[NodeLevel_0_count, 4] = m_StartingRank_HY;
        NodesAnalysis0[NodeLevel_0_count, 5] = m_FinishingRank_HY;

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

        // Check is HY eats the opponents queen (so it is preferable to do so...)
        // Not operational yet...
        if ((ProsorinoKommati.CompareTo("White Queen") == 0) || (ProsorinoKommati.CompareTo("Black Queen") == 0))
            go_for_it = true;

        // v0.970: Danger penalty now checked directly in ComputerMove
    }

}

// Changed in version 0.970
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
    // If there is a possibility to eat back what was eaten, then go for it!
    possibility_to_eat_back = false;

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
            NodesAnalysis3[dimension1, dimension2] = 0;
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
    // Also find number and value of attackers and defenders for each square of the chessboard: will be used below to determine if the move is stupid
    #region DangerousSquares
    Danger_for_piece = false;

    for (int o1 = 0; o1 <= 7; o1++)
    {
        for (int p1 = 0; p1 <= 7; p1++)
        {
            Skakiera_Dangerous_Squares[(o1), (p1)] = "";
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
            if (Number_of_attackers[o1, p1] > Number_of_defenders[o1, p1])
                Skakiera_Dangerous_Squares[(o1), (p1)] = "Y";
        }
    }

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

                        MovingPiece = Skakiera_Thinking[(iii), (jjj)];
                        m_StartingColumnNumber = iii + 1;
                        m_FinishingColumnNumber = w + 1;
                        m_StartingRank = jjj + 1;
                        m_FinishingRank = r + 1;

                        // Store temporary move data in local variables, so as to use them in the Undo of the move
                        // at the end of this function (the MovingPiece, m_StartingColumnNumber, etc variables are
                        // changed by next functions as well, so using them leads to problems)
                        MovingPiece0 = MovingPiece;
                        m_StartingColumnNumber0 = m_StartingColumnNumber;
                        m_FinishingColumnNumber0 = m_FinishingColumnNumber;
                        m_StartingRank0 = m_StartingRank;
                        m_FinishingRank0 = m_FinishingRank;
                        ProsorinoKommati0 = Skakiera_Thinking[(m_FinishingColumnNumber0 - 1), (m_FinishingRank0 - 1)];

                        // Check for stupid moves in the start of the game
                        String DoNotMakeStupidMove = "Not stupid";
                        #region CheckStupidMove
                        if (Move < 5)
                        {
                            if ((MovingPiece.CompareTo("White Queen") == 0) || (MovingPiece.CompareTo("Black Queen") == 0) ||
                                    (MovingPiece.CompareTo("White Rook") == 0) || (MovingPiece.CompareTo("Black Rook") == 0))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if (((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                    && (m_FinishingColumnNumber == 1))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if (((MovingPiece.CompareTo("White Knight") == 0) || (MovingPiece.CompareTo("Black Knight") == 0))
                                    && (m_FinishingColumnNumber == 8))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("White Knight") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 4)
                                    && (Skakiera_Thinking[(2), (0)].CompareTo("White Bishop") == 0))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("White Knight") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 5)
                                    && (Skakiera_Thinking[(5), (0)].CompareTo("White Bishop") == 0))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("Black Knight") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 4)
                                    && (Skakiera_Thinking[(2), (7)].CompareTo("Black Bishop") == 0))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("Black Knight") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 5)
                                    && (Skakiera_Thinking[(5), (7)].CompareTo("Black Bishop") == 0))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("White Pawn") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("White Pawn") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("Black Pawn") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("Black Pawn") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if ((MovingPiece.CompareTo("White King") == 0) || (MovingPiece.CompareTo("Black King") == 0))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                            else if (((MovingPiece.CompareTo("White Bishop") == 0) || (MovingPiece.CompareTo("Black Bishop") == 0))
                                && ((m_FinishingRank == 3) || (m_FinishingRank == 5) || (m_FinishingRank == 6)))
                            {
                                DoNotMakeStupidMove = "Stupid";
                            }
                        }
                        #endregion CheckStupidMove


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

                        // If a pieve of lower value attacks the square where the computer moves, then... stupid move!
                        if ((Number_of_attackers[w, r] == 1) && (Value_of_attackers[w, r] < ValueOfMovingPiece))
                            DoNotMakeStupidMove = "Stupid";


                        //If the move is not stupid or the destination square is not dangerous then do the move to check it...
                        if ((DoNotMakeStupidMove.CompareTo("Not stupid") == 0) && (Skakiera_Dangerous_Squares[w, r].CompareTo("") == 0))
                        {
                            // THE HEART OF THE THINKING MECHANISM: Here the computer checks the moves

                            // Validity and legality of the move will be checked in CheckMove
                            // (plus some additional checks for possible mate etc)
                            CheckMove(Skakiera_Thinking);

                            number_of_moves_analysed++;

                            // If everything is OK, then do the move and measure it's score
                            if ((m_OrthotitaKinisis == true) && (m_NomimotitaKinisis == true))
                            {
                                // Do the move
                                ProsorinoKommati = Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                Skakiera_Thinking[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                Skakiera_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;

                                // Check the score after the computer move
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


                                // v0.970: Check if you can eat back the piece of the human which moved!
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


                                // v0.970: If you can eat back the piece of the human, then go for it and don't analyze!
                                if ((Move_Analyzed < Thinking_Depth) && (possibility_to_eat_back == false))
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
    // Analyze only if possibility to eat back is not true!!!

    if (possibility_to_eat_back == false)
    {
        // [MiniMax algorithm - skakos]
        // Find node 1 move with the best score via the MiniMax algorithm.
        int counter0, counter1, counter2, counter3, counter4; // counter5, counter6, counter7, counter8, counter9, counter10;

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

        for (counter4 = 1; counter4 <= NodeLevel_4_count; counter4++)
        {
            if (Int32.Parse(NodesAnalysis4[counter4, 1].ToString()) != parentNodeAnalyzed)
            {
                //parentNodeAnalyzedchanged = true;
                parentNodeAnalyzed = Int32.Parse(NodesAnalysis4[counter4, 1].ToString());
                NodesAnalysis3[Int32.Parse(NodesAnalysis4[counter4, 1].ToString()), 0] = NodesAnalysis4[counter4, 0];
            }

            if (NodesAnalysis4[counter4, 0] >= NodesAnalysis3[Int32.Parse(NodesAnalysis4[counter4, 1].ToString()), 0])
                NodesAnalysis3[Int32.Parse(NodesAnalysis4[counter4, 1].ToString()), 0] = NodesAnalysis4[counter4, 0];
        }

        parentNodeAnalyzed = -999;

        for (counter3 = 1; counter3 <= NodeLevel_3_count; counter3++)
        {
            if (Int32.Parse(NodesAnalysis3[counter3, 1].ToString()) != parentNodeAnalyzed)
            {
                //parentNodeAnalyzedchanged = true;
                parentNodeAnalyzed = Int32.Parse(NodesAnalysis3[counter3, 1].ToString());
                NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0] = NodesAnalysis3[counter3, 0];
            }

            if (NodesAnalysis3[counter3, 0] <= NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0])
                NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0] = NodesAnalysis3[counter3, 0];
        }

        parentNodeAnalyzed = -999;

        for (counter2 = 1; counter2 <= NodeLevel_2_count; counter2++)
        {
            if (Int32.Parse(NodesAnalysis2[counter2, 1].ToString()) != parentNodeAnalyzed)
            {
                //parentNodeAnalyzedchanged = true;
                parentNodeAnalyzed = Int32.Parse(NodesAnalysis2[counter2, 1].ToString());
                NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
            }

            if (NodesAnalysis2[counter2, 0] >= NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0])
                NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
        }

        // Now the node0 level is filled with the score data
        // this is line 1 in the shape at http://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Minimax.svg/300px-Minimax.svg.png

        parentNodeAnalyzed = -999;

        for (counter1 = 1; counter1 <= NodeLevel_1_count; counter1++)
        {
            if (Int32.Parse(NodesAnalysis1[counter1, 1].ToString()) != parentNodeAnalyzed)
            {
                //parentNodeAnalyzedchanged = true;
                parentNodeAnalyzed = Int32.Parse(NodesAnalysis1[counter1, 1].ToString());
                NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
            }

            if (NodesAnalysis1[counter1, 0] <= NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0])
                NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
        }

        // Choose the biggest score at the Node0 level
        // Check example at http://en.wikipedia.org/wiki/Minimax#Example_2
        // This is line 0 at the shape at http://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Minimax.svg/300px-Minimax.svg.png

        // Initialize the score with the first score and move found
        double temp_score = NodesAnalysis0[1, 0];
        Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[1, 2].ToString());
        Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[1, 4].ToString());
        Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[1, 3].ToString());
        Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[1, 5].ToString());

        for (counter0 = 1; counter0 <= NodeLevel_0_count; counter0++)
        {
            if (NodesAnalysis0[counter0, 0] > temp_score)
            {
                temp_score = NodesAnalysis0[counter0, 0];

                Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 2].ToString());
                Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[counter0, 4].ToString());
                Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 3].ToString());
                Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[counter0, 5].ToString());
            }
        }

    }

    // Total final positions analyzed is...
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

    // If king is moved, no castling can occur
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

    // Is there a pawn to promote?
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
    // Show HY move
    //////////////////////////////////////////////////////////////////////
    // UNCOMMENT TO SHOW THINKING TIME!
    // Uncomment to have the program record the start and stop time to a log .txt file
    // StreamWriter huo_sw2 = new StreamWriter("game.txt", true);
    // MessageBox.Show(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
    // huo_sw2.WriteLine(string.Concat("Stoped thinking at: ", DateTime.Now.ToString("hh:mm:ss.fffffff")));
    // MessageBox.Show(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));
    // huo_sw2.WriteLine(string.Concat("Number of moves analyzed: ", number_of_moves_analysed.ToString()));

    NextLine = String.Concat(HY_Starting_Column_Text, Best_Move_StartingRank.ToString(), " -> ", HY_Finishing_Column_Text, Best_Move_FinishingRank.ToString());
    Console.WriteLine(String.Concat("My move is: ", NextLine));
    Display_board(Skakiera);
    //MessageBox.Show(number_of_moves_analysed.ToString());

    number_of_moves_analysed = 0;

    // Αν ο υπολογιστής παίζει με τα λευκά, τότε αυξάνεται τώρα το νούμερο της κίνησης.
    // If the computer plays with White, now is the time to increase the number of moves in the game.
    if (m_PlayerColor.CompareTo("Black") == 0)
        Move = Move + 1;

    // Now it is the other color's turn to play
    if (m_PlayerColor.CompareTo("Black") == 0)
        m_WhichColorPlays = "Black";
    else if (m_PlayerColor.CompareTo("White") == 0)
        m_WhichColorPlays = "White";

    // Now it is the human's turn to play
    m_WhoPlays = "Human";
}

//v0.970: Changed the return type to integer to help memory usage
//v0.970: Return to basics! Remove too much sauce!
public static int CountScore(string[,] CSSkakiera, int DangerWeight)
{
    // White pieces: positive score
    // Black pieces: negative score

    Current_Move_Score = 0;
    int addValueWhite = 0;
    int addValueBlack = 0;
    int Multiplier_White = 1;
    int Multiplier_Black = 1;
    DangerWeight = 0;

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
            }
            else if (CSSkakiera[(i), (j)].CompareTo("White Knight") == 0)
            {
                Current_Move_Score = Current_Move_Score + 3 * Multiplier_White + (10 * addValueWhite);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("White Bishop") == 0)
            {
                Current_Move_Score = Current_Move_Score + 3 * Multiplier_White + (10 * addValueWhite);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("White Queen") == 0)
            {
                Current_Move_Score = Current_Move_Score + 9 * Multiplier_White + (10 * addValueWhite);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("White King") == 0)
                Current_Move_Score = Current_Move_Score + 15 * Multiplier_White + (10 * addValueWhite);
            else if (CSSkakiera[(i), (j)].CompareTo("Black Pawn") == 0)
                Current_Move_Score = Current_Move_Score - 1 * Multiplier_Black + (10 * addValueBlack);
            else if (CSSkakiera[(i), (j)].CompareTo("Black Rook") == 0)
            {
                Current_Move_Score = Current_Move_Score - 5 * Multiplier_Black + (10 * addValueBlack);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("Black Knight") == 0)
            {
                Current_Move_Score = Current_Move_Score - 3 * Multiplier_Black + (10 * addValueBlack);
                // Decrease score based on the danger in which the piece is in
                // v0.970: Delete tis polles malakies
                // Current_Move_Score = Current_Move_Score + DangerWeight * CheckDanger_Black(CSSkakiera, i, j);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("Black Bishop") == 0)
            {
                Current_Move_Score = Current_Move_Score - 3 * Multiplier_Black + (10 * addValueBlack);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("Black Queen") == 0)
            {
                Current_Move_Score = Current_Move_Score - 9 * Multiplier_Black + (10 * addValueBlack);
            }
            else if (CSSkakiera[(i), (j)].CompareTo("Black King") == 0)
                Current_Move_Score = Current_Move_Score + 15 * Multiplier_Black + (10 * addValueBlack);

        }
    }

    return Current_Move_Score;
}



// FUNCTION TO CHECK THE LEGALITY (='Nomimotita' in Greek) OF A MOVE
// (i.e. if between the initial and the destination square lies another
// piece, then the move is not legal).
// The ElegxosNomimotitas "checkForDanger" function differs from the normal function in that it does not make all the validations
// (since it is used to check for "Dangerous" squares in the chessboard and not to actually judge the correctness of an actual move)
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

	if( ((finishRank-1) > 7) || ((finishRank-1) < 0) || ((finishColumn-1) > 7) || ((finishColumn-1) < 0) )
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
	else if( (MovingPiece_2.CompareTo("White Rook") == 0) || (MovingPiece_2.CompareTo("White Queen") == 0) || (MovingPiece_2.CompareTo("White Bishop") == 0) || (MovingPiece_2.CompareTo("Black Rook") == 0) || (MovingPiece_2.CompareTo("Black Queen") == 0) || (MovingPiece_2.CompareTo("Black Bishop") == 0) )
	{
		h = 0;
		p = 0;
		//hhh = 0;
		how_to_move_Rank = 0;
		how_to_move_Column = 0;

		if(((finishRank-1) > (startRank-1)) || ((finishRank-1) < (startRank-1)))
			how_to_move_Rank = ((finishRank-1) - (startRank-1))/System.Math.Abs((finishRank-1) - (startRank-1));
			
		if(((finishColumn-1) > (startColumn-1)) || ((finishColumn-1) < (startColumn-1)) )
			how_to_move_Column = ((finishColumn-1) - (startColumn-1))/System.Math.Abs((finishColumn-1) - (startColumn-1));

		exit_elegxos_nomimothtas = false;

		do
		{
			h = h + how_to_move_Rank;
			p = p + how_to_move_Column;

			if( (((startRank-1) + h) == (finishRank-1)) && ((((startColumn-1) + p)) == (finishColumn-1)) )
				exit_elegxos_nomimothtas = true;

			if((startColumn - 1 + p)<0)
				exit_elegxos_nomimothtas = true;
			else if((startRank - 1 + h)<0)
				exit_elegxos_nomimothtas = true;
			else if((startColumn - 1 + p)>7)
				exit_elegxos_nomimothtas = true;
			else if((startRank - 1 + h)>7)
				exit_elegxos_nomimothtas = true;

			// if a piece exists between the initial and the destination square,
			// then the move is illegal!
			if( exit_elegxos_nomimothtas == false )
			{
				if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("White Rook") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("White Knight") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("White Bishop") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("White Queen") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("White King") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("White Pawn") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				
				if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("Black Rook") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("Black Knight") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("Black Bishop") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("Black Queen") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("Black King") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
				else if(ENSkakiera[(startColumn - 1 + p),(startRank - 1 + h)].CompareTo("Black Pawn") == 0)
				{
					Nomimotita = false;
					exit_elegxos_nomimothtas = true;
				}
			}
		}while(exit_elegxos_nomimothtas == false);
	}
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


// v0.970: Fixed comments
public static void Enter_move()
{
    // Validate the move the human opponent entered

    // Show the move entered by the human player

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
        Console.WriteLine("It's not your turn.");

    // Is the column entered valid?

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

        // Is the king under check?
        if (m_PlayerColor.CompareTo("White") == 0)
            WhiteKingCheck = CheckForWhiteCheck(Skakiera);
        else if (m_PlayerColor.CompareTo("Black") == 0)
            BlackKingCheck = CheckForBlackCheck(Skakiera);

        MovingPiece = Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];

        // If he chooses to move a piece of different colour...
        if (((m_PlayerColor.CompareTo("White") == 0) || (m_PlayerColor.CompareTo("Self") == 0) && ((Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White King") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("White Pawn") == 0))) || (((m_PlayerColor.CompareTo("Black") == 0) || (m_PlayerColor.CompareTo("Self") == 0)) && ((Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Rook") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Knight") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Bishop") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Queen") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black King") == 0) || (Skakiera[(m_StartingColumnNumber - 1), ((m_StartingRank - 1))].CompareTo("Black Pawn") == 0))))
        {
            Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
        }

    }
    else
    {
        if (m_WhichColorPlays.CompareTo("White") == 0)
            Console.WriteLine("White plays.");
        else if (m_WhichColorPlays.CompareTo("Black") == 0)
            Console.WriteLine("Black plays.");

        m_WrongColumn = true;
        // v0.980 possible fix: This variable is set to "true" so that... what?!? Must check in the next versions...
        // Η μεταβλητή αυτή τίθεται true για να βγει "μη ορθή" η κίνηση από
        // τη συνάρτηση που ακολουθεί ακριβώς από κάτω και ελέγχει την "ορθότητα" της κίνησης.
    }

    // Check correctness of move entered
    m_OrthotitaKinisis = ElegxosOrthotitas(Skakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

    // Check legality of move entered (only if it is correct - so as to save time!)
    if (m_OrthotitaKinisis == true)
        m_NomimotitaKinisis = ElegxosNomimotitas(Skakiera, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
    else
        m_NomimotitaKinisis = false;

    // Check if the human's king is in check even after his move!
    // Temporarily move the piece the user wants to move
    Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
    ProsorinoKommati = Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
    Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;
    // Check if king is still under check
    WhiteKingCheck = CheckForWhiteCheck(Skakiera);

    if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
        m_NomimotitaKinisis = false;


    // Check if black king is still under check
    BlackKingCheck = CheckForBlackCheck(Skakiera);

    if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
        m_NomimotitaKinisis = false;

    // Restore all pieces to the initial state
    Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
    Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = ProsorinoKommati;


    // CHECK IF THE HUMAN HAS ENTERED A CASTLING MOVE

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
        if (m_PlayerColor.CompareTo("White") == 0)
            Move = Move + 1;

        // Erase initial square
        Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";

        Human_last_move_target_column = -1;
        Human_last_move_target_row = -1;
        if (Skakiera[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("") == 1)
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

        if ((m_PlayerColor.CompareTo("White") == 0) || (m_PlayerColor.CompareTo("Black") == 0))
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
            Console.WriteLine("CHECK!");
        }


        // If it is the turn of the HY to play, then call the respective HY Thought function

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
        Console.WriteLine("INVALID MOVE!");
        Skakiera[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
        MovingPiece = "";
        m_WhoPlays = "Human";
    }


}
		

public static void PawnPromotion()                     
{
	for (i = 0; i <= 7; i++)
	{
			
			if (Skakiera[(i),(0)].CompareTo("Black Pawn") == 0)
			{

				if (m_WhoPlays.CompareTo("Human") == 0)
				{
					///////////////////////////
					// promote pawn
					///////////////////////////

					Console.WriteLine("");

					Console.WriteLine("Promote your pawn to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop");
					Console.Write("CHOOSE (1-4): ");
					choise_of_user = Int32.Parse(Console.ReadLine());

					switch(choise_of_user)
					{
					case 1:
						Skakiera[(i),(0)] = "Black Queen";
						break;

					case 2:
						Skakiera[(i),(0)] = "Black Rook";
						break;

					case 3:
						Skakiera[(i),(0)] = "Black Knight";
						break;

					case 4:
						Skakiera[(i),(0)] = "Black Bishop";
						break;
					};
				}

			}

			if (Skakiera[(i),(7)].CompareTo("White Pawn") == 0)
			{
				if (m_WhoPlays.CompareTo("Human") == 0)
				{
					///////////////////////////
					// promote pawn
					///////////////////////////

					Console.WriteLine("");

					Console.WriteLine("Promote your pawn to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop");
					Console.Write("CHOOSE (1-4): ");
					choise_of_user = Int32.Parse(Console.ReadLine());

					switch(choise_of_user)
					{
					case 1:
						Skakiera[(i),(0)] = "White Queen";
						break;

					case 2:
						Skakiera[(i),(0)] = "White Rook";
						break;

					case 3:
						Skakiera[(i),(0)] = "White Knight";
						break;

					case 4:
						Skakiera[(i),(0)] = "White Bishop";
						break;
					};
				}

			}

	}
}

// Setup the starting position
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
                        MovingPiece1 = MovingPiece;
                        m_StartingColumnNumber1 = m_StartingColumnNumber;
                        m_FinishingColumnNumber1 = m_FinishingColumnNumber;
                        m_StartingRank1 = m_StartingRank;
                        m_FinishingRank1 = m_FinishingRank;
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
                        MovingPiece2 = MovingPiece;
                        m_StartingColumnNumber2 = m_StartingColumnNumber;
                        m_FinishingColumnNumber2 = m_FinishingColumnNumber;
                        m_StartingRank2 = m_StartingRank;
                        m_FinishingRank2 = m_FinishingRank;
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
                                //NodesAnalysis[NodeLevel_5_count, 5, 0] = Temp_Score_Move_5_human;
                                //NodesAnalysis[NodeLevel_6_count, 6, 0] = Temp_Score_Move_6;

                                // Store the parents (number of the node of the upper level)
                                NodesAnalysis0[NodeLevel_0_count, 1] = 0;
                                NodesAnalysis1[NodeLevel_1_count, 1] = NodeLevel_0_count;
                                NodesAnalysis2[NodeLevel_2_count, 1] = NodeLevel_1_count;
                                NodesAnalysis3[NodeLevel_3_count, 1] = NodeLevel_2_count;
                                NodesAnalysis4[NodeLevel_4_count, 1] = NodeLevel_3_count;
                                //NodesAnalysis[NodeLevel_5_count, 5, 1] = NodeLevel_4_count;
                                //NodesAnalysis[NodeLevel_6_count, 6, 1] = NodeLevel_5_count;

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

                            // Exception for Defenders!
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
                            else if (Number_of_defenders[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] > 1)
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

//Michael Kirk: 11 - 10 - 2013 Added console display of the board after the computer move
//skakos: Fixed for C#
public static void Display_board(string[,] DrawSkakiera)
{
    bool BoardColour = true;
    //False = Black True = While
    int RowCounter = 7;
    while (RowCounter > -1)
    {
        for (int ColumnCounter = 0; ColumnCounter <= 7; ColumnCounter++)
        {
            Console.BackgroundColor = SetBoardColour(ref BoardColour);
            SetPieceColour(DrawSkakiera[ColumnCounter, RowCounter]);
            Console.Write(" ");
            Console.Write(get_key(DrawSkakiera[ColumnCounter, RowCounter]));
            Console.Write(" ");
        }
        Console.WriteLine("");
        Console.BackgroundColor = SetBoardColour(ref BoardColour);
        //Does this to switch the colour at the end of the row
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        RowCounter -= 1;
    }

    // Return to the default letters colour
    Console.ForegroundColor = ConsoleColor.Gray;
}

public static string get_key(string Piece)
{
    if (Piece.CompareTo("") == 0)
        return " ";
    if (Piece.CompareTo("White Pawn") == 0)
        return "o";
    if (Piece.CompareTo("White Rook") == 0)
        return "R";
    if (Piece.CompareTo("White Bishop") == 0)
        return "B";
    if (Piece.CompareTo("White King") == 0)
        return "K";
    if (Piece.CompareTo("White Knight") == 0)
        return "N";
    if (Piece.CompareTo("White Queen") == 0)
        return "Q";
    if (Piece.CompareTo("Black Pawn") == 0)
        return "o";
    if (Piece.CompareTo("Black Rook") == 0)
        return "R";
    if (Piece.CompareTo("Black Bishop") == 0)
        return "B";
    if (Piece.CompareTo("Black King") == 0)
        return "K";
    if (Piece.CompareTo("Black Knight") == 0)
        return "N";
    if (Piece.CompareTo("Black Queen") == 0)
        return "Q";
    return Piece;
}

public static System.ConsoleColor SetBoardColour(ref bool BoardColour)
{
    if (BoardColour == false)
    {
        BoardColour = true;
        return ConsoleColor.DarkGray;
    }
    else
    //if (BoardColour == true)
    {
        BoardColour = false;
        return ConsoleColor.Gray;
    }
}

public static void SetPieceColour(string Piece)
{
    if (Piece.CompareTo("") == 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else
    {
        if (Piece.Substring(0, 5).CompareTo("White") == 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
};
}

