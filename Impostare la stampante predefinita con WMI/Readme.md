# Impostare la stampante predefinita con WMI
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WMI
## Topics
- Printing
- WMI Taks
- Windows Management Interface (WMI)
## Updated
- 06/17/2012
## Description

<h1>Introduction</h1>
<p>Mediante questo esempio sar&agrave; dimostrato come utilizzare Wmi (Windows management instrumentation) per selezionare ed impostare la stampante predefinita tr&agrave; quelle disponibili nel proprio sistema operativo.</p>
<h1><span>Building the Sample</span></h1>
<p>Per poter provare questo esempio &egrave; richiesto il netFramework4.0</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>WMI (Windows Management Instrumentation) &egrave; un componente del sistema operativo,
<br>
quindi non scaricabile separatamente, essendo gi&agrave; incluso, <br>
che contiene un set di strumenti per la gestione e la configurazione del sistema operativo.
<br>
Tramite WMI &egrave; possibile visualizzare le stampanti e cambiare quella predefinita
<br>
&quot;come in questo esempio&quot;, oppure vedere le informazioni hardware della macchina <br>
dalla scheda madre al processore alla cpu fino alle le schede installate e molto altro.<br>
Uno dei famosi programmi che si interfacciano con WMI &egrave; POWERSHELL.<br>
Come vedremo in questo esempio le classi rese disponibili a livello di programmazione
<br>
sono in .NET framework e sono piuttosto facili da usare. <br>
Non bisogna dimenticarsi anche di aggiungere il riferimento a System.Management per poter<br>
fare uso di questa interessante tecnologia , maggiori informazioni riguardo WMI sono<br>
disponibili su Msdn Library . Di seguito riporto il codice di esempio disponibile in VisualBasic Net e C#. Gli esempi sono stati creati utilizzando Wpf (Windows Presentation Foundation) , anche su Wpf si trovano diversi esempi su Msdn Library .</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">//Richiamo dll del Framework 4.0
using System;
using System.Windows;
using System.Management;

//Classe Printer_Selection
namespace Printer_Selection
{
    /// &lt;summary&gt;
    /// Logic of interaction for MainWindow.xaml
    /// &lt;/ Summary&gt;
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
                search = new ManagementObjectSearcher(&quot;select * from win32_printer&quot;);

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
                    /*Valorizziamo tramite la propriet&agrave; Intems ed il metodo Add la ComboBox
                     *cbxAvialiblePrinters , la quale visualizzer&agrave; tutte la stampanti 
                     *disponibili al suo interno , dando la possibilit&agrave; di poterle selezionare.
                     */
                    cbxAvialiblePrinters.Items.Add(printer[&quot;Name&quot;]);
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
                    /*Verifichiamo che il valore mediante la propriet&agrave; Name 
                     *della variabile print sia uguale al valore della propriet&agrave; 
                     *Text del controllo ComboBox cbxAvialiblePrinters
                     */
                    if (print[&quot;Name&quot;].Equals(cbxAvialiblePrinters.Text))
                    {
                        /*Richiamiamo il metodo InvokeMethod
                         *il quale richiama il metodo sull'oggetto passato
                         *come argomento in questo caso SetDefaultPrinter ,
                         *che imposter&agrave; come stampante predefinita ci&ograve; che l'utente
                         *ha selezionato dal controllo ComboBox cbxAvialiblePrinters.
                         */
                        print.InvokeMethod(&quot;SetDefaultPrinter&quot;, arg);

                        /*Visualizziamo anche mediante un TextBlock tbkPrinterSelect
                         *il nome della stampante attualmente selezionata ed impostata come
                         *stampante predefinita.
                         */
                        tbkPrinterSelect.Text = cbxAvialiblePrinters.Text;
                        break;
                    }

                    /*Aggiungiamo anche un controllo qualora non vi sia stata selezionata
                     *nessuna stampante da parte dell'utente mediante la propriet&agrave; SelectedIndex.
                     *Questa propriet&agrave; restituisce un intero che st&agrave; ad indicare quale items l'utente ha
                     *scelto , nel caso di mancata selezione restituir&agrave; valore negativo -1.
                     */
                    else if (cbxAvialiblePrinters.SelectedIndex.Equals(-1))
                    {
                        /*Visualizziamo un messaggio dove chiediamo di selezionate una stampante dal 
                         *ComboBox cbxAvialiblePrinters
                         */
                        MessageBox.Show(&quot;Select a printer from the drop-down box&quot;, Application.Current.MainWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
</pre>
<pre class="hidden">Option Strict Off
Option Explicit On

Class MainWindow
    'Dichiarazione istanza della Classe ManagementObjectSearcher
    Dim search As System.Management.ManagementObjectSearcher

    'Dichiarazione classe ManagementObjectCollection Rappresenta insiemi diversi di oggetti di gestione recuperati tramite wmi
    'WMI, Windows Management Instrumentation &egrave; un componente del sistema operativo, quindi non scaricabile separatamente, essendo gi&agrave; incluso, che contiene un set di strumenti
    'per la gestione e la configurazione del sistema operativo. Tramite WMi &egrave; possibile visualizzare le stampanti e cambiare quella predefinita 
    'come in questo esempio, oppure vedere le informazioni hardware della macchina dalla scheda madre al processore e le schede installate.
    'Uno dei famois programmi che si interfacciano con WMi &egrave; POWERSHELL.
    'Come vediamo in questo esempio le classi rese disponibili a livello di programmazione sono in .NET framework e sono facili da usare, come visto in questo esempio. 
    'Non bisogna dimenticarsi di aggiungere il riferimento a System.Management
    Dim results As System.Management.ManagementObjectCollection

    'Definisco una matrice a due elementi di tipo Object
    Dim args(1) As Object

    'Dichiarazione istanza classe System.Management.ManagementObject
    Dim printer As System.Management.ManagementObject

    'Costruttore della Classe MainWindow
    Private Sub MainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        'Prova
        Try
            'Assegno alla variabile search un istanza della classe ManagementObjectSearcher
            'con la query che dobbiamo specificare come parametro , in questo caso
            'tramite select * from win32_printer verranno ricercate tutte le stampanti disponibili ed installate nel
            'sistema operativo.
            search = New System.Management.ManagementObjectSearcher(&quot;select * from win32_printer&quot;)

            'Il metodo Get appartenente all Classe ManagementObjectSearcher richiama
            ' la query che abbiamo specificato in precedenza in modo da valorizzare la 
            ' variabile results di tipo ManagementObjectCollection con tutto l'insieme 
            ' risultante.
            results = search.Get()


            'Eseguiamo un ciclo ForEach assegnando alla variabile printer
            'di tipo ManagementObject tutti gli insiemi collection della variabile
            'results
            For Each printer In results

                'Valorizziamo tramite la propriet&agrave; Intems ed il metodo Add la ComboBox
                'cbxAvialiblePrinters , la quale visualizzer&agrave; tutte la stampanti 
                'disponibili al suo interno , dando la possibilit&agrave; di poterle selezionare.
                cbxAvialiblePrinters.Items.Add(printer(&quot;Name&quot;))
            Next
            'Gestiamo anche mediante un blocco try/catch e la classe Exception un eventuale eccezzione a runtime.  
        Catch ex As Exception
            'Visualizziamo all'utente una messagebox
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    'Evento Click del Pulsante btnSelect
    Private Sub btnSelect_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)

        'Prova
        Try
            'Eseguiamo un ciclo ForEach assegnando alla variabile prnt
            'di tipo ManagementObject tutti gli insiemi collection della variabile
            'results
            For Each printer In results

                'Verifichiamo che il valore mediante la propriet&agrave; Name 
                'della variabile print sia uguale al valore della propriet&agrave; 
                'Text del controllo ComboBox cbxAvialiblePrinters
                If printer(&quot;Name&quot;) = cbxAvialiblePrinters.Text Then

                    'Richiamiamo il metodo InvokeMethod
                    'il quale richiama il metodo sull'oggetto passato
                    'come argomento in questo caso SetDefaultPrinter ,
                    'che imposter&agrave; come stampante predefinita ci&ograve; che l'utente
                    'ha selezionato dal controllo ComboBox cbxAvialiblePrinters.
                    printer.InvokeMethod(&quot;SetDefaultPrinter&quot;, args(0))

                    'Visualizziamo anche mediante un TextBlock tbkPrinterSelect
                    'il nome della stampante attualmente selezionata ed impostata come
                    'stampante predefinita.
                    tbkPrinterSelect.Text = cbxAvialiblePrinters.Text


                    'Aggiungiamo anche un controllo qualora non vi sia stata selezionata
                    'nessuna stampante da parte dell'utente mediante la propriet&agrave; SelectedIndex.
                    'Questa propriet&agrave; restituisce un intero che st&agrave; ad indicare quale items l'utente ha
                    'scelto , nel caso di mancata selezione restituir&agrave; valore negativo -1.
                ElseIf (cbxAvialiblePrinters.SelectedIndex.Equals(-1)) Then

                    'Visualizziamo un messaggio dove chiediamo di selezionare una stampante dal 
                    'ComboBox cbxAvialiblePrinters
                    MessageBox.Show(&quot;Select a printer from the drop-down box&quot;, Application.Current.MainWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
                End If

            Next
            'Gestiamo anche mediante un blocco try/catch e la classe Exception un eventuale eccezzione a runtime.  
        Catch ex As Exception
            'Visualizziamo all'utente una messagebox
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
End Class
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//Richiamo&nbsp;dll&nbsp;del&nbsp;Framework&nbsp;4.0</span>&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;System.Windows;&nbsp;
using&nbsp;System.Management;&nbsp;
&nbsp;
<span class="js__sl_comment">//Classe&nbsp;Printer_Selection</span>&nbsp;
namespace&nbsp;Printer_Selection&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Logic&nbsp;of&nbsp;interaction&nbsp;for&nbsp;MainWindow.xaml</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/&nbsp;Summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;MainWindow&nbsp;:&nbsp;Window&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Dichiarazione&nbsp;di&nbsp;una&nbsp;nuova&nbsp;istanza&nbsp;della&nbsp;Classe&nbsp;ManagementObjectSearcher</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectSearcher&nbsp;search&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ManagementObjectSearcher();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Dichiarazione&nbsp;classe&nbsp;ManagementObjectCollection&nbsp;Rappresenta&nbsp;insiemi&nbsp;diversi&nbsp;di&nbsp;oggetti&nbsp;di&nbsp;gestione&nbsp;recuperati&nbsp;tramite&nbsp;wmi</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectCollection&nbsp;results;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Definisco&nbsp;una&nbsp;matrice&nbsp;a&nbsp;due&nbsp;elementi&nbsp;di&nbsp;tipo&nbsp;Object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Object</span>[]&nbsp;arg&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Object</span>&nbsp;[<span class="js__num">1</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Costruttore&nbsp;della&nbsp;Classe&nbsp;MainWindow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MainWindow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Metodo&nbsp;InitializeComponent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Evento&nbsp;Loaded&nbsp;della&nbsp;Classe&nbsp;MainWindow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Window_Loaded(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Assegno&nbsp;alla&nbsp;variabile&nbsp;search&nbsp;un&nbsp;istanza&nbsp;della&nbsp;classe&nbsp;ManagementObjectSearcher&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*con&nbsp;la&nbsp;query&nbsp;che&nbsp;dobbiamo&nbsp;specificare&nbsp;come&nbsp;parametro&nbsp;,&nbsp;in&nbsp;questo&nbsp;caso&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*tramite&nbsp;select&nbsp;*&nbsp;from&nbsp;win32_printer&nbsp;verranno&nbsp;ricercate&nbsp;tutte&nbsp;le&nbsp;stampanti&nbsp;disponibili&nbsp;ed&nbsp;installate&nbsp;nel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*sistema&nbsp;operativo.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;search&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ManagementObjectSearcher(<span class="js__string">&quot;select&nbsp;*&nbsp;from&nbsp;win32_printer&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Il&nbsp;metodo&nbsp;Get&nbsp;appartenente&nbsp;all&nbsp;Classe&nbsp;ManagementObjectSearcher&nbsp;richiama&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;la&nbsp;query&nbsp;che&nbsp;abbiamo&nbsp;specificato&nbsp;in&nbsp;precedenza&nbsp;in&nbsp;modo&nbsp;da&nbsp;valorizzare&nbsp;la&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;variabile&nbsp;results&nbsp;di&nbsp;tipo&nbsp;ManagementObjectCollection&nbsp;con&nbsp;tutto&nbsp;l'insieme&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;risultante.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;results&nbsp;=&nbsp;search.Get();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Eseguiamo&nbsp;un&nbsp;ciclo&nbsp;ForEach&nbsp;assegnando&nbsp;alla&nbsp;variabile&nbsp;printer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*di&nbsp;tipo&nbsp;ManagementObject&nbsp;tutti&nbsp;gli&nbsp;insiemi&nbsp;collection&nbsp;della&nbsp;variabile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*results&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(ManagementObject&nbsp;printer&nbsp;<span class="js__operator">in</span>&nbsp;results)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Valorizziamo&nbsp;tramite&nbsp;la&nbsp;propriet&agrave;&nbsp;Intems&nbsp;ed&nbsp;il&nbsp;metodo&nbsp;Add&nbsp;la&nbsp;ComboBox&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*cbxAvialiblePrinters&nbsp;,&nbsp;la&nbsp;quale&nbsp;visualizzer&agrave;&nbsp;tutte&nbsp;la&nbsp;stampanti&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*disponibili&nbsp;al&nbsp;suo&nbsp;interno&nbsp;,&nbsp;dando&nbsp;la&nbsp;possibilit&agrave;&nbsp;di&nbsp;poterle&nbsp;selezionare.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbxAvialiblePrinters.Items.Add(printer[<span class="js__string">&quot;Name&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Gestiamo&nbsp;anche&nbsp;mediante&nbsp;un&nbsp;blocco&nbsp;try/catch&nbsp;e&nbsp;la&nbsp;classe&nbsp;Exception&nbsp;un&nbsp;eventuale&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*eccezzione&nbsp;a&nbsp;runtime.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Visualizziamo&nbsp;all'utente&nbsp;una&nbsp;messagebox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Evento&nbsp;Click&nbsp;del&nbsp;Pulsante&nbsp;btnSelect</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;btnSelect_Click(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Prova</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Eseguiamo&nbsp;un&nbsp;ciclo&nbsp;ForEach&nbsp;assegnando&nbsp;alla&nbsp;variabile&nbsp;printer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*di&nbsp;tipo&nbsp;ManagementObject&nbsp;tutti&nbsp;gli&nbsp;insiemi&nbsp;collection&nbsp;della&nbsp;variabile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*results&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(ManagementObject&nbsp;print&nbsp;<span class="js__operator">in</span>&nbsp;results)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Verifichiamo&nbsp;che&nbsp;il&nbsp;valore&nbsp;mediante&nbsp;la&nbsp;propriet&agrave;&nbsp;Name&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*della&nbsp;variabile&nbsp;print&nbsp;sia&nbsp;uguale&nbsp;al&nbsp;valore&nbsp;della&nbsp;propriet&agrave;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*Text&nbsp;del&nbsp;controllo&nbsp;ComboBox&nbsp;cbxAvialiblePrinters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(print[<span class="js__string">&quot;Name&quot;</span>].Equals(cbxAvialiblePrinters.Text))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Richiamiamo&nbsp;il&nbsp;metodo&nbsp;InvokeMethod&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*il&nbsp;quale&nbsp;richiama&nbsp;il&nbsp;metodo&nbsp;sull'oggetto&nbsp;passato&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*come&nbsp;argomento&nbsp;in&nbsp;questo&nbsp;caso&nbsp;SetDefaultPrinter&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*che&nbsp;imposter&agrave;&nbsp;come&nbsp;stampante&nbsp;predefinita&nbsp;ci&ograve;&nbsp;che&nbsp;l'utente&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*ha&nbsp;selezionato&nbsp;dal&nbsp;controllo&nbsp;ComboBox&nbsp;cbxAvialiblePrinters.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;print.InvokeMethod(<span class="js__string">&quot;SetDefaultPrinter&quot;</span>,&nbsp;arg);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Visualizziamo&nbsp;anche&nbsp;mediante&nbsp;un&nbsp;TextBlock&nbsp;tbkPrinterSelect&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*il&nbsp;nome&nbsp;della&nbsp;stampante&nbsp;attualmente&nbsp;selezionata&nbsp;ed&nbsp;impostata&nbsp;come&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*stampante&nbsp;predefinita.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbkPrinterSelect.Text&nbsp;=&nbsp;cbxAvialiblePrinters.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Aggiungiamo&nbsp;anche&nbsp;un&nbsp;controllo&nbsp;qualora&nbsp;non&nbsp;vi&nbsp;sia&nbsp;stata&nbsp;selezionata&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*nessuna&nbsp;stampante&nbsp;da&nbsp;parte&nbsp;dell'utente&nbsp;mediante&nbsp;la&nbsp;propriet&agrave;&nbsp;SelectedIndex.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*Questa&nbsp;propriet&agrave;&nbsp;restituisce&nbsp;un&nbsp;intero&nbsp;che&nbsp;st&agrave;&nbsp;ad&nbsp;indicare&nbsp;quale&nbsp;items&nbsp;l'utente&nbsp;ha&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*scelto&nbsp;,&nbsp;nel&nbsp;caso&nbsp;di&nbsp;mancata&nbsp;selezione&nbsp;restituir&agrave;&nbsp;valore&nbsp;negativo&nbsp;-1.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__statement">if</span>&nbsp;(cbxAvialiblePrinters.SelectedIndex.Equals(-<span class="js__num">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Visualizziamo&nbsp;un&nbsp;messaggio&nbsp;dove&nbsp;chiediamo&nbsp;di&nbsp;selezionate&nbsp;una&nbsp;stampante&nbsp;dal&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*ComboBox&nbsp;cbxAvialiblePrinters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Select&nbsp;a&nbsp;printer&nbsp;from&nbsp;the&nbsp;drop-down&nbsp;box&quot;</span>,&nbsp;Application.Current.MainWindow.Title,&nbsp;MessageBoxButton.OK,&nbsp;MessageBoxImage.Exclamation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__ml_comment">/*Gestiamo&nbsp;anche&nbsp;mediante&nbsp;un&nbsp;blocco&nbsp;try/catch&nbsp;e&nbsp;la&nbsp;classe&nbsp;Exception&nbsp;un&nbsp;eventuale&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*eccezzione&nbsp;a&nbsp;runtime.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Visualizziamo&nbsp;a&nbsp;video&nbsp;all'utente&nbsp;una&nbsp;messagebox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>Questo articolo e stato creato da Piero Sbressa e Carmelo La Monica , potete contattarli a questi riferimenti</em></p>
<p><em>Piero Sbressa</em></p>
<div class="mcePaste" id="_mcePaste" style="width:1px; height:1px; overflow:hidden; top:0px; left:-10000px">
</div>
<p>&nbsp;</p>
<p><em><a href="mailto:pierosbressa@crystalweb.it"><span style="color:#00749e">pierosbressa@crystalweb.it</span></a></em></p>
<p><em><a href="http://www.crystalweb.it/"><span style="text-decoration:underline"><span style="font-size:x-small"><span><span style="color:#00749e">www.crystalweb.it</span></span></span></span></a></em></p>
<p><em>Carmelo La Monica</em></p>
<p><em><span style="font-size:x-small"><a href="http://community.visual-basic.it/carmelolamonica/default.aspx"><span style="color:#960bb4">http://community.visual-basic.it/carmelolamonica/default.aspx</span></a></span><br>
</em></p>
