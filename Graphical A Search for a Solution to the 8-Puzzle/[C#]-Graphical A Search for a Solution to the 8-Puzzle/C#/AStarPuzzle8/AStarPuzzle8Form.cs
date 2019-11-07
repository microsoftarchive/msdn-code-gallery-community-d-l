using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AStarPuzzle8
{
    public partial class AStarPuzzle8Form : Form
    {
        char[] positions;
        char[,] solution;
        int move = 0, moves;

        void PaintPanel(Object obj, PaintEventArgs pea)
        {
            int W = panel1.Width - 16;
            int H = panel1.Height - 16;
            int w = W / 3 - 8, x;
            int h = H / 3 - 8, y = 16;
            Brush brush = new SolidBrush(Color.White);
            Brush fontBrush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericMonospace, (float) (h - 64), FontStyle.Bold);
            Graphics g = pea.Graphics;
            Pen pen = new Pen(Color.Black);

            g.DrawRectangle(pen, 8, 8, W, H);

            for (int i = 0; i < 3; i++)
            {
                x = 16;

                for (int j = 0; j < 3; j++)
                {
                    g.FillRectangle(brush, x, y, w, h);

                    char p = positions[3 * i + j];

                    g.DrawString(p.ToString(), font, fontBrush, x + 6, y + 6);
 
                    x += w + 8;
                }

                y += h + 8;
            }
        }

        void ButtonOnClick(Object obj, EventArgs ea)
        {
            if (move < moves)
            {
                for (int i = 0; i < 9; i++)
                    positions[i] = solution[move, i];

                move++;
                panel1.Invalidate();
                textBox1.Text = move.ToString();
            }

            else
                button1.Enabled = false;
        }

        public AStarPuzzle8Form()
        {
            positions = new char[9];
            solution = new char[PuzzleASCS.MaxMoves + 1, 9];

            do
            {
                PuzzleASCS puzzle = new PuzzleASCS();
                moves = puzzle.solve(ref solution);
            } while (moves == PuzzleASCS.MaxMoves);

            for (int i = 0; i < 9; i++)
                positions[i] = solution[0, i];

            InitializeComponent();

            button1.Click += new EventHandler(ButtonOnClick);
            panel1.Paint += new PaintEventHandler(PaintPanel);
            textBox2.Text = moves.ToString();
        }
    }
}
