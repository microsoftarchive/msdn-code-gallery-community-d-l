using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TopoSort
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DoWork();
        }

        List<Node> GenerateGraph()
        {
            Node u = new Node(0, 0, 0, "u", null);
            Node v = new Node(0, 0, 1, "v", null);
            Node w = new Node(0, 0, 2, "w", null);
            Node x = new Node(0, 0, 3, "x", null);
            Node y = new Node(0, 0, 4, "y", null);
            Node z = new Node(0, 0, 5, "z", null);

            u.Adjacency = new List<Node>();
            u.Adjacency.Add(v);
            u.Adjacency.Add(x);

            v.Adjacency = new List<Node>();
            v.Adjacency.Add(y);

            w.Adjacency = new List<Node>();
            w.Adjacency.Add(y);
            w.Adjacency.Add(z);

            x.Adjacency = new List<Node>();
            x.Adjacency.Add(v);

            y.Adjacency = new List<Node>();
            y.Adjacency.Add(x);

            z.Adjacency = new List<Node>();
            z.Adjacency.Add(z);

            List<Node> G = new List<Node>();

            G.Add(u);
            G.Add(v);
            G.Add(w);
            G.Add(x);
            G.Add(y);
            G.Add(z);

            return G;
        }

        void DoWork()
        {
            List<Node> G = GenerateGraph();
            DepthFirstSearch dfs = new DepthFirstSearch();

            dfs.DFS(G);

            textBox1.Text = "Node d/f\r\n\r\n";

            for (int i = 0; i < G.Count; i++)
            {
                Node a = G[i];

                textBox1.Text += a.Name + "\t";
                textBox1.Text += a.Discovery + "/";
                textBox1.Text += a.Finish + "\r\n";
            }

            textBox1.Text += "\r\n";

            G = GenerateGraph();

            List<Node> ln = dfs.TopologicalSort(G);

            textBox1.Text += "Node d/f\r\n\r\n";

            for (int i = ln.Count - 1; i >= 0; i--)
            {
                Node a = ln[i];

                textBox1.Text += a.Name + "\t";
                textBox1.Text += a.Discovery + "/";
                textBox1.Text += a.Finish + "\r\n";
            }
        }
    }
}