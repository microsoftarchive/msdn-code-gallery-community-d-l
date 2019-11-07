using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    class Graph
    {
        private List<int> d;
        private List<int> pi;
        private List<Vertex> v;

        public List<int> D
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
            }
        }

        public List<int> Pi
        {
            get
            {
                return pi;
            }
            set
            {
                pi = value;
            }
        }

        public List<Vertex> V
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

        public Graph()
        {
            d = new List<int>();
            pi = new List<int>();
            v = new List<Vertex>();
        }

        public Graph(Graph copy)
        {
            d = new List<int>();
            pi = new List<int>();
            v = new List<Vertex>();

            for (int i = 0; i < copy.d.Count; i++)
                d.Add(copy.d[i]);

            for (int i = 0; i < copy.pi.Count; i++)
                pi.Add(copy.pi[i]);

            for (int i = 0; i < copy.v.Count; i++)
                v.Add(copy.v[i]);
        }
    }
}