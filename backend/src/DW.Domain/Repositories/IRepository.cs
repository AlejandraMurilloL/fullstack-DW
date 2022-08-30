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
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit, Expression<Func<TEntity, bool>> expression = null);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> Count(Expression<Func<TEntity, bool>> expression = null);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
