using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    class Vertex
    {
        Node vNode;
        List<int> weights;
        List<Node> edges;

        public Node VNode
        {
            get
            {
                return vNode;
            }
        }

        public List<int> Weights
        {
            get
            {
                return weights;
            }
        }

        public List<Node> Edges
        {
            get
            {
                return edges;
            }
        }

        public Vertex(
            Node vNode,
            List<int> weights,
            List<Node> edges)
        {
            this.vNode = vNode;
            this.weights = new List<int>();
            this.edges = new List<Node>();

            for (int i = 0; i < weights.Count; i++)
                this.weights.Add(weights[i]);

            for (int i = 0; i < edges.Count; i++)
                this.edges.Add(edges[i]);
        }
    }
}