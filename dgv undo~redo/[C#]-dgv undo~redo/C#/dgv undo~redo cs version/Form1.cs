using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
        public partial class Form1 : Form
    {

        Stack<object[][]> undoStack = new Stack<object[][]>();
        Stack<object[][]> redoStack = new Stack<object[][]>();

        Boolean ignore = false;

        public Form1()
        {
            InitializeComponent();
            DataGridView1.CellValidated += DataGridView1_CellValidated;
            ToolStripButton2.Click += ToolStripButton2_Click;
            UndoToolStripButton.Click += UndoToolStripButton_Click;
            RedoToolStripButton.Click += RedoToolStripButton_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int r = 1; r <= 10; r++)
            {
                DataGridView1.Rows.Add(string.Format("R{0}C1", r), string.Format("R{0}C2", r), string.Format("R{0}C3", r));
            }
        }

        private void DataGridView1_CellValidated(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (ignore) { return ; }
            if (undoStack.NeedsItem(DataGridView1))
            {
                undoStack.Push(DataGridView1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).Select(r => r.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray()).ToArray());
            }
            UndoToolStripButton.Enabled = undoStack.Count > 1;
        }

        private void ToolStripButton2_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void UndoToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            if (redoStack.Count == 0 || redoStack.NeedsItem(DataGridView1))
            {
                redoStack.Push(DataGridView1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).Select(r => r.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray()).ToArray());
            }
            object[][] rows = undoStack.Pop();
            while (rows.ItemEquals(DataGridView1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).ToArray()))
            {
                rows = undoStack.Pop();
            }
            ignore = true;
            DataGridView1.Rows.Clear();
            for (int x = 0; x <= rows.GetUpperBound(0); x++)
            {
                DataGridView1.Rows.Add(rows[x]);
            }
            ignore = false;
            UndoToolStripButton.Enabled = undoStack.Count > 0;
            RedoToolStripButton.Enabled = redoStack.Count > 0;
        }

        private void RedoToolStripButton_Click(System.Object sender, System.EventArgs e)
        {
            if (undoStack.Count == 0 || undoStack.NeedsItem(DataGridView1))
            {
                undoStack.Push(DataGridView1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).Select(r => r.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray()).ToArray());
            }
            object[][] rows = redoStack.Pop();
            while (rows.ItemEquals(DataGridView1.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).ToArray()))
            {
                rows = redoStack.Pop();
            }
            ignore = true;
            DataGridView1.Rows.Clear();
            for (int x = 0; x <= rows.GetUpperBound(0); x++)
            {
                DataGridView1.Rows.Add(rows[x]);
            }
            ignore = false;
            RedoToolStripButton.Enabled = redoStack.Count > 0;
            UndoToolStripButton.Enabled = undoStack.Count > 0;
        }

    }
}
