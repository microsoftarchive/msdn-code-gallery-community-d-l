using System.Windows.Forms;

namespace ClientSample
{
    public partial class MoveToRemoteFolder : Form
    {
        public MoveToRemoteFolder()
        {
            InitializeComponent();
        }

        public MoveToRemoteFolder(string remoteDir)
        {
            InitializeComponent();

            txtRemoteDir.Text = remoteDir;
        }

        /// <summary>
        /// Gets the path to the desired destination remote folder.
        /// </summary>
        public string RemoteDir
        {
            get { return txtRemoteDir.Text; }
        }

        /// <summary>
        /// Gets the search file masks.
        /// </summary>
        public string FileMasks
        {
            get { return txtMasks.Text; }
        }
    }
}