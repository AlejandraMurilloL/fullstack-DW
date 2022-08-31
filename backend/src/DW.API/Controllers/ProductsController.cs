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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var result = await _productService.GetProducts();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> Get(int productId)
        {
            try
            {
                var result = await _productService.GetProduct(productId);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto productDto)
        {
            var result = await _productService.AddProduct(productDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                await _productService.UpdateProduct(productDto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                await _productService.DeleteProduct(productId);
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
