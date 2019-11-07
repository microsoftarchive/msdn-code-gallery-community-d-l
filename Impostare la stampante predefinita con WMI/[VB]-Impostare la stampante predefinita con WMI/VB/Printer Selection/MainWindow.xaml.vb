Option Strict Off
Option Explicit On

Class MainWindow
    'Dichiarazione istanza della Classe ManagementObjectSearcher
    Dim search As System.Management.ManagementObjectSearcher

    'Dichiarazione classe ManagementObjectCollection Rappresenta insiemi diversi di oggetti di gestione recuperati tramite wmi
    'WMI, Windows Management Instrumentation è un componente del sistema operativo, quindi non scaricabile separatamente, essendo già incluso, che contiene un set di strumenti
    'per la gestione e la configurazione del sistema operativo. Tramite WMi è possibile visualizzare le stampanti e cambiare quella predefinita 
    'come in questo esempio, oppure vedere le informazioni hardware della macchina dalla scheda madre al processore e le schede installate.
    'Uno dei famosi programmi che si interfacciano con WMi è POWERSHELL.
    'Come vediamo in questo esempio le classi rese disponibili a livello di programmazione sono in .NET framework e sono facili da usare, come visto in questo esempio. 
    'Non bisogna dimenticarsi di aggiungere il riferimento a System.Management
    Dim results As System.Management.ManagementObjectCollection

    'Definisco una matrice a due elementi di tipo Object
    Dim args(1) As Object

    'Costruttore della Classe MainWindow
    Private Sub MainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        'Prova
        Try

            'Assegno alla variabile search un istanza della classe ManagementObjectSearcher
            'con la query che dobbiamo specificare come parametro , in questo caso
            'tramite select * from win32_printer verranno ricercate tutte le stampanti disponibili ed installate nel
            'sistema operativo.
            search = New System.Management.ManagementObjectSearcher("select * from win32_printer")

            'Il metodo Get appartenente all Classe ManagementObjectSearcher richiama
            ' la query che abbiamo specificato in precedenza in modo da valorizzare la 
            ' variabile results di tipo ManagementObjectCollection con tutto l'insieme 
            ' risultante.
            results = search.Get()


            'Eseguiamo un ciclo ForEach assegnando alla variabile printer
            'di tipo ManagementObject tutti gli insiemi collection della variabile
            'results
            For Each printer In results

                'Valorizziamo tramite la proprietà Intems ed il metodo Add la ComboBox
                'cbxAvialiblePrinters , la quale visualizzerà tutte la stampanti 
                'disponibili al suo interno , dando la possibilità di poterle selezionare.
                cbxAvialiblePrinters.Items.Add(printer("Name"))
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
            For Each printer As Management.ManagementObject In results

                'Verifichiamo che il valore mediante la proprietà Name 
                'della variabile print sia uguale al valore della proprietà 
                'Text del controllo ComboBox cbxAvialiblePrinters
                If printer("Name") = cbxAvialiblePrinters.Text Then

                    'Richiamiamo il metodo InvokeMethod
                    'il quale richiama il metodo sull'oggetto passato
                    'come argomento in questo caso SetDefaultPrinter ,
                    'che imposterà come stampante predefinita ciò che l'utente
                    'ha selezionato dal controllo ComboBox cbxAvialiblePrinters.
                    printer.InvokeMethod("SetDefaultPrinter", args(0))

                    'Visualizziamo anche mediante un TextBlock tbkPrinterSelect
                    'il nome della stampante attualmente selezionata ed impostata come
                    'stampante predefinita.
                    tbkPrinterSelect.Text = cbxAvialiblePrinters.Text


                    'Aggiungiamo anche un controllo qualora non vi sia stata selezionata
                    'nessuna stampante da parte dell'utente mediante la proprietà SelectedIndex.
                    'Questa proprietà restituisce un intero che stà ad indicare quale items l'utente ha
                    'scelto , nel caso di mancata selezione restituirà valore negativo -1.
                ElseIf (cbxAvialiblePrinters.SelectedIndex.Equals(-1)) Then

                    'Visualizziamo un messaggio dove chiediamo di selezionare una stampante dal 
                    'ComboBox cbxAvialiblePrinters
                    MessageBox.Show("Select a printer from the drop-down box", Application.Current.MainWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation)
                End If
            Next

            'Gestiamo anche mediante un blocco try/catch e la classe Exception un eventuale eccezzione a runtime.  
        Catch ex As Exception
            'Visualizziamo all'utente una messagebox
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
End Class
