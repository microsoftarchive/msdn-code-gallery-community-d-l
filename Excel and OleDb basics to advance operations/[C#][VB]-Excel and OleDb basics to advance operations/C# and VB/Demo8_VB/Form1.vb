Imports System.Data.OleDb
''' <summary>
''' Shows some methods to work with Excel via OleDb DataAdapter.
''' Not meant to be perfect and is not but done for various post in the web.
''' </summary>
''' <remarks>
''' </remarks>
Public Class Form1
    Private FileName As String = IO.Path.Combine(Application.StartupPath, "File1.xls")
    Private cn As OleDbConnection = New OleDbConnection
    Private DataSet1 As DataSet = New DataSet()
    Private ExcelAdapter As OleDbDataAdapter = New OleDbDataAdapter
    WithEvents bsData As New BindingSource

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetCueText(txtNewFirstName, "Enter a first name")
        SetCueText(txtNewLastName, "Enter a last name")

        SetCueText(txtFirstName, "Enter a first name")
        SetCueText(txtLastName, "Enter a last name")

        cn.SetExcelConnectionString(FileName, UseHeader.Yes, ExcelImex.TryScan)
        '
        ' &lt;&gt; equates to <>
        '
        Dim cmd As OleDbCommand =
            New OleDbCommand(
            <SQL>
                  SELECT Firstname, Lastname
                  FROM [Sheet1$] 
                  WHERE 
                      FirstName &lt;&gt;  '' AND  
                      lastName &lt;&gt;  '' 
            </SQL>.Value, cn)

        ExcelAdapter.SelectCommand = cmd

        cn.Open()

        ExcelAdapter.Fill(DataSet1, "Sheet1")

        bsData.DataSource = DataSet1.Tables("Sheet1").DefaultView

        DataSet1.Tables("Sheet1").Columns.Add(New DataColumn With
                                              {
                                                  .ColumnName = "FullName",
                                                  .DataType = GetType(String),
                                                  .Expression = "FirstName + ' ' + LastName"
                                              }
                                          )

        DataGridView1.DataSource = bsData

        ExcelAdapter.InsertCommand = New OleDbCommand With {.CommandText = "INSERT INTO [Sheet1$] VALUES(@P1,@P2,@P3)", .Connection = cn}
        ExcelAdapter.InsertCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P1", .OleDbType = OleDbType.WChar})
        ExcelAdapter.InsertCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P2", .OleDbType = OleDbType.WChar})
        ExcelAdapter.InsertCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P3", .OleDbType = OleDbType.Integer})

        ExcelAdapter.UpdateCommand = New OleDbCommand With _
                             { _
                                 .CommandText = _
                                 <SQL>
                                     UPDATE [Sheet1$] 
                                     SET FirstName=@P1, LastName = @P2
                                     WHERE FirstName=@P3 AND LastName = @P4
                                 </SQL>.Value, _
                                 .Connection = cn
                             }

        ExcelAdapter.UpdateCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P1", .OleDbType = OleDbType.WChar})
        ExcelAdapter.UpdateCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P2", .OleDbType = OleDbType.WChar})
        ExcelAdapter.UpdateCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P3", .OleDbType = OleDbType.WChar})
        ExcelAdapter.UpdateCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P4", .OleDbType = OleDbType.WChar})

        '
        ' A cheap way to get rid of rows but in reality they made into blank rows in Excel since ISAM driver
        ' does not support delete. Thus we could (but are not) use early binding to do this.
        '
        ExcelAdapter.DeleteCommand = New OleDbCommand With _
                            {
                                .CommandText = ExcelAdapter.UpdateCommand.CommandText,
                                .Connection = cn
                            }

        ExcelAdapter.DeleteCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P1", .OleDbType = OleDbType.WChar})
        ExcelAdapter.DeleteCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P2", .OleDbType = OleDbType.WChar})
        ExcelAdapter.DeleteCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P3", .OleDbType = OleDbType.WChar})
        ExcelAdapter.DeleteCommand.Parameters.Add(New OleDbParameter With {.ParameterName = "@P4", .OleDbType = OleDbType.WChar})


        DataGridView1.Columns("FirstName").HeaderText = "First"
        DataGridView1.Columns("LastName").HeaderText = "Last"

    End Sub

    Private Sub cmdInsertRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertRow.Click
        If Not String.IsNullOrWhiteSpace(txtFirstName.Text) AndAlso Not String.IsNullOrWhiteSpace(txtLastName.Text) Then

            If PersonExist(FileName, "Sheet1", txtFirstName.Text, txtLastName.Text) Then
                MessageBox.Show("This would create a duplicate person, aborting")
                Exit Sub
            End If

            ExcelAdapter.InsertCommand.Parameters(0).Value = txtFirstName.Text
            ExcelAdapter.InsertCommand.Parameters(1).Value = txtLastName.Text
            ExcelAdapter.InsertCommand.Parameters(2).Value = txtLength.Text
            Try
                Dim Affected = ExcelAdapter.InsertCommand.ExecuteNonQuery()
                If Affected = 1 Then
                    CType(bsData.DataSource, DataView).Table.Rows.Add(New Object() {txtFirstName.Text, txtLastName.Text})
                    MessageBox.Show("Record added")
                    ActiveControl = DataGridView1
                Else
                    MessageBox.Show("Failed to add record.")
                End If
            Catch ex As Exception
                MessageBox.Show(
                    String.Format("System error adding record.{0}{1}", Environment.NewLine, ex.Message))
            End Try
        Else
            MessageBox.Show("Please enter a first and last name")
        End If
    End Sub
    Private Sub cmdUpdateCurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCurrent.Click
        If Not String.IsNullOrWhiteSpace(txtNewFirstName.Text) AndAlso Not String.IsNullOrWhiteSpace(txtNewLastName.Text) Then
            If PersonExist(FileName, "Sheet1", txtNewFirstName.Text, txtNewLastName.Text) Then
                MessageBox.Show("This would create a duplicate person, aborting")
                Exit Sub
            End If
            Dim Row As DataRow = CType(bsData.Current, DataRowView).Row

            ExcelAdapter.UpdateCommand.Parameters(0).Value = txtNewFirstName.Text
            ExcelAdapter.UpdateCommand.Parameters(1).Value = txtNewLastName.Text
            ExcelAdapter.UpdateCommand.Parameters(2).Value = Row.Field(Of String)("FirstName")
            ExcelAdapter.UpdateCommand.Parameters(3).Value = Row.Field(Of String)("LastName")


            Try

                Dim Affected = ExcelAdapter.UpdateCommand.ExecuteNonQuery()

                Console.WriteLine(Affected)
                If Affected = 1 Then
                    CType(bsData.Current, DataRowView).Row.SetField(Of String)("FirstName", txtNewFirstName.Text)
                    CType(bsData.Current, DataRowView).Row.SetField(Of String)("LastName", txtNewLastName.Text)
                    MessageBox.Show("Record updated")
                    ActiveControl = DataGridView1
                ElseIf Affected > 1 Then
                    '
                    ' We could prevent this by having another select query run first to see if there are
                    ' duplicates
                    '
                    MessageBox.Show("Well you just updated more than one row")
                Else

                    MessageBox.Show("Failed to update record. Affected: " & Affected.ToString)
                End If
            Catch ex As Exception
                MessageBox.Show(String.Format("System error updating record.{0}{1}", Environment.NewLine, ex.Message))
            End Try
        Else
            MessageBox.Show("Please enter a first and last name")
        End If
    End Sub
    Private Sub bsData_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsData.PositionChanged
        If bsData.Current IsNot Nothing Then
            '
            ' You can determine say row here for Excel
            '
        End If
    End Sub


    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If Not e.ColumnIndex = DataGridView1.Columns("FullName").DisplayIndex Then
            If Not DataGridView1.CurrentRow.IsNewRow Then
                lblAddress.Text = String.Format("{0}:{1}", (e.ColumnIndex + 1).ExcelColumnName, e.RowIndex + 2)
            End If
        End If
    End Sub
    Private Sub cmdGetCurrentRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetCurrentRow.Click
        If bsData.Current IsNot Nothing Then
            Dim row As DataRow = CType(bsData.Current, DataRowView).Row
            txtNewFirstName.Text = row.Field(Of String)("FirstName")
            txtNewLastName.Text = row.Field(Of String)("LastName")
        End If
    End Sub
    ''' <summary>
    ''' Would not suggest this, read comments in form load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDeleteCurrentRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteCurrentRow.Click
        If bsData.Current IsNot Nothing Then
            Dim row As DataRow = CType(bsData.Current, DataRowView).Row
            If My.Dialogs.Question("Remove '" & row.Field(Of String)("Fullname") & "' ?") Then
                ExcelAdapter.DeleteCommand.Parameters(0).Value = ""
                ExcelAdapter.DeleteCommand.Parameters(1).Value = ""
                ExcelAdapter.DeleteCommand.Parameters(2).Value = row.Field(Of String)("FirstName")
                ExcelAdapter.DeleteCommand.Parameters(3).Value = row.Field(Of String)("LastName")
                Dim Affected = ExcelAdapter.DeleteCommand.ExecuteNonQuery
                If Affected <> 1 Then
                    My.Dialogs.ExceptionDialog("Failed to remove person")
                Else
                    bsData.RemoveCurrent()
                End If
            End If
        End If
    End Sub
End Class
