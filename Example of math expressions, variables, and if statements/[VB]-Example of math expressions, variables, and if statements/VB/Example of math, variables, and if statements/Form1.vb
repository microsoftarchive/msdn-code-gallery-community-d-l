Public Class Form1
    Private x As String 'This defines the string variable x
    Private y As String
    Private random_string As String
    Private x_number As Integer 'This defines the integer variable x_number
    Private y_number As Integer
    Private random As Integer
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        x = Me.textBox1.Text()
        y = Me.TextBox2.Text
        If x = "" Then 'This sees if x has no value
            x = "0" 'This sets x to 0
        End If
        If y = "" Then 'This sees if x has no value
            y = "0" 'This sets y to 0
        End If
        x_number = Convert.ToInt32(x) 'This converts the string x to a integer then stores it in x_number
        y_number = Convert.ToInt32(y)
        random = x_number + y_number 'This sets the integer variable random to the value of x_number plus y_number
        random_string = Convert.ToString(random) 'This converts the integer random to the string random_string
        Me.Label3.Text = random_string
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        x = Me.TextBox1.Text()
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        random = x_number - y_number
        random_string = Convert.ToString(random)
        Me.Label3.Text = random_string
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        x = Me.TextBox1.Text()
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        random = x_number * y_number
        random_string = Convert.ToString(random)
        Me.Label3.Text = random_string
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        x = Me.TextBox1.Text()
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If y_number = 0 Then
            random_string = "Divide by zero error"
        Else
            random = x_number / y_number
            random_string = Convert.ToString(random)
        End If
        Me.Label3.Text = random_string
    End Sub
    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        x = Me.TextBox1.Text
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If x_number = y_number Then 'This checks if the integer x_number is equal to the integer y_number
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.yes 'If it is the picture is set to a check
        Else 'If they are not then the picture is set as an X
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.no
        End If
    End Sub
    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        x = Me.TextBox1.Text
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If x_number > y_number Then 'This checks if the integer x_number is equal to the integer y_number
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.yes 'If it is the picture is set to a check
        Else 'If they are not then the picture is set as an X
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.no
        End If
    End Sub
    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        x = Me.TextBox1.Text
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If x_number < y_number Then 'This checks if the integer x_number is equal to the integer y_number
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.yes 'If it is the picture is set to a check
        Else 'If they are not then the picture is set as an X
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.no
        End If
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        x = Me.TextBox1.Text
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If x_number >= y_number Then 'This checks if the integer x_number is equal to the integer y_number
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.yes 'If it is the picture is set to a check
        Else 'If they are not then the picture is set as an X
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.no
        End If
    End Sub
    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        x = Me.TextBox1.Text
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If x_number <= y_number Then 'This checks if the integer x_number is equal to the integer y_number
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.yes 'If it is the picture is set to a check
        Else 'If they are not then the picture is set as an X
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.no
        End If
    End Sub
    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        x = Me.TextBox1.Text
        y = Me.TextBox2.Text
        If x = "" Then
            x = "0"
        End If
        If y = "" Then
            y = "0"
        End If
        x_number = Convert.ToInt32(x)
        y_number = Convert.ToInt32(y)
        If x_number <> y_number Then 'This checks if the integer x_number is equal to the integer y_number
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.yes 'If it is the picture is set to a check
        Else 'If they are not then the picture is set as an X
            Me.PictureBox1.Image = Global.Example_of_math_variables_and_if_statements.My.Resources.no
        End If
    End Sub
End Class
