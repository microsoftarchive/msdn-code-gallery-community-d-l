using System;
using System.Windows.Forms;

namespace ClientSample.Ftp
{
    /// <summary>
    /// A form that prompts for FTP command.
    /// </summary>
    public partial class ExecCommand : Form
    {
        /// <summary>
        /// Initializes a new instance of the form.
        /// </summary>
        public ExecCommand()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the desired folder name.
        /// </summary>
        public string Command
        {
            get
            {
                return txtCommand.Text;
            }
            set
            {
                txtCommand.Text = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtCommand.SelectAll();
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Show error if the command is empty.
            if (Command.Trim().Length == 0)
            {
                MessageBox.Show("Command cannot be empty", Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}