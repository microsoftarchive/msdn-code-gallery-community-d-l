using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void InsertCollection(List<TEntity> entityCollection);
        void Dispose();
    }
}
