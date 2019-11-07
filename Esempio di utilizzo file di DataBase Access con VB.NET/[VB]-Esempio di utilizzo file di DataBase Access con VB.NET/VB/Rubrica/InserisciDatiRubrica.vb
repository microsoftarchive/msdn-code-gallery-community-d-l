' Classe InserisciDatiRubrica
Public Class InserisciDatiRubrica

    ' Dichiaro quattro variabili di tipo string ed assegno il valore String.Empty
    Dim nome As String = String.Empty
    Dim cognome As String = String.Empty
    Dim telefono As String = String.Empty
    Dim posizioneRubrica As String = String.Empty

    ' Questa funzione quando richiamata restituisce il valore della variabile nome
    ' Valorizzata tramite l'altro metodo ovvero setNome , il metodo sarà poi richiamato
    ' Al momento di inserire il nome al campo NOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNome() As String
        ' Restituisco il valore di nome al chiamante
        Return Me.nome
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro nome,il metodo sarà poi richiamato
    ' nel caso l'utente voglia inserire il nome nel campo NOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile nome può essere recuperata tramite la funzione getNome()
    Public Sub setNome(ByVal nome As String)
        ' Valorizzo la variabile nomeModificato 
        Me.nome = nome
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile cognome
    ' Valorizzata tramite l'altro metodo ovvero setCognome , il metodo sarà poi richiamato
    ' Al momento di inserire il cognome al campo COGNOME del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getCognonme() As String
        ' Restituisco il valore di cognome al chiamante
        Return Me.cognome
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro cognome,il metodo sarà poi richiamato
    ' nel caso l'utente voglia inserire il cogmome nel campo COGNOME all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile cognome può essere recuperata tramite la funzione getCogNome()
    Public Sub setCognome(ByVal cognome As String)
        ' Valorizzo la variabile nomeModificato 
        Me.cognome = cognome
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile telefono
    ' Valorizzata tramite l'altro metodo ovvero setNumeroTelefono , il metodo sarà poi richiamato
    ' Al momento di inserire il numero di telefono al campo TELEFONO del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getNumeroTelefono() As String
        ' Restituisco il valore di telefono al chiamante
        Return Me.telefono
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro telefono,il metodo sarà poi richiamato
    ' nel caso l'utente voglia inserire il numero di telefono nel campo TELEFONO all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile telefono può essere recuperata tramite la funzione getNumeroTelefono()
    Public Sub setNumeroTelefono(ByVal telefono As String)
        ' Valorizzo la variabile telefonoModificato 
        Me.telefono = telefono
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile posizioneRubrica
    ' Valorizzata tramite l'altro metodo ovvero setPosizioneRubrica , il metodo sarà poi richiamato
    ' Al momento di inserire il numero di posizione rubrica al campo POSIZIONE_RUBRICA del Database Rubrica della riga selezionata
    ' Sul datagridview
    Public Function getPosizioneRubrica() As String
        ' Restituisco il valore di posizioneRubrica al chiamante
        Return Me.posizioneRubrica
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro posizionerubrica,il metodo sarà poi richiamato
    ' nel caso l'utente voglia inserire il numero di posizone rubrica nel campo POSIZONE_RUBRICA all'interno del Database Rubrica della riga selezionata sul datagridview e
    ' Successivamente la variabile posizioneRubrica può essere recuperata tramite la funzione getPosizioneRubrica()
    Public Sub setPosizioneRubrica(ByVal posizionerubrica As String)
        ' Valorizzo la variabile posizionerubrica 
        Me.posizioneRubrica = posizionerubrica
    End Sub
End Class
