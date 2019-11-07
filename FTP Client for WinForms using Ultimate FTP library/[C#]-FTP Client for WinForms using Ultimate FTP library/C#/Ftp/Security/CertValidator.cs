using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ClientSample.Ftp.Security
{
    /// <summary>
    /// Form used for showing certificate's issues and let user to decide Accept or Reject the certificate.
    /// </summary>
    public partial class CertValidator : Form
    {
        private bool _showAddToTrustedList;
        /// <summary>
        /// Gets or sets a boolean value indicating whether the button "Add To Trusted List" will be shown.
        /// </summary>
        public bool ShowAddToTrustedList
        {
            get { return _showAddToTrustedList; }
            set { _showAddToTrustedList = value; }
        }

        private bool _addToTrustedList;
        /// <summary>
        /// Gets a boolean value indicating whether the certificate will be added to the local PC's trusted list.
        /// </summary>
        public bool AddToTrustedList
        {
            get { return _addToTrustedList; }
        }

        private bool _accepted;
        /// <summary>
        /// Gets a boolean value indicating whether the certificate is accepted.
        /// </summary>
        public bool Accepted
        {
            get { return _accepted; }
        }

        private X509Certificate2 _cert;
        /// <summary>
        /// Gets or sets the certificate object.
        /// </summary>
        public X509Certificate2 Certificate
        {
            get { return _cert; }
            set { _cert = value; }
        }

        private string _issues;
        /// <summary>
        /// Gets or sets the certificate's issues.
        /// </summary>
        public string Issues
        {
            get { return _issues; }
            set { _issues = value; }
        }

        /// <summary>
        /// Handles the Trusted button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnTrusted_Click(object sender, System.EventArgs e)
        {
            _addToTrustedList = true;
            _accepted = true;
            Close();
        }

        /// <summary>
        /// Handles the Cancel button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            // User rejected this certificate and close this form.
            Close();
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            // User accepted this certificate and close this form.
            _accepted = true;
            Close();
        }

        /// <summary>
        /// Initializes a new instance of the CertValidator class.
        /// </summary>
        public CertValidator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form's Load event.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            string commonName;
            string countryCode;
            string state;
            string city;
            string organization;
            string unit;
            string email;

            CertTextExtractor.Extract(_cert.Issuer, out commonName, out countryCode, out state, out city, out organization, out unit, out email);

            // Update label controls.
            lblIssuerText.Text = organization;
            lblUnitText.Text = unit;
            lblLocationText.Text = string.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city);
            lblCommonNameText.Text = commonName;

            CertTextExtractor.Extract(_cert.Subject, out commonName, out countryCode, out state, out city, out organization, out unit, out email);

            lblOrganizationSubText.Text = organization;
            lblUnitSubText.Text = unit;
            lblLocationSubText.Text = string.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city);
            lblCommonNameSubText.Text = commonName;

            lblFromText.Text = _cert.NotBefore.ToString();
            lblToText.Text = _cert.NotAfter.ToString();

            txtIssues.Text = _issues;

            btnTrusted.Visible = _showAddToTrustedList;
        }
    }
}