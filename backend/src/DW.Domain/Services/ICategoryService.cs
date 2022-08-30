using DW.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW.Domain.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategory(int categoryId);
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> AddCategory(CategoryDto categoryDto);
        Task UpdateCategory(CategoryDto categoryDto);
        Task DeleteCategory(int categoryId);
    }
}
