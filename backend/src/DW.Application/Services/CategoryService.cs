using AutoMapper;
using DW.Domain;
using DW.Domain.DTOs;
using DW.Domain.Entities;
using DW.Domain.Exceptions;
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

        public async Task<CategoryDto> GetCategory(int categoryId)
        {
            var exists = await _unitOfWork.CategoryRepository.ExistAsync(x => x.Id == categoryId);

            if (!exists)
                throw new NotFoundException("La categoria seleccionada no existe");

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
            var exists = await _unitOfWork.CategoryRepository.ExistAsync(x => x.Id == categoryDto.Id);

            if (!exists)
                throw new NotFoundException("La categoria seleccionada no existe");

            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var exists = await _unitOfWork.CategoryRepository.ExistAsync(x => x.Id == categoryId);

            if (!exists)
                throw new NotFoundException("La categoria seleccionada no existe");

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
