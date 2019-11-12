Public Class MyDataGridView
    Inherits DataGridView

    Protected Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean

        If e.KeyData = Keys.Left OrElse e.KeyData = Keys.Right Then
            If Me.EditingControl IsNot Nothing Then
                If Me.EditingControl.GetType() Is GetType(DataGridViewComboBoxEditingControl) Then
                    Dim control As ComboBox = TryCast(Me.EditingControl, ComboBox)
                    If control.DropDownStyle <> ComboBoxStyle.DropDownList Then
                        Select Case e.KeyData
                            Case Keys.Left
                                If control.SelectionStart > 0 Then
                                    control.SelectionStart -= 1
                                    Return True
                                End If
                            Case Keys.Right
                                If control.SelectionStart < control.Text.Length Then
                                    control.SelectionStart += 1
                                    Return True
                                End If
                        End Select
                    End If
                End If
            End If

        End If

        Return MyBase.ProcessDataGridViewKey(e)

    End Function
End Class