Imports System.Xml

Namespace ClientSample
	Friend Structure SiteInfo
		Public Address As String
		Public Port As Integer
		Public UserName As String
		Public Password As String
		Public Security As Integer
		Public Description As String
	End Structure

	Friend Class SiteLoader
		Public Shared Function GetSites() As SiteInfo()
			Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "Sites.xml"

			Dim list As New List(Of SiteInfo)()
			Dim xmlReader As XmlTextReader = Nothing
			Try
				xmlReader = New XmlTextReader(fileName)

				Do While xmlReader.Read()
					If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "sites" Then
						Do While xmlReader.Read()
							If xmlReader.NodeType = XmlNodeType.Element AndAlso xmlReader.Name = "add" Then
								Dim address As String = Nothing
								Dim port As Integer = 0
								Dim userName As String = Nothing
								Dim password As String = Nothing
								Dim security As Integer = 0
								Dim desc As String = Nothing

								Do While xmlReader.MoveToNextAttribute()
									If xmlReader.Name = "address" Then
										address = xmlReader.Value
									ElseIf xmlReader.Name = "port" Then
										If xmlReader.Value <> String.Empty Then
											port = Integer.Parse(xmlReader.Value)
										Else
											port = 0
										End If
									ElseIf xmlReader.Name = "userName" Then
										userName = xmlReader.Value
									ElseIf xmlReader.Name = "password" Then
										password = xmlReader.Value
									ElseIf xmlReader.Name = "security" Then
										security = Integer.Parse(xmlReader.Value)
									ElseIf xmlReader.Name = "desc" Then
										desc = xmlReader.Value
									End If
								Loop

								If address IsNot Nothing Then
									Dim info As New SiteInfo()
									info.Address = address
									info.Port = port
									info.UserName = userName
									info.Password = password
									info.Security = security
									info.Description = desc

									list.Add(info)
								End If
							End If
						Loop
					End If
				Loop
			Catch
				Return Nothing
			Finally
				' Finished with XmlTextReader
				If xmlReader IsNot Nothing Then
					xmlReader.Close()
				End If
			End Try

			Return list.ToArray()
		End Function
	End Class
End Namespace