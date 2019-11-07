/*
	Author:	Pate Williams (c) 1999

	Kruskal's minimum spanning tree algorithm.
	See _Introduction to Algorithms_ by T. H.
	Cormen et al. Section 24.2 pages 504 - 510.
	Especailly see Figure 24.4 pages 506 - 507.

	Program output:

	The edges of the minimum spanning tree:

	(6, 7)
	(2, 8)
	(5, 6)
	(2, 5)
	(0, 1)
	(2, 3)
	(0, 7)
	(3, 4)
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kruskal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Adjacency adjacency = new Adjacency(9);

            adjacency.setElementAt(true, 0, 1);
            adjacency.setElementAt(true, 0, 7);
            adjacency.setElementAt(true, 1, 2);
            adjacency.setElementAt(true, 1, 7);
            adjacency.setElementAt(true, 2, 3);
            adjacency.setElementAt(true, 2, 5);
            adjacency.setElementAt(true, 2, 8);
            adjacency.setElementAt(true, 3, 4);
            adjacency.setElementAt(true, 3, 5);
            adjacency.setElementAt(true, 4, 5);
            adjacency.setElementAt(true, 5, 6);
            adjacency.setElementAt(true, 6, 7);
            adjacency.setElementAt(true, 6, 8);
            adjacency.setElementAt(true, 7, 8);
            adjacency.setWeight(0, 1, 4);
            adjacency.setWeight(0, 7, 8);
            adjacency.setWeight(1, 2, 8);
            adjacency.setWeight(1, 7, 11);
            adjacency.setWeight(2, 3, 7);
            adjacency.setWeight(2, 5, 4);
            adjacency.setWeight(2, 8, 2);
            adjacency.setWeight(3, 4, 9);
            adjacency.setWeight(3, 5, 14);
            adjacency.setWeight(4, 5, 10);
            adjacency.setWeight(5, 6, 2);
            adjacency.setWeight(6, 7, 1);
            adjacency.setWeight(6, 8, 6);
            adjacency.setWeight(7, 8, 7);

            KruskalMST mst = new KruskalMST();
            Pair[] A = mst.MSTKruskal(9, adjacency);

            textBox1.Text = "The edges of the minimum spanning tree:\r\n\r\n";
            for (int i = 0; i < A.Length; i++)
                if (A[i] != null)
                    textBox1.Text += A[i].ToString() + "\r\n";
        }
    }
}
