using DW.Domain.Entities;
using DW.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DW.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _entities;

        public Repository(DbSet<TEntity> entities) 
        { 
            _entities = entities;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity) 
        {
            await Task.Run(() => { _entities.Update(entity); });
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression) 
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit, Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.Where(expression)
                           .Skip(skip)
                           .Take(limit)
                           .ToListAsync();
        }

        public void Delete(TEntity entity) 
        {
            _entities.Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity) 
        {
            await Task.Run(() => { Delete(entity); });
        }

        public async virtual Task<int> Count(Expression<Func<TEntity, bool>> expression = null) 
        {
            return await _entities.Where(expression).CountAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate) 
        {
            return await _entities.AnyAsync(predicate);
        } 
    }
}
