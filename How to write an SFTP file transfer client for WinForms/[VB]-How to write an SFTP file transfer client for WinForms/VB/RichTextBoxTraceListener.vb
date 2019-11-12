Imports ComponentPro.Diagnostics

Namespace ClientSample
	Public Class RichTextBoxTraceListener
		Inherits UltimateTextWriterTraceListener
		Private Shared ReadOnly TextColorCommand As Color = Color.White ' Text color for command texts.
		Private Shared ReadOnly TextColorError As Color = Color.FromArgb(&Hff, &H50, &H50) ' Text color for error texts.
		Friend Shared ReadOnly TextColorInfo As Color = Color.FromArgb(&H72, &Hff, &H7c) ' Text color for information texts.
		Private Shared ReadOnly TextColorResponse As Color = Color.FromArgb(&Ha0, &Ha0, &Ha0) ' Text color for response texts.
		Private Shared ReadOnly TextColorSecure As Color = Color.FromArgb(&H8b, &Hf5, &Hfc) ' Text color for security information texts.
		Private ReadOnly _textbox As RichTextBox

		Public Sub New(ByVal textbox As RichTextBox)
			_textbox = textbox
		End Sub

		Public Overrides Sub TraceData(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal level As TraceEventType, ByVal id As Integer, ParamArray ByVal data() As Object)
			Dim color As Color = TextColorInfo
			Dim category As String = CStr(data(1))
			Dim message As String = CStr(data(0))

			' If it's showing an error?
			If level <= TraceEventType.Error Then
				color = TextColorError
			Else
				Select Case category.ToUpper()
					Case "COMMAND"
						' command log.
						color = TextColorCommand
						message = String.Format("[{0:HH:mm:ss.fff}] {1} - COMMAND>   {2}" & vbCrLf, Date.Now, level, message)
						GoTo Invoke

					Case "RESPONSE"
						' response log.
						color = TextColorResponse
						message = String.Format("[{0:HH:mm:ss.fff}] {1} -        <   {2}" & vbCrLf, Date.Now, level, message)
						GoTo Invoke

					Case "SECURESHELL", "SECURESOCKET"
						color = TextColorSecure
				End Select
			End If
			message = String.Format("[{0:HH:mm:ss.fff}] {1} - {2}: {3}" & vbCrLf, Date.Now, level, category, message)

			Invoke:
			_textbox.Invoke(New OnLogHandler(AddressOf OnLog), New Object() {message, color})
		End Sub

		Private Sub OnLog(ByVal message As String, ByVal color As Color)
			' Write log message to the text box.
			_textbox.SelectionColor = color
			_textbox.SelectionStart = _textbox.Text.Length
			_textbox.SelectedText = message
			_textbox.ScrollToCaret()
		End Sub

		#Region "Nested type: OnLogHandler"

		Private Delegate Sub OnLogHandler(ByVal message As String, ByVal color As Color)

		#End Region
	End Class
End Namespace