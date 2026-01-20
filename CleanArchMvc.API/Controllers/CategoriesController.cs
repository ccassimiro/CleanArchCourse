using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetById(int? id)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetByIdAsync(id.Value);

                if (category == null)
                {
                    return NotFound("Category not found");
                }

                return Ok(category);
            }

            return NotFound("Category not found");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid data.");

            await _categoryService.AddAsync(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id || categoryDto == null)
                return BadRequest("Invalid data.");

            await _categoryService.UpdateAsync(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if(id == null)
                return BadRequest("Invalid data.");

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound("Category not found");

            await _categoryService.RemoveAsync(id.Value);

            return Ok(category);
        }
    }
}
