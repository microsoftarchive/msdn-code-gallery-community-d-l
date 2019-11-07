' Classe TrovaDatiRubrica
Public Class TrovaDatiRubrica

    ' Dichiaro due variabili di tipo string ed assegno il valore String.Empty
    Dim tipoRicerca As String = String.Empty
    Dim Ricerca As String = String.Empty

    ' Questa funzione quando richiamata restituisce il valore della variabile tipoRicerca
    ' Valorizzata tramite l'altro metodo ovvero setTipoRicerca , il metodo sarà poi richiamato
    ' Al momento di assegnare il tipo di ricerca all'interno del Database Rubrica se per nome , cognome o telefono 
    Public Function getTipoRicerca() As String
        ' Restituisco il valore di tipoRicerca al chiamante
        Return Me.tipoRicerca
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro tiporicerca,il metodo sarà poi richiamato
    ' Al momento di assegnare il tipo di ricerca all'interno del Database Rubrica se per nome , cognome o telefono 
    Public Sub setTipoRicerca(ByVal tiporicerca As String)
        ' Valorizzo la variabile tipoRicerca
        Me.tipoRicerca = tiporicerca
    End Sub

    ' Questa funzione quando richiamata restituisce il valore della variabile Ricerca
    ' Valorizzata tramite l'altro metodo ovvero Ricerca , il metodo sarà poi richiamato
    ' Al momento di eseguire una ricerca all'interno del Database Rubrica
    Public Function getRicerca() As String
        ' Restituisco il valore di Ricerca al chiamante
        Return Me.Ricerca
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro ricerca,il metodo sarà poi richiamato
    ' Al momento di assegnare un nome , cognome o telefono da ricercare 
    Public Sub setRicerca(ByVal ricerca As String)
        ' Valorizzo la variabile Ricerca
        Me.Ricerca = ricerca
    End Sub
End Class
