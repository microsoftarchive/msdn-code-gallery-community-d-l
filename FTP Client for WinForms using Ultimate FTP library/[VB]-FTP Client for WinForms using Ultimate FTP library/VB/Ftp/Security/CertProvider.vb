Imports System.Security.Cryptography.X509Certificates

Namespace ClientSample.Ftp.Security
	''' <summary>
	''' Form used for selecting available certificates.
	''' </summary>
	Partial Public Class CertProvider
		Inherits Form
		Private _certs As X509Certificate2Collection ' available certificates.
		Private _selectedCertificate As X509Certificate2 ' selected certificate object.

		''' <summary>
		''' Gets the selected certificate object.
		''' </summary>
		Public ReadOnly Property SelectedCertificate() As X509Certificate2
			Get
				Return _selectedCertificate
			End Get
		End Property

		''' <summary>
		''' Initializes a new instance of the class.
		''' </summary>
		Public Sub New()
			InitializeComponent()
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
			MyBase.OnLoad(e)

			' Load certificates from the local machine.
			Dim my As New X509Store(StoreName.My, StoreLocation.CurrentUser)
			my.Open(OpenFlags.ReadOnly)

			' Retrieve a list of available certificates.
			Dim certs As X509Certificate2Collection = my.Certificates

			' If no certificate found, return.
			If certs.Count = 0 Then
				Return
			End If

			LoadData(certs)
		End Sub

		''' <summary>
		''' Loads certificates and update form controls.
		''' </summary>
		''' <param name="certs"></param>
		Public Sub LoadData(ByVal certs As X509Certificate2Collection)
			_certs = certs

			' Add to the combo box.
			For i As Integer = 0 To certs.Count - 1
				cbCertList.Items.Add(certs(i).SubjectName.Name)
			Next i

			If certs.Count > 0 Then
				cbCertList.SelectedIndex = 0
				UpdateForm(certs(0))
			Else
				' Update label controls.
				lblOrganizationText.Text = String.Empty
				lblUnitText.Text = String.Empty
				lblLocationText.Text = String.Empty
				lblCommonNameText.Text = String.Empty

				lblOrganizationSubText.Text = String.Empty
				lblUnitSubText.Text = String.Empty
				lblLocationSubText.Text = String.Empty
				lblCommonNameSubText.Text = String.Empty

				lblFromText.Text = String.Empty
				lblToText.Text = String.Empty
			End If
		End Sub

		Private Sub UpdateForm(ByVal cert As X509Certificate2)
			Dim commonName As String = Nothing
			Dim countryCode As String = Nothing
			Dim state As String = Nothing
			Dim city As String = Nothing
			Dim organization As String = Nothing
			Dim unit As String = Nothing
			Dim email As String = Nothing

			CertTextExtractor.Extract(cert.Issuer, commonName, countryCode, state, city, organization, unit, email)

			' Update label controls.
			lblOrganizationText.Text = organization
			lblUnitText.Text = unit
			lblLocationText.Text = String.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city)
			lblCommonNameText.Text = commonName

			CertTextExtractor.Extract(cert.Subject, commonName, countryCode, state, city, organization, unit, email)

			lblOrganizationSubText.Text = organization
			lblUnitSubText.Text = unit
			lblLocationSubText.Text = String.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city)
			lblCommonNameSubText.Text = commonName

			lblFromText.Text = cert.NotBefore.ToString()
			lblToText.Text = cert.NotAfter.ToString()
		End Sub

		''' <summary>
		''' Handles the certificate list combobox's SelectedIndexChanged event.
		''' </summary>
		Private Sub cbCertList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCertList.SelectedIndexChanged
			If cbCertList.SelectedIndex <> -1 Then ' a valid certificate is selected.
				Dim selIndex As Integer = cbCertList.SelectedIndex
				Dim c As X509Certificate2 = _certs(selIndex) ' get from the cached list.

				UpdateForm(c)
			End If
		End Sub

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
			If cbCertList.SelectedIndex <> -1 Then
				_selectedCertificate = _certs(cbCertList.SelectedIndex)
			Else
				_selectedCertificate = Nothing
			End If

			Close()
		End Sub
	End Class
End Namespace