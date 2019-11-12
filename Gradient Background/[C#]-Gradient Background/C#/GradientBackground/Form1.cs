using System;
using System.Windows.Forms;

namespace GradientBackground
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphics = e.Graphics;
            System.Drawing.Rectangle gradient_rectangle = new System.Drawing.Rectangle(0, 0, panel1.Width, panel1.Height);
            System.Drawing.Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(gradient_rectangle, System.Drawing.Color.FromArgb(255, 0, 0), System.Drawing.Color.FromArgb(57, 128, 227), 65f);
            graphics.FillRectangle(b, gradient_rectangle);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You Want To Exit ?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gradient Background\nProgrammer : Aryan Mesgari\nRelease Date : 2017/5/25", "About Us",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
