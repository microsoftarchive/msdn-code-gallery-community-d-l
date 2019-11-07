Imports System.Xml.Xsl
Imports System.Xml
Imports System.IO

Namespace XmlTransformation

	Public Class XsltTransformer
		Private ReadOnly xslTransform As XslCompiledTransform

		Public Sub New(ByVal xsl As String)
			xslTransform = New XslCompiledTransform()

			Dim xslt = XmlReader.Create(New StringReader(xsl))
			xslTransform.Load(xslt)
		End Sub

		Public Function Transform(ByVal person As Object) As String
			Dim xml = New XmlSerializerHelper().Serialize(person)

			Using writer = New StringWriter()
				Dim input = XmlReader.Create(New StringReader(xml))

				xslTransform.Transform(input, Nothing, writer)
				Return writer.ToString()
			End Using
		End Function
	End Class
End Namespace