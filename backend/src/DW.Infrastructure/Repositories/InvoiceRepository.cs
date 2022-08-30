using DW.Domain.Entities;
using DW.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly DbSet<Invoice> _invoices;

        public InvoiceRepository(DbSet<Invoice> invoices) : base(invoices)
        {
            _invoices = invoices;
        }

        public override async Task<Invoice> GetByIdAsync(int id)
        {
            return await _invoices.Include(x => x.InvoiceDetails).Include(x => x.Customer).FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _invoices.Include(x => x.InvoiceDetails).Include(x => x.Customer).ToListAsync();
        }
    }
}
