// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe GestioneRubrica
    class GestioneRubrica
    {
        // Istanzio un nuovo oggetto di tipo InserisciDatiRubrica

        RubricaDAO RubricaDAO = new RubricaDAO();
        // Metodo inserisciDatiRubrica
        // Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        // Successivamente inseriti all'interno del Database Rubrica
        public void inserisciDatiRubrica(string nome, string cognome, string telefono, string posizionerubrica)
        {
            // Richiamo il metodo InserisciDatiRubrica della classe RubricaDAO
            // Anche questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
            // Successivamente inseriti all'interno del Database Rubrica
            RubricaDAO.InserisciDatiRubrica(nome, cognome, telefono, posizionerubrica);
        }

        // Metodo rimuoviDatiRubrica
        // Questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
        // Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
        public void rimuoviDatiRubrica(string posizionerubrica)
        {
            // Richiamo il metodo EliminaDatiRubrica della classe RubricaDAO
            // Anche questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
            // Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
            RubricaDAO.EliminaDatiRubrica(posizionerubrica);
        }

        // Metodo modificaDatiRubrica
        // Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        // Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
        public void modificaDatiRubrica(string nome, string cognome, string telefono, string posizionerubrica)
        {
            // Metodo ModificaDatiRubrica
            // Anche questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
            // Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
            RubricaDAO.ModificaDatiRubrica(nome, cognome, telefono, posizionerubrica);
        }
    }
}
