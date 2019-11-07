Imports ClientSample.Ftp
Imports ComponentPro.Net

Namespace ClientSample
	Partial Public Class Setting
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal s As SettingInfoBase)
			InitializeComponent()

			_info = s

			txtThrottle.Text = s.Get(Of Integer)(SettingInfo.Throttle).ToString()
			txtTimeout.Text = s.Get(Of Integer)(SettingInfo.Timeout).ToString()
			txtKeepAliveInterval.Text = s.Get(Of Integer)(SettingInfo.KeepAlive).ToString()
			rbtAscii.Checked = s.Get(Of Boolean)(SettingInfo.AsciiTransfer)
			rbtBinary.Checked = Not s.Get(Of Boolean)(SettingInfo.AsciiTransfer)
			tbProgress.Value = s.Get(Of Integer)(SettingInfo.ProgressUpdateInterval) / 50
			chkRestoreProperties.Checked = s.Get(Of Boolean)(SettingInfo.RestoreFileProperties)
			chkShowProgress.Checked = s.Get(Of Boolean)(SettingInfo.ShowProgressWhileDeleting)
			chkShowProgressWhileTransferring.Checked = s.Get(Of Boolean)(SettingInfo.ShowProgressWhileTransferring)

#If FTP Then
#If Not SFTP Then
			tabControlExt.Controls.Remove(sftpPage)
#End If
'			#Region "FTP"
			chkSendABOR.CheckState = GetState(s.Get(Of OptionValue)(FtpSettingInfo.SendAborCommand))
			chkSendSignals.Checked = s.Get(Of Boolean)(FtpSettingInfo.SendAbortSignals)
			chkChDirBeforeListing.Checked = s.Get(Of Boolean)(FtpSettingInfo.ChangeDirBeforeListing)
			chkChDirBeforeTransfer.Checked = s.Get(Of Boolean)(FtpSettingInfo.ChangeDirBeforeTransfer)
			chkCompress.Checked = s.Get(Of Boolean)(FtpSettingInfo.Compress)
			chkSmartPath.Checked = s.Get(Of Boolean)(FtpSettingInfo.SmartPath)
'			#End Region
#End If

#If SFTP Then
#If Not FTP Then
			tabControlExt.Controls.Remove(ftpPage)
#End If
'			#Region "SFTP"
			cbxServerOs.SelectedIndex = s.Get(Of Integer)(SftpSettingInfo.ServerOs)
'			#End Region
#End If
		End Sub

		Private Function GetState(ByVal value As OptionValue) As CheckState
			Select Case value
				Case OptionValue.Auto
					Return CheckState.Indeterminate
				Case OptionValue.Yes
					Return CheckState.Checked
			End Select

			Return CheckState.Unchecked
		End Function

		Private Function GetState(ByVal value As CheckState) As OptionValue
			Select Case value
				Case CheckState.Indeterminate
					Return OptionValue.Auto
				Case CheckState.Checked
					Return OptionValue.Yes
			End Select

			Return OptionValue.No
		End Function

		Private ReadOnly _info As SettingInfoBase

		Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
			Dim limit As Integer
			Try
				limit = Integer.Parse(txtThrottle.Text)
			Catch exc As Exception
				Util.ShowError(exc, "Invalid Throttle")
				Return
			End Try
			If limit < 0 Then
				MessageBox.Show("Invalid throttle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			Dim timeout As Integer
			Try
				timeout = Integer.Parse(txtTimeout.Text)
			Catch exc As Exception
				Util.ShowError(exc, "Invalid Timeout")
				Return
			End Try
			If timeout < 1 Then
				MessageBox.Show("Invalid timeout, it must be greater than or equal to 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			Dim keepaliveint As Integer
			Try
				keepaliveint = Integer.Parse(txtKeepAliveInterval.Text)
			Catch exc As Exception
				Util.ShowError(exc, "Invalid Interval")
				Return
			End Try
			If keepaliveint < 10 Then
				MessageBox.Show("Invalid keep alive interval, it must be greater than or equal to 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			_info.Set(SettingInfo.AsciiTransfer, rbtAscii.Checked)
			_info.Set(SettingInfo.KeepAlive, keepaliveint)
			_info.Set(SettingInfo.Throttle, limit)
			_info.Set(SettingInfo.Timeout, timeout)
			_info.Set(SettingInfo.ProgressUpdateInterval, tbProgress.Value * 50)
			_info.Set(SettingInfo.ShowProgressWhileDeleting, chkShowProgress.Checked)
			_info.Set(SettingInfo.ShowProgressWhileTransferring, chkShowProgressWhileTransferring.Checked)
			_info.Set(SettingInfo.RestoreFileProperties, chkRestoreProperties.Checked)

#If FTP Then
			_info.Set(FtpSettingInfo.SendAborCommand, GetState(chkSendABOR.CheckState))
			_info.Set(FtpSettingInfo.SendAbortSignals, chkSendSignals.Checked)
			_info.Set(FtpSettingInfo.ChangeDirBeforeListing, chkChDirBeforeListing.Checked)
			_info.Set(FtpSettingInfo.ChangeDirBeforeTransfer, chkChDirBeforeTransfer.Checked)
			_info.Set(FtpSettingInfo.Compress, chkCompress.Checked)
			_info.Set(FtpSettingInfo.SmartPath, chkSmartPath.Checked)
#End If

#If SFTP Then
			_info.Set(SftpSettingInfo.ServerOs, cbxServerOs.SelectedIndex)
#End If

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace