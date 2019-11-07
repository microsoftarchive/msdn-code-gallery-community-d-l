using System;

namespace Kruskal
{
    class Edge
    {
        int u, v, weight;

        public Edge()
        {
            u = v = weight = 0;
        }

        public Edge(int u, int v, int weight)
        {
            this.u = u;
            this.v = v;
            this.weight = weight;
        }

        public int U
        {
            get
            {
                return u;
            }
            set
            {
                u = value;
            }
        }

        public int V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
    }
}