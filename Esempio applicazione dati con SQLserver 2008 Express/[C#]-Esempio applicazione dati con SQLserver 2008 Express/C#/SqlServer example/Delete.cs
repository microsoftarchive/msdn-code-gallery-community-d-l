//dll .netFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Spazio dei nomi SqlSever_example
namespace SqlServer_example
{
    // Classe Delete
    class Delete
    {
        // Dichiaro una variabile di tipo stringa dove viene memorizzato il valore
        // del parametro passato dal metodo setName
        private string name = string.Empty;
        // Dichiaro una variabile di tipo stringa dove viene memorizzato il valore
        // del parametro passato dal metodo setSurName
        private string surName = string.Empty;
        // Dichiaro una variabile di tipo stringa dove viene memorizzato il valore
        // del parametro passato dal metodo setAge
        private string age = string.Empty;

        // Metodo pubblico setName
        public void setName(string name)
        {
            // Assegno alla variabile a livello di classe name il valore del parametro 
            // del metodo setName
            this.name = name;
        }

        // Metodo pubblico getName
        public string getName()
        {
            // Restituisco il valore della variabile a livello di classe name
            return this.name;
        }

        // Metodo pubblico setSurName
        public void setSurName(string surName)
        {
            // Assegno alla variabile a livello di classe surName il valore del parametro 
            // del metodo setSurName
            this.surName = surName;
        }

        // Metodo pubblico getSurName
        public string getSurName()
        {
            // Restituisco il valore della variabile a livello di classe surName
            return this.surName;
        }

        // Metodo pubblico setAge
        public void setAge(string age)
        {
            // Assegno alla variabile a livello di classe age il valore del parametro 
            // del metodo setAge
            this.age = age;
        }

        // Metodo pubblico getAge
        public string getAge()
        {
            // Restituisco il valore della variabile a livello di classe age
            return this.age;
        }
    }
}
