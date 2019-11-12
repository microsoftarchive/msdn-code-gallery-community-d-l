//Spazio dei Nomi GridSample
namespace GridSample
{
    //Classe Insert
    public class Insert
    {
        /*Definsco le proprietà utilizzate per l'inserimento dei Dati all'interno
                        della Tabella DatiPersonali nel DataBase Rubrica.sdf*/
        public string InsertName { get; set; }
        public string InsertSurname { get; set; }
        public string InsertAddress { get; set; }
        public string InsertTelephone { get; set; }
        public string InsertNationality { get; set; }
    }

    //Classe Delete
    public class Delete
    {
        /*Definsco le proprietà utilizzate per la cancellazione dei Dati all'interno
                della Tabella DatiPersonali nel DataBase Rubrica.sdf*/
        public string DeleteName { get; set; }
        public string DeleteSurname { get; set; }
        public string DeleteAddress { get; set; }
        public string DeleteTelephone { get; set; }
        public string DeleteNationality { get; set; }
    }

    //Classe Update
    public class Update
    {
        /*Definsco le proprietà utilizzate per l'aggiornamento dei Dati all'interno
                della Tabella DatiPersonali nel DataBase Rubrica.sdf*/
        public string UpdateId { get; set; }
        public string UpdateName { get; set; }
        public string UpdateSurname { get; set; }
        public string UpdateAddress { get; set; }
        public string UpdateTelephone { get; set; }
        public string UpdateNationality { get; set; }
    }
}
