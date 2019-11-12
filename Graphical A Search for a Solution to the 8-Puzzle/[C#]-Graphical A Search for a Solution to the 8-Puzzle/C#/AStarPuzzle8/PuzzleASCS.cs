using System;

namespace AStarPuzzle8
{
    class PuzzleASCS
    {
        int g, nodesExpanded;
        int[,] board;
        DateTime date = DateTime.Now;
        Random random;
        public static int MaxMoves = 256;

        public PuzzleASCS() {
		    bool found;
		    int digit, i, j, k;
		    int[] placed = new int[9];
		
		    random = new Random((int) date.Ticks);
		    for (i = 0; i < 9; i++)
			    placed[i] = 0;
		    board = new int[3, 3];
		    g = nodesExpanded = 0;
		    for (i = 0; i < 3; i++)
			    for (j = 0; j < 3; j++)
				    board[i, j] = 0;
		    for (i = 0; i < 9; i++) {
			    found = false;
			    do {
				    digit = random.Next(9);
				    found = placed[digit] == 0;
				    if (found)
					    placed[digit] = 1;
			    } while (!found);
			    do {
				    j = random.Next(3);
				    k = random.Next(3);
				    found = board[j, k] == 0;
				    if (found)
					    board[j, k] = digit;
			    } while (!found);
		    }
	    }

        int getNodesExpanded()
        {
            return nodesExpanded;
        }

        int expand(int[,] square, ref int[,,] tempSquare)
        {
            int b = -1, col = -1, i, j, k, row = -1;

            for (i = 0; i < 4; i++)
                for (j = 0; j < 3; j++)
                    for (k = 0; k < 3; k++)
                        tempSquare[i, j, k] = square[j, k];
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (square[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }
            if (row == 0 && col == 0)
            {
                tempSquare[0 , 0 , 0] = tempSquare[0 , 0 , 1];
                tempSquare[0 , 0 , 1] = 0;
                tempSquare[1 , 0 , 0] = tempSquare[1 , 1 , 0];
                tempSquare[1 , 1 , 0] = 0;
                b = 2;
            }
            else if (row == 0 && col == 1)
            {
                tempSquare[0 , 0 , 1] = tempSquare[0 , 0 , 0];
                tempSquare[0 , 0 , 0] = 0;
                tempSquare[1 , 0 , 1] = tempSquare[1 , 1 , 1];
                tempSquare[1 , 1 , 1] = 0;
                tempSquare[2 , 0 , 1] = tempSquare[2 , 0 , 2];
                tempSquare[2 , 0 , 2] = 0;
                b = 3;
            }
            else if (row == 0 && col == 2)
            {
                tempSquare[0 , 0 , 2] = tempSquare[0 , 0 , 1];
                tempSquare[0 , 0 , 1] = 0;
                tempSquare[1 , 0 , 2] = tempSquare[1 , 1 , 2];
                tempSquare[1 , 1 , 2] = 0;
                b = 2;
            }
            else if (row == 1 && col == 0)
            {
                tempSquare[0 , 1 , 0] = tempSquare[0 , 0 , 0];
                tempSquare[0 , 0 , 0] = 0;
                tempSquare[1 , 1 , 0] = tempSquare[1 , 1 , 1];
                tempSquare[1 , 1 , 1] = 0;
                tempSquare[2 , 1 , 0] = tempSquare[2 , 2 , 0];
                tempSquare[2 , 2 , 0] = 0;
                b = 3;
            }
            else if (row == 1 && col == 1)
            {
                tempSquare[0 , 1 , 1] = tempSquare[0 , 1 , 0];
                tempSquare[0 , 1 , 0] = 0;
                tempSquare[1 , 1 , 1] = tempSquare[1 , 0 , 1];
                tempSquare[1 , 0 , 1] = 0;
                tempSquare[2 , 1 , 1] = tempSquare[2 , 1 , 2];
                tempSquare[2 , 1 , 2] = 0;
                tempSquare[3 , 1 , 1] = tempSquare[3 , 2 , 1];
                tempSquare[3 , 2 , 1] = 0;
                b = 4;
            }
            else if (row == 1 && col == 2)
            {
                tempSquare[0 , 1 , 2] = tempSquare[0 , 0 , 2];
                tempSquare[0 , 0 , 2] = 0;
                tempSquare[1 , 1 , 2] = tempSquare[1 , 1 , 1];
                tempSquare[1 , 1 , 1] = 0;
                tempSquare[2 , 1 , 2] = tempSquare[2 , 2 , 2];
                tempSquare[2 , 2 , 2] = 0;
                b = 3;
            }
            else if (row == 2 && col == 0)
            {
                tempSquare[0 , 2 , 0] = tempSquare[0 , 1 , 0];
                tempSquare[0 , 1 , 0] = 0;
                tempSquare[1 , 2 , 0] = tempSquare[1 , 2 , 1];
                tempSquare[1 , 2 , 1] = 0;
                b = 2;
            }
            else if (row == 2 && col == 1)
            {
                tempSquare[0 , 2 , 1] = tempSquare[0 , 2 , 0];
                tempSquare[0 , 2 , 0] = 0;
                tempSquare[1 , 2 , 1] = tempSquare[1 , 1 , 1];
                tempSquare[1 , 1 , 1] = 0;
                tempSquare[2 , 2 , 1] = tempSquare[2 , 2 , 2];
                tempSquare[2 , 2 , 2] = 0;
                b = 3;
            }
            else if (row == 2 && col == 2)
            {
                tempSquare[0 , 2 , 2] = tempSquare[0 , 2 , 1];
                tempSquare[0 , 2 , 1] = 0;
                tempSquare[1 , 2 , 2] = tempSquare[1 , 1 , 2];
                tempSquare[1 , 1 , 2] = 0;
                b = 2;
            }
            return b;
        }

        int heuristic(int[ , ] square)
        {
            return ManhattanDistance(square);
        }

        bool move()
        {
            int b, count, i, j, k, min;
            int[] f = new int[4], index = new int[4];
            int[ ,  , ] tempSquare = new int[4, 3, 3];

            if (board[0 , 0] == 1 && board[0 , 1] == 2 && board[0 , 2] == 3 &&
                board[1 , 0] == 8 && board[1 , 1] == 0 && board[1 , 2] == 4 &&
                board[2 , 0] == 7 && board[2 , 1] == 6 && board[2 , 2] == 5)
                return true;
            b = expand(board, ref tempSquare);
            for (i = 0; i < b; i++)
            {
                int[,] ts = new int[3, 3];

                for (j = 0; j < 3; j++)
                    for (k = 0; k < 3; k++)
                        ts[j, k] = tempSquare[i, j, k];

                f[i] = g + heuristic(ts);

                for (j = 0; j < 3; j++)
                    for (k = 0; k < 3; k++)
                        board[j , k] = tempSquare[i , j , k];
            }
            // find the node of minimum f
            min = f[0];
            for (i = 1; i < b; i++)
                if (f[i] < min)
                    min = f[i];
            for (count = i = 0; i < b; i++)
                if (f[i] == min)
                    index[count++] = i;
            i = index[random.Next(count)];
            // increment the cost of the path thus far
            g++;
            nodesExpanded += b;
            for (j = 0; j < 3; j++)
                for (k = 0; k < 3; k++)
                    board[j, k] = tempSquare[i, j, k];
            return false;
        }

        int outOfPlace(int[ , ] square)
        {
            int i, j, oop = 0;
            int[ , ] goal = new int[3, 3];

            goal[0 , 0] = 1;
            goal[0 , 1] = 2;
            goal[0 , 2] = 3;
            goal[1 , 0] = 8;
            goal[1 , 1] = 0;
            goal[1 , 2] = 4;
            goal[2 , 0] = 7;
            goal[2 , 1] = 6;
            goal[2 , 2] = 5;
            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                    if (square[i , j] != goal[i , j])
                        oop++;
            return oop;
        }

        int ManhattanDistance(int[ , ] square)
        {
            // city block or Manhatten distance heuristic
            int md = 0;

            if (square[0, 0] == 1)
                md += 0;
            else if (square[0, 0] == 2)
                md += 1;
            else if (square[0, 0] == 3)
                md += 2;
            else if (square[0, 0] == 4)
                md += 3;
            else if (square[0, 0] == 5)
                md += 4;
            else if (square[0, 0] == 6)
                md += 3;
            else if (square[0, 0] == 7)
                md += 2;
            else if (square[0, 0] == 8)
                md += 1;
            if (square[0, 1] == 1)
                md += 1;
            else if (square[0, 1] == 2)
                md += 0;
            else if (square[0, 1] == 3)
                md += 1;
            else if (square[0, 1] == 4)
                md += 2;
            else if (square[0, 1] == 5)
                md += 3;
            else if (square[0, 1] == 6)
                md += 2;
            else if (square[0, 1] == 7)
                md += 3;
            else if (square[0, 1] == 8)
                md += 2;
            if (square[0, 2] == 1)
                md += 2;
            else if (square[0, 2] == 2)
                md += 1;
            else if (square[0, 2] == 3)
                md += 0;
            else if (square[0, 2] == 4)
                md += 1;
            else if (square[0, 2] == 5)
                md += 2;
            else if (square[0, 2] == 6)
                md += 3;
            else if (square[0, 2] == 7)
                md += 4;
            else if (square[0, 2] == 8)
                md += 3;
            if (square[1, 0] == 0)
                md += 1;
            else if (square[1, 0] == 1)
                md += 1;
            else if (square[1, 0] == 2)
                md += 2;
            else if (square[1, 0] == 3)
                md += 3;
            else if (square[1, 0] == 4)
                md += 2;
            else if (square[1, 0] == 5)
                md += 3;
            else if (square[1, 0] == 6)
                md += 2;
            else if (square[1, 0] == 7)
                md += 1;
            else if (square[1, 0] == 8)
                md += 0;
            if (square[1 , 1] == 1)
                md += 2;
            else if (square[1 , 1] == 2)
                md += 1;
            else if (square[1 , 1] == 3)
                md += 2;
            else if (square[1 , 1] == 4)
                md += 1;
            else if (square[1 , 1] == 5)
                md += 2;
            else if (square[1 , 1] == 6)
                md += 1;
            else if (square[1 , 1] == 7)
                md += 2;
            else if (square[1 , 1] == 8)
                md += 1;
            if (square[1 , 2] == 1)
                md += 3;
            else if (square[1 , 2] == 2)
                md += 2;
            else if (square[1 , 2] == 3)
                md += 1;
            else if (square[1 , 2] == 4)
                md += 0;
            else if (square[1 , 2] == 5)
                md += 1;
            else if (square[1 , 2] == 6)
                md += 2;
            else if (square[1 , 2] == 7)
                md += 3;
            else if (square[1 , 2] == 8)
                md += 2;
            if (square[2 , 0] == 1)
                md += 2;
            else if (square[2 , 0] == 2)
                md += 3;
            else if (square[2 , 0] == 3)
                md += 4;
            else if (square[2 , 0] == 4)
                md += 3;
            else if (square[2 , 0] == 5)
                md += 2;
            else if (square[2 , 0] == 6)
                md += 1;
            else if (square[2 , 0] == 7)
                md += 0;
            else if (square[2 , 0] == 8)
                md += 1;
            if (square[2, 1] == 1)
                md += 3;
            else if (square[2, 1] == 2)
                md += 2;
            else if (square[2, 1] == 3)
                md += 3;
            else if (square[2, 1] == 4)
                md += 2;
            else if (square[2, 1] == 5)
                md += 1;
            else if (square[2, 1] == 6)
                md += 0;
            else if (square[2, 1] == 7)
                md += 1;
            else if (square[2, 1] == 8)
                md += 2;
            if (square[2, 2] == 1)
                md += 4;
            else if (square[2, 2] == 2)
                md += 3;
            else if (square[2, 2] == 3)
                md += 2;
            else if (square[2, 2] == 4)
                md += 1;
            else if (square[2, 2] == 5)
                md += 0;
            else if (square[2, 2] == 6)
                md += 1;
            else if (square[2, 2] == 7)
                md += 2;
            else if (square[2, 2] == 8)
                md += 3;
            return md;
        }

        public int solve(ref char[ , ] solution)
        {
            bool found;
            int i, j, k, m = 0;

            do
            {
                for (i = k = 0; i < 3; i++)
                    for (j = 0; j < 3; j++)
                        solution[m , k++] = (char)(board[i , j] + '0');
                found = move();
                m++;
            } while (!found && m < MaxMoves);
            for (i = k = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                    solution[m , k++] = (char)(board[i , j] + '0');
            return m;
        }
    }
}
