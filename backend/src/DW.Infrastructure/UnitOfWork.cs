using DW.Domain;
using DW.Domain.Repositories;
using DW.Infrastructure.Database;
using System.Threading.Tasks;

namespace DW.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        private readonly PruebaDWContext _pruebaDWContext;

        public UnitOfWork(PruebaDWContext kCTestContext, 
                          ICategoryRepository categoryRepository,
                          ICustomerRepository customerRepository,
                          IProductRepository productRepository)
        {
            _pruebaDWContext = kCTestContext;
            CategoryRepository = categoryRepository;
            CustomerRepository = customerRepository;
            ProductRepository = productRepository;
        }

        public async Task<int> SaveAsync() => await _pruebaDWContext.SaveChangesAsync();

        public void Dispose() => _pruebaDWContext.Dispose();
    }
}
