using DI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DIConsoleEntities context;
        internal IDbSet<TEntity> dbSet;

        public Repository(DIConsoleEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void InsertCollection(List<TEntity> entityCollection)
        {
            try
            {
                entityCollection.ForEach(e =>
                {
                    dbSet.Add(e);
                });               
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
