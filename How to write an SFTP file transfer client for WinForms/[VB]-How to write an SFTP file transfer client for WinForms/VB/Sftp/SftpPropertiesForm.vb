Imports ComponentPro.Net
Imports ComponentPro.IO

Namespace ClientSample.Sftp
	''' <summary>
	''' The remote properties form.
	''' </summary>
	Partial Public Class SftpPropertiesForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private _fileName As String
		Public Property FileName() As String
			Get
				Return _fileName
			End Get
			Set(ByVal value As String)
				_fileName = value
			End Set
		End Property

		Private _directory As Boolean
		Public Property Directory() As Boolean
			Get
				Return _directory
			End Get
			Set(ByVal value As Boolean)
				_directory = value
			End Set
		End Property

		Private _recursive As Boolean
		Public Property Recursive() As Boolean
			Get
				Return _recursive
			End Get
			Set(ByVal value As Boolean)
				_recursive = value
			End Set
		End Property

		Private _permissions As SftpFilePermissions
		Public Property Permissions() As SftpFilePermissions
			Get
				Return _permissions
			End Get
			Set(ByVal value As SftpFilePermissions)
				_permissions = value
			End Set
		End Property

		Private _loaded As Boolean
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			txtPermissions.Text = Convert.ToString(CInt(Fix(_permissions)), 16)

			UpdateCheckboxes()

			chkRecursive.Checked = _recursive
			chkRecursive.Enabled = _directory

			If _fileName Is Nothing Then
				Text = "Multiple files - Properties"
			Else
				Text = FileSystemPath.GetRemoteFileName(_fileName) & " - Properties"
			End If

			_loaded = True
		End Sub

		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			UpdatePermissions()

			_recursive = chkRecursive.Checked
		End Sub

		Private Sub UpdateCheckboxes()
			chkOwnerRead.Checked = (_permissions And SftpFilePermissions.OwnerRead) <> 0
			chkOwnerWrite.Checked = (_permissions And SftpFilePermissions.OwnerWrite) <> 0
			chkOwnerExecute.Checked = (_permissions And SftpFilePermissions.OwnerExecute) <> 0
			chkSetUID.Checked = (_permissions And SftpFilePermissions.SetUid) <> 0

			chkGroupRead.Checked = (_permissions And SftpFilePermissions.GroupRead) <> 0
			chkGroupWrite.Checked = (_permissions And SftpFilePermissions.GroupWrite) <> 0
			chkGroupExecute.Checked = (_permissions And SftpFilePermissions.GroupExecute) <> 0
			chkSetGID.Checked = (_permissions And SftpFilePermissions.SetGid) <> 0

			chkPublicRead.Checked = (_permissions And SftpFilePermissions.OthersRead) <> 0
			chkPublicWrite.Checked = (_permissions And SftpFilePermissions.OthersWrite) <> 0
			chkPublicExecute.Checked = (_permissions And SftpFilePermissions.OthersExecute) <> 0
			chkStickly.Checked = (_permissions And SftpFilePermissions.Sticky) <> 0
		End Sub

		Private Sub UpdatePermissions()
			_permissions = 0

			If chkOwnerRead.Checked Then
				_permissions = _permissions Or SftpFilePermissions.OwnerRead
			End If
			If chkOwnerWrite.Checked Then
				_permissions = _permissions Or SftpFilePermissions.OwnerWrite
			End If
			If chkOwnerExecute.Checked Then
				_permissions = _permissions Or SftpFilePermissions.OwnerExecute
			End If
			If chkSetUID.Checked Then
				_permissions = _permissions Or SftpFilePermissions.SetUid
			End If

			If chkGroupRead.Checked Then
				_permissions = _permissions Or SftpFilePermissions.GroupRead
			End If
			If chkGroupWrite.Checked Then
				_permissions = _permissions Or SftpFilePermissions.GroupWrite
			End If
			If chkGroupExecute.Checked Then
				_permissions = _permissions Or SftpFilePermissions.GroupExecute
			End If
			If chkSetGID.Checked Then
				_permissions = _permissions Or SftpFilePermissions.SetGid
			End If

			If chkPublicRead.Checked Then
				_permissions = _permissions Or SftpFilePermissions.OthersRead
			End If
			If chkPublicWrite.Checked Then
				_permissions = _permissions Or SftpFilePermissions.OthersWrite
			End If
			If chkPublicExecute.Checked Then
				_permissions = _permissions Or SftpFilePermissions.OthersExecute
			End If
			If chkStickly.Checked Then
				_permissions = _permissions Or SftpFilePermissions.Sticky
			End If
		End Sub

		Private Sub txtPermissions_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPermissions.TextChanged
			If (Not _loaded) OrElse txtPermissions.Text.Length = 0 Then
				Return
			End If
			Try
				Dim p As UInteger = Convert.ToUInt32(txtPermissions.Text, 16)
				If p < 0 OrElse p > &HFFF Then
					MessageBox.Show(Messages.InvalidPermissions, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If

				_permissions = CType(p, SftpFilePermissions)
				UpdateCheckboxes()
			Catch e1 As Exception
				MessageBox.Show(Messages.InvalidPermissions, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try
		End Sub

		Private Sub checkBoxes_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkSetUID.CheckedChanged, chkOwnerExecute.CheckedChanged, chkOwnerWrite.CheckedChanged, chkOwnerRead.CheckedChanged, chkSetGID.CheckedChanged, chkGroupExecute.CheckedChanged, chkGroupWrite.CheckedChanged, chkGroupRead.CheckedChanged, chkStickly.CheckedChanged, chkPublicExecute.CheckedChanged, chkPublicWrite.CheckedChanged, chkPublicRead.CheckedChanged
			If (Not _loaded) OrElse txtPermissions.Focused Then
				Return
			End If
			UpdatePermissions()
			txtPermissions.Text = Convert.ToString(CInt(Fix(_permissions)), 16)
		End Sub
	End Class
End Namespace