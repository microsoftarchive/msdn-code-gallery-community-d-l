using System.Collections.Generic;
using System.Windows.Forms;
using ComponentPro.IO;

namespace ClientSample
{
    public partial class FileOperation : Form
    {
        private Dictionary<System.Windows.Forms.Button, TransferConfirmNextActions> _btns;
        private readonly Dictionary<TransferConfirmReason, object> _skipTypes = new Dictionary<TransferConfirmReason, object>();
        private TransferConfirmEventArgs _oldEvt;

        private bool _overwriteAll;
        private bool _overwriteOlder;
        private bool _overwriteDifferentSize;

        private bool _resumeAll;
        private bool _followAllLinks;

        public FileOperation()
        {
            InitializeComponent();
        }

        public void Init()
        {
            if (_btns == null)
            {
                _btns = new Dictionary<System.Windows.Forms.Button, TransferConfirmNextActions>();
                _btns.Add(btnOverwrite, TransferConfirmNextActions.Overwrite);
                _btns.Add(btnOverwriteAll, TransferConfirmNextActions.Overwrite);
                _btns.Add(btnOverwriteDiffSize, TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes);
                _btns.Add(btnOverwriteOlder, TransferConfirmNextActions.CheckAndOverwriteOlderFiles);
                _btns.Add(btnRename, TransferConfirmNextActions.Rename);
                _btns.Add(btnSkip, TransferConfirmNextActions.Skip);
                _btns.Add(btnSkipAll, TransferConfirmNextActions.Skip);
                _btns.Add(btnFollowLink, TransferConfirmNextActions.FollowLink);
                _btns.Add(btnFollowLinkAll, TransferConfirmNextActions.FollowLink);
                _btns.Add(btnRetry, TransferConfirmNextActions.Retry);
                _btns.Add(btnCancel, TransferConfirmNextActions.Cancel);
                _btns.Add(btnResume, TransferConfirmNextActions.ResumeFileTransfer);
                _btns.Add(btnResumeAll, TransferConfirmNextActions.ResumeFileTransfer);
            }

            _skipTypes.Clear();
            _overwriteAll = false;
            _overwriteOlder = false;
            _overwriteDifferentSize = false;

            _resumeAll = false;

            _followAllLinks = false;
        }

        public void Show(Form parent, TransferConfirmEventArgs evt)
        {
            if (_skipTypes.ContainsKey(evt.ConfirmReason))
            {
                evt.NextAction = TransferConfirmNextActions.Skip;
                return;
            }

            if (evt.ConfirmReason == TransferConfirmReason.FileAlreadyExists)
            {
                if (_overwriteAll)
                {
                    evt.NextAction = TransferConfirmNextActions.Overwrite;
                    return;
                }

                if (_overwriteDifferentSize)
                {
                    evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes;
                    return;
                }

                if (_overwriteOlder)
                {
                    evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles;
                    return;
                }

                if (_resumeAll && (evt.PossibleNextActions & TransferConfirmNextActions.ResumeFileTransfer) != 0)
                {
                    evt.NextAction = TransferConfirmNextActions.ResumeFileTransfer;
                    return;
                }

                // format the text according to TransferState (Downloading or Uploading)
                const string messageFormat = "Are you sure you want to overwrite file: {0}\r\n{1} Bytes, {2}\r\n\r\nWith file: {3}\r\n{4} Bytes, {5}";

                lblMessage.Text = string.Format(messageFormat,
                                                evt.DestinationFileInfo.FullName, evt.DestinationFileInfo.Length,
                                                evt.DestinationFileInfo.LastWriteTime,
                                                evt.SourceFileInfo.FullName, evt.SourceFileInfo.Length,
                                                evt.SourceFileInfo.LastWriteTime);

                Text = "File already exists";
            }
            else
            {
                if (evt.Exception != null)
                {
                    lblMessage.Text = evt.Exception.Message;

                    if (evt.Exception.InnerException != null)
                    {
                        lblMessage.Text += "\r\nReason: " + evt.Exception.InnerException.Message;
                    }
                }
                else
                {
                    if (_followAllLinks && (evt.PossibleNextActions & TransferConfirmNextActions.FollowLink) != 0)
                    {
                        evt.NextAction = TransferConfirmNextActions.FollowLink;
                        return;
                    }

                    lblMessage.Text = evt.Message;
                }

                Text = "An error occurred";
            }

            _oldEvt = evt;

            ArrangeButtons(evt);

            this.ShowDialog(parent);
        }

        private void ArrangeButtons(TransferConfirmEventArgs evt)
        {
            const int buttonHeight = 24;
            const int buttonWidth = 128;
            const int gap = 3;


            int buttons = 0;
            foreach (KeyValuePair<System.Windows.Forms.Button, TransferConfirmNextActions> en in _btns)
            {
                bool b = evt.CanPerform(en.Value);
                en.Key.Visible = b;
                if (b)
                {
                    buttons++;
                }
            }

            int count = this.ClientSize.Width / (buttonWidth + gap);
            int y = this.ClientSize.Height - (buttonHeight + gap) * ((buttons / count) + ((buttons % count) == 0 ? 0 : 1)) - 4;
            int x = (this.ClientSize.Width - count * buttonWidth - gap) / 2;
            
            int i = 0;
            foreach (KeyValuePair<System.Windows.Forms.Button, TransferConfirmNextActions> en in _btns)
            {
                bool b = evt.CanPerform(en.Value);
                en.Key.Visible = b;
                if (b)
                {
                    en.Key.Left = x + (buttonWidth + gap) * (i % count);
                    en.Key.Top = y + (buttonHeight + gap) * (i / count);
                    i++;
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Cancel;
            Close();
        }

        private void btnSkip_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Skip;
            Close();
        }

        private void btnSkipAll_Click(object sender, System.EventArgs e)
        {
            _skipTypes.Add(_oldEvt.ConfirmReason, null);

            _oldEvt.NextAction = TransferConfirmNextActions.Skip;
            Close();
        }

        private void btnRetry_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Retry;
            Close();
        }

        private void btnRename_Click(object sender, System.EventArgs e)
        {
            string oldName = _oldEvt.DestinationFileSystem.GetFileName(_oldEvt.DestinationFileInfo.Name);
            NewNamePrompt formNewName = new NewNamePrompt(oldName);

            DialogResult result = formNewName.ShowDialog(this);

            string newName = formNewName.NewName;

            if (result != DialogResult.OK || newName.Length == 0 || newName == oldName)
                return;

            _oldEvt.NextAction = TransferConfirmNextActions.Rename;
            _oldEvt.NewName = newName;
            Close();
        }

        private void btnOverwrite_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Overwrite;
            Close();
        }

        private void btnOverwriteAll_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Overwrite;
            _overwriteAll = true;
            Close();
        }

        private void btnOverwriteOlder_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles;
            _overwriteOlder = true;
            Close();
        }

        private void btnOverwriteDiffSize_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes;
            _overwriteDifferentSize = true;
            Close();
        }

        private void btnFollowLink_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.FollowLink;
            Close();
        }

        private void btnResume_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.ResumeFileTransfer;
            Close();
        }

        private void btnResumeAll_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.ResumeFileTransfer;
            _resumeAll = true;
            Close();
        }

        private void btnFollowLinkAll_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.FollowLink;
            _followAllLinks = true;
            Close();
        }
    }
}