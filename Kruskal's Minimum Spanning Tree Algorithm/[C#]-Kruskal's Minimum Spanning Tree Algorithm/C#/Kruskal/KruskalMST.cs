using System;

namespace Kruskal
{
    class KruskalMST
    {
        int ALength;
        Edge[] edge;

        void quickSort(int p, int r)
        {
            int i = p, j = r, m = (i + j) / 2;
            Edge x = edge[m];

            do
            {
                while (edge[i].Weight < x.Weight)
                    i++;

                while (edge[j].Weight > x.Weight)
                    j--;

                if (i <= j)
                {
                    Edge temp = edge[i];

                    edge[i] = edge[j];
                    edge[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (p < j)
                quickSort(p, j);
            
            if (i < r)
                quickSort(i, r);
        }

        public Pair[] MSTKruskal(int n, Adjacency adjacency)
        {
            bool uFound, vFound;
            int i, j, k, l, m, u, v;
            int ULength, count = 0;
            int[] U = new int[n];
            int[] SLength = new int[n];
            int[,] S = new int[n, n];
            Pair[] A = new Pair[n * n];

            ALength = 0;

            for (v = 0; v < n; v++)
            {
                SLength[v] = 1;
                S[v, 0] = v;
            }

            for (u = 0; u < n - 1; u++)
                for (v = u + 1; v < n; v++)
                    if (adjacency.getElementAt(u, v))
                        count++;

            edge = new Edge[count];
            
            for (i = 0; i < count; i++)
                edge[i] = new Edge();
            
            for (i = u = 0; u < n - 1; u++)
            {
                for (v = u + 1; v < n; v++)
                {
                    if (adjacency.getElementAt(u, v))
                    {
                        edge[i].U = u;
                        edge[i].V = v;
                        edge[i++].Weight = adjacency.getWeight(u, v);
                    }
                }
            }

            quickSort(0, count - 1);

            for (i = 0; i < count; i++)
            {
                int jIndex = -1, lIndex = -1;

                u = edge[i].U;
                v = edge[i].V;

                for (uFound = false, j = 0; !uFound && j < n; j++)
                {
                    for (k = 0; !uFound && k < SLength[j]; k++)
                    {
                        uFound = u == S[j, k];
                        if (uFound)
                            jIndex = j;
                    }
                }
                for (vFound = false, l = 0; !vFound && l < n; l++)
                {
                    for (m = 0; !vFound && m < SLength[l]; m++)
                    {
                        vFound = v == S[l, m];
                        if (vFound)
                            lIndex = l;
                    }
                }

                if (jIndex != lIndex)
                {
                    Pair pair = new Pair(u, v);

                    for (j = 0; j < ALength; j++)
                        if (A[j].Equals(pair))
                            break;
                    if (j == ALength)
                        A[ALength++] = pair;

                    ULength = SLength[jIndex];

                    for (u = 0; u < ULength; u++)
                        U[u] = S[jIndex, u];

                    for (u = 0; u < SLength[lIndex]; u++)
                    {
                        v = S[lIndex, u];

                        for (vFound = false, j = 0; j < ULength; j++)
                            vFound = v == U[j];

                        if (!vFound)
                            U[ULength++] = v;
                    }

                    SLength[jIndex] = ULength;

                    for (j = 0; j < ULength; j++)
                        S[jIndex, j] = U[j];
                    SLength[lIndex] = 0;
                }
            }

            return A;
        }
    }
}