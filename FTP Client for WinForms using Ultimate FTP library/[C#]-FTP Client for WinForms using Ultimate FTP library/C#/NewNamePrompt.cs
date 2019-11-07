using System;
using System.Windows.Forms;

namespace ClientSample
{
    public partial class NewNamePrompt : Form
    {
        public NewNamePrompt(string oldName)
        {
            InitializeComponent();

            txtNewName.Text = oldName;
        }

        /// <summary>
        /// Gets the desired new name.
        /// </summary>
        public string NewName
        {
            get
            {
                return txtNewName.Text;
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Check for invalid characters.
            if (NewName.Contains("/") || NewName.Contains("\\"))
            {
                MessageBox.Show("Character '/' or '\\' should not be entered", "New Name Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}