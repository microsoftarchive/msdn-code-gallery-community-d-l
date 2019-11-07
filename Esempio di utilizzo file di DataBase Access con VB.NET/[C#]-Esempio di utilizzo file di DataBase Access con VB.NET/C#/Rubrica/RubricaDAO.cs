// Importazione dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

// Spazio dei nomi Rubrica
namespace Rubrica
{
    // Classe RubricaDAO
    class RubricaDAO
    {
        private const string Connessione = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=%1;Persist Security Info=False";
        /// <summary>
        /// Genera la stringa di connessione per access 2007
        /// </summary>
        /// <param name="NomeDataBase">Nome del database completo di path</param>
        /// <param name="Password">Password del database, eventualmente passare String.Empty</param>
        /// <returns>La stringa già formattata</returns>
        /// <remarks></remarks>
        private string GeneraStringaConnessioneAccess2007(string NomeDataBase, string Password)
        {
            string OutValue = Connessione.Replace("%1", NomeDataBase);
            if (!string.IsNullOrEmpty(Password))
            {
                OutValue = OutValue + "Jet OLEDB:Database Password=" + Password;
            }
            return OutValue;
        }

        // Metodo InserisciDatiRubrica
        // Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        // Successivamente inseriti all'interno del Database Rubrica

        public void InserisciDatiRubrica(string nome, string cognome, string telefono, string posizionerubrica)
        {
            // Questa classe rappresenta una connessione aperta ad un origine Dati,e riceve come parametro la funzione GeneraStringaConnessioneAccess2007
            // Sopraindicata, per comodità ho utilizzato un percorso fisso per l'accesso al file di Database e passato come Password una stringa vuota.
            OleDbConnection connection = new OleDbConnection(GeneraStringaConnessioneAccess2007(@"D:\Rubrica.accdb", string.Empty));
            // Tramite la classe OleDbCommand e possibile eseguire un istruzione sql o una stored procedure in relazione ad un origine dati
            // In questo caso viene eseguita la query sql insert into che recupera i parametri passati dal metodo InserisciDatiRubrica ed aggiunge
            // Un nuovo record al Database Rubrica
            OleDbCommand cmd = new OleDbCommand("INSERT INTO TabellaRubrica (NOME, COGNOME,TELEFONO,POSIZIONE_RUBRICA) VALUES (?,?,?,?)", connection);
            // Tramite la classe OleDbParameter e possibile ottenere un oggetto ed eventualmente il relativo mapping di una colonna
            // Vengono qui valorizzati i campi nome,cognome,telefono e posizione_rubrica e successivamente inseriti nel Database Rubrica
            cmd.Parameters.Add(new OleDbParameter("@NOME", OleDbType.WChar)).Value = nome.ToUpper();
            cmd.Parameters.Add(new OleDbParameter("@COGNOME", OleDbType.WChar)).Value = cognome.ToUpper();
            cmd.Parameters.Add(new OleDbParameter("@TELEFONO", OleDbType.WChar)).Value = telefono.ToUpper();
            cmd.Parameters.Add(new OleDbParameter("@POSIZIONE_RUBRICA", OleDbType.WChar)).Value = posizionerubrica.ToUpper();
            // Apro la connessione al Database Rubrica
            connection.Open();
            // Eseguo l'istruzione sql 
            cmd.ExecuteNonQuery();
            // Chiudo la connessione con il Database Rubrica
            connection.Close();

        }

        // Metodo EliminaDatiRubrica
        // Questo metodo aspetta un parametro di tipo string ,la posizione rubrica che sara utilizzato per verificare , individuare e 
        // Cancellare dalla bancadati il nome , cognome , telefono avente quella posizione di rubrica
        public void EliminaDatiRubrica(string posizionerubricaeliminato)
        {
            // Questa classe rappresenta una connessione aperta ad un origine Dati,e riceve come parametro la funzione GeneraStringaConnessioneAccess2007
            // Sopraindicata, per comodità ho utilizzato un percorso fisso per l'accesso al file di Database e passato come Password una stringa vuota.
            OleDbConnection connection = new OleDbConnection(GeneraStringaConnessioneAccess2007("D:\\Rubrica.accdb", string.Empty));
            // Tramite la classe OleDbCommand e possibile eseguire un istruzione sql o una stored procedure in relazione ad un origine dati
            // In questo caso viene eseguita la query sql delete che recupera il parametro passato dal metodo EliminaDatiRubrica e procede
            // alla cancellazione dei dati del record dal Database Rubrica
            OleDbCommand cmd = new OleDbCommand("DELETE FROM TabellaRubrica WHERE POSIZIONE_RUBRICA = '" + posizionerubricaeliminato + "'", connection);
            // Apro la connessione al Database Rubrica
            connection.Open();
            // Eseguo l'istruzione sql 
            cmd.ExecuteNonQuery();
            // Chiudo la connessione con il Database Rubrica
            connection.Close();

        }

        // Metodo ModificaDatiRubrica
        // Questo metodo aspetta quattro parametri di tipo string , il nome , il cogmome, il telefono e la posizione rubrica che saranno 
        // Successivamente inseriti all'interno del Database Rubrica per apportare modifiche ad uno o piu' campi del Database Rubrica
        public void ModificaDatiRubrica(string nome, string cognome, string telefono, string posizionerubrica)
        {
            // Questa classe rappresenta una connessione aperta ad un origine Dati,e riceve come parametro la funzione GeneraStringaConnessioneAccess2007
            // Sopraindicata, per comodità ho utilizzato un percorso fisso per l'accesso al file di Database e passato come Password una stringa vuota.
            OleDbConnection connection = new OleDbConnection(GeneraStringaConnessioneAccess2007("D:\\Rubrica.accdb", string.Empty));
            // Tramite la classe OleDbCommand e possibile eseguire un istruzione sql o una stored procedure in relazione ad un origine dati
            // In questo caso viene eseguita la query sql update che recupera i parametri passati dal metodo ModificaDatiRubrica e procede
            // con la modifica dei dati sul record al Database Rubrica selezionato
            OleDbCommand cmd = new OleDbCommand("UPDATE TabellaRubrica SET NOME = '" + nome + "' ,COGNOME = '" + cognome + "' ,TELEFONO = '" + telefono + "' WHERE POSIZIONE_RUBRICA = '" + posizionerubrica + "'", connection);
            // Apro la connessione al Database Rubrica
            connection.Open();
            // Eseguo l'istruzione sql 
            cmd.ExecuteNonQuery();
            // Chiudo la connessione con il Database Rubrica
            connection.Close();

        }
    }
}
