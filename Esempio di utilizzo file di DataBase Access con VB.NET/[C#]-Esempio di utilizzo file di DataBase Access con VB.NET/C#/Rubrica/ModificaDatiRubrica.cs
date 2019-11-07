// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe ModificaDatiRubrica
    class ModificaDatiRubrica
    {
        // Dichiaro quattro variabili di tipo string ed assegno il valore String.Empty
        string nomeModificato = string.Empty;
        string cognomeModificato = string.Empty;
        string telefonoModificato = string.Empty;

        string posizioneRubrica = string.Empty;
        // Questa funzione quando richiamata restituisce il valore della variabile nomeModificato
        // Valorizzata tramite l'altro metodo ovvero setNomeModificato , il metodo sarà poi richiamato
        // Al momento di riassegnare il nome eventualmente modificato al campo NOME del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getNomeModificato()
        {
            // Restituisco il valore di nomeModificato al chiamante
            return this.nomeModificato;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro nomemodificato,il metodo sarà poi richiamato
        // nel caso l'utente voglia modificare il campo NOME all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile nomeModificato può essere recuperata tramite la funzione getNomeModificato()
        public void setNomeModificato(string nomemodificato)
        {
            // Valorizzo la variabile nomeModificato 
            this.nomeModificato = nomemodificato;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile cognomeModificato
        // Valorizzata tramite l'altro metodo ovvero setCognomeModificato , il metodo sarà poi richiamato
        // Al momento di riassegnare il cognome eventualmente modificato al campo COGNOME del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getCognonmeModoficato()
        {
            // Restituisco il valore di cognomeModificato al chiamante
            return this.cognomeModificato;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro cognomemodificato,il metodo sarà poi richiamato
        // nel caso l'utente voglia modificare il campo COGNOME all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile cognomeModificato può essere recuperata tramite la funzione getCogNomeModificato()
        public void setCognomeModificato(string cognomemodificato)
        {
            // Valorizzo la variabile nomeModificato 
            this.cognomeModificato = cognomemodificato;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile telefonoModificato
        // Valorizzata tramite l'altro metodo ovvero setNumeroTelefono , il metodo sarà poi richiamato
        // Al momento di riassegnare il telefono eventualmente modificato al campo TELEFONO del Database Rubrica della riga selezionata
        // Sul datagridview
        public string getNumeroTelefonoModificato()
        {
            // Restituisco il valore di telefonoModificato al chiamante
            return this.telefonoModificato;
        }

        // Questa Sub quando richiamata si aspetta un parametro tipo string e
        // Valorizzata tramite il parametro telefonodificato,il metodo sarà poi richiamato
        // nel caso l'utente voglia modificare il campo TELEFONO all'interno del Database Rubrica della riga selezionata sul datagridview e
        // Successivamente la variabile telefonoModificato può essere recuperata tramite la funzione getNumeroTelefonoModificato()
        public void setNumeroTelefono(string telefonomodificato)
        {
            // Valorizzo la variabile telefonoModificato 
            this.telefonoModificato = telefonomodificato;
        }

        // Questa funzione quando richiamata restituisce il valore della variabile posizioneRubrica
        // Valorizzata tramite l'altro metodo ovvero setPosizioneRubrica , il metodo sarà poi richiamato
        // Solamente per identificare tramite la clausola WHERE della query sql di modifica , in modo da
        // Modificare i dati appartenenti a tale posizione rubrica
        public string getPosizioneRubrica()
        {
            // Restituisco il valore di posizioneRubrica al chiamante
            return this.posizioneRubrica;
        }

        // Questa Sub quando richiamata restituisce il valore della variabile posizionerubrica
        // Valorizzata tramite l'altro metodo ovvero getPosizioneRubrica , il metodo sarà poi richiamato
        // Solamente per memorizzare e restituire tramite la funzione getPosizioneRubrica il numero di posizione rubrica che sara poi 
        // Confrontato tramite la clausola WHERE della query sql di modifica , in modo da
        // Modificare i dati apparteneti a tale posizione rubrica
        public void setPosizioneRubrica(string posizionerubrica)
        {
            // Valorizzo la variabile posizionerubrica 
            this.posizioneRubrica = posizionerubrica;
        }
    }
}
