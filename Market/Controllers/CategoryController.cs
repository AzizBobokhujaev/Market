using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Categories;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _service.GetAllCategories());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _service.GetCategoryById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateCategoryRequest request)
        {
            return Ok(await _service.CreateAsync(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody] UpdateCategoryRequest request)
        {
            return Ok(await _service.UpdateAsync(id,request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}