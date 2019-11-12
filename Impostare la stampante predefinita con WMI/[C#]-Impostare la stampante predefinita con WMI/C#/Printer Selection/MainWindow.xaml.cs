//Richiamo dll del Framework 4.0
using System;
using System.Windows;
using System.Management;

//Classe Printer_Selection
namespace Printer_Selection
{
    /// <summary>
    /// Logic of interaction for MainWindow.xaml
    /// </ Summary>
    public partial class MainWindow : Window
    {
        //Dichiarazione di una nuova istanza della Classe ManagementObjectSearcher
        ManagementObjectSearcher search = new ManagementObjectSearcher();
        //Dichiarazione classe ManagementObjectCollection Rappresenta insiemi diversi di oggetti di gestione recuperati tramite wmi
        ManagementObjectCollection results;
        //Definisco una matrice a due elementi di tipo Object
        Object[] arg = new Object [1];

        //Costruttore della Classe MainWindow
        public MainWindow()
        {
            //Metodo InitializeComponent
            InitializeComponent();
        }

        //Evento Loaded della Classe MainWindow
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Prova
            try
            {
                /*Assegno alla variabile search un istanza della classe ManagementObjectSearcher
                 *con la query che dobbiamo specificare come parametro , in questo caso
                 *tramite select * from win32_printer verranno ricercate tutte le stampanti disponibili ed installate nel
                 *sistema operativo.
                 */
                search = new ManagementObjectSearcher("select * from win32_printer");

                /*Il metodo Get appartenente all Classe ManagementObjectSearcher richiama
                 * la query che abbiamo specificato in precedenza in modo da valorizzare la 
                 * variabile results di tipo ManagementObjectCollection con tutto l'insieme 
                 * risultante.
                 */
                results = search.Get();

                /*Eseguiamo un ciclo ForEach assegnando alla variabile printer
                 *di tipo ManagementObject tutti gli insiemi collection della variabile
                 *results
                 */
                foreach (ManagementObject printer in results)
                {
                    /*Valorizziamo tramite la proprietà Intems ed il metodo Add la ComboBox
                     *cbxAvialiblePrinters , la quale visualizzerà tutte la stampanti 
                     *disponibili al suo interno , dando la possibilità di poterle selezionare.
                     */
                    cbxAvialiblePrinters.Items.Add(printer["Name"]);
                }
            }

            /*Gestiamo anche mediante un blocco try/catch e la classe Exception un eventuale
             *eccezzione a runtime.  
             */
            catch (Exception ex)
            {
                //Visualizziamo all'utente una messagebox
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Evento Click del Pulsante btnSelect
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            //Prova
            try
            {
                /*Eseguiamo un ciclo ForEach assegnando alla variabile printer
                *di tipo ManagementObject tutti gli insiemi collection della variabile
                *results
                */
                foreach (ManagementObject print in results)
                {
                    /*Verifichiamo che il valore mediante la proprietà Name 
                     *della variabile print sia uguale al valore della proprietà 
                     *Text del controllo ComboBox cbxAvialiblePrinters
                     */
                    if (print["Name"].Equals(cbxAvialiblePrinters.Text))
                    {
                        /*Richiamiamo il metodo InvokeMethod
                         *il quale richiama il metodo sull'oggetto passato
                         *come argomento in questo caso SetDefaultPrinter ,
                         *che imposterà come stampante predefinita ciò che l'utente
                         *ha selezionato dal controllo ComboBox cbxAvialiblePrinters.
                         */
                        print.InvokeMethod("SetDefaultPrinter", arg);

                        /*Visualizziamo anche mediante un TextBlock tbkPrinterSelect
                         *il nome della stampante attualmente selezionata ed impostata come
                         *stampante predefinita.
                         */
                        tbkPrinterSelect.Text = cbxAvialiblePrinters.Text;
                        break;
                    }

                    /*Aggiungiamo anche un controllo qualora non vi sia stata selezionata
                     *nessuna stampante da parte dell'utente mediante la proprietà SelectedIndex.
                     *Questa proprietà restituisce un intero che stà ad indicare quale items l'utente ha
                     *scelto , nel caso di mancata selezione restituirà valore negativo -1.
                     */
                    else if (cbxAvialiblePrinters.SelectedIndex.Equals(-1))
                    {
                        /*Visualizziamo un messaggio dove chiediamo di selezionate una stampante dal 
                         *ComboBox cbxAvialiblePrinters
                         */
                        MessageBox.Show("Select a printer from the drop-down box", Application.Current.MainWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        break;
                    }
                }
            }

            /*Gestiamo anche mediante un blocco try/catch e la classe Exception un eventuale
             *eccezzione a runtime.  
             */
            catch (Exception ex)
            {
                //Visualizziamo a video all'utente una messagebox
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
