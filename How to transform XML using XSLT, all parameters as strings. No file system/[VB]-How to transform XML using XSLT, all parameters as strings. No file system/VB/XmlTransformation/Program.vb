Namespace XmlTransformation

	Friend Class Program
		Private Shared Sub Main()
			Dim person = CreatePerson()

			ShowPersonXml(person)

			Console.WriteLine()

			ShowPersonXmlTranformation(person)
		End Sub

		Private Shared Function CreatePerson() As Person
			Return New Person With {.Name = "Bill", .Age = 30}
		End Function

		Private Shared Sub ShowPersonXml(ByVal person As Person)
			Dim xml = New XmlSerializerHelper().Serialize(person)

			Console.WriteLine(xml)
		End Sub

		Private Shared Sub ShowPersonXmlTranformation(ByVal person As Person)
			Dim xslt = New ResourcesReader().Read("XmlTransformation.Res.PersonHtml.xslt")

			Dim xsltTransformer = New XsltTransformer(xslt)

			Dim transformedXml = xsltTransformer.Transform(person)

			Console.WriteLine(transformedXml)
		End Sub
	End Class
End Namespace