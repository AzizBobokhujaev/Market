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
using Microsoft.CodeAnalysis.FindSymbols;

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

        [HttpGet("GetAllWithSubs")]
        public async Task<IActionResult> GetAllWithSubs()
        {
            return Ok(await _service.GetAllWithSubs());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result =await _service.GetCategoryById(id);
            return result.Status switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                _ => BadRequest(result)
            };
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateCategoryRequest request)
        {
            var result = await _service.CreateAsync(request);
            return result.Status == 200 ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody] UpdateCategoryRequest request)
        {
            var result= await _service.UpdateAsync(id,request);
            return result.Status switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                _ => BadRequest(result)
            };
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result.Status switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                _ => BadRequest(result)
            };
        }
    }
}