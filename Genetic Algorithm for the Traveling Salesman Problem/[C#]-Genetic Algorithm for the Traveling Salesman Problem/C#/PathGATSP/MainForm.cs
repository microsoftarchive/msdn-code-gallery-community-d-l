using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PathGATSP
{
    public partial class MainForm : Form
    {
        private double[] x, y;
        private int number;
        private BackgroundWorker bw;
        private DateTime newDate, oldDate;
        private GeneticAlgorithm ga;

        public MainForm()
        {
            InitializeComponent();
            button2.Enabled = false;
            button4.Enabled = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(
                    openFileDialog1.FileName);

                string line = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    if (line.Contains("DIMENSION"))
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c >= '0' && c <= '9')
                                sb.Append(c);
                        }

                        number = int.Parse(sb.ToString());
                        
                        break;
                    }

                    line = sr.ReadLine();
                }

                x = new double[number];
                y = new double[number];
                
                int count = 0;

                line = sr.ReadLine();

                while (line != null && line.Length != 0)
                {
                    if (line[0] >= '0' && line[0] <= '9')
                    {
                        StringBuilder sb = new StringBuilder();
                        int i, j;

                        for (i = 0; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c >= '0' && c <= '9')
                                sb.Append(c);

                            else
                                break;
                        }

                        sb = new StringBuilder();

                        for (j = i + 1; j < line.Length; j++)
                        {
                            char c = line[j];

                            if (c >= '0' && c <= '9' || c == '.')
                                sb.Append(c);

                            else
                                break;
                        }

                        x[count] = double.Parse(sb.ToString());

                        sb = new StringBuilder();

                        for (i = j + 1; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c >= '0' && c <= '9' || c == '.')
                                sb.Append(c);

                            else
                                break;
                        }

                        y[count++] = double.Parse(sb.ToString());
                    }
                 
                    line = sr.ReadLine();
                }

                sr.Close();
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "&Run")
            {
                oldDate = DateTime.Now;
                int seed = int.Parse((string)comboBox3.SelectedItem);
                int generations = int.Parse((string)comboBox2.SelectedItem);
                int population = int.Parse((string)comboBox1.SelectedItem);
                double rate = double.Parse((string)comboBox5.SelectedItem);

                ga = new GeneticAlgorithm(
                    rate, x, y, generations, number, population, seed);
                bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                progressBar1.Value = 0;
                bw.RunWorkerAsync();
                while (!bw.IsBusy) { }
                button2.Text = "&Stop";
            }

            else
                bw.CancelAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ga.RunGA(bw);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.Text = string.Empty;

            for (int n = 0; n < number; n++)
                textBox1.Text += n.ToString() + "\t" +
                    ga.MinTour[n].ToString() + "\r\n";

            textBox1.Text += number.ToString() + "\t" +
                    ga.MinTour[0].ToString() + "\r\n";

            textBox1.Text += "\r\nTour Length = " +
                ga.MinDistance.ToString("F6") + "\r\n";

            newDate = DateTime.Now;
            TimeSpan ts = newDate - oldDate;

            textBox1.Text += "\r\nRuntime (Hrs:Min:Sec.MS) = ";
            textBox1.Text += ts.Hours.ToString("00") + ":";
            textBox1.Text += ts.Minutes.ToString("00") + ":";
            textBox1.Text += ts.Seconds.ToString("00") + ".";
            textBox1.Text += ts.Milliseconds.ToString("000") + "\r\n";

            button2.Text = "&Run";
            button4.Enabled = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.Text = ga.MinDistance.ToString("F0");
            textBox2.Refresh();
            textBox3.Text = ga.G.ToString();
            textBox3.Refresh();
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[] tourX = new double[number + 1];
            double[] tourY = new double[number + 1];

            for (int n = 0; n < number; n++)
            {
                tourX[n] = x[ga.MinTour[n]];
                tourY[n] = y[ga.MinTour[n]];
            }

            tourX[number] = x[ga.MinTour[0]];
            tourY[number] = y[ga.MinTour[0]];

            GraphForm gf = new GraphForm(tourX, tourY, ga.MinTour);
            gf.Show();
        }
    }
}
