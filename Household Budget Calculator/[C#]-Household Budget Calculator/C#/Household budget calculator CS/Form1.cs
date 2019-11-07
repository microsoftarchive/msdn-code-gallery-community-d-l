using System;
using System.Collections.Generic;
//using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace Household_budget_calculator_CS
{
    [System.Serializable()]
    public partial class Form1 : Form
    {

        #region "     Variables"


        Dictionary<string, decimal> propertiesDictionary = new Dictionary<string, decimal>();

        public properties props = new properties();
        Color[] barColors = {
		Color.FromArgb(215, 215, 195),
		Color.FromArgb(200, 220, 240),
		Color.FromArgb(210, 220, 230),
		Color.FromArgb(255, 225, 215),
		Color.FromArgb(245, 245, 225),
		Color.FromArgb(235, 225, 235),
		Color.FromArgb(220, 240, 245),
		Color.FromArgb(255, 240, 225),
		Color.FromArgb(200, 240, 240),
		Color.FromArgb(170, 175, 195)

	};

        GraphicsPath[] rgns = new GraphicsPath[10];

        string openFileName = "Untitled.budget";
        private struct openedState
        {
            public decimal d1;
            public decimal d2;
            public decimal d3;
            public decimal d4;
            public decimal d5;
            public decimal d6;
            public decimal d7;
            public decimal d8;
            public decimal d9;
            public decimal d10;
        }


        openedState original = new openedState();
        #endregion

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            PictureBox1.Paint += PictureBox1_Paint;
            PictureBox1.MouseMove += PictureBox1_MouseMove;
            //Load += Form1_Load;
            FormClosing += Form1_FormClosing;
        }

        #region "     Form"

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (hasChanged())
            {
                DialogResult response = MessageBox.Show("Budget has changes. Save it now?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {
                    SaveAsToolStripMenuItem.PerformClick();
                }
                else if (response == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }


        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            PropertyGrid1.SelectedObject = props;
            propertiesDictionary.Add("Total Income", 0);
            propertiesDictionary.Add("Household", 0);
            propertiesDictionary.Add("Transport", 0);
            propertiesDictionary.Add("Finance", 0);
            propertiesDictionary.Add("Leisure", 0);
            propertiesDictionary.Add("Regular Bills", 0);
            propertiesDictionary.Add("Insurance", 0);
            propertiesDictionary.Add("Children", 0);
            propertiesDictionary.Add("Other Bills", 0);
            propertiesDictionary.Add("Remaining", 0);

            original.d1 = 0;
            original.d2 = 0;
            original.d3 = 0;
            original.d4 = 0;
            original.d5 = 0;
            original.d6 = 0;
            original.d7 = 0;
            original.d8 = 0;
            original.d9 = 0;
            original.d10 = 0;

            this.Text = string.Format("{0} - Household Budget Calculator", openFileName);

            props.propertiesChanged += props_propertiesChanged;

            if (Properties.Settings.Default.recentFiles == null)
            {
                Properties.Settings.Default.recentFiles = new System.Collections.Specialized.StringCollection();
            }

            reOrderRecentFiles();

            if (!System.IO.Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Saved Budgets")))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Saved Budgets"));
            }

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, PictureBox1.Left, PictureBox1.Bottom, PictureBox1.Left + 490, PictureBox1.Bottom);
        }

        #endregion

        #region "     Methods/Functions"

        private bool hasChanged()
        {
            return original.d1 != propertiesDictionary["Total Income"] || original.d2 != propertiesDictionary["Household"] || original.d3 != propertiesDictionary["Transport"] || original.d4 != propertiesDictionary["Finance"] || original.d5 != propertiesDictionary["Leisure"] || original.d6 != propertiesDictionary["Regular Bills"] || original.d7 != propertiesDictionary["Insurance"] || original.d8 != propertiesDictionary["Children"] || original.d9 != propertiesDictionary["Other Bills"] || original.d10 != propertiesDictionary["Remaining"];
        }

        private void reOrderRecentFiles()
        {
            bool hasItems = false;
            for (int x = FileToolStripMenuItem.DropDownItems.Count - 1; x >= 0; x += -1)
            {
                if (FileToolStripMenuItem.DropDownItems[x].Tag != null)
                {
                    FileToolStripMenuItem.DropDownItems.RemoveAt(x);
                    hasItems = true;
                }
            }
            if (hasItems)
            {
                FileToolStripMenuItem.DropDownItems.RemoveAt(2);
            }
            for (int x = Properties.Settings.Default.recentFiles.Count - 1; x >= 0; x += -1)
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.recentFiles[x].Trim()))
                {
                    Properties.Settings.Default.recentFiles.RemoveAt(x);
                }
            }
            int insertAt = 3;
            if (Properties.Settings.Default.recentFiles.Count > 0)
            {
                ToolStripSeparator tss = new ToolStripSeparator();
                FileToolStripMenuItem.DropDownItems.Insert(3, tss);
            }
            for (int x = Properties.Settings.Default.recentFiles.Count - 1; x >= 0; x += -1)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem(System.IO.Path.GetFileName(Properties.Settings.Default.recentFiles[x]), null, recentFile_Clicked) { Tag = Properties.Settings.Default.recentFiles[x] };
                FileToolStripMenuItem.DropDownItems.Insert(insertAt, tsi);
                insertAt += 1;
            }
        }


        private void openBudget(string fileName)
        {
            if (hasChanged())
            {
                DialogResult response = MessageBox.Show("Budget has changes. Save it now?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {

                    SaveAsToolStripMenuItem.PerformClick();
                }
                else if (response == DialogResult.Cancel)
                {
                    return;
                }
            }

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
            props = (properties)formatter.Deserialize(fs);
            fs.Close();
            openFileName = System.IO.Path.GetFileName(fileName);
            PropertyGrid1.SelectedObject = props;

            props.removeEventHandlers();
            props.addEventHandlers();

            props.propertiesChanged += props_propertiesChanged;

            decimal decValue = default(decimal);
            decimal.TryParse(props.totalIncome, NumberStyles.Currency, CultureInfo.CurrentCulture, out decValue);
            propertiesDictionary["Total Income"] = decValue;
            propertiesDictionary["Household"] = props.houseHold.totalHousehold;
            propertiesDictionary["Transport"] = props.transport.totalTransport;
            propertiesDictionary["Finance"] = props.finance.totalFinance;
            propertiesDictionary["Leisure"] = props.leisure.totalLeisure;
            propertiesDictionary["Regular Bills"] = props.regularBills.totalRegularBills;
            propertiesDictionary["Insurance"] = props.insurance.totalInsurance;
            propertiesDictionary["Children"] = props.children.totalChildren;
            propertiesDictionary["Other Bills"] = props.otherBills.totalOtherBills;
            if (propertiesDictionary["Total Income"] != 0)
            {
                propertiesDictionary["Remaining"] = propertiesDictionary["Total Income"] - propertiesDictionary.Values.Skip(1).Take(8).Sum();
            }
            else
            {
                propertiesDictionary["Remaining"] = 0;
            }
            PictureBox1.Invalidate();

            original.d1 = propertiesDictionary["Total Income"];
            original.d2 = propertiesDictionary["Household"];
            original.d3 = propertiesDictionary["Transport"];
            original.d4 = propertiesDictionary["Finance"];
            original.d5 = propertiesDictionary["Leisure"];
            original.d6 = propertiesDictionary["Regular Bills"];
            original.d7 = propertiesDictionary["Insurance"];
            original.d8 = propertiesDictionary["Children"];
            original.d9 = propertiesDictionary["Other Bills"];
            original.d10 = propertiesDictionary["Remaining"];

            this.Text = string.Format("{0} - Household Budget Calculator", openFileName);
        }

        #endregion

        #region "     Menus"

        private void recentFile_Clicked(System.Object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            if (!System.IO.File.Exists(tsi.Tag.ToString()))
            {
                Properties.Settings.Default.recentFiles.Remove(tsi.Tag.ToString());
                reOrderRecentFiles();
            }
            else
            {
                openBudget(tsi.Tag.ToString());
                Properties.Settings.Default.recentFiles.Remove(tsi.Tag.ToString());
                Properties.Settings.Default.recentFiles.Add(tsi.Tag.ToString());
                reOrderRecentFiles();
            }
        }


        private void NewToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (hasChanged())
            {
                DialogResult response = MessageBox.Show("Budget has changes. Save it now?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {

                    SaveAsToolStripMenuItem.PerformClick();
                }
                else if (response == DialogResult.Cancel)
                {
                    return;
                }
            }

            props = new properties();
            props.propertiesChanged += props_propertiesChanged;
            PropertyGrid1.SelectedObject = props;
            propertiesDictionary["Total Income"] = 0;
            propertiesDictionary["Household"] = 0;
            propertiesDictionary["Transport"] = 0;
            propertiesDictionary["Finance"] = 0;
            propertiesDictionary["Leisure"] = 0;
            propertiesDictionary["Regular Bills"] = 0;
            propertiesDictionary["Insurance"] = 0;
            propertiesDictionary["Children"] = 0;
            propertiesDictionary["Other Bills"] = 0;
            propertiesDictionary["Remaining"] = 0;
            PictureBox1.Invalidate();

            original.d1 = 0;
            original.d2 = 0;
            original.d3 = 0;
            original.d4 = 0;
            original.d5 = 0;
            original.d6 = 0;
            original.d7 = 0;
            original.d8 = 0;
            original.d9 = 0;
            original.d10 = 0;

            openFileName = "Untitled.budget";
            this.Text = string.Format("{0} - Household Budget Calculator", openFileName);
        }


        private void OpenToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Household Budget files (*.budget)|*.budget",
                FilterIndex = 0,
                Title = "Choose Budget file",
                InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Saved Budgets")
            };

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openBudget(ofd.FileName);
                Properties.Settings.Default.recentFiles.Remove(ofd.FileName);
                Properties.Settings.Default.recentFiles.Add(ofd.FileName);
                reOrderRecentFiles();
            }

        }

        private void SaveAsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Household Budget files (*.budget)|*.budget",
                FilterIndex = 0,
                Title = "Save Budget file",
                InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Saved Budgets"),
                AddExtension = true,
                FileName = openFileName
            };

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                props.removeEventHandlers();
                props.propertiesChanged -= props_propertiesChanged;
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.FileStream fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create);
                formatter.Serialize(fs, props);
                fs.Close();
                openFileName = System.IO.Path.GetFileName(sfd.FileName);
                props.addEventHandlers();
                props.propertiesChanged += props_propertiesChanged;
                if (!Properties.Settings.Default.recentFiles.Contains(sfd.FileName))
                {
                    Properties.Settings.Default.recentFiles.Add(sfd.FileName);
                    if (Properties.Settings.Default.recentFiles.Count == 13)
                        Properties.Settings.Default.recentFiles.RemoveAt(0);
                    reOrderRecentFiles();
                }
                original.d1 = propertiesDictionary["Total Income"];
                original.d2 = propertiesDictionary["Household"];
                original.d3 = propertiesDictionary["Transport"];
                original.d4 = propertiesDictionary["Finance"];
                original.d5 = propertiesDictionary["Leisure"];
                original.d6 = propertiesDictionary["Regular Bills"];
                original.d7 = propertiesDictionary["Insurance"];
                original.d8 = propertiesDictionary["Children"];
                original.d9 = propertiesDictionary["Other Bills"];
                original.d10 = propertiesDictionary["Remaining"];
            }

        }

        private void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region "     PictureBox1"

        private void PictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (rgns.Any(rgn => rgn != null && rgn.IsVisible(e.X, -(PictureBox1.Height - e.Y))))
            {
                int index = Array.FindLastIndex(rgns, rgn => rgn != null && rgn.IsVisible(e.X, -(PictureBox1.Height - e.Y)));
                ToolStripStatusLabel1.Text = string.Format("{0}: {1:c2}", propertiesDictionary.ElementAt(index).Key, propertiesDictionary.ElementAt(index).Value);
            }
            else
            {
                ToolStripStatusLabel1.Text = "";
            }
        }

        private void PictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            if (propertiesDictionary["Total Income"] != 0)
            {
                int totalHeight = Convert.ToInt32(propertiesDictionary["Total Income"]);
                int topHeight = Convert.ToInt32(totalHeight * 0.05);

                // Flip vertically and scale to fit.
                float scalex = 20f;
                float scaley = Convert.ToSingle(-PictureBox1.Height / (totalHeight * 1.5));
                e.Graphics.ScaleTransform(scalex, scaley, MatrixOrder.Append);

                // Translate so (0, MAX_VALUE) maps to the origin.
                e.Graphics.TranslateTransform(0, PictureBox1.Height, MatrixOrder.Append);

                PointF[] front = {
				new PointF(0, 0),
				new PointF(0, totalHeight),
				new PointF(2, totalHeight),
				new PointF(2, 0),
				new PointF(0, 0)
			};

                PointF[] top = {
				new PointF(0, totalHeight),
				new PointF(1, totalHeight + topHeight),
				new PointF(3, totalHeight + topHeight),
				new PointF(2, totalHeight),
				new PointF(0, totalHeight)
			};

                PointF[] right = {
				new PointF(2, totalHeight),
				new PointF(3, totalHeight + topHeight),
				new PointF(3, topHeight),
				new PointF(2, 0),
				new PointF(2, totalHeight)
			};

                // Draw the histogram.
                for (int x = 0; x <= propertiesDictionary.Count - 1; x++)
                {
                    rgns[x] = new GraphicsPath();
                    int value = Convert.ToInt32(propertiesDictionary.ElementAt(x).Value);
                    if (value > 0)
                    {
                        float offsetX = Convert.ToSingle(x * 2.5);

                        PointF[] barFront = Array.ConvertAll(front, pf => new PointF(pf.X + offsetX, pf.Y));
                        barFront[1].Y = value;
                        barFront[2].Y = value;
                        e.Graphics.FillPolygon(new SolidBrush(barColors[x]), barFront);
                        e.Graphics.DrawPolygon(new Pen(Color.Black, 0), barFront);

                        rgns[x].AddPolygon(Array.ConvertAll(barFront, pf => new PointF(pf.X * scalex, pf.Y * scaley)));

                        PointF[] barTop = Array.ConvertAll(top, pf => new PointF(pf.X + offsetX, value));
                        barTop[1].Y += topHeight;
                        barTop[2].Y += topHeight;
                        e.Graphics.FillPolygon(new SolidBrush(barColors[x]), barTop);
                        e.Graphics.DrawPolygon(new Pen(Color.Black, 0), barTop);

                        rgns[x].AddPolygon(Array.ConvertAll(barTop, pf => new PointF(pf.X * scalex, pf.Y * scaley)));

                        PointF[] barRight = Array.ConvertAll(right, pf => new PointF(pf.X + offsetX, pf.Y));
                        barRight[0].Y = value;
                        barRight[1].Y = value + topHeight;
                        barRight[4].Y = value;
                        e.Graphics.FillPolygon(new SolidBrush(barColors[x]), barRight);
                        e.Graphics.DrawPolygon(new Pen(Color.Black, 0), barRight);

                        rgns[x].AddPolygon(Array.ConvertAll(barRight, pf => new PointF(pf.X * scalex, pf.Y * scaley)));

                    }
                }

                e.Graphics.ResetTransform();

            }
            else
            {
                Array.Clear(rgns, 0, 10);
            }
        }

        #endregion

        #region "     PropertyGrid"

        private void props_propertiesChanged(propertiesChangedEventArgs e)
        {
            propertiesDictionary[e.propName] = e.newValue;
            if (propertiesDictionary["Total Income"] != 0)
            {
                propertiesDictionary["Remaining"] = propertiesDictionary["Total Income"] - propertiesDictionary.Values.Skip(1).Take(8).Sum();
            }
            else
            {
                propertiesDictionary["Remaining"] = 0;
            }
            PictureBox1.Invalidate();
        }

        #endregion

    }
}
