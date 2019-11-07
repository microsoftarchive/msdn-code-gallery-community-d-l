// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Spazio dei nomi AutocompleteTextBox
namespace AutocompleteTextBox
{
    // Classe FrmAutoComplete
    public partial class FrmAutoComplete : Form
    {
        // Costruttore della classe AutoComplete
        public FrmAutoComplete()
        {
            // Metodo InitializeComponent
            InitializeComponent();
        }

        //Evento Click del Pulsante TABELLAPAROLEBindingNavigatorSaveItem
        private void TABELLAPAROLEBindingNavigatorSaveItem_Click(System.Object sender, System.EventArgs e)
        {
            //Verifica il valore del controllo che non è più attivo
            this.Validate();

            //Appplica le modifiche all'origine dati sottostante
            this.tABELLAPAROLEBindingSource.EndEdit();

            //Aggiorna tutte le modifiche al dataset
            this.tableAdapterManager.UpdateAll(this.paroleDataSet);
        }

        //Evento load del form FrmAutoComplete
        private void FrmAutoComplete_Load(System.Object sender, System.EventArgs e)
        {
            //Assegno alla proprietà AutoCompleteMode della TxtBox il valore AutoCompleteMode.Suggest, necessario
            //per eseguire l'autocompletamento e suggerire le parole con una specifica lettera iniziale
            this.TxtAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;

            //Assegno alla proprietà AutoCompleteSource il valore AutoCompleteSource.CustomSource per indicare che
            //la sorgente per l'autocompletemento e prsonalizzata.
            this.TxtAutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Se la variabile AutoComplete non e nothing

            if (Properties.Settings.Default.AutoComplete != null)
            {
                //Assegna alla proprietà AutoCompleteCustomSource di TxtAutoCmplete il contenuto della 
                //Variabile AutoComplete
                this.TxtAutoComplete.AutoCompleteCustomSource = Properties.Settings.Default.AutoComplete;

                //Altrimenti
            }
            else
            {
                //Crea un istanza di AutoComplete
                Properties.Settings.Default.AutoComplete = new System.Windows.Forms.AutoCompleteStringCollection();
                //Eseguo il salvataggio delle impostazioni dell'applicazione
                Properties.Settings.Default.Save();
            }
        }

        //Evento Click del Pulsante btnAutocomplete
        private void btnAutocomplete_Click(System.Object sender, System.EventArgs e)
        {
            //Prova
            try
            {
                //Ottiene il numero di righe che contiene la Tabella del DataGridView
                int rows = AutoCompleteDataGridView.RowCount;

                //Dichiaro una variabile di tipo integer che servirà per scorrere tutte le righe del DataGridWiev 
                int i = 0;

                //Eseguo l'iterazione della variabile i
                for (i = 0; i <= rows - 1; i++)
                {
                    //Aggiungo alla variabile AutoComplete tutti i valore dela cella PAROLE 
                    Properties.Settings.Default.AutoComplete.Add(AutoCompleteDataGridView.Rows[i].Cells["PAROLE"].Value.ToString());
                    //Eseguo il salvataggio delle impostazioni dell'applicazione
                    Properties.Settings.Default.Save();
                }

                //Assegna alla proprietà AutoCompleteCustomSource di TxtAutoCmplete il contenuto della 
                //Variabile AutoComplete
                this.TxtAutoComplete.AutoCompleteCustomSource = Properties.Settings.Default.AutoComplete;

                //Eseguo il salvataggio delle impostazioni dell'applicazione
                Properties.Settings.Default.Save();

            }
                // In caso di eccezzione
            catch (Exception ex)
            {
                // Visualizzo messaggio a utente
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
