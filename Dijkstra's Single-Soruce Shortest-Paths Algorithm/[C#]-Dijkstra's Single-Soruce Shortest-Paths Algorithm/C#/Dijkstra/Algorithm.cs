using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Algorithm
    {
        public List<int> Dijkstra(ref int[] pi, ref List<Node> G, int s)
        {
            InitializeSingleSource(ref pi, ref G, s); 

            List<int> S = new List<int>();
            PriorityQueue Q = new PriorityQueue(G);

            Q.buildHeap();

            while (Q.size() != 0)
            {
                Node u = Q.extractMin();

                S.Add(u.Id);

                for (int i = 0; i < u.Adjacency.Count; i++)
                {
                    Node v = u.Adjacency[i];
                    int w = u.Weights[i];

                    Relax(ref pi, u, ref v, w);
                }
            }

            return S;
        }

        void InitializeSingleSource(ref int[] pi, ref List<Node> nodeList, int s)
        {
            pi = new int[nodeList.Count];

            for (int i = 0; i < pi.Length; i++)
                pi[i] = -1;

            nodeList[s].Distance = 0;
        }

        void Relax(ref int[] pi, Node u, ref Node v, int w)
        {
            if (v.Distance > u.Distance + w)
            {
                v.Distance = u.Distance + w;
                pi[v.Id] = u.Id;
            }
        }
    }
}
