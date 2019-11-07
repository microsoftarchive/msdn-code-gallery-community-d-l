using System;
using System.Windows.Forms;

namespace FloydWarshall
{
    class Algorithm
    {
        public const int Infinity = int.MaxValue / 2;
        public const object NIL = null;

        private void PrintD(int[,] D, int n, TextBox tb)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (D[i, j] == Infinity || D[i, j] > Infinity / 2)
                        tb.Text += "INF";

                    else
                        tb.Text += D[i, j].ToString();

                    tb.Text += "\t";
                }

                tb.Text += "\r\n";
            }

            tb.Text += "\r\n";
        }

        private void PrintPI(object [,] pi, int n, TextBox tb)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pi[i, j] == NIL)
                        tb.Text += "NIL";

                    else
                        tb.Text += ((int)pi[i, j] + 1).ToString();

                    tb.Text += "\t";
                }

                tb.Text += "\r\n";
            }

            tb.Text += "\r\n";
        }

        private int[,] CopyMatrix(int[,] m, int n)
        {
            int[,] x = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    x[i, j] = m[i, j];

            return x;
        }

        public int[,] FloydWarshall(int[,] W, int n, TextBox tb)
        {
            int[,] D0 = CopyMatrix(W, n);
            int[,] D1 = new int[n, n];
            object[,] P0 = new object[n, n];
            object[,] P1 = new object[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || W[i, j] == Infinity)
                        P0[i, j] = NIL;

                    else if (i != j && W[i, j] < Infinity)
                        P0[i, j] = (object)i;
                }
            }

            PrintD(D0, n, tb);
            PrintPI(P0, n, tb);

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        D1[i, j] = Math.Min(
                            D0[i, j], D0[i, k] + D0[k, j]);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (D0[i, j] <= D0[i, k] + D0[k, j])
                            P1[i, j] = P0[i, j];

                        else if (D0[i, j] > D0[i, k] + D0[k, j])
                            P1[i, j] = P0[k, j];
                    }
                }

                D0 = CopyMatrix(D1, n);

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        P0[i, j] = P1[i, j];

                PrintD(D0, n, tb);
                PrintPI(P0, n, tb);
            }

            return D0;
        }
    }
}