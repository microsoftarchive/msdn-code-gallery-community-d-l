using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace WindowsFormsApplication27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            label5.Font = new System.Drawing.Font(label5.Font, FontStyle.Regular);
            axWindowsMediaPlayer1.Hide();
            axWindowsMediaPlayer1.settings.volume = 100;
        }
        
        private SpeechSynthesizer speak = new SpeechSynthesizer();
        string songname = @"C:\Users\G. KUMAR\Documents\Visual Studio 2012\Projects\WindowsFormsApplication27\WindowsFormsApplication27\ipl-final-23.mp3";
        private Timer tm = new Timer();
        string times, temp1, temp2, temp3, temp4;
        int tempmin;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            tm.Tick += new EventHandler(tm_Tick);
            tm.Enabled = true;
        }
        
        void tm_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            label1.Text = time.ToString("T");
            label4.Text = time.ToString("D");
            times = label1.Text;
            getalarm();
        }

        public void getalarm() 
        {
            char[] temptime = times.ToCharArray();
            temp1 = temptime[0].ToString() + temptime[1].ToString();//hh
            temp2 = temptime[3].ToString() + temptime[4].ToString();//mm
            temp3 = temptime[6].ToString() + temptime[7].ToString();//ss
            temp4 = temptime[9].ToString() + temptime[10].ToString();//pm am
            if (temp1 == comboBox1.Text && temp2 == comboBox2.Text && temp4 == comboBox3.Text && temp3 == "00")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\G. KUMAR\Documents\Visual Studio 2012\Projects\WindowsFormsApplication27\WindowsFormsApplication27\smiling.gif");
                speak.Speak("\t your important message \t is \t \t\t\n\n\n" + textBox1.Text+"\t\t\t\t\t\t\n\n\n\n");
                axWindowsMediaPlayer1.URL = songname;
                tempmin = Convert.ToInt32(comboBox2.Text);
                tempmin += 2;
                comboBox2.Text = tempmin.ToString();
            }
            else 
            {
            
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
                textBox1.Enabled = false;
                panel1.Hide();
                label5.Font = new System.Drawing.Font(label5.Font, FontStyle.Bold);
            }
            else 
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\G. KUMAR\Documents\Visual Studio 2012\Projects\WindowsFormsApplication27\WindowsFormsApplication27\1.ico");
                comboBox1.Enabled = true;
                comboBox1.SelectedIndex = -1;
                comboBox2.Enabled = true;
                comboBox2.SelectedIndex = -1;
                comboBox3.Enabled = true;
                comboBox3.SelectedIndex = -1;
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
                textBox1.Text = "";
                axWindowsMediaPlayer1.URL = null;
                label5.Font = new System.Drawing.Font(label5.Font, FontStyle.Regular);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Show();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.Filter = "mp3 files (*.mp3)|*.mp3";
            if (dg.ShowDialog() == DialogResult.OK)
            {
                songname = dg.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            songname = @"C:\Users\G. KUMAR\Documents\Visual Studio 2012\Projects\WindowsFormsApplication27\WindowsFormsApplication27\ipl-final-23.mp3";
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button2_MouseMove_1(object sender, MouseEventArgs e)
        {
            panel1.Show();
        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            panel1.Show();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Show();
        }
    }
}
