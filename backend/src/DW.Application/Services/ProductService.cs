using AutoMapper;
using DW.Domain;
using DW.Domain.DTOs;
using DW.Domain.Entities;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> GetProduct(int productId)
        {
            await CheckIfProductExists(productId);

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(product.Category.Id);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            await CheckIfProductExists(productDto.Id);

            var product = _mapper.Map<Product>(productDto);

            var productCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(productDto.Category.Id);
            product.Category = productCategory ?? throw new NotFoundException("La Categoria del Producto no existe");

            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            await CheckIfProductExists(productId);

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            CheckAssociatedInvoices(product);

            await _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.SaveAsync();
        }

        private async Task CheckIfProductExists(int productId)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productId);

            if (!exists)
                throw new NotFoundException("El Producto seleccionado no existe");
        }

        private void CheckAssociatedInvoices(Product product)
        {
            if (product.InvoiceDetails.Any())
                throw new ConflictException("El Producto no se puede eliminar porque tiene facturas asociadas. Asegurese de eliminarlas antes.");
        }
    }
}
