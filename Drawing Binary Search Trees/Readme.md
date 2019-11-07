# Drawing Binary Search Trees
## Requires
- Visual Studio 2008
## License
- MIT
## Technologies
- C#
- Visual Studio 2008
- Windows Forms
- Visual C#
## Topics
- C#
- Algorithm
- Data Structures
- Binary Search Tree
## Updated
- 10/12/2015
## Description

<h1>Introduction</h1>
<p><em>This application draws a randomly generated binary search tree with 5 or 10 or 15 or 20 nodes. The code for the binary trees is by Scott Mitchell. The simple code to draw the binary search tree is by an unknown to me author at Columbia University and
 originally written in Java. Translation from Java to C# is rather facile.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This project should build as is using Visual Studio 2008.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This program draws binary trees by inorder traversals of binary search trees. There are three distinct types of binary tree traversal preorder, inorder, and postorder. In inorder traversal visit the left node, vist node, then visit right node recursively.
 In preorder traversal visit the node, visit the left node, then visit the right node recursively. The postorder trranversal is similarly defined recursively. The form is started in its maximized state. You can resize the form.<br>
</em></p>
<p><em><img id="143556" src="143556-drawbinarytree%2015%20a.jpg" alt="" width="698" height="543">&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// code to draw the binary tree from
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
        private BinaryTreeNode&lt;int&gt; root;
        private List&lt;int&gt; data;
        private Pen blackPen;
        private SolidBrush blackBrush;

        private void GenerateData(int n)
        {
            bool[] used = new bool[n];
            Random random = new Random((int)DateTime.Now.Ticks);

            data = new List&lt;int&gt;();

            for (int i = 0; i &lt; n; i&#43;&#43;)
            {
                int number = random.Next(n);

                while (used[number])
                    number = random.Next(n);

                data.Add(number);
                used[number] = true;
            }
        }

        private void InorderTraversal(BinaryTreeNode&lt;int&gt; t, int depth)
        {
            if (t != null)
            {
                InorderTraversal(t.Left, depth &#43; 1); //add 1 to depth (y coordinate) 
                t.Xpos = totalNodes&#43;&#43; &#43; 1; //x coord is node number in inorder traversal
                t.Ypos = depth - 1; // mark y coord as depth
                InorderTraversal(t.Right, depth &#43; 1);
            }
        }

        private void ComputeNodePositions()
        {
            int depth = 1;

            InorderTraversal(root, depth);
        }

        private int TreeHeight(BinaryTreeNode&lt;int&gt; t)
        {
            if (t == null) return -1;
            else return 1 &#43; Math.Max(TreeHeight(t.Left), TreeHeight(t.Right));
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
            panel1.Paint &#43;= new PaintEventHandler(panel1_Paint);
            panel1.SizeChanged &#43;= new EventHandler(panel1_SizeChanged);
            panel1.Font = new Font(&quot;SansSerif&quot;, 20.0f, FontStyle.Bold);
            blackPen = new Pen(Color.Black);
            blackBrush = new SolidBrush(Color.Black);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        public void DrawTree(BinaryTreeNode&lt;int&gt; root, Graphics g)
        {
            panel1.Width = ClientSize.Width - 8;
            panel1.Height = ClientSize.Height - 8;

            int Width = panel1.Width;
            int Height = panel1.Height;
            int dx = 0, dy = 0, dx2 = 0, dy2 = 0, ys = 20;
            int XSCALE, YSCALE;
            int treeHeight = TreeHeight(root);

            XSCALE = (int)(Width / totalNodes); //scale x by total nodes in tree
            YSCALE = (int)((Height - ys) / (maxTreeHeight &#43; 1)); //scale y by tree height

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
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;code&nbsp;to&nbsp;draw&nbsp;the&nbsp;binary&nbsp;tree&nbsp;from</span>&nbsp;
<span class="cs__com">//&nbsp;Columbia&nbsp;University&nbsp;in&nbsp;Java</span>&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DrawBinaryTree&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainForm&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;maxTreeHeight,&nbsp;totalNodes;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;IntBinaryTree&nbsp;intRoot;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;BinaryTreeNode&lt;<span class="cs__keyword">int</span>&gt;&nbsp;root;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Pen&nbsp;blackPen;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SolidBrush&nbsp;blackBrush;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;GenerateData(<span class="cs__keyword">int</span>&nbsp;n)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>[]&nbsp;used&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">bool</span>[n];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;random&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random((<span class="cs__keyword">int</span>)DateTime.Now.Ticks);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;n;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;number&nbsp;=&nbsp;random.Next(n);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(used[number])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;number&nbsp;=&nbsp;random.Next(n);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.Add(number);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;used[number]&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InorderTraversal(BinaryTreeNode&lt;<span class="cs__keyword">int</span>&gt;&nbsp;t,&nbsp;<span class="cs__keyword">int</span>&nbsp;depth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(t&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InorderTraversal(t.Left,&nbsp;depth&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;<span class="cs__com">//add&nbsp;1&nbsp;to&nbsp;depth&nbsp;(y&nbsp;coordinate)&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;t.Xpos&nbsp;=&nbsp;totalNodes&#43;&#43;&nbsp;&#43;&nbsp;<span class="cs__number">1</span>;&nbsp;<span class="cs__com">//x&nbsp;coord&nbsp;is&nbsp;node&nbsp;number&nbsp;in&nbsp;inorder&nbsp;traversal</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;t.Ypos&nbsp;=&nbsp;depth&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;<span class="cs__com">//&nbsp;mark&nbsp;y&nbsp;coord&nbsp;as&nbsp;depth</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InorderTraversal(t.Right,&nbsp;depth&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ComputeNodePositions()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;depth&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InorderTraversal(root,&nbsp;depth);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;TreeHeight(BinaryTreeNode&lt;<span class="cs__keyword">int</span>&gt;&nbsp;t)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(t&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__number">1</span>&nbsp;&#43;&nbsp;Math.Max(TreeHeight(t.Left),&nbsp;TreeHeight(t.Right));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateTree(<span class="cs__keyword">int</span>&nbsp;n)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GenerateData(n);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intRoot&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IntBinaryTree(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;root&nbsp;=&nbsp;intRoot.IntRoot;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalNodes&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComputeNodePositions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;maxTreeHeight&nbsp;=&nbsp;TreeHeight(root);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainForm()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WindowState&nbsp;=&nbsp;FormWindowState.Maximized;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Paint&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PaintEventHandler(panel1_Paint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.SizeChanged&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler(panel1_SizeChanged);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Font&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Font(<span class="cs__string">&quot;SansSerif&quot;</span>,&nbsp;<span class="cs__number">20</span>.0f,&nbsp;FontStyle.Bold);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blackPen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.Black);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blackBrush&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidBrush(Color.Black);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;panel1_SizeChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DrawTree(BinaryTreeNode&lt;<span class="cs__keyword">int</span>&gt;&nbsp;root,&nbsp;Graphics&nbsp;g)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Width&nbsp;=&nbsp;ClientSize.Width&nbsp;-&nbsp;<span class="cs__number">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Height&nbsp;=&nbsp;ClientSize.Height&nbsp;-&nbsp;<span class="cs__number">8</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Width&nbsp;=&nbsp;panel1.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Height&nbsp;=&nbsp;panel1.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;dx&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;dy&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;dx2&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;dy2&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;ys&nbsp;=&nbsp;<span class="cs__number">20</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;XSCALE,&nbsp;YSCALE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;treeHeight&nbsp;=&nbsp;TreeHeight(root);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XSCALE&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(Width&nbsp;/&nbsp;totalNodes);&nbsp;<span class="cs__com">//scale&nbsp;x&nbsp;by&nbsp;total&nbsp;nodes&nbsp;in&nbsp;tree</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;YSCALE&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)((Height&nbsp;-&nbsp;ys)&nbsp;/&nbsp;(maxTreeHeight&nbsp;&#43;&nbsp;<span class="cs__number">1</span>));&nbsp;<span class="cs__com">//scale&nbsp;y&nbsp;by&nbsp;tree&nbsp;height</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(root&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;inorder&nbsp;traversal&nbsp;to&nbsp;draw&nbsp;each&nbsp;node</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawTree(root.Left,&nbsp;g);&nbsp;<span class="cs__com">//&nbsp;do&nbsp;left&nbsp;side&nbsp;of&nbsp;inorder&nbsp;traversal&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dx&nbsp;=&nbsp;root.Xpos&nbsp;*&nbsp;XSCALE;&nbsp;<span class="cs__com">//&nbsp;get&nbsp;x,y&nbsp;coords.,&nbsp;and&nbsp;scale&nbsp;them&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dy&nbsp;=&nbsp;root.Ypos&nbsp;*&nbsp;YSCALE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;root.Value.ToString();&nbsp;<span class="cs__com">//get&nbsp;the&nbsp;word&nbsp;at&nbsp;this&nbsp;node</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(s,&nbsp;panel1.Font,&nbsp;blackBrush,&nbsp;<span class="cs__keyword">new</span>&nbsp;PointF(dx&nbsp;-&nbsp;ys,&nbsp;dy));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;this&nbsp;draws&nbsp;the&nbsp;lines&nbsp;from&nbsp;a&nbsp;node&nbsp;to&nbsp;its&nbsp;children,&nbsp;if&nbsp;any</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(root.Left&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//draws&nbsp;the&nbsp;line&nbsp;to&nbsp;left&nbsp;child&nbsp;if&nbsp;it&nbsp;exists</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dx2&nbsp;=&nbsp;root.Left.Xpos&nbsp;*&nbsp;XSCALE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dy2&nbsp;=&nbsp;root.Left.Ypos&nbsp;*&nbsp;YSCALE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawLine(blackPen,&nbsp;dx,&nbsp;dy,&nbsp;dx2,&nbsp;dy2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(root.Right&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//draws&nbsp;the&nbsp;line&nbsp;to&nbsp;right&nbsp;child&nbsp;if&nbsp;it&nbsp;exists</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dx2&nbsp;=&nbsp;root.Right.Xpos&nbsp;*&nbsp;XSCALE;<span class="cs__com">//get&nbsp;right&nbsp;child&nbsp;x,y&nbsp;scaled&nbsp;position</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dy2&nbsp;=&nbsp;root.Right.Ypos&nbsp;*&nbsp;YSCALE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawLine(blackPen,&nbsp;dx,&nbsp;dy,&nbsp;dx2,&nbsp;dy2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawTree(root.Right,&nbsp;g);&nbsp;<span class="cs__com">//now&nbsp;do&nbsp;right&nbsp;side&nbsp;of&nbsp;inorder&nbsp;traversal&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;panel1_Paint(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;PaintEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(root&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawTree(root,&nbsp;e.Graphics);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;toolStripMenuItem2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateTree(<span class="cs__number">5</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;toolStripMenuItem3_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateTree(<span class="cs__number">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;toolStripMenuItem4_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateTree(<span class="cs__number">15</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;toolStripMenuItem5_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateTree(<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>BinaryTreeNode.cs - Scott Mitchell code.</em> </li><li><em><em>IntBinaryTree.cs - an integer binary tree based on the generic BinaryTreeNode.</em></em>
</li><li><em>MainForm.cs - the main and only form of this application has a menu for input.</em>
</li><li><em>Node.cs - Scott Mitchell code.</em> </li><li><em>NodeList.cs - Scott Mitchell code updated for version 3.5.</em> </li><li><em>Program.cs - the Visual Studio generated program class. </em></li></ul>
<h1>More Information</h1>
<p><em>For more information on binary search trees, see any good algorithms book such as
<strong>Introduction to Algorithms</strong> by Cormen et al. Or search the web or read a good data structures textbook.<br>
</em></p>
