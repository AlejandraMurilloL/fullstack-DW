using DW.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace DW.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IInvoiceRepository InvoiceRepository { get; set; }
        IInvoiceDetailRepository InvoiceDetailRepository { get; set; }
        Task<int> SaveAsync();
    }
}
