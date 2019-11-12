'Classe FrmAutoComplete
Public Class FrmAutoComplete
    'Evento Click del Pulsante TABELLAPAROLEBindingNavigatorSaveItem
    Private Sub TABELLAPAROLEBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles TABELLAPAROLEBindingNavigatorSaveItem.Click
        'Verifica il valore del controllo che non è più attivo
        Me.Validate()

        'Appplica le modifiche all'origine dati sottostante
        Me.TABELLAPAROLEBindingSource.EndEdit()

        'Aggiorna tutte le modifiche al dataset
        Me.TableAdapterManager.UpdateAll(Me.ParoleDataSet)
    End Sub

    'Evento load del form FrmAutoComplete
    Private Sub FrmAutoComplete_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TABELLAPAROLETableAdapter.Fill(Me.ParoleDataSet.TABELLAPAROLE)

        'Assegno alla proprietà AutoCompleteMode della TxtBox il valore AutoCompleteMode.Suggest, necessario
        'per eseguire l'autocompletamento e suggerire le parole con una specifica lettera iniziale
        Me.TxtAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest

        'Assegno alla proprietà AutoCompleteSource il valore AutoCompleteSource.CustomSource per indicare che
        'la sorgente per l'autocompletemento e prsonalizzata.
        Me.TxtAutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource

        ' Se la variabile AutoComplete non e nothing
        If My.MySettings.Default.AutoComplete IsNot Nothing Then

            'Assegna alla proprietà AutoCompleteCustomSource di TxtAutoCmplete il contenuto della 
            'Variabile AutoComplete
            Me.TxtAutoComplete.AutoCompleteCustomSource = My.MySettings.Default.AutoComplete

            'Altrimenti
        Else

            'Crea un istanza di AutoComplete
            My.MySettings.Default.AutoComplete = New System.Windows.Forms.AutoCompleteStringCollection
        End If
    End Sub

    'Evento Click del Pulsante btnAutocomplete
    Private Sub btnAutocomplete_Click(sender As System.Object, e As System.EventArgs) Handles btnAutocomplete.Click
        'Prova
        Try
            'Ottiene il numero di righe che contiene la Tabella del DataGridView
            Dim rows As Integer = AutoCompleteDataGridView.RowCount

            'Dichiaro una variabile di tipo integer che servirà per scorrere tutte le righe del DataGridWiev 
            Dim i As Integer

            'Eseguo l'iterazione della variabile i
            For i = 0 To rows - 1
                'Aggiungo alla variabile AutoComplete tutti i valore dela cella PAROLE 
                My.MySettings.Default.AutoComplete.Add(AutoCompleteDataGridView.Rows(i).Cells("PAROLE").Value.ToString)
                'Iterazione successiva
            Next

            'Assegna alla proprietà AutoCompleteCustomSource di TxtAutoCmplete il contenuto della 
            'Variabile AutoComplete
            Me.TxtAutoComplete.AutoCompleteCustomSource = My.MySettings.Default.AutoComplete

            'Eseguo il salvataggio delle impostazioni dell'applicazione
            My.MySettings.Default.Save()

        Catch ex As Exception

        End Try
    End Sub
End Class
