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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> GetCustomer(int customerId)
        {
            var exists = await _unitOfWork.CustomerRepository.ExistAsync(x => x.Id == customerId);

            if (!exists)
                throw new NotFoundException("El cliente seleccionado no existe");

            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(customerId);
            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return customersDto;
        }

        public async Task<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            await _unitOfWork.CustomerRepository.AddAsync(customer);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task UpdateCustomer(CustomerDto customerDto)
        {
            var exists = await _unitOfWork.CustomerRepository.ExistAsync(x => x.Id == customerDto.Id);

            if (!exists)
                throw new NotFoundException("El cliente seleccionado no existe");

            var customer = _mapper.Map<Customer>(customerDto);
            await _unitOfWork.CustomerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCustomer(int customerId)
        {
            var exists = await _unitOfWork.CustomerRepository.ExistAsync(x => x.Id == customerId);

            if (!exists)
                throw new NotFoundException("El cliente seleccionado no existe");

            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(customerId);

            if (customer.Invoices.Any())
                throw new ConflictException("El Cliente no se puede eliminar porque tiene facturas asociadas. Asegurese de eliminarlas antes.");

            await _unitOfWork.CustomerRepository.DeleteAsync(customer);
            await _unitOfWork.SaveAsync();
        }
    }
}
