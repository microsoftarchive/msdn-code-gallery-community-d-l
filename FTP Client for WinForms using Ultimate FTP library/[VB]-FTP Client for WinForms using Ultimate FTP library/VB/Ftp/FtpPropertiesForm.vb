Imports ComponentPro.IO
Imports ComponentPro.Net

Namespace ClientSample.Ftp
	''' <summary>
	''' The remote properties form.
	''' </summary>
	Partial Public Class FtpPropertiesForm
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

		Private _recursive As RecursionMode
		Public Property Recursive() As RecursionMode
			Get
				Return _recursive
			End Get
			Set(ByVal value As RecursionMode)
				_recursive = value
			End Set
		End Property

		Private _permissions As FtpFilePermissions
		Public Property Permissions() As FtpFilePermissions
			Get
				Return _permissions
			End Get
			Set(ByVal value As FtpFilePermissions)
				_permissions = value
			End Set
		End Property

		Public ReadOnly Property PermissionsString() As String
			Get
				Return Convert.ToString(CInt(_permissions), 8)
			End Get
		End Property

		Private _loaded As Boolean
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			UpdateCheckboxes()

			chkRecursive.Checked = _recursive = RecursionMode.RecurseIntoAllSubFolders
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

			If chkRecursive.Checked Then
				_recursive = RecursionMode.RecurseIntoAllSubFolders
			Else
				_recursive = RecursionMode.None
			End If
		End Sub

		Private Sub UpdateCheckboxes()
			chkOwnerRead.Checked = (_permissions And FtpFilePermissions.OwnerRead) <> 0
			chkOwnerWrite.Checked = (_permissions And FtpFilePermissions.OwnerWrite) <> 0
			chkOwnerExecute.Checked = (_permissions And FtpFilePermissions.OwnerExecute) <> 0

			chkGroupRead.Checked = (_permissions And FtpFilePermissions.GroupRead) <> 0
			chkGroupWrite.Checked = (_permissions And FtpFilePermissions.GroupWrite) <> 0
			chkGroupExecute.Checked = (_permissions And FtpFilePermissions.GroupExecute) <> 0

			chkPublicRead.Checked = (_permissions And FtpFilePermissions.PublicRead) <> 0
			chkPublicWrite.Checked = (_permissions And FtpFilePermissions.PublicWrite) <> 0
			chkPublicExecute.Checked = (_permissions And FtpFilePermissions.PublicExecute) <> 0
		End Sub

		Private Sub UpdatePermissions()
			_permissions = 0

			If chkOwnerRead.Checked Then
				_permissions = _permissions Or FtpFilePermissions.OwnerRead
			End If
			If chkOwnerWrite.Checked Then
				_permissions = _permissions Or FtpFilePermissions.OwnerWrite
			End If
			If chkOwnerExecute.Checked Then
				_permissions = _permissions Or FtpFilePermissions.OwnerExecute
			End If

			If chkGroupRead.Checked Then
				_permissions = _permissions Or FtpFilePermissions.GroupRead
			End If
			If chkGroupWrite.Checked Then
				_permissions = _permissions Or FtpFilePermissions.GroupWrite
			End If
			If chkGroupExecute.Checked Then
				_permissions = _permissions Or FtpFilePermissions.GroupExecute
			End If

			If chkPublicRead.Checked Then
				_permissions = _permissions Or FtpFilePermissions.PublicRead
			End If
			If chkPublicWrite.Checked Then
				_permissions = _permissions Or FtpFilePermissions.PublicWrite
			End If
			If chkPublicExecute.Checked Then
				_permissions = _permissions Or FtpFilePermissions.PublicExecute
			End If
		End Sub

		Private Sub checkBoxes_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkOwnerExecute.CheckedChanged, chkOwnerWrite.CheckedChanged, chkOwnerRead.CheckedChanged, chkGroupExecute.CheckedChanged, chkGroupWrite.CheckedChanged, chkGroupRead.CheckedChanged, chkPublicExecute.CheckedChanged, chkPublicWrite.CheckedChanged, chkPublicRead.CheckedChanged
			If Not _loaded Then
				Return
			End If
			UpdatePermissions()
		End Sub
	End Class
End Namespace