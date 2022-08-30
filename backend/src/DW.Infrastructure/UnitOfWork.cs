using DW.Domain;
using DW.Domain.Repositories;
using DW.Domain.Services;
using DW.Infrastructure.Database;
using System.Threading.Tasks;

namespace DW.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IInvoiceRepository InvoiceRepository { get; set; }
        public IInvoiceDetailRepository InvoiceDetailRepository { get; set; }

        private readonly PruebaDWContext _pruebaDWContext;

        public UnitOfWork(PruebaDWContext kCTestContext, 
                          ICategoryRepository categoryRepository,
                          ICustomerRepository customerRepository,
                          IProductRepository productRepository,
                          IInvoiceRepository invoiceRepository,
                          IInvoiceDetailRepository invoiceDetailRepository)
        {
            _pruebaDWContext = kCTestContext;
            CategoryRepository = categoryRepository;
            CustomerRepository = customerRepository;
            ProductRepository = productRepository;
            InvoiceRepository = invoiceRepository;
            InvoiceDetailRepository = invoiceDetailRepository;
        }

        public async Task<int> SaveAsync() => await _pruebaDWContext.SaveChangesAsync();

        public void Dispose() => _pruebaDWContext.Dispose();
    }
}
