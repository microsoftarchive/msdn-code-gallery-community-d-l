// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe EliminaDatiRubrica
    class EliminaDatiRubrica
    {
        // Dichiaro una variabile di tipo string ed assegno il valore String.Empty

        string posizioneRubricaEliminato = string.Empty;
        // Questa funzione quando richiamata restituisce il valore della variabile posizioneRubricaEliminato
        // Valorizzata tramite l'altro metodo ovvero setPosizioneRubricaEliminato , il metodo sarà poi richiamato
        // Al momento di eliminare uno o più record dal Database Rubrica aventi lo stesso numero di posizione rubrica
        public string getPosizioneRubricaEliminato()
        {
            // Restituisco il valore di posizioneRubricaEliminato al chiamante
            return this.posizioneRubricaEliminato;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro posizionerubricaeliminato,il metodo sarà poi richiamato
        // nel caso l'utente voglia eliminare dal Database Rubrica il o i record aventi lo stesso numero di posizione rubrica
        // Successivamente la variabile nome può essere recuperata tramite la funzione getPosizioneRubricaEliminato()
        public void setPosizioneRubricaEliminato(string posizionerubricaeliminato)
        {
            // Valorizzo la variabile posizioneRubricaEliminato
            this.posizioneRubricaEliminato = posizionerubricaeliminato;
        }
    }
}
