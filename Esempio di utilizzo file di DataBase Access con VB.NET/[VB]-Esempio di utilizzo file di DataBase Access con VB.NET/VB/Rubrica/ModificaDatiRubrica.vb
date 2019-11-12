' Classe ModificaDatiRubrica
Public Class ModificaDatiRubrica

    ' Dichiaro quattro variabili di tipo string ed assegno il valore String.Empty
    Dim nomeModificato As String = String.Empty
    Dim cognomeModificato As String = String.Empty
    Dim telefonoModificato As String = String.Empty
    Dim posizioneRubrica As String = String.Empty

    ' Questa funzione quando richiamata restituisce il valore della variabile nomeModificato
    ' Valorizzata tramite l'altro metodo ovvero setNomeModificato , il metodo sarà poi richiamato
    ' Al momento di riassegnare il nome eventualmente modificato al campo NOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNomeModificato() As String
        ' Restituisco il valore di nomeModificato al chiamante
        Return Me.nomeModificato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro nomemodificato,il metodo sarà poi richiamato
    ' nel caso l'utente voglia modificare il campo NOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile nomeModificato può essere recuperata tramite la funzione getNomeModificato()
    Public Sub setNomeModificato(ByVal nomemodificato As String)
        ' Valorizzo la variabile nomeModificato 
        Me.nomeModificato = nomemodificato
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile cognomeModificato
    ' Valorizzata tramite l'altro metodo ovvero setCognomeModificato , il metodo sarà poi richiamato
    ' Al momento di riassegnare il cognome eventualmente modificato al campo COGNOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getCognonmeModoficato() As String
        ' Restituisco il valore di cognomeModificato al chiamante
        Return Me.cognomeModificato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro cognomemodificato,il metodo sarà poi richiamato
    ' nel caso l'utente voglia modificare il campo COGNOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile cognomeModificato può essere recuperata tramite la funzione getCogNomeModificato()
    Public Sub setCognomeModificato(ByVal cognomemodificato As String)
        ' Valorizzo la variabile nomeModificato 
        Me.cognomeModificato = cognomemodificato
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile telefonoModificato
    ' Valorizzata tramite l'altro metodo ovvero setNumeroTelefono , il metodo sarà poi richiamato
    ' Al momento di riassegnare il telefono eventualmente modificato al campo TELEFONO del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNumeroTelefonoModificato() As String
        ' Restituisco il valore di telefonoModificato al chiamante
        Return Me.telefonoModificato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro telefonodificato,il metodo sarà poi richiamato
    ' nel caso l'utente voglia modificare il campo TELEFONO all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile telefonoModificato può essere recuperata tramite la funzione getNumeroTelefonoModificato()
    Public Sub setNumeroTelefono(ByVal telefonomodificato As String)
        ' Valorizzo la variabile telefonoModificato 
        Me.telefonoModificato = telefonomodificato
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile posizioneRubrica
    ' Valorizzata tramite l'altro metodo ovvero setPosizioneRubrica , il metodo sarà poi richiamato
    ' Solamente per identificare tramite la clausola WHERE della query sql di modifica , in modo da
    ' Modificare i dati appartenenti a tale posizione rubrica
    Public Function getPosizioneRubrica() As String
        ' Restituisco il valore di posizioneRubrica al chiamante
        Return Me.posizioneRubrica
    End Function

    ' Questa Sub quando richiamata restituisce il valore della variabile posizionerubrica
    ' Valorizzata tramite l'altro metodo ovvero getPosizioneRubrica , il metodo sarà poi richiamato
    ' Solamente per memorizzare e restituire tramite la funzione getPosizioneRubrica il numero di posizione rubrica che sara poi 
    ' Confrontato tramite la clausola WHERE della query sql di modifica , in modo da
    ' Modificare i dati apparteneti a tale posizione rubrica
    Public Sub setPosizioneRubrica(ByVal posizionerubrica As String)
        ' Valorizzo la variabile posizionerubrica 
        Me.posizioneRubrica = posizionerubrica
    End Sub
End Class
