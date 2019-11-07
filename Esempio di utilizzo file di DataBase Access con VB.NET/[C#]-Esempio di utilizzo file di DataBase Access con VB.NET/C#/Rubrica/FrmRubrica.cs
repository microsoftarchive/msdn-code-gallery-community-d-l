// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe FrmRubrica
    public partial class FrmRubrica : Form
    {
        // Costruttore della classe FrmRubrica
        public FrmRubrica()
        {
            // Metodo InitializeComponent
            InitializeComponent();
        }

        // Evento load del form FrmRubrica
        private void FrmRubrica_Load(System.Object sender, System.EventArgs e)
        {
            // TODO: questa riga di codice carica i dati nella tabella 'rubricaDataSet.TabellaRubrica'. È possibile spostarla o rimuoverla se necessario.
            this.tabellaRubricaTableAdapter.Fill(this.rubricaDataSet.TabellaRubrica);
            // Disabilito pulsante btnElimina
            btnElimina.Enabled = false;
            // Disabilito pulsante btnModifica
            btnModifica.Enabled = false;
        }

        // Evento Click del pulsante btnInserisci
        private void btnInserisci_Click(System.Object sender, System.EventArgs e)
        {
            // Se txtPosizioneRubrica non contiene alcun carattere
            if (this.txtPosizioneRubrica.Text == string.Empty)
            {
                // Avviso l'utente che va inserito un numero di posizione rubrica inerente al nome,cognome e telefono
                MessageBox.Show("Inserisci un numero di posizione rubrica", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Altrimenti
            }
            else
            {
                // Istanzio un nuovo oggetto di tipo InserisciDatiRubrica 
                InserisciDatiRubrica idr = new InserisciDatiRubrica();
                // Richiamo la sub setNome della classe InserisciDatiRubrica
                // passando come parametro il contenuto di txtNome.Text
                idr.setNome(this.txtNome.Text);
                // Richiamo la sub setCognome della classe InserisciDatiRubrica
                // passando come parametro il contenuto di txtCognome.Text
                idr.setCognome(this.txtCognome.Text);
                // Richiamo la sub setNumeroTelefono della classe InserisciDatiRubrica
                // passando come parametro il contenuto di txtTelefono.Text
                idr.setNumeroTelefono(this.txtTelefono.Text);
                // Richiamo la sub setPosizioneRubrica della classe InserisciDatiRubrica
                // passando come parametro il contenuto di txtPosizioneRubrica.Text
                idr.setPosizioneRubrica(this.txtPosizioneRubrica.Text);


                // Istanzio un nuovo oggetto di tipo GestioneRubrica 
                GestioneRubrica gr = new GestioneRubrica();
                // Richiamo il metodo inserisciDatiRubrica() della classe gestioneRubrica
                // ed implemento i parametri del metodo mediante le funzioni get della Classe InserisciDatiRubrica
                // Queste funzioni restituiscono i valori memorizzati in precedenza mediante le sub Set
                gr.inserisciDatiRubrica(idr.getNome(), idr.getCognonme(), idr.getNumeroTelefono(), idr.getPosizioneRubrica());
                // Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
                this.tabellaRubricaTableAdapter.Fill(this.rubricaDataSet.TabellaRubrica);
                // Cancello il contenuto di txtNome
                txtNome.Clear();
                // Cancello il contenuto di txtCognome
                txtCognome.Clear();
                // Cancello il contenuto di txtTelefono
                txtTelefono.Clear();
                // Cancello il contenuto di txtPosizioneRubrica
                txtPosizioneRubrica.Clear();
            }
        }

        // Evento Click del pulsante btnElimina

        private void btnElimina_Click(System.Object sender, System.EventArgs e)
        {
            // Istanzio un nuovo oggetto di tipo EliminaDatiRubrica 
            EliminaDatiRubrica edr = new EliminaDatiRubrica();
            // Richiamo la sub setPosizioneRubricaEliminato della classe EliminaDatiRubrica
            // passando come parametro il contenuto di txtEliminaPosizioneRubrica.Text
            edr.setPosizioneRubricaEliminato(this.txtEliminaPosizioneRubrica.Text);



            // Istanzio un nuovo oggetto di tipo GestioneRubrica 
            GestioneRubrica gr = new GestioneRubrica();
            // Richiamo il metodo rimuoviDatiRubrica() della classe gestioneRubrica
            // ed implemento i parametri del metodo mediante la funziona get della Classe EliminaDatiRubrica
            // Questa funzione restituisce il valore memorizzato in precedenza mediante le sub Set
            gr.rimuoviDatiRubrica(edr.getPosizioneRubricaEliminato());
            // Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
            this.tabellaRubricaTableAdapter.Fill(this.rubricaDataSet.TabellaRubrica);
            // Abilito pulsante btnElimina
            btnElimina.Enabled = true;
            // Cancello il contenuto di txtEliminaNome
            txtEliminaNome.Clear();
            // Cancello il contenuto di txtEliminaCognome
            txtEliminaCognome.Clear();
            // Cancello il contenuto di txtEliminaTelefono
            txtEliminaTelefono.Clear();
            // Cancello il contenuto di txtEliminaPosizioneRubrica
            txtEliminaPosizioneRubrica.Clear();
            // Cancello il contenuto di txtNomeAttuale
            txtNomeAttuale.Clear();
            // Cancello il contenuto di txtCognomeAttuale
            txtCognomeAttuale.Clear();
            // Cancello il contenuto di txtTelefonoAttuale
            txtTelefonoAttuale.Clear();
            // Cancello il contenuto di txtPosizioneRubricaAttuale
            txtPosizioneRubricaAttuale.Clear();
        }

        // Evento Click del pulsante btnModifica

        private void btnModifica_Click(System.Object sender, System.EventArgs e)
        {
            // Istanzio un nuovo oggetto di tipo ModificaDatiRubrica 
            ModificaDatiRubrica mdr = new ModificaDatiRubrica();
            // Richiamo la sub setNomeModificato della classe ModificaDatiRubrica
            // passando come parametro il contenuto di txtNomeAttuale.Text
            mdr.setNomeModificato(this.txtNomeAttuale.Text);
            // Richiamo la sub setCognomeModificato della classe ModificaDatiRubrica
            // passando come parametro il contenuto di txtCognomeAttuale.Text
            mdr.setCognomeModificato(this.txtCognomeAttuale.Text);
            // Richiamo la sub setNumeroTelefono della classe ModificaDatiRubrica
            // passando come parametro il contenuto di txtTelefonoAttuale.Text
            mdr.setNumeroTelefono(this.txtTelefonoAttuale.Text);
            // Richiamo la sub setPosizioneRubrica della classe ModificaDatiRubrica
            // passando come parametro il contenuto di txtPosizioneRubricaAttuale.Text
            mdr.setPosizioneRubrica(this.txtPosizioneRubricaAttuale.Text);


            // Istanzio un nuovo oggetto di tipo GestioneRubrica 
            GestioneRubrica gr = new GestioneRubrica();
            // Richiamo il metodo modificaDatiRubrica della classe gestioneRubrica
            // ed implemento i parametri del metodo mediante le funzioni get della Classe ModificaDatiRubrica
            // Queste funzioni restituiscono i valori memorizzati in precedenza mediante le sub Set
            gr.modificaDatiRubrica(mdr.getNomeModificato(), mdr.getCognonmeModoficato(), mdr.getNumeroTelefonoModificato(), mdr.getPosizioneRubrica());
            // Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
            this.tabellaRubricaTableAdapter.Fill(this.rubricaDataSet.TabellaRubrica);
            // Abilito pulsante btnModifica
            btnModifica.Enabled = true;
            // Cancello il contenuto di txtNomeAttuale
            txtNomeAttuale.Clear();
            // Cancello il contenuto di txtCognomeAttuale
            txtCognomeAttuale.Clear();
            // Cancello il contenuto di txtTelefonoAttuale
            txtTelefonoAttuale.Clear();
            // Cancello il contenuto di txtPosizioneRubricaAttuale
            txtPosizioneRubricaAttuale.Clear();
            // Cancello il contenuto di txtEliminaNome
            txtEliminaNome.Clear();
            // Cancello il contenuto di txtEliminaCognome
            txtEliminaCognome.Clear();
            // Cancello il contenuto di txtEliminaTelefono
            txtEliminaTelefono.Clear();
            // Cancello il contenuto di txtEliminaPosizioneRubrica
            txtEliminaPosizioneRubrica.Clear();
        }



        // Evento Click del pulsante btnAggiorna
        private void btnAggiorna_Click(System.Object sender, System.EventArgs e)
        {
            // Aggiorno la visualizzazione di TabellaRubrica sul DataGridView1
            this.tabellaRubricaTableAdapter.Fill(this.rubricaDataSet.TabellaRubrica);
        }

        // Evento Click del pulsante btnEsciToolStripMenuItem
        private void EsciToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            // Chiudo l'applicazione Rubrica
            Application.Exit();
        }

        // Evento RowHeaderMouseClick di dtgRubrica
        private void dtgRubrica_RowHeaderMouseClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            // Questa parte di codice serve per selezionare i dati da un record e successivamente l'utente
            // può decidere se eliminare o modificare uno o più campi del record , bisogna per fare ciò
            // impostare la proprietà Multiselect del datagridview a false
            // Prova
            try
            {
                // Assegno a txtNomeAttuale il contenuto della cella NOMEDataGridViewTextBoxColumn della riga selezionata
                this.txtNomeAttuale.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["NOME"].Value.ToString();
                // Assegno a txtCognomeAttuale il contenuto della cella COGNOMEDataGridViewTextBoxColumn della riga selezionata
                this.txtCognomeAttuale.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["COGNOME"].Value.ToString();
                // Assegno a txtTelefonoAttuale il contenuto della cella TELEFONODataGridViewTextBoxColumn della riga selezionata
                this.txtTelefonoAttuale.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["TELEFONO"].Value.ToString();
                // Assegno a txtPosizioneRubricaAttuale il contenuto della cella POSIZIONERUBRICADataGridViewTextBoxColumn della riga selezionata
                this.txtPosizioneRubricaAttuale.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["POSIZIONE_RUBRICA"].Value.ToString();
                // Abilito pulsante btnModifica
                btnModifica.Enabled = true;

                // Assegno a txtEliminaNome il contenuto della cella NOMEDataGridViewTextBoxColumn della riga selezionata
                this.txtEliminaNome.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["NOME"].Value.ToString();
                // Assegno a txtEliminaCognome il contenuto della cella COGNOMEDataGridViewTextBoxColumn della riga selezionata
                this.txtEliminaCognome.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["COGNOME"].Value.ToString();
                // Assegno a txtEliminaTelefono il contenuto della cella TELEFONODataGridViewTextBoxColumn della riga selezionata
                this.txtEliminaTelefono.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["TELEFONO"].Value.ToString();
                // Assegno a txtEliminaPosizioneRubrica il contenuto della cella POSIZIONERUBRICADataGridViewTextBoxColumn della riga selezionata
                this.txtEliminaPosizioneRubrica.Text = this.dtgRubrica.Rows[this.dtgRubrica.CurrentRow.Index].Cells["POSIZIONE_RUBRICA"].Value.ToString();
                // Abilito pulsante btnElimina
                btnElimina.Enabled = true;

                // Nel caso di eccezzione
            }
            catch (Exception)
            {
                // Visualizzo un messaggio all'utente ad indicare che la riga del datagridview selezionata e priva di dati
                MessageBox.Show("Nessun nome,cognome o indirizzo selezionati", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento Click del pulsante btnRicerca

        private void btnRicerca_Click(System.Object sender, System.EventArgs e)
        {
            // Eseguo il costrutto SelectCase su parametro tiporicerca
            switch (this.cbTipoRicerca.Text)
            {
                // Se tiporicerca ha come valore NOME
                case "NOME":
                    // Prova
                    try
                    {
                        //Esegue la query di ricerca TrovaNome
                        this.tabellaRubricaTableAdapter.TrovaNome(this.rubricaDataSet.TabellaRubrica, this.txtRicerca.Text.ToUpper());

                        // Nel caso di eccezzione
                    }
                    catch (System.Exception ex)
                    {
                        // Visualizzo un messaggio all'utente con l'eccezzione sollevata
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }

                    break;
                // Se tiporicerca ha come valore COGNOME
                case "COGNOME":
                    // Prova
                    try
                    {
                        //Esegue la query di ricerca TrovaCognome
                        this.tabellaRubricaTableAdapter.TrovaCognome(this.rubricaDataSet.TabellaRubrica, this.txtRicerca.Text.ToUpper());

                        // Nel caso di eccezzione
                    }
                    catch (System.Exception ex)
                    {
                        // Visualizzo un messaggio all'utente con l'eccezzione sollevata
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }

                    break;
                // Se tiporicerca ha come valore TELEFONO
                case "TELEFONO":
                    // Prova
                    try
                    {
                        //Esegue la query di ricerca TrovaTelefono
                        this.tabellaRubricaTableAdapter.TrovaTelefono(this.rubricaDataSet.TabellaRubrica, this.txtRicerca.Text.ToUpper());

                        // Nel caso di eccezzione
                    }
                    catch (System.Exception ex)
                    {
                        // Visualizzo un messaggio all'utente con l'eccezzione sollevata
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
    }
}