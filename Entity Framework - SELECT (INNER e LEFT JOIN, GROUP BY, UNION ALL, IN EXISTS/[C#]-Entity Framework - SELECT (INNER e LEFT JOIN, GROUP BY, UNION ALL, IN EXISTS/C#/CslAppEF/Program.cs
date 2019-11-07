using CslAppEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;
namespace CslAppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFrameworkContext Db = new EFrameworkContext())
            {
                // INNER JOIN ****************************************************************************
                //var TelefoneInnerJoinPessoa = Db.Telefones
                //    .AsNoTracking()
                //    .Join(Db.Pessoas, t => t.PessoaId, p => p.PessoaId, (t, p) => new { t, p })                    
                //    .Select(s => new
                //    {
                //        s.t.PessoaId,
                //        s.p.Nome,
                //        s.t.TelefoneId,
                //        s.t.Ddd,
                //        s.t.Numero
                //    }).AsQueryable();
                //var TGeracao = TelefoneInnerJoinPessoa.ToList();
                // INNER JOIN ****************************************************************************

                // LEFT JOIN ****************************************************************************
                //var PessoaLeftJoinTelefone = Db.Pessoas
                //    .AsNoTracking()
                //    .GroupJoin(Db.Telefones, p => p.PessoaId, t => t.PessoaId, (p, t) => new { p, t })
                //    .SelectMany(temp => temp.t.DefaultIfEmpty(), (p, t) => new
                //    {
                //        t.PessoaId,
                //        p.p.Nome,
                //        TelefoneId = (int?)t.TelefoneId,
                //        t.Ddd,
                //        t.Numero
                //    }).AsQueryable();
                //var TGeracaoLeft = PessoaLeftJoinTelefone.ToList(); 
                // LEFT JOIN **************************************************************************** 


                // GROUP BY *****************************************************************************
                //var TelefonesCountByPessoa =
                //    Db.Telefones.AsNoTracking()
                //    .GroupBy(x => x.PessoaId)
                //    .Select(x => new
                //    {
                //        PessoaId = x.Key,
                //        Quantidade = (int?)x.Count()
                //    })
                //    .Join(Db.Pessoas, a => a.PessoaId, p => p.PessoaId, (a, p) => new { a, p })
                //    .Select(s => new
                //    {
                //        s.a.PessoaId,
                //        s.p.Nome,
                //        Quantidade = s.a.Quantidade ?? 0
                //    }).AsQueryable();   
                //var TGeracaoGroup1 = TelefonesCountByPessoa.ToList();

                //var TelefonesCountByPessoa1 =
                //    Db.Telefones.AsNoTracking()
                //    .GroupBy(x => x.PessoaId)
                //    .Select(x => new
                //    {
                //        PessoaId = x.Key,
                //        Quantidade = (int?)x.Count()
                //    }).AsQueryable();

                //var PessoasToTelefonesCountByPessoa1 = Db.Pessoas
                //    .AsNoTracking()
                //    .GroupJoin(TelefonesCountByPessoa1, p => p.PessoaId, a => a.PessoaId, (p, a) => new { p, a })
                //    .SelectMany(temp => temp.a.DefaultIfEmpty(),
                //    (p, a) => new
                //    {
                //        p.p.PessoaId,
                //        Quantidade = a.Quantidade ?? 0,
                //        p.p.Nome
                //    }).AsQueryable();   
                //var TGeracaoGroup2 = PessoasToTelefonesCountByPessoa1.ToList();

                //var PessoasToTelefonesCountByPessoa3 = Db.Pessoas.Select(x => new
                //{
                //    x.PessoaId,
                //    x.Nome,
                //    Quantidade = x.Telefones.LongCount()
                //}).AsQueryable();
                //var TGeracao3 = PessoasToTelefonesCountByPessoa3.ToList();   
                // GROUP BY *****************************************************************************

                // UNION ALL ****************************************************************************
                //var TbAUnionAllTbB = Db.TbAs.Select(x => new
                //{
                //    x.Id,
                //    x.Descricao
                //}).Concat(Db.TbBs.Select(s => new
                //{
                //    s.Id,
                //    s.Descricao
                //})).AsQueryable();

                //var GeracaoUnionAll = TbAUnionAllTbB.ToList();
                // UNION ALL ****************************************************************************

                //IN, NOT IN, EXISTS e NOT EXISTS
                //IN
                //ICollection<int> Lista = Db.TbBs
                //    .AsNoTracking()
                //    .Select(x => x.Id).ToList<int>();                 
                //ICollection<int> lista = new List<int>() { 1, 2 }; VALORES FIXOS

                //var SelectIn = Db.TbAs
                //    .AsNoTracking()
                //    .Where(x => Lista.Contains(x.Id))
                //    .AsQueryable();

                //var GeracaoTIn = SelectIn.ToList();

                //NOT IN
                //var SelectNotIn = Db.TbAs
                //    .AsNoTracking()
                //    .Where(x => !Lista.Contains(x.Id))
                //    .AsQueryable();
                //var GeracaoTNotIn = SelectNotIn.ToList();
                //IN, NOT IN, EXISTS e NOT EXISTS     
           

                //EXISTS
                //var SelectExists = Db.TbAs
                //    .AsNoTracking()
                //    .Where(x => Db.TbBs.Select(a => a.Id).Contains(x.Id))
                //    .AsQueryable();

                //var GeracaoTExists = SelectExists.ToList();

                //EXISTS
                //var SelectNotExists = Db.TbAs
                //    .AsNoTracking()
                //    .Where(x => !Db.TbBs.Select(a => a.Id).Contains(x.Id))
                //    .AsQueryable();

                //var GeracaoTNotExists = SelectNotExists.ToList();
            }
        }
    }
}
