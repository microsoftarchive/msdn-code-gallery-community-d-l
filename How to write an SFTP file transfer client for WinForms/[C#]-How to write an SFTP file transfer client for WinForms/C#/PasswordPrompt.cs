using System;
using System.Windows.Forms;

namespace ClientSample
{
    public partial class PasswordPrompt : Form
    {
        public PasswordPrompt(string title)
        {
            InitializeComponent();

            this.Text = title;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}