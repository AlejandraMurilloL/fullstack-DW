using AutoMapper;
using DW.Domain;
using DW.Domain.DTOs;
using DW.Domain.Entities;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> GetCategory(int categoryId)
        {
            await CheckIfCategoryExists(categoryId);
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }

        public async Task<CategoryDto> AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            await CheckIfCategoryExists(categoryDto.Id);

            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategory(int categoryId)
        {
            await CheckIfCategoryExists(categoryId);

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
            CheckAssociatedProducts(category);

            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveAsync();
        }

        private async Task CheckIfCategoryExists(int categoryId)
        {
            var exists = await _unitOfWork.CategoryRepository.ExistAsync(x => x.Id == categoryId);

            if (!exists)
                throw new NotFoundException("La categoria seleccionada no existe");
        }

        private static void CheckAssociatedProducts(Category category)
        {
            if (category.Products.Any())
                throw new ConflictException("La Categoria no se puede eliminar porque tiene productos asociados. Asegurese de eliminarlos antes.");

        }
    }
}
