'dll .netFramework
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Class FrmMain
    ' Evento Load del Form FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Richiamo metodo LoadData
        LoadData()
    End Sub

    ' Evento click del pulsante btnInsert
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        ' Dichiaro una nuova istanza della Classe Insert
        Dim i As New Insert()
        ' Passo al metodo setName della Classe Insert il valore inserito dall'utente nel controllo TextBox txtName
        i.setName(Me.txtName.Text)
        ' Passo al metodo setName della Classe Insert il valore inserito dall'utente nel controllo TextBox txtSurName
        i.setSurName(Me.txtSurName.Text)
        ' Passo al metodo setName della Classe Insert il valore inserito dall'utente nel controllo TextBox txAge
        i.setAge(Me.txtAge.Text)

        ' Creo una nuova istanza della Classe DatabaseManagement
        Dim dbInsert As New DatabaseManagement()
        ' Passo al metodo insertData i parametri necessari per la memorizzazione del Nome,Cognome e Età all'interno della
        ' Tabella del DataBase
        dbInsert.insertData(i.getName(), i.getSurName(), i.getAge())
        ' Richiamo metodo LoadData
        LoadData()
    End Sub

    ' Evento click del pulsante btnDelete
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Dichiaro una nuova istanza della Classe Delete
        Dim d As New Delete()
        ' Passo al metodo setName della Classe Delete il valore inserito dall'utente nel controllo TextBox txtName
        d.setName(Me.txtName.Text)
        ' Passo al metodo setName della Classe Delete il valore inserito dall'utente nel controllo TextBox txtSurName
        d.setSurName(Me.txtSurName.Text)
        ' Passo al metodo setName della Classe Delete il valore inserito dall'utente nel controllo TextBox txAge
        d.setAge(Me.txtAge.Text)

        ' Creo una nuova istanza della Classe DatabaseManagement
        Dim dbDelete As New DatabaseManagement()
        ' Passo al metodo deleteData i parametri necessari per la memorizzazione del Nome,Cognome e Età all'interno della
        ' Tabella del DataBase
        dbDelete.deleteData(d.getName(), d.getSurName(), d.getAge())
        ' Richiamo metodo LoadData
        LoadData()
    End Sub

    ' Evento click del pulsante btnUpdate
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Dichiaro una nuova istanza della Classe UpdateDati
        Dim ud As New UpdateDati()
        ' Passo al metodo setName della Classe UpdateDati il valore inserito dall'utente nel controllo TextBox txtName
        ud.setName(Me.txtName.Text)
        ' Passo al metodo setName della Classe UpdateDati il valore inserito dall'utente nel controllo TextBox txtSurName
        ud.setSurName(Me.txtSurName.Text)
        ' Passo al metodo setName della Classe UpdateDati il valore inserito dall'utente nel controllo TextBox txtAge
        ud.setAge(Me.txtAge.Text)

        ' Creo una nuova istanza della Classe DatabaseManagement
        Dim dbUpdate As New DatabaseManagement()
        ' Passo al metodo updateData i parametri necessari per la memorizzazione del Nome,Cognome e Età all'interno della
        ' Tabella del DataBase
        dbUpdate.updateData(ud.getName(), ud.getSurName(), ud.getAge())
        ' Richiamo metodo LoadData
        LoadData()
    End Sub

    ' Evento click del pulsante btnFindTypeData
    Private Sub btnFindTypeData_Click(sender As Object, e As EventArgs) Handles btnFindTypeData.Click
        ' Eseguo controllo sul valore del controllo ComboBox cbxTypeData
        Select Case Me.cbxTypeData.Text
            ' Se valore NAME
            Case "NAME"
                ' Eseguo la query di ricerca LinqToDataSet per nome
                Dim queryName = From c In Me.ExampleDataSet.TABELLA1 Where c.NOME = Me.txtFind.Text.ToUpper()
                                Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryName.AsDataView()
                ' Visualizzo a utente i risultati della ricerca
                Me.lblFind.Text = "Ricerca terminata. Trovati" & " " & queryName.AsDataView().Count.ToString() & " " & "elementi"
                Exit Select

                ' Se valore SURNAME
            Case "SURNAME"
                ' Eseguo la query di ricerca LinqToDataSet per Cognome
                Dim querySurName = From c In Me.ExampleDataSet.TABELLA1 Where c.COGNOME = Me.txtFind.Text.ToUpper()
                                   Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = querySurName.AsDataView()
                ' Visualizzo a utente i risultati della ricerca
                Me.lblFind.Text = "Ricerca terminata. Trovati" & " " & querySurName.AsDataView().Count.ToString() & " " & "elementi"
                Exit Select

                ' Se valore AGE
            Case "AGE"
                ' Eseguo la query di ricerca LinqToDataSet per età
                Dim queryAge = From c In Me.ExampleDataSet.TABELLA1 Where c.AGE = Me.txtFind.Text.ToUpper()
                               Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryAge.AsDataView()
                Me.lblFind.Text = "Ricerca terminata. Trovati" & " " & queryAge.AsDataView().Count.ToString() & " " & "elementi"
                Exit Select
        End Select
    End Sub

    ' Evento click del pulsante btnFindLinq
    Private Sub btnFindLinq_Click(sender As Object, e As EventArgs) Handles btnFindLinq.Click
        ' Eseguo controllo sul valore del controllo ComboBox cbxLinq
        Select Case cbxLinq.Text
            ' Se valore ASCENDING NAME
            Case "ASCENDING NAME"
                ' Eseguo la query di ricerca LinqToDataSet per nome e ordino il 
                ' Risultato in senso crescente
                Dim queryAscendingName = From c In Me.ExampleDataSet.TABELLA1 Order By c.NOME Ascending
                                         Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryAscendingName.AsDataView()
                Exit Select

                ' Se valore DESCENDING NAME
            Case "DESCENDING NAME"
                ' Eseguo la query di ricerca LinqToDataSet per nome e ordino il 
                ' Risultato in senso decrescente
                Dim queryDescendingName = From c In Me.ExampleDataSet.TABELLA1 Order By c.NOME Descending
                                          Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryDescendingName.AsDataView()
                Exit Select

                ' Se valore ASCENDING SURNAME
            Case "ASCENDING SURNAME"
                ' Eseguo la query di ricerca LinqToDataSet per Cognome e ordino il 
                ' Risultato in senso crescente
                Dim queryAscendingSurName = From c In Me.ExampleDataSet.TABELLA1 Order By c.COGNOME Ascending
                                                   Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryAscendingSurName.AsDataView()
                Exit Select

                ' Se valore DESCENDING NAME
            Case "DESCENDING SURNAME"
                ' Eseguo la query di ricerca LinqToDataSet per Cognome e ordino il 
                ' Risultato in senso decrescente
                Dim queryDescendingSurName = From c In Me.ExampleDataSet.TABELLA1 Order By c.COGNOME Descending
                                             Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryDescendingSurName.AsDataView()
                Exit Select

                ' Se valore ASCENDING AGE
            Case "ASCENDING AGE"
                ' Eseguo la query di ricerca LinqToDataSet per età e ordino il 
                ' Risultato in senso crescente
                Dim queryAscendingAge = From c In Me.ExampleDataSet.TABELLA1 Order By c.AGE Ascending
                                        Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryAscendingAge.AsDataView()
                Exit Select

                ' Se valore DESCENDING AGE
            Case "DESCENDING AGE"
                ' Eseguo la query di ricerca LinqToDataSet per età e ordino il 
                ' Risultato in senso decrescente
                Dim queryDescendingAge = From c In Me.ExampleDataSet.TABELLA1 Order By c.AGE Descending
                                         Select c

                ' Assegno il risultato della query alla proprietà DataSource del controllo
                ' DataGridView dgvExample
                Me.dgvExample.DataSource = queryDescendingAge.AsDataView()
                Exit Select
        End Select
    End Sub

    ' Evento click del pulsante btnExit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Esco e chiudo l'applicazione SqlServer example
        Application.[Exit]()
    End Sub

    ' Evento SelectedIndexChanged del ComboBox cbxTypeData
    Private Sub cbxTypeData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTypeData.SelectedIndexChanged
        ' Se l'utente non ha selezionato un criterio di ricerca
        If Me.cbxTypeData.Text.Equals("") Then
            ' Disabilito pulsante btnFindTypeData
            Me.btnFindTypeData.Enabled = False
        Else

            ' Altrimenti
            ' Abilito pulsante btnFindTypeData
            Me.btnFindTypeData.Enabled = True
        End If
    End Sub

    ' Evento SelectedIndexChanged del ComboBox cbxTypeData
    Private Sub cbxLinq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxLinq.SelectedIndexChanged
        ' Se l'utente non ha selezionato un criterio di ricerca
        If Me.cbxLinq.Text.Equals("") Then
            ' Disabilito pulsante btnFindLinq
            Me.btnFindLinq.Enabled = False
        Else

            ' Altrimenti
            ' Abilito pulsante btnFindLinq
            Me.btnFindLinq.Enabled = True
        End If
    End Sub

    ' Evento RowEnter del controllo dgvExample
    Private Sub dgvExample_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExample.RowEnter
        ' Prova
        Try
            ' Assegno al controllo txtName il valore selezionato dall'utente sul controllo dgvExample
            Me.txtName.Text = Me.dgvExample.Rows(e.RowIndex).Cells("NAMES").Value.ToString()
            ' Assegno al controllo txtSurName il valore selezionato dall'utente sul controllo dgvExample
            Me.txtSurName.Text = Me.dgvExample.Rows(e.RowIndex).Cells("SURNAME").Value.ToString()
            ' Assegno al controllo txtAge il valore selezionato dall'utente sul controllo dgvExample
            Me.txtAge.Text = Me.dgvExample.Rows(e.RowIndex).Cells("AGE").Value.ToString()

            ' In caso di eccezzione
        Catch ex As System.Exception
            ' Visualizzo messaggio a utente
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Metodo LoadData
    Private Sub LoadData()
        ' Disabilito pulsante btnFindTypeData
        Me.btnFindTypeData.Enabled = False
        ' Disabilito pulsante btnFindLinq
        Me.btnFindLinq.Enabled = False
        ' Popolo la tabella con i dati presenti nel DataBase
        Me.tABELLA1TableAdapter.Fill(Me.exampleDataSet.TABELLA1)
    End Sub

    Private Sub FrmMain_Load_1(sender As System.Object, e As System.EventArgs)
        'TODO: questa riga di codice carica i dati nella tabella 'ExampleDataSet.TABELLA1'. È possibile spostarla o rimuoverla se necessario.
        'Me.TABELLA1TableAdapter.Fill(Me.ExampleDataSet.TABELLA1)
    End Sub
End Class