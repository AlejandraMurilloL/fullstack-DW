using AutoMapper;
using DW.Domain;
using DW.Domain.DTOs;
using DW.Domain.Entities;
using DW.Domain.Services;
using System;
using System.Collections.Generic;
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

        public async Task<CategoryDto> AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public Task DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }

        public Task<CategoryDto> GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
