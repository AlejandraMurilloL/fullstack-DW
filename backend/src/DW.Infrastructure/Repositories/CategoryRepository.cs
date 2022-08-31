using DW.Domain.Entities;
using DW.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DW.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;

        public CategoryRepository(DbSet<Category> categories) : base(categories)
        {
            _categories = categories;
        }

        public override async Task<Category> GetByIdAsync(int id)
        {
            return await _categories.Include(x => x.Products).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
