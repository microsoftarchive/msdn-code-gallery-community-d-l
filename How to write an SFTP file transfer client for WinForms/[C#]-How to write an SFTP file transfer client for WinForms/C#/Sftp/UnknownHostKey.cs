using System;
using System.Windows.Forms;

namespace ClientSample.Sftp
{
    public partial class UnknownHostKey : Form
    {
        /// <summary>
        /// Gets or sets a value indicating whether to always accept the fingerprint.
        /// </summary>
        /// <value>True to accept the fingerprint; false to reject it.</value>
        public bool AlwaysAccept
        {
            get
            {
                return this._accept;
            }
        }
        private bool _accept;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownHostKey"/> class.
        /// </summary>
        /// <param name="server">The SFTP server name.</param>
        /// <param name="port">The SFTP port</param>
        /// <param name="fingerprint">The public key fingerprint.</param>
        public UnknownHostKey(string server, int port, string fingerprint)
        {
            InitializeComponent();

            lblHost.Text = server;
            lblPort.Text = port.ToString();
            lblFingerprint.Text = fingerprint;
        }

        private void btnAlwaysAccept_Click(object sender, EventArgs e)
        {
            _accept = true;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}