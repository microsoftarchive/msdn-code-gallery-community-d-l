Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        EncryptS.UniCod.txt2Encrypt = TextBox1.Text
        EncryptS.UniCod.EncryptNow()
        TextBox2.Text = EncryptS.UniCod.EncryptedText


    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        EncryptS.UniCod.txt2Decrypt = TextBox2.Text
        EncryptS.UniCod.DecryptNow()
        TextBox3.Text = EncryptS.UniCod.DecryptedText

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If TextBox1.Text = TextBox3.Text Then
            MsgBox("Successfull")
        Else
            MsgBox("Failed")
        End If


    End Sub

End Class
