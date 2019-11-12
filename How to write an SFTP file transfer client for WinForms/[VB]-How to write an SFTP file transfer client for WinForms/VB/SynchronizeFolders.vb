Imports ComponentPro.IO

Namespace ClientSample
	Partial Public Class SynchronizeFolders
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal localIsMaster As Boolean, ByVal recursive As RecursionMode, ByVal syncDateTime As Boolean, ByVal comparisonMethod As Integer, ByVal checkForResumability As Boolean, ByVal searchPattern As String)
			InitializeComponent()

			rbtLocalMaster.Checked = localIsMaster
			rbtRemoteMaster.Checked = Not localIsMaster
			chkRecursive.Checked = recursive = RecursionMode.RecurseIntoAllSubFolders
			chkSyncDateTime.Checked = syncDateTime
			cbxComparisonType.SelectedIndex = comparisonMethod
			chkResumability.Checked = checkForResumability
			txtSearchPattern.Text = searchPattern
		End Sub

		''' <summary>
		''' Gets the boolean value indicating whether the local folder is the master.
		''' </summary>
		Public ReadOnly Property RemoteIsMaster() As Boolean
			Get
				Return rbtRemoteMaster.Checked
			End Get
		End Property

		Public ReadOnly Property Recursive() As RecursionMode
			Get
				If chkRecursive.Checked Then
					Return RecursionMode.RecurseIntoAllSubFolders
				Else
					Return RecursionMode.None
				End If
			End Get
		End Property

		Public ReadOnly Property SyncDateTime() As Boolean
			Get
				Return chkSyncDateTime.Checked
			End Get
		End Property

		Public ReadOnly Property ComparisonMethod() As Integer
			Get
				Return cbxComparisonType.SelectedIndex
			End Get
		End Property

		Public ReadOnly Property SearchPattern() As String
			Get
				Return txtSearchPattern.Text
			End Get
		End Property

		Public ReadOnly Property CheckForResumability() As Boolean
			Get
				Return chkResumability.Checked
			End Get
		End Property

		Private Sub cbxComparisonType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxComparisonType.SelectedIndexChanged
			chkResumability.Visible = cbxComparisonType.SelectedIndex = 1
		End Sub
	End Class
End Namespace