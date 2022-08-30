using DW.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW.Domain.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomer(int categoryId);
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto> AddCustomer(CustomerDto categoryDto);
        Task UpdateCustomer(CustomerDto categoryDto);
        Task DeleteCustomer(int categoryId);
    }
}
