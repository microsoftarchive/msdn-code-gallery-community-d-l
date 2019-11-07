using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Color : Form
    {
        public Color()
        {
            InitializeComponent();
            button1.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.red = trackBar1.Value;
            Globals.green = trackBar2.Value;
            Globals.blue = trackBar3.Value;

            Globals.isValid = true;

            this.Close();
        }

        private void Color_Load(object sender, EventArgs e)
        {
            trackBar1.Value = Globals.red;
            trackBar2.Value = Globals.green;
            trackBar3.Value = Globals.blue;
        }
    }
}
