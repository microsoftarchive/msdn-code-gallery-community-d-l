// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe InserisciDatiRubrica
    class InserisciDatiRubrica
    {
        // Dichiaro quattro variabili di tipo string ed assegno il valore String.Empty
        string nome = string.Empty;
        string cognome = string.Empty;
        string telefono = string.Empty;

        string posizioneRubrica = string.Empty;
        // Questa funzione quando richiamata restituisce il valore della variabile nome
        // Valorizzata tramite l'altro metodo ovvero setNome , il metodo sarà poi richiamato
        // Al momento di inserire il nome al campo NOME del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getNome()
        {
            // Restituisco il valore di nome al chiamante
            return this.nome;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro nome,il metodo sarà poi richiamato
        // nel caso l'utente voglia inserire il nome nel campo NOME all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile nome può essere recuperata tramite la funzione getNome()
        public void setNome(string nome)
        {
            // Valorizzo la variabile nomeModificato 
            this.nome = nome;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile cognome
        // Valorizzata tramite l'altro metodo ovvero setCognome , il metodo sarà poi richiamato
        // Al momento di inserire il cognome al campo COGNOME del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getCognonme()
        {
            // Restituisco il valore di cognome al chiamante
            return this.cognome;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro cognome,il metodo sarà poi richiamato
        // nel caso l'utente voglia inserire il cogmome nel campo COGNOME all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile cognome può essere recuperata tramite la funzione getCogNome()
        public void setCognome(string cognome)
        {
            // Valorizzo la variabile nomeModificato 
            this.cognome = cognome;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile telefono
        // Valorizzata tramite l'altro metodo ovvero setNumeroTelefono , il metodo sarà poi richiamato
        // Al momento di inserire il numero di telefono al campo TELEFONO del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getNumeroTelefono()
        {
            // Restituisco il valore di telefono al chiamante
            return this.telefono;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro telefono,il metodo sarà poi richiamato
        // nel caso l'utente voglia inserire il numero di telefono nel campo TELEFONO all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile telefono può essere recuperata tramite la funzione getNumeroTelefono()
        public void setNumeroTelefono(string telefono)
        {
            // Valorizzo la variabile telefonoModificato 
            this.telefono = telefono;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile posizioneRubrica
        // Valorizzata tramite l'altro metodo ovvero setPosizioneRubrica , il metodo sarà poi richiamato
        // Al momento di inserire il numero di posizione rubrica al campo POSIZIONE_RUBRICA del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getPosizioneRubrica()
        {
            // Restituisco il valore di posizioneRubrica al chiamante
            return this.posizioneRubrica;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro posizionerubrica,il metodo sarà poi richiamato
        // nel caso l'utente voglia inserire il numero di posizone rubrica nel campo POSIZONE_RUBRICA all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile posizioneRubrica può essere recuperata tramite la funzione getPosizioneRubrica()
        public void setPosizioneRubrica(string posizionerubrica)
        {
            // Valorizzo la variabile posizionerubrica 
            this.posizioneRubrica = posizionerubrica;
        }
    }
}
