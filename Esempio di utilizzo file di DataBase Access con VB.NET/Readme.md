# Esempio di utilizzo file di DataBase Access con VB.NET
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- Microsoft Office Access
## Topics
- Data Access
## Updated
- 06/20/2011
## Description

<h1>Introduction</h1>
<div><em>Questo esempio di codice vuole dimostrare come poter eseguire operazioni di insert,update e delete su un file di DataBase Access,mediante l'utilizzo di query.L'applicazione di esempio e necessita di un file di DataBase Access 2007 contenente una tabella
 di nome TabellaRubrica,all'interno sono presenti quattro campi denominati &quot;Nome&quot;,&quot;Cognome&quot;,&quot;Telefono&quot;,PosizioneRubrica&quot;.Nel form principale sono presenti cinque sezioni inerenti all'inserimento dei dati , la modifica , l'eliminazione ,una sezione per la ricerca
 dei contatti della rubrica suddivisi in tre modalit&agrave;,per nome ,cognome e telefono.Infine ci sar&agrave; anche un controllo DataGridWiev associato alla tabella Del DataBase Rubrica che provvedera a visualizzare tutti i dati inseriti all'interno della
 tabella del DataBase Rubrica. Il funzionamento parte mediante l'inserimento di un nuovo record di dati , bisognar&agrave; compilare in ogni sua parte la sezione ISERIMENTO DATI e confermare con il pulsante inserisci una volta compilate tutte le caselle di
 testo.E possibile anche modificare ed eliminare i dati inseriti in precedenza selezionando il record da modificare ed eliminare ,automaticamente verranno popolate le caselle di testo delle sezioni MODIFICA DATI ed ELIMINAZIONE DATI. A quel punto sar&agrave;
 possibile modificare ed aggiornare i dati o eliminarli in maniera definitiva dal DataBase. Nella Classe RubricaDAO.vb si fa uso delle query parametriche per l'inserimento dei dati in rubrica,per maggiori ed esaustivi chiarimenti consultare la documentazione
 su MSDN Liv&igrave;brary.</em></div>
<h1><span>Building the Sample</span></h1>
<div><em>Per poter eseguire l'esempio occorre aver installato il .netFramework4 , MicrosoftAccess 2007 o<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=C06B8369-60DD-4B64-A44B-84B371EDE16D&displaylang=en">MicrosoftDataBaseEngine2010Redistributable</a>
 e crearsi un file di DataBase con Access 2007 con al suo interno una tabella denominata TabellaRubrica , con 5 campi ,ID contatore , NOME,COGNOME.TELEFONO,POSIZIONE_RUBRICA tutti di tipo testo. L'applicazione di esempio ha il DataBase in posizione D:\Rubrica.accbd,
 se non si dispone di un unit&agrave; D su proprio pc, occorre modificare il percorso a seconda di dove risiede il file di DataBase nelle impostazioni dell'applicazione e nel file RubricaDAO.vb.</em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Classe FrmRubrica
Public Class FrmRubrica

    ' Evento load del form FrmRubrica
    Private Sub FrmRubrica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: questa riga di codice carica i dati nella tabella 'RubricaDataSet.TabellaRubrica'. &Egrave; possibile spostarla o rimuoverla se necessario.
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
            MessageBox.Show(&quot;Inserisci un numero di posizione rubrica&quot;, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        ' pu&ograve; decidere se eliminare o modificare uno o pi&ugrave; campi del record , bisogna per fare ci&ograve;
        ' impostare la propriet&agrave; Multiselect del datagridview a false
        ' Prova
        Try
            ' Assegno a txtNomeAttuale il contenuto della cella NOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtNomeAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;NOME&quot;).Value
            ' Assegno a txtCognomeAttuale il contenuto della cella COGNOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtCognomeAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;COGNOME&quot;).Value
            ' Assegno a txtTelefonoAttuale il contenuto della cella TELEFONODataGridViewTextBoxColumn della riga selezionata
            Me.txtTelefonoAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;TELEFONO&quot;).Value
            ' Assegno a txtPosizioneRubricaAttuale il contenuto della cella POSIZIONERUBRICADataGridViewTextBoxColumn della riga selezionata
            Me.txtPosizioneRubricaAttuale.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;POSIZIONE_RUBRICA&quot;).Value
            ' Abilito pulsante btnModifica
            btnModifica.Enabled = True

            ' Assegno a txtEliminaNome il contenuto della cella NOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaNome.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;NOME&quot;).Value
            ' Assegno a txtEliminaCognome il contenuto della cella COGNOMEDataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaCognome.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;COGNOME&quot;).Value
            ' Assegno a txtEliminaTelefono il contenuto della cella TELEFONODataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaTelefono.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;TELEFONO&quot;).Value
            ' Assegno a txtEliminaPosizioneRubrica il contenuto della cella POSIZIONERUBRICADataGridViewTextBoxColumn della riga selezionata
            Me.txtEliminaPosizioneRubrica.Text = Me.dtgRubrica.Rows(Me.dtgRubrica.CurrentRow.Index).Cells(&quot;POSIZIONE_RUBRICA&quot;).Value
            ' Abilito pulsante btnElimina
            btnElimina.Enabled = True

            ' Nel caso di eccezzione
        Catch ex As Exception
            ' Visualizzo un messaggio all'utente ad indicare che la riga del datagridview selezionata e priva di dati
            MessageBox.Show(&quot;Nessun nome,cognome o indirizzo selezionati&quot;, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ' Evento Click del pulsante btnRicerca
    Private Sub btnRicerca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRicerca.Click

        ' Eseguo il costrutto SelectCase su parametro tiporicerca
        Select Case Me.cbTipoRicerca.Text
            ' Se tiporicerca ha come valore NOME
            Case &quot;NOME&quot;
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
            Case &quot;COGNOME&quot;
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
            Case &quot;TELEFONO&quot;
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

</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Classe&nbsp;FrmRubrica</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;FrmRubrica&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;load&nbsp;del&nbsp;form&nbsp;FrmRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;FrmRubrica_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'TODO:&nbsp;questa&nbsp;riga&nbsp;di&nbsp;codice&nbsp;carica&nbsp;i&nbsp;dati&nbsp;nella&nbsp;tabella&nbsp;'RubricaDataSet.TabellaRubrica'.&nbsp;&Egrave;&nbsp;possibile&nbsp;spostarla&nbsp;o&nbsp;rimuoverla&nbsp;se&nbsp;necessario.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Disabilito&nbsp;pulsante&nbsp;btnElimina</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnElimina.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Disabilito&nbsp;pulsante&nbsp;btnModifica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnModifica.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnInserisci</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnInserisci_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnInserisci.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;txtPosizioneRubrica&nbsp;non&nbsp;contiene&nbsp;alcun&nbsp;carattere</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.txtPosizioneRubrica.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Avviso&nbsp;l'utente&nbsp;che&nbsp;va&nbsp;inserito&nbsp;un&nbsp;numero&nbsp;di&nbsp;posizione&nbsp;rubrica&nbsp;inerente&nbsp;al&nbsp;nome,cognome&nbsp;e&nbsp;telefono</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Inserisci&nbsp;un&nbsp;numero&nbsp;di&nbsp;posizione&nbsp;rubrica&quot;</span>,&nbsp;Application.ProductName.ToString(),&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Information)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Altrimenti</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;InserisciDatiRubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;idr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;InserisciDatiRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setNome&nbsp;della&nbsp;classe&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtNome.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idr.setNome(<span class="visualBasic__keyword">Me</span>.txtNome.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setCognome&nbsp;della&nbsp;classe&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtCognome.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idr.setCognome(<span class="visualBasic__keyword">Me</span>.txtCognome.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setNumeroTelefono&nbsp;della&nbsp;classe&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtTelefono.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idr.setNumeroTelefono(<span class="visualBasic__keyword">Me</span>.txtTelefono.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setPosizioneRubrica&nbsp;della&nbsp;classe&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtPosizioneRubrica.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idr.setPosizioneRubrica(<span class="visualBasic__keyword">Me</span>.txtPosizioneRubrica.Text)&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;GestioneRubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;gr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GestioneRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;il&nbsp;metodo&nbsp;inserisciDatiRubrica()&nbsp;della&nbsp;classe&nbsp;gestioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;ed&nbsp;implemento&nbsp;i&nbsp;parametri&nbsp;del&nbsp;metodo&nbsp;mediante&nbsp;le&nbsp;funzioni&nbsp;get&nbsp;della&nbsp;Classe&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Queste&nbsp;funzioni&nbsp;restituiscono&nbsp;i&nbsp;valori&nbsp;memorizzati&nbsp;in&nbsp;precedenza&nbsp;mediante&nbsp;le&nbsp;sub&nbsp;Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.inserisciDatiRubrica(idr.getNome(),&nbsp;idr.getCognonme(),&nbsp;idr.getNumeroTelefono(),&nbsp;idr.getPosizioneRubrica())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Aggiorno&nbsp;la&nbsp;visualizzazione&nbsp;di&nbsp;TabellaRubrica&nbsp;sul&nbsp;DataGridView1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtNome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtNome.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtCognome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtCognome.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtTelefono</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtTelefono.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtPosizioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtPosizioneRubrica.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnElimina</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnElimina_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnElimina.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;EliminaDatiRubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;edr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;EliminaDatiRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setPosizioneRubricaEliminato&nbsp;della&nbsp;classe&nbsp;EliminaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaPosizioneRubrica.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;edr.setPosizioneRubricaEliminato(<span class="visualBasic__keyword">Me</span>.txtEliminaPosizioneRubrica.Text)&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;GestioneRubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;gr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GestioneRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;il&nbsp;metodo&nbsp;rimuoviDatiRubrica()&nbsp;della&nbsp;classe&nbsp;gestioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;ed&nbsp;implemento&nbsp;i&nbsp;parametri&nbsp;del&nbsp;metodo&nbsp;mediante&nbsp;la&nbsp;funziona&nbsp;get&nbsp;della&nbsp;Classe&nbsp;EliminaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;memorizzato&nbsp;in&nbsp;precedenza&nbsp;mediante&nbsp;le&nbsp;sub&nbsp;Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.rimuoviDatiRubrica(edr.getPosizioneRubricaEliminato())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Aggiorno&nbsp;la&nbsp;visualizzazione&nbsp;di&nbsp;TabellaRubrica&nbsp;sul&nbsp;DataGridView1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Abilito&nbsp;pulsante&nbsp;btnElimina</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnElimina.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaNome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaNome.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaCognome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaCognome.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaTelefono</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaTelefono.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaPosizioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaPosizioneRubrica.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtNomeAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtNomeAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtCognomeAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtCognomeAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtTelefonoAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtTelefonoAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtPosizioneRubricaAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtPosizioneRubricaAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnModifica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnModifica_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnModifica.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;ModificaDatiRubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;mdr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ModificaDatiRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setNomeModificato&nbsp;della&nbsp;classe&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtNomeAttuale.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mdr.setNomeModificato(<span class="visualBasic__keyword">Me</span>.txtNomeAttuale.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setCognomeModificato&nbsp;della&nbsp;classe&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtCognomeAttuale.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mdr.setCognomeModificato(<span class="visualBasic__keyword">Me</span>.txtCognomeAttuale.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setNumeroTelefono&nbsp;della&nbsp;classe&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtTelefonoAttuale.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mdr.setNumeroTelefono(<span class="visualBasic__keyword">Me</span>.txtTelefonoAttuale.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;la&nbsp;sub&nbsp;setPosizioneRubrica&nbsp;della&nbsp;classe&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;passando&nbsp;come&nbsp;parametro&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtPosizioneRubricaAttuale.Text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mdr.setPosizioneRubrica(<span class="visualBasic__keyword">Me</span>.txtPosizioneRubricaAttuale.Text)&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;GestioneRubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;gr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;GestioneRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;il&nbsp;metodo&nbsp;modificaDatiRubrica&nbsp;della&nbsp;classe&nbsp;gestioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;ed&nbsp;implemento&nbsp;i&nbsp;parametri&nbsp;del&nbsp;metodo&nbsp;mediante&nbsp;le&nbsp;funzioni&nbsp;get&nbsp;della&nbsp;Classe&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Queste&nbsp;funzioni&nbsp;restituiscono&nbsp;i&nbsp;valori&nbsp;memorizzati&nbsp;in&nbsp;precedenza&nbsp;mediante&nbsp;le&nbsp;sub&nbsp;Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gr.modificaDatiRubrica(mdr.getNomeModificato(),&nbsp;mdr.getCognonmeModoficato(),&nbsp;mdr.getNumeroTelefonoModificato(),&nbsp;mdr.getPosizioneRubrica())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Aggiorno&nbsp;la&nbsp;visualizzazione&nbsp;di&nbsp;TabellaRubrica&nbsp;sul&nbsp;DataGridView1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Abilito&nbsp;pulsante&nbsp;btnModifica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnModifica.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtNomeAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtNomeAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtCognomeAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtCognomeAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtTelefonoAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtTelefonoAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtPosizioneRubricaAttuale</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtPosizioneRubricaAttuale.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaNome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaNome.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaCognome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaCognome.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaTelefono</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaTelefono.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancello&nbsp;il&nbsp;contenuto&nbsp;di&nbsp;txtEliminaPosizioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtEliminaPosizioneRubrica.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnAggiorna</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnAggiorna_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnAggiorna.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Aggiorno&nbsp;la&nbsp;visualizzazione&nbsp;di&nbsp;TabellaRubrica&nbsp;sul&nbsp;DataGridView1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnEsciToolStripMenuItem</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;EsciToolStripMenuItem_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;EsciToolStripMenuItem.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Chiudo&nbsp;l'applicazione&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.<span class="visualBasic__keyword">Exit</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;RowHeaderMouseClick&nbsp;di&nbsp;dtgRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;dtgRubrica_RowHeaderMouseClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.Forms.DataGridViewCellMouseEventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;dtgRubrica.RowHeaderMouseClick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;parte&nbsp;di&nbsp;codice&nbsp;serve&nbsp;per&nbsp;selezionare&nbsp;i&nbsp;dati&nbsp;da&nbsp;un&nbsp;record&nbsp;e&nbsp;successivamente&nbsp;l'utente</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;pu&ograve;&nbsp;decidere&nbsp;se&nbsp;eliminare&nbsp;o&nbsp;modificare&nbsp;uno&nbsp;o&nbsp;pi&ugrave;&nbsp;campi&nbsp;del&nbsp;record&nbsp;,&nbsp;bisogna&nbsp;per&nbsp;fare&nbsp;ci&ograve;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;impostare&nbsp;la&nbsp;propriet&agrave;&nbsp;Multiselect&nbsp;del&nbsp;datagridview&nbsp;a&nbsp;false</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtNomeAttuale&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;NOMEDataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtNomeAttuale.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;NOME&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtCognomeAttuale&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;COGNOMEDataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtCognomeAttuale.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;COGNOME&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtTelefonoAttuale&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;TELEFONODataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtTelefonoAttuale.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;TELEFONO&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtPosizioneRubricaAttuale&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;POSIZIONERUBRICADataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtPosizioneRubricaAttuale.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;POSIZIONE_RUBRICA&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Abilito&nbsp;pulsante&nbsp;btnModifica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnModifica.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtEliminaNome&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;NOMEDataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtEliminaNome.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;NOME&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtEliminaCognome&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;COGNOMEDataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtEliminaCognome.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;COGNOME&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtEliminaTelefono&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;TELEFONODataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtEliminaTelefono.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;TELEFONO&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Assegno&nbsp;a&nbsp;txtEliminaPosizioneRubrica&nbsp;il&nbsp;contenuto&nbsp;della&nbsp;cella&nbsp;POSIZIONERUBRICADataGridViewTextBoxColumn&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.txtEliminaPosizioneRubrica.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.dtgRubrica.Rows(<span class="visualBasic__keyword">Me</span>.dtgRubrica.CurrentRow.Index).Cells(<span class="visualBasic__string">&quot;POSIZIONE_RUBRICA&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Abilito&nbsp;pulsante&nbsp;btnElimina</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnElimina.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Nel&nbsp;caso&nbsp;di&nbsp;eccezzione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Visualizzo&nbsp;un&nbsp;messaggio&nbsp;all'utente&nbsp;ad&nbsp;indicare&nbsp;che&nbsp;la&nbsp;riga&nbsp;del&nbsp;datagridview&nbsp;selezionata&nbsp;e&nbsp;priva&nbsp;di&nbsp;dati</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Nessun&nbsp;nome,cognome&nbsp;o&nbsp;indirizzo&nbsp;selezionati&quot;</span>,&nbsp;Application.ProductName.ToString(),&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Information)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Evento&nbsp;Click&nbsp;del&nbsp;pulsante&nbsp;btnRicerca</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnRicerca_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnRicerca.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Eseguo&nbsp;il&nbsp;costrutto&nbsp;SelectCase&nbsp;su&nbsp;parametro&nbsp;tiporicerca</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__keyword">Me</span>.cbTipoRicerca.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;tiporicerca&nbsp;ha&nbsp;come&nbsp;valore&nbsp;NOME</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;NOME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Esegue&nbsp;la&nbsp;query&nbsp;di&nbsp;ricerca&nbsp;TrovaNome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.TrovaNome(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica,&nbsp;<span class="visualBasic__keyword">Me</span>.txtRicerca.Text)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Nel&nbsp;caso&nbsp;di&nbsp;eccezzione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Visualizzo&nbsp;un&nbsp;messaggio&nbsp;all'utente&nbsp;con&nbsp;l'eccezzione&nbsp;sollevata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Forms.MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;tiporicerca&nbsp;ha&nbsp;come&nbsp;valore&nbsp;COGNOME</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;COGNOME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Esegue&nbsp;la&nbsp;query&nbsp;di&nbsp;ricerca&nbsp;TrovaCognome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.TrovaCognome(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica,&nbsp;<span class="visualBasic__keyword">Me</span>.txtRicerca.Text)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Nel&nbsp;caso&nbsp;di&nbsp;eccezzione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Visualizzo&nbsp;un&nbsp;messaggio&nbsp;all'utente&nbsp;con&nbsp;l'eccezzione&nbsp;sollevata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Forms.MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;tiporicerca&nbsp;ha&nbsp;come&nbsp;valore&nbsp;TELEFONO</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;TELEFONO&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Esegue&nbsp;la&nbsp;query&nbsp;di&nbsp;ricerca&nbsp;TrovaTelefono</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.TabellaRubricaTableAdapter.TrovaTelefono(<span class="visualBasic__keyword">Me</span>.RubricaDataSet.TabellaRubrica,&nbsp;<span class="visualBasic__keyword">Me</span>.txtRicerca.Text)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Nel&nbsp;caso&nbsp;di&nbsp;eccezzione</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Visualizzo&nbsp;un&nbsp;messaggio&nbsp;all'utente&nbsp;con&nbsp;l'eccezzione&nbsp;sollevata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Forms.MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Classe GestioneRubrica
Public Class GestioneRubrica

    ' Istanzio un nuovo oggetto di tipo InserisciDatiRubrica
    Dim RubricaDAO As New RubricaDAO

    ' Metodo inserisciDatiRubrica
    ' Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
    ' Successivamente inseriti all'interno del Database Rubrica
    Public Sub inserisciDatiRubrica(ByVal nome As String, ByVal cognome As String, ByVal telefono As String, ByVal posizionerubrica As String)
        ' Richiamo il metodo InserisciDatiRubrica della classe RubricaDAO
        ' Anche questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        ' Successivamente inseriti all'interno del Database Rubrica
        RubricaDAO.InserisciDatiRubrica(nome, cognome, telefono, posizionerubrica)
    End Sub

    ' Metodo rimuoviDatiRubrica
    ' Questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
    ' Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
    Public Sub rimuoviDatiRubrica(ByVal posizionerubrica As String)
        ' Richiamo il metodo EliminaDatiRubrica della classe RubricaDAO
        ' Anche questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
        ' Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
        RubricaDAO.EliminaDatiRubrica(posizionerubrica)
    End Sub

    ' Metodo modificaDatiRubrica
    ' Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
    ' Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
    Public Sub modificaDatiRubrica(ByVal nome As String, ByVal cognome As String, ByVal telefono As String, ByVal posizionerubrica As String)
        ' Metodo ModificaDatiRubrica
        ' Anche questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        ' Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
        RubricaDAO.ModificaDatiRubrica(nome, cognome, telefono, posizionerubrica)
    End Sub
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Classe&nbsp;GestioneRubrica</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;GestioneRubrica&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Istanzio&nbsp;un&nbsp;nuovo&nbsp;oggetto&nbsp;di&nbsp;tipo&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;RubricaDAO&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;RubricaDAO&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;inserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questo&nbsp;metodo&nbsp;aspetta&nbsp;quattro&nbsp;parametri&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,&nbsp;il&nbsp;nome&nbsp;,&nbsp;il&nbsp;cogmome,&nbsp;il&nbsp;telefono&nbsp;e&nbsp;la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;saranno&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;inseriti&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;inserisciDatiRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;nome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cognome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;telefono&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;il&nbsp;metodo&nbsp;InserisciDatiRubrica&nbsp;della&nbsp;classe&nbsp;RubricaDAO</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Anche&nbsp;questo&nbsp;metodo&nbsp;aspetta&nbsp;quattro&nbsp;parametri&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,&nbsp;il&nbsp;nome&nbsp;,&nbsp;il&nbsp;cogmome,&nbsp;il&nbsp;telefono&nbsp;e&nbsp;la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;saranno&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;inseriti&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RubricaDAO.InserisciDatiRubrica(nome,&nbsp;cognome,&nbsp;telefono,&nbsp;posizionerubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;rimuoviDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questo&nbsp;metodo&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;sara&nbsp;utilizzato&nbsp;per&nbsp;verificare&nbsp;,&nbsp;individuare&nbsp;e&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancellare&nbsp;dalla&nbsp;bancadati&nbsp;il&nbsp;nome&nbsp;,&nbsp;cognome&nbsp;,&nbsp;telefono&nbsp;avente&nbsp;quella&nbsp;posizione&nbsp;di&nbsp;rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;rimuoviDatiRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Richiamo&nbsp;il&nbsp;metodo&nbsp;EliminaDatiRubrica&nbsp;della&nbsp;classe&nbsp;RubricaDAO</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Anche&nbsp;questo&nbsp;metodo&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;sara&nbsp;utilizzato&nbsp;per&nbsp;verificare&nbsp;,&nbsp;individuare&nbsp;e&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancellare&nbsp;dalla&nbsp;bancadati&nbsp;il&nbsp;nome&nbsp;,&nbsp;cognome&nbsp;,&nbsp;telefono&nbsp;avente&nbsp;quella&nbsp;posizione&nbsp;di&nbsp;rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RubricaDAO.EliminaDatiRubrica(posizionerubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;modificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questo&nbsp;metodo&nbsp;aspetta&nbsp;quattro&nbsp;parametri&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,&nbsp;il&nbsp;nome&nbsp;,&nbsp;il&nbsp;cogmome,&nbsp;il&nbsp;telefono&nbsp;e&nbsp;la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;saranno&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;inseriti&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;per&nbsp;apportare&nbsp;modifiche&nbsp;ad&nbsp;uno&nbsp;o&nbsp;piu'&nbsp;campi&nbsp;del&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;modificaDatiRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;nome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cognome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;telefono&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Anche&nbsp;questo&nbsp;metodo&nbsp;aspetta&nbsp;quattro&nbsp;parametri&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,&nbsp;il&nbsp;nome&nbsp;,&nbsp;il&nbsp;cogmome,&nbsp;il&nbsp;telefono&nbsp;e&nbsp;la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;saranno&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;inseriti&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;per&nbsp;apportare&nbsp;modifiche&nbsp;ad&nbsp;uno&nbsp;o&nbsp;piu'&nbsp;campi&nbsp;del&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RubricaDAO.ModificaDatiRubrica(nome,&nbsp;cognome,&nbsp;telefono,&nbsp;posizionerubrica)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Classe InserisciDatiRubrica
Public Class InserisciDatiRubrica

    ' Dichiaro quattro variabili di tipo string ed assegno il valore String.Empty
    Dim nome As String = String.Empty
    Dim cognome As String = String.Empty
    Dim telefono As String = String.Empty
    Dim posizioneRubrica As String = String.Empty

    ' Questa funzione quando richiamata restituisce il valore della variabile nome
    ' Valorizzata tramite l'altro metodo ovvero setNome , il metodo sar&agrave; poi richiamato
    ' Al momento di inserire il nome al campo NOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNome() As String
        ' Restituisco il valore di nome al chiamante
        Return Me.nome
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro nome,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia inserire il nome nel campo NOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile nome pu&ograve; essere recuperata tramite la funzione getNome()
    Public Sub setNome(ByVal nome As String)
        ' Valorizzo la variabile nomeModificato 
        Me.nome = nome
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile cognome
    ' Valorizzata tramite l'altro metodo ovvero setCognome , il metodo sar&agrave; poi richiamato
    ' Al momento di inserire il cognome al campo COGNOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getCognonme() As String
        ' Restituisco il valore di cognome al chiamante
        Return Me.cognome
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro cognome,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia inserire il cogmome nel campo COGNOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile cognome pu&ograve; essere recuperata tramite la funzione getCogNome()
    Public Sub setCognome(ByVal cognome As String)
        ' Valorizzo la variabile nomeModificato 
        Me.cognome = cognome
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile telefono
    ' Valorizzata tramite l'altro metodo ovvero setNumeroTelefono , il metodo sar&agrave; poi richiamato
    ' Al momento di inserire il numero di telefono al campo TELEFONO del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNumeroTelefono() As String
        ' Restituisco il valore di telefono al chiamante
        Return Me.telefono
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro telefono,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia inserire il numero di telefono nel campo TELEFONO all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile telefono pu&ograve; essere recuperata tramite la funzione getNumeroTelefono()
    Public Sub setNumeroTelefono(ByVal telefono As String)
        ' Valorizzo la variabile telefonoModificato 
        Me.telefono = telefono
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile posizioneRubrica
    ' Valorizzata tramite l'altro metodo ovvero setPosizioneRubrica , il metodo sar&agrave; poi richiamato
    ' Al momento di inserire il numero di posizione rubrica al campo POSIZIONE_RUBRICA del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getPosizioneRubrica() As String
        ' Restituisco il valore di posizioneRubrica al chiamante
        Return Me.posizioneRubrica
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro posizionerubrica,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia inserire il numero di posizone rubrica nel campo POSIZONE_RUBRICA all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile posizioneRubrica pu&ograve; essere recuperata tramite la funzione getPosizioneRubrica()
    Public Sub setPosizioneRubrica(ByVal posizionerubrica As String)
        ' Valorizzo la variabile posizionerubrica 
        Me.posizioneRubrica = posizionerubrica
    End Sub
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Classe&nbsp;InserisciDatiRubrica</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;InserisciDatiRubrica&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Dichiaro&nbsp;quattro&nbsp;variabili&nbsp;di&nbsp;tipo&nbsp;string&nbsp;ed&nbsp;assegno&nbsp;il&nbsp;valore&nbsp;String.Empty</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cognome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;telefono&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;posizioneRubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;nome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setNome&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;inserire&nbsp;il&nbsp;nome&nbsp;al&nbsp;campo&nbsp;NOME&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getNome()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;nome&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.nome&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;nome,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;inserire&nbsp;il&nbsp;nome&nbsp;nel&nbsp;campo&nbsp;NOME&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;nome&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getNome()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setNome(<span class="visualBasic__keyword">ByVal</span>&nbsp;nome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;nomeModificato&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.nome&nbsp;=&nbsp;nome&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;cognome</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setCognome&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;inserire&nbsp;il&nbsp;cognome&nbsp;al&nbsp;campo&nbsp;COGNOME&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getCognonme()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;cognome&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.cognome&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;cognome,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;inserire&nbsp;il&nbsp;cogmome&nbsp;nel&nbsp;campo&nbsp;COGNOME&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;cognome&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getCogNome()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setCognome(<span class="visualBasic__keyword">ByVal</span>&nbsp;cognome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;nomeModificato&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.cognome&nbsp;=&nbsp;cognome&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;telefono</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setNumeroTelefono&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;inserire&nbsp;il&nbsp;numero&nbsp;di&nbsp;telefono&nbsp;al&nbsp;campo&nbsp;TELEFONO&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getNumeroTelefono()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;telefono&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.telefono&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;telefono,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;inserire&nbsp;il&nbsp;numero&nbsp;di&nbsp;telefono&nbsp;nel&nbsp;campo&nbsp;TELEFONO&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;telefono&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getNumeroTelefono()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setNumeroTelefono(<span class="visualBasic__keyword">ByVal</span>&nbsp;telefono&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;telefonoModificato&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.telefono&nbsp;=&nbsp;telefono&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;posizioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setPosizioneRubrica&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;inserire&nbsp;il&nbsp;numero&nbsp;di&nbsp;posizione&nbsp;rubrica&nbsp;al&nbsp;campo&nbsp;POSIZIONE_RUBRICA&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getPosizioneRubrica()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;posizioneRubrica&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.posizioneRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;posizionerubrica,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;inserire&nbsp;il&nbsp;numero&nbsp;di&nbsp;posizone&nbsp;rubrica&nbsp;nel&nbsp;campo&nbsp;POSIZONE_RUBRICA&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;posizioneRubrica&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getPosizioneRubrica()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setPosizioneRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;posizionerubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.posizioneRubrica&nbsp;=&nbsp;posizionerubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Classe ModificaDatiRubrica
Public Class ModificaDatiRubrica

    ' Dichiaro quattro variabili di tipo string ed assegno il valore String.Empty
    Dim nomeModificato As String = String.Empty
    Dim cognomeModificato As String = String.Empty
    Dim telefonoModificato As String = String.Empty
    Dim posizioneRubrica As String = String.Empty

    ' Questa funzione quando richiamata restituisce il valore della variabile nomeModificato
    ' Valorizzata tramite l'altro metodo ovvero setNomeModificato , il metodo sar&agrave; poi richiamato
    ' Al momento di riassegnare il nome eventualmente modificato al campo NOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNomeModificato() As String
        ' Restituisco il valore di nomeModificato al chiamante
        Return Me.nomeModificato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro nomemodificato,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia modificare il campo NOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile nomeModificato pu&ograve; essere recuperata tramite la funzione getNomeModificato()
    Public Sub setNomeModificato(ByVal nomemodificato As String)
        ' Valorizzo la variabile nomeModificato 
        Me.nomeModificato = nomemodificato
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile cognomeModificato
    ' Valorizzata tramite l'altro metodo ovvero setCognomeModificato , il metodo sar&agrave; poi richiamato
    ' Al momento di riassegnare il cognome eventualmente modificato al campo COGNOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getCognonmeModoficato() As String
        ' Restituisco il valore di cognomeModificato al chiamante
        Return Me.cognomeModificato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro cognomemodificato,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia modificare il campo COGNOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile cognomeModificato pu&ograve; essere recuperata tramite la funzione getCogNomeModificato()
    Public Sub setCognomeModificato(ByVal cognomemodificato As String)
        ' Valorizzo la variabile nomeModificato 
        Me.cognomeModificato = cognomemodificato
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile telefonoModificato
    ' Valorizzata tramite l'altro metodo ovvero setNumeroTelefono , il metodo sar&agrave; poi richiamato
    ' Al momento di riassegnare il telefono eventualmente modificato al campo TELEFONO del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNumeroTelefonoModificato() As String
        ' Restituisco il valore di telefonoModificato al chiamante
        Return Me.telefonoModificato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro telefonodificato,il metodo sar&agrave; poi richiamato
    ' nel caso l'utente voglia modificare il campo TELEFONO all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile telefonoModificato pu&ograve; essere recuperata tramite la funzione getNumeroTelefonoModificato()
    Public Sub setNumeroTelefono(ByVal telefonomodificato As String)
        ' Valorizzo la variabile telefonoModificato 
        Me.telefonoModificato = telefonomodificato
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile posizioneRubrica
    ' Valorizzata tramite l'altro metodo ovvero setPosizioneRubrica , il metodo sar&agrave; poi richiamato
    ' Solamente per identificare tramite la clausola WHERE della query sql di modifica , in modo da
    ' Modificare i dati appartenenti a tale posizione rubrica
    Public Function getPosizioneRubrica() As String
        ' Restituisco il valore di posizioneRubrica al chiamante
        Return Me.posizioneRubrica
    End Function

    ' Questa Sub quando richiamata restituisce il valore della variabile posizionerubrica
    ' Valorizzata tramite l'altro metodo ovvero getPosizioneRubrica , il metodo sar&agrave; poi richiamato
    ' Solamente per memorizzare e restituire tramite la funzione getPosizioneRubrica il numero di posizione rubrica che sara poi 
    ' Confrontato tramite la clausola WHERE della query sql di modifica , in modo da
    ' Modificare i dati apparteneti a tale posizione rubrica
    Public Sub setPosizioneRubrica(ByVal posizionerubrica As String)
        ' Valorizzo la variabile posizionerubrica 
        Me.posizioneRubrica = posizionerubrica
    End Sub
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Classe&nbsp;ModificaDatiRubrica</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;ModificaDatiRubrica&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Dichiaro&nbsp;quattro&nbsp;variabili&nbsp;di&nbsp;tipo&nbsp;string&nbsp;ed&nbsp;assegno&nbsp;il&nbsp;valore&nbsp;String.Empty</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nomeModificato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cognomeModificato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;telefonoModificato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;posizioneRubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;nomeModificato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setNomeModificato&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;riassegnare&nbsp;il&nbsp;nome&nbsp;eventualmente&nbsp;modificato&nbsp;al&nbsp;campo&nbsp;NOME&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getNomeModificato()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;nomeModificato&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.nomeModificato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;nomemodificato,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;modificare&nbsp;il&nbsp;campo&nbsp;NOME&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;nomeModificato&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getNomeModificato()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setNomeModificato(<span class="visualBasic__keyword">ByVal</span>&nbsp;nomemodificato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;nomeModificato&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.nomeModificato&nbsp;=&nbsp;nomemodificato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;cognomeModificato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setCognomeModificato&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;riassegnare&nbsp;il&nbsp;cognome&nbsp;eventualmente&nbsp;modificato&nbsp;al&nbsp;campo&nbsp;COGNOME&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getCognonmeModoficato()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;cognomeModificato&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.cognomeModificato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;cognomemodificato,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;modificare&nbsp;il&nbsp;campo&nbsp;COGNOME&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;cognomeModificato&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getCogNomeModificato()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setCognomeModificato(<span class="visualBasic__keyword">ByVal</span>&nbsp;cognomemodificato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;nomeModificato&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.cognomeModificato&nbsp;=&nbsp;cognomemodificato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;telefonoModificato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setNumeroTelefono&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Al&nbsp;momento&nbsp;di&nbsp;riassegnare&nbsp;il&nbsp;telefono&nbsp;eventualmente&nbsp;modificato&nbsp;al&nbsp;campo&nbsp;TELEFONO&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sul&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getNumeroTelefonoModificato()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;telefonoModificato&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.telefonoModificato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;si&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;tipo&nbsp;string&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;il&nbsp;parametro&nbsp;telefonodificato,il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;nel&nbsp;caso&nbsp;l'utente&nbsp;voglia&nbsp;modificare&nbsp;il&nbsp;campo&nbsp;TELEFONO&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;della&nbsp;riga&nbsp;selezionata&nbsp;sul&nbsp;datagridview&nbsp;e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;la&nbsp;variabile&nbsp;telefonoModificato&nbsp;pu&ograve;&nbsp;essere&nbsp;recuperata&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getNumeroTelefonoModificato()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setNumeroTelefono(<span class="visualBasic__keyword">ByVal</span>&nbsp;telefonomodificato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;telefonoModificato&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.telefonoModificato&nbsp;=&nbsp;telefonomodificato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;funzione&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;posizioneRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;setPosizioneRubrica&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Solamente&nbsp;per&nbsp;identificare&nbsp;tramite&nbsp;la&nbsp;clausola&nbsp;WHERE&nbsp;della&nbsp;query&nbsp;sql&nbsp;di&nbsp;modifica&nbsp;,&nbsp;in&nbsp;modo&nbsp;da</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Modificare&nbsp;i&nbsp;dati&nbsp;appartenenti&nbsp;a&nbsp;tale&nbsp;posizione&nbsp;rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;getPosizioneRubrica()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Restituisco&nbsp;il&nbsp;valore&nbsp;di&nbsp;posizioneRubrica&nbsp;al&nbsp;chiamante</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.posizioneRubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;Sub&nbsp;quando&nbsp;richiamata&nbsp;restituisce&nbsp;il&nbsp;valore&nbsp;della&nbsp;variabile&nbsp;posizionerubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzata&nbsp;tramite&nbsp;l'altro&nbsp;metodo&nbsp;ovvero&nbsp;getPosizioneRubrica&nbsp;,&nbsp;il&nbsp;metodo&nbsp;sar&agrave;&nbsp;poi&nbsp;richiamato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Solamente&nbsp;per&nbsp;memorizzare&nbsp;e&nbsp;restituire&nbsp;tramite&nbsp;la&nbsp;funzione&nbsp;getPosizioneRubrica&nbsp;il&nbsp;numero&nbsp;di&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;sara&nbsp;poi&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Confrontato&nbsp;tramite&nbsp;la&nbsp;clausola&nbsp;WHERE&nbsp;della&nbsp;query&nbsp;sql&nbsp;di&nbsp;modifica&nbsp;,&nbsp;in&nbsp;modo&nbsp;da</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Modificare&nbsp;i&nbsp;dati&nbsp;apparteneti&nbsp;a&nbsp;tale&nbsp;posizione&nbsp;rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setPosizioneRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Valorizzo&nbsp;la&nbsp;variabile&nbsp;posizionerubrica&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.posizioneRubrica&nbsp;=&nbsp;posizionerubrica&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Importazione dei componenti del .netframework
Imports System.Data.OleDb

' Classe RubricaDAO
Public Class RubricaDAO

    Private Const Connessione As String = &quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=%1;Persist Security Info=False&quot;
    ''' &lt;summary&gt;
    ''' Genera la stringa di connessione per access 2007
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;NomeDataBase&quot;&gt;Nome del database completo di path&lt;/param&gt;
    ''' &lt;param name=&quot;Password&quot;&gt;Password del database, eventualmente passare String.Empty&lt;/param&gt;
    ''' &lt;returns&gt;La stringa gi&agrave; formattata&lt;/returns&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;

    Private Function GeneraStringaConnessioneAccess2007(ByVal NomeDataBase As String, ByVal Password As String) As String
        Dim OutValue As String = Connessione.Replace(&quot;%1&quot;, NomeDataBase)
        If Password &lt;&gt; &quot;&quot; Then
            OutValue = OutValue &amp; &quot;Jet OLEDB:Database Password=&quot; &amp; Password
        End If
        Return OutValue
    End Function

    ' Metodo InserisciDatiRubrica
    ' Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
    ' Successivamente inseriti all'interno del Database Rubrica
    Public Sub InserisciDatiRubrica(ByVal nome As String, ByVal cognome As String, ByVal telefono As String, ByVal posizionerubrica As String)

        ' Questa classe rappresenta una connessione aperta ad un origine Dati,e riceve come parametro la funzione GeneraStringaConnessioneAccess2007
        ' Sopraindicata, per comodit&agrave; ho utilizzato un percorso fisso per l'accesso al file di Database e passato come Password una stringa vuota.
        Dim connection As New OleDbConnection(GeneraStringaConnessioneAccess2007(&quot;D:\Rubrica.accdb&quot;, String.Empty))
        ' Tramite la classe OleDbCommand e possibile eseguire un istruzione sql o una stored procedure in relazione ad un origine dati
        ' In questo caso viene eseguita la query sql insert into che recupera i parametri passati dal metodo InserisciDatiRubrica ed aggiunge
        ' Un nuovo record al Database Rubrica
        Dim cmd As New OleDbCommand(&quot;INSERT INTO TabellaRubrica (NOME, COGNOME,TELEFONO,POSIZIONE_RUBRICA) VALUES (?,?,?,?)&quot;, connection)
        ' Tramite la classe OleDbParameter e possibile ottenere un oggetto ed eventualmente il relativo mapping di una colonna
        ' Vengono qui valorizzati i campi nome,cognome,telefono e posizione_rubrica e successivamente inseriti nel Database Rubrica
        cmd.Parameters.Add(New OleDbParameter(&quot;@NOME&quot;, OleDbType.WChar)).Value = nome.ToUpper
        cmd.Parameters.Add(New OleDbParameter(&quot;@COGNOME&quot;, OleDbType.WChar)).Value = cognome.ToUpper
        cmd.Parameters.Add(New OleDbParameter(&quot;@TELEFONO&quot;, OleDbType.WChar)).Value = telefono.ToUpper
        cmd.Parameters.Add(New OleDbParameter(&quot;@POSIZIONE_RUBRICA&quot;, OleDbType.WChar)).Value = posizionerubrica.ToUpper
        ' Apro la connessione al Database Rubrica
        connection.Open()
        ' Eseguo l'istruzione sql 
        cmd.ExecuteNonQuery()
        ' Chiudo la connessione con il Database Rubrica
        connection.Close()

    End Sub

    ' Metodo EliminaDatiRubrica
    ' Questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
    ' Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
    Public Sub EliminaDatiRubrica(ByVal posizionerubricaeliminato As String)
        ' Questa classe rappresenta una connessione aperta ad un origine Dati,e riceve come parametro la funzione GeneraStringaConnessioneAccess2007
        ' Sopraindicata, per comodit&agrave; ho utilizzato un percorso fisso per l'accesso al file di Database e passato come Password una stringa vuota.
        Dim connection As New OleDbConnection(GeneraStringaConnessioneAccess2007(&quot;D:\Rubrica.accdb&quot;, String.Empty))
        ' Tramite la classe OleDbCommand e possibile eseguire un istruzione sql o una stored procedure in relazione ad un origine dati
        ' In questo caso viene eseguita la query sql delete che recupera il parametro passato dal metodo EliminaDatiRubrica e procede
        ' alla cancellazione dei dati del record dal Database Rubrica
        Dim cmd As New OleDbCommand(&quot;DELETE FROM TabellaRubrica WHERE POSIZIONE_RUBRICA = '&quot; &#43; posizionerubricaeliminato &#43; &quot;'&quot;, connection)
        ' Apro la connessione al Database Rubrica
        connection.Open()
        ' Eseguo l'istruzione sql 
        cmd.ExecuteNonQuery()
        ' Chiudo la connessione con il Database Rubrica
        connection.Close()

    End Sub

    ' Metodo ModificaDatiRubrica
    ' Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
    ' Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
    Public Sub ModificaDatiRubrica(ByVal nome As String, ByVal cognome As String, ByVal telefono As String, ByVal posizionerubrica As String)
        ' Questa classe rappresenta una connessione aperta ad un origine Dati,e riceve come parametro la funzione GeneraStringaConnessioneAccess2007
        ' Sopraindicata, per comodit&agrave; ho utilizzato un percorso fisso per l'accesso al file di Database e passato come Password una stringa vuota.
        Dim connection As New OleDbConnection(GeneraStringaConnessioneAccess2007(&quot;D:\Rubrica.accdb&quot;, String.Empty))
        ' Tramite la classe OleDbCommand e possibile eseguire un istruzione sql o una stored procedure in relazione ad un origine dati
        ' In questo caso viene eseguita la query sql update che recupera i parametri passati dal metodo ModificaDatiRubrica e procede
        ' con la modifica dei dati sul record al Database Rubrica selezionato
        Dim cmd As New OleDbCommand(&quot;UPDATE TabellaRubrica SET NOME = '&quot; &#43; nome &#43; &quot;' ,COGNOME = '&quot; &#43; cognome &#43; &quot;' ,TELEFONO = '&quot; &#43; telefono &#43; &quot;' WHERE POSIZIONE_RUBRICA = '&quot; &#43; posizionerubrica &#43; &quot;'&quot;, connection)
        ' Apro la connessione al Database Rubrica
        connection.Open()
        ' Eseguo l'istruzione sql 
        cmd.ExecuteNonQuery()
        ' Chiudo la connessione con il Database Rubrica
        connection.Close()

    End Sub

End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Importazione&nbsp;dei&nbsp;componenti&nbsp;del&nbsp;.netframework</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Data.OleDb&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;Classe&nbsp;RubricaDAO</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;RubricaDAO&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;Connessione&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Provider=Microsoft.ACE.OLEDB.12.0;Data&nbsp;Source=%1;Persist&nbsp;Security&nbsp;Info=False&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Genera&nbsp;la&nbsp;stringa&nbsp;di&nbsp;connessione&nbsp;per&nbsp;access&nbsp;2007</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;NomeDataBase&quot;&gt;Nome&nbsp;del&nbsp;database&nbsp;completo&nbsp;di&nbsp;path&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;Password&quot;&gt;Password&nbsp;del&nbsp;database,&nbsp;eventualmente&nbsp;passare&nbsp;String.Empty&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;La&nbsp;stringa&nbsp;gi&agrave;&nbsp;formattata&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GeneraStringaConnessioneAccess2007(<span class="visualBasic__keyword">ByVal</span>&nbsp;NomeDataBase&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;Password&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;OutValue&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;Connessione.Replace(<span class="visualBasic__string">&quot;%1&quot;</span>,&nbsp;NomeDataBase)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Password&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OutValue&nbsp;=&nbsp;OutValue&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;Jet&nbsp;OLEDB:Database&nbsp;Password=&quot;</span>&nbsp;&amp;&nbsp;Password&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;OutValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;InserisciDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questo&nbsp;metodo&nbsp;aspetta&nbsp;quattro&nbsp;parametri&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,&nbsp;il&nbsp;nome&nbsp;,&nbsp;il&nbsp;cogmome,&nbsp;il&nbsp;telefono&nbsp;e&nbsp;la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;saranno&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;inseriti&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;InserisciDatiRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;nome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cognome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;telefono&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;classe&nbsp;rappresenta&nbsp;una&nbsp;connessione&nbsp;aperta&nbsp;ad&nbsp;un&nbsp;origine&nbsp;Dati,e&nbsp;riceve&nbsp;come&nbsp;parametro&nbsp;la&nbsp;funzione&nbsp;GeneraStringaConnessioneAccess2007</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sopraindicata,&nbsp;per&nbsp;comodit&agrave;&nbsp;ho&nbsp;utilizzato&nbsp;un&nbsp;percorso&nbsp;fisso&nbsp;per&nbsp;l'accesso&nbsp;al&nbsp;file&nbsp;di&nbsp;Database&nbsp;e&nbsp;passato&nbsp;come&nbsp;Password&nbsp;una&nbsp;stringa&nbsp;vuota.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;connection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection(GeneraStringaConnessioneAccess2007(<span class="visualBasic__string">&quot;D:\Rubrica.accdb&quot;</span>,&nbsp;<span class="visualBasic__keyword">String</span>.Empty))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Tramite&nbsp;la&nbsp;classe&nbsp;OleDbCommand&nbsp;e&nbsp;possibile&nbsp;eseguire&nbsp;un&nbsp;istruzione&nbsp;sql&nbsp;o&nbsp;una&nbsp;stored&nbsp;procedure&nbsp;in&nbsp;relazione&nbsp;ad&nbsp;un&nbsp;origine&nbsp;dati</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;In&nbsp;questo&nbsp;caso&nbsp;viene&nbsp;eseguita&nbsp;la&nbsp;query&nbsp;sql&nbsp;insert&nbsp;into&nbsp;che&nbsp;recupera&nbsp;i&nbsp;parametri&nbsp;passati&nbsp;dal&nbsp;metodo&nbsp;InserisciDatiRubrica&nbsp;ed&nbsp;aggiunge</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Un&nbsp;nuovo&nbsp;record&nbsp;al&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand(<span class="visualBasic__string">&quot;INSERT&nbsp;INTO&nbsp;TabellaRubrica&nbsp;(NOME,&nbsp;COGNOME,TELEFONO,POSIZIONE_RUBRICA)&nbsp;VALUES&nbsp;(?,?,?,?)&quot;</span>,&nbsp;connection)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Tramite&nbsp;la&nbsp;classe&nbsp;OleDbParameter&nbsp;e&nbsp;possibile&nbsp;ottenere&nbsp;un&nbsp;oggetto&nbsp;ed&nbsp;eventualmente&nbsp;il&nbsp;relativo&nbsp;mapping&nbsp;di&nbsp;una&nbsp;colonna</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Vengono&nbsp;qui&nbsp;valorizzati&nbsp;i&nbsp;campi&nbsp;nome,cognome,telefono&nbsp;e&nbsp;posizione_rubrica&nbsp;e&nbsp;successivamente&nbsp;inseriti&nbsp;nel&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.Add(<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter(<span class="visualBasic__string">&quot;@NOME&quot;</span>,&nbsp;OleDbType.WChar)).Value&nbsp;=&nbsp;nome.ToUpper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.Add(<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter(<span class="visualBasic__string">&quot;@COGNOME&quot;</span>,&nbsp;OleDbType.WChar)).Value&nbsp;=&nbsp;cognome.ToUpper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.Add(<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter(<span class="visualBasic__string">&quot;@TELEFONO&quot;</span>,&nbsp;OleDbType.WChar)).Value&nbsp;=&nbsp;telefono.ToUpper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.Add(<span class="visualBasic__keyword">New</span>&nbsp;OleDbParameter(<span class="visualBasic__string">&quot;@POSIZIONE_RUBRICA&quot;</span>,&nbsp;OleDbType.WChar)).Value&nbsp;=&nbsp;posizionerubrica.ToUpper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Apro&nbsp;la&nbsp;connessione&nbsp;al&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Eseguo&nbsp;l'istruzione&nbsp;sql&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Chiudo&nbsp;la&nbsp;connessione&nbsp;con&nbsp;il&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Close()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;EliminaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questo&nbsp;metodo&nbsp;aspetta&nbsp;un&nbsp;parametro&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;sara&nbsp;utilizzato&nbsp;per&nbsp;verificare&nbsp;,&nbsp;individuare&nbsp;e&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cancellare&nbsp;dalla&nbsp;bancadati&nbsp;il&nbsp;nome&nbsp;,&nbsp;cognome&nbsp;,&nbsp;telefono&nbsp;avente&nbsp;quella&nbsp;posizione&nbsp;di&nbsp;rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;EliminaDatiRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubricaeliminato&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;classe&nbsp;rappresenta&nbsp;una&nbsp;connessione&nbsp;aperta&nbsp;ad&nbsp;un&nbsp;origine&nbsp;Dati,e&nbsp;riceve&nbsp;come&nbsp;parametro&nbsp;la&nbsp;funzione&nbsp;GeneraStringaConnessioneAccess2007</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sopraindicata,&nbsp;per&nbsp;comodit&agrave;&nbsp;ho&nbsp;utilizzato&nbsp;un&nbsp;percorso&nbsp;fisso&nbsp;per&nbsp;l'accesso&nbsp;al&nbsp;file&nbsp;di&nbsp;Database&nbsp;e&nbsp;passato&nbsp;come&nbsp;Password&nbsp;una&nbsp;stringa&nbsp;vuota.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;connection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection(GeneraStringaConnessioneAccess2007(<span class="visualBasic__string">&quot;D:\Rubrica.accdb&quot;</span>,&nbsp;<span class="visualBasic__keyword">String</span>.Empty))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Tramite&nbsp;la&nbsp;classe&nbsp;OleDbCommand&nbsp;e&nbsp;possibile&nbsp;eseguire&nbsp;un&nbsp;istruzione&nbsp;sql&nbsp;o&nbsp;una&nbsp;stored&nbsp;procedure&nbsp;in&nbsp;relazione&nbsp;ad&nbsp;un&nbsp;origine&nbsp;dati</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;In&nbsp;questo&nbsp;caso&nbsp;viene&nbsp;eseguita&nbsp;la&nbsp;query&nbsp;sql&nbsp;delete&nbsp;che&nbsp;recupera&nbsp;il&nbsp;parametro&nbsp;passato&nbsp;dal&nbsp;metodo&nbsp;EliminaDatiRubrica&nbsp;e&nbsp;procede</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;alla&nbsp;cancellazione&nbsp;dei&nbsp;dati&nbsp;del&nbsp;record&nbsp;dal&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand(<span class="visualBasic__string">&quot;DELETE&nbsp;FROM&nbsp;TabellaRubrica&nbsp;WHERE&nbsp;POSIZIONE_RUBRICA&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;posizionerubricaeliminato&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;'&quot;</span>,&nbsp;connection)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Apro&nbsp;la&nbsp;connessione&nbsp;al&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Eseguo&nbsp;l'istruzione&nbsp;sql&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Chiudo&nbsp;la&nbsp;connessione&nbsp;con&nbsp;il&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Close()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Metodo&nbsp;ModificaDatiRubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questo&nbsp;metodo&nbsp;aspetta&nbsp;quattro&nbsp;parametri&nbsp;di&nbsp;tipo&nbsp;string&nbsp;,&nbsp;il&nbsp;nome&nbsp;,&nbsp;il&nbsp;cogmome,&nbsp;il&nbsp;telefono&nbsp;e&nbsp;la&nbsp;posizione&nbsp;rubrica&nbsp;che&nbsp;saranno&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Successivamente&nbsp;inseriti&nbsp;all'interno&nbsp;del&nbsp;Database&nbsp;Rubrica&nbsp;per&nbsp;apportare&nbsp;modifiche&nbsp;ad&nbsp;uno&nbsp;o&nbsp;piu'&nbsp;campi&nbsp;del&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ModificaDatiRubrica(<span class="visualBasic__keyword">ByVal</span>&nbsp;nome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cognome&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;telefono&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;posizionerubrica&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Questa&nbsp;classe&nbsp;rappresenta&nbsp;una&nbsp;connessione&nbsp;aperta&nbsp;ad&nbsp;un&nbsp;origine&nbsp;Dati,e&nbsp;riceve&nbsp;come&nbsp;parametro&nbsp;la&nbsp;funzione&nbsp;GeneraStringaConnessioneAccess2007</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Sopraindicata,&nbsp;per&nbsp;comodit&agrave;&nbsp;ho&nbsp;utilizzato&nbsp;un&nbsp;percorso&nbsp;fisso&nbsp;per&nbsp;l'accesso&nbsp;al&nbsp;file&nbsp;di&nbsp;Database&nbsp;e&nbsp;passato&nbsp;come&nbsp;Password&nbsp;una&nbsp;stringa&nbsp;vuota.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;connection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection(GeneraStringaConnessioneAccess2007(<span class="visualBasic__string">&quot;D:\Rubrica.accdb&quot;</span>,&nbsp;<span class="visualBasic__keyword">String</span>.Empty))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Tramite&nbsp;la&nbsp;classe&nbsp;OleDbCommand&nbsp;e&nbsp;possibile&nbsp;eseguire&nbsp;un&nbsp;istruzione&nbsp;sql&nbsp;o&nbsp;una&nbsp;stored&nbsp;procedure&nbsp;in&nbsp;relazione&nbsp;ad&nbsp;un&nbsp;origine&nbsp;dati</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;In&nbsp;questo&nbsp;caso&nbsp;viene&nbsp;eseguita&nbsp;la&nbsp;query&nbsp;sql&nbsp;update&nbsp;che&nbsp;recupera&nbsp;i&nbsp;parametri&nbsp;passati&nbsp;dal&nbsp;metodo&nbsp;ModificaDatiRubrica&nbsp;e&nbsp;procede</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;con&nbsp;la&nbsp;modifica&nbsp;dei&nbsp;dati&nbsp;sul&nbsp;record&nbsp;al&nbsp;Database&nbsp;Rubrica&nbsp;selezionato</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand(<span class="visualBasic__string">&quot;UPDATE&nbsp;TabellaRubrica&nbsp;SET&nbsp;NOME&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;nome&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;'&nbsp;,COGNOME&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;cognome&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;'&nbsp;,TELEFONO&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;telefono&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;'&nbsp;WHERE&nbsp;POSIZIONE_RUBRICA&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;posizionerubrica&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;'&quot;</span>,&nbsp;connection)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Apro&nbsp;la&nbsp;connessione&nbsp;al&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Eseguo&nbsp;l'istruzione&nbsp;sql&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Chiudo&nbsp;la&nbsp;connessione&nbsp;con&nbsp;il&nbsp;Database&nbsp;Rubrica</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Close()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p></p>
<h1>More Information</h1>
<div><em>Per maggiori informazioni <a href="http://community.visual-basic.it/carmelolamonica/">
http://community.visual-basic.it/carmelolamonica/</a></em></div>
<p><em></em>&nbsp;</p>
