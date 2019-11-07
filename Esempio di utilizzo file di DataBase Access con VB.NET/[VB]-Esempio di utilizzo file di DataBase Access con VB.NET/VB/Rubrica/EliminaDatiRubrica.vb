' Classe EliminaDatiRubrica
Public Class EliminaDatiRubrica

    ' Dichiaro una variabile di tipo string ed assegno il valore String.Empty
    Dim posizioneRubricaEliminato As String = String.Empty

    ' Questa funzione quando richiamata restituisce il valore della variabile posizioneRubricaEliminato
    ' Valorizzata tramite l'altro metodo ovvero setPosizioneRubricaEliminato , il metodo sarà poi richiamato
    ' Al momento di eliminare uno o più record dal Database Rubrica aventi lo stesso numero di posizione rubrica
    Public Function getPosizioneRubricaEliminato() As String
        ' Restituisco il valore di posizioneRubricaEliminato al chiamante
        Return Me.posizioneRubricaEliminato
    End Function

    ' Questa Sub quando richiamata si aspetta un parametro tipo string e
    ' Valorizzata tramite il parametro posizionerubricaeliminato,il metodo sarà poi richiamato
    ' nel caso l'utente voglia eliminare dal Database Rubrica il o i record aventi lo stesso numero di posizione rubrica
    ' Successivamente la variabile nome può essere recuperata tramite la funzione getPosizioneRubricaEliminato()
    Public Sub setPosizioneRubricaEliminato(ByVal posizionerubricaeliminato As String)
        ' Valorizzo la variabile posizioneRubricaEliminato
        Me.posizioneRubricaEliminato = posizionerubricaeliminato
    End Sub
End Class
