using System;
using System.Windows.Forms;

namespace FloydWarshall
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Algorithm algo = new Algorithm();
            int n = 5, Inf = int.MaxValue / 2;
            int[,] W = {
                       {0, 3, 8, Inf, -4},
                       {Inf, 0, Inf, 1, 7},
                       {Inf, 4, 0, Inf, Inf},
                       {2, Inf, -5, 0, Inf},
                       {Inf, Inf, Inf, 6, 0}};

            int[,] D = algo.FloydWarshall(W, n, textBox1);
        }
    }
}
