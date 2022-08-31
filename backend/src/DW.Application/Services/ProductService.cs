using AutoMapper;
using DW.Domain;
using DW.Domain.DTOs;
using DW.Domain.Entities;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using System.Collections.Generic;
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
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productId);

            if (!exists)
                throw new NotFoundException("El producto seleccionado no existe");

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
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productDto.Id);

            if (!exists)
                throw new NotFoundException("El Producto seleccionado no existe");

            var productCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(productDto.Category.Id);

            if (productCategory == null)
                throw new NotFoundException("La Categoria del Producto no existe");

            var product = _mapper.Map<Product>(productDto);
            product.Category = productCategory;

            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var exists = await _unitOfWork.ProductRepository.ExistAsync(x => x.Id == productId);

            if (!exists)
                throw new NotFoundException("El Producto seleccionado no existe");

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            await _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
