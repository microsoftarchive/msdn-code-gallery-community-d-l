Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO

Namespace XmlTransformation

	Public Class XmlSerializerHelper
		Public Function Serialize(ByVal obj As Object) As String
			Dim serializer = New XmlSerializer(obj.GetType())

			Dim writerSettings = New XmlWriterSettings With {.OmitXmlDeclaration = True, .Indent = True}

			Dim emptyNameSpace = New XmlSerializerNamespaces()
			emptyNameSpace.Add(String.Empty, String.Empty)

			Dim stringWriter = New StringWriter()
			Using xmlWriter = XmlWriter.Create(stringWriter, writerSettings)
				serializer.Serialize(xmlWriter, obj, emptyNameSpace)

				Return stringWriter.ToString()
			End Using
		End Function
	End Class
End Namespace