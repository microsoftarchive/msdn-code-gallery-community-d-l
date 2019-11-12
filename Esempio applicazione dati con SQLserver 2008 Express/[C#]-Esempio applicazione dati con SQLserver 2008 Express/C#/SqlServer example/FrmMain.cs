//dll .netFramework
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Spazio dei nomi SqlSever_example
namespace SqlServer_example
{
    // Classe FrmMain
    public partial class FrmMain : Form
    {
        // Costruttore pubblico della Classe FrmMain
        public FrmMain()
        {
            // Richiamo metodo InitializeComponent
            InitializeComponent();
        }

        // Evento Load del Form FrmMain
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Richiamo metodo LoadData
            LoadData();
        }

        // Evento click del pulsante btnInsert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Dichiaro una nuova istanza della Classe Insert
            Insert i = new Insert();
            // Passo al metodo setName della Classe Insert il valore inserito dall'utente nel controllo TextBox txtName
            i.setName(this.txtName.Text);
            // Passo al metodo setName della Classe Insert il valore inserito dall'utente nel controllo TextBox txtSurName
            i.setSurName(this.txtSurName.Text);
            // Passo al metodo setName della Classe Insert il valore inserito dall'utente nel controllo TextBox txAge
            i.setAge(this.txtAge.Text);

            // Creo una nuova istanza della Classe DatabaseManagement
            DatabaseManagement dbInsert = new DatabaseManagement();
            // Passo al metodo insertData i parametri necessari per la memorizzazione del Nome,Cognome e Età all'interno della
            // Tabella del DataBase
            dbInsert.insertData(i.getName(), i.getSurName(),i.getAge());

            // Richiamo metodo LoadData
            LoadData();
        }

        // Evento click del pulsante btnDelete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Dichiaro una nuova istanza della Classe Delete
            Delete d = new Delete();
            // Passo al metodo setName della Classe Delete il valore inserito dall'utente nel controllo TextBox txtName
            d.setName(this.txtName.Text);
            // Passo al metodo setName della Classe Delete il valore inserito dall'utente nel controllo TextBox txtSurName
            d.setSurName(this.txtSurName.Text);
            // Passo al metodo setName della Classe Delete il valore inserito dall'utente nel controllo TextBox txAge
            d.setAge(this.txtAge.Text);

            // Creo una nuova istanza della Classe DatabaseManagement
            DatabaseManagement dbDelete = new DatabaseManagement();
            // Passo al metodo deleteData i parametri necessari per la memorizzazione del Nome,Cognome e Età all'interno della
            // Tabella del DataBase
            dbDelete.deleteData(d.getName(), d.getSurName(), d.getAge());

            // Richiamo metodo LoadData
            LoadData();
        }

        // Evento click del pulsante btnUpdate
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Dichiaro una nuova istanza della Classe UpdateDati
            UpdateDati ud = new UpdateDati();
            // Passo al metodo setName della Classe UpdateDati il valore inserito dall'utente nel controllo TextBox txtName
            ud.setName(this.txtName.Text);
            // Passo al metodo setName della Classe UpdateDati il valore inserito dall'utente nel controllo TextBox txtSurName
            ud.setSurName(this.txtSurName.Text);
            // Passo al metodo setName della Classe UpdateDati il valore inserito dall'utente nel controllo TextBox txtAge
            ud.setAge(this.txtAge.Text);

            // Creo una nuova istanza della Classe DatabaseManagement
            DatabaseManagement dbUpdate = new DatabaseManagement();
            // Passo al metodo updateData i parametri necessari per la memorizzazione del Nome,Cognome e Età all'interno della
            // Tabella del DataBase
            dbUpdate.updateData(ud.getName(), ud.getSurName(), ud.getAge());

            // Richiamo metodo LoadData
            LoadData();
        }

        // Evento click del pulsante btnFindTypeData
        private void btnFindTypeData_Click(object sender, EventArgs e)
        {
            // Eseguo controllo sul valore del controllo ComboBox cbxTypeData
            switch (this.cbxTypeData.Text)
            {
                // Se valore NAME
                case "NAME":
                    // Eseguo la query di ricerca LinqToDataSet per nome
                    var queryName = from c in this.exampleDataSet.TABELLA1
                                 where  c.NOME  == this.txtFind.Text.ToUpper()
                                 select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryName.AsDataView();
                    // Visualizzo a utente i risultati della ricerca
                    this.lblFind.Text = "Ricerca terminata. Trovati" + " " + queryName.AsDataView().Count.ToString() + " " + "elementi";
                    break;

                // Se valore SURNAME
                case "SURNAME":
                    // Eseguo la query di ricerca LinqToDataSet per Cognome
                    var querySurName = from c in this.exampleDataSet.TABELLA1
                                where c.COGNOME == this.txtFind.Text.ToUpper()
                                select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = querySurName.AsDataView();
                    break;

                // Se valore AGE
                case "AGE":
                    // Eseguo la query di ricerca LinqToDataSet per età
                    var queryAge = from c in this.exampleDataSet.TABELLA1
                                where c.AGE  == this.txtFind.Text.ToUpper()
                                select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryAge.AsDataView();
                    break;
            }
        }

        // Evento click del pulsante btnFindLinq
        private void btnFindLinq_Click(object sender, EventArgs e)
        {
            // Eseguo controllo sul valore del controllo ComboBox cbxLinq
            switch (cbxLinq.Text)
            {
                // Se valore ASCENDING NAME
                case "ASCENDING NAME":
                    // Eseguo la query di ricerca LinqToDataSet per nome e ordino il 
                    // Risultato in senso crescente
                    var queryAscendingName = from c in this.exampleDataSet.TABELLA1 
                                    orderby c.NOME ascending
                                    select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryAscendingName.AsDataView();
                    break;

                // Se valore DESCENDING NAME
                case "DESCENDING NAME":
                    // Eseguo la query di ricerca LinqToDataSet per nome e ordino il 
                    // Risultato in senso decrescente
                    var queryDescendingName = from c in this.exampleDataSet.TABELLA1
                                             orderby c.NOME descending
                                             select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryDescendingName.AsDataView();
                    break;

                // Se valore ASCENDING SURNAME
                case "ASCENDING SURNAME":
                    // Eseguo la query di ricerca LinqToDataSet per Cognome e ordino il 
                    // Risultato in senso crescente
                    var queryAscendingSurName = from c in this.exampleDataSet.TABELLA1
                                             orderby c.COGNOME ascending
                                             select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryAscendingSurName.AsDataView();
                    break;

                // Se valore DESCENDING NAME
                case "DESCENDING SURNAME":
                    // Eseguo la query di ricerca LinqToDataSet per Cognome e ordino il 
                    // Risultato in senso decrescente
                    var queryDescendingSurName = from c in this.exampleDataSet.TABELLA1
                                              orderby c.COGNOME descending
                                              select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryDescendingSurName.AsDataView();
                    break;

                // Se valore ASCENDING AGE
                case "ASCENDING AGE":
                    // Eseguo la query di ricerca LinqToDataSet per età e ordino il 
                    // Risultato in senso crescente
                    var queryAscendingAge = from c in this.exampleDataSet.TABELLA1
                                             orderby c.AGE ascending
                                             select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryAscendingAge.AsDataView();
                    break;

                // Se valore DESCENDING AGE
                case "DESCENDING AGE":
                    // Eseguo la query di ricerca LinqToDataSet per età e ordino il 
                    // Risultato in senso decrescente
                    var queryDescendingAge = from c in this.exampleDataSet.TABELLA1
                                              orderby c.AGE descending
                                              select c;

                    // Assegno il risultato della query alla proprietà DataSource del controllo
                    // DataGridView dgvExample
                    this.dgvExample.DataSource = queryDescendingAge.AsDataView();
                    break;
            }
        }

        // Evento click del pulsante btnExit
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Esco e chiudo l'applicazione SqlServer example
            Application.Exit();
        }

        // Evento SelectedIndexChanged del ComboBox cbxTypeData
        private void cbxTypeData_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se l'utente non ha selezionato un criterio di ricerca
            if (this.cbxTypeData.Text.Equals(""))
            {
                // Disabilito pulsante btnFindTypeData
                this.btnFindTypeData.Enabled = false;
            }

            // Altrimenti
            else
            {
                // Abilito pulsante btnFindTypeData
                this.btnFindTypeData.Enabled = true;
            }
        }

        // Evento SelectedIndexChanged del ComboBox cbxTypeData
        private void cbxLinq_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se l'utente non ha selezionato un criterio di ricerca
            if (this.cbxLinq.Text.Equals(""))
            {
                // Disabilito pulsante btnFindLinq
                this.btnFindLinq.Enabled = false;
            }

            // Altrimenti
            else
            {
                // Abilito pulsante btnFindLinq
                this.btnFindLinq.Enabled = true;
            }
        }

        // Evento RowEnter del controllo dgvExample
        private void dgvExample_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Prova
            try
            {
                // Assegno al controllo txtName il valore selezionato dall'utente sul controllo dgvExample
                this.txtName.Text = this.dgvExample.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
                // Assegno al controllo txtSurName il valore selezionato dall'utente sul controllo dgvExample
                this.txtSurName.Text = this.dgvExample.Rows[e.RowIndex].Cells["SURNAME"].Value.ToString();
                // Assegno al controllo txtAge il valore selezionato dall'utente sul controllo dgvExample
                this.txtAge.Text = this.dgvExample.Rows[e.RowIndex].Cells["AGE"].Value.ToString();
            }

            // In caso di eccezzione
            catch (System.Exception ex)
            {
                // Visualizzo messaggio a utente
                MessageBox.Show(ex.Message);
            }
        }

        // Metodo LoadData
        private void LoadData()
        {
            // Disabilito pulsante btnFindTypeData
            this.btnFindTypeData.Enabled = false;
            // Disabilito pulsante btnFindLinq
            this.btnFindLinq.Enabled = false;
            // Popolo la tabella con i dati presenti nel DataBase
            this.tABELLA1TableAdapter.Fill(this.exampleDataSet.TABELLA1);
        }
    }
}
