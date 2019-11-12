using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LZWAlgorithms
{
    public partial class MainForm : Form
    {
        private Dictionary<int, string> dictionary;
        private List<int> indices;

        public MainForm()
        {
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            LZWCompressor comp = new LZWCompressor();

            indices = new List<int>();
            dictionary = comp.Compressor(text, ref indices);
            textBox2.Text += "Dictionary\r\n\r\n";

            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                if (kvp.Key >= 256)
                {
                    textBox2.Text += kvp.Key.ToString("D3") + "\t";
                    textBox2.Text += kvp.Value + "\r\n";
                }
            }

            textBox2.Text += "\r\nIndices\r\n\r\n";

            foreach (int index in indices)
                textBox2.Text += index.ToString() + "\r\n";

            textBox2.Text += "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dictionary != null && indices != null)
            {
                LZWDecompressor dec = new LZWDecompressor();

                textBox2.Text += dec.Decompressor(dictionary, indices) + "\r\n\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }
    }
}
