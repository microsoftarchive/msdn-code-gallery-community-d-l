using KiksApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KiksApp.Core.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
        
        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        
        Task DeleteAsync(TEntity entity);
    }
}
