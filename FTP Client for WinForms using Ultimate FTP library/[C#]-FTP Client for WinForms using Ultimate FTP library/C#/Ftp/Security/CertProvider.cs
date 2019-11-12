using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ClientSample.Ftp.Security
{
    /// <summary>
    /// Form used for selecting available certificates.
    /// </summary>
    public partial class CertProvider : Form
    {
        private X509Certificate2Collection _certs; // available certificates.
        private X509Certificate2 _selectedCertificate; // selected certificate object.

        /// <summary>
        /// Gets the selected certificate object.
        /// </summary>
        public X509Certificate2 SelectedCertificate
        {
            get
            {
                return _selectedCertificate;
            }
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public CertProvider()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            // Load certificates from the local machine.
            X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);

            // Retrieve a list of available certificates.
            X509Certificate2Collection certs = my.Certificates;

            // If no certificate found, return.
            if (certs.Count == 0)
                return;

            LoadData(certs);
        }

        /// <summary>
        /// Loads certificates and update form controls.
        /// </summary>
        /// <param name="certs"></param>
        public void LoadData(X509Certificate2Collection certs)
        {
            _certs = certs;

            // Add to the combo box.
            for (int i = 0; i < certs.Count; i++)
            {
                cbCertList.Items.Add(certs[i].SubjectName.Name);
            }

            if (certs.Count > 0)
            {
                cbCertList.SelectedIndex = 0;
                UpdateForm(certs[0]);
            }
            else
            {
                // Update label controls.
                lblOrganizationText.Text = string.Empty;
                lblUnitText.Text = string.Empty;
                lblLocationText.Text = string.Empty;
                lblCommonNameText.Text = string.Empty;

                lblOrganizationSubText.Text = string.Empty;
                lblUnitSubText.Text = string.Empty;
                lblLocationSubText.Text = string.Empty;
                lblCommonNameSubText.Text = string.Empty;

                lblFromText.Text = string.Empty;
                lblToText.Text = string.Empty;
            }
        }

        void UpdateForm(X509Certificate2 cert)
        {
            string commonName;
            string countryCode;
            string state;
            string city;
            string organization;
            string unit;
            string email;

            CertTextExtractor.Extract(cert.Issuer, out commonName, out countryCode, out state, out city, out organization, out unit, out email);

            // Update label controls.
            lblOrganizationText.Text = organization;
            lblUnitText.Text = unit;
            lblLocationText.Text = string.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city);
            lblCommonNameText.Text = commonName;

            CertTextExtractor.Extract(cert.Subject, out commonName, out countryCode, out state, out city, out organization, out unit, out email);

            lblOrganizationSubText.Text = organization;
            lblUnitSubText.Text = unit;
            lblLocationSubText.Text = string.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city);
            lblCommonNameSubText.Text = commonName;

            lblFromText.Text = cert.NotBefore.ToString();
            lblToText.Text = cert.NotAfter.ToString();
        }

        /// <summary>
        /// Handles the certificate list combobox's SelectedIndexChanged event.
        /// </summary>
        private void cbCertList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbCertList.SelectedIndex != -1) // a valid certificate is selected.
            {
                int selIndex = cbCertList.SelectedIndex;
                X509Certificate2 c = _certs[selIndex]; // get from the cached list.

                UpdateForm(c);
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (cbCertList.SelectedIndex != -1)
                _selectedCertificate = _certs[cbCertList.SelectedIndex];
            else
                _selectedCertificate = null;

            Close();
        }
    }
}