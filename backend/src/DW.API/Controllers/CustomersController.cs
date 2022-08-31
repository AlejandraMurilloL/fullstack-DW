using DW.Domain.DTOs;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var result = await _customerService.GetCustomers();
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> Get(int customerId)
        {

            try
            {
                var result = await _customerService.GetCustomer(customerId);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Post([FromBody] CustomerDto customerDto)
        {
            var result = await _customerService.AddCustomer(customerDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerDto customerDto)
        {
            try
            {
                await _customerService.UpdateCustomer(customerDto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }            
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            try
            {
                await _customerService.DeleteCustomer(customerId);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflictException e)
            {
                return StatusCode((int)HttpStatusCode.Conflict, e.Message);
            }            
        }
    }
}
