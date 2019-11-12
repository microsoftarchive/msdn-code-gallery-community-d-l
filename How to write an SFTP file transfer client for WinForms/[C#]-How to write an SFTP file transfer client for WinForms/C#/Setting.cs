using System;
using System.Windows.Forms;
using ClientSample.Sftp;
using ComponentPro.Net;

namespace ClientSample
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        public Setting(SettingInfoBase s)
        {
            InitializeComponent();

            _info = s;

            txtThrottle.Text = s.Get<int>(SettingInfo.Throttle).ToString();
            txtTimeout.Text = s.Get<int>(SettingInfo.Timeout).ToString();
            txtKeepAliveInterval.Text = s.Get<int>(SettingInfo.KeepAlive).ToString();
            rbtAscii.Checked = s.Get<bool>(SettingInfo.AsciiTransfer);
            rbtBinary.Checked = !s.Get<bool>(SettingInfo.AsciiTransfer);
            tbProgress.Value = s.Get<int>(SettingInfo.ProgressUpdateInterval) / 50;
            chkRestoreProperties.Checked = s.Get<bool>(SettingInfo.RestoreFileProperties);
            chkShowProgress.Checked = s.Get<bool>(SettingInfo.ShowProgressWhileDeleting);
            chkShowProgressWhileTransferring.Checked = s.Get<bool>(SettingInfo.ShowProgressWhileTransferring);
        
#if FTP
#if !SFTP
            tabControlExt.Controls.Remove(sftpPage);
#endif
            #region FTP
            chkSendABOR.CheckState = GetState(s.Get<OptionValue>(FtpSettingInfo.SendAborCommand));
            chkSendSignals.Checked = s.Get<bool>(FtpSettingInfo.SendAbortSignals);
            chkChDirBeforeListing.Checked = s.Get<bool>(FtpSettingInfo.ChangeDirBeforeListing);
            chkChDirBeforeTransfer.Checked = s.Get<bool>(FtpSettingInfo.ChangeDirBeforeTransfer);
            chkCompress.Checked = s.Get<bool>(FtpSettingInfo.Compress);
            chkSmartPath.Checked = s.Get<bool>(FtpSettingInfo.SmartPath);
            #endregion
#endif

#if SFTP
#if !FTP
            tabControlExt.Controls.Remove(ftpPage);
#endif
            #region SFTP
            cbxServerOs.SelectedIndex = s.Get<int>(SftpSettingInfo.ServerOs);
            #endregion
#endif
        }

        CheckState GetState(OptionValue value)
        {
            switch (value)
            {
                case OptionValue.Auto:
                    return CheckState.Indeterminate;
                case OptionValue.Yes:
                    return CheckState.Checked;
            }

            return CheckState.Unchecked;
        }

        OptionValue GetState(CheckState value)
        {
            switch (value)
            {
                case CheckState.Indeterminate:
                    return OptionValue.Auto;
                case CheckState.Checked:
                    return OptionValue.Yes;
            }

            return OptionValue.No;
        }

        private readonly SettingInfoBase _info;

        private void btnOK_Click(object sender, EventArgs e)
        {
            int limit;
            try
            {
                limit = int.Parse(txtThrottle.Text);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc, "Invalid Throttle");
                return;
            }
            if (limit < 0)
            {
                MessageBox.Show("Invalid throttle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int timeout;
            try
            {
                timeout = int.Parse(txtTimeout.Text);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc, "Invalid Timeout");
                return;
            }
            if (timeout < 1)
            {
                MessageBox.Show("Invalid timeout, it must be greater than or equal to 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int keepaliveint;
            try
            {
                keepaliveint = int.Parse(txtKeepAliveInterval.Text);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc, "Invalid Interval");
                return;
            }
            if (keepaliveint < 10)
            {
                MessageBox.Show("Invalid keep alive interval, it must be greater than or equal to 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _info.Set(SettingInfo.AsciiTransfer, rbtAscii.Checked);
            _info.Set(SettingInfo.KeepAlive, keepaliveint);
            _info.Set(SettingInfo.Throttle, limit);
            _info.Set(SettingInfo.Timeout, timeout);
            _info.Set(SettingInfo.ProgressUpdateInterval, tbProgress.Value * 50);
            _info.Set(SettingInfo.ShowProgressWhileDeleting, chkShowProgress.Checked);
            _info.Set(SettingInfo.ShowProgressWhileTransferring, chkShowProgressWhileTransferring.Checked);
            _info.Set(SettingInfo.RestoreFileProperties, chkRestoreProperties.Checked);
            
#if FTP
            _info.Set(FtpSettingInfo.SendAborCommand, GetState(chkSendABOR.CheckState));
            _info.Set(FtpSettingInfo.SendAbortSignals, chkSendSignals.Checked);
            _info.Set(FtpSettingInfo.ChangeDirBeforeListing, chkChDirBeforeListing.Checked);
            _info.Set(FtpSettingInfo.ChangeDirBeforeTransfer, chkChDirBeforeTransfer.Checked);
            _info.Set(FtpSettingInfo.Compress, chkCompress.Checked);
            _info.Set(FtpSettingInfo.SmartPath, chkSmartPath.Checked);
#endif

#if SFTP
            _info.Set(SftpSettingInfo.ServerOs, cbxServerOs.SelectedIndex);
#endif

            this.DialogResult = DialogResult.OK;
        }
    }
}