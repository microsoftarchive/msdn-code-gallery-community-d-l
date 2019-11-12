' Classe FrmRubrica
Public Class FrmRubrica

    ' Evento load del form FrmRubrica
    Private Sub FrmRubrica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: questa riga di codice carica i dati nella tabella 'RubricaDataSet.TabellaRubrica'. È possibile spostarla o rimuoverla se necessario.
        Me.TabellaRubricaTableAdapter.Fill(Me.RubricaDataSet.TabellaRubrica)
        ' Disabilito pulsante btnElimina
        btnElimina.Enabled = False
        ' Disabilito pulsante btnModifica
        btnModifica.Enabled = False
    End Sub

    ' Evento Click del pulsante btnInserisci
    Private Sub btnInserisci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserisci.Click
        ' Se txtPosizioneRubrica non contiene alcun carattere
        If Me.txtPosizioneRubrica.Text = String.Empty Then
            ' Avviso l'utente che va inserito un numero di posizione rubrica inerente al nome,cognome e telefono
            MessageBox.Show("Inserisci un numero di posizione rubrica", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Altrimenti
        Else
            ' Istanzio un nuovo oggetto di tipo InserisciDatiRubrica 
            Dim idr As New InserisciDatiRubrica
            ' Richiamo la sub setNome della classe InserisciDatiRubrica
            ' passando come parametro il contenuto di txtNome.Text
            idr.setNome(Me.txtNome.Text)
            ' Richiamo la sub setCognome della classe InserisciDatiRubrica
            ' passando come parametro il contenuto di txtCognome.Text
            idr.setCognome(Me.txtCognome.Text)
            ' Richiamo la sub setNumeroTelefono della classe InserisciDatiRubrica
            ' passando come parametro il contenuto di txtTelefono.Text
            idr.setNumeroTelefono(Me.txtTelefono.Text)
            ' Richiamo la sub setPosizioneRubrica della classe InserisciDatiRubrica
            ' passando come parametro il contenuto di txtPosizioneRubrica.Text
            idr.setPosizioneRubrica(Me.txtPosizioneRubrica.Text)


            ' Istanzio un nuovo oggetto di tipo GestioneRubrica 
            Dim gr As New GestioneRubrica
            ' Richiamo il metodo inserisciDatiRubrica() della classe gestioneRubrica
            ' ed implemento i parametri del metodo mediante le funzioni get della Classe InserisciDatiRubrica
            ' Queste funzioni restituiscono i valori memorizzati in precedenza mediante le sub Set
            gr.inserisciDatiRubrica(idr.getNome(), idr.getCognonme(), idr.getNumeroTelefono(), idr.getPosizioneRubrica())
            ' Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
            Me.TabellaRubricaTableAdapter.Fill(Me.RubricaDataSet.TabellaRubrica)
            ' Cancello il contenuto di txtNome
            txtNome.Clear()
            ' Cancello il contenuto di txtCognome
            txtCognome.Clear()
            ' Cancello il contenuto di txtTelefono
            txtTelefono.Clear()
            ' Cancello il contenuto di txtPosizioneRubrica
            txtPosizioneRubrica.Clear()
        End If
    End Sub

    ' Evento Click del pulsante btnElimina
    Private Sub btnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElimina.Click

        ' Istanzio un nuovo oggetto di tipo EliminaDatiRubrica 
        Dim edr As New EliminaDatiRubrica
        ' Richiamo la sub setPosizioneRubricaEliminato della classe EliminaDatiRubrica
        ' passando come parametro il contenuto di txtEliminaPosizioneRubrica.Text
        edr.setPosizioneRubricaEliminato(Me.txtEliminaPosizioneRubrica.Text)



        ' Istanzio un nuovo oggetto di tipo GestioneRubrica 
        Dim gr As New GestioneRubrica
        ' Richiamo il metodo rimuoviDatiRubrica() della classe gestioneRubrica
        ' ed implemento i parametri del metodo mediante la funziona get della Classe EliminaDatiRubrica
        ' Questa funzione restituisce il valore memorizzato in precedenza mediante le sub Set
        gr.rimuoviDatiRubrica(edr.getPosizioneRubricaEliminato())
        ' Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
        Me.TabellaRubricaTableAdapter.Fill(Me.RubricaDataSet.TabellaRubrica)
        ' Abilito pulsante btnElimina
        btnElimina.Enabled = True
        ' Cancello il contenuto di txtEliminaNome
        txtEliminaNome.Clear()
        ' Cancello il contenuto di txtEliminaCognome
        txtEliminaCognome.Clear()
        ' Cancello il contenuto di txtEliminaTelefono
        txtEliminaTelefono.Clear()
        ' Cancello il contenuto di txtEliminaPosizioneRubrica
        txtEliminaPosizioneRubrica.Clear()
        ' Cancello il contenuto di txtNomeAttuale
        txtNomeAttuale.Clear()
        ' Cancello il contenuto di txtCognomeAttuale
        txtCognomeAttuale.Clear()
        ' Cancello il contenuto di txtTelefonoAttuale
        txtTelefonoAttuale.Clear()
        ' Cancello il contenuto di txtPosizioneRubricaAttuale
        txtPosizioneRubricaAttuale.Clear()
    End Sub

    ' Evento Click del pulsante btnModifica
    Private Sub btnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifica.Click

        ' Istanzio un nuovo oggetto di tipo ModificaDatiRubrica 
        Dim mdr As New ModificaDatiRubrica
        ' Richiamo la sub setNomeModificato della classe ModificaDatiRubrica
        ' passando come parametro il contenuto di txtNomeAttuale.Text
        mdr.setNomeModificato(Me.txtNomeAttuale.Text)
        ' Richiamo la sub setCognomeModificato della classe ModificaDatiRubrica
        ' passando come parametro il contenuto di txtCognomeAttuale.Text
        mdr.setCognomeModificato(Me.txtCognomeAttuale.Text)
        ' Richiamo la sub setNumeroTelefono della classe ModificaDatiRubrica
        ' passando come parametro il contenuto di txtTelefonoAttuale.Text
        mdr.setNumeroTelefono(Me.txtTelefonoAttuale.Text)
        ' Richiamo la sub setPosizioneRubrica della classe ModificaDatiRubrica
        ' passando come parametro il contenuto di txtPosizioneRubricaAttuale.Text
        mdr.setPosizioneRubrica(Me.txtPosizioneRubricaAttuale.Text)


        ' Istanzio un nuovo oggetto di tipo GestioneRubrica 
        Dim gr As New GestioneRubrica
        ' Richiamo il metodo modificaDatiRubrica della classe gestioneRubrica
        ' ed implemento i parametri del metodo mediante le funzioni get della Classe ModificaDatiRubrica
        ' Queste funzioni restituiscono i valori memorizzati in precedenza mediante le sub Set
        gr.modificaDatiRubrica(mdr.getNomeModificato(), mdr.getCognonmeModoficato(), mdr.getNumeroTelefonoModificato(), mdr.getPosizioneRubrica())
        ' Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
        Me.TabellaRubricaTableAdapter.Fill(Me.RubricaDataSet.TabellaRubrica)
        ' Abilito pulsante btnModifica
        btnModifica.Enabled = True
        ' Cancello il contenuto di txtNomeAttuale
        txtNomeAttuale.Clear()
        ' Cancello il contenuto di txtCognomeAttuale
        txtCognomeAttuale.Clear()
        ' Cancello il contenuto di txtTelefonoAttuale
        txtTelefonoAttuale.Clear()
        ' Cancello il contenuto di txtPosizioneRubricaAttuale
        txtPosizioneRubricaAttuale.Clear()
        ' Cancello il contenuto di txtEliminaNome
        txtEliminaNome.Clear()
        ' Cancello il contenuto di txtEliminaCognome
        txtEliminaCognome.Clear()
        ' Cancello il contenuto di txtEliminaTelefono
        txtEliminaTelefono.Clear()
        ' Cancello il contenuto di txtEliminaPosizioneRubrica
        txtEliminaPosizioneRubrica.Clear()
    End Sub

 

    ' Evento Click del pulsante btnAggiorna
    Private Sub btnAggiorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiorna.Click
        ' Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
        Me.TabellaRubricaTableAdapter.Fill(Me.RubricaDataSet.TabellaRubrica)
    End Sub

    ' Evento Click del pulsante btnEsciToolStripMenuItem
    Private Sub EsciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsciToolStripMenuItem.Click
        ' Chiudo l'applicazione Rubrica
        Application.Exit()
    End Sub

    ' Evento RowHeaderMouseClick di dtgRubrica
    Private Sub dtgRubrica_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgRubrica.RowHeaderMouseClick
        ' Questa parte di codice serve per selezionare i dati da un record e successivamente l'utente
        ' può decidere se eliminare o modificare uno o più campi del record , bisogna per fare ciò
        ' impostare la proprietà Multiselect del datagridview a false
        ' Prova
        Try
            ' Assegno a txtNomeAttuale il contenuto della cella NOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtNomeAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("NOME").Value
            ' Assegno a txtCognomeAttuale il contenuto della cella COGNOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtCognomeAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("COGNOME").Value
            ' Assegno a txtTelefonoAttuale il contenuto della cella TELEFONODataGridViewTextBoxColumn della riga selezionata
            Me.txtTelefonoAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("TELEFONO").Value
            ' Assegno a txtPosizioneRubricaAttuale il contenuto della cella POSIZIONERUBRICADataGridViewTextBoxColumn della riga selezionata
            Me.txtPosizioneRubricaAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("POSIZIONE_RUBRICA").Value
            ' Abilito pulsante btnModifica
            btnModifica.Enabled = True

            ' Assegno a txtEliminaNome il contenuto della cella NOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaNome.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("NOME").Value
            ' Assegno a txtEliminaCognome il contenuto della cella COGNOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaCognome.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("COGNOME").Value
            ' Assegno a txtEliminaTelefono il contenuto della cella TELEFONODataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaTelefono.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("TELEFONO").Value
            ' Assegno a txtEliminaPosizioneRubrica il contenuto della cella POSIZIONERUBRICADataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaPosizioneRubrica.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells("POSIZIONE_RUBRICA").Value
            ' Abilito pulsante btnElimina
            btnElimina.Enabled = True

            ' Nel caso di eccezzione
        Catch ex As Exception
            ' Visualizzo un messaggio all'utente ad indicare che la riga del datagridview selezionata e priva di dati
            MessageBox.Show("Nessun nome,cognome o indirizzo selezionati", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ' Evento Click del pulsante btnRicerca
    Private Sub btnRicerca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRicerca.Click

        ' Eseguo il costrutto SelectCase su parametro tiporicerca
        Select Case Me.cbTipoRicerca.Text
            ' Se tiporicerca ha come valore NOME
            Case "NOME"
                ' Prova
                Try
                    'Esegue la query di ricerca TrovaNome
                    Me.TabellaRubricaTableAdapter.TrovaNome(Me.RubricaDataSet.TabellaRubrica, Me.txtRicerca.Text)

                    ' Nel caso di eccezzione
                Catch ex As System.Exception
                    ' Visualizzo un messaggio all'utente con l'eccezzione sollevata
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try

                ' Se tiporicerca ha come valore COGNOME
            Case "COGNOME"
                ' Prova
                Try
                    'Esegue la query di ricerca TrovaCognome
                    Me.TabellaRubricaTableAdapter.TrovaCognome(Me.RubricaDataSet.TabellaRubrica, Me.txtRicerca.Text)

                    ' Nel caso di eccezzione
                Catch ex As System.Exception
                    ' Visualizzo un messaggio all'utente con l'eccezzione sollevata
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try

                ' Se tiporicerca ha come valore TELEFONO
            Case "TELEFONO"
                ' Prova
                Try
                    'Esegue la query di ricerca TrovaTelefono
                    Me.TabellaRubricaTableAdapter.TrovaTelefono(Me.RubricaDataSet.TabellaRubrica, Me.txtRicerca.Text)

                    ' Nel caso di eccezzione
                Catch ex As System.Exception
                    ' Visualizzo un messaggio all'utente con l'eccezzione sollevata
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try
        End Select
    End Sub
End Class

