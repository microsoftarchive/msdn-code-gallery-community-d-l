Imports System.Security.Cryptography.X509Certificates

Namespace ClientSample.Ftp.Security
	''' <summary>
	''' Form used for showing certificate's issues and let user to decide Accept or Reject the certificate.
	''' </summary>
	Partial Public Class CertValidator
		Inherits Form
		Private _showAddToTrustedList As Boolean
		''' <summary>
		''' Gets or sets a boolean value indicating whether the button "Add To Trusted List" will be shown.
		''' </summary>
		Public Property ShowAddToTrustedList() As Boolean
			Get
				Return _showAddToTrustedList
			End Get
			Set(ByVal value As Boolean)
				_showAddToTrustedList = value
			End Set
		End Property

		Private _addToTrustedList As Boolean
		''' <summary>
		''' Gets a boolean value indicating whether the certificate will be added to the local PC's trusted list.
		''' </summary>
		Public ReadOnly Property AddToTrustedList() As Boolean
			Get
				Return _addToTrustedList
			End Get
		End Property

		Private _accepted As Boolean
		''' <summary>
		''' Gets a boolean value indicating whether the certificate is accepted.
		''' </summary>
		Public ReadOnly Property Accepted() As Boolean
			Get
				Return _accepted
			End Get
		End Property

		Private _cert As X509Certificate2
		''' <summary>
		''' Gets or sets the certificate object.
		''' </summary>
		Public Property Certificate() As X509Certificate2
			Get
				Return _cert
			End Get
			Set(ByVal value As X509Certificate2)
				_cert = value
			End Set
		End Property

		Private _issues As String
		''' <summary>
		''' Gets or sets the certificate's issues.
		''' </summary>
		Public Property Issues() As String
			Get
				Return _issues
			End Get
			Set(ByVal value As String)
				_issues = value
			End Set
		End Property

		''' <summary>
		''' Handles the Trusted button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnTrusted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTrusted.Click
			_addToTrustedList = True
			_accepted = True
			Close()
		End Sub

		''' <summary>
		''' Handles the Cancel button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
			' User rejected this certificate and close this form.
			Close()
		End Sub

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
			' User accepted this certificate and close this form.
			_accepted = True
			Close()
		End Sub

		''' <summary>
		''' Initializes a new instance of the CertValidator class.
		''' </summary>
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Handles the form's Load event.
		''' </summary>
		''' <param name="e">The arguments for the event.</param>
		Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
			MyBase.OnLoad(e)

			Dim commonName As String = Nothing
			Dim countryCode As String = Nothing
			Dim state As String = Nothing
			Dim city As String = Nothing
			Dim organization As String = Nothing
			Dim unit As String = Nothing
			Dim email As String = Nothing

			CertTextExtractor.Extract(_cert.Issuer, commonName, countryCode, state, city, organization, unit, email)

			' Update label controls.
			lblIssuerText.Text = organization
			lblUnitText.Text = unit
			lblLocationText.Text = String.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city)
			lblCommonNameText.Text = commonName

			CertTextExtractor.Extract(_cert.Subject, commonName, countryCode, state, city, organization, unit, email)

			lblOrganizationSubText.Text = organization
			lblUnitSubText.Text = unit
			lblLocationSubText.Text = String.Format("Country Code: {0}, State: {1}, City: {2}", countryCode, state, city)
			lblCommonNameSubText.Text = commonName

			lblFromText.Text = _cert.NotBefore.ToString()
			lblToText.Text = _cert.NotAfter.ToString()

			txtIssues.Text = _issues

			btnTrusted.Visible = _showAddToTrustedList
		End Sub
	End Class
End Namespace