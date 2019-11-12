' Classe GestioneRubrica
Public Class GestioneRubrica

    ' Istanzio un nuovo oggetto di tipo InserisciDatiRubrica
    Dim RubricaDAO As New RubricaDAO

    ' Metodo inserisciDatiRubrica
    ' Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
    ' Successivamente inseriti all'interno del Database Rubrica
    Public Sub inserisciDatiRubrica(ByVal nome As String, ByVal cognome As String, ByVal telefono As String, ByVal posizionerubrica As String)
        ' Richiamo il metodo InserisciDatiRubrica della classe RubricaDAO
        ' Anche questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        ' Successivamente inseriti all'interno del Database Rubrica
        RubricaDAO.InserisciDatiRubrica(nome, cognome, telefono, posizionerubrica)
    End Sub

    ' Metodo rimuoviDatiRubrica
    ' Questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
    ' Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
    Public Sub rimuoviDatiRubrica(ByVal posizionerubrica As String)
        ' Richiamo il metodo EliminaDatiRubrica della classe RubricaDAO
        ' Anche questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
        ' Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
        RubricaDAO.EliminaDatiRubrica(posizionerubrica)
    End Sub

    ' Metodo modificaDatiRubrica
    ' Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
    ' Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
    Public Sub modificaDatiRubrica(ByVal nome As String, ByVal cognome As String, ByVal telefono As String, ByVal posizionerubrica As String)
        ' Metodo ModificaDatiRubrica
        ' Anche questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        ' Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
        RubricaDAO.ModificaDatiRubrica(nome, cognome, telefono, posizionerubrica)
    End Sub
End Class
