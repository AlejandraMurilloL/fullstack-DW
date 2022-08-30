using DW.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW.Domain.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int productId);
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> AddProduct(ProductDto productId);
        Task UpdateProduct(ProductDto productId);
        Task DeleteProduct(int productId);
    }
}
