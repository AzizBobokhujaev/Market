using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects.Products;
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
            return Ok(await _service.GetProductById(id));
        }

        /*[HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductsRequest model)
        {
            return Ok(await _service.CreateAsync(model));
        }*/
    }
}