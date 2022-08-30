using DW.Domain.Entities;
using DW.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductRepository(DbSet<Product> products) : base(products)
        {
            _products = products;
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _products.Include(x => x.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _products.Include(x => x.Category).ToListAsync();
        }
    }
}
