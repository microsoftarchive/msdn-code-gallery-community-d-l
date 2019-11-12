//dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Data;

// Spazio dei nomi SqlSever_example
namespace SqlServer_example
{
    // Classe DataBaseManagement
    class DatabaseManagement
    {
        // Metodo getConnectionString
        private  string getConnectionString()
        {
            // Dichiaro una nuova istanza della Classe SqlConnectionStringBuilder
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            // Assegno il nome del Server alla quale connettersi
            builder.DataSource = @".\SQLEXPRESS";
            // Assegno il nome e il percorso del DataBase alla quale collegarsi
            builder.AttachDBFilename = @"E:\Example.mdf";
            // Gestisco le credenziali di accesso Windows corrente
            builder.IntegratedSecurity = true;
            // Imposto tempo di attesa per connessione a DataBase Example1
            builder.ConnectTimeout = 30;
            builder.UserInstance = true;
            // Restituisco la stringa di Connessione al DataBase
            return builder.ConnectionString;
        }

        // Metodo insertData , richiede tre parametri , il nome , il cognome , l'età per l'inserimento all'interno del DataBase
        public void insertData(string name,string surName,string age)
        {
            // Dichiaro una nuova istanza della Classe SqlConnection
            SqlConnection connection = new SqlConnection(getConnectionString());
            // Dichiaro una TRANSLAT.SQL di inserimnto dati all'interno della Tabella1
            SqlCommand cmd = new SqlCommand("INSERT INTO TABELLA1 (NOME,COGNOME,AGE) VALUES (@NOME,@COGNOME,@AGE)", connection);

            // Prova
            try
            {
                // Eseguo L'inserimento del valore della variabile name all'interno del campo NOME della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@NOME", name.ToUpper());
                // Eseguo L'inserimento del valore della variabile name all'interno del campo COGNOME della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@COGNOME", surName.ToUpper());
                // Eseguo L'inserimento del valore della variabile name all'interno del campo AGE della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@AGE", age.ToUpper());
                // Apro la connessione con il DataBase Example.mdf
                connection.Open();
                // Eseguo l'istruzione TRANSLAT.SQL
                cmd.ExecuteNonQuery();
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
               
            }

            // In caso di eccezzione a runtime
            catch (Exception ex)
            {
                // Visualizzo messaggio errore a ytente
                MessageBox.Show(ex.Message.ToString());
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
            }

            finally
            {
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
            }
        }

        // Metodo deleteData , richiede tre parametri , il nome , il cognome , l'età per l'inserimento all'interno del DataBase
        public void deleteData(string name, string surName, string age)
        {
            // Dichiaro una nuova istanza della Classe SqlConnection
            SqlConnection connection = new SqlConnection(getConnectionString());
            // Dichiaro una TRANSLAT.SQL di eliminazione dati all'interno della Tabella1
            SqlCommand cmd = new SqlCommand("DELETE FROM TABELLA1 WHERE NOME = @NOME AND COGNOME = @COGNOME AND AGE = @AGE",connection);

            // Prova
            try
            {
                // Eseguo L'eliminazione del valore della variabile name all'interno del campo NOME della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@NOME", name.ToUpper());
                // Eseguo L'eliminazione del valore della variabile name all'interno del campo COGNOME della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@COGNOME", surName.ToUpper());
                // Eseguo L'eliminazione del valore della variabile name all'interno del campo AGE della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@AGE", age.ToUpper());
                // Apro la connessione con il DataBase Example.mdf
                connection.Open();
                // Eseguo l'istruzione TRANSLAT.SQL
                cmd.ExecuteNonQuery();
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();

            }

            // In caso di eccezzione a runtime
            catch (Exception ex)
            {
                // Visualizzo messaggio errore a ytente
                MessageBox.Show(ex.Message.ToString());
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
            }

            finally
            {
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
            }
        }

        // Metodo updateData , richiede tre parametri , il nome , il cognome , l'età per l'inserimento all'interno del DataBase
        public void updateData(string name, string surName, string age)
        {
            // Dichiaro una nuova istanza della Classe SqlConnection
            SqlConnection connection = new SqlConnection(getConnectionString());
            // Dichiaro una TRANSLAT.SQL di aggiornamento dati all'interno della Tabella1
            SqlCommand cmd = new SqlCommand("UPDATE TABELLA1 SET NOME = @NOME,COGNOME = @COGNOME,AGE = @AGE WHERE NOME = @NOME" , connection);

            // Prova
            try
            {
                // Eseguo L'aggiornamento del valore della variabile name all'interno del campo NOME della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@NOME", name.ToUpper());
                // Eseguo L'aggiornamento del valore della variabile name all'interno del campo COGNOME della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@COGNOME", surName.ToUpper());
                // Eseguo L'aggiornamento del valore della variabile name all'interno del campo AGE della Tabella1 su DataBase Example.mdf
                cmd.Parameters.AddWithValue("@AGE", age.ToUpper());
                // Apro la connessione con il DataBase Example.mdf
                connection.Open();
                // Eseguo l'istruzione TRANSLAT.SQL
                cmd.ExecuteNonQuery();
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();

            }

            // In caso di eccezzione a runtime
            catch (Exception ex)
            {
                // Visualizzo messaggio errore a ytente
                MessageBox.Show(ex.Message.ToString());
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
            }

            finally
            {
                // Chiudo la connessione con il DataBase Example.mdf
                connection.Close();
                // Libero tutte le risorse associate alla connessione al DataBase Example.mdf
                connection.Dispose();
            }
        }
    }
}
