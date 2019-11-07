using System;
using System.Collections.Generic;

namespace CslAppEF.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            this.Telefones = new List<Telefone>();
        }

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
