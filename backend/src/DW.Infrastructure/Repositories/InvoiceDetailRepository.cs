using DW.Domain.Entities;
using DW.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DW.Infrastructure.Repositories
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(DbSet<InvoiceDetail> invoiceDetails) : base(invoiceDetails) 
        {

        }
    }
}
