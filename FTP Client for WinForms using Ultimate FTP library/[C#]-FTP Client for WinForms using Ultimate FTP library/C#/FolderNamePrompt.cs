using System;
using System.Windows.Forms;

namespace ClientSample
{
    /// <summary>
    /// A form that prompts for folder name.
    /// </summary>
    public partial class FolderNamePrompt : Form
    {
        /// <summary>
        /// Initializes a new instance of the form.
        /// </summary>
        public FolderNamePrompt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the desired folder name.
        /// </summary>
        public string FolderName
        {
            get
            {
                return txtFolderName.Text;
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Show error if the folder name is empty.
            if (FolderName.Length == 0)
            {
                MessageBox.Show("Folder name cannot be empty", "Ftp Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Show error if the folder name contains one or more invalid characters.
            if (FolderName.Contains("/") || FolderName.Contains("\\"))
            {
                MessageBox.Show("Character '/' or '\\' should not be entered", "Ftp Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}