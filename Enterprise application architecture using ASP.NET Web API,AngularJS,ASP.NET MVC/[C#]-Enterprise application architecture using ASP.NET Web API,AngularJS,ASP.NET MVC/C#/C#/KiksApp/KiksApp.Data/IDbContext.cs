using KiksApp.Core.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KiksApp.Data
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;
        
        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        
        void BeginTransaction();
        
        int Commit();
        Task<int> CommitAsync();
        
        void Rollback();
    }
}
