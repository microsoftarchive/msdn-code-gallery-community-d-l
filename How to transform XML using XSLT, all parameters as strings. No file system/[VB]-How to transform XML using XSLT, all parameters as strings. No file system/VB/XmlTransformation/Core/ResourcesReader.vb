Imports System.Reflection
Imports System.IO

Namespace XmlTransformation

	Public Class ResourcesReader
		''' <exception cref="ArgumentException">Cannot find a resources with the specified name.</exception>
		Public Function Read(ByVal name As String) As String
			Using stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name)
				If stream Is Nothing Then
					Throw New ArgumentException("Cannot find a resources with the specified name.")
				End If

				Using reader = New StreamReader(stream)
					Return reader.ReadToEnd()
				End Using
			End Using
		End Function
	End Class
End Namespace