using System;
using System.Collections.Generic;

namespace CslAppEF.Models
{
    public partial class Telefone
    {
        public int TelefoneId { get; set; }
        public Nullable<int> PessoaId { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
