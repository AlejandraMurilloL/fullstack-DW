using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DW.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
