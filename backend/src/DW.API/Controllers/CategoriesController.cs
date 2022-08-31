using DW.Domain.DTOs;
using DW.Domain.Exceptions;
using DW.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> Get(int categoryId)
        {
            try
            {
                var result = await _categoryService.GetCategory(categoryId);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.AddCategory(categoryDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDto categoryDto)
        {
            try
            {
                await _categoryService.UpdateCategory(categoryDto);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId);
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
