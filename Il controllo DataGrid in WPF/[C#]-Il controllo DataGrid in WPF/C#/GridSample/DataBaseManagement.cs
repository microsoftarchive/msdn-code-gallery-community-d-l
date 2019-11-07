//Richiamo dll del netFramework
using System.Data;
using System.Data.SqlServerCe;

//Spazio dei Nomi GridSample
namespace GridSample
{
    /*Classe DataBaseManagement
                Questa Classe gestisce la comunicazione trà l'applicazione e la FonteDati.
                E composta da quattro Metodi di cui uno di tipo DataTable il quale popola il Controllo DataGrid
                all'avvio dell'applicazione stassa mediante query Sql Select.
                I metodi InsertData, DeleteData e UpdateData si occupano dell'inserimento , la cancellazione e 
                L'aggiornamento dei Dtai all'interno della Tabella DatiPersonali contenuta nel DataBase Rubrica.sdf*/
    class DataBaseManagement
    {
        /*Definisco una stringa costante sul quale non è possibile modificarne il contenuto , questo solamente come esempio,
                        in un applicazione reale la gestione delle stringhe di connessione e differente.*/
        private const string ConString = "DataSource =" + @"C:\Users\La Monica\Desktop\Rubrica.sdf";
        /*Dichiaro una variabile di tipo stringa  la verrà di volta in volta richiamata dai metodi LoadData , InsertData , DeleteData e UpdateData per
                        la gestione delle loro Query Sql*/
        private string CmdString = string.Empty;

        /*Questo Metodo Popola il DataTable dt con i dati prelevati dalla Tabella DatiPersonali  e lo restituisce al controllo chiamante*/
        public DataTable LoadData()
        {
            using (SqlCeConnection con = new SqlCeConnection(ConString))
            {
                CmdString = "SELECT ID, NOME, COGNOME, INDIRIZZO , TELEFONO , NAZIONALITA FROM DATIPERSONALI";
                SqlCeCommand cmd = new SqlCeCommand(CmdString, con);
                SqlCeDataAdapter sda = new SqlCeDataAdapter(cmd);
                DataTable dt = new DataTable("DATIPERSONALI");
                sda.Fill(dt);
                return dt;
            }
        }

        /*Questo Metodo esegue mediante query Insert l'inserimento dei dati passati dagli argomenti richiesti nome,cognome,indirizzo,telefono e nazionalità
                        Per l'inserimento vengono utilizzati i parameter contenuti nella Classe SqlCeCommand. L'utilizzo dei Parameter ci evità attacchi di SqlJniection diminuendo
                        il rischio che venga inserito del codice maligno che possa avere accesso in modo improprio ai Dati*/
        public void InsertData(string name,string surname,string address , string telephone , string nationality)
        {
            using (SqlCeConnection con = new SqlCeConnection(ConString))
            {
                CmdString = "INSERT INTO DATIPERSONALI (NOME,COGNOME,INDIRIZZO ,TELEFONO ,NAZIONALITA) VALUES (@NOME,@COGNOME,@INDIRIZZO,@TELEFONO,@NAZIONALITA)";
                SqlCeCommand cmd = new SqlCeCommand(CmdString, con);
                cmd.Parameters.AddWithValue("@NOME", name);
                cmd.Parameters.AddWithValue("@COGNOME", surname);
                cmd.Parameters.AddWithValue("@INDIRIZZO", address);
                cmd.Parameters.AddWithValue("@TELEFONO", telephone);
                cmd.Parameters.AddWithValue("@NAZIONALITA", nationality);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /*Questo Metodo esegue mediante query Delete l'eliminazione dei dati passati dagli argomenti richiesti nome,cognome,indirizzo,telefono e nazionalità */
        public void DeleteData(string name, string surname, string address, string telephone, string nationality)
        {
            using (SqlCeConnection con = new SqlCeConnection(ConString))
            {
                CmdString = "DELETE FROM DATIPERSONALI WHERE NOME = @NOME AND COGNOME = @COGNOME";
                SqlCeCommand cmd = new SqlCeCommand(CmdString, con);
                cmd.Parameters.AddWithValue("@NOME", name);
                cmd.Parameters.AddWithValue("@COGNOME", surname);
                cmd.Parameters.AddWithValue("@INDIRIZZO", address);
                cmd.Parameters.AddWithValue("@TELEFONO", telephone);
                cmd.Parameters.AddWithValue("@NAZIONALITA", nationality);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /*Questo Metodo esegue mediante query Update l'aggiornamento dei dati passati dagli argomenti richiesti nome,cognome,indirizzo,telefono e nazionalità 
                        questo secondo l'Id inserito dall'utente , diversamente senza un Id specifico verranno aggiornate tutte le occorrenza che corrispondono a tutti i dati inseriti
                        dall'utente  , se ve ne sono per esempio 1000 saranno tutte aggiornate*/
        public void UpdateData(string name, string surname, string address, string telephone, string nationality, string id)
        {
            using (SqlCeConnection con = new SqlCeConnection(ConString))
            {
                CmdString = "UPDATE DATIPERSONALI SET NOME=@NOME,COGNOME=@COGNOME,INDIRIZZO=@INDIRIZZO,TELEFONO=@TELEFONO,NAZIONALITA=@NAZIONALITA WHERE ID = @ID";
                SqlCeCommand cmd = new SqlCeCommand(CmdString, con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@NOME", name);
                cmd.Parameters.AddWithValue("@COGNOME", surname);
                cmd.Parameters.AddWithValue("@INDIRIZZO", address);
                cmd.Parameters.AddWithValue("@TELEFONO", telephone);
                cmd.Parameters.AddWithValue("@NAZIONALITA", nationality);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
