// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe TrovaDatiRubrica
    class TrovaDatiRubrica
    {
        // Dichiaro due variabili di tipo string ed assegno il valore String.Empty
        string tipoRicerca = string.Empty;

        string Ricerca = string.Empty;
        // Questa funzione quando richiamata restituisce il valore della variabile tipoRicerca
        // Valorizzata tramite l'altro metodo ovvero setTipoRicerca , il metodo sarà poi richiamato
        // Al momento di assegnare il tipo di ricerca all'interno del Database Rubrica se per nome , cognome o telefono 
        public string getTipoRicerca()
        {
            // Restituisco il valore di tipoRicerca al chiamante
            return this.tipoRicerca;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro tiporicerca,il metodo sarà poi richiamato
        // Al momento di assegnare il tipo di ricerca all'interno del Database Rubrica se per nome , cognome o telefono 
        public void setTipoRicerca(string tiporicerca)
        {
            // Valorizzo la variabile tipoRicerca
            this.tipoRicerca = tiporicerca;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile Ricerca
        // Valorizzata tramite l'altro metodo ovvero Ricerca , il metodo sarà poi richiamato
        // Al momento di eseguire una ricerca all'interno del Database Rubrica
        public string getRicerca()
        {
            // Restituisco il valore di Ricerca al chiamante
            return this.Ricerca;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro ricerca,il metodo sarà poi richiamato
        // Al momento di assegnare un nome , cognome o telefono da ricercare 
        public void setRicerca(string ricerca)
        {
            // Valorizzo la variabile Ricerca
            this.Ricerca = ricerca;
        }
    }
}
