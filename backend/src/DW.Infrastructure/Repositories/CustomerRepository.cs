using DW.Domain.Entities;
using DW.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DW.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(DbSet<Customer> customers) : base(customers)
        {
            _customers = customers;
        }

        public override async Task<Customer> GetByIdAsync(int id)
        {
            return await _customers.Include(x => x.Invoices).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
