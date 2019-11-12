//Richiamo dll del netFramework
using System;
using System.Windows;

//Spazio dei Nomi GridSample
namespace GridSample
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Costruttore della Classe MainWindow
        public MainWindow()
        {
            //Metodo InitializeComponent
            InitializeComponent();
        }

        /*Evento Click del Pulsante btnLoad. All'interno di questo evento
                    viene creata un istanza della Classe DataBaseManagement, la quale si occupa
                    di interagire trà l'applicazione e la fonte dati alla quale ci connettiamo */
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            //Dichiaro una nuova istanza della Classe DataBaseManagement
            var Management = new DataBaseManagement();
            /*Mediante il Metodo LoadData contenuto nell'istanza Management , carichiamo all'interno
                               di un controllo DataGrid il contenuto di una tabella in questo caso DatiPersonali da un DataBase
                               denominato Rubrica , tutto mediante query Select , e mediante la proprietà DefaultView
                                possiamo personalizzare la visualizzazione dei dati  filtrata secondo nostre esigenze*/
            dgvDati.ItemsSource = Management.LoadData().DefaultView;
        }

        /*Evento Loaded della Classe Window , questo evento viene eseguito subito dopo il caricamento
                      del Form MainWindow , e come per il caso precedente viene caricato all'interno di un controllo 
                      DataGrid il contenuto di una tabella da un DataBase mediante query Select*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Dichiaro una nuova istanza della Classe DataBaseManagement
            var Management = new DataBaseManagement();
            /*Mediante il Metodo LoadData contenuto nell'istanza Management , carichiamo all'interno
                               di un controllo DataGrid il contenuto di una tabella in questo caso DatiPersonali da un DataBase
                               denominato Rubrica , tutto mediante query Select , e mediante la proprietà DefaultView
                                possiamo personalizzare la visualizzazione dei dati  filtrata secondo nostre esigenze*/
            dgvDati.ItemsSource = Management.LoadData().DefaultView;
        }

        /*Evento Click del Pulsante btnInsert. All'interno di questo evento
                    viene creata un istanza della Classe Insert, la quale si occupa
                    mediante cinque proprietà di inserire tutti i riferimenti riguardanti Nome , Cognome
                    Indirizzo, Telefono e Nazionalità , passati come argomenti al metodo InsertData sempre contenuto
                    nella Classe DataBaseManagement*/
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            //Dichiaro una nuova istanza della Classe Insert
            var NewContact = new Insert
            {
                /*Valorizzo le Proprietà da InsertName a InsertNationality con i valori contenuti
                                         nelle TextBox abbinate*/
                InsertName = txtName.Text,
                InsertSurname = txtSurname.Text,
                InsertAddress = txtAddress.Text,
                InsertTelephone = txtTelephone.Text,
                InsertNationality = txtNationality.Text
            };

            //Dichiaro una nuova istanza della Classe DataBaseManagement
            var management = new DataBaseManagement();

            /*Mediante il Metodo InsertData contenuto nell'istanza Management , carichiamo all'interno
                               della Tabella DatiPersonali di tutto ciò che abbiamo inserito nelle procedenti proprietà passate poi come
                               argomenti a questo metodo il quale esegue una query Insert*/
            management.InsertData(NewContact.InsertName, NewContact.InsertSurname, NewContact.InsertAddress, NewContact.InsertTelephone, NewContact.InsertNationality);
        }

        /*Evento Click del Pulsante btnDelete. All'interno di questo evento
                     viene creata un istanza della Classe Delete, la quale contiene
                     cinque proprietà , che valorizzate dall'utente memorizzano i dati da passare successivamente al Metodo 
                    metodo DeleteData sempre contenuto nella Classe DataBaseManagement .
                    Verrà eseguita la cancellazione dalla tabella DatiPersonali di tutti i record riguardanti Nome , Cognome
                     Indirizzo, Telefono e Nazionalità inseriti dell'utente , tutto questo mediante una query Sql Delete*/
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Dichiaro una nuova istanza della Classe Delete
            var DeleteContact = new Delete
            {
                /*Valorizzo le Proprietà da InsertName a InsertNationality con i valori contenuti
                                        nelle TextBox abbinate*/
                DeleteName = txtName.Text,
                DeleteSurname = txtSurname.Text,
                DeleteAddress = txtAddress.Text,
                DeleteTelephone = txtTelephone.Text,
                DeleteNationality = txtNationality.Text
            };

            //Dichiaro una nuova istanza della Classe DataBaseManagement
            var management = new DataBaseManagement();

            /*Mediante il Metodo DeleteData contenuto nell'istanza Management , si esegue la cancellazione dei dati all'interno
                               della Tabella DatiPersonali di tutto ciò che abbiamo inserito nelle procedenti proprietà passate poi come
                               argomenti a questo metodo il quale esegue una query Delete*/
            management.DeleteData(DeleteContact.DeleteName, DeleteContact.DeleteSurname, DeleteContact.DeleteAddress, DeleteContact.DeleteTelephone, DeleteContact.DeleteNationality);
        }

        /*Evento Click del Pulsante btnUpdate. All'interno di questo evento
                     viene creata un istanza della Classe Update, la quale contiene
                     cinque proprietà , che valorizzate dall'utente memorizzano le modifiche da passare successivamente al Metodo 
                    metodo UpdateData sempre contenuto nella Classe DataBaseManagement .
                    Verrà eseguito l'aggiornamento della tabella DatiPersonali su tutti i campi riguardanti Nome , Cognome
                     Indirizzo, Telefono e Nazionalità secondo l'id Contatto inserito dell'utente , tutto questo mediante una query Sql Update*/
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Dichiaro una nuova istanza della Classe Update
            var UpdateContact = new Update
            {
                /*Valorizzo le Proprietà da InsertName a InsertNationality con i valori contenuti
                                        nelle TextBox abbinate*/
                UpdateId = txtId.Text,
                UpdateName = txtName.Text,
                UpdateSurname = txtSurname.Text,
                UpdateAddress = txtAddress.Text,
                UpdateTelephone = txtTelephone.Text,
                UpdateNationality = txtNationality.Text
            };

            //Dichiaro una nuova istanza della Classe DataBaseManagement
            var Management = new DataBaseManagement();

            /*Mediante il Metodo UpdateData contenuto nell'istanza Management , si esegue l'aggiornamento  dei dati all'interno
                               della Tabella DatiPersonali di tutto ciò che abbiamo inserito nelle procedenti proprietà passate poi come
                               argomenti a questo metodo il quale esegue una query Update*/
            Management.UpdateData(UpdateContact.UpdateName, UpdateContact.UpdateSurname, UpdateContact.UpdateAddress, UpdateContact.UpdateTelephone, UpdateContact.UpdateNationality, UpdateContact.UpdateId);

            //Disabilito in pulsante btnUpdate dopo l'aggiornamento
            btnUpdate.IsEnabled = !btnUpdate.IsEnabled;
        }

        //Evento Click del pulsante btnEsci
        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            //Mediante il Metodo Shutdown , chiudiamo l'applicazione corrente. 
            Application.Current.Shutdown();
        }

        //Evento TextChanged del controllo txtId
        private void txtId_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //Abilito in pulsante btnUpdate per l'aggiornamento dei Dati
            btnUpdate.IsEnabled = true;
        }
    }
}

