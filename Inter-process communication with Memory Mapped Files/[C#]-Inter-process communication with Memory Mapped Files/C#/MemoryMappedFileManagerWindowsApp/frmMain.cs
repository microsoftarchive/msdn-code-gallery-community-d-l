using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MemoryMappedFileManager;

namespace MemoryMappedFileManagerWindowsApp
{
    public partial class frmMain : Form
    {
        private MemoryMappedFileCommunicator communicator;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            communicator = new MemoryMappedFileCommunicator("MemoryMappedShare", 4096);

            // This process reads data that begins in the position 0 and writes starting from the position 2000.
            communicator.ReadPosition = 0;
            communicator.WritePosition = 2000;

            // Creates an handler for the event that is raised when data are available in the
            // MemoryMappedFile.
            communicator.DataReceived += new EventHandler<MemoryMappedDataReceivedEventArgs>(communicator_DataReceived);
            communicator.StartReader();
        }

        private void communicator_DataReceived(object sender, MemoryMappedDataReceivedEventArgs e)
        {
            var receivedMessage = System.Text.Encoding.UTF8.GetString(e.Data);
            lstMessages.Items.Add(receivedMessage);
            lstMessages.SelectedIndex = lstMessages.Items.Count - 1;

            // Sends a message as a response.
            communicator.Write("Message from Windows App: data received at " + DateTime.Now);            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Closes the reader thread.
            communicator.CloseReader();
            communicator.Dispose();
            communicator = null;
        }
    }
}
