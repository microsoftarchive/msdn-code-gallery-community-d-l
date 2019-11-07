using System;
using System.Collections.Generic;

namespace TopoSort
{
    class DepthFirstSearch
    {
        private int time;
        private int[] pi;

        private void DFSVisit(Node u)
        {
            u.Color = Colors.GRAY;
            u.Discovery = ++time;

            if (u.Adjacency != null)
            {
                for (int i = 0; i < u.Adjacency.Count; i++)
                {
                    Node v = u.Adjacency[i];

                    if (v.Color == Colors.WHITE)
                    {
                        pi[v.Id] = u.Id;
                        DFSVisit(v);
                    }
                }

            }

            u.Color = Colors.BLACK;
            u.Finish = ++time;
        }

        public void DFS(List<Node> G)
        {
            pi = new int[G.Count];

            for (int i = 0; i < G.Count; i++)
            {
                Node u = G[i];

                u.Color = Colors.WHITE;
                pi[u.Id] = -1;
            }

            time = 0;

            for (int i = 0; i < G.Count; i++)
            {
                Node u = G[i];

                if (u.Color == Colors.WHITE)
                    DFSVisit(u);
            }
        }

        public List<Node> TopologicalSort(List<Node> G)
        {
            List<Node> ln = new List<Node>();

            DFS(G);

            for (int i = 0; i < G.Count; i++)
            {
                int j = 0;
                Node u = G[i];

                while (j < ln.Count)
                {
                    if (ln[j].Finish < u.Finish)
                        j++;

                    else
                        break;
                }

                ln.Insert(j, u);
            }
                    
            return ln;
        }
    }
}