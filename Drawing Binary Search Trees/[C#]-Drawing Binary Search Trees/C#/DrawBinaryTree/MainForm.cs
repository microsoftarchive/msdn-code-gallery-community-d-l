// code to draw the binary tree from
// Columbia University in Java

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawBinaryTree
{
    public partial class MainForm : Form
    {
        private int maxTreeHeight, totalNodes;
        private IntBinaryTree intRoot;
        private BinaryTreeNode<int> root;
        private List<int> data;
        private Pen blackPen;
        private SolidBrush blackBrush;

        private void GenerateData(int n)
        {
            bool[] used = new bool[n];
            Random random = new Random((int)DateTime.Now.Ticks);

            data = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int number = random.Next(n);

                while (used[number])
                    number = random.Next(n);

                data.Add(number);
                used[number] = true;
            }
        }

        private void InorderTraversal(BinaryTreeNode<int> t, int depth)
        {
            if (t != null)
            {
                InorderTraversal(t.Left, depth + 1); //add 1 to depth (y coordinate) 
                t.Xpos = totalNodes++ + 1; //x coord is node number in inorder traversal
                t.Ypos = depth - 1; // mark y coord as depth
                InorderTraversal(t.Right, depth + 1);
            }
        }

        private void ComputeNodePositions()
        {
            int depth = 1;

            InorderTraversal(root, depth);
        }

        private int TreeHeight(BinaryTreeNode<int> t)
        {
            if (t == null) return -1;
            else return 1 + Math.Max(TreeHeight(t.Left), TreeHeight(t.Right));
        }

        private void CreateTree(int n)
        {
            GenerateData(n);
            intRoot = new IntBinaryTree(data);
            root = intRoot.IntRoot;
            totalNodes = 0;
            ComputeNodePositions();
            maxTreeHeight = TreeHeight(root);
        }

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.SizeChanged += new EventHandler(panel1_SizeChanged);
            panel1.Font = new Font("SansSerif", 20.0f, FontStyle.Bold);
            blackPen = new Pen(Color.Black);
            blackBrush = new SolidBrush(Color.Black);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        public void DrawTree(BinaryTreeNode<int> root, Graphics g)
        {
            panel1.Width = ClientSize.Width - 8;
            panel1.Height = ClientSize.Height - 8;

            int Width = panel1.Width;
            int Height = panel1.Height;
            int dx = 0, dy = 0, dx2 = 0, dy2 = 0, ys = 20;
            int XSCALE, YSCALE;
            int treeHeight = TreeHeight(root);

            XSCALE = (int)(Width / totalNodes); //scale x by total nodes in tree
            YSCALE = (int)((Height - ys) / (maxTreeHeight + 1)); //scale y by tree height

            if (root != null)
            { 
                // inorder traversal to draw each node
                DrawTree(root.Left, g); // do left side of inorder traversal 
                dx = root.Xpos * XSCALE; // get x,y coords., and scale them 
                dy = root.Ypos * YSCALE;
                string s = root.Value.ToString(); //get the word at this node
                g.DrawString(s, panel1.Font, blackBrush, new PointF(dx - ys, dy));
                // this draws the lines from a node to its children, if any
                if (root.Left != null)
                { 
                    //draws the line to left child if it exists
                    dx2 = root.Left.Xpos * XSCALE;
                    dy2 = root.Left.Ypos * YSCALE;
                    g.DrawLine(blackPen, dx, dy, dx2, dy2);
                }

                if (root.Right != null)
                { 
                    //draws the line to right child if it exists
                    dx2 = root.Right.Xpos * XSCALE;//get right child x,y scaled position
                    dy2 = root.Right.Ypos * YSCALE;
                    g.DrawLine(blackPen, dx, dy, dx2, dy2);
                }

                DrawTree(root.Right, g); //now do right side of inorder traversal 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (root != null)
                DrawTree(root, e.Graphics);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateTree(5);
            panel1.Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CreateTree(10);
            panel1.Invalidate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateTree(15);
            panel1.Invalidate();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CreateTree(20);
            panel1.Invalidate();
        }
    }
}