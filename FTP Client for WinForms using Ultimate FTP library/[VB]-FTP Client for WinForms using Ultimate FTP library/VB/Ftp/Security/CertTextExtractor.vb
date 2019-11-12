Namespace ClientSample.Ftp.Security
	Friend NotInheritable Class CertTextExtractor

		Private Sub New()
		End Sub

		Public Shared Sub Extract(ByVal name As String, <System.Runtime.InteropServices.Out()> ByRef commonName As String, <System.Runtime.InteropServices.Out()> ByRef countryCode As String, <System.Runtime.InteropServices.Out()> ByRef state As String, <System.Runtime.InteropServices.Out()> ByRef city As String, <System.Runtime.InteropServices.Out()> ByRef organization As String, <System.Runtime.InteropServices.Out()> ByRef unit As String, <System.Runtime.InteropServices.Out()> ByRef email As String)
			email = String.Empty
			unit = email
			organization = unit
			city = organization
			state = city
			countryCode = state
			commonName = countryCode
			Dim arr() As String = name.Split(","c)
			For Each s As String In arr
				Dim pair() As String = s.TrimStart(" "c).Split("="c)
				Select Case pair(0)
					Case "CN"
						commonName = pair(1)

					Case "C"
						countryCode = pair(1)

					Case "S"
						state = pair(1)

					Case "L"
						city = pair(1)

					Case "O"
						organization = pair(1)

					Case "OU"
						unit = pair(1)

					Case "E"
						email = pair(1)
				End Select
			Next s
		End Sub
	End Class
End Namespace
