using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _service.GetProductById(id);
            return result.Status switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                _ => BadRequest(result)
            };
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _service.GetAllProducts());
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductRequest model,int categoryId)
        {
            return Ok(await _service.CreateAsync(model,categoryId));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductRequest model, int productId)
        {
            var result = await _service.Update(model, productId);
            return result.Status switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                _ => BadRequest(result)
            };
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result =await _service.Delete(productId);
            return result.Status switch
            {
                200 => Ok(result),
                404 => NotFound(result),
                _ => BadRequest(result)
            };
        }
    }
}