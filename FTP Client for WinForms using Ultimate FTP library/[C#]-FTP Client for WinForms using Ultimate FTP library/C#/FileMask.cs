using System;
using System.Windows.Forms;

namespace ClientSample
{
    public partial class FileMask : Form
    {
        public FileMask()
        {
            InitializeComponent();
        }

        public FileMask(string mask, bool expand)
        {
            InitializeComponent();

            txtFileType.Text = mask;

            this.Text = expand ? "Expand selection" : "Shrink selection";
        }

        public FileMask(string mask, string title)
        {
            InitializeComponent();

            txtFileType.Text = mask;

            this.Text = title;
        }

        public string Mask
        {
            get { return txtFileType.Text; }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Check for invalid characters.
            if (Mask.Contains("/") || Mask.Contains("\\"))
            {
                MessageBox.Show("Character '/' or '\\' should not be entered", "New Name Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}